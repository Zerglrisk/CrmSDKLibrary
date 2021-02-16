using System;
using System.Net.Http;
using System.Threading.Tasks;
using CrmSdkLibrary.Definition.Enum;
using CrmSdkLibrary.Entities;
using WebApi;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmSdkLibrary.Connection conn = new CrmSdkLibrary.Connection();
            var myid = conn.ConnectServiceOAuth("https://test.crm5.dynamics.com", "clientid", "id", "pw", "tenantid");


            #region SecurityRoles



            var role = new SecurityRoles();


            var privilegesRole = new Privilege();
            //var list = role.RetrieveSecurityRolesList(Connection.OrgService);

            //foreach (var entity in list)
            //{
            //    Console.WriteLine($"{entity[SecurityRoles.PrimaryKeyAttribute]}({entity.Id})");

            //}

            //var currentPrivileges = role.RetrievePrivilegesRole(Connection.OrgService, new Guid("84e8f3e2-de6c-ea11-b817-005056a1b19b"));

            ////foreach (var privilege in privileges)
            ////{
            ////    Console.WriteLine($"{privilege.PrivilegeId}({privilege.Depth})");
            ////}

            //var priv = privilegesRole.RetrievePrivileges(Connection.OrgService, currentPrivileges);
            //foreach (var entity in priv)
            //{
            //    if(entity[Privilege.PrimaryKeyAttribute].ToString().ToLower().Contains("contact"))
            //    Console.WriteLine($"{entity.Id}({entity[Privilege.PrimaryKeyAttribute]})");
            //}

            #endregion

            //var allEntities = Messages.RetrieveAllEntities(Connection.OrgService);
            //var uis = allEntities.Where(x => x.LogicalName.Contains("view"));
            //foreach (var ui in uis)
            //{
            //    Console.WriteLine(ui.LogicalName);
            //}
            ////foreach (var entityMetadata in cc)
            ////{
            ////    if (entityMetadata.LogicalName.Contains("new_"))
            ////    {
            ////        Console.WriteLine(entityMetadata.LogicalName + ", " + count);
            ////    }

            ////    count++;
            ////}

            //QueryExpression query = new QueryExpression
            //{
            //    EntityName = "userentityuisettings",
            //    ColumnSet = new ColumnSet(true),
            //    Criteria =
            //    {
            //        Filters =
            //        {
            //            new FilterExpression
            //            {
            //                FilterOperator = LogicalOperator.And,
            //                Conditions =
            //                {
            //                    new ConditionExpression("owninguser",
            //                        ConditionOperator.Equal, myid),
            //                    new ConditionExpression("recentlyviewedxml",
            //                        ConditionOperator.NotNull)
            //                }
            //            }
            //        }
            //    }
            //};

            //DataCollection<Entity> result =
            //    Connection.OrgService.RetrieveMultiple(query).Entities;


            //var qe = new QueryExpression("organizationui")
            //{
            //    ColumnSet = new ColumnSet(true)
            //};

            //var ec = Connection.OrgService.RetrieveMultiple(qe);
            //var views = SystemView.RetrieveViews(Connection.OrgService, "account");
            //var view = views.Entities.Where(x => x["name"].ToString() == "All Accounts");

            //var aa = Messages.RetrieveEntity(Connection.OrgService, "contact", EntityFilters.All);
            //var b = CrmSdkLibrary.Entities.SystemView.RetrieveAttributes(Connection.OrgService,
            //    new Guid("{00000000-0000-0000-00aa-000010001004}"));
            //var c = CrmSdkLibrary.Entities.SystemView.RetrieveView(Connection.OrgService,
            //    new Guid("{00000000-0000-0000-00aa-000010001004}"));
            //var d = Messages.FetchXmlToQueryExpression(Connection.OrgService, c["fetchxml"].ToString());
            //var converted = SqlConverter.Convert(d, c["layoutxml"].ToString());
            //var dd = CrmSdkLibrary.Entities.SystemView.RetrieveAttributeMetadata(Connection.OrgService,
            //    new Guid("{00000000-0000-0000-00aa-000010001004}"), true);
            //var Systemview = SystemView.RetrieveViews(Connection.OrgService, "account");
            ////var xml = new XmlDocument();
            ////xml.LoadXml(c["layoutxml"].ToString());
            ////var xnList = xml.GetElementsByTagName("cell");
            ////foreach (XmlNode xn in xnList)
            ////{
            ////    if (xn.Attributes != null) Console.WriteLine(xn.Attributes["name"].Value);
            ////}
            ////foreach (var entity in Systemview.Entities)
            ////{
            ////    foreach (var att in entity.Attributes)
            ////    {
            ////            Console.WriteLine($"{att.Key} : {att.Value}");
            ////    }
            ////}

            Program app = new Program();
            Task.WaitAll(Task.Run(async () => await app.RunAsync()));

            //Console.WriteLine(converted.GenerateSql());
            Console.WriteLine("(End)");

        }

        public async Task RunAsync()
        {
            Api.SetClientId("clientid");
            //HttpClient client = Api.getCrmAPIHttpClient("tester200317@tester200317.onmicrosoft.com", "tester201018@",
            //    "test191020.onmicrosoft.com", "https://tester200317.crm5.dynamics.com/");
            var tenantid = Api.GetTenantId("https://test.crm5.dynamics.com/");
            HttpClient client = await Api.GetWebApiHttpClient("id",
                "pw",
                "https://test.crm5.dynamics.com/",
                $"https://login.microsoftonline.com/{tenantid}", secret: "secret");

            //var aa = await Api.GetImageBlob(client, "8deff917-1035-eb11-a813-000d3a085bd4");
            //Console.WriteLine(aa);
            //var id = await Api.GetAccessTokenToken("https://text201218.crm5.dynamics.com", "Be-m71px1YC-rsH4bCQUyoK19LEFXX.M.H", "https://login.microsoftonline.com/19098be0-47c0-4627-a814-f69548323a3d");
            //var client = await Api.GetWebApiHttpClient(
            //    resourceUrl: "https://text201218.crm5.dynamics.com",
            //    authorityUrl: "https://login.microsoftonline.com/19098be0-47c0-4627-a814-f69548323a3d", secret: "E1p3~8~~1i46Id7QSflzmeZcRHRuE-Usy-");

            //Load All EntiySetName To Memory
            //var entitySetPaths = Api.EntitySetPaths;
            Console.WriteLine(await Api.User(client));

            //var organizationDetail = await Api.GetCurrentOrganization(client, EndpointAccessType.Default);
            //var qe = new QueryExpression("opportunity") {ColumnSet = new ColumnSet(true)};
            //var retrieve = CrmSdkLibrary.Connection.OrgService.RetrieveMultiple(qe);

            ////need test
            //var ab = await Api.RetrieveDuplicates(client, retrieve.Entities.First(),
            //    new PagingInfo() {PageNumber = 1, Count = 10});

            //var objectTyperCode = await Api.GetObjectTypeCode(client, "account");
            //Console.WriteLine($"Account ObjectTypeCode : {objectTyperCode}");

            //var cc = Messages.GetCurrentOrganization(Connection.OrgService);
            //Console.WriteLine($"{cc.UrlName} +  {cc.EnvironmentId} + {cc.FriendlyName} + {cc.OrganizationVersion} + {cc.UniqueName} + {cc.Endpoints.First().Key}:{cc.Endpoints.First().Value}");

            //var bb = await Api.GetDataAsJson(client);
            //Console.WriteLine(bb);

        }

    }

}