using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.ServiceModel;

/// <summary>
///
/// </summary>
public class CalculateRollupField : System.Activities.CodeActivity
{
	#region Arguments

	[RequiredArgument]
	[Input("TargetRollupAttributeLogicalName")]
	public InArgument<string> TargetRollupAttributeLogicalName { get; set; }

	[Input("TargetRollupRelatedLookupAttributeLogicalName [Optional]")]
	public InArgument<string> TargetRollupRelatedLookupAttributeLogicalName { get; set; }

	#endregion Arguments

	protected override void Execute(CodeActivityContext context)
	{
		//Create the tracing service
		ITracingService tracingService = context.GetExtension<ITracingService>();

		try
		{
			//Create the context
			IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
			IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
			IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

			if (string.IsNullOrWhiteSpace(this.TargetRollupAttributeLogicalName.Get<string>(context)))
			{
				return;
			}

			if (this.TargetRollupRelatedLookupAttributeLogicalName.Get<string>(context) != null) //&& IsValidEntityName(service, this.TargetRollupRelatedLookupAttributeLogicalName.Get<string>(context)))
			{
				EntityReference value = service.GetFieldValue<EntityReference>(workflowContext.PrimaryEntityName, workflowContext.PrimaryEntityId, this.TargetRollupRelatedLookupAttributeLogicalName.Get<string>(context));
				if (value != null)
				{
					service.Execute(new CalculateRollupFieldRequest()
					{
						Target = value,
						FieldName = this.TargetRollupAttributeLogicalName.Get<string>(context)
					});
				}
				else
				{
					//value is null;
					tracingService.Trace("[Warning]: '{0}' Value is null.", this.TargetRollupRelatedLookupAttributeLogicalName.Get<string>(context));
				}
			}
			else
			{
				service.Execute(new CalculateRollupFieldRequest()
				{
					Target = new EntityReference(workflowContext.PrimaryEntityName, workflowContext.PrimaryEntityId),
					FieldName = this.TargetRollupAttributeLogicalName.Get<string>(context)
				});
			}
		}
		catch (Exception ex)
		{
			tracingService.Trace("[An error has occurred]: {0}", ex.ToString());
			throw;
		}
	}
}