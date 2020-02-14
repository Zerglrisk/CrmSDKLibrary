using System;
using System.ServiceModel;

using Microsoft.Crm.Sdk.Messages;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

using System.Collections.Generic;
using System.Net;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;
using Microsoft.Xrm.Tooling.Connector;
using AuthenticationType = CrmSdkLibrary.Definition.Enum.AuthenticationType;

namespace CrmSdkLibrary
{
    public class Connection
    {
        public static IOrganizationService OrgService { get; private set; }
        public static ClientCredentials ClientCredentials;
        private ClientCredentials _deviceCredentials;

        //CrmServiceClient를 사용하여 Microsoft Dynamics 365(온라인 및 온-프레미스) 웹 서비스에 연결한다.
        /// <summary>
        /// connect to the Organization service.
        /// Connect to the Microsoft Dynamics 365 (online & on-premises) web service using the CrmServiceClient
        /// </summary>
        /// <see cref="https://msdn.microsoft.com/en-us/library/jj602970.aspx"/>
        /// <seealso cref="https://rajeevpentyala.com/2016/12/11/code-snippet-connect-to-dynamics-crm-using-organization-service-c/"/>
        /// <param name="connectionString">Provides service connection information</param>
        /// <param name="orgName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="location"></param>
        public Guid ConnectService(string orgName, string userName, string password, Definition.Enum.Location location)
        {
            
            var uri = new System.Uri($"https://{orgName}.api.crm{location.GetStringValue()}.dynamics.com/XRMServices/2011/Organization.svc");
            #region Old Using Microsoft.Xrm.Tooling.Connector.CrmServiceClient
            /*
            //need string connectionString parameter
            var conn = new CrmServiceClient(connectionString);

            //Need to add reference assembly "System.ServiceModel"
            _orgService = ((IOrganizationService)conn.OrganizationWebProxyClient != null) ? 
                (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            */
            #endregion
            //기본인증정보 설정.
            if (!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password))
            {
                if (ClientCredentials == null)
                    ClientCredentials = new ClientCredentials();
                ClientCredentials.UserName.UserName = userName;
                ClientCredentials.UserName.Password = password;
            }

            if (_deviceCredentials == null)
                _deviceCredentials = DeviceIdManager.LoadOrRegisterDevice();
            
            var organizationServiceProxy = new OrganizationServiceProxy(uri, null, ClientCredentials, _deviceCredentials);

            OrgService = organizationServiceProxy;

            return ((WhoAmIResponse)organizationServiceProxy.Execute(new WhoAmIRequest())).UserId;
        }

        /// <summary>
        /// Set clientCredential and Connect Server by Client using OrganizationServiceProxy to Custom URL
        /// </summary>
        /// <param name="organizationServiceUri"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Guid ConnectService(Uri organizationServiceUri, string userName, string password)
        {
            #region Old Using Microsoft.Xrm.Tooling.Connector.CrmServiceClient
            /*
            //need string connectionString parameter
            var conn = new CrmServiceClient(connectionString);

            //Need to add reference assembly "System.ServiceModel"
            _orgService = ((IOrganizationService)conn.OrganizationWebProxyClient != null) ? 
                (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            */
            #endregion
            
            //기본인증정보 설정.
            if (!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password))
            {
                if (ClientCredentials == null)
                    ClientCredentials = new ClientCredentials();
                ClientCredentials.UserName.UserName = userName;
                ClientCredentials.UserName.Password = password;
            }
            if (_deviceCredentials == null)
                _deviceCredentials = DeviceIdManager.LoadOrRegisterDevice();

            OrganizationServiceProxy organizationServiceProxy = null;

            try
            {
                organizationServiceProxy = new OrganizationServiceProxy(organizationServiceUri, null,
                    ClientCredentials, _deviceCredentials);
            }
            catch (Exception e)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                organizationServiceProxy = new OrganizationServiceProxy(organizationServiceUri, null,
                    ClientCredentials, _deviceCredentials);
            }
            organizationServiceProxy.Authenticate();
            
            OrgService = organizationServiceProxy;
            
            return ((WhoAmIResponse)organizationServiceProxy.Execute(new WhoAmIRequest())).UserId;
        }

        /// <summary>
        /// Connect Service Using CrmServiceClient
        /// Crm Online : Office365
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/org-service/quick-start-org-service-console-app"/>
        /// <param name="environmentUri"> e.g. https://test201018.crm5.dynamics.com</param>
        /// <param name="userName"> e.g. you@yourorg.onmicrosoft.com </param>
        /// <param name="password"> e.g. y0urp455w0rd </param>
        /// <param name="authType">  </param>
        /// <returns></returns>
        public Guid ConnectService(string environmentUri, string userName, string password,
            Definition.Enum.AuthenticationType authType = AuthenticationType.Office365) //Microsoft.Xrm.Tooling.Connector.AuthenticationType authType)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {authType:G};
            UserName = {userName};
            Password = {password};
            RequireNewInstance = True"; //GenerateConString();
            var svc = new CrmServiceClient(conn);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            svc.OrganizationServiceProxy.Authenticate();
            OrgService = svc;

            return ((WhoAmIResponse)svc.OrganizationServiceProxy.Execute(new WhoAmIRequest())).UserId;
        }

        //Similer WhoAmI Method
        /// <summary>
        /// Obtain information about the logged on user from the web service.
        /// </summary>
        /// <returns></returns>
        public string RetrieveLoggedUserInfo()
        {
            var User = string.Empty;
            try
            {

                var userid = ((Microsoft.Crm.Sdk.Messages.WhoAmIResponse)OrgService.Execute(new Microsoft.Crm.Sdk.Messages.WhoAmIRequest())).UserId;
                //var systemUser = (SystemUser)_orgService.Retrieve("systemuser", userid,
                //   new ColumnSet(new string[] { "firstname", "lastname" }));

                //User = "Logged on user is " + systemUser.FirstName + " " + systemUser.LastName + ".";
                User = OrgService.Retrieve("systemuser", userid, new ColumnSet("fullname")).GetAttributeValue<string>("fullname");

            }
            catch (Exception)
            {
                //will add logger
            }
            return User;
        }

        /// <summary>
        /// Retrieve the version of Microsoft Dynamics CRM.
        /// </summary>
        /// <returns></returns>
        public string RetrieveCRMVersion()
        {
            var version = string.Empty;
            try
            {
                version = ((RetrieveVersionResponse)OrgService.Execute(new RetrieveVersionRequest())).Version;

            }
            catch (Exception)
            {
                //will add logger
            }

            return version;
        }

        /// <summary>
        /// Create an On-Premises User
        /// </summary>
        /// <see cref="https://msdn.microsofot.com/en-us/library/jj602984.aspx"/>
        public void CreateOnPremisesUser()
        {

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
            AuthenticationProviderType endpointType,string userid, string userpw, string domain)
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
    }
}
