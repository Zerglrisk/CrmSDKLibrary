using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrmSdkLibrary.Dataverse
{
	public class Copy
	{
		private Copy()
		{ }

		//Clone Entity http://mileyja.blogspot.kr/2011/05/clone-or-copy-entity-form-using-net-or.html
		//https://debajmecrm.com/2015/01/27/how-to-using-xrm-utility-openentityform-to-clone-all-fields-of-one-record-to-another-in-dynamics-crm/
		//https%3A%2F%2Fdebajmecrm.com%2F2015%2F10%2F04%2Fclone-an-entity-record-programmatically-in-microsoft-dynamics-crm%2F&usg=AFQjCNHn9AjC3tFpRZvOPhZY9Qv3yJ9dnA
		//https://msdn.microsoft.com/en-us/library/dn817895.aspx
		//https://msdn.microsoft.com/en-us/library/microsoft.crm.sdk.messages.cloneproductrequest.aspx

		/// <summary>
		///
		/// </summary>
		/// <param name="logicalName"></param>
		/// <param name="parentRecordId"></param>
		/// <param name="attribute"></param>
		/// <see cref="http://www.inogic.com/blog/2014/08/clone-records-in-dynamics-crm/"/>
		/// <returns>Created Record Id</returns>
		public static Guid CloneRecord(in IOrganizationService service, string logicalName, Guid parentRecordId, AttributeCollection attribute = null)
		{
			/* === ex ===
               var qe = new QueryExpression("account"){ColumnSet = new ColumnSet(true)};
               var re = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe) ;
               AttributeCollection attribute = new AttributeCollection();
               attribute.Add("name", "child Account Test");
               Guid childAccountID = CrmSdkLibrary.Copy.CloneRecord(Account.EntityLogicalName, re.Entities.First().Id , attribute);
             */

			//Declare Variables
			try
			{
				//retrieve the parent record
				var parentRecord = service.Retrieve(logicalName, parentRecordId, new ColumnSet(true));

				//Clone the Account Record using Clone function;
				//Clone function takes a bool parameter which relates the Related Entities of the parent
				//record to the cloned records, if set to true.
				//The bool parameter passed to Clone method is set to true by default.
				var childRecord = parentRecord;

				//Remove all the attributes of type primaryId as all the cloned records will have their own primaryid
				childRecord.Attributes.Remove(childRecord.LogicalName + "id");
				childRecord.Id = Guid.Empty;

				//^\w+\s?id{1}$  은 띄어쓰기 포함
				var list = (from val in childRecord.Attributes.Where(x =>
					Regex.Match(x.Key, @"^\w+id{1}$").Success)
							where val.Value.GetType() != typeof(EntityReference)
							select val.Key).ToList();

				foreach (var val in list)
				{
					childRecord.Attributes.Remove(val);
				}

				if (attribute != null)
				{
					foreach (var val in attribute)
					{
						childRecord[val.Key] = val.Value;
					}
				}

				//create the cloned record and return child account ID
				return service.Create(childRecord);
			}
			catch (SaveChangesException)
			{
				throw;
			}
		}

		/// <summary>
		/// Clone each record as specified attributes.
		/// </summary>
		/// <param name="logicalName"></param>
		/// <param name="parentRecordIds"></param>
		/// <param name="attribute"></param>
		/// <returns>Created Record Ids</returns>
		public static List<Guid> CloneRecords(in IOrganizationService service, string logicalName, Guid[] parentRecordIds, AttributeCollection attribute = null)
		{
			/*  === ex ===
               var qe = new QueryExpression("account"){ColumnSet = new ColumnSet(true)};
               var re = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe) ;
               AttributeCollection attribute = new AttributeCollection();
               attribute.Add("name", "child Account Test");
               var list = re.Entities.Select(variable => variable.Id).ToList();
               var childAccountIds = CrmSdkLibrary.Copy.CloneRecords(Account.EntityLogicalName,list.ToArray(), attribute);
             */
			var clonedRecordIds = new List<Guid>();
			var qe = new QueryExpression(logicalName.ToLower())
			{
				ColumnSet = new ColumnSet(true),
				Criteria = new FilterExpression()
				{
					//Primary Key Cannot Use ContainValues
					//Conditions = { new ConditionExpression($"{logicalName.ToLower()}id", ConditionOperator.ContainValues, parentRecordIds)}
				}
			};
			var filter = new FilterExpression(LogicalOperator.Or);
			foreach (var recordId in parentRecordIds)
			{
				filter.AddCondition($"{logicalName.ToLower()}id", ConditionOperator.Equal, recordId);
			}
			qe.Criteria.Filters.Add(filter);
			var retrieve = service.RetrieveMultiple(qe);

			foreach (var childRecord in retrieve.Entities)
			{
				childRecord.Attributes.Remove(childRecord.LogicalName + "id");
				childRecord.Id = Guid.Empty;

				//^\w+\s?id{1}$  은 띄어쓰기 포함
				var list = (from val in childRecord.Attributes.Where(x =>
						Regex.Match(x.Key, @"^\w+id{1}$").Success)
							where val.Value.GetType() != typeof(EntityReference)
							select val.Key).ToList();

				foreach (var val in list)
				{
					childRecord.Attributes.Remove(val);
				}

				if (attribute != null)
				{
					foreach (var val in attribute)
					{
						childRecord[val.Key] = val.Value;
					}
				}

				//Don't Use Bulk For get Ids
				clonedRecordIds.Add(service.Create(childRecord));
			}
			return clonedRecordIds;
		}
	}
}