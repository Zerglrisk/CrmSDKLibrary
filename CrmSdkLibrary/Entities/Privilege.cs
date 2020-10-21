using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary.Entities
{
    public class Privilege
    {
        private int? _entityTypeCode;
        public int? EntityTypeCode =>
            _entityTypeCode ?? (_entityTypeCode = Connection.OrgService != null
                ? Messages.GetEntityTypeCode(Connection.OrgService, EntityLogicalName)
                : _entityTypeCode);
        public const string EntityLogicalName = "privilege";
        public const string EntitySetPath = "privileges";
        public const string DisplayName = "Privilege";
        public const string PrimaryKey = "privilegeid";
        public const string PrimaryKeyAttribute = "name";

        public IEnumerable<Entity> RetrievePrivileges(IOrganizationService service)
        {
            var qe = new QueryExpression()
            {
                EntityName = EntityLogicalName,
                ColumnSet = new ColumnSet(true),
                PageInfo = new PagingInfo()
                {
                    Count = 5000,
                    PageNumber = 1,
                }
            };
            var ec = service.RetrieveMultiple(qe);

            var entities = new List<Entity>(ec.Entities);

            while (ec.MoreRecords)
            {
                qe.PageInfo.PageNumber += 1;
                qe.PageInfo.PagingCookie = ec.PagingCookie;
                ec = service.RetrieveMultiple(qe);

                entities.AddRange(ec.Entities);
            }

            return entities;
        }

        public IEnumerable<Entity> RetrievePrivileges(IOrganizationService service, IEnumerable<RolePrivilege> privileges)
        {
            var qe = new QueryExpression()
            {
                EntityName = EntityLogicalName,
                ColumnSet = new ColumnSet(true),
                PageInfo = new PagingInfo()
                {
                    Count = 5000,
                    PageNumber = 1,
                },
                Criteria =  new FilterExpression()
                {
                    Conditions =
                    {
                        new ConditionExpression(PrimaryKey, ConditionOperator.In, privileges.Select(x => x.PrivilegeId).ToArray())
                    }
                }
            };


            var ec = service.RetrieveMultiple(qe);

            var entities = new List<Entity>(ec.Entities);

            while (ec.MoreRecords)
            {
                qe.PageInfo.PageNumber += 1;
                qe.PageInfo.PagingCookie = ec.PagingCookie;
                ec = service.RetrieveMultiple(qe);

                entities.AddRange(ec.Entities);
            }

            return entities;
        }
    }
}
