using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CrmSdkLibrary;
using CrmSdkLibrary.Entities;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using AuthenticationType = CrmSdkLibrary.Definition.Enum.AuthenticationType;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmSdkLibrary.Connection conn = new CrmSdkLibrary.Connection();
            //Console.WriteLine(conn.ConnectService("mscrm0827", "admin@mscrm0827.onmicrosoft.com", "mscrm@0827"));
            //Console.WriteLine(conn.ConnectService(
            //    new Uri("https://test201018.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"),
            //    "test201018@test201018.onmicrosoft.com", "tester201018@"));
            Console.WriteLine(conn.ConnectService("https://test201018.crm5.dynamics.com", "test201018@test201018.onmicrosoft.com", "tester201018@",AuthenticationType.Office365));

            //AttributeCollection attribute = new AttributeCollection();
            //attribute.Add("name", "child Account Test");
            //Guid childAccountID = CrmSdkLibrary.Copy.CloneRecord(Account.EntityLogicalName, , attribute);

            //CrmSdkLibrary.Entities.Account acc = new CrmSdkLibrary.Entities.Account();
            //ColumnSet columnset = new ColumnSet(new String[] { "name" });

            //var retrieved = CrmSdkLibrary.Connection.OrgService.Retrieve("account",childAccountID, columnset);
            //CrmSdkLibrary.Copy.CloneRecord("account", new Guid("a8a19cdd-88df-e311-b8e5-6c3be5a8b200"), null);
            //var qe = new QueryExpression("opportunity") { ColumnSet = new ColumnSet(true) };
            //var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);

            //CrmSdkLibrary.Common.GetOptionSetList(CrmSdkLibrary.Connection.OrgService, "lead", "leadsourcecode");

            //foreach (var a in retrieve.Entities)
            //{
            //    Console.WriteLine(a.Id + "," + (a.Contains("name") ? a["name"].ToString() : string.Empty));
            //}

            Program app = new Program();
            Api.SetApplicationId("68e95894-a339-40f1-a053-727f08c3a1ee");
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));

            Console.WriteLine("aav)");
        }

        public async Task RunAsync()
        {
            //HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("test191020@test191020.onmicrosoft.com", "***REMOVED***",
            //    "test191020.onmicrosoft.com", "https://test201018.crm5.dynamics.com/");
            HttpClient client = CrmSdkLibrary.Api.GetWebApiHttpClient(new UserPasswordCredential("test201018@test201018.onmicrosoft.com", "tester201018@"),
                   "https://test201018.crm5.dynamics.com", "https://login.microsoftonline.com/b402a2b7-7be7-4436-b53c-a47d0f64fe9d");
            var aa = await CrmSdkLibrary.Api.User(client);
            Console.WriteLine(aa);

            
            var qe = new QueryExpression("opportunity") { ColumnSet = new ColumnSet(true) };
            var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);
            
            //need test
            var ab = await CrmSdkLibrary.Api.RetrieveDuplicates(client,new EntityReference("opportunity", retrieve.Entities.First().Id), "opportunity", "");

            var ac = await Api.GetObjectTypeCode(client, "account");
            Console.WriteLine($"Account ObjectTypeCode : {ac}");

            //Console.WriteLine();
            //var bb = await Api.GetDataAsJson(client);
            //Console.WriteLine(bb);
        }

        private static Guid CloneRecord(string logicalName, Guid parentRecordId, List<string> attribute)
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
                var childAccount = parentRecord;
                //Remove all the attributes of type primaryid as all the cloned records will have their own primaryid
                childAccount.Attributes.Remove(childAccount.LogicalName + "id");
                childAccount.Attributes.Remove("address2_addressid");
                childAccount.Attributes.Remove("address1_addressid");
                childAccount.Id = Guid.Empty;
                //Remove the telephone1 attribute from the cloned record to differentiate between the parent and cloned record
                //childaccount.Attributes.Remove("telephone1");
                if (attribute != null)
                {
                    foreach (var a in attribute)
                    {
                        childAccount.Attributes.Remove(a);
                    }
                }
                //childAccount.Attributes = attribute;
                //create the cloned record and return child account ID
                try
                {
                    return CrmSdkLibrary.Connection.OrgService.Create(childAccount);
                }
                catch
                {
                    if (attribute == null)
                    {
                        attribute = new List<string>();
                    }
                    attribute.Add(childAccount.Attributes.First().Key);
                    Console.WriteLine("Delete Key  : " + childAccount.Attributes.First().Key);
                    return CloneRecord(logicalName, parentRecordId, attribute);
                }


            }
            catch (SaveChangesException ex)
            {
                throw ex;
            }
        }
    }
}
