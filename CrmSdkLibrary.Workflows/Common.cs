using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Linq;
using System.ServiceModel;

public static class Common
{
	public static bool IsValidEntityName(this IOrganizationService service, in string entityName)
	{
		try
		{
			RetrieveEntityRequest request = new RetrieveEntityRequest
			{
				LogicalName = entityName,
				EntityFilters = EntityFilters.Entity
			};

			RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);

			return true;
		}
		catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
		{
			return false;
		}
	}

	public static T GetFieldValue<T>(this IOrganizationService service, in string entityName, in Guid entityId, in string fieldName)
	{
		Entity entity;
		try
		{
			entity = service.Retrieve(entityName, entityId, new Microsoft.Xrm.Sdk.Query.ColumnSet(fieldName));
		}
		catch
		{
			throw new Exception($"'{fieldName}' Field is not valid in this '{entityName}' Entity");
		}
		try
		{
			return entity.GetAttributeValue<T>(fieldName);
		}
		catch
		{
			throw new Exception($"'{fieldName}' is not of type '{typeof(T).FullName}'.");
		}
	}
	public static bool HasChildRecords(this IOrganizationService service, string childEntityName, string lookupFieldName, Guid primaryEntityId)
	{
		QueryExpression query = new QueryExpression(childEntityName);
		query.Criteria.AddCondition(lookupFieldName, ConditionOperator.Equal, primaryEntityId);
		EntityCollection childRecords = service.RetrieveMultiple(query);
		return childRecords.Entities.Count > 0;
	}

	public static bool HasNecessarySecurityRole(this IOrganizationService service, Guid userId, EntityReference securityRole)
	{
		QueryExpression userRoleQuery = new QueryExpression("systemuserroles")
		{
			ColumnSet = new ColumnSet("roleid"),
			Criteria = new FilterExpression
			{
				Conditions =
				{
					new ConditionExpression("roleid", ConditionOperator.NotNull),
					new ConditionExpression("systemuserid", ConditionOperator.Equal, userId),
				}
			}
		};
		EntityCollection userRoles = service.RetrieveMultiple(userRoleQuery);

		if (userRoles.Entities.Any(e => e.GetAttributeValue<EntityReference>("roleid").Id == securityRole.Id || e.GetAttributeValue<EntityReference>("roleid").Name == securityRole.Name))
		{
			return true;
		}

		return false;
	}
}