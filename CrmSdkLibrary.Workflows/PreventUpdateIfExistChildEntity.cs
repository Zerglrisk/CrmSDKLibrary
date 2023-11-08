using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Linq;

public class PreventUpdateIfExistChildEntity : CodeActivity
{
	#region Arguments

	[RequiredArgument]
	[Input("Child Entity Name")]
	public InArgument<string> ChildEntityName { get; set; }

	[RequiredArgument]
	[Input("Lookup Field Name")]
	public InArgument<string> LookupFieldName { get; set; }

	[RequiredArgument]
	[Input("Access Security Role")]
	[ReferenceTarget("role")]
	public InArgument<EntityReference> AccessSecurityRole { get; set; }

	#endregion Arguments

	protected override void Execute(CodeActivityContext context)
	{
		// Create the tracing service
		ITracingService tracingService = context.GetExtension<ITracingService>();

		// Create the context
		IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
		IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
		IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

		// Check if the user has the necessary security role
		EntityReference securityRole = AccessSecurityRole.Get(context);
		if (service.HasNecessarySecurityRole(workflowContext.UserId, securityRole))
		{
			tracingService.Trace("The user has the necessary security role: {0}", securityRole.Id);
			return;
		}

		// Check if the child entity name is valid
		string childEntityName = ChildEntityName.Get(context);
		if (!service.IsValidEntityName(childEntityName))
		{
			tracingService.Trace("Invalid child entity name: {0}", childEntityName);
			throw new InvalidPluginExecutionException($"Invalid child entity name: {childEntityName}");
		}

		// Check if the lookup field name is valid
		string lookupFieldName = LookupFieldName.Get(context);
		try
		{
			service.GetFieldValue<object>(childEntityName, workflowContext.PrimaryEntityId, lookupFieldName);
		}
		catch (Exception ex)
		{
			tracingService.Trace("Invalid lookup field name: {0}", lookupFieldName);
			throw new InvalidPluginExecutionException($"Invalid lookup field name: {lookupFieldName}", ex);
		}

		// Check if the entity has child records
		if (service.HasChildRecords(childEntityName, lookupFieldName, workflowContext.PrimaryEntityId))
		{
			// If child records exist, throw an exception to prevent the update
			throw new InvalidPluginExecutionException("Cannot update record because child records exist.");
		}
	}
}