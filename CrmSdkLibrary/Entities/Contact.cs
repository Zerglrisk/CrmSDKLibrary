using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace CrmSdkLibrary.Entities
{
    public class Contact
    {
        private int? _entityTypeCode;
        public int? EntityTypeCode =>
            _entityTypeCode ?? (_entityTypeCode = Connection.Service != null
                ? Messages.GetEntityTypeCode(Connection.Service, EntityLogicalName)
                : _entityTypeCode);
        public const string EntityLogicalName = "contact";
        public const string EntitySetPath = "contacts";
        public const string DisplayName = "Contact";
        public const string PrimaryKey = "contactid";
        public const string PrimaryKeyAttribute = "fullname";

        /// <summary>
        /// This is native CRM behavior, to copy the content from Parent to Child record, using the Relationship ‘Mappings’ to avoid the overhead of manual data entry on child record.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="accountId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <see cref="https://rajeevpentyala.com/2017/01/26/create-a-child-record-by-copying-mapping-fields-from-parent-using-crm-sdk/"/>
        /// <returns></returns>
        public Guid CreateRecordFromAccount(IOrganizationService service, Guid accountId, string firstName, string lastName)
        {
            InitializeFromRequest initialize = new InitializeFromRequest
            {
                // Set the target entity (i.e.,Contact)
                TargetEntityName = "contact",

                // Create the EntityMoniker of Source (i.e.,Account)
                EntityMoniker = new EntityReference("account", accountId)
            };



            // Execute the request
            InitializeFromResponse initialized = (InitializeFromResponse)service.Execute(initialize);

            // Read Intitialized entity (i.e.,Contact with copied attributes from Account)
            if (initialized.Entity != null)
            {
                // Get entContact from the response
                var entContact = initialized.Entity;

                // Set the additional attributes of the Contact
                entContact.Attributes.Add("firstname", firstName);
                entContact.Attributes.Add("lastname", lastName);

                // Create a new contact
                return service.Create(entContact);
            }
            else return new Guid();
        }
    }

}
