using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
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
}