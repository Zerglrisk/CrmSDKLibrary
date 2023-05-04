using System.Collections.Generic;
using Microsoft.Xrm.Sdk;

namespace CrmSdkLibrary_Core.Definition.Model
{
    public class EmailFormat
    {
        /// <summary>
        /// Receiver
        /// Target : account,contact,entitlement,equipment,knowledgearticle,lead,queue,systemuser,unresolvedaddress
        /// </summary>
        public EntityReferenceCollection To { get; set; }
        /// <summary>
        /// Sender
        /// Target : account,contact,entitlement,equipment,knowledgearticle,lead,queue,systemuser,unresolvedaddress
        /// </summary>
        public EntityReference From { get; set; }
        /// <summary>
        /// Receiver (Unknown, Using Email Address)
        /// </summary>
        public List<string> EmailAddress { get; set; }
        /// <summary>
        /// Email Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Email Contents
        /// </summary>
        public string Description { get; set; }
    }
}
