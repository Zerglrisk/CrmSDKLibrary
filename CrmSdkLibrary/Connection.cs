using System;
using System.ServiceModel;

using Microsoft.Crm.Sdk.Messages;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

using System.Collections.Generic;
using System.Net;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System.ServiceModel.Description;
using AuthenticationType = Microsoft.Xrm.Tooling.Connector.AuthenticationType;

namespace CrmSdkLibrary
{
    public class Connection
    {
        public static CrmServiceClient Service { get; private set; }

        public Guid ConnectServiceOAuth(string environmentUri, string clientId, string id, string pw, string tenantId)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {Microsoft.Xrm.Tooling.Connector.AuthenticationType.OAuth:G};
            Username = {id};
            Password = {pw};
            AppId = {clientId};
            RedirectUri = app://{tenantId};
            RequireNewInstance = True;
            LoginPrompt=Auto;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var svc = new CrmServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            {
                //실행 대기시간 default 2분 -> 5분
                svc.OrganizationWebProxyClient.InnerChannel.OperationTimeout = new TimeSpan(0, 5, 0);
                
            }

            Service = svc;
            //OrgService = svc.OrganizationWebProxyClient ?? (IOrganizationService)svc.OrganizationServiceProxy;


            return ((WhoAmIResponse)svc.Execute(new WhoAmIRequest())).UserId;
        }

        /// <summary>
        /// idk it doesn't work (shows 403 error) check more 
        /// </summary>
        /// <param name="environmentUri"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public Guid ConnectServiceCLientBased(string environmentUri, string clientId, string clientSecret)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {AuthenticationType.ClientSecret:G};
            ClientId = {clientId};
            ClientSecret = {clientSecret};
            RequireNewInstance = True; LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var svc = new CrmServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            { }
            svc.OrganizationServiceProxy.Authenticate();
            Service = svc;
            //OrgService = svc.OrganizationWebProxyClient ?? (IOrganizationService)svc.OrganizationServiceProxy;


            return ((WhoAmIResponse)svc.OrganizationServiceProxy.Execute(new WhoAmIRequest())).UserId;
        }

        /// <summary>
        /// Connect using a certificate thumbprint
        /// If you are connecting using a certificate and using the Microsoft.Xrm.Tooling.Connector.CrmServiceClient you can use this
        /// 인증서의 지문을 이용하여 사용한다,
        /// win + r  -> certmgr.msc -> 개인용 -> 인증서 선택 -> 제일 밑의 지문(thumbprint)
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/authenticate-oauth#connect-using-a-certificate-thumbprint"/>
        /// <see cref="https://www.crmviking.com/2018/03/dynamics-365-s2s-oauth-authentication.html"/>
        /// <param name="certThumbPrintId">e.g.) DC6C689022C905EA5F812B51F1574ED10F256FF6</param>
        /// <param name="environmentUri">e.g.) https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">  e.g.) 545ce4df-95a6-4115-ac2f-e8e5546e79af</param>
        public static Guid ConnectService(string certThumbPrintId, string environmentUri, string clientId)
        {
            string ConnectionStr = $@"AuthType=Certificate;
                        SkipDiscovery=true;url={environmentUri};
                        thumbprint={certThumbPrintId};
                        ClientId={clientId};
                        RequireNewInstance=true";
            CrmServiceClient svc = new CrmServiceClient(ConnectionStr);
            svc.OrganizationServiceProxy.Authenticate();

            Service = svc;
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

                var userid = ((Microsoft.Crm.Sdk.Messages.WhoAmIResponse)Service.Execute(new Microsoft.Crm.Sdk.Messages.WhoAmIRequest())).UserId;
                //var systemUser = (SystemUser)_orgService.Retrieve("systemuser", userid,
                //   new ColumnSet(new string[] { "firstname", "lastname" }));

                //User = "Logged on user is " + systemUser.FirstName + " " + systemUser.LastName + ".";
                User = Service.Retrieve("systemuser", userid, new ColumnSet("fullname")).GetAttributeValue<string>("fullname");

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
                version = ((RetrieveVersionResponse)Service.Execute(new RetrieveVersionRequest())).Version;

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
    }
}
