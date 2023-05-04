using System;

namespace CrmSdkLibrary.Definition.CrmValue
{
    public abstract partial class CrmValueConverter
    {
        internal CrmValueConverter(){ }

        public abstract bool CanConvert(Type typeToConvert);

        internal abstract Type ElementType { get; }

        internal abstract Type TypeToConvert { get; }

        /// <summary>
        /// Cached value of ShouldHandleNullValue. It is cached since the converter should never
        /// change the value depending on state and because it may contain non-trival logic.
        /// </summary>
        internal bool HandleNullValue { get; set; }

        /// <summary>
        /// Cached value of TypeToConvert.IsValueType, which is an expensive call.
        /// </summary>
        internal bool IsValueType { get; set; }
    }
}
