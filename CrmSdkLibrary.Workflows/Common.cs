using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Linq;
using System.ServiceModel;
using System.Web.Services.Description;

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

	public static bool IsValidAttributeForEntity(this IOrganizationService service, string entityName, string attributeName)
	{
		try
		{
			// Retrieve the entity metadata with the attributes
			RetrieveEntityRequest request = new RetrieveEntityRequest
			{
				LogicalName = entityName,
				EntityFilters = EntityFilters.Attributes
			};

			RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
			EntityMetadata metadata = response.EntityMetadata;

			// Check if the attribute exists in the entity
			return metadata.Attributes.Any(a => a.LogicalName.Equals(attributeName, StringComparison.InvariantCultureIgnoreCase));
		}
		catch (FaultException<OrganizationServiceFault>)
		{
			// If there's a fault exception, the entity or attribute doesn't exist
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
		if(securityRole == null)
		{
			return false;
		}

		// Retrieve the role name
		Entity role = service.Retrieve("role", securityRole.Id, new ColumnSet("name"));
		string roleName = role.GetAttributeValue<string>("name");

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
			},
			LinkEntities =
			{
				new LinkEntity("systemuserroles", "role", "roleid", "roleid", JoinOperator.Inner)
				{
					Columns = new ColumnSet("name"),
					EntityAlias = "role"
				}
			}
		};
		EntityCollection userRoles = service.RetrieveMultiple(userRoleQuery);

		if (userRoles.Entities.Any(e => e.GetAttributeValue<Guid>("roleid") == securityRole.Id 
		|| e.GetAliasedValue<string>("role.name") == roleName))
		{
			return true;
		}

		return false;
	}

	private static readonly Guid AdminRoleTemplateId = new Guid("627090FF-40A3-4053-8790-584EDC5BE201");

	public static bool HavingAdminRole(this IOrganizationService service, Guid systemUserId)
	{
		var query = new QueryExpression("role");
		query.Criteria.AddCondition("roletemplateid", ConditionOperator.Equal, AdminRoleTemplateId);
		var link = query.AddLink("systemuserroles", "roleid", "roleid");
		link.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, systemUserId);

		return service.RetrieveMultiple(query).Entities.Count > 0;
	}

	public static T GetAliasedValue<T>(this Entity entity, string attributeName)
	{
		if (!entity.Contains(attributeName))
		{
			return default;
		}
		if (entity.Attributes[attributeName].GetType() != typeof(AliasedValue))
		{
			return default;
		}

		return (T)entity.GetAttributeValue<AliasedValue>(attributeName).Value;
	}
}