using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        /// <summary>
        /// https://carldesouza.com/dynamics-365-webapi-and-c-configuring-sample-code/
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public static HttpClient getCrmAPIHttpClient(string userName, string password, string domainName, string serviceUrl)
        {
            HttpClient httpClient;
            var Authority = DiscoverAuthority(serviceUrl);
            if (string.IsNullOrEmpty(Authority))
            {
                if (userName != string.Empty)
                {
                    httpClient = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domainName) });
                }
                else
                {
                    httpClient = new HttpClient(new HttpClientHandler(){UseDefaultCredentials = true});
                }
            }
            else
            {
                httpClient = new HttpClient(new HttpClientHandler());
                AuthenticationContext context = new AuthenticationContext(Authority,false);
            }
            httpClient = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domainName) }, true);
            //Define the Web API base address, the max period of execute time, the 
            // default OData version, and the default response payload format.
            httpClient.BaseAddress = new Uri(serviceUrl + "api/data/v8.1/");
            httpClient.Timeout = new TimeSpan(0, 2, 0);
            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public static string DiscoverAuthority(string serviceUrl)
        {
            try
            {
                //Require Microsoft.IdentityModel.Clients.ActiveDirectory.dll
                AuthenticationParameters ap = AuthenticationParameters.CreateFromResourceUrlAsync(
                    new Uri(serviceUrl + "api/data/")).Result;

                return ap.Authority;
            }
            catch (HttpRequestException e)
            {
                throw new Exception("An HTTP request exception occurred during authority discovery.", e);
            }
            catch (System.Exception e)
            {
                // This exception ocurrs when the service is not configured for OAuth.
                if (e.HResult == -2146233088)
                {
                    return String.Empty;
                }
                else
                {
                    throw e;
                }
            }
        }

        public static async Task<string> User(HttpClient httpClient)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await httpClient.GetAsync("WhoAmI", HttpCompletionOption.ResponseContentRead);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
                JObject whoAmIresp = JsonConvert.DeserializeObject<JObject>(await
                    response.Content.ReadAsStringAsync());
                //First obtain the user's ID.
                Guid myUserId = (Guid)whoAmIresp["UserId"];
                return myUserId.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
