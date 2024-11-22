using CrmSdkLibrary.Dataverse.Services;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Dataverse.NUnitTest
{
    public class Tests
    {
        public class AppSettings
        {
            public CrmConfig CrmConfig { get; set; }
        }

        private AppSettings Config { get; set; }

        [SetUp]
        public void Setup()
        {
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/secrets.json"))
            {
                Config = JsonConvert.DeserializeObject<AppSettings>(reader.ReadToEnd());
            }
        }

        [Test]
        public void Test1()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            var li = new List<string>();
            var ens = new EntityUtility(service);

            var abc = ens.GetEntitiesMetadata(x => x.LogicalName.Contains("new_")).Select(x => new { DisplayName = x.DisplayName.UserLocalizedLabel?.Label, LogicalName = x.LogicalName, CreatedOn = x.CreatedOn?.ToString("yyyy-MM-dd"), ModifiedOn = x.ModifiedOn?.ToString("yyyy-MM-dd"), OwnerId = x.OwnerId }).ToList();
            // Query Expression Example
            using (var context = new OrganizationServiceContext(Connection.Service))
            {
                //var q = from e in context.CreateQuery("systemuser")
                //		where e.GetAttributeValue<Guid>("systemuserid") == new Guid("692ac4bb-6973-ec11-8943-000d3ac7ee49")
                //		select new
                //		{
                //			id = e.Id,
                //			name = e.GetAttributeValue<string>("fullname")
                //		};

                //var q = from e in context.CreateQuery("entity")
                //		select e;
                //	//select new
                //	//{
                //	//	id = e.Id,
                //	//	createdon = e.GetAttributeValue<DateTime>("createdon")
                //	//};

                //var q = from e in context.CreateQuery("activityparty")
                //		where e.GetAttributeValue<Guid>("activitypartyid") == new Guid("5f1cf8e5-5251-44db-b631-153d815b23d2")
                //		select new
                //		{
                //			id = e.Id
                //		};

                //var data = q.ToList();
            }
            // Where
            using (var context = new OrganizationServiceContext(Connection.Service))
            {
                var q = from e in context.CreateQuery("contact")
                        where e.GetAttributeValue<string>("mobilephone") == "01012345678"
                        where e.GetAttributeValue<int>("statecode") == 0
                        orderby e.GetAttributeValue<DateTime>("createdon") descending
                        select new
                        {
                            id = e.Id,
                            code = e.GetAttributeValue<string>("fullname"),
                        };
                var data = q.ToList();
            }

            // Left Join
            using (var context = new OrganizationServiceContext(Connection.Service))
            {
                var q = from a in context.CreateQuery("account")
                        join c in context.CreateQuery("contact") on a.GetAttributeValue<Guid>("accountid") equals c.GetAttributeValue<Guid>("parentcustomerid") into _cg
                        from c in _cg.DefaultIfEmpty() //left outer join
                        where c.GetAttributeValue<int>("statecode") == 0
                        where a.GetAttributeValue<int>("statecode") == 0
                        where a.GetAttributeValue<string>("name") == "A" || a.GetAttributeValue<string>("name") == "B"
                        select new
                        {
                            AccountId = a.Id,
                            AccountName = a.GetAttributeValue<string>("name"),
                            ContactsName = c.GetAttributeValue<string>("fullname"),
                        };
                var data = q.ToList();
            }

            // Left Join Sub Query (SUM)
            //using (var context = new OrganizationServiceContext(CrmSdkLibrary.Connection.Service))
            //{
            //    var q = from a in context.CreateQuery("account")
            //            join c in (
            //                from _c in context.CreateQuery("opportunity")
            //                where _c.GetAttributeValue<Guid?>("parentaccountid") != null
            //                group _c by _c.GetAttributeValue<Guid>("parentaccountid") into _co
            //                select new
            //                {
            //                    ParentAccountId = _co.Key,
            //                    EstimatedValue = _co.Sum(x => x.GetAttributeValue<decimal>("estimatedvalue")),
            //                }
            //            ) on a.GetAttributeValue<Guid>("accountid") equals c.ParentAccountId into _cg
            //            from c in _cg.DefaultIfEmpty() //left outer join (subquery?)
            //            where c.EstimatedValue > 0
            //            select new
            //            {
            //                AccountId = a.Id,
            //                c.EstimatedValue,
            //            };
            //    var data = q.ToList();
            //}

            // Left Join Grouping
            using (var context = new OrganizationServiceContext(Connection.Service))
            {
                var query = from ac in context.CreateQuery("account")
                            join co in context.CreateQuery("contact") on ac["accountid"] equals co["parentcustomerid"] into coGroup
                            from co in coGroup.DefaultIfEmpty()
                            where (int)ac["statecode"] == 0 //&& (Guid)ac["accountid"] == recordId
                            select new { Account = ac, Contact = co };

                var data = query.ToList().GroupBy(x => x.Account.Id).Select(aItem => new
                {
                    Id = aItem.First().Account.Id,
                    Name = aItem.First().Account.GetAttributeValue<string>("name"),
                    CustomerSizeCode = aItem.First().Account.GetAttributeValue<OptionSetValue>("customersizecode")?.Value,
                    TransactionCurrencyId = aItem.First().Account.GetAttributeValue<EntityReference>("transactioncurrencyid")?.Id,
                    TransactionCurrencyIdName = aItem.First().Account.Contains("transactioncurrencyid") ? aItem.First().Account.FormattedValues["transactioncurrencyid"] : null,
                    Contacts = aItem.Where(x => x.Contact != null && x.Contact.Contains("contactid") && (Guid)x.Contact["contactid"] != Guid.Empty).Select(cItem => new
                    {
                        Id = (Guid)cItem.Contact["contactid"], //Join Entity Has not Id Value.
                        ParentCustomerId = cItem.Contact.Contains("parentcustomerid") ? cItem.Contact.GetAttributeValue<EntityReference>("parentcustomerid").Id : (Guid?)null,
                        ParentCustomerIdName = cItem.Contact.Contains("parentcustomerid") ? cItem.Contact.GetAttributeValue<EntityReference>("parentcustomerid").Name : null, // Join Entity Has not FormattedValue
                    }).ToList()
                }).ToList();
            }

            // Left Join Grouping - Other Way
            {
                var ec = Connection.Service.RetrieveMultiple(new QueryExpression("account")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression()
                    {
                        Conditions =
                        {
                            new ConditionExpression("statecode", ConditionOperator.Equal, 0),

							//new ConditionExpression("new_l_opportunity", ConditionOperator.Equal, recordId)
						}
                    },
                    LinkEntities =
                    {
                        new LinkEntity( "account", "contact","accountid","parentcustomerid", JoinOperator.LeftOuter)
                        {
                            EntityAlias = "co",
                            Columns = new ColumnSet(true),
                            LinkCriteria = new FilterExpression() {
                            Conditions=
                                {
                                    new ConditionExpression("statecode", ConditionOperator.Equal, 0),
                                }
                            }
                        }
                    }
                });
                var data = ec.Entities.GroupBy(x => x.Id).Select(item => new
                {
                    Id = item.First().Id,
                    Name = item.First().GetAttributeValue<string>("name"),
                    CustomerSizeCode = item.First().GetAttributeValue<OptionSetValue>("customersizecode")?.Value,
                    TransactionCurrencyId = item.First().GetAttributeValue<EntityReference>("transactioncurrencyid")?.Id,
                    TransactionCurrencyIdName = item.First().Contains("transactioncurrencyid") ? item.First().FormattedValues["transactioncurrencyid"] : null,
                    Revenue = item.First().GetAttributeValue<Money>("revenue")?.Value,
                    CreditLimit = item.First().GetAttributeValue<Money>("creditlimit")?.Value,
                    OpenRevenue = item.First().GetAttributeValue<Money>("openrevenue")?.Value,
                    DoNotFax = item.First().GetAttributeValue<bool?>("donotfax") ?? false,
                    ExchangeRate = item.First().GetAttributeValue<decimal?>("exchangerate"),
                    NumberOfEmployees = item.First().GetAttributeValue<int?>("numberofemployees"),
                    Contacts = item.Where(x => x.Contains("co.parentcustomerid"))?.Select(co => new
                    {
                        Id = co.GetAliasedValue<Guid>("co.contactid"),
                        ParentCustomerId = co.Contains("parentcustomerid") ? co.GetAliasedValue<EntityReference>("parentcustomerid").Id : (Guid?)null,
                        ParentCustomerIdName = co.Contains("parentcustomerid") ? co.FormattedValues["co.new_l_account"] : null,
                    }).ToList()
                }).ToList();
            }

            // Inner Join

            Assert.Pass();
        }

        [Test]
        public async Task Api_ADALAsync()
        {
            var config = Config.CrmConfig;
            WebApi_ADAL.Api.SetClientId(config.ClientId);
            var httpClient = await WebApi_ADAL.Api.GetWebApiHttpClient(config.UserId, config.UserPassword, config.EnvironmentUrl);

            var user = await WebApi_ADAL.Api.User(httpClient);

            var objectTypeCode = await WebApi_ADAL.Api.GetObjectTypeCode(httpClient, "account");
            var calcRF = await WebApi_ADAL.Api.CalculateRollupField(httpClient, "account", "d11452ee-b338-ed11-9db1-000d3aa3b95d", "new_i_opportunity");
            var RD = await WebApi_ADAL.Api.RetrieveDuplicates(httpClient, "account", "046a76d8-0075-ec11-8943-0022485a0300");

            var logs = await WebApi_ADAL.Api.GetPluginTraceLogs(httpClient);
            Assert.Pass();
        }

        [Test]
        public void Clone()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);
            Copy.CloneRecord(service, "lead", new Guid("a2249ae9-d568-ee11-9ae7-6045bd591b31"));
        }

        [Test]
        public void Api_MSAL()
        {
        }

        [Test]
        public async Task ExportAsync()
        {
            try
            {
                var config = Config.CrmConfig;
                var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                       config.UserId, config.UserPassword, config.TenantId);

                var currentOrg = service.Execute(new RetrieveCurrentOrganizationRequest()) as RetrieveCurrentOrganizationResponse;
                var url = currentOrg.Detail.Endpoints
                    .Where(e => e.Key == Microsoft.Xrm.Sdk.Organization.EndpointType.WebApplication)
                    .FirstOrDefault()
                    .Value;
                var qe2 = new QueryExpression("account")
                {
                    ColumnSet = new ColumnSet(true)
                };
                var abc = await service.RetrieveMultipleAsync(qe2);
                var qe = new QueryExpression("savedquery")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression()
                    {
                        Conditions =
                    {
                        //new ConditionExpression("solutionid", ConditionOperator.Equal, new Guid()),
                        new ConditionExpression("returnedtypecode", ConditionOperator.Equal, "new_incident"),
                        new ConditionExpression("isdefault", ConditionOperator.Equal, true),

                        //new ConditionExpression("savedqueryid", ConditionOperator.Equal, new Guid()),
                    }
                    }
                };

                var defaultView = await service.RetrieveMultipleAsync(qe);

                var view = defaultView.Entities.First().ToEntityReference();
                string fetchXml = defaultView.Entities.First().GetAttributeValue<string>("fetchxml");
                string layoutXml = defaultView.Entities.First().GetAttributeValue<string>("layoutxml");
                string queryApi = defaultView.Entities.First().GetAttributeValue<string>("queryapi") ?? "";

                var excel = Messages.Undocumented.ExportToExcel(service, view, fetchXml, layoutXml, queryApi);

                if (excel != null)
                {
                    File.WriteAllBytes("test.xlsx", excel);
                }
                Assert.That(excel, Is.Not.Null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void RestoreAsync()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            var a = Audits.RestoreDeletedRecord(service, new Guid("F44E78E4-EE29-EE11-A9BB-000D3AA26549"));
        }

        [Test]
        public void ActivateRecord()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            Messages.ActivateRecord(service, "account", new Guid("09859910-8f35-ee11-bdf4-000d3a07e75b"));
        }

        [Test]
        public void SendEmail()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            Messages.SendEmail(service, new Definition.Email.EmailFormat()
            {
                From = new Definition.Email.EntityReferenceEmailRecipient(new EntityReference("systemuser", service.CallerId)),
                To = new Definition.Email.StringEmailRecipient[] { new Definition.Email.StringEmailRecipient("tester@test.com"), },
                Subject = "this thes",
                Description = @"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
	<title></title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
</head>
<body style=""margin: 0; padding: 0;"">
</body>
</html>
"
            });
        }

        [Test]
        public void OptionSetDescription()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            //global optionset
            var r = Messages.RetrieveOptionSet(service, "statecode", true);
            var rb = r.Options.Select(x => x.Description.LocalizedLabels.FirstOrDefault()?.Label).Distinct().ToList();
            var re = r.Options.Select(x => x.ExternalValue).Distinct().ToList();
        }

        [Test]
        public void RetrieveSiteMap()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId,
                   config.UserId, config.UserPassword, config.TenantId);

            #region Case 1

            var appModuleComponentQuery = new QueryExpression("appmodulecomponent")
            {
                ColumnSet = new ColumnSet("objectid", "componenttype"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
						//new ConditionExpression("appmoduleid", ConditionOperator.Equal, appModuleId),  // 상위 AppModuleId로 조회
						new ConditionExpression("componenttype", ConditionOperator.Equal, 62)  // 62는 Sitemap
					}
                },
                LinkEntities =
                {
					// AppModule 연결 (상위 AppModule의 Name 가져오기)
					new LinkEntity("appmodulecomponent", "appmodule", "appmoduleidunique", "appmoduleidunique", JoinOperator.Inner)
                    {
                        Columns = new ColumnSet("name"),  // 상위 AppModule의 Name
						EntityAlias = "appmodule"
                    },
					// Sitemap 연결 (Sitemap의 XML 정보 가져오기)
					new LinkEntity("appmodulecomponent", "sitemap", "objectid", "sitemapid", JoinOperator.Inner)
                    {
                        Columns = new ColumnSet("sitemapid", "sitemapxml"),
                        EntityAlias = "sitemap"
                    }
                }
            };

            // Query 실행
            EntityCollection sitemapResults = service.RetrieveMultiple(appModuleComponentQuery);

            foreach (Entity entity in sitemapResults.Entities)
            {
                var appName = entity.GetAttributeValue<AliasedValue>("appmodule.name").Value.ToString();
                var sitemapId = entity.GetAttributeValue<AliasedValue>("sitemap.sitemapid").Value.ToString();
                var sitemapXml = entity.GetAttributeValue<AliasedValue>("sitemap.sitemapxml").Value.ToString();

                if (appName == "Sales Hub")
                {
                }
                //Console.WriteLine($"App Name: {appName}, Sitemap ID: {sitemapId}, Sitemap XML: {sitemapXml}");
            }

            #endregion Case 1

            #region Linq

            var context = new OrganizationServiceContext(service);

            var appModuleWithSitemap = from amc in context.CreateQuery("appmodulecomponent")
                                       join am in context.CreateQuery("appmodule") on amc.GetAttributeValue<EntityReference>("appmoduleidunique").Id equals am.GetAttributeValue<Guid>("appmoduleidunique")
                                       join sm in context.CreateQuery("sitemap") on amc.GetAttributeValue<Guid>("objectid") equals sm.GetAttributeValue<Guid>("sitemapid")
                                       //where amc["appmoduleid"].Equals(appModuleId)  // 상위 AppModuleId로 조회
                                       //&& ((OptionSetValue)amc["componenttype"]).Value == 62  // 62는 Sitemap
                                       where amc.GetAttributeValue<OptionSetValue>("componenttype").Value == 62
                                       select new
                                       {
                                           AppName = am.GetAttributeValue<string>("name"),     // AppModule의 Name
                                           SitemapId = sm.GetAttributeValue<Guid>("sitemapid"),
                                           SitemapXml = sm.GetAttributeValue<string>("sitemapxml"),
                                       };

            foreach (var result in appModuleWithSitemap.ToList())
            {
                if (result.AppName == "Sales Hub")
                {
                    var parser = new AdaptiveSitemapParser();
                    var a = parser.ParseSitemap(result.SitemapXml);
                    var b = a.Root.FilterNodesWithPrivileges();
                }
                //Console.WriteLine($"App Name: {result.AppName}, Sitemap ID: {result.SitemapId}, Sitemap XML: {result.SitemapXml}");
            }

            #endregion Linq
        }

        [Test]
        public void ChangeSavedQueryOwnership()
        {
            var config = Config.CrmConfig;
            var service = Connection.ConnectServiceOAuth(config.EnvironmentUrl, config.ClientId, config.UserId, config.UserPassword, config.TenantId);

            //Get Specifiy User's Saved Query
            var qe = new QueryExpression("userquery")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression(LogicalOperator.Or)
                {
                    Conditions =
                    {
                        new ConditionExpression("ownerid", ConditionOperator.Equal, new Guid("")),
                    }
                }
            };

            var ec = service.RetrieveMultiple(qe);

            foreach(var entity in ec.Entities)
            {
                entity.Attributes["ownerid"] = new EntityReference("systemuser", new Guid(""));
                //service.Update(entity);
            }
            #region You cannot Retrieve Using Disabled User

            //var qe = new QueryExpression("userquery")
            //{
            //    ColumnSet = new ColumnSet(true),
            //    Criteria = new FilterExpression(LogicalOperator.Or)
            //    {
            //        Conditions =
            //        {
            //            new ConditionExpression("ownerid", ConditionOperator.Equal, new Guid("")),
            //        }
            //    }
            //};

            //var ec = service.RetrieveMultiple(qe);

            //var qe2 = new QueryExpression("userquery")
            //{
            //    ColumnSet = new ColumnSet(true),
            //    Criteria = new FilterExpression(LogicalOperator.Or)
            //    {
            //        Conditions =
            //        {
            //            new ConditionExpression("ownerid", ConditionOperator.Equal, new Guid("")),
            //        }
            //    }
            //};

            //var ec2 = service.RetrieveMultiple(qe2);

            #endregion You cannot Retrieve Using Disabled User

            #region 모든 활성화된 사용자를 impersonate하여 공유 받은 퇴사좌의 userquery 조회
            //// 1. 먼저 활성 상태인 사용자들 조회
            //QueryExpression userQuery = new QueryExpression("systemuser")
            //{
            //    ColumnSet = new ColumnSet("systemuserid"),
            //    Criteria = new FilterExpression()
            //    {
            //        Conditions =
            //        {
            //            new ConditionExpression("isdisabled", ConditionOperator.Equal, false)
            //        }
            //    }
            //};

            //var activeUsers = service.RetrieveMultiple(userQuery);

            //// 2. 각 활성 사용자로 impersonation하여 비활성화된 사용자의 view 찾기
            //var disabledUserId = new Guid("");
            //Dictionary<Guid, string> foundViews = new Dictionary<Guid, string>(); // 중복 방지용

            //foreach (Entity activeUser in activeUsers.Entities)
            //{
            //    try
            //    {
            //        service.CallerId = activeUser.Id;

            //        QueryExpression viewQuery = new QueryExpression("userquery")
            //        {
            //            ColumnSet = new ColumnSet("name", "ownerid"),
            //            Criteria = new FilterExpression()
            //            {
            //                Conditions =
            //                {
            //                    new ConditionExpression("ownerid", ConditionOperator.Equal, disabledUserId)
            //                }
            //            }
            //        };

            //        EntityCollection views = service.RetrieveMultiple(viewQuery);

            //        foreach (Entity view in views.Entities)
            //        {
            //            if (!foundViews.ContainsKey(view.Id))
            //            {
            //                foundViews.Add(view.Id, view.GetAttributeValue<string>("name"));
            //                //Console.WriteLine($"Found view: {view["name"]}, ID: {view.Id}");
            //                // 여기서 owner 변경 작업 수행 가능
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //Console.WriteLine($"Failed for user {activeUser.Id}: {ex.Message}");
            //        continue; // 실패해도 다음 사용자로 계속 진행
            //    }
            //}
            #endregion
        }
    }
}