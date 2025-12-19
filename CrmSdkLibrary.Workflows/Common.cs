using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
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

    /// <summary>
    /// Get User's TimeZoneBias For using DateTime
    /// </summary>
    /// <param name="service"></param>
    /// <param name="systemUserId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static int GetUserTimeZoneBias(in IOrganizationService service, Guid systemUserId)
    {
        EntityCollection ec = service.RetrieveMultiple(new QueryExpression("usersettings")
        {
            ColumnSet = new ColumnSet("timezonebias"),
            Criteria = new FilterExpression()
            {
                Conditions =
                    {
                        new ConditionExpression("systemuserid", ConditionOperator.Equal, systemUserId)
                    }
            }
        });
        if (ec.Entities.Count < 1)
        {
            throw new Exception("Failed to retrieve the user settings record.");
        }
        return ec.Entities.First().GetAttributeValue<int>("timezonebias");
    }

    /// <summary>
    /// Returns the datetime adjusted for the user’s timezone bias based on the received date parameter.
    /// to use plugin system service (system service only using utc time.)
    /// ex)
    /// new ConditionExpression("createdon", ConditionOperator.GreaterEqual, date.AddMinutes(timezonebias)));
    /// new ConditionExpression("createdon", ConditionOperator.LessEqual, date.AddMinutes(timezonebias).AddDays(1).AddTicks(-1)));
    /// </summary>
    /// <param name="service"></param>
    /// <param name="systemUserId"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetUserDateTime(in IOrganizationService service, in Guid systemUserId, DateTime date)
    {
        return date.AddMinutes(-GetUserTimeZoneBias(service, systemUserId));
    }
}