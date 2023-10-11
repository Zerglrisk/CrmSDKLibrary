using CrmSdkLibrary.Dataverse.Definition.Attribute;

namespace CrmSdkLibrary.Dataverse.Definition.Enum
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