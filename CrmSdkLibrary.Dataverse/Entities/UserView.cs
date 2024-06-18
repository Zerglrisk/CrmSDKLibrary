using CrmSdkLibrary.Dataverse;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.PowerPlatform.Dataverse.Client.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace CrmSdkLibrary.Dataverse.Entities
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

				var client = (ServiceClient)service;

				//client.CallerId = Messages.GetCurrentUserId(service);
				client.CallerId = ((ServiceClient)service).GetMyUserId();
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

		public static EntityCollection GetAllUsersPersonalViews<T>(in T service) where T : IOrganizationService
		{
			EntityCollection views = new EntityCollection()
			{
				EntityName = "userquery",
			};

			Guid originalCallerId = Guid.Empty;
			if (service is OrganizationServiceProxy serviceProxy)
			{
				originalCallerId = serviceProxy.CallerId;
			}
			else if (service is ServiceClient serviceClient)
			{
				originalCallerId = serviceClient.CallerId;
			}

			EntityCollection users = service.RetrieveMultiple(new QueryExpression("systemuser")
			{
				ColumnSet = new ColumnSet("systemuserid"),
				Criteria = new FilterExpression()
				{
					Conditions =
					{
						new ConditionExpression("isdisabled", ConditionOperator.Equal, false)
					}
				}
			});

			foreach (Entity user in users.Entities)
			{
				if (service is OrganizationServiceProxy tserviceProxy)
				{
					tserviceProxy.CallerId = user.Id;
				}
				else if (service is ServiceClient tserviceClient)
				{
					tserviceClient.CallerId = user.Id;
				}

				EntityCollection userViews = service.RetrieveMultiple(new QueryExpression("userquery") { ColumnSet = new ColumnSet(true) });

				views.Entities.AddRange(userViews.Entities);
			}

			if (service is OrganizationServiceProxy orgServiceProxy)
			{
				orgServiceProxy.CallerId = originalCallerId;
			}
			else if (service is ServiceClient svcClient)
			{
				svcClient.CallerId = originalCallerId;
			}

			views.TotalRecordCount = views.Entities.Count;

			return views;
		}
	}
}