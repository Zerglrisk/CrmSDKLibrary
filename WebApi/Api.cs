using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApi_ADAL.Definition.Model;

namespace WebApi_ADAL
{
    //azrue active directory에 app 등록 방법
    //https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/walkthrough-register-app-azure-active-directory

    //https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
    //https://digitalflow.github.io/Xrm-WebApi-Client/WebApiClient.Requests.js.html

    //POSTman
    //https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/webapi/setup-postman-environment?view=dynamics-ce-odata-9
    //http://techcommunity.softwareag.com/pwiki/-/wiki/Main/Register%20Dynamics%20CRM%20App%20with%20Azure%20for%20OAuth%202.0%20Authentication

    //httpclient
    // https://github.com/anilvem1/CrmWebApiOAuth

    public class Api
    {
        //https://stackoverflow.com/questions/50795500/authenticate-to-dynamics-365-using-adal-v3-using-clientid/51305491

        private static Dictionary<string, string> _entitySetPaths;

        public static Dictionary<string, string> EntitySetPaths
        {
            get => _entitySetPaths;
            private set => _entitySetPaths = value; //_entitySetPaths ?? (_entitySetPaths = Api.GetAllEntitySetName(new HttpClient()).Result);
        }

        /// <summary>
        /// Authenticate to Microsoft Dynamics 365 with the Web API
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt595798(v=crm.8)"/>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="apiUrl">e.g.) https://tester200317.api.crm5.dynamics.com/api/data/v9.0/</param>
        /// <returns></returns>
        //public static HttpClient GetNewHttpClient(string userName, string password, string domainName, string apiUrl)
        //{
        //    return GetNewHttpClient(new NetworkCredential(userName, password, domainName), apiUrl);
        //}

        //public static HttpClient GetNewHttpClient(NetworkCredential credential, string apiUrl)
        //{
        //    var client = new HttpClient(new HttpClientHandler() { Credentials = credential })
        //    {
        //        BaseAddress = new Uri(apiUrl),
        //        Timeout = new TimeSpan(0, 2, 0)
        //    };
        //    return client;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://carldesouza.com/dynamics-365-webapi-and-c-configuring-sample-code/"/>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domainName"></param>
        /// <param name="resourceUrl"></param>
        /// <returns></returns>
        //public static HttpClient GetCrmApiHttpClient(string userName, string password, string domainName, string resourceUrl)
        //{
        //    Api api = new Api();
        //    HttpClient httpClient;
        //    var Authority = DiscoverAuthority(resourceUrl);
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
        //    httpClient.BaseAddress = new Uri(resourceUrl + "api/data/v8.1/");
        //    httpClient.Timeout = new TimeSpan(0, 2, 0);
        //    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    return httpClient;
        //}


