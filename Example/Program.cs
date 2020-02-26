using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using CrmSdkLibrary;
using CrmSdkLibrary.Definition.Enum;
using CrmSdkLibrary.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using AttributeCollection = Microsoft.Xrm.Sdk.AttributeCollection;
using AuthenticationType = CrmSdkLibrary.Definition.Enum.AuthenticationType;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmSdkLibrary.Connection conn = new CrmSdkLibrary.Connection();
            //Login Case 1
            //Console.WriteLine(conn.ConnectService("test201018", "test201018@test201018.onmicrosoft.com", "tester201018@", Location.APAC));
            //Login Case 2
            //Console.WriteLine(conn.ConnectService(
            //    new Uri("https://test201018.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"),
            //    "test201018@test201018.onmicrosoft.com", "tester201018@"));
            //Login Case 3
            Console.WriteLine(conn.ConnectService("***REMOVED***", "***REMOVED***", "***REMOVED***",AuthenticationType.Office365));

            var cc = Messages.RetrieveAllEntities(Connection.OrgService);
            var count = 0;
            foreach (var entityMetadata in cc)
            {
                if (entityMetadata.LogicalName.Contains("new_"))
                {
                    Console.WriteLine(entityMetadata.LogicalName + ", " + count);
                }

                count++;
            }
            var a = Messages.RetrieveViews(Connection.OrgService, "contact");
            var b = Messages.RetrieveViewAttributes(Connection.OrgService,new Guid("{2f0d0ede-d356-4b1e-83bd-e978f10e3eeb}"));
            var c = Messages.RetrieveView(Connection.OrgService, new Guid("2f0d0ede-d356-4b1e-83bd-e978f10e3eeb"));
            //var d = Messages.RetrieveViewAttributesAsDictionary(Connection.OrgService,
            //    new Guid("{2f0d0ede-d356-4b1e-83bd-e978f10e3eeb}"));
           
            Program app = new Program();
            Api.SetApplicationId("68e95894-a339-40f1-a053-727f08c3a1ee");
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));

            Console.WriteLine("(End)");

        }

        public async Task RunAsync()
        {
            //HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("test191020@test191020.onmicrosoft.com", "***REMOVED***",
            //    "test191020.onmicrosoft.com", "https://test201018.crm5.dynamics.com/");
            HttpClient client = CrmSdkLibrary.Api.GetWebApiHttpClient(new UserPasswordCredential("test201018@test201018.onmicrosoft.com", "tester201018@"),
                   "https://test201018.crm5.dynamics.com", "https://login.microsoftonline.com/b402a2b7-7be7-4436-b53c-a47d0f64fe9d");
            var aa = await CrmSdkLibrary.Api.User(client);

            //Load All EntiySetName To Memory
            var a = Api.EntitySetPaths;

            Console.WriteLine(aa);

            
            var qe = new QueryExpression("opportunity") { ColumnSet = new ColumnSet(true) };
            var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);
            
            //need test
            var ab = await CrmSdkLibrary.Api.RetrieveDuplicates(client, retrieve.Entities.First(), new PagingInfo(){PageNumber = 1, Count = 10});

            var ac = await Api.GetObjectTypeCode(client, "account");
            Console.WriteLine($"Account ObjectTypeCode : {ac}");

            //var cc = Messages.GetCurrentOrganization(Connection.OrgService);
            //Console.WriteLine($"{cc.UrlName} +  {cc.EnvironmentId} + {cc.FriendlyName} + {cc.OrganizationVersion} + {cc.UniqueName} + {cc.Endpoints.First().Key}:{cc.Endpoints.First().Value}");
            var cc = await Api.GetCurrentOrganization(client, EndpointAccessType.Default);
            Console.WriteLine(cc);
            //var bb = await Api.GetDataAsJson(client);
            //Console.WriteLine(bb);
        }

    }
}
