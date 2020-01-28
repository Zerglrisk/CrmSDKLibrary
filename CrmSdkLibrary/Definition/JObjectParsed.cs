using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition
{
    public class JObjectParsed
    {
        public ApiException Error { get; set; }

        public string ODataContext { get; set; }
        public dynamic value { get; set; }
    }
}
