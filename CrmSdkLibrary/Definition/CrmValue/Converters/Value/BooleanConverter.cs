using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition.CrmValue.Converters.Value
{
    internal sealed class BooleanConverter : CrmValueConverter<bool>
    {
        public override bool Read(ref CrmValueReader reader, Type typeConvert)
        {
            return reader.GetBoolean();
        }

    }
}
