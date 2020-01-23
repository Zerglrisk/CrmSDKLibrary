using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    public class Copy
    {
        Copy() { }
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
        /// <returns></returns>
        public static Guid CloneRecord(string logicalName, Guid parentRecordId, AttributeCollection attribute)
        {
            //Declare Variables
            try
            {
                //retrieve the parent record
                var parentRecord = CrmSdkLibrary.Connection.OrgService.Retrieve(logicalName, parentRecordId, new ColumnSet(true));

                //Clone the Account Record using Clone function;
                //Clone function takes a bool parameter which relates the Related Entities of the parent
                //record to the cloned records, if set to true.
                //The bool parameter passed to Clone method is set to true by default.
                var childaccount = parentRecord;
                //Remove all the attributes of type primaryId as all the cloned records will have their own primaryid
                childaccount.Attributes.Remove(childaccount.LogicalName + "id");
                childaccount.Attributes.Remove("address2_addressid");
                childaccount.Attributes.Remove("address1_addressid");
                childaccount.Id = Guid.Empty;
                //Remove the telephone1 attribute from the cloned record to differentiate between the parent and cloned record
                //childAccount.Attributes.Remove("telephone1");
                if (attribute != null)
                    childaccount.Attributes = attribute;
                //create the cloned record and return child account ID
                return CrmSdkLibrary.Connection.OrgService.Create(childaccount);


            }
            catch (SaveChangesException)
            {
                throw;
            }
        }
        public static Guid[] CloneRecords(string logicalName, Guid[] parentRecordIds, AttributeCollection attribute)
        {
            var qe = new QueryExpression(logicalName.ToLower());
            var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);

            foreach (var entity in retrieve.Entities)
            {
                if (parentRecordIds != null)
                {
                    foreach (var t in parentRecordIds)
                    {
                        if (t != (Guid) entity.Attributes[entity.LogicalName + "id"]) continue;
                        var childAccount = entity;//.Clone(true);
                        childAccount.Attributes.Remove(childAccount.LogicalName + "id");
                        if (attribute != null)
                            childAccount.Attributes = attribute;
                        CrmSdkLibrary.Connection.OrgService.Create(childAccount);
                    }
                }
                else
                {
                    var childAccount = entity;//.Clone(true);
                    childAccount.Attributes.Remove(childAccount.LogicalName + "id");
                    if (attribute != null)
                        childAccount.Attributes = attribute;
                    CrmSdkLibrary.Connection.OrgService.Create(childAccount);
                }
            }
            return parentRecordIds;
        }
    }
}
