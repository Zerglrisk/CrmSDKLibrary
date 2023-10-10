using System;

namespace CrmSdkLibrary.Old.Definition.CrmValue
{
	public abstract partial class CrmValueConverter<T> : CrmValueConverter
	{
		protected internal CrmValueConverter()
		{
			IsInternalConverter = GetType().Assembly == typeof(CrmValueConverter).Assembly;
			IsValueType = TypeToConvert.IsValueType;
			HandleNullValue = ShouldHandleNullValue;
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(T);
		}

		internal override Type ElementType => null;

		internal override sealed Type TypeToConvert => typeof(T);

		/// <summary>
		/// Is the converter built-in.
		/// </summary>
		internal bool IsInternalConverter { get; set; }

		// Allow a converter that can't be null to return a null value representation, such as JsonElement or Nullable<>.
		// In other cases, this will likely cause an JsonException in the converter.
		// Do not call this directly; it is cached in HandleNullValue.
		internal virtual bool ShouldHandleNullValue => IsValueType;

		public abstract T Read(ref CrmValueReader reader, Type typeToConvert);
	}
}