using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmSdkLibrary.UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		public class AppSettings
		{
			public CrmConfig CrmConfig { get; set; }
		}

		private AppSettings Config { get; set; }

		public UnitTest1()
		{
			using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/secrets.json"))
			{
				Config = JsonConvert.DeserializeObject<AppSettings>(reader.ReadToEnd());
			}
		}

		[TestMethod]
		public void v8TestMethod1()
		{
			var conn = new Connectionv8();
			var service = conn.ConnectService(new Uri("https://crmurl/XRMServices/2011/Organization.svc"), "userid", "password");


			QueryExpression query = new QueryExpression("usersettings");
			query.ColumnSet = new ColumnSet(true);
			query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, service.CallerId);
			var results = service.RetrieveMultiple(query);

		}

		[TestMethod]
		public void TestMethod1()
		{
			var conn = new Connection();
			var service = conn.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			var ec = service.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.QueryExpression("contact")
			{
			});
		}

		[TestMethod]
		public async Task TestMathod2Async()
		{
			var conn = new Connection();
			var item = conn.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			try
			{
				var token = new CancellationTokenSource();
				var t = item.RetrieveMultipleAsync(new Microsoft.Xrm.Sdk.Query.QueryExpression("contact")
				{
					ColumnSet = new Microsoft.Xrm.Sdk.Query.ColumnSet("fullname", "contactid")
				}, token.Token);

				//Cancel Test
				token.Cancel();
				var ec = await t;
				var a = ec.Entities;
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}