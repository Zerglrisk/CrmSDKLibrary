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
    public class SecurityRoles
    {
        private int? _entityTypeCode;
        public int? EntityTypeCode =>
            _entityTypeCode ?? (_entityTypeCode = Connection.Service != null
                ? Messages.GetEntityTypeCode(Connection.Service, EntityLogicalName)
                : _entityTypeCode);
        public const string EntityLogicalName = "role";
        public const string EntitySetPath = "roles";
        public const string DisplayName = "Security Role";
        public const string PrimaryKey = "roleid";
        public const string PrimaryKeyAttribute = "name";

        public IEnumerable<Entity> RetrieveSecurityRolesList(IOrganizationService service)
        {
            var qe = new QueryExpression()
            {
                EntityName = EntityLogicalName,
                //ColumnSet = new ColumnSet("roleid", "name", "businessunitid", "iscustomizable", "ismanaged", "createdby", "createdon", "modifiedby", "modifiedon")
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

        public IEnumerable<RolePrivilege> RetrievePrivilegesRole(IOrganizationService service, Guid roleId)
        {
            return CrmSdkLibrary.Messages.RetrieveRolePrivilegesRole(service, roleId);
        }

        public void AddPrivilegesRole(IOrganizationService service, Guid roleId, IEnumerable<RolePrivilege> privileges)
        {
            CrmSdkLibrary.Messages.AddPrivilegesRole(service, roleId, privileges);
        }

        public void ReplacePrivilegesRole(IOrganizationService service, Guid roleId, IEnumerable<RolePrivilege> privileges)
        {
            CrmSdkLibrary.Messages.ReplacePrivilegesRole(service, roleId, privileges);
        }
    }
}
