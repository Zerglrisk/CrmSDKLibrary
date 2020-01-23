using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition.Enum
{
    /// <summary>
    /// Specifies the authentication type(AuthType) to connect to Common Data Service environment.
    /// Valid values are: AD, IFD (AD FS enabled), OAuth, Certificate, ClientSecret, or Office365.
    /// However, only OAuth, Certificate, ClientSecret and Office365 are permitted values for Common Data Service environments.
    /// </summary>
    /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/xrm-tooling/use-connection-strings-xrm-tooling-connect"/>
    public enum AuthenticationType
    {
        AD,
        IFD,
        OAuth,
        Certificate,
        ClientSecret,
        Office365,
        /// <summary>
        /// Custom Type (나중에 모르면 타입 하나씩 로그인 시도
        /// </summary>
        Unknown
    }
}