        private static string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Set Azure App Id(Client ID)
        /// The application ID that's assigned to your app
        /// </summary>
        /// <param name="clientId"></param>
        public static void SetClientId(string clientId)
        {
            ClientId = clientId;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="password"></param>
        ///// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        ///// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId</param>
        ///// <returns></returns>
        //public static Task<HttpClient> GetWebApiHttpClient(string userName, string password, string resourceUrl,
        //    string authorityUrl = "https://login.microsoftonline.com/common")
        //{
        //    return GetWebApiHttpClient(UserPasswordCredential(userName, password), resourceUrl, authorityUrl);
        //}
        ///// <summary>
        ///// UserPasswordCredential Not support in net core or net standard
        ///// </summary>
        ///// <see href="https://rajeevpentyala.com/2018/09/18/code-snippet-authenticate-and-perform-operations-using-d365-web-api-and-c/"/>
        ///// <see href="https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/305276/crud-operations-using-web-api-in-console-app?pifragment-97030=1#responses"/>
        ///// <param name="credential"></param>
        ///// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        ///// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId</param>
        ///// <returns></returns>
        //public static async Task<HttpClient> GetWebApiHttpClient(UserPasswordCredential credential, string resourceUrl, string authorityUrl = "https://login.microsoftonline.com/common")
        //{
        //    //var credentials = new UserPasswordCredential(userName, password);
        //    var context = new AuthenticationContext(authorityUrl);
        //    var authResult = await context.AcquireTokenAsync(resourceUrl, Api.ClientId, credential);

        //    var httpClient = new HttpClient() { BaseAddress = new Uri(resourceUrl), Timeout = new TimeSpan(0, 2, 0) };

        //    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authResult.AccessTokenType, authResult.AccessToken);
        //    //httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue")
        //    return httpClient;
        //}


        /// <summary>
        /// client credential need application user
        /// if dont have application user, when try call others(e.g.)whoami) will return 403(forbidden) error)
        /// </summary>
        /// <see cref="https://community.dynamics.com/crm/b/magnetismsolutionscrmblog/posts/dynamics-365-online-authenticate-with-client-credentials"/>
        /// <see cref="https://www.c-sharpcorner.com/article/generate-access-token-for-dynamics-365-single-tenant-server-to-server-authentica/"/>
        /// <param name="secret"></param>
        /// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        /// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId</param>
        /// <returns></returns>
        public static async Task<HttpClient> GetWebApiHttpClientSecret(string secret, string resourceUrl, string authorityUrl = "https://login.microsoftonline.com/common")
        {
            var clientCredential = new ClientCredential(ClientId, secret); // );"_Xqg[Fw7-J3j9D:CacUojLjm2Gc8[RU=");
            var context = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authorityUrl);

            var authResult = await context.AcquireTokenAsync(resourceUrl, clientCredential);

            var httpClient = new HttpClient() { BaseAddress = new Uri(resourceUrl), Timeout = new TimeSpan(0, 2, 0) };

            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authResult.AccessTokenType, authResult.AccessToken);
            //httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue")

            //After work
            _entitySetPaths = _entitySetPaths ?? (_entitySetPaths = GetAllEntitySetName(httpClient).Result);
            return httpClient;
        }

        ///// <summary>
        ///// https://stackoverflow.com/a/56449292
        ///// </summary>
        ///// <param name="clientId"></param>
        ///// <param name="tenantId"></param>
        ///// <param name="id"></param>
        ///// <param name="pw"></param>
        ///// <returns></returns>
        //public static async Task<HttpClient> GetMSAL(string clientId, string tenantId, string id, string pw)
        //{
        //    IPublicClientApplication app = null;
        //    if(app == null)
        //    {
        //        app = PublicClientApplicationBuilder.CreateWithApplicationOptions(new PublicClientApplicationOptions()
        //        {
        //            ClientId = clientId,
        //            TenantId = tenantId,
        //            AzureCloudInstance = AzureCloudInstance.AzurePublic
        //        }).Build();

        //        var scopes = new List<string>() { "https://graph.microsoft.com/.default" };
        //        // As I wanted to log in using username and password, I have to use this:
        //        //var token = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

        //        // if I want to log in using code, I can also use this:
        //        var token = await app.AcquireTokenByUsernamePassword(scopes, id, pw).ExecuteAsync();

        //        HttpClient httpClient = new HttpClient();
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
        //    }
        //    return null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth-ropc"/>
        /// <see cref="https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/193506/crm-online-web-api-error-401-unauthorized-access-is-denied"/>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        /// <param name="secret">If your app is a public client, then the client_secret cannot be included</param>
        /// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId, https://graph.windows.net/</param>
        /// <returns></returns>
        public static async Task<HttpClient> GetWebApiHttpClient(string username, string password, string resourceUrl,
            string authorityUrl = "https://login.microsoftonline.com/common", string secret = "")
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(resourceUrl),
                Timeout = new TimeSpan(0, 5, 0)
            };

            // FormUrlEncodedContent class Encode form data in utf8 encoding
            // A container for name/value tuples encoded using application/x-www-form-urlencoded MIME type.
            HttpContent content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("resource", resourceUrl),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                ///new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                new KeyValuePair<string, string>("client_secret", secret),
                new KeyValuePair<string, string>("grant_type", "password")
            });
            //= new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            //content type is application/json
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            using (HttpResponseMessage response = await httpClient.PostAsync($"{authorityUrl}/oauth2/token", content))
            {
                //error : possible 400 error if set grant_type password when you have not permmision or wrong password etc that response always return 400, bad_request, idk why
                if (response.IsSuccessStatusCode)
                {
                    // must came in utf8json as stream
                    var responsebody = await response.Content.ReadAsStreamAsync();
                    
                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.Token>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    #region [System.Net.Http.Json]

                    //var responsebody = await response.Content.ReadAsStringAsync();

                    #region Using JsonElement (Dynamic)

                    //var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                    //if (!result.TryGetProperty("access_token", out var accessToken))
                    //{
                    //    throw new Exception(
                    //   $"Message: \"cannot found access_token property.\", StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //}
                    //if (!result.TryGetProperty("token_type", out var accessTokenType))
                    //{
                    //    throw new Exception(
                    //   $"Message: \"cannot found token_type property.\", StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //} 

                    // ...
                    // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessTokenType.GetString(), accessToken.GetString());

                    #endregion

                    //var result = await response.Content.ReadFromJsonAsync<WebApi_ADAL.Definition.Model.Token>(); 

                    // ...
                    // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

                    #endregion

                    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

                    //After work
                    _entitySetPaths = _entitySetPaths ?? (_entitySetPaths = GetAllEntitySetName(httpClient).Result);
                }
                else
                {
                    throw new Exception(
                        $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                }
            }


            return httpClient;
        }

        /// <summary>
        /// client credential need application user
        /// if dont have application user, in ropc response is 200 but when try call others(e.g.)whoami) will return 403(forbidden) error)
        /// </summary>
        /// <see cref="https://community.dynamics.com/crm/b/magnetismsolutionscrmblog/posts/dynamics-365-online-authenticate-with-client-credentials"/>
        /// <see cref="https://www.c-sharpcorner.com/article/generate-access-token-for-dynamics-365-single-tenant-server-to-server-authentica/"/>
        /// <param name="resourceUrl"></param>
        /// <param name="authorityUrl"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static async Task<HttpClient> GetWebApiHttpClient2(string resourceUrl,
            string authorityUrl = "https://login.microsoftonline.com/common", string secret = "")
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(resourceUrl),
                Timeout = new TimeSpan(0, 5, 0)
            };
            HttpContent content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("resource", resourceUrl),
                //new KeyValuePair<string, string>("scope", "openid offline_access admin.services.crm.dynamics.com/user_impersonation"), //"https://graph.microsoft.com/.default"),
                new KeyValuePair<string, string>("client_secret", secret),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });
            //content type is application/json
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            using (HttpResponseMessage response = await httpClient.PostAsync($"{authorityUrl}/oauth2/token", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    // must came in utf8json as stream
                    var responsebody = await response.Content.ReadAsStreamAsync();

                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.Token>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    #region [System.Net.Http.Json]

                    //var responsebody = await response.Content.ReadAsStringAsync();

                    #region Using JsonElement (Dynamic)

                    //var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                    //if (!result.TryGetProperty("access_token", out var accessToken))
                    //{
                    //    throw new Exception(
                    //   $"Message: \"cannot found access_token property.\", StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //}
                    //if (!result.TryGetProperty("token_type", out var accessTokenType))
                    //{
                    //    throw new Exception(
                    //   $"Message: \"cannot found token_type property.\", StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    //} 

                    // ...
                    // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessTokenType.GetString(), accessToken.GetString());

                    #endregion

                    //var result = await response.Content.ReadFromJsonAsync<WebApi_ADAL.Definition.Model.Token>(); 

                    // ...
                    // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

                    #endregion

                    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

                    //After work
                    _entitySetPaths = _entitySetPaths ?? (_entitySetPaths = GetAllEntitySetName(httpClient).Result);
                }
                else
                {
                    throw new Exception(
                        $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                }
            }


            return httpClient;
        }

        //public static async Task<HttpClient> GetGraphHttpClient(string username, string password)
        //{
        //    var httpClient = new HttpClient()
        //    {
        //        BaseAddress = new Uri("https://graph.windows.net/"),
        //        Timeout = new TimeSpan(0, 0, 15)
        //    };
        //    var content = new FormUrlEncodedContent(new[]{
        //        new KeyValuePair<string, string>("client_id", Api.ClientId),
        //        new KeyValuePair<string, string>("resource", "https://graph.windows.net/"),
        //        new KeyValuePair<string, string>("username", username),
        //        new KeyValuePair<string, string>("password", password),
        //        new KeyValuePair<string, string>("grant_type", "password")
        //    });
        //    //content type is application/json
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var tokenEndpoint = $"https://login.windows.net/1fd4863a-b5bc-42b2-9617-56a7d222fad7/oauth2/token";
        //        var accept = "application/json";

        //        client.DefaultRequestHeaders.Add("Accept", accept);
        //        string postBody = $"resource=https://graph.windows.net/&client_id={Api.ClientId}&grant_type=password&username={username}&password={password}";
        //        using (HttpResponseMessage response = await client.PostAsync(tokenEndpoint, new StringContent(postBody, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded")))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var jsonresult = JObject.Parse(await response.Content.ReadAsStringAsync());
        //                var token = (string)jsonresult["access_token"];
        //            }
        //        }
        //    }

        //    return httpClient;
        //}

        /// <summary>
        /// If you are connecting using an secret configured for the application, 
        /// you will use the ClientCredential class passing in the clientId and clientSecret rather than a UserCredential with userName and password parameters.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/authenticate-oauth#connect-using-the-application-secret"/>
        /// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        /// <param name="secret">If your app is a public client, then the client_secret cannot be included</param>
        /// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId, https://graph.windows.net/</param>
        /// <returns></returns>
        public static async Task<string> GetAccessTokenToken(string resourceUrl, string secret, string authorityUrl = "https://login.microsoftonline.com/common")
        {
            //"https://login.microsoftonline.com/<Tenant-ID-here>"
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authorityUrl);
            ClientCredential credential = new ClientCredential(ClientId, secret);

            AuthenticationResult result = await authContext.AcquireTokenAsync(resourceUrl, credential);

            return result.AccessToken;
        }

        /// <summary>
        /// resourceUrl(ResourceUrl)
        /// </summary>
        /// <param name="resourceUrl">>e.g.) https://tester200317.crm5.dynamics.com</param>
        /// <returns></returns>
        public static Guid GetTenantId(string resourceUrl)
        {
            try
            {
                var tenantId = Guid.Empty;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                AuthenticationParameters ap = AuthenticationParameters.CreateFromUrlAsync(new Uri($"{resourceUrl}/api/data/")).Result;

                var segments = new Uri(ap.Authority).Segments;

                foreach (var segment in new Uri(ap.Authority).Segments)
                {
                    if (Guid.TryParse(segment.Replace("/", ""), out tenantId))
                    {
                        break;
                    }
                }

                return tenantId;
            }
            catch (Exception)
            {
                throw;
            }

        }
        // For ActiveDirectory 3.13.9 lowest : https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/274605/steps-to-retrieve-token-dynamics-crm-365-online-webapi
        // (https://stackoverflow.com/questions/53502733/powerbi-aadsts90002-tenant-authorize-not-found)
        // cutomwebui : http://thewindowsupdate.com/2019/04/14/how-to-use-active-directory-authentication-library-adal-for-net-on-net-core-3-0-wpf-apps/
        // PlatformParameters : https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/wiki/Acquiring-tokens-interactively---Public-client-application-flows
        //https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-desktop-acquire-token?tabs=dotnet
        // customwebui e.g. : https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/blob/053a98d16596be7e9ca1ab916924e5736e341fe8/tests/Microsoft.Identity.Test.Integration/Infrastructure/SeleniumWebUI.cs#L15-L160
        /// <summary>
        /// </summary>
        /// <param name="apiUrl">e.g.) https://tester200317.api.crm5.dynamics.com/api/data/</param>
        /// <param name="customWebUi">cannot be null</param>
        /// <returns></returns>
        //public static async Task<string> GetToken(string apiUrl, Microsoft.IdentityModel.Clients.ActiveDirectory.Extensibility.ICustomWebUi customWebUi)
        //{
        //    Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext authContext = null;
        //    try
        //    {
        //        // Get the Resource Url & Authority Url using the Api method. This is the best way to get authority URL
        //        // for any Azure service api.
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //        var ap = Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationParameters.CreateFromUrlAsync(new Uri(apiUrl)).Result;

        //        string resourceUrl = ap.Resource;
        //        string authorityUrl = DiscoverAuthority(ap.Resource);//$"https://login.microsoftonline.com/{GetTenantId(resourceUrl)}";

        //        //Generate the Authority context .. For the sake of simplicity for the post, I haven't splitted these
        //        // in to multiple methods. Ideally, you would want to use some sort of design pattern to generate the context and store
        //        // till the end of the program.
        //        authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authorityUrl, false);

        //        try
        //        {
        //            //Check if we can get the authentication token w/o prompting for credentials.
        //            //With this system will try to get the token from the cache if there is any, if it is not there then will throw error
        //            var authToken = await authContext.AcquireTokenAsync(resourceUrl, ClientId, new Uri("ms-console-app://consoleapp"), new PlatformParameters(PromptBehavior.Never, customWebUi));
        //            return authToken.AccessToken;
        //        }
        //        catch (AdalException e)
        //        {

        //            if (e.ErrorCode == "user_interaction_required")
        //            {
        //                // We are here means, there is no cached token, So get it from the service.
        //                // You should see a prompt for User Id & Password at this place.
        //                var authToken = await authContext.AcquireTokenAsync(resourceUrl, ClientId, new Uri("ms-console-app://consoleapp"), new PlatformParameters(PromptBehavior.Auto, customWebUi));
        //                return authToken.AccessToken;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        Console.WriteLine("Got the authentication token, Getting data from Webapi !!");


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Some thing unexpected happened here, Please see the exception details : {ex.ToString()}");
        //    }

        //    return null;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
        /// <returns></returns>
        public static string DiscoverAuthority(string resourceUrl)
        {
            try
            {
                //Require Microsoft.IdentityModel.Clients.ActiveDirectory.dll
                AuthenticationParameters ap = AuthenticationParameters.CreateFromUrlAsync(
                    new Uri(resourceUrl + "/api/data/")).Result;
                var authority = new Uri(ap.Authority);

                return $"{authority.Scheme}://{authority.Host}:{authority.Port}/{authority.Segments[1]}";
            }
            catch (HttpRequestException e)
            {
                throw new Exception("An HTTP request exception occurred during authority discovery.", e);
            }
            catch (Exception e)
            {
                // This exception ocurrs when the service is not configured for OAuth.
                if (e.HResult == -2146233088)
                {
                    return string.Empty;
                }
                else
                {
                    throw e;
                }
            }
        }

        public static async Task<Dictionary<string, string>> GetAllEntitySetName(HttpClient httpClient)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response =
                    await httpClient.GetAsync("api/data/v9.0/EntityDefinitions?$select=LogicalName,EntitySetName", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    //var jObject = JsonSerializer.Deserialize<JsonDocument>(await
                    //    response.Content.ReadAsStringAsync(), new JsonSerializerOptions() { WriteIndented = true });
                    //var stream = new MemoryStream();
                    //var writer = new Utf8JsonWriter(stream);
                    //jObject.RootElement.WriteTo(writer);
                    ////https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/
                    ////https://docs.microsoft.com/ko-kr/dotnet/standard/serialization/system-text-json-how-to
                    ////https://github.com/dotnet/runtime/tree/master/src/libraries/System.Text.Json
                    //writer.WriteStartObject();

                    // must came in utf8json as stream
                    var responsebody = await response.Content.ReadAsStreamAsync();

                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.EntityDefinitions>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return result.Values.ToDictionary(k => k.LogicalName, v => v.EntitySetName);
                    //var jObject = JsonConvert.DeserializeObject<JObject>(await
                    //    response.Content.ReadAsStringAsync());
                    //jObject.Add("ODataContext", jObject["@odata.context"]);
                    //jObject.Remove("@odata.context");
                    //var entityMetadatas = jObject["value"] as JArray;

                    //return entityMetadatas.Children<JObject>().ToDictionary(
                    //    x => x.Property("LogicalName").Value.ToString(),
                    //    x => x.Property("EntitySetName").Value.ToString());
                    //delegate (EntityMetadata metadata) { return metadata.LogicalName; },
                    //delegate (EntityMetadata metadata) { return metadata.EntitySetName; });
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

                    // must came in utf8json as stream
                    var responsebody = await response.Content.ReadAsStreamAsync();

                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.WhoAmI>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return result;
                }
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

                    var responsebody = await response.Content.ReadAsStringAsync();

                    return responsebody;
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
        /// <param name="entityLogicalName"></param>
        /// <param name="entityRecordId"></param>
        /// <param name="attributeName">The logical name of the attribute to calculate.</param>
        /// <returns></returns>
        public static async Task<CalculateRollupFieldResponse> CalculateRollupField(HttpClient httpClient, string entityLogicalName, string entityRecordId, string attributeName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (var response =
                    await httpClient.GetAsync($@"api/data/v8.0/CalculateRollupField(Target=@tid,FieldName=@fname)?@tid={{'@odata.id':'{EntitySetPaths[entityLogicalName]}({entityRecordId})'}}&@fname='{attributeName}'", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new Exception($"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                        //var aa = whoAmI.ToObject<ApiExceptionWrapper>(); //에러
                    }

                    var responsebody = await response.Content.ReadAsStringAsync();
                    responsebody = responsebody.Replace($"\"{attributeName}", "\"attribute");
                    responsebody = responsebody.Replace($"\"{entityLogicalName}id", "\"recordid");
                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.CalculateRollupFieldResponse>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                    result.AttributeName = attributeName;
                    return result;
                    //var whoAmI = JsonConvert.DeserializeObject<JObject>(await
                    //    response.Content.ReadAsStringAsync());

                    //return whoAmI.ToObject<string>();
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
        /// <param name="entityLogicalName"></param>
        /// <param name="entityRecordId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<JObjectParsed> RetrieveDuplicates(HttpClient httpClient, string entityLogicalName, string entityRecordId, int pageNumber = 1, int pageCount= 20)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response =
                    await httpClient.GetAsync($@"api/data/v9.0/RetrieveDuplicates(BusinessEntity=@p1,MatchingEntityName=@p2,PagingInfo=@p3)?@p2='{entityLogicalName}'&@p1={{'@odata.id':'{EntitySetPaths[entityLogicalName]}({entityRecordId})'}}&@p3={{'PageNumber':{pageNumber},'Count':{pageCount}}}", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new Exception(
                        //    $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    var responsebody = await response.Content.ReadAsStreamAsync();
                    var jObj = JsonSerializer.Deserialize<JObjectParsed>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    //if (parsed.Error != null)
                    //{
                    //    throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}", parsed.Error.InnerError);
                    //}

                    //{"@odata.context":"https://test201018.crm5.dynamics.com/api/data/v9.0/$metadata#opportunities","value":[]}
                    return jObj;
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
        /// <see cref = "" />
        /// < see cref="http://butenko.pro/2018/07/11/how-to-call-queryschedule-using-webapi/"/>
        /// <param name = "httpClient" ></ param >
        /// < param name="userId"></param>
        /// <param name = "startDate" ></ param >
        /// < param name="endDate"></param>
        /// <param name = "TimeCodes" ></ param >
        /// < returns ></ returns >
        public static async Task<string> QuerySchedule(HttpClient httpClient, Guid userId, DateTime startDate, DateTime endDate, string TimeCodes)
        {
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <see cref="http://butenko.pro/2017/06/09/how-to-get-object-type-code-of-entity-using-webapi/"/>
        /// <param name="httpClient"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static async Task<int?> GetObjectTypeCode(HttpClient httpClient, string entityLogicalName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response = await httpClient.GetAsync($@"api/data/v9.0/EntityDefinitions?$filter=LogicalName eq '{entityLogicalName}'&$select=ObjectTypeCode", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    var responsebody = await response.Content.ReadAsStreamAsync();

                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.EntityDefinitions>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return result.Values.FirstOrDefault().ObjectTypeCode;

                    //var jObj = JsonConvert.DeserializeObject<JObject>(await
                    //    response.Content.ReadAsStringAsync());
                    //jObj.Add("ODataContext", jObj["@odata.context"]);
                    //jObj.Remove("@odata.context");
                    //var parsed = jObj.ToObject<JObjectParsed>();

                    //if (parsed.Error != null)
                    //{
                    //    throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}", parsed.Error.InnerError);
                    //}
                    //return parsed.value.First.ObjectTypeCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <see cref="https://crmtipoftheday.com/757/passing-enumerated-values-to-web-api/"/>
        ///// <param name="httpClient"></param>
        ///// <param name="accessType"></param>
        ///// <returns></returns>
        //public static async Task<Microsoft.Xrm.Sdk.Organization.OrganizationDetail> GetCurrentOrganization(HttpClient httpClient, Microsoft.Xrm.Sdk.Organization.EndpointAccessType accessType)
        //{
        //    try
        //    {
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        //        using (var response = await httpClient.GetAsync($@"api/data/v9.0/RetrieveCurrentOrganization(AccessType=Microsoft.Dynamics.CRM.EndpointAccessType'{accessType}')", HttpCompletionOption.ResponseContentRead))
        //        {
        //            //오류 페이지 내용을 가져오므로 정말 안될 때 쓰여야한다
        //            //if (!response.IsSuccessStatusCode)
        //            //{
        //            //    throw new Exception(
        //            //        $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
        //            //}R

        //            var jObj = JsonConvert.DeserializeObject<JObject>(await
        //                response.Content.ReadAsStringAsync());
        //            jObj.Add("ODataContext", jObj["@odata.context"]);
        //            jObj.Remove("@odata.context");
        //            //jObj.Add("value",jObj["Detail"]);
        //            var parsed = jObj.ToObject<JObjectParsed>();

        //            if (parsed.Error != null)
        //            {
        //                throw new Exception($"[{parsed.Error.InnerError.Type}({parsed.Error.Code})] {parsed.Error.Message}", parsed.Error.InnerError);
        //            }

        //            //Count 부분 때문에 오브젝트로 변경이 안됨.
        //            var dd = jObj["Detail"] as JObject;

        //            #region EndPoints
        //            var obj = dd["Endpoints"] as JObject;
        //            var count = dd["Endpoints"]["Count"] as JValue;
        //            var keys = dd["Endpoints"]["Keys"] as JArray;
        //            var values = dd["Endpoints"]["Values"] as JArray;
        //            //var end = dd["Endpoints"].ToObject<Microsoft.Xrm.Sdk.Organization.EndpointCollection>();
        //            var endpoints = new Microsoft.Xrm.Sdk.Organization.EndpointCollection();
        //            for (var i = 0; i < (long)count.Value; ++i)
        //            {
        //                var key = keys[i] as JValue;
        //                var value = values[i] as JValue;
        //                Enum.TryParse(key.Value.ToString(), out EndpointType endpointType);
        //                endpoints.Add(endpointType, value.Value.ToString());
        //            }

        //            dd.Property("Endpoints").Remove();
        //            #endregion
        //            var dddd = dd.ToObject<Microsoft.Xrm.Sdk.Organization.OrganizationDetail>();
        //            dddd.Endpoints.AddRange(endpoints);
        //            return dddd;
        //            //return parsed.value.First.ObjectTypeCode;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <see cref="https://stackoverflow.com/a/39001154"/>
        ///// <param name="httpClient"></param>
        ///// <param name="entityLogicalName"></param>
        ///// <returns></returns>
        //public static async Task<string> RetrieveSystemViews(HttpClient httpClient, string entityLogicalName)
        //{
        //    try
        //    {
        //        //var entityLogicalNameSetPath = EntitySetPaths.Where(x => x.Key == entityLogicalName).Select(x => x.Value).FirstOrDefault();
        //        //if (string.IsNullOrWhiteSpace(entityLogicalNameSetPath))
        //        //{
        //        //    throw new ArgumentOutOfRangeException($"Can not find entity Set Path from {entityLogicalName}");
        //        //}
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//?$select=name,accountnumber
        //        using (var response = await httpClient.GetAsync($"api/data/v9.0/savedqueries?$filter=returnedtypecode eq '{entityLogicalName}'", HttpCompletionOption.ResponseContentRead))
        //        {
        //            if (!response.IsSuccessStatusCode)
        //            {
        //                throw new Exception(
        //                    $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
        //            }

        //            var resp = JsonConvert.DeserializeObject<JObject>(await
        //                response.Content.ReadAsStringAsync());

        //            return resp.ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="httpClient"></param>
        ///// <param name="entityLogicalName"></param>
        ///// <returns></returns>
        //public static async Task<string> RetrieveUserViews(HttpClient httpClient, string entityLogicalName, bool isAll = false)
        //{
        //    try
        //    {
        //        //var entityLogicalNameSetPath = EntitySetPaths.Where(x => x.Key == entityLogicalName).Select(x => x.Value).FirstOrDefault();
        //        //if (string.IsNullOrWhiteSpace(entityLogicalNameSetPath))
        //        //{
        //        //    throw new ArgumentOutOfRangeException($"Can not find entity Set Path from {entityLogicalName}");
        //        //}
        //        //https://yourorg.crm.dynamics.com/api/data/v9.1/userqueries?$filter=returnedtypecode%20eq%20%272%27%20and%20layoutxml%20ne%20null
        //        var isAllString = isAll ? string.Empty : " and layoutxml ne null";
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//?$select=name,accountnumber
        //        using (var response = await httpClient.GetAsync($"api/data/v9.0/userqueries?$filter=returnedtypecode eq '{entityLogicalName}'" + isAllString, HttpCompletionOption.ResponseContentRead))
        //        {
        //            if (!response.IsSuccessStatusCode)
        //            {
        //                throw new Exception(
        //                    $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
        //            }

        //            var resp = JsonConvert.DeserializeObject<JObject>(await
        //                response.Content.ReadAsStringAsync());

        //            return resp.ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static async Task<string> FetchXmlToQueryExpression(HttpClient httpClient, string fetchXml)
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;//?$select=name,accountnumber
        //    using (var response = await httpClient.GetAsync($"api/data/v9.0/FetchXmlToQueryExpression(FetchXml=@p1)?@p1='{fetchXml}'", HttpCompletionOption.ResponseContentRead))
        //    {
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception(
        //                $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
        //        }

        //        var resp = JsonConvert.DeserializeObject<JObject>(await
        //            response.Content.ReadAsStringAsync());

        //        return resp.ToString();
        //    }
        //}

        public static async Task<System.IO.Stream> GetImageBlob(HttpClient httpClient, string targetId)
        {
            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response =
                    await httpClient.GetAsync("api/data/v9.0/msdyn_richtextfiles(" + targetId + ")/msdyn_imageblob/$value?size=full", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            "StatusCode : " + response.StatusCode + ", ReasonPhrase : " + response.ReasonPhrase);
                    }

                    //var jObject = JsonSerializer.Deserialize<JsonDocument>(await
                    //    response.Content.ReadAsStringAsync(), new JsonSerializerOptions() { WriteIndented = true });
                    //var stream = new MemoryStream();
                    //var writer = new Utf8JsonWriter(stream);
                    //jObject.RootElement.WriteTo(writer);
                    ////https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/
                    ////https://docs.microsoft.com/ko-kr/dotnet/standard/serialization/system-text-json-how-to
                    ////https://github.com/dotnet/runtime/tree/master/src/libraries/System.Text.Json
                    //writer.WriteStartObject();

                    var jObject = await response.Content.ReadAsByteArrayAsync();
                    System.IO.Stream stream = new System.IO.MemoryStream(jObject);

                    return stream;//jObject;
                    //delegate (EntityMetadata metadata) { return metadata.LogicalName; },
                    //delegate (EntityMetadata metadata) { return metadata.EntitySetName; });
                }

                //First obtain the user's ID.
                //Guid myUserId = (Guid)whoAmIresp["UserId"];

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

        /// <summary>
        /// For Plugins Debuging
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/data-platform/debug-plug-in"/>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static async Task<PluginTraceLogs> GetPluginTraceLogs(HttpClient httpClient, string pluginName = "")
        {
            try
            {
                ////api/data/v9.0/plugintracelogs?$select=messageblock&$filter=typename eq 'BasicPlugin.FollowUpPlugin'
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var response = await httpClient.GetAsync($@"api/data/v9.0/plugintracelogs{(!string.IsNullOrWhiteSpace(pluginName) ? $"?$filter=contains(typename,'{pluginName}')" : "")}", HttpCompletionOption.ResponseContentRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"StatusCode : {response.StatusCode}, ReasonPhrase : {response.ReasonPhrase}");
                    }

                    var responsebody = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<WebApi_ADAL.Definition.Model.PluginTraceLogs>(responsebody, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
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



