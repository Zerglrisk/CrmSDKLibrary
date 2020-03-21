using CrmSdkLibrary;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using CrmSdkLibrary.Definition;
using AuthenticationContext = Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext;
using AuthenticationType = CrmSdkLibrary.Definition.Enum.AuthenticationType;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmSdkLibrary.Connection conn = new CrmSdkLibrary.Connection();
            //Login Case 1
            //Console.WriteLine(conn.ConnectService("test201018", "tester200317@tester200317.onmicrosoft.com", "tester201018@", Location.APAC));
            //Login Case 2
            //Console.WriteLine(conn.ConnectService(
            //    new Uri("https://test201018.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"),
            //    "test201018@test201018.onmicrosoft.com", "tester201018@"));
            //Login Case 3
            Console.WriteLine(conn.ConnectService("https://tester200317.crm5.dynamics.com", "tester200317@tester200317.onmicrosoft.com", "tester201018@", AuthenticationType.Office365));
            var cc = Messages.RetrieveAllEntities(Connection.OrgService);
            var count = 0;

            //foreach (var entityMetadata in cc)
            //{
            //    if (entityMetadata.LogicalName.Contains("new_"))
            //    {
            //        Console.WriteLine(entityMetadata.LogicalName + ", " + count);
            //    }

            //    count++;
            //}
            var aa = Messages.RetrieveEntity(Connection.OrgService, "contact", EntityFilters.All);
            var b = CrmSdkLibrary.Entities.SystemView.RetrieveAttributes(Connection.OrgService, new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var c = CrmSdkLibrary.Entities.SystemView.RetrieveView(Connection.OrgService, new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var d = Messages.FetchXmlToQueryExpression(Connection.OrgService, c["fetchxml"].ToString());
            var converted = SqlConverter.Convert(d, c["layoutxml"].ToString());
            var dd = CrmSdkLibrary.Entities.SystemView.RetrieveAttributeMetadata(Connection.OrgService,
                new Guid("{00000000-0000-0000-00aa-000010001004}"),true);

            //var xml = new XmlDocument();
            //xml.LoadXml(c["layoutxml"].ToString());
            //var xnList = xml.GetElementsByTagName("cell");
            //foreach (XmlNode xn in xnList)
            //{
            //    if (xn.Attributes != null) Console.WriteLine(xn.Attributes["name"].Value);
            //}

            Program app = new Program();
            Api.SetApplicationId("26de6e84-f9e2-4ca6-a174-fbb9d00b175c");
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));

            Console.WriteLine(converted.GenerateSql());
            Console.WriteLine("(End)");

        }


        public async Task RunAsync()
        {
            //HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("tester200317@tester200317.onmicrosoft.com", "***REMOVED***",
            //    "test191020.onmicrosoft.com", "https://tester200317.crm5.dynamics.com/");
            HttpClient client = CrmSdkLibrary.Api.GetWebApiHttpClient(new UserPasswordCredential("tester200317@tester200317.onmicrosoft.com", "tester201018@"),
                   "https://tester200317.crm5.dynamics.com", "https://login.microsoftonline.com/2e83d097-5831-48ad-a9df-e105ef01997d");
            var aa = await CrmSdkLibrary.Api.User(client);
            var cli = Api.GetWebApiHttpClient("_Xqg[Fw7-J3j9D:CacUojLjm2Gc8[RU=",
                "https://tester200317.crm5.dynamics.com",
                "https://login.microsoftonline.com/2e83d097-5831-48ad-a9df-e105ef01997d");
            //Load All EntiySetName To Memory
            var a = Api.EntitySetPaths;
            Console.WriteLine(aa);

            var aaaaaa = await Api.GetToken("https://tester200317.api.crm5.dynamics.com/api/data/");
            var aaaaab = await Api.GetCurrentOrganization(client, EndpointAccessType.Default);
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
