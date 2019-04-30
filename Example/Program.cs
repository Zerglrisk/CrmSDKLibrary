using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmSdkLibrary.Connection conn = new CrmSdkLibrary.Connection();
            //Console.WriteLine(conn.ConnectService("mscrm0827", "admin@mscrm0827.onmicrosoft.com", "mscrm@0827"));
            Console.WriteLine(conn.ConnectService(
                new Uri("https://test90424.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"),
                "test@test90424.onmicrosoft.com", "true@0424"));

            //AttributeCollection attribute = new AttributeCollection();
            //attribute.Add("name", "child Account Test");
            //Guid childAccountID = CrmSdkLibrary.Copy.CloneRecord(Account.EntityLogicalName, , attribute);

            //CrmSdkLibrary.Entities.Account acc = new CrmSdkLibrary.Entities.Account();
            //ColumnSet columnset = new ColumnSet(new String[] { "name" });

            //var retrieved = CrmSdkLibrary.Connection.OrgService.Retrieve("account",childAccountID, columnset);
            //CrmSdkLibrary.Copy.CloneRecord("account", new Guid("a8a19cdd-88df-e311-b8e5-6c3be5a8b200"), null);
            //var qe = new QueryExpression("account") { ColumnSet = new ColumnSet("name") } ;
            //var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);
            //    //CrmSdkLibrary.Common.GetOptionSetList(CrmSdkLibrary.Connection.OrgService, "lead", "leadsourcecode");

            //foreach (var a in retrieve.Entities)
            //{
            //    Console.WriteLine(a.Id + "," + (a.Contains("name") ? a["name"].ToString() : string.Empty));
            //}
            Program app = new Program();
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));


        }

        public async Task RunAsync()
        {
            HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("test@test90424.onmicrosoft.com", "true@0424",
                "test90424.onmicrosoft.com", "https://test90424.crm5.dynamics.com/");
           string aa = await CrmSdkLibrary.Api.User(client);
           Console.WriteLine(aa);
        }

        private static Guid CloneRecord(string LogicalName, Guid parentRecordId, List<string> attribute)
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
                {
                    foreach(var a in attribute)
                    {
                        childaccount.Attributes.Remove(a);
                    }
                }
                    //childaccount.Attributes = attribute;
                //create the cloned record and return child account ID
                try
                {
                    return CrmSdkLibrary.Connection.OrgService.Create(childaccount);
                }
                catch
                {
                    if(attribute == null)
                    {
                        attribute = new List<string>();
                    }
                    attribute.Add(childaccount.Attributes.First().Key);
                    Console.WriteLine("Delete Key  : " + childaccount.Attributes.First().Key);
                    return CloneRecord(LogicalName, parentRecordId, attribute);
                }


            }
            catch (SaveChangesException ex)
            {
                throw ex;
            }
        }
    }
}
