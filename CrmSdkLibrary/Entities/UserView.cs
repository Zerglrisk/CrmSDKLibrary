using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace CrmSdkLibrary.Entities
{
	public class UserView
	{
		private static int? _entityTypeCode;

		public static int? EntityTypeCode =>
			_entityTypeCode ?? (_entityTypeCode = Connection.Service != null
				? Messages.GetEntityTypeCode(Connection.Service, EntityLogicalName)
				: _entityTypeCode);

		public const string EntityLogicalName = "userquery";
		public const string EntitySetPath = "userqueries";
		public const string DisplayName = "Saved View";
		public const string PrimaryKey = "userqueryid";
		public const string PrimaryKeyAttribute = "name";

		/// <summary>
		///
		/// </summary>
		/// <see cref="https://www.crmanswers.net/2015/01/retrieve-saved-views-userquery-users.html"/>
		/// <param name="service"></param>
		/// <param name="entityLogicalName"></param>
		/// <returns></returns>
		public static EntityCollection RetrieveViews(IOrganizationService service, string entityLogicalName, bool isAll = false)
		{
			try
			{
				var qe = new QueryExpression(EntityLogicalName)
				{
					ColumnSet = new ColumnSet(true),
					Criteria = new FilterExpression()
					{
						Conditions =
						{
							new ConditionExpression("returnedtypecode", ConditionOperator.Equal, Messages.GetEntityTypeCode(service ,entityLogicalName))
						}
					}
				};
				if (!isAll)
				{
					qe.Criteria.Conditions.Add(new ConditionExpression("layoutxml", ConditionOperator.NotNull));
				}

				var a = Messages.QueryExpressionToFetchXml(service, qe);

				var client = (CrmServiceClient)service;

				//client.CallerId = Messages.GetCurrentUserId(service);
				client.CallerId = ((CrmServiceClient)service).GetMyCrmUserId();
				return client.RetrieveMultiple(qe);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Retrieve View(userquery) Entity
		/// </summary>
		/// <param name="service"></param>
		/// <param name="viewId"></param>
		/// <returns></returns>
		public static Entity RetrieveView(IOrganizationService service, Guid viewId)
		{
			try
			{
				return service.Retrieve("userquery", viewId, new ColumnSet(true));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}