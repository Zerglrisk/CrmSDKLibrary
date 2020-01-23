using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition
{
    public class ApiExceptionWrapper
    {
        public ApiException Error { get; set; }
    }

    public class ApiException
    {

        public string Code { get; set; }
        public string Message { get; set; }
        public ApiInnerError InnerError { get; set; }
    }

    public class ApiInnerError
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string StackTrace { get; set; }

    }
}
