//using Microsoft.Xrm.Sdk;
//using Microsoft.Xrm.Sdk.Messages;
//using Microsoft.Xrm.Sdk.Metadata;
//using Microsoft.Xrm.Sdk.Query;
//using Microsoft.Xrm.Sdk.Workflow;
//using System;
//using System.Activities;
//using System.ComponentModel;
//using System.Linq;
//using System.Text.RegularExpressions;

//public class UpdateChildRecords : System.Activities.CodeActivity
//{
//    [Input("Child Entity Logical Name")]
//    [Description("Enter the logical name of the child entity to update")]
//    [RequiredArgument]
//    public InArgument<string> ChildEntityName { get; set; }

//    [Input("Parent Lookup Field")]
//    [Description("Enter the logical name of the lookup field in child entity that references the parent (e.g., 'new_l_project')")]
//    [RequiredArgument]
//    public InArgument<string> ParentLookupField { get; set; }

//    [Input("Target Attribute")]
//    [Description("Enter the logical name of the field to update in the child entity")]
//    [RequiredArgument]
//    public InArgument<string> TargetAttribute { get; set; }

//    [Input("Value Pattern")]
//    [Description(@"Enter the pattern to generate new values. Use:
//- ${field_name} to use parent entity field value
//- ${C.field_name} to use child entity field value
//- ${*field_name} to use parent entity field value and keep the part after separator
//- $#{separator} to specify the separator character (default is '_')

//Examples:
//1. '${new_name}_suffix' → If parent's new_name is 'TEST', result will be 'TEST_suffix'
//2. '${new_name}_${C.new_type}' → Combines parent's new_name with child's new_type
//3. '[${C.new_type}] ${*new_name}$#{_}' → If current value is 'M15_변경 사항', result will be 'M16_변경 사항'")]
//    [RequiredArgument]
//    public InArgument<string> ValuePattern { get; set; }

//    protected override void Execute(CodeActivityContext executionContext)
//    {
//        IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
//        IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
//        IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

//        string childEntity = ChildEntityName.Get(executionContext);
//        string parentLookup = ParentLookupField.Get(executionContext);
//        string targetAttr = TargetAttribute.Get(executionContext);
//        string valuePattern = ValuePattern.Get(executionContext);

//        ValidateAttribute(service, childEntity, targetAttr);
//        ValidateAttribute(service, childEntity, parentLookup);

//        Entity parentRecord = service.Retrieve(context.PrimaryEntityName, context.PrimaryEntityId, new ColumnSet(true));

//        QueryExpression qe = new QueryExpression(childEntity)
//        {
//            ColumnSet = new ColumnSet(true),
//            Criteria = new FilterExpression()
//            {
//                Conditions =
//                {
//                    new ConditionExpression(parentLookup, ConditionOperator.Equal, context.PrimaryEntityId)
//                }
//            }
//        };
//        EntityCollection childRecords = service.RetrieveMultiple(qe);

//        // Find separator
//        string startSeparator = "_"; // default separator
//        var separatorMatch = Regex.Match(valuePattern, @"\$#{([^}]+)}");
//        if (separatorMatch.Success)
//        {
//            startSeparator = separatorMatch.Groups[1].Value;
//        }

//        foreach (Entity childRecord in childRecords.Entities)
//        {
//            string currentValue = childRecord.GetAttributeValue<string>(targetAttr) ?? string.Empty;
//            if (string.IsNullOrEmpty(currentValue)) continue;

//            string finalValue = valuePattern;

//            // Process child entity field references (${C.field})
//            var childVariables = Regex.Matches(finalValue, @"\${C\.([^}]+)}");
//            foreach (Match match in childVariables)
//            {
//                string fieldName = match.Groups[1].Value;
//                if (!childRecord.Contains(fieldName))
//                {
//                    throw new InvalidPluginExecutionException(
//                        $"Field '{fieldName}' not found in child entity.");
//                }
//                string value = GetFormattedValue(childRecord[fieldName], fieldName, childRecord);
//                finalValue = finalValue.Replace(match.Value, value);
//            }

