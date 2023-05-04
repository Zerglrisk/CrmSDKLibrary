using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi_ADAL.Definition.Model
{
    public class EntityMetadata
    {
        /// <summary>
        /// 무조건 있는 Id
        /// </summary>
        [JsonPropertyName("MetadataId")]
        public string MetadataId { get; set; }

        [JsonPropertyName("LogicalName")]
        public string LogicalName { get; set; }

        [JsonPropertyName("EntitySetName")]
        public string EntitySetName { get; set; }


        public int? ActivityTypeMask { get; set; }
        public bool? AutoRouteToOwnerQueue { get; set; }
        public bool? CanTriggerWorkflow { get; set; } 
        public bool? EntityHelpUrlEnabled { get; set; }
        public string EntityHelpUrl { get; set; }
        public bool? IsDocumentManagementEnabled { get; set; }

        [JsonPropertyName("ObjectTypeCode")]
        public int? ObjectTypeCode { get; set; }
    }
}