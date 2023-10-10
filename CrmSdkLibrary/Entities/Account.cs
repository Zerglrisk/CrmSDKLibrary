using Microsoft.Xrm.Sdk;
using System;

namespace CrmSdkLibrary.Entities
{
	public class Account
	{
		private int? _entityTypeCode;

		public int? EntityTypeCode =>
			_entityTypeCode ?? (_entityTypeCode = Connection.Service != null
				? Messages.GetEntityTypeCode(Connection.Service, EntityLogicalName)
				: _entityTypeCode);

		public const string EntityLogicalName = "account";
		public const string EntitySetPath = "accounts";
		public const string DisplayName = "Account";
		public const string PrimaryKey = "accountid";
		public const string PrimaryKeyAttribute = "name";

		/// <summary>
		///
		/// </summary>
		/// <see cref="https://community.dynamics.com/crm/b/misscrm360exploration/archive/2015/05/10/tips-crm-c-create-validated-parent-and-child-records-at-once-as-one-big-compound-using-related-entities"/>
		/// <param name="service"></param>
		/// <param name="name"></param>
		/// <param name="subject"></param>
		/// <param name="contents"></param>
		public void CreateLetterRecordWithRelatedEntities(IOrganizationService service, string name, string subject, string contents)
		{
			try
			{
				//Define the account for which we will add letters
				//Account
				var entity = new Entity("account")
				{
					["name"] = name
				};

				//This acts as a container for each letter we create, Note that we haven't
				//define the relationship between the letter and account yet.
				var entityCollection = new EntityCollection();
				var eLetter = new Entity("letter")
				{
					["subject"] = string.Format(subject)
				};

				//bind to the EntityCollection of the related records
				entityCollection.Entities.Add(eLetter);

				//Creates the reference between which relationship between Letter and
				//Account we would be like to use.
				var relationship = new Relationship("Account_Letters");

				//Adds the letters to the account under the specified relationship
				entity.RelatedEntities.Add(relationship, entityCollection);

				//Passes the Account (which contains the letters)
				service.Create(entity);

				//and guess, you only need 1 request for all records!!
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}