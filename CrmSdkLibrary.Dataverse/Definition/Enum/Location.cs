using CrmSdkLibrary.Dataverse.Definition.Attribute;

namespace CrmSdkLibrary.Dataverse.Definition.Enum
{
	/// <summary>
	/// Regional data center
	/// </summary>
	/// <see cref="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/org-service/discovery-service"/>
	public enum Location
	{
		[StringValue("")]
		NorthAmerica = 0,

		[StringValue("9")]
		NorthAmerica2 = 9,

		/// <summary>
		/// Europe, Middle East and Africa
		/// </summary>
		[StringValue("4")]
		EMEA = 4,

		/// <summary>
		/// Asia Pacific Area
		/// </summary>
		[StringValue("5")]
		APAC = 5,

		[StringValue("6")]
		Oceania = 6,

		[StringValue("7")]
		Japan = 7,

		[StringValue("2")]
		SouthAmerica = 2,

		[StringValue("8")]
		India = 8,

		[StringValue("3")]
		Canada = 3,

		[StringValue("11")]
		UnitedKingdom = 11,

		[StringValue("12")]
		France = 12,
	}
}