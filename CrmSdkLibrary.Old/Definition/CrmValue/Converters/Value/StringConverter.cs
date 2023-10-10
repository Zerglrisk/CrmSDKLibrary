using System;

namespace CrmSdkLibrary.Old.Definition.CrmValue.Converters.Value
{
	internal sealed class StringConverter : CrmValueConverter<string>
	{
		public override string Read(ref CrmValueReader reader, Type typeConvert)
		{
			return reader.GetString();
		}
	}
}