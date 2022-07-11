using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    public class Audits
    {
        public static bool? GetIsAuditEnabled(IOrganizationService service)
        {
            //Connection.Service.ConnectedOrgId 
            //Connection.Service.OrganizationDetail.OrganizationId
            var orgId = Connection.Service.ConnectedOrgId;
            var org = service.Retrieve("organization", orgId, new Microsoft.Xrm.Sdk.Query.ColumnSet("organizationid", "isauditenabled"));

            if(org != null && org.Contains("isauditenabled"))
            {
                return org.GetAttributeValue<bool>("isauditenabled");
            }
            return null;
        }

        public static void EnableOrganizationAuditing(IOrganizationService service, bool isEnable)
        {
            var orgId = Connection.Service.ConnectedOrgId;
            var org = service.Retrieve("organization", orgId, new Microsoft.Xrm.Sdk.Query.ColumnSet("organizationid", "isauditenabled"));

            org.Attributes["isauditenabled"] = isEnable;
            service.Update(org);
        }

        public static void EnableEntityAuditing(IOrganizationService service, string entityLogicalName, bool isEnable)
        {
            var entityMetadata = ((RetrieveEntityResponse)service.Execute(new RetrieveEntityRequest
            {
                LogicalName = entityLogicalName,
                EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes
            })).EntityMetadata;

            entityMetadata.IsAuditEnabled = new BooleanManagedProperty(isEnable);
            
            service.Execute(new UpdateEntityRequest
            {
                Entity = entityMetadata,
            });
        }

        public static List<FieldHistory> GetFieldHistory(string entityLogicalName, Guid recordId, string fieldName, IOrganizationService service)
        {
            var attributeChangeHistoryRequest = new RetrieveAttributeChangeHistoryRequest
            {
                Target = new EntityReference(entityLogicalName, recordId),
                AttributeLogicalName = fieldName
            };

            var attributeChangeHistoryResponse = (RetrieveAttributeChangeHistoryResponse)service.Execute(attributeChangeHistoryRequest);
            var details = attributeChangeHistoryResponse.AuditDetailCollection;

            var fieldHistory = new List<FieldHistory>();

            foreach (var detail in details.AuditDetails)
            {
                var detailType = detail.GetType();
                if (detailType == typeof(AttributeAuditDetail))
                {
                    // retrieve old & new value of each action of each audit change from AttributeAuditDetail
                    var attributeDetail = (AttributeAuditDetail)detail;

                    var userName = attributeDetail.AuditRecord.GetAttributeValue<EntityReference>("userid").Name;
                    var changedOn = attributeDetail.AuditRecord.GetAttributeValue<DateTime>("createdon");
                    var newValue = attributeDetail.NewValue.FormattedValues[fieldName];
                    var oldValue = attributeDetail.OldValue?.FormattedValues[fieldName];

                    fieldHistory.Add(new FieldHistory
                    {
                        ChangedBy = userName,
                        ChangedOn = changedOn,
                        Oldvalue = oldValue,
                        NewValue = newValue
                    });
                }
            }
            return fieldHistory;
        }
        public class FieldHistory
        {
            public string ChangedBy { get; set; }
            public DateTime ChangedOn { get; set; }
            public string Oldvalue { get; set; }
            public string NewValue { get; set; }
        }
    }
}
