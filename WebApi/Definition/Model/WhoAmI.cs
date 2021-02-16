using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition.Model
{
    /// <summary>
    /// Use For Web API
    /// </summary>
    public class WhoAmI
    {
        public string ODataContext { get; set; }
        public string BusinessUnitId { get; set; }
        public string UserId { get; set; }
        public string OrganizationId { get; set; }

        public ApiException Error { get; set; }

        public override string ToString()
        {
            return $"{{{{\"ODataContext\" : \"{ODataContext}\", \"BusinessUnitId\" : \"{BusinessUnitId}\", \"UserId\" : \"{UserId}\", \"OrganizationId\" : \"{OrganizationId}\"}}}}";
        }
    }
}
