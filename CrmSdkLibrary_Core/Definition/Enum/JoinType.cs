﻿using CrmSdkLibrary_Core.Definition.Attribute;

namespace CrmSdkLibrary_Core.Definition.Enum
{
    public enum JoinType
    {
        /// <summary>
        /// LEFT OUTER
        /// </summary>
        [StringValue("LEFT")]
        LEFT,
        [StringValue("RIGHT OUTER")]
        RIGHT_OUTER,
        [StringValue("FULL OUTER")]
        FULL_OUTER,
        [StringValue("INNER")]
        INNER,
        [StringValue("CROSS")]
        CROSS,
        [StringValue("SELF")]
        SELF
    }
}