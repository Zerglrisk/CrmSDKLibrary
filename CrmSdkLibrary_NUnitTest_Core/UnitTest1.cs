using Microsoft.Xrm.Sdk.Client;
using NUnit.Framework;
using System;
using System.Linq;
using System.Data;
using Microsoft.Xrm.Sdk;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace CrmSdkLibrary_NUnitTest_Core
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
            var item = CrmSdkLibrary_Core.Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
                Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

            var ec = item.Item1.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.QueryExpression("contact")
            {

            });

            // Query Expression Example

            // Where
            using (var context = new OrganizationServiceContext(CrmSdkLibrary_Core.Connection.Service))
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
            using (var context = new OrganizationServiceContext(CrmSdkLibrary_Core.Connection.Service))
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
            using (var context = new OrganizationServiceContext(CrmSdkLibrary_Core.Connection.Service))
            {
                var q = from a in context.CreateQuery("account")
                        join c in (
                            from _c in context.CreateQuery("opportunity")
                            where _c.GetAttributeValue<Guid?>("parentaccountid") != null
                            group _c by _c.GetAttributeValue<Guid>("parentaccountid") into _co

                            select new
                            {

                                ParentAccountId = _co.Key,
                                EstimatedValue = _co.Sum(x => x.GetAttributeValue<decimal>("estimatedvalue")),
                            }
                        ) on a.GetAttributeValue<Guid>("accountid") equals c.ParentAccountId into _cg
                        from c in _cg.DefaultIfEmpty() //left outer join (subquery?)
                        where c.EstimatedValue > 0
                        select new
                        {
                            AccountId = a.Id,
                            c.EstimatedValue,
                        };
                var data = q.ToList();
            }


            // Inner Join

            Assert.Pass();
        }

        [Test]
        public async Task Api_ADALAsync()
        {
            WebApi_ADAL.Api.SetClientId(Config.CrmConfig.ClientId);
            var httpClient = await WebApi_ADAL.Api.GetWebApiHttpClient(Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.EnvironmentUrl);

            var user = await WebApi_ADAL.Api.User(httpClient);

            var objectTypeCode = await WebApi_ADAL.Api.GetObjectTypeCode(httpClient, "account");
            var calcRF = await WebApi_ADAL.Api.CalculateRollupField(httpClient, "account", "d11452ee-b338-ed11-9db1-000d3aa3b95d", "new_i_opportunity");
            var RD = await WebApi_ADAL.Api.RetrieveDuplicates(httpClient, "account", "046a76d8-0075-ec11-8943-0022485a0300");

            var logs = await WebApi_ADAL.Api.GetPluginTraceLogs(httpClient);
            Assert.Pass();
        }

        [Test]
        public void Api_MSAL()
        {

        }
    }
}