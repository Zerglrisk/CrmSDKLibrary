using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApi_ADAL
{
	public partial class Api
	{
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

					#endregion Using JsonElement (Dynamic)

					//var result = await response.Content.ReadFromJsonAsync<WebApi_ADAL.Definition.Model.Token>();

					// ...
					// httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

					#endregion [System.Net.Http.Json]

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

					#endregion Using JsonElement (Dynamic)

					//var result = await response.Content.ReadFromJsonAsync<WebApi_ADAL.Definition.Model.Token>();

					// ...
					// httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.AccessToken);

					#endregion [System.Net.Http.Json]

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
			var clientCredential = new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(ClientId, secret); // );"_Xqg[Fw7-J3j9D:CacUojLjm2Gc8[RU=");
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
	}
}