using System;
using System.ServiceModel;

using Microsoft.Crm.Sdk.Messages;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

using System.Collections.Generic;
using System.Net;
using Microsoft.Xrm.Sdk.Client;
using System.Threading.Tasks;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Rest;

namespace CrmSdkLibrary
{
    public class Connection
    {
        /// <summary>
        /// 한번에 ServiceClient 실행가능 한 횟수 52
        /// </summary>
        public const int ConcurrentConnectionLimit = 52;

        private static System.Collections.Queue queue = new System.Collections.Queue();
        private readonly object queueLock = new object();

        public static CrmServiceClient Service { get; private set; }

        //private static CrmServiceClient crmServiceClient;
        //public static CrmServiceClient CrmServiceClient
        //{
        //    get
        //    {
        //        if (crmServiceClient == null ||
        //            crmServiceClient.ActiveAuthenticationType == AuthenticationType.InvalidConnection)
        //        {
        //            CrmServiceClient = ConnectServiceOAuth();
        //        }
        //        return crmServiceClient;
        //    }
        //    set
        //    {
        //        crmServiceClient = value;
        //    }
        //}

        /// <summary>
        /// Connect using a certificate thumbprint
        /// If you are connecting using a certificate and using the Microsoft.Xrm.Tooling.Connector.CrmServiceClient you can use this
        /// 인증서의 지문을 이용하여 사용한다,
        /// win + r  -> certmgr.msc -> 개인용 -> 인증서 선택 -> 제일 밑의 지문(thumbprint)
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/authenticate-oauth#connect-using-a-certificate-thumbprint"/>
        /// <see href="https://www.crmviking.com/2018/03/dynamics-365-s2s-oauth-authentication.html"/>
        /// <param name="certThumbPrintId">e.g.) DC6C689022C905EA5F812B51F1574ED10F256FF6</param>
        /// <param name="environmentUri">e.g.) https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">  e.g.) 545ce4df-95a6-4115-ac2f-e8e5546e79af</param>
        public static Guid ConnectServiceThumbprint(string certThumbPrintId, string environmentUri, string clientId)
        {
            string ConnectionStr = $@"AuthType=Certificate;
                        SkipDiscovery=true;url={environmentUri};
                        thumbprint={certThumbPrintId};
                        ClientId={clientId};
                        RequireNewInstance=true";

            ////실행 대기시간 default 2분 -> 5분
            //CrmServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);
            CrmServiceClient svc = new CrmServiceClient(ConnectionStr);

            if (svc.IsReady)
            {
                //실행 대기시간 default 2분 -> 5분
                //if (svc.OrganizationWebProxyClient != null)
                //{
                //    svc.OrganizationWebProxyClient.InnerChannel.OperationTimeout = new TimeSpan(0, 5, 0);
                //}
                //else if(svc.OrganizationServiceProxy != null)
                //{
                //    svc.OrganizationServiceProxy.Timeout = new TimeSpan(0, 5, 0);
                //}
            }
            Service = svc;
            return ((WhoAmIResponse)svc.OrganizationServiceProxy.Execute(new WhoAmIRequest())).UserId;
        }

        /// <summary>
        /// Renew the token(if it is near expiration or has expired)
        /// </summary>
        /// <param name="_proxy"></param>
        /// <see cref="https://alisharifiblog.wordpress.com/2017/02/13/refresh-security-token-for-microsoft-dynamics-crm/"/>
        /// <see cref="https://stackoverflow.com/questions/27154282/is-there-an-organizationservice-connection-keep-alive-setting"/>
        /// <see cref="https://blog.thomasfaulkner.nz/post/2015/03/crm-organization-service-(re)authentication"/>
        public static void RenewTokenIfRequired(OrganizationServiceProxy _proxy)
        {
            if (null != _proxy.SecurityTokenResponse &&
                DateTime.UtcNow.AddMinutes(15) >= _proxy.SecurityTokenResponse.Response.Lifetime.Expires)
            {
                try
                {
                    _proxy.Authenticate();
                }
                catch (CommunicationException)
                {
                    if (null == _proxy.SecurityTokenResponse ||
                        DateTime.UtcNow >= _proxy.SecurityTokenResponse.Response.Lifetime.Expires)
                    {
                        throw;
                    }
                    // Ignore the exception 
                }
            }
        }

        /// <summary>
        /// If you are connecting using an secret configured for the application, you will use the "ClientCredential" class passing in the 'clientId' and 'clientSecret' rather than a "UserCredential" with 'userName' and 'password' parameters.
        /// it need application user on CRM(have to create)
        /// </summary>
        /// <see href="https://www.ashishvishwakarma.com/Connect-CrmServiceClient-Authenticate-Azure-AD-ClientId-ClientSecret/"/>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/data-platform/authenticate-oauth#connect-using-the-application-secret"/>
        /// <param name="environmentUri">https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">from aad, app registration</param>
        /// <param name="clientSecret">from aad, app registration</param>
        /// <returns></returns>
        public CrmServiceClient ConnectServiceApplicationUser(string environmentUri, string clientId, string clientSecret)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {Microsoft.Xrm.Tooling.Connector.AuthenticationType.ClientSecret:G};
            ClientId = {clientId};
            ClientSecret = {clientSecret};
            RequireNewInstance = True; LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            CrmServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);

            var svc = new CrmServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            {

            }
            else
            {
                throw svc.LastCrmException;
            }
            Service = svc;

            return svc;
        }

        /// <summary>
        /// Connect with specific crm user.
        /// You must set AllowPublicClient in AAD, AppRegistration, Manifest.
        /// </summary>
        /// <param name="environmentUri">https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">from aad, app registration</param>
        /// <param name="id">crm id</param>
        /// <param name="pw">crm pw</param>
        /// <param name="tenantId">from aad, app registration </param>
        /// <returns></returns>
        public CrmServiceClient ConnectServiceOAuth(string environmentUri, string clientId, string id, string pw, string tenantId)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {Microsoft.Xrm.Tooling.Connector.AuthenticationType.OAuth:G};
            Username = {id};
            Password = {pw};
            AppId = {clientId};
            RedirectUri = app://{tenantId};
            RequireNewInstance = True;
            LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            CrmServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);

            var svc = new CrmServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            {
                svc.CallerId = svc.GetMyCrmUserId();
            }
            else
            {
                throw svc.LastCrmException;
            }

            Service = svc;

            return svc;
        }

        /// <summary>
        /// Connect with specific crm user.
        /// You must set AllowPublicClient in AAD, AppRegistration, Manifest.
        /// </summary>
        /// <param name="environmentUri">https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">from aad, app registration</param>
        /// <param name="id">crm id</param>
        /// <param name="pw">crm pw</param>
        /// <returns></returns>
        public CrmServiceClient ConnectServiceOAuth(string environmentUri, string clientId, string accessToken)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {Microsoft.Xrm.Tooling.Connector.AuthenticationType.OAuth:G};
            ClientId = {clientId};
            RedirectUri = app://redirect;
            AccessToken = {accessToken};
            LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            CrmServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);

            var svc = new CrmServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            {
                svc.CallerId = svc.GetMyCrmUserId();
            }
            else
            {
                throw svc.LastCrmException;
            }

            Service = svc;

            return svc;
        }

        /// <summary>
        /// Create an On-Premises User
        /// </summary>
        /// <see cref="https://msdn.microsofot.com/en-us/library/jj602984.aspx"/>
        public void CreateOnPremisesUser()
        {

        }

        /// <summary>
        /// Obtain the AuthenticationCredentials based on AuthenticationProviderType.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-authenticate-users-web-services"/>
        /// <typeparam name="TService"></typeparam>
        /// <param name="service">A service management object.</param>
        /// <param name="endpointType">An <code>AuthenticationProviderType</code> of the CRM environment.</param>
        /// <param name="userid"></param>
        /// <param name="userpw"></param>
        /// <param name="domain"></param>
        /// <returns>Get filled <code>AuthenticationCredentials</code>.</returns>
        public AuthenticationCredentials GetCredentials<TService>(IServiceManagement<TService> service,
            AuthenticationProviderType endpointType, string userid, string userpw, string domain)
        {
            AuthenticationCredentials authCredentials = new AuthenticationCredentials();

            switch (endpointType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    authCredentials.ClientCredentials.Windows.ClientCredential = new NetworkCredential(userid, userpw, domain);
                    break;
                case AuthenticationProviderType.LiveId:
                    authCredentials.ClientCredentials.UserName.UserName = userid;
                    authCredentials.ClientCredentials.UserName.Password = userpw;
                    authCredentials.SupportingCredentials = new AuthenticationCredentials();
                    authCredentials.SupportingCredentials.ClientCredentials = DeviceIdManager.LoadOrRegisterDevice();
                    break;
                case AuthenticationProviderType.Federation:
                case AuthenticationProviderType.None:
                    break;
                case AuthenticationProviderType.OnlineFederation:
                    // For Federated and OnlineFederated environments.
                    authCredentials.ClientCredentials.UserName.UserName = userid;
                    authCredentials.ClientCredentials.UserName.Password = userpw;
                    // For OnlineFederated single-sign on, you could just use current UserPrincipalName instead of passing user name and password.
                    // authCredentials.UserPrincipalName = UserPrincipal.Current.UserPrincipalName;  // Windows Kerberos

                    // The service is configured for User Id authentication, but the user might provide Microsoft
                    // account credentials. If so, the supporting credentials must contain the device credentials.

                    IdentityProvider provider = service.GetIdentityProvider(authCredentials.ClientCredentials.UserName.UserName);
                    if (provider != null && provider.IdentityProviderType == IdentityProviderType.LiveId)
                    {
                        authCredentials.SupportingCredentials = new AuthenticationCredentials();
                        authCredentials.SupportingCredentials.ClientCredentials =
                           DeviceIdManager.LoadOrRegisterDevice();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(endpointType), endpointType, null);
            }

            return authCredentials;
        }

        /// <summary>
        /// Retrieve the version of Microsoft Dynamics CRM.
        /// </summary>
        /// <returns></returns>
        [Obsolete("RetrieveCRMVersion is Deprecated. Please use CrmServiceClient.ConnectedOrgVersion")]
        public string RetrieveCRMVersion(CrmServiceClient service = null)
        {
            if (service == null)
            {
                service = Service;
            }
            //return Service.ConnectedOrgVersion.ToString();
            var version = string.Empty;
            try
            {
                version = ((RetrieveVersionResponse)Service.Execute(new RetrieveVersionRequest())).Version;

            }
            catch (Exception)
            {
                //will add logger
            }

            return version;
        }

        /// <summary>
        /// Obtain information about the logged on user from the web service.
        /// Similer WhoAmI Method
        /// </summary>
        /// <returns></returns>
        public string RetrieveLoggedUserInfo()
        {
            var User = string.Empty;
            try
            {

                var userid = ((Microsoft.Crm.Sdk.Messages.WhoAmIResponse)Service.Execute(new Microsoft.Crm.Sdk.Messages.WhoAmIRequest())).UserId;
                //var systemUser = (SystemUser)_orgService.Retrieve("systemuser", userid,
                //   new ColumnSet(new string[] { "firstname", "lastname" }));

                //User = "Logged on user is " + systemUser.FirstName + " " + systemUser.LastName + ".";
                User = Service.Retrieve("systemuser", userid, new ColumnSet("fullname")).GetAttributeValue<string>("fullname");

            }
            catch (Exception)
            {
                //will add logger
                throw;
            }
            return User;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://gp23.com.au/2019/01/18/d365-authentication-connect-my-apps/"/>
        public class AuthHook : Microsoft.Xrm.Tooling.Connector.IOverrideAuthHookWrapper
        {
            /// <summary>
            /// In memory cache of access tokens
            /// </summary>
            Dictionary<string, Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult> accessTokens = new Dictionary<string, Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult>();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="environmentUrl">"https://myD365instance.crm6.dynamics.com"</param>
            /// <param name="clientId">00000000-0000-0000-0000-000000000001/param>
            /// <param name="clientSecret">the client secret for your app</param>
            /// <param name="tenantId">00000000-0000-0000-0000-000000000001</param>
            /// <param name="aadInstance">https://login.microsoftonline.com/</param>
            public AuthHook(string environmentUrl, string clientId, string clientSecret, string tenantId, string aadInstance = "https://login.microsoftonline.com/")
            {
                this.EnvironmentUrl = environmentUrl;
                this.ClientId = clientId;
                this.ClientSecret = clientSecret;
                this.TenantId = tenantId;
                this.AADInstance = aadInstance;
            }

            private string AADInstance { get; set; }
            /// <summary>
            ///  This is the Application ID from your App Registration
            /// </summary>
            private string ClientId { get; set; }

            /// <summary>
            /// The Client Secret from your App Registration
            /// </summary>
            private string ClientSecret { get; set; }

            private string EnvironmentUrl { get; set; }
            /// <summary>
            /// The GUID of your Azure Tenant ID. See the article above for details on finding this value.
            /// </summary>
            private string TenantId { get; set; }    
            public void AddAccessToken(Uri orgUri, Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult accessToken)
            {
                // Access tokens can be matched on the hostname,
                // different endpoints in the same organization can use the same access token
                accessTokens[orgUri.Host] = accessToken;
            }

            public CrmServiceClient Connect()
            {
                // Register the hook with the CrmServiceClient
                CrmServiceClient.AuthOverrideHook = this;

                // Create a new instance of CrmServiceClient, pass your organization url and make sure useUniqueInstance = true!
                var client = new CrmServiceClient(new Uri(this.EnvironmentUrl), useUniqueInstance: true);

                // Test with a basic WhoAmI request first
                OrganizationRequest request2 = new OrganizationRequest()
                {
                    RequestName = "WhoAmI"
                };
                OrganizationResponse response2 = client.Execute(request2);

                Entity entity1 = client.Retrieve("account", new Guid("92348762-0D32-E611-80EC-B38A27891203"), new Microsoft.Xrm.Sdk.Query.ColumnSet("name", "preferredcontactmethodcode"));
                return null;
            }

            public Microsoft.Xrm.Sdk.WebServiceClient.OrganizationWebProxyClient Connects()
            {
                var requestedToken = this.GetAuthToken(new Uri(EnvironmentUrl));

                using (var webProxyClient = new Microsoft.Xrm.Sdk.WebServiceClient.OrganizationWebProxyClient(new Uri($"{this.EnvironmentUrl}/XRMServices/2011/Organization.svc/web"), false))
                {
                    webProxyClient.HeaderToken = requestedToken;

                    // Test with a basic WhoAmI request first
                    OrganizationRequest request1 = new OrganizationRequest()
                    {
                        RequestName = "WhoAmI"
                    };
                    OrganizationResponse response1 = webProxyClient.Execute(request1);

                    // We are also able to create an instance of the OrganizationService and run queries against it
                    IOrganizationService organizationService = webProxyClient as IOrganizationService;

                    Entity entity = organizationService.Retrieve("account", new Guid("92348762-0D32-E611-80EC-B38A27891203"), new Microsoft.Xrm.Sdk.Query.ColumnSet("name", "preferredcontactmethodcode"));

                }
                return null;
            }

            public string GetAuthToken(Uri connectedUri)
            {
                // Check if you have an access token for this host
                if (accessTokens.ContainsKey(connectedUri.Host) && accessTokens[connectedUri.Host].ExpiresOn > DateTime.Now)
                {
                    return accessTokens[connectedUri.Host].AccessToken;
                }
                else
                {
                    accessTokens[connectedUri.Host] = GetAccessTokenFromAzureADAsync(connectedUri).Result;
                }
                return accessTokens[connectedUri.Host].AccessToken;
            }

            private async Task<Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult> GetAccessTokenFromAzureADAsync(Uri orgUrl)
            {
                var clientcred = new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(this.ClientId, this.ClientSecret);
                var authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(this.AADInstance + this.TenantId);
                var authenticationResult = await authenticationContext.AcquireTokenAsync(this.EnvironmentUrl, clientcred);
                
                // Save into memory
                accessTokens[new Uri(this.EnvironmentUrl).Host] = authenticationResult;

                return authenticationResult;
            }
        }
    }
}
