using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi_ADAL.Definition.Model
{
    public class JObjectParsed
    {
        [JsonIgnore]
        public ApiException Error { get; set; }

        [JsonPropertyName("@odata.context")]

        public string ODataContext { get; set; }
        [JsonPropertyName("value")]
        public JsonElement Value { get; set; }
    }
}
