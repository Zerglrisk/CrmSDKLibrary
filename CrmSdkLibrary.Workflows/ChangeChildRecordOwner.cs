using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// [Tested] Microsoft.CrmSdk.CoreAssemblies Version v9.0.2.3 Microsoft.CrmSdk.Workflow Version 9.0.2.3
/// </summary>
public class ChangeChildRecordOwner : System.Activities.CodeActivity
{
	#region Arguments

	[RequiredArgument]
	[Input("OwnerId")]
	[ReferenceTarget("systemuser")]
	public InArgument<EntityReference> SystemUserOwnerId { get; set; }

	[RequiredArgument]
	[Input("TeamOwnerId")]
	[ReferenceTarget("team")]
	public InArgument<EntityReference> TeamOwnerId { get; set; }

	[RequiredArgument]
	[Input("BusinesUnitOwnerId")]
	[ReferenceTarget("businessunit")]
	public InArgument<EntityReference> BusinesUnitOwnerId { get; set; }

	/// <summary>
	/// Input Multiple EntityLogicalName using Divider ';'
	/// </summary>
	[RequiredArgument]
	[Input("ChildEntityLogicalNames [Divider ';']")]
	public InArgument<string> ChildEntityLogicalNames { get; set; }

	#endregion Arguments

	protected override void Execute(CodeActivityContext context)
	{
		// Create the tracing service
		ITracingService tracingService = context.GetExtension<ITracingService>();

		// tracingService.Trace("Getting tracing service, workflow context, organization service factory, and organization service from context.");

		// Create the context
		IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
		IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
		IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

		EntityReference ownerId = SystemUserOwnerId.Get(context) ?? TeamOwnerId.Get(context) ?? BusinesUnitOwnerId.Get(context);
		var childEntityLogicalNames = ChildEntityLogicalNames.Get(context)?.Split(new char[] { ';' }, options: StringSplitOptions.RemoveEmptyEntries);

		//tracingService.Trace("Getting values of OwnerId and ChildEntityLogicalName arguments.");

		#region Validation

		//tracingService.Trace("Validating OwnerId value.");
		if (ownerId == null || (ownerId.LogicalName != "systemuser" && ownerId.LogicalName != "team" && ownerId.LogicalName != "businessunit"))
		{
			throw new InvalidPluginExecutionException("Invalid entity type");
		}

		//tracingService.Trace("Validating ChildEntityLogicalName value.");
		if (childEntityLogicalNames == null || childEntityLogicalNames.Length == 0)
		{
			throw new InvalidPluginExecutionException("Invalid argument");
		}

		#endregion Validation

		foreach (var entityLogicalname in childEntityLogicalNames)
		{
			//tracingService.Trace($"Retrieving metadata of {entityLogicalname} entity and checking if it has {workflowContext.PrimaryEntityName} lookup field.");
			var entitymetadata = RetrieveEntity(service, entityLogicalname, EntityFilters.Attributes);
			var attributeMetadata = entitymetadata.Attributes.Where(a => a is LookupAttributeMetadata && (a as LookupAttributeMetadata).Targets.Any(x => x == workflowContext.PrimaryEntityName));

			if (attributeMetadata != null)
			{
				var qe = new QueryExpression(entityLogicalname)
				{
					ColumnSet = new ColumnSet(entitymetadata.PrimaryIdAttribute)
				};

				var filter = new FilterExpression(LogicalOperator.Or);
				foreach (var metadata in attributeMetadata)
				{
					filter.AddCondition(metadata.LogicalName, ConditionOperator.Equal, workflowContext.PrimaryEntityId);
				}
				qe.Criteria.AddFilter(filter);
				var ec = service.RetrieveMultiple(qe);
				foreach (var entity in ec.Entities)
				{
					entity.Attributes["ownerid"] = ownerId;
				}

				if (workflowContext.WorkflowMode == (int)WorkflowMode.Synchronous)
				{
					tracingService.Trace($"Updating retrieved records of {entityLogicalname} entity.");
					foreach (var entity in ec.Entities)
					{
						service.Update(entity);
					}
				}
				else if (workflowContext.Mode == (int)WorkflowMode.Asynchronous)
				{
					tracingService.Trace($"Updating retrieved records of {entityLogicalname} entity.");
					UpdateBulk(service, tracingService, ec, false);
				}

				#region Using Linq Query

				//var ec = new EntityCollection();
				//foreach (var metadata in attributeMetadata)
				//{
				//    //tracingService.Trace($"Getting schema name of {workflowContext.PrimaryEntityName} lookup field.");
				//    var logicalName = metadata.LogicalName;
				//    using (var ocontext = new OrganizationServiceContext(service))
				//    {
				//        //tracingService.Trace($"Retrieving records of {entityLogicalname} entity where {schemaName} equals {workflowContext.PrimaryEntityId}.");
				//        var ecq = from u in ocontext.CreateQuery(entityLogicalname)
				//                  where u.GetAttributeValue<EntityReference>(logicalName).Id == workflowContext.PrimaryEntityId
				//                  select new Entity(u.LogicalName, u.Id);
				//        ec.Entities.AddRange(ecq.ToList());
				//    }
				//    var temp = ec.Entities.Distinct(new EntityEqualityComparer()).ToList();
				//    ec.Entities.Clear();
				//    foreach (var entity in temp)
				//    {
				//        entity.Attributes["ownerid"] = ownerId;
				//        entity.EntityState = EntityState.Changed;
				//        ec.Entities.Add(entity);
				//    }

				//    if (workflowContext.WorkflowMode == (int)WorkflowMode.Synchronous)
				//    {
				//        tracingService.Trace($"Updating retrieved records of {entityLogicalname} entity.");
				//        foreach (var entity in ec.Entities)
				//        {
				//            service.Update(entity);
				//        }
				//    }
				//    else if (workflowContext.Mode == (int)WorkflowMode.Asynchronous)
				//    {
				//        tracingService.Trace($"Updating retrieved records of {entityLogicalname} entity.");
				//        UpdateBulk(service, tracingService, ec, false);
				//    }
				//}

				#endregion Using Linq Query
			}
			else
			{
				tracingService.Trace($"[{entityLogicalname}] Warning : this entity doesn't have '{workflowContext.PrimaryEntityName}' Lookup Field.");
			}
		}
	}

	private void UpdateBulk(in IOrganizationService service, in ITracingService tracingService, EntityCollection ec, bool continueOnError = true)
	{
		var loopCount = (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);

		for (var i = 0; i < loopCount; i++)
		{
			try
			{
				var multipleRequest = new ExecuteMultipleRequest()
				{
					Settings = new ExecuteMultipleSettings()
					{
						ContinueOnError = continueOnError,
						ReturnResponses = true,
					},
					Requests = new OrganizationRequestCollection()
				};

				var start = (i * 1000);
				var end = ec.Entities.Count <= (i + 1) * 1000 ? ec.Entities.Count : (i + 1) * 1000;

				for (var j = start; j < end; j++)
				{
					var updateRequest = new UpdateRequest() { Target = ec.Entities.ElementAt(j) };
					multipleRequest.Requests.Add(updateRequest);
				}

				// Execute all the requests in the request collection using a single web method call.
				var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);

				if (!multipleResponse.Responses.Any()) continue;
				foreach (var response in multipleResponse.Responses)
				{
					if (response.Fault == null) continue;
					if (response.Fault.InnerFault != null)
					{
						if (!continueOnError)
						{
							throw new Exception(response.Fault.InnerFault.Message);

							//throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) +
							//                    Environment.NewLine +
							//                    JsonConvert.SerializeObject(
							//                        ec.Entities[(i * 1000) + response.RequestIndex]));
						}
					}
					else
					{
						if (!continueOnError)
						{
							throw new Exception(response.Fault.Message);

							//throw new Exception(JsonConvert.SerializeObject(response.Fault) + Environment.NewLine +
							//                    JsonConvert.SerializeObject(
							//                        ec.Entities[(i * 1000) + response.RequestIndex]));
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	/// <summary>
	/// Contains the data that is needed to retrieve entity metadata.
	/// </summary>
	/// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveentityrequest?view=dynamics-general-ce-9"/>
	/// <param name="service"></param>
	/// <param name="entityLogicalName"></param>
	/// <param name="entityFilters"></param>
	/// <returns></returns>
	private EntityMetadata RetrieveEntity(in IOrganizationService service, string entityLogicalName,
		EntityFilters entityFilters = EntityFilters.Default) => (service.Execute(new RetrieveEntityRequest()
		{
			EntityFilters = entityFilters,
			LogicalName = entityLogicalName
		}) as RetrieveEntityResponse).EntityMetadata;

	public class EntityEqualityComparer : IEqualityComparer<Entity>
	{
		public bool Equals(Entity x, Entity y)
		{
			return x.Id == y.Id && x.LogicalName == y.LogicalName;
		}

		public int GetHashCode(Entity obj)
		{
			return obj.Id.GetHashCode() ^ obj.LogicalName.GetHashCode();
		}
	}

	public enum WorkflowMode : int
	{
		/// <summary>
		/// Background/Asynchronous
		/// </summary>
		Asynchronous = 0,

		/// <summary>
		/// Real-Time
		/// </summary>
		Synchronous = 1,
	}
}