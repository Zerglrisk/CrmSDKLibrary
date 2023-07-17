using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary_Core
{
    public class Connection
    {
        public static ServiceClient Service { get; private set; }

        //private static Microsoft.PowerPlatform.Dataverse.Client.ServiceClient serviceClient;

        //public static ServiceClient ServiceClient
        //{
        //    get
        //    {
        //        if (serviceClient == null ||
        //            serviceClient.ActiveAuthenticationType == AuthenticationType.InvalidConnection)
        //        {
        //            ServiceClient = ConnectServiceOAuth();
        //        }
        //        return serviceClient;
        //    }
        //    set
        //    {
        //        serviceClient = value;
        //    }
        //}

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
        public static ServiceClient ConnectServiceOAuth(string environmentUri, string clientId, string id, string pw, string tenantId)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {AuthenticationType.OAuth:G};
            Username = {id};
            Password = {pw};
            AppId = {clientId};
            RedirectUri = app://{tenantId};
            RequireNewInstance = True;
            LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            ServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);
            ServiceClient svc;
            try
            {
                svc = new ServiceClient(conn);
            }
            catch (Microsoft.PowerPlatform.Dataverse.Client.Utils.DataverseConnectionException dcex)
            {
                throw dcex;
            }

            if (svc.IsReady) //Connection is successful
            {
                svc.CallerId = GetCallerId(ref svc);
            }
            else
            {
                throw svc.LastException;
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
        public static ServiceClient ConnectServiceOAuth(string environmentUri, string accessToken)
        {
            var client = 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            ServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);
            ServiceClient svc;
            try
            {
                svc = new ServiceClient(new Uri(environmentUri), (orgServiceUrl) => Task.FromResult(accessToken));
            }
            catch (Microsoft.PowerPlatform.Dataverse.Client.Utils.DataverseConnectionException dcex)
            {
                throw dcex;
            }

            if (svc.IsReady) //Connection is successful
            {
                svc.CallerId = GetCallerId(ref svc);
            }
            else
            {
                throw svc.LastException;
            }

            Service = svc;

            return svc;
        }

        /// <summary>
        /// If you are connecting using an secret configured for the application, you will use the "ClientCredential" class passing in the 'clientId' and 'clientSecret' rather than a "UserCredential" with 'userName' and 'password' parameters.
        /// it need application user on CRM(have to create)
        /// </summary>
        /// <see href="https://www.ashishvishwakarma.com/Connect-ServiceClient-Authenticate-Azure-AD-ClientId-ClientSecret/"/>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/data-platform/authenticate-oauth#connect-using-the-application-secret"/>
        /// <param name="environmentUri">https://yourorg.crm.dynamics.com</param>
        /// <param name="clientId">from aad, app registration</param>
        /// <param name="clientSecret">from aad, app registration</param>
        /// <returns></returns>
        public static ServiceClient ConnectServiceApplicationUser(string environmentUri, string clientId, string clientSecret)
        {
            string conn = $@" 
            Url = {environmentUri};
            AuthType = {AuthenticationType.ClientSecret:G};
            ClientId = {clientId};
            ClientSecret = {clientSecret};
            RequireNewInstance = True; LoginPrompt=Never;"; //GenerateConString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //실행 대기시간 default 2분 -> 5분
            ServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);

            var svc = new ServiceClient(conn);
            if (svc.IsReady) //Connection is successful
            {
                svc.CallerId = GetCallerId(ref svc);
            }
            else
            {
                throw svc.LastException;
            }
            Service = svc;

            return svc;
        }

        /// <summary>
        /// Connect using a certificate thumbprint
        /// If you are connecting using a certificate and using the Microsoft.Xrm.Tooling.Connector.ServiceClient you can use this
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
            //ServiceClient.MaxConnectionTimeout = new TimeSpan(0, 5, 0);
            ServiceClient svc = new ServiceClient(ConnectionStr);

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
                svc.CallerId = GetCallerId(ref svc);
            }
            Service = svc;
            return svc.CallerId;
            //return ((WhoAmIResponse)svc.Execute(new WhoAmIRequest())).UserId;
        }

        public static Guid GetCallerId(ref ServiceClient serviceClient)
        {
            return ((Microsoft.Crm.Sdk.Messages.WhoAmIResponse)serviceClient.Execute(new Microsoft.Crm.Sdk.Messages.WhoAmIRequest())).UserId;
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
                throw;
            }
            return User;
        }

        /// <summary>
        /// Retrieve the version of Microsoft Dynamics CRM.
        /// </summary>
        /// <returns></returns>
        [Obsolete("RetrieveCRMVersion is Deprecated. Please use ServiceClient.ConnectedOrgVersion")]
        public string RetrieveCRMVersion(ServiceClient service = null)
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

    }
}
