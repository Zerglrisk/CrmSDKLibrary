using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
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

            if (org != null && org.Contains("isauditenabled"))
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

        public static List<FieldHistory> GetFieldHistory(IOrganizationService service, string entityLogicalName, Guid recordId, string fieldName)
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

        public static AuditDetailCollection GetRecordHistory(IOrganizationService service, string entityLogicalName, Guid recordId)
        {
            var retrieveRecordChangeHistoryRequest = new RetrieveRecordChangeHistoryRequest()
            {
                Target = new EntityReference(entityLogicalName, recordId)
            };

            var retrieveRecordChangeHistoryResponse = (RetrieveRecordChangeHistoryResponse)service.Execute(retrieveRecordChangeHistoryRequest);
            var details = retrieveRecordChangeHistoryResponse.AuditDetailCollection;

            return details;
        }

        public static AuditDetail GetAuditDetail(IOrganizationService service, Guid auditId)
        {
            var retrieveAuditDetailsRequest = new RetrieveAuditDetailsRequest()
            {
                AuditId = auditId
            };

            var retrieveAuditDetailsResponse = (RetrieveAuditDetailsResponse)service.Execute(retrieveAuditDetailsRequest);
            var detail = retrieveAuditDetailsResponse.AuditDetail;

            return detail;
        }

        /// <summary>
        /// Restore Deleted Record using audit guid
        /// </summary>
        /// <see href="https://cloudblogs.microsoft.com/dynamics365/no-audience/2011/05/23/recover-your-deleted-crm-data-and-recreate-them-using-crm-api/"/>
        /// <param name="auditId"></param>
        /// <param name="service"></param>
        public static Guid? RestoreDeletedRecord(IOrganizationService service, Guid auditId)
        {
            var auditEntity = Audits.GetAuditDetail(service, auditId).AuditRecord;
            var details = Audits.GetRecordHistory(service, auditEntity.LogicalName, auditEntity.Id);

            for (var i = 0; i < details.Count; i++)
            {
                if (typeof(AttributeAuditDetail).Name == details[i].GetType().Name)
                {
                    AttributeAuditDetail detail = details[i] as AttributeAuditDetail;

                    // This is a safety check to verify
                    // if the audit record is for the delete operation
                    if (detail.NewValue == null && detail.OldValue != null)
                    {
                        Entity entity = detail.OldValue;
                        return service.Create(entity);
                        // The audit records are recorded in the order 
                        // from latest to older. So, it's ok to break since you've recreated 
                        // from the latest snapshot of the entity, just before deletion
                        // break;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieve audit using qe first and Retrieve Audit Detail
        /// </summary>
        /// <see href="https://promx.net/en/2016/04/how-to-restore-deleted-records-from-your-crm-system/"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName">objecttypecode condition</param>
        /// <param name="onOrAfter">createdon condition</param>
        /// <param name="onOrBefore">createdon condition</param>
        public static EntityCollection RetrieveDeletedRecords(IOrganizationService service, string entityLogicalName = "", DateTime? onOrAfter = null, DateTime? onOrBefore = null)
        {
            EntityCollection rtn = null;
            var qe = new QueryExpression("audit")
            {
                ColumnSet = new ColumnSet("createdon", "userid"),
                Criteria = new FilterExpression()
                {
                    Conditions =
                    {
                        new ConditionExpression("operation", ConditionOperator.Equal, 3), // Delete
                    }
                }
            };
            if (!string.IsNullOrWhiteSpace(entityLogicalName))
            {
                qe.Criteria.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityLogicalName));
            }
            if (onOrAfter != null)
            {
                qe.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.OnOrAfter, onOrAfter.Value.ToString("o"))); //yyyy-MM-ddTHH:mm:ssK
            }
            if (onOrBefore != null)
            {
                qe.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.OnOrBefore, onOrBefore.Value.ToString("o"))); //yyyy-MM-ddTHH:mm:ssK
            }

            var ec = service.RetrieveMultiple(qe);
            if (ec.Entities.Any())
            {
                rtn = new EntityCollection();
                foreach (var entity in ec.Entities)
                {
                    var retrieveAuditDetailsRequest = new RetrieveAuditDetailsRequest()
                    {
                        AuditId = entity.Id,
                    };

                    var retrieveAuditDetailsResponse = (RetrieveAuditDetailsResponse)service.Execute(retrieveAuditDetailsRequest);
                    rtn.Entities.Add(((AttributeAuditDetail)retrieveAuditDetailsResponse.AuditDetail).OldValue);
                }
            }
            return rtn;
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
