using System;

namespace CrmSdkLibrary.Old.Definition.Enum
{
	[Flags]
	public enum QualifyLeadEntity
	{
		None = 0,
		Account = 1,
		Contact = 2,
		Opportunity = 4
	}
}