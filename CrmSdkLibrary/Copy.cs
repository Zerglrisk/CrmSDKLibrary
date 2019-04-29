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
        /// <param name="LogicalName"></param>
        /// <param name="parentEntityId"></param>
        /// <param name="attribute"></param>
        /// <see cref="http://www.inogic.com/blog/2014/08/clone-records-in-dynamics-crm/"/>
        /// <returns></returns>
        public static Guid CloneRecord(string LogicalName, Guid parentRecordId, AttributeCollection attribute)
        {
            //Declare Variables
            Entity parentRecord;
            Entity childaccount;
            try
            {
                //retrieve the parent record
                parentRecord = CrmSdkLibrary.Connection.OrgService.Retrieve(LogicalName, parentRecordId, new ColumnSet(true));

                //Clone the Account Record using Clone function;
                //Clone function takes a bool parameter which relates the Related Entities of the parent
                //record to the cloned records, if set to true.
                //The bool parameter passed to Clone method is set to true by default.
                childaccount = parentRecord;//.Clone(true);
                //Remove all the attributes of type primaryid as all the cloned records will have their own primaryid
                childaccount.Attributes.Remove(childaccount.LogicalName + "id");
                childaccount.Attributes.Remove("address2_addressid");
                childaccount.Attributes.Remove("address1_addressid");
                childaccount.Id = Guid.Empty;
                //Remove the telephone1 attribute from the cloned record to differentiate between the parent and cloned record
                //childaccount.Attributes.Remove("telephone1");
                if (attribute != null)
                    childaccount.Attributes = attribute;
                //create the cloned record and return child account ID
                return CrmSdkLibrary.Connection.OrgService.Create(childaccount);


            }
            catch (SaveChangesException ex)
            {
                throw ex;
            }
        }
        public static Guid[] CloneRecords(string LogicalName, Guid[] parentRecordIds, AttributeCollection attribute)
        {
            var qe = new QueryExpression(LogicalName.ToLower());
            var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);

            foreach (var entity in retrieve.Entities)
            {
                if (parentRecordIds != null)
                {
                    for (int i = 0; i < parentRecordIds.Length; i++)
                    {
                        if (parentRecordIds[i] == (Guid)entity.Attributes[entity.LogicalName + "id"]) //복사할 레코드가 있으면
                        {
                            Entity childaccount = entity;//.Clone(true);
                            childaccount.Attributes.Remove(childaccount.LogicalName + "id");
                            if (attribute != null)
                                childaccount.Attributes = attribute;
                            CrmSdkLibrary.Connection.OrgService.Create(childaccount);
                        }
                    }
                }
                else
                {
                    Entity childaccount = entity;//.Clone(true);
                    childaccount.Attributes.Remove(childaccount.LogicalName + "id");
                    if (attribute != null)
                        childaccount.Attributes = attribute;
                    CrmSdkLibrary.Connection.OrgService.Create(childaccount);
                }
            }
            return parentRecordIds;
        }
    }
}
