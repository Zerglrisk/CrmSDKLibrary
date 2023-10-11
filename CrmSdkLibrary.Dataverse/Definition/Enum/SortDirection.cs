using CrmSdkLibrary.Dataverse.Definition.Attribute;

namespace CrmSdkLibrary.Dataverse.Definition.Enum
{
	public enum SortDirection
	{
		[StringValue("ASC")]
		Ascending = 0,

		[StringValue("DESC")]
		Descending
	}
}