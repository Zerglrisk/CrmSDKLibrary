using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace CrmSdkLibrary.Dataverse.Definition
{
	public partial class Email
	{
		public interface IEmailRecipient
		{
			Entity GetEntity();
		}

		public class Attachment
		{
			public byte[] Content { get; set; }
			public string FileName { get; set; }
			public string MimeType { get; set; }
		}

		public class EmailFormat
		{
			/// <summary>
			/// Sender
			/// Target : systemuser
			/// </summary>
			public EntityReferenceEmailRecipient From { get; set; }

			/// <summary>
			/// Receiver
			/// Target : account,contact,entitlement,equipment,knowledgearticle,lead,queue,systemuser,unresolvedaddress, (Unknown, Using Email Address)
			/// </summary>
			public IEnumerable<IEmailRecipient> To { get; set; }

			public IEnumerable<IEmailRecipient> Cc { get; set; }
			public IEnumerable<IEmailRecipient> Bcc { get; set; }

			/// <summary>
			/// Email Subject
			/// </summary>
			public string Subject { get; set; }

			/// <summary>
			/// Email Contents
			/// </summary>
			public string Description { get; set; }

			public IEnumerable<Attachment> Attachments { get; set; }
		}

		public class EntityReferenceEmailRecipient : IEmailRecipient
		{
			public EntityReferenceEmailRecipient(EntityReference entityReference)
			{
				this.EntityReference = entityReference;
			}

			public EntityReference EntityReference { get; set; }

			public Entity GetEntity()
			{
				return new Entity("activityparty")
				{
					Attributes =
					{
						["partyid"] = EntityReference
					}
				};
			}
		}

		public class StringEmailRecipient : IEmailRecipient
		{
			public StringEmailRecipient(string address)
			{
				this.Address = address;
			}

			public string Address { get; set; }

			public Entity GetEntity()
			{
				return new Entity("activityparty")
				{
					Attributes =
					{
						["addressused"] = Address
					}
				};
			}
		}
	}
}