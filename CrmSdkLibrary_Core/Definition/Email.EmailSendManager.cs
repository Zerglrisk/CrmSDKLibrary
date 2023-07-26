using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;

namespace CrmSdkLibrary_Core.Definition
{
    public partial class Email
    {
        internal class EmailSendManager
        {
            public EmailSendManager(IOrganizationService service)
            {
                this.service = service;
            }

            private IOrganizationService service { get; set; }

            /// <summary>
            /// Contains the data that is needed to send an email message.
            /// </summary>
            /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.sendemailrequest?view=dynamics-general-ce-9"/>
            /// <see cref="https://docs.microsoft.com/en-us/dynamics365/customerengagement/on-premises/developer/entities/email"/>
            /// <param name="service"></param>
            /// <param name="email"></param>
            public void SendEmail(EmailFormat email)
            {
                // Sender
                var fromEntity = new EntityCollection();
                fromEntity.Entities.Add(email.From.GetEntity());

                // To
                var toEntity = new EntityCollection();
                foreach (var recipient in email.To)
                {
                    toEntity.Entities.Add(recipient.GetEntity());
                }

                // Cc
                var ccEntity = new EntityCollection();
                if (email.Cc != null)
                {
                    foreach (var recipient in email.Cc)
                    {
                        ccEntity.Entities.Add(recipient.GetEntity());
                    }
                }

                // Bcc
                var bccEntity = new EntityCollection();
                if (email.Bcc != null)
                {
                    foreach (var recipient in email.Bcc)
                    {
                        bccEntity.Entities.Add(recipient.GetEntity());
                    }
                }

                // Email entity
                var emailEntity = new Entity("email")
                {
                    Attributes =
                    {
                        ["subject"] = email.Subject,
                        ["description"] = email.Description,
                        ["from"] = fromEntity,
                        ["to"] = toEntity,
                        ["cc"] = ccEntity,
                        ["bcc"] = bccEntity,
                    }
                };

                // Create and send email
                var emailId = service.Create(emailEntity);

                // Attachments
                if (email.Attachments != null)
                {
                    foreach (var attachment in email.Attachments)
                    {
                        var attachmentEntity = new Entity("activitymimeattachment")
                        {
                            Attributes =
                            {
                                ["objectid"] = new EntityReference("email", emailId),
                                ["objecttypecode"] = "email",
                                ["filename"] = attachment.FileName,
                                ["body"] = Convert.ToBase64String(attachment.Content),
                                ["mimetype"] = attachment.MimeType
                            }
                        };
                        service.Create(attachmentEntity);
                    }
                }

                var response = service.Execute(new SendEmailRequest()
                {
                    EmailId = emailId,
                    IssueSend = true,
                    TrackingToken = string.Empty
                }) as SendEmailResponse;
            }
        }
    }
}