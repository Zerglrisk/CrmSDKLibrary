using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace CrmSdkLibrary.Retrieves
{
    public class UserView
    {
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
                var qe = new QueryExpression("userquery")
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

                var a = Messages.QueryExpressionToFetchXml(service,qe);
                if (Connection.OrgServiceType == typeof(OrganizationServiceProxy))
                {
                    var serviceProxy = (OrganizationServiceProxy)service;

                    serviceProxy.CallerId = Messages.GetCurrentUserId(service);
                    return serviceProxy.RetrieveMultiple(qe);
                }
                else if (Connection.OrgServiceType == typeof(CrmServiceClient))
                {
                    var client = (CrmServiceClient)service;
                    client.CallerId = Messages.GetCurrentUserId(service);
                    return client.RetrieveMultiple(qe);
                }
                return service.RetrieveMultiple(qe);
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
                return service.Retrieve("savedquery", viewId, new ColumnSet(true));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
