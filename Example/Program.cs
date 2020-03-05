using CrmSdkLibrary;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using CrmSdkLibrary.Definition;
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
            var b = CrmSdkLibrary.Retrieves.SystemView.RetrieveAttributes(Connection.OrgService, new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var c = CrmSdkLibrary.Retrieves.SystemView.RetrieveView(Connection.OrgService, new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var d = Messages.FetchXmlToQueryExpression(Connection.OrgService, c["fetchxml"].ToString());
            var converted = SqlConverter.Convert(d, c["layoutxml"].ToString());
            var dd = CrmSdkLibrary.Retrieves.SystemView.RetrieveAttributeMetadata(Connection.OrgService,
                new Guid("{00000000-0000-0000-00aa-000010001004}"),true);
            //var xml = new XmlDocument();
            //xml.LoadXml(c["layoutxml"].ToString());
            //var xnList = xml.GetElementsByTagName("cell");
            //foreach (XmlNode xn in xnList)
            //{
            //    if (xn.Attributes != null) Console.WriteLine(xn.Attributes["name"].Value);
            //}
            Console.WriteLine(converted.GenerateSql());
            Console.WriteLine("(End)");

        }

        public async Task RunAsync()
        {
            //HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("test191020@test191020.onmicrosoft.com", "Aa_1685511",
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
