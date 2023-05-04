using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi_ADAL.Definition.Model
{
    public class EntityDefinitions
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }

        [JsonPropertyName("value")]
        public List<EntityMetadata> Values { get; set; }

        public EntityDefinitions()
        {
            this.Values = new List<EntityMetadata>();
        }
    }
}
