using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi_ADAL.Definition.Model
{
    /// <summary>
    /// Use For Web API
    /// </summary>
    public class WhoAmI
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }

        [JsonPropertyName("BusinessUnitId")]
        public string BusinessUnitId { get; set; }

        [JsonPropertyName("UserId")]
        public string UserId { get; set; }

        [JsonPropertyName("OrganizationId")]
        public string OrganizationId { get; set; }

        [JsonIgnore]
        public ApiException Error { get; set; }
    }
}
