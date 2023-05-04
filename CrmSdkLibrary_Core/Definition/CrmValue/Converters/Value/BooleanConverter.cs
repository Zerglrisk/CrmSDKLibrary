using System;

namespace CrmSdkLibrary_Core.Definition.CrmValue.Converters.Value
{
    internal sealed class BooleanConverter : CrmValueConverter<bool>
    {
        public override bool Read(ref CrmValueReader reader, Type typeConvert)
        {
            return reader.GetBoolean();
        }

    }
}
