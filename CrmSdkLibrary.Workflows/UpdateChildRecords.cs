using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

public class UpdateChildRecords : System.Activities.CodeActivity
{
    [Input("Child Entity Logical Name")]
    [Description("Enter the logical name of the child entity to update")]
    [RequiredArgument]
    public InArgument<string> ChildEntityName { get; set; }

    [Input("Parent Lookup Field")]
    [Description("Enter the logical name of the lookup field in child entity that references the parent (e.g., 'new_l_project')")]
    [RequiredArgument]
    public InArgument<string> ParentLookupField { get; set; }

    [Input("Target Attribute")]
    [Description("Enter the logical name of the field to update in the child entity")]
    [RequiredArgument]
    public InArgument<string> TargetAttribute { get; set; }

    [Input("Value Pattern")]
    [Description(@"Enter the pattern to generate new values. Use:
- ${field_name} to use parent entity field value
- ${C.field_name} to use child entity field value
- ${*field_name} to use parent entity field value and keep the part between separators
- $#{separator} to specify the start separator character
- #{separator} to specify the end separator character (optional)

Examples:
1. '${new_name}_suffix' → If parent's new_name is 'TEST', result will be 'TEST_suffix'
2. '${new_name}_${C.new_type}' → Combines parent's new_name with child's new_type
3. '[${C.new_p_type}] ${*new_name}$#{_}#{ (} (Owner : ${C.ownerid})' → Preserves content between separators")]
    [RequiredArgument]
    public InArgument<string> ValuePattern { get; set; }

    protected override void Execute(CodeActivityContext executionContext)
    {
        IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
        IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
        IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

        string childEntity = ChildEntityName.Get(executionContext);
        string parentLookup = ParentLookupField.Get(executionContext);
        string targetAttr = TargetAttribute.Get(executionContext);
        string valuePattern = ValuePattern.Get(executionContext);

        ValidateAttribute(service, childEntity, targetAttr);
        ValidateAttribute(service, childEntity, parentLookup);

        Entity parentRecord = service.Retrieve(context.PrimaryEntityName, context.PrimaryEntityId, new ColumnSet(true));

        QueryExpression qe = new QueryExpression(childEntity)
        {
            ColumnSet = new ColumnSet(true),
            Criteria = new FilterExpression()
            {
                Conditions =
                {
                    new ConditionExpression(parentLookup, ConditionOperator.Equal, context.PrimaryEntityId)
                }
            }
        };
        EntityCollection childRecords = service.RetrieveMultiple(qe);

        // Find start and end separators
        string startSeparator = null;
        string endSeparator = null;
        var startSeparatorMatch = Regex.Match(valuePattern, @"\$#{([^}]+)}");
        if (startSeparatorMatch.Success)
        {
            startSeparator = startSeparatorMatch.Groups[1].Value;

            // Look for end separator only if start separator exists
            var endSeparatorMatch = Regex.Match(valuePattern, @"#{([^}]+)}");
            while (endSeparatorMatch.Success && endSeparatorMatch.Index > 0 && valuePattern[endSeparatorMatch.Index - 1] == '$')
            {
                endSeparatorMatch = endSeparatorMatch.NextMatch();
            }
            if (endSeparatorMatch.Success)
            {
                endSeparator = endSeparatorMatch.Groups[1].Value;
            }
        }

        foreach (Entity childRecord in childRecords.Entities)
        {
            string currentValue = childRecord.GetAttributeValue<string>(targetAttr) ?? string.Empty;
            if (string.IsNullOrEmpty(currentValue)) continue;

            string finalValue = valuePattern;

            // Process child entity field references (${C.field})
            var childVariables = Regex.Matches(finalValue, @"\${C\.([^}]+)}");
            foreach (Match match in childVariables)
            {
                string fieldName = match.Groups[1].Value;
                if (!childRecord.Contains(fieldName))
                {
                    throw new InvalidPluginExecutionException($"Field '{fieldName}' not found in child entity.");
                }
                string value = GetFormattedValue(childRecord.Attributes[fieldName], fieldName, childRecord);
                finalValue = finalValue.Replace(match.Value, value);
            }

            // Process wildcarded parent references (${*field})
            var parentWildcardVariables = Regex.Matches(finalValue, @"\${(\*[^}]+)}");
            foreach (Match match in parentWildcardVariables)
            {
                string fieldPattern = match.Groups[1].Value.TrimStart('*');
                var matchingField = parentRecord.Attributes.FirstOrDefault(a => a.Key.Contains(fieldPattern));

                if (matchingField.Key != null)
                {
                    string value = GetFormattedValue(matchingField.Value, matchingField.Key, parentRecord);
                    finalValue = finalValue.Replace(match.Value, value);

                    // Keep the part between/after separators from current value
                    if (startSeparator != null)
                    {
                        int startIdx = currentValue.IndexOf(startSeparator);
                        if (startIdx >= 0)
                        {
                            startIdx += startSeparator.Length;
                            string preservedContent;

                            // Get preserved content first
                            if (endSeparator != null)
                            {
                                // Find end separator with exact pattern " ("
                                int endIdx = currentValue.IndexOf(" (", startIdx);
                                if (endIdx <= startIdx) endIdx = currentValue.Length;
                                preservedContent = currentValue.Substring(startIdx, endIdx - startIdx);
                            }
                            else
                            {
                                preservedContent = currentValue.Substring(startIdx);
                            }

                            // Replace the wildcarded parent field first
                            finalValue = finalValue.Replace(match.Value, value);

                            // Then replace the complete separator pattern with preserved content
                            string separatorPattern = @"\$#{" + Regex.Escape(startSeparator) + @"}#{[^}]+}";
                            finalValue = Regex.Replace(finalValue, separatorPattern, startSeparator + preservedContent);
                        }
                    }
                }
            }

            // Process regular parent field references (${field})
            var parentVariables = Regex.Matches(finalValue, @"\${([^C\*\.][^}]+)}");
            foreach (Match match in parentVariables)
            {
                string fieldName = match.Groups[1].Value;
                if (!parentRecord.Contains(fieldName))
                {
                    throw new InvalidPluginExecutionException($"Field '{fieldName}' not found in parent entity.");
                }
                string value = GetFormattedValue(parentRecord.Attributes[fieldName], fieldName, parentRecord);
                finalValue = finalValue.Replace(match.Value, value);
            }

            // Update child record if value has changed
            if (finalValue != currentValue)
            {
                Entity updateEntity = new Entity(childRecord.LogicalName, childRecord.Id);
                updateEntity.Attributes[targetAttr] = finalValue;
                service.Update(updateEntity);
            }
        }
    }

    private void ValidateAttribute(IOrganizationService service, string entityName, string attributeName)
    {
        var request = new RetrieveEntityRequest
        {
            EntityFilters = EntityFilters.Attributes,
            LogicalName = entityName
        };

        var response = (RetrieveEntityResponse)service.Execute(request);

        if (!response.EntityMetadata.Attributes.Any(a => a.LogicalName == attributeName))
        {
            throw new InvalidPluginExecutionException($"Attribute '{attributeName}' does not exist in entity '{entityName}'");
        }
    }

    private string GetFormattedValue(object value, string fieldName, Entity entity)
    {
        if (value == null) return string.Empty;

        switch (value)
        {
            case DateTime dateTime:
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            case Money money:
                return money.Value.ToString();

            case OptionSetValue optionSet:
                return entity.FormattedValues.Contains(fieldName) ? entity.FormattedValues[fieldName] : string.Empty;

            case EntityReference entityRef:
                return entity.FormattedValues.Contains(fieldName) ? entity.FormattedValues[fieldName] : string.Empty;

            default:
                return value.ToString();
        }
    }
}