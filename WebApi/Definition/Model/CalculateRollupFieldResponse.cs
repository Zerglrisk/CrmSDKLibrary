using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi_ADAL.Definition.Model
{
    public class CalculateRollupFieldResponse
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }
        [JsonPropertyName("@odata.type")]
        public string OdataType { get; set; }
        [JsonPropertyName("@odata.etag")]
        public string OdataETag { get; set; }
        [JsonPropertyName("attribute")]
        public object AttributeValue { get; set; }
        [JsonPropertyName("attribute_date")]
        public string AttributeDate { get; set; }
        [JsonPropertyName("attribute_state")]
        public int AttributeState { get; set; }
        [JsonIgnore]
        public string AttributeName { get; set; }
        [JsonPropertyName("recordid")]
        public string EntityRecordId { get; set; }

        [JsonIgnore]
        public ApiException Error { get; set; }
    }
}
