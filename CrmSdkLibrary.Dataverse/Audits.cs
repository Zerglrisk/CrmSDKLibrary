using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmSdkLibrary.Dataverse
{
	public class Audits
	{
		public enum ActionType : int
		{
			Unknown = 0,
			Create = 1,
			Update = 2,
			Delete = 3,
			Activate = 4,
			Deactivate = 5,
			Cascade = 11,
			Merge = 12,
			Assign = 13,
			Share = 14,
			Retrieve = 15,
			Close = 16,
			Cancel = 17,
			Complete = 18,
			Resolve = 20,
			Reopen = 21,
			Fulfill = 22,
			Paid = 23,
			Qualify = 24,
			Disqualify = 25,
			Submit = 26,
			Reject = 27,
			Approve = 28,
			Invoice = 29,
			Hold = 30,
			AddMember = 31,
			RemoveMember = 32,
			AssociateEntities = 33,
			DisassociateEntities = 34,
			AddMembers = 35,
			RemoveMembers = 36,
			AddItem = 37,
			RemoveItem = 38,
			AddSubstitute = 39,
			RemoveSubstitute = 40,
			SetState = 41,
			Renew = 42,
			Revise = 43,
			Win = 44,
			Lose = 45,
			InternalProcessing = 46,
			Reschedule = 47,
			ModifyShare = 48,
			Unshare = 49,
			Book = 50,
			GenerateQuoteFromOpportunity = 51,
			AddToQueue = 52,
			AssignRoleToTeam = 53,
			RemoveRoleFromTeam = 54,
			AssignRoleToUser = 55,
			RemoveRoleFromUser = 56,
			AddPrivilegestoRole = 57,
			RemovePrivilegesFromRole = 58,
			ReplacePrivilegesInRole = 59,
			ImportMappings = 60,
			Clone = 61,
			SendDirectEmail = 62,
			Enabledfororganization = 63,
			UserAccessviaWeb = 64,
			UserAccessviaWebServices = 65,
			DeleteEntity = 100,
			DeleteAttribute = 101,
			AuditChangeatEntityLevel = 102,
			AuditChangeatAttributeLevel = 103,
			AuditChangeatOrgLevel = 104,
			EntityAuditStarted = 105,
			AttributeAuditStarted = 106,
			AuditEnabled = 107,
			EntityAuditStopped = 108,
			AttributeAuditStopped = 109,
			AuditDisabled = 110,
			AuditLogDeletion = 111,
			UserAccessAuditStarted = 112,
			UserAccessAuditStopped = 113,
			Upsert = 6,
			Archive = 115,
		}

		public static void EnableEntityAuditing(in IOrganizationService service, string entityLogicalName, bool isEnable)
		{
			var entityMetadata = (service.Execute(new RetrieveEntityRequest
			{
				LogicalName = entityLogicalName,
				EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes
			}) as RetrieveEntityResponse).EntityMetadata;

			entityMetadata.IsAuditEnabled = new BooleanManagedProperty(isEnable);

			service.Execute(new UpdateEntityRequest
			{
				Entity = entityMetadata,
			});
		}

		public static void EnableOrganizationAuditing(in IOrganizationService service, bool isEnable)
		{
			var orgId = Connection.Service.ConnectedOrgId;
			var org = service.Retrieve("organization", orgId, new ColumnSet("organizationid", "isauditenabled"));

			org.Attributes["isauditenabled"] = isEnable;
			service.Update(org);
		}

		public static bool? GetIsAuditEnabled(in IOrganizationService service)
		{
			//Connection.Service.ConnectedOrgId
			//Connection.Service.OrganizationDetail.OrganizationId
			var orgId = Connection.Service.ConnectedOrgId;
			var org = service.Retrieve("organization", orgId, new ColumnSet("organizationid", "isauditenabled"));

			if (org != null && org.Contains("isauditenabled"))
			{
				return org.GetAttributeValue<bool>("isauditenabled");
			}
			return null;
		}

		/// <summary>
		/// Restore a deleted record using the auditId.
		/// </summary>
		/// <see href="https://cloudblogs.microsoft.com/dynamics365/no-audience/2011/05/23/recover-your-deleted-crm-data-and-recreate-them-using-crm-api/"/>
		/// <param name="service">The IOrganizationService instance to use.</param>
		/// <param name="auditId">The ID of the audit record to use.</param>
		/// <returns>The ID of the restored record, or null if the record could not be restored.</returns>
		public static Guid? RestoreDeletedRecord(in IOrganizationService service, Guid auditId, Guid? entityId = null)
		{
			var detail = RetrieveAuditDetail(service, auditId);
			if (detail.AuditRecord.GetAttributeValue<OptionSetValue>("action").Value == (int)ActionType.Delete && detail is AttributeAuditDetail)
			{
				var attrDetail = detail as AttributeAuditDetail;
				if(entityId != null)
				{
					attrDetail.OldValue.Id = entityId.Value;

                }
				return service.Create(attrDetail.OldValue);
			}

			// old 1
			//var auditEntity = udits.RetrieveAuditDetail(service, auditId).AuditRecord;
			//var target = auditEntity.GetAttributeValue<EntityReference>("objectid");
			//var auditDetails = Audits.RetrieveRecordChangeHistory(service, target);

			//var targetDetail = auditDetails.AuditDetails.FirstOrDefault(x => x.AuditRecord.GetAttributeValue<OptionSetValue>("action").Value == (int)ActionType.Delete);
			//if (targetDetail != null && targetDetail is AttributeAuditDetail)
			//{
			//    var targetAttributeDetail = targetDetail as AttributeAuditDetail;
			//    var targetEntity = targetAttributeDetail.OldValue;
			//    return service.Create(targetEntity);
			//}

			// old 2
			//for (var i = 0; i < auditDetails.Count; i++)
			//{
			//    if (auditDetails[i] is AttributeAuditDetail detail)
			//    {
			//        // This is a safety check to verify
			//        // if the audit record is for the delete operation
			//        if ((detail.NewValue == null || !detail.NewValue.Attributes.Any()) && (detail.OldValue != null && detail.OldValue.Attributes.Any()))
			//        {
			//            Entity entity = detail.OldValue;
			//            return service.Create(entity);
			//            // The audit records are recorded in the order
			//            // from latest to older. So, it's ok to break since you've recreated
			//            // from the latest snapshot of the entity, just before deletion
			//            // break;
			//        }
			//    }
			//}
			return null;
		}

		public static List<FieldHistory> RetrieveAttributeChangeHistory(in IOrganizationService service, string entityLogicalName, Guid recordId, string fieldName)
		{
			var attributeChangeHistoryRequest = new RetrieveAttributeChangeHistoryRequest
			{
				Target = new EntityReference(entityLogicalName, recordId),
				AttributeLogicalName = fieldName
			};

			var attributeChangeHistoryResponse = service.Execute(attributeChangeHistoryRequest) as RetrieveAttributeChangeHistoryResponse;
			var details = attributeChangeHistoryResponse.AuditDetailCollection;

			var fieldHistory = new List<FieldHistory>();

			foreach (var detail in details.AuditDetails)
			{
				if (detail is AttributeAuditDetail attributeDetail)
				{
					// retrieve old & new value of each action of each audit change from AttributeAuditDetail
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

		public static AuditDetail RetrieveAuditDetail(in IOrganizationService service, Guid auditId)
		{
			var retrieveAuditDetailsRequest = new RetrieveAuditDetailsRequest()
			{
				AuditId = auditId
			};

			var retrieveAuditDetailsResponse = service.Execute(retrieveAuditDetailsRequest) as RetrieveAuditDetailsResponse;
			var detail = retrieveAuditDetailsResponse.AuditDetail;

			return detail;
		}

		/// <summary>
		/// Retrieve deleted records for a given entity.
		/// </summary>
		/// /// <see href="https://promx.net/en/2016/04/how-to-restore-deleted-records-from-your-crm-system/"/>
		/// <param name="service">The IOrganizationService instance to use.</param>
		/// <param name="entityLogicalName">The logical name of the entity to retrieve deleted records for.</param>
		/// <param name="recordId">The ID of the record to retrieve deleted records for.</param>
		/// <param name="onOrAfter">The earliest date to retrieve deleted records for.</param>
		/// <param name="onOrBefore">The latest date to retrieve deleted records for.</param>
		/// <returns>An EntityCollection containing the deleted records, or null if no records were found.</returns>
		public static EntityCollection RetrieveDeletedRecords(in IOrganizationService service, string entityLogicalName = "", Guid? recordId = null, DateTime? onOrAfter = null, DateTime? onOrBefore = null)
		{
			var qe = new QueryExpression("audit")
			{
				ColumnSet = new ColumnSet("createdon", "userid"),
				Criteria = new FilterExpression()
				{
					Conditions =
					{
						new ConditionExpression("operation", ConditionOperator.Equal, (int)ActionType.Delete), // Delete
                    }
				}
			};
			if (!string.IsNullOrWhiteSpace(entityLogicalName))
			{
				qe.Criteria.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityLogicalName));
			}
			if (recordId != null)
			{
				qe.Criteria.Conditions.Add(new ConditionExpression("objectid", ConditionOperator.Equal, recordId.Value));
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
				var rtn = new EntityCollection();
				foreach (var entity in ec.Entities)
				{
					var auditDetail = RetrieveAuditDetail(service, entity.Id);
					if (auditDetail != null && auditDetail is AttributeAuditDetail)
					{
						rtn.Entities.Add((auditDetail as AttributeAuditDetail).OldValue);
					}
				}
				return rtn;
			}
			return null;
		}

		public static AuditDetailCollection RetrieveRecordChangeHistory(in IOrganizationService service, string entityLogicalName, Guid recordId)
		{
			return RetrieveRecordChangeHistory(service, new EntityReference(entityLogicalName, recordId));
		}

		public static AuditDetailCollection RetrieveRecordChangeHistory(in IOrganizationService service, EntityReference entityReference)
		{
			var retrieveRecordChangeHistoryRequest = new RetrieveRecordChangeHistoryRequest()
			{
				Target = entityReference,
			};

			var retrieveRecordChangeHistoryResponse = service.Execute(retrieveRecordChangeHistoryRequest) as RetrieveRecordChangeHistoryResponse;
			var details = retrieveRecordChangeHistoryResponse.AuditDetailCollection;

			return details;
		}

		public class FieldHistory
		{
			public string ChangedBy { get; set; }
			public DateTime ChangedOn { get; set; }
			public string NewValue { get; set; }
			public string Oldvalue { get; set; }
		}
	}
}