using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Net;
using System.ServiceModel.Description;

namespace CrmSdkLibrary
{
	/// <summary>
	/// Deprecated (Use Ws-Trust Authenticate)
	/// </summary>
	public class Connectionv8
	{
		public static ClientCredentials ClientCredentials;
		private static ClientCredentials _deviceCredentials;
		public static CrmServiceClient Service { get; private set; }

		/// <summary>
		/// CrmServiceClient를 사용하여 Microsoft Dynamics 365(온라인 및 온-프레미스) 웹 서비스에 연결한다.
		/// Deprecated (Ws-Trust)
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
		public CrmServiceClient ConnectService(string orgName, string userName, string password, Definition.Enum.Location location)
		{
			var uri = new System.Uri($"https://{orgName}.api.crm{location.GetStringValue()}.dynamics.com/XRMServices/2011/Organization.svc");

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
			Service = new CrmServiceClient(organizationServiceProxy);
			Service.CallerId = ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
			//return ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
			return Service;
		}

		/// <summary>
		/// DepreCated (WS-Trust)
		/// Set clientCredential and Connect Server by Client using OrganizationServiceProxy to Custom URL
		/// </summary>
		/// <param name="organizationServiceUri"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public CrmServiceClient ConnectService(Uri organizationServiceUri, string userName, string password)
		{
			//기본인증정보 설정.
			if (!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password))
			{
				if (ClientCredentials == null)
					ClientCredentials = new ClientCredentials();
				ClientCredentials.UserName.UserName = userName;
				ClientCredentials.UserName.Password = password;
			}

			OrganizationServiceProxy organizationServiceProxy = null;

			ServicePointManager.SecurityProtocol =
				SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;

			try
            {
                if (_deviceCredentials == null)
                    _deviceCredentials = DeviceIdManager.LoadOrRegisterDevice();

                organizationServiceProxy = new OrganizationServiceProxy(organizationServiceUri, null,
					ClientCredentials, _deviceCredentials);
			}
			catch
			{
				organizationServiceProxy = new OrganizationServiceProxy(organizationServiceUri, null,
					ClientCredentials, null);
			}

			organizationServiceProxy.Authenticate();

			Service = new CrmServiceClient(organizationServiceProxy);
			Service.CallerId = ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
			return Service;
			//return ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
		}

		/// <summary>
		/// DepreCated (WS-Trust)
		/// Connect Service Using CrmServiceClient
		/// Crm Online : Office365
		/// </summary>
		/// <see href="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/org-service/quick-start-org-service-console-app"/>
		/// <param name="environmentUri"> e.g. https://test201018.crm5.dynamics.com</param>
		/// <param name="userName"> e.g. you@yourorg.onmicrosoft.com </param>
		/// <param name="password"> e.g. y0urp455w0rd </param>
		/// <param name="authType">  </param>
		/// <returns></returns>
		public CrmServiceClient ConnectService(string environmentUri, string userName, string password,
			AuthenticationType authType = AuthenticationType.Office365) //Microsoft.Xrm.Tooling.Connector.AuthenticationType authType)
		{
			string conn = $@"
            Url = {environmentUri};
            AuthType = {authType:G};
            UserName = {userName};
            Password = {password};
            RequireNewInstance = True;"; //GenerateConString();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			var svc = new CrmServiceClient(conn);
			svc.OrganizationServiceProxy.Authenticate();
			Service = svc;

			//OrgService = svc.OrganizationWebProxyClient ?? (IOrganizationService)svc.OrganizationServiceProxy;
			Service.CallerId = ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
			//return ((WhoAmIResponse)Service.Execute(new WhoAmIRequest())).UserId;
			return Service;
		}
	}
}