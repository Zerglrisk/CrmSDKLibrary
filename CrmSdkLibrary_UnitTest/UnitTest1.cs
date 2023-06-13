using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Newtonsoft.Json;
using System;
using System.IO;

namespace CrmSdkLibrary_UnitTest
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
            //using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/secrets.json"))
            //{
            //    Config = JsonConvert.DeserializeObject<AppSettings>(reader.ReadToEnd());
            //}
        }

        [TestMethod]
        public void TestMethod1()
        {
            var conn = new CrmSdkLibrary.Connection();
            var item = conn.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
                Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

            var ec = item.Item1.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.QueryExpression("contact")
            {

            });
        }
    }
}
