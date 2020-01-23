using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CrmSdkLibrary.Definition;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrmSdkLibrary
{
    public class Api
    {
        //https://stackoverflow.com/questions/50795500/authenticate-to-dynamics-365-using-adal-v3-using-clientid/51305491



        public static string ClientId;

        /// <summary>
        /// Authenticate to Microsoft Dynamics 365 with the Web API
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt595798(v=crm.8)"/>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="webAPIBaseAddress"></param>
        /// <returns></returns>
        public static HttpClient GetNewHttpClient(string userName, string password, string domainName, string webAPIBaseAddress)
        {
            return GetNewHttpClient(new NetworkCredential(userName, password, domainName), webAPIBaseAddress);
        }

        public static HttpClient GetNewHttpClient(NetworkCredential credential, string webAPIBaseAddress)
        {
            var client = new HttpClient(new HttpClientHandler() {Credentials = credential})
            {
                BaseAddress = new Uri(webAPIBaseAddress), Timeout = new TimeSpan(0, 2, 0)
            };
            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://carldesouza.com/dynamics-365-webapi-and-c-configuring-sample-code/"/>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        //public static HttpClient getCrmAPIHttpClient(string userName, string password, string domainName, string serviceUrl)
        //{
        //    Api api = new Api();
        //    HttpClient httpClient;
        //    var Authority = DiscoverAuthority(serviceUrl);
        //    if (string.IsNullOrEmpty(Authority))
        //    {
        //        if (userName != string.Empty)
        //        {
        //            httpClient = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domainName) });
        //        }
        //        else
        //        {
        //            httpClient = new HttpClient(new HttpClientHandler(){UseDefaultCredentials = true});
        //        }
        //    }
        //    else
        //    {
        //        httpClient = new HttpClient(new HttpClientHandler());
        //        AuthenticationContext context = new AuthenticationContext(Authority, false);
        //    }
        //    httpClient = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domainName) }, true);
        //    //Define the Web API base address, the max period of execute time, the 
        //    // default OData version, and the default response payload format.
        //    httpClient.BaseAddress = new Uri(serviceUrl + "api/data/v8.1/");
        //    httpClient.Timeout = new TimeSpan(0, 2, 0);
        //    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    return httpClient;
        //}


        private static string ApplicationId { get; set; } = string.Empty;

        /// <summary>
        /// Set Azure App Id
        /// </summary>
        /// <param name="applicationId"></param>
        public static void SetApplicationId(string applicationId)
        {
            ApplicationId = applicationId;
        }

        public static HttpClient GetWebApiHttpClient(string userName, string password, string serviceUrl,
            string authorityUrl = "https://login.microsoftonline.com/common")
        {
            return GetWebApiHttpClient(new UserPasswordCredential(userName, password), serviceUrl, authorityUrl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://rajeevpentyala.com/2018/09/18/code-snippet-authenticate-and-perform-operations-using-d365-web-api-and-c/"/>
        /// <see href="https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/305276/crud-operations-using-web-api-in-console-app?pifragment-97030=1#responses"/>
        /// <param name="credential"></param>
        /// <param name="serviceUrl"></param>
        /// <param name="authorityUrl"></param>
        /// <returns></returns>
        public static HttpClient GetWebApiHttpClient(UserPasswordCredential credential, string serviceUrl, string authorityUrl = "https://login.microsoftonline.com/common")
        {
            //var credentials = new UserPasswordCredential(userName, password);
            var context = new AuthenticationContext(authorityUrl);
            var authResult = context.AcquireTokenAsync(serviceUrl, Api.ApplicationId, credential).Result;

            var httpClient = new HttpClient() { BaseAddress = new Uri(serviceUrl), Timeout = new TimeSpan(0, 2, 0) };

            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            return httpClient;
        }
        //public static string DiscoverAuthority(string serviceUrl)
        //{
        //    try
        //    {
        //        //Require Microsoft.IdentityModel.Clients.ActiveDirectory.dll
        //        AuthenticationParameters ap = AuthenticationParameters.CreateFromResourceUrlAsync(
        //            new Uri(serviceUrl + "api/data/")).Result;

        //        return ap.Authority;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        throw new Exception("An HTTP request exception occurred during authority discovery.", e);
        //    }
        //    catch (System.Exception e)
        //    {
        //        // This exception ocurrs when the service is not configured for OAuth.
        //        if (e.HResult == -2146233088)
        //        {
        //            return String.Empty;
        //        }
        //        else
        //        {
        //            throw e;
        //        }
        //    }
        //}

        /// <summary>
        /// Get User Using WebAPI
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static async Task<WhoAmI> User(HttpClient httpClient)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response =
                    await httpClient.GetAsync("api/data/v9.0/WhoAmI", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    var whoAmI = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());
                    whoAmI.Add("ODataContext", whoAmI["@odata.context"]);
                    whoAmI.Remove("@odata.context");

                    return whoAmI.ToObject<WhoAmI>();
                }

                //First obtain the user's ID.
                //Guid myUserId = (Guid)whoAmIresp["UserId"];
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //5000개 레코드 이상 가져오는지 확인
        public static async Task<string> GetDataAsJson(HttpClient httpClient)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response = await httpClient.GetAsync("api/data/v9.0/accounts?$select=name,accountnumber?$filter=", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    var resp = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());

                    return resp.ToString();
                }
                //First obtain the user's ID.
                //Guid myUserId = (Guid)whoAmIresp["UserId"];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="target"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static async Task<string> CalculateRollupField(HttpClient httpClient, EntityReference target,
            string fieldName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                
                using (var response =
                    await httpClient.GetAsync($@"api/data/v8.0/CalculateRollupField(Target=@tid,FieldName=@fname)?@tid={{'@odata.id':'{target.ToEntitySetPath()}({target.Id})'}}&@fname='{fieldName}'", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new Exception($"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                        //var aa = whoAmI.ToObject<ApiExceptionWrapper>(); //에러
                    }

                    var whoAmI = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());

                    return whoAmI.ToObject<string>();
                }

                //First obtain the user's ID.
                //Guid myUserId = (Guid)whoAmIresp["UserId"];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