//            // Process wildcarded parent references (${*field})
//            var parentWildcardVariables = Regex.Matches(finalValue, @"\${(\*[^}]+)}");
//            foreach (Match match in parentWildcardVariables)
//            {
//                string fieldPattern = match.Groups[1].Value.TrimStart('*');
//                var matchingField = parentRecord.Attributes
//                    .FirstOrDefault(a => a.Key.Contains(fieldPattern));

//                if (matchingField.Key != null)
//                {
//                    string value = GetFormattedValue(matchingField.Value, matchingField.Key, parentRecord);
//                    finalValue = finalValue.Replace(match.Value, value);

//                    // Keep the part after separator from current value
//                    if (startSeparator != null)
//                    {
//                        int sepIndex = currentValue.IndexOf(startSeparator);
//                        if (sepIndex >= 0)
//                        {
//                            string afterSeparator = currentValue.Substring(sepIndex);
//                            finalValue = Regex.Replace(finalValue, @"\$#{[^}]+}", afterSeparator);
//                        }
//                    }
//                }
//            }

//            // Process regular parent field references (${field})
//            var parentVariables = Regex.Matches(finalValue, @"\${([^C\*\.][^}]+)}");
//            foreach (Match match in parentVariables)
//            {
//                string fieldName = match.Groups[1].Value;
//                if (!parentRecord.Contains(fieldName))
//                {
//                    throw new InvalidPluginExecutionException(
//                        $"Field '{fieldName}' not found in parent entity.");
//                }
//                string value = GetFormattedValue(parentRecord[fieldName], fieldName, parentRecord);
//                finalValue = finalValue.Replace(match.Value, value);
//            }

//            // Update child record if value has changed
//            if (finalValue != currentValue)
//            {
//                Entity updateEntity = new Entity(childRecord.LogicalName, childRecord.Id);
//                updateEntity[targetAttr] = finalValue;
//                service.Update(updateEntity);
//            }
//        }
//    }

//    private void ValidateAttribute(IOrganizationService service, string entityName, string attributeName)
//    {
//        var request = new RetrieveEntityRequest
//        {
//            EntityFilters = EntityFilters.Attributes,
//            LogicalName = entityName
//        };

//        var response = (RetrieveEntityResponse)service.Execute(request);

//        if (!response.EntityMetadata.Attributes.Any(a => a.LogicalName == attributeName))
//        {
//            throw new InvalidPluginExecutionException(
//                $"Attribute '{attributeName}' does not exist in entity '{entityName}'");
//        }
//    }

//    private string GetFormattedValue(object value, string fieldName, Entity entity)
//    {
//        if (value == null) return string.Empty;

//        switch (value)
//        {
//            case DateTime dateTime:
//                return dateTime.ToString("yyyy-MM-dd HH:mm:ss");

//            case Money money:
//                return money.Value.ToString();

//            case OptionSetValue optionSet:
//                // Try to get formatted value first
//                string formattedOptionSet = entity.FormattedValues.Contains(fieldName)
//                    ? entity.FormattedValues[fieldName]
//                    : string.Empty;
//                return !string.IsNullOrEmpty(formattedOptionSet)
//                    ? formattedOptionSet
//                    : optionSet.Value.ToString();

//            case EntityReference entityRef:
//                // Try to get formatted value first
//                string formattedReference = entity.FormattedValues.Contains(fieldName)
//                    ? entity.FormattedValues[fieldName]
//                    : string.Empty;
//                if (!string.IsNullOrEmpty(formattedReference))
//                    return formattedReference;

//                // Fallback to Name or Id
//                return !string.IsNullOrEmpty(entityRef.Name)
//                    ? entityRef.Name
//                    : entityRef.Id.ToString();

//            default:
//                return value.ToString();
//        }
//    }
//}