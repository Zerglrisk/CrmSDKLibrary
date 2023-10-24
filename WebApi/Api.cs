using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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

	public partial class Api
	{
		//https://stackoverflow.com/questions/50795500/authenticate-to-dynamics-365-using-adal-v3-using-clientid/51305491

		private static Dictionary<string, string> _entitySetPaths;

		public static Dictionary<string, string> EntitySetPaths
		{
			get => _entitySetPaths;
			private set => _entitySetPaths = value; //_entitySetPaths ?? (_entitySetPaths = Api.GetAllEntitySetName(new HttpClient()).Result);
		}

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

		#region ADAL 3.19.8 or 5.3.0

#if ADAL_5_3_0 || ADAL_3_19_8

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
		/// If you are connecting using an secret configured for the application,
		/// you will use the ClientCredential class passing in the clientId and clientSecret rather than a UserCredential with userName and password parameters.
		/// </summary>
		/// <see cref="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/authenticate-oauth#connect-using-the-application-secret"/>
		/// <param name="resourceUrl">e.g.) https://tester200315.crm5.dynamics.com</param>
		/// <param name="secret">If your app is a public client, then the client_secret cannot be included</param>
		/// <param name="authorityUrl">e.g.) https://login.microsoftonline.com/tenantId, https://graph.windows.net/</param>
		/// <returns></returns>
		public static async Task<string> GetTenantId(string resourceUrl, string secret, string authorityUrl = "https://login.microsoftonline.com/common")
		{
			//"https://login.microsoftonline.com/<Tenant-ID-here>"
			var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authorityUrl);
			ClientCredential credential = new ClientCredential(ClientId, secret);

			AuthenticationResult result = await authContext.AcquireTokenAsync(resourceUrl, credential);

			return result.TenantId;
		}

#endif

		#endregion ADAL 3.19.8 or 5.3.0

		//}

		#region Only ADAL 5.1.0 ~ 5.3.0

#if ADAL_5_3_0

		/// <summary>
		/// resourceUrl(ResourceUrl)
		/// require Microsoft.IdentityModel.Clients.ActiveDirectory 5.3.0
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

				//using Microsoft.Identity.Client
				//var app = ConfidentialClientApplicationBuilder.Create(clientId)
				//         .WithClientSecret(clientSecret)
				//         .WithAuthority(new Uri(authority))
				//         .Build();

				//var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

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

#else

		// 다른 버전의 라이브러리를 사용하는 경우에 실행할 코드를 여기에 작성하세요.
#endif

		#endregion Only ADAL 5.1.0 ~ 5.3.0

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
		public static async Task<JObjectParsed> RetrieveDuplicates(HttpClient httpClient, string entityLogicalName, string entityRecordId, int pageNumber = 1, int pageCount = 20)
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
			return await Task.FromResult<string>(null);
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