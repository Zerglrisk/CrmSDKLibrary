using System;

namespace CrmSdkLibrary.Attributes
{
	public class XrmAttribute : Attribute
	{
		#region Attributes

		public string AttributeName { get; }
		public Type AttributeType { get; }
		public string EntityReferenceLogicalName { get; }

		#endregion Attributes

		/// <summary>
		///
		/// </summary>
		/// <param name="attributeName"></param>
		/// <param name="attributeType">Default null</param>
		/// <param name="entityReferenceLogicalName">Default null</param>
		public XrmAttribute(string attributeName, Type attributeType = null, string entityReferenceLogicalName = null)
		{
			AttributeName = attributeName;

			//this.AttributeType = attributeType == null ? typeof(string) : attributeType;
			AttributeType = attributeType;
			EntityReferenceLogicalName = entityReferenceLogicalName;
		}
	}
}