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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
            Console.WriteLine(conn.ConnectService("test201018", "test201018@test201018.onmicrosoft.com", "tester201018@", Location.APAC));
            //Console.WriteLine(conn.ConnectService(
            //    new Uri("https://test201018.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"),
            //    "test201018@test201018.onmicrosoft.com", "tester201018@"));
            Console.WriteLine(conn.ConnectService("https://test201018.crm5.dynamics.com", "test201018@test201018.onmicrosoft.com", "tester201018@",AuthenticationType.Office365));

            //CrmSdkLibrary.Entities.Account acc = new CrmSdkLibrary.Entities.Account();
            //ColumnSet columnset = new ColumnSet(new String[] { "name" });
            Messages.QualifyLead(Connection.OrgService,
                new EntityReference("lead", new Guid("A461CA69-7A34-4416-A6D4-224C9D91E945")), 3,
                QualifyLeadEntity.Account | QualifyLeadEntity.Contact | QualifyLeadEntity.Opportunity);

            //CrmSdkLibrary.Common.GetOptionSetList(CrmSdkLibrary.Connection.OrgService, "lead", "leadsourcecode");

            //foreach (var a in retrieve.Entities)
            //{
            //    Console.WriteLine(a.Id + "," + (a.Contains("name") ? a["name"].ToString() : string.Empty));
            //}
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
