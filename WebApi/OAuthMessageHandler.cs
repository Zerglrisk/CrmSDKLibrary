using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class OAuthMessageHandler : DelegatingHandler
    {
        private AuthenticationHeaderValue authHeader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl">https://test.crm5.dynamics.com</param>
        /// <param name="clientId"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="innerHandler"></param>
        public OAuthMessageHandler(string serviceUrl, string clientId, string redirectUrl, string username, string password,
                HttpMessageHandler innerHandler)
            : base(innerHandler)
        {

            string apiVersion = "9.2";
            string webApiUrl = $"{serviceUrl}/api/data/v{apiVersion}/";

            //Build Microsoft.Identity.Client (MSAL) OAuth Token Request
            var authBuilder = Microsoft.Identity.Client.PublicClientApplicationBuilder.Create(clientId)
                            .WithAuthority(Microsoft.Identity.Client.AadAuthorityAudience.AzureAdMultipleOrgs)
                            .WithRedirectUri(redirectUrl)
                            .Build();
            var scope = serviceUrl + "//.default";
            string[] scopes = { scope };

            Microsoft.Identity.Client.AuthenticationResult authBuilderResult;
            if (username != string.Empty && password != string.Empty)
            {
                //Make silent Microsoft.Identity.Client (MSAL) OAuth Token Request
                var securePassword = new System.Security.SecureString();
                foreach (char ch in password) securePassword.AppendChar(ch);
                authBuilderResult = authBuilder.AcquireTokenByUsernamePassword(scopes, username, securePassword)
                            .ExecuteAsync().Result;
            }
            else
            {
                //Popup authentication dialog box to get token
                authBuilderResult = authBuilder.AcquireTokenInteractive(scopes)
                            .ExecuteAsync().Result;
            }

            //Note that an Azure AD access token has finite lifetime, default expiration is 60 minutes.
            authHeader = new AuthenticationHeaderValue("Bearer", authBuilderResult.AccessToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(
                    HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Authorization = authHeader;
            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">Url=https://{env-name}.api.crm.dynamics.com;Username={username}@{env-name}.onmicrosoft.com;Password={mypassword};</param>
        /// <param name="clientId"></param>
        /// <param name="redirectUrl">app:{ApplicationId}</param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static HttpClient GetHttpClient(string connectionString, string clientId, string redirectUrl, string version = "v9.2")
        {
            string url = GetParameterValueFromConnectionString(connectionString, "Url");
            string username = GetParameterValueFromConnectionString(connectionString, "Username");
            string password = GetParameterValueFromConnectionString(connectionString, "Password");
            try
            {
                HttpMessageHandler messageHandler = new OAuthMessageHandler(url, clientId, redirectUrl, username, password,
                                new HttpClientHandler());

                HttpClient httpClient = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(string.Format("{0}/api/data/{1}/", url, version)),

                    Timeout = new TimeSpan(0, 2, 0)  //2 minutes
                };

                return httpClient;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetParameterValueFromConnectionString(string connectionString, string parameter)
        {
            try
            {
                return connectionString.Split(';').Where(s => s.Trim().StartsWith(parameter)).FirstOrDefault().Split('=')[1];
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
    }
}
