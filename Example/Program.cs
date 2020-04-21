using CrmSdkLibrary;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using CrmSdkLibrary.Definition;
using CrmSdkLibrary.Definition.Enum;
using CrmSdkLibrary.Entities;
using Microsoft.IdentityModel.Clients.ActiveDirectory.Extensibility;
using Microsoft.Xrm.Sdk;
using WebApi;
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
            var myid = conn.ConnectService("tester200420", "tester200420@tester200420.onmicrosoft.com", "tester201018@",
                Location.NorthAmerica);
            //Login Case 2
            //var myid= conn.ConnectService(new Uri("https://tester200420.api.crm.dynamics.com/XRMServices/2011/Organization.svc"),
            //    "tester200420@tester200420.onmicrosoft.com", "tester201018@");
            //Login Case 3
            //var myid = conn.ConnectService("https://tester200420.crm.dynamics.com",
            //    "tester200420@tester200420.onmicrosoft.com", "tester201018@", AuthenticationType.Office365);
            Console.WriteLine(myid);
            var cc = Messages.RetrieveAllEntities(Connection.OrgService);
            var count = 0;

            var allEntities = Messages.RetrieveAllEntities(Connection.OrgService);
            var uis = allEntities.Where(x => x.LogicalName.Contains("view"));
            foreach (var ui in uis)
            {
                Console.WriteLine(ui.LogicalName);
            }
            //foreach (var entityMetadata in cc)
            //{
            //    if (entityMetadata.LogicalName.Contains("new_"))
            //    {
            //        Console.WriteLine(entityMetadata.LogicalName + ", " + count);
            //    }

            //    count++;
            //}

            QueryExpression query = new QueryExpression
            {
                EntityName = "userentityuisettings",
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Filters =
                    {
                        new FilterExpression
                        {
                            FilterOperator = LogicalOperator.And,
                            Conditions =
                            {
                                new ConditionExpression("owninguser",
                                    ConditionOperator.Equal, myid),
                                new ConditionExpression("recentlyviewedxml",
                                    ConditionOperator.NotNull)
                            }
                        }
                    }
                }
            };

            DataCollection<Entity> result =
                Connection.OrgService.RetrieveMultiple(query).Entities;


            var qe = new QueryExpression("organizationui")
            {
                ColumnSet = new ColumnSet(true)
            };

            var ec = Connection.OrgService.RetrieveMultiple(qe);
            var views = SystemView.RetrieveViews(Connection.OrgService, "account");
            var view = views.Entities.Where(x => x["name"].ToString() == "All Accounts");

            var aa = Messages.RetrieveEntity(Connection.OrgService, "contact", EntityFilters.All);
            var b = CrmSdkLibrary.Entities.SystemView.RetrieveAttributes(Connection.OrgService,
                new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var c = CrmSdkLibrary.Entities.SystemView.RetrieveView(Connection.OrgService,
                new Guid("{00000000-0000-0000-00aa-000010001004}"));
            var d = Messages.FetchXmlToQueryExpression(Connection.OrgService, c["fetchxml"].ToString());
            var converted = SqlConverter.Convert(d, c["layoutxml"].ToString());
            var dd = CrmSdkLibrary.Entities.SystemView.RetrieveAttributeMetadata(Connection.OrgService,
                new Guid("{00000000-0000-0000-00aa-000010001004}"), true);
            var Systemview = SystemView.RetrieveViews(Connection.OrgService, "account");
            //var xml = new XmlDocument();
            //xml.LoadXml(c["layoutxml"].ToString());
            //var xnList = xml.GetElementsByTagName("cell");
            //foreach (XmlNode xn in xnList)
            //{
            //    if (xn.Attributes != null) Console.WriteLine(xn.Attributes["name"].Value);
            //}
            //foreach (var entity in Systemview.Entities)
            //{
            //    foreach (var att in entity.Attributes)
            //    {
            //            Console.WriteLine($"{att.Key} : {att.Value}");
            //    }
            //}

            Program app = new Program();
            Api.SetClientId("65ca5727-7553-4436-b291-690eb89adea8");
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));

            Console.WriteLine(converted.GenerateSql());
            Console.WriteLine("(End)");

        }

        public async Task RunAsync()
        {
            //HttpClient client = CrmSdkLibrary.Api.getCrmAPIHttpClient("tester200317@tester200317.onmicrosoft.com", "tester201018@",
            //    "test191020.onmicrosoft.com", "https://tester200317.crm5.dynamics.com/");
            HttpClient client = await Api.GetWebApiHttpClient("tester200420@tester200420.onmicrosoft.com",
                "tester201018@",
                "https://tester200420.crm.dynamics.com",
                "https://login.microsoftonline.com/1fd4863a-b5bc-42b2-9617-56a7d222fad7");

            var cli = await Api.GetWebApiHttpClient("E:6-@t12F_E2ITO6Xaz1N0?TAdDzz6_W",
                "https://tester200420.crm.dynamics.com",
                "https://login.microsoftonline.com/1fd4863a-b5bc-42b2-9617-56a7d222fad7");
            //Load All EntiySetName To Memory
            var entitySetPaths = Api.EntitySetPaths;
            Console.WriteLine(await Api.User(client));

            var organizationDetail = await Api.GetCurrentOrganization(client, EndpointAccessType.Default);
            var qe = new QueryExpression("opportunity") {ColumnSet = new ColumnSet(true)};
            var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);

            //need test
            var ab = await Api.RetrieveDuplicates(client, retrieve.Entities.First(),
                new PagingInfo() {PageNumber = 1, Count = 10});

            var objectTyperCode = await Api.GetObjectTypeCode(client, "account");
            Console.WriteLine($"Account ObjectTypeCode : {objectTyperCode}");

            //var cc = Messages.GetCurrentOrganization(Connection.OrgService);
            //Console.WriteLine($"{cc.UrlName} +  {cc.EnvironmentId} + {cc.FriendlyName} + {cc.OrganizationVersion} + {cc.UniqueName} + {cc.Endpoints.First().Key}:{cc.Endpoints.First().Value}");

            //var bb = await Api.GetDataAsJson(client);
            //Console.WriteLine(bb);

        }

    }

}