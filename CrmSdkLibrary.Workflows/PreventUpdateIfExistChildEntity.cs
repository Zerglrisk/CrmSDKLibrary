using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Security.Principal;

/// <summary>
/// Realtime WorkFlow
/// NEED TEST - in CRM 2016 dosen't create systemService well ; test failed.
/// </summary>
public class PreventUpdateIfExistChildEntity : CodeActivity
{
	#region Arguments

	[RequiredArgument]
	[Input("Child Entity Name")]
	public InArgument<string> ChildEntityName { get; set; }

	[RequiredArgument]
	[Input("Lookup Field Name")]
	public InArgument<string> LookupFieldName { get; set; }

	[Input("Access Security Role")]
	[ReferenceTarget("role")]
	public InArgument<EntityReference> AccessSecurityRole { get; set; }

	[Input("Access Security Role2")]
	[ReferenceTarget("role")]
	public InArgument<EntityReference> AccessSecurityRole2 { get; set; }

	[Input("Access Security Role3")]
	[ReferenceTarget("role")]
	public InArgument<EntityReference> AccessSecurityRole3 { get; set; }

	[Input("Access SystemUser")]
	[ReferenceTarget("systemuser")]
	public InArgument<EntityReference> AcesssSystemUser { get; set; }

	[Input("Access SystemUser2")]
	[ReferenceTarget("systemuser")]
	public InArgument<EntityReference> AcesssSystemUser2 { get; set; }

	[Input("Access SystemUser3")]
	[ReferenceTarget("systemuser")]
	public InArgument<EntityReference> AcesssSystemUser3 { get; set; }

	#endregion Arguments

	protected override void Execute(CodeActivityContext context)
	{
		// Create the context
		IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
		IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
		IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);
		IOrganizationService systemService = serviceFactory.CreateOrganizationService(null);

		// Create the tracing service
		ITracingService tracingService = context.GetExtension<ITracingService>();

		// Check if the user access systemuser
		EntityReference[] systemUsers = new EntityReference[] { AcesssSystemUser.Get(context), AcesssSystemUser2.Get(context), AcesssSystemUser3.Get(context) };
		foreach (var systemUser in systemUsers)
		{
			if (systemUser != null && workflowContext.UserId == systemUser.Id)
			{
				return;
			}
		}

		//check is system administrator
		if (service.HavingAdminRole(workflowContext.UserId))
		{
			return;
		}

		// Check if the user has the necessary security role
		EntityReference[] securityRoles = new EntityReference[] { AccessSecurityRole.Get(context), AccessSecurityRole2.Get(context), AccessSecurityRole3.Get(context) };
		foreach (var securityRole in securityRoles)
		{
			if (service.HasNecessarySecurityRole(workflowContext.UserId, securityRole))
			{
				return;
			}
		}

		// Check if the child entity name is valid
		string childEntityName = ChildEntityName.Get(context);
		if (!service.IsValidEntityName(childEntityName))
		{
			throw new InvalidPluginExecutionException($"Invalid child entity name: {childEntityName}");
		}

		// Check if the lookup field name is valid
		string lookupFieldName = LookupFieldName.Get(context);
		if(!service.IsValidAttributeForEntity(childEntityName, lookupFieldName))
		{
			throw new InvalidPluginExecutionException($"Invalid lookup field name: {lookupFieldName}");
		}

		// Check if the entity has child records - test Failed systemService not work as SYSTEM
		if (systemService.HasChildRecords(childEntityName, lookupFieldName, workflowContext.PrimaryEntityId))
		{
			throw new InvalidPluginExecutionException("Cannot update record because child records exist.");
		}
	}
}