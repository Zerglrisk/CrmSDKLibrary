using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CrmSdkLibrary.Definition;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrmSdkLibrary
{
    public class Api
    {
        //https://stackoverflow.com/questions/50795500/authenticate-to-dynamics-365-using-adal-v3-using-clientid/51305491

        private static Dictionary<string, string> _entitySetPaths;
        public static Dictionary<string, string> EntitySetPaths => _entitySetPaths ?? (_entitySetPaths = Messages.GetAllEntitySetName(Connection.OrgService));

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
        //public static HttpClient GetCrmApiHttpClient(string userName, string password, string domainName, string serviceUrl)
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
        //            httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
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
        /// Set Azure App Id(Client ID)
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
            //httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue")
            return httpClient;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="serviceUrl"></param>
        /// <param name="authorityUrl"></param>
        /// <returns></returns>
        public static HttpClient GetWebApiHttpClient(string secret, string serviceUrl, string authorityUrl = "https://login.microsoftonline.com/common")
        {
            var clientCredential = new ClientCredential(Api.ApplicationId, secret); // );"_Xqg[Fw7-J3j9D:CacUojLjm2Gc8[RU=");
            var context = new AuthenticationContext(authorityUrl);

            var authResult = context.AcquireTokenAsync(serviceUrl, clientCredential).Result;

            var httpClient = new HttpClient() { BaseAddress = new Uri(serviceUrl), Timeout = new TimeSpan(0, 2, 0) };

            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            //httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue")
            return httpClient;
        }



        /// <summary>
        /// ServiceUrl(ResourceUrl)
        /// </summary>
        /// <param name="serviceUrl">>e.g.) https://tester200317.crm5.dynamics.com</param>
        /// <returns></returns>
        public static Guid GetTenantId(string serviceUrl)
        {
            try
            {
                var tenantId = Guid.Empty;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                AuthenticationParameters ap = AuthenticationParameters.CreateFromUrlAsync(new Uri($"{serviceUrl}/api/data/")).Result;

                var segments = new Uri(ap.Authority).Segments;

                foreach (var segment in new Uri(ap.Authority).Segments)
                {
                    if (Guid.TryParse(segment.Replace("/",""), out tenantId))
                    {
                        break;
                    }
                }

                return tenantId;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        // For ActiveDirectory 3.13.9 lowest : https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/274605/steps-to-retrieve-token-dynamics-crm-365-online-webapi
        // (https://stackoverflow.com/questions/53502733/powerbi-aadsts90002-tenant-authorize-not-found)
        /// <summary>
        /// </summary>
        /// <param name="apiUrl">e.g.) https://tester200317.api.crm5.dynamics.com/api/data/</param>
        /// <returns></returns>
        public static async Task<string> GetToken(string apiUrl)
        {
            Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext authContext = null;
            try
            {
                // Get the Resource Url & Authority Url using the Api method. This is the best way to get authority URL
                // for any Azure service api.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                AuthenticationParameters ap = AuthenticationParameters.CreateFromUrlAsync(new Uri(apiUrl)).Result;

                string resourceUrl = ap.Resource;
                string authorityUrl =  DiscoverAuthority(ap.Resource);//$"https://login.microsoftonline.com/{GetTenantId(resourceUrl)}";

                //Generate the Authority context .. For the sake of simplicity for the post, I haven't splitted these
                // in to multiple methods. Ideally, you would want to use some sort of design pattern to generate the context and store
                // till the end of the program.
                authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authorityUrl, false);

                try
                {
                    //Check if we can get the authentication token w/o prompting for credentials.
                    //With this system will try to get the token from the cache if there is any, if it is not there then will throw error
                    var authToken = await authContext.AcquireTokenAsync(resourceUrl, Api.ApplicationId, new Uri("ms-console-app://consoleapp"), new PlatformParameters(PromptBehavior.Never));
                    return authToken.AccessToken;
                }
                catch (AdalException e)
                {

                    if (e.ErrorCode == "user_interaction_required")
                    {
                        // We are here means, there is no cached token, So get it from the service.
                        // You should see a prompt for User Id & Password at this place.
                        var authToken = await authContext.AcquireTokenAsync(resourceUrl, Api.ApplicationId, new Uri("ms-console-app://consoleapp"), new PlatformParameters(PromptBehavior.Auto));
                        return authToken.AccessToken;
                    }
                    else
                    {
                        throw;
                    }
                }

                Console.WriteLine("Got the authentication token, Getting data from Webapi !!");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some thing unexpected happened here, Please see the exception details : {ex.ToString()}");
            }

            return null;
        }
        public static string DiscoverAuthority(string serviceUrl)
        {
            try
            {
                //Require Microsoft.IdentityModel.Clients.ActiveDirectory.dll
                AuthenticationParameters ap = AuthenticationParameters.CreateFromUrlAsync(
                    new Uri(serviceUrl + "/api/data/")).Result;
                var authority = new Uri(ap.Authority);

                return $"{authority.Scheme}://{authority.Host}:{authority.Port}/{authority.Segments[1]}";
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
        /// Applies To: Dynamics 365 (online), Dynamics 365 (on-premises), Dynamics CRM 2016, Dynamics CRM Online
        /// Calculates the value of a rollup attribute.
        /// </summary>
        /// <see cref="https://community.dynamics.com/365/b/leichtbewoelkt/posts/calculaterollupfield-with-webapi-function-in-javascript"/>
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt718083%28v%3dcrm.8%29"/>
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

        /// <summary>
        /// Applies To: Dynamics 365 (online), Dynamics 365 (on-premises), Dynamics CRM 2016, Dynamics CRM Online
        /// Detects and retrieves duplicates for a specified record.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt683537%28v%3dcrm.8%29"/>
        /// <param name="httpClient"></param>
        /// <param name="businessEntity"></param>
        /// <param name="matchingEntityName"></param>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        public static async Task<bool> RetrieveDuplicates(HttpClient httpClient, Entity businessEntity, PagingInfo pagingInfo)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response =
                    await httpClient.GetAsync($@"api/data/v9.0/RetrieveDuplicates(BusinessEntity=@p1,MatchingEntityName=@p2,PagingInfo=@p3)?@p2='{businessEntity.LogicalName}'&@p1={{'@odata.id':'{Api.EntitySetPaths[businessEntity.LogicalName]}({businessEntity.Id})'}}&@p3={{'PageNumber':{pagingInfo.PageNumber},'Count':{pagingInfo.Count}}}", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new Exception(
                        //    $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }
                    
                    var jObj = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());
                    jObj.Add("ODataContext", jObj["@odata.context"]);
                    jObj.Remove("@odata.context");
                    var parsed = jObj.ToObject<JObjectParsed>();

                    if (parsed.Error != null)
                    {
                        throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}", parsed.Error.InnerError);
                    }
                    //{"@odata.context":"https://test201018.crm5.dynamics.com/api/data/v9.0/$metadata#opportunities","value":[]}
                    return false;
                    //return whoAmI.ToObject<WhoAmI>();
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
        /// <see cref=""/>
        /// <see cref="http://butenko.pro/2018/07/11/how-to-call-queryschedule-using-webapi/"/>
        /// <param name="httpClient"></param>
        /// <param name="userId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="TimeCodes"></param>
        /// <returns></returns>
        //public static async Task<string> QuerySchedule(HttpClient httpClient, Guid userId, DateTime startDate, DateTime endDate, string TimeCodes)
        //{
        //    return null;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <see cref="http://butenko.pro/2017/06/09/how-to-get-object-type-code-of-entity-using-webapi/"/>
        /// <param name="httpClient"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static async Task<int> GetObjectTypeCode(HttpClient httpClient, string entityLogicalName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response = await httpClient.GetAsync($@"api/data/v9.0/EntityDefinitions?$filter=LogicalName eq '{entityLogicalName}'&$select=ObjectTypeCode", HttpCompletionOption.ResponseContentRead))
                {
                    //오류 페이지 내용을 가져오므로 정말 안될 때 쓰여야한다
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    throw new Exception(
                    //        $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //}

                    var jObj = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());
                    jObj.Add("ODataContext", jObj["@odata.context"]);
                    jObj.Remove("@odata.context");
                    var parsed = jObj.ToObject<JObjectParsed>();

                    if (parsed.Error != null)
                    {
                        throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}",parsed.Error.InnerError);
                    }
                    return parsed.value.First.ObjectTypeCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://crmtipoftheday.com/757/passing-enumerated-values-to-web-api/"/>
        /// <param name="httpClient"></param>
        /// <param name="accessType"></param>
        /// <returns></returns>
        public static async Task<Microsoft.Xrm.Sdk.Organization.OrganizationDetail> GetCurrentOrganization(HttpClient httpClient,Microsoft.Xrm.Sdk.Organization.EndpointAccessType accessType)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response = await httpClient.GetAsync($@"api/data/v9.0/RetrieveCurrentOrganization(AccessType=Microsoft.Dynamics.CRM.EndpointAccessType'{accessType}')", HttpCompletionOption.ResponseContentRead))
                {
                    //오류 페이지 내용을 가져오므로 정말 안될 때 쓰여야한다
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    throw new Exception(
                    //        $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //}R

                    var jObj = JsonConvert.DeserializeObject<JObject>(await
                        response.Content.ReadAsStringAsync());
                    jObj.Add("ODataContext", jObj["@odata.context"]);
                    jObj.Remove("@odata.context");
                    //jObj.Add("value",jObj["Detail"]);
                    var parsed = jObj.ToObject<JObjectParsed>();

                    if (parsed.Error != null)
                    {
                        throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}", parsed.Error.InnerError);
                    }

                    //Count 부분 때문에 오브젝트로 변경이 안됨.
                    var dd = jObj["Detail"] as JObject;

                    #region EndPoints
                    var obj = dd["Endpoints"] as JObject;
                    var count = dd["Endpoints"]["Count"] as JValue;
                    var keys = dd["Endpoints"]["Keys"] as JArray;
                    var values = dd["Endpoints"]["Values"] as JArray;
                    //var end = dd["Endpoints"].ToObject<Microsoft.Xrm.Sdk.Organization.EndpointCollection>();
                    var endpoints = new Microsoft.Xrm.Sdk.Organization.EndpointCollection();
                    for (var i = 0; i < (long)count.Value; ++i)
                    {
                        var key = keys[i] as JValue;
                        var value = values[i] as JValue;
                        EndpointType endpointType;
                        EndpointType.TryParse(key.Value.ToString(), out endpointType);
                        endpoints.Add(endpointType, value.Value.ToString());
                    }

                    dd.Property("Endpoints").Remove(); 
                    #endregion
                    var dddd = dd.ToObject<Microsoft.Xrm.Sdk.Organization.OrganizationDetail>();
                    dddd.Endpoints.AddRange(endpoints);
                    return dddd;
                    //return parsed.value.First.ObjectTypeCode;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/39001154"/>
        /// <param name="httpClient"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static async Task<string> RetrieveSystemViews(HttpClient httpClient, string entityLogicalName)
        {
            try
            {
                //var entityLogicalNameSetPath = EntitySetPaths.Where(x => x.Key == entityLogicalName).Select(x => x.Value).FirstOrDefault();
                //if (string.IsNullOrWhiteSpace(entityLogicalNameSetPath))
                //{
                //    throw new ArgumentOutOfRangeException($"Can not find entity Set Path from {entityLogicalName}");
                //}
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//?$select=name,accountnumber
                using (var response = await httpClient.GetAsync($"api/data/v9.0/savedqueries?$filter=returnedtypecode eq '{entityLogicalName}'", HttpCompletionOption.ResponseContentRead))
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
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static async Task<string> RetrieveUserViews(HttpClient httpClient, string entityLogicalName, bool isAll = false)
        {
            try
            {
                //var entityLogicalNameSetPath = EntitySetPaths.Where(x => x.Key == entityLogicalName).Select(x => x.Value).FirstOrDefault();
                //if (string.IsNullOrWhiteSpace(entityLogicalNameSetPath))
                //{
                //    throw new ArgumentOutOfRangeException($"Can not find entity Set Path from {entityLogicalName}");
                //}
                //https://yourorg.crm.dynamics.com/api/data/v9.1/userqueries?$filter=returnedtypecode%20eq%20%272%27%20and%20layoutxml%20ne%20null
                var isAllString = isAll ? string.Empty : " and layoutxml ne null";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//?$select=name,accountnumber
                using (var response = await httpClient.GetAsync($"api/data/v9.0/userqueries?$filter=returnedtypecode eq '{entityLogicalName}'" + isAllString, HttpCompletionOption.ResponseContentRead))
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ErrorCheck(ApiException error)
        {
            if (error.InnerError.Type == "Microsoft.OData.ODataException")
            {
                //throw new Microsoft.OData.ODataException();
            }
        }
    }

    
    public class ODataResponse<T>

    {

        public T[] Value { get; set; }

    }
}
//http://butenko.pro/webapi-examples-index/

//create 부분사용 
//https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/webapi/web-api-samples-csharp