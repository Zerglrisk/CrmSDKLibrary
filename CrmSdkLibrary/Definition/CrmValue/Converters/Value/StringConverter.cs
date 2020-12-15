using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition.CrmValue.Converters.Value
{
    internal sealed class StringConverter : CrmValueConverter<string>
    {
        public override string Read(ref CrmValueReader reader, Type typeConvert)
        {
            return reader.GetString();
        }

    }
}
