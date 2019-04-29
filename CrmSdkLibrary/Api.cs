using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    public class Api
    {
        /// <summary>
        /// Authenticate to Microsoft Dynamics 365 with the Web API
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt595798(v=crm.8)"/>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="webAPIBaseAddress"></param>
        /// <returns></returns>
        public static HttpClient getNewHttpClient(string userName, string password, string domainName, string webAPIBaseAddress)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domainName) });
            client.BaseAddress = new Uri(webAPIBaseAddress);
            client.Timeout = new TimeSpan(0, 2, 0);
            return client;
        }
    }
}
