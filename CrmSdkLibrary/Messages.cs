using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmSdkLibrary.Definition.Enum;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary
{
    public class Messages
    {
        public static bool DisableDuplicateDetection { get; set; } = false;

        public static KeyValuePair<string, object> GetDisableDuplicateDetectionParameter { get; } = new KeyValuePair<string, object>("SuppressDuplicateDetection", DisableDuplicateDetection);

        public static Guid GetCurrentUserId(IOrganizationService service)
        {
            try
            {
                return ((WhoAmIResponse)service.Execute(new WhoAmIRequest())).UserId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Guid GetCurrentOrganizationId(IOrganizationService service)
        {
            try
            {
                return ((WhoAmIResponse)service.Execute(new WhoAmIRequest())).OrganizationId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static Guid GetCurrentBusinessUnitId(IOrganizationService service)
        {
            try
            {
                return ((WhoAmIResponse)service.Execute(new WhoAmIRequest())).BusinessUnitId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public static Guid team(IOrganizationService service)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Get Current Microsoft Dynamics CRM version
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Version</returns>
        public static string GetCurrentCRMVersion(IOrganizationService service)
        {
            try
            {
                return ((RetrieveVersionResponse)service.Execute(new RetrieveVersionRequest())).Version;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Contains the data that’s needed to retrieve information about the current organization.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievecurrentorganizationrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns></returns>
        public static OrganizationDetail GetCurrentOrganization(IOrganizationService service)
        {
            try
            {
                return ((RetrieveCurrentOrganizationResponse)service.Execute(new RetrieveCurrentOrganizationRequest())).Detail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// It must Enabled the 'Use System Pricing Calculation'
        /// On CRM System Settings Page > Sales Tab
        /// </summary>
        /// <see href="https://github.com/demianrasko/Dynamics-365-Workflow-Tools/blob/master/msdyncrmWorkflowTools/msdyncrmWorkflowTools/Class/CalculatePrice.cs"/>
        /// <see href="https://github.com/delegateas/XrmMockup/issues/25"/>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/dn817877%28v%3dcrm.8%29"/>
        /// <param name="service"></param>
        /// <param name="target"></param>
        public static void CalculatePrice(IOrganizationService service, EntityReference target)
        {
            try
            {
                service.Execute(new CalculatePriceRequest() { Target = target });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Applies To: Dynamics 365 (online), Dynamics 365 (on-premises), Dynamics CRM 2016, Dynamics CRM Online
        /// Contains the data that is needed to calculate the value of a rollup attribute.
        /// need test
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/dn818093(v=crm.8)?redirectedfrom=MSDN"/>
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/dn817863%28v%3dcrm.8%29"/> --need add
        /// <param name="service"></param>
        /// <param name="target">Gets or sets a reference to the record containing the rollup attribute to calculate. Required.</param>
        /// <param name="fieldName">Gets or sets logical name of the attribute to calculate. Required.</param>
        /// <returns>Gets an entity that contains the attributes relevant to the calculated rollup attribute.</returns>
        public static Entity CalculateRollupField(IOrganizationService service, EntityReference target, string fieldName)
        {

            try
            {
                var crfr = (CalculateRollupFieldResponse)service.Execute(new CalculateRollupFieldRequest()
                {
                    Target = target,
                    FieldName = fieldName
                });

                return crfr.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Contains the data that is needed to detect and retrieve duplicates for a specified record.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveduplicatesrequest?view=dynamics-general-ce-9"/>
        /// <see cref="https://blog.naver.com/wmf1235/221788586740"/>
        /// <param name="service"></param>
        /// <param name="businessEntity">Gets or sets a record for which the duplicates are retrieved.Required.</param>
        /// <param name="pagingInfo">Gets or sets a paging information for the retrieved duplicates.Required.</param>
        /// <returns>Gets a collection of duplicate entity instances.</returns>
        public static EntityCollection RetrieveDuplicatesEntities(IOrganizationService service, Entity businessEntity, PagingInfo pagingInfo)
        {
            try
            {
                var rdr = (RetrieveDuplicatesResponse)service.Execute(new RetrieveDuplicatesRequest
                {
                    BusinessEntity = businessEntity,
                    MatchingEntityName = businessEntity.LogicalName,
                    PagingInfo = pagingInfo
                });

                return rdr.DuplicateCollection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/org-service/discovery-service
        public static void DiscoverUrl()
        {

            var a = new Microsoft.Xrm.Sdk.WebServiceClient.DiscoveryWebProxyClient(
                new Uri("https://test201018.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"));

        }

        /// <summary>
        /// Contains the data that is needed to add a set of existing privileges to an existing role.
        /// 
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addprivilegesrolerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="privileges"></param>
        /// <param name="roleId"></param>
        public static void AddPrivilegesRole(IOrganizationService service, RolePrivilege[] privileges, Guid roleId)
        {
            try
            {
                var response = (AddPrivilegesRoleResponse)service.Execute(new AddPrivilegesRoleRequest()
                {
                    Privileges = privileges,
                    RoleId = roleId
                });


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="userId"></param>
        /// <returns>Gets an array of privileges that the user holds.</returns>
        public static RolePrivilege[] RetrieveUserPrivileges(IOrganizationService service, Guid userId)
        {
            try
            {
                var response = (RetrieveUserPrivilegesResponse)service.Execute(new RetrieveUserPrivilegesRequest()
                {
                    UserId = userId
                });
                return response.RolePrivileges;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns>Gets an array of privileges that the user holds.</returns>
        public static RolePrivilege[] RetrieveUserPrivileges(IOrganizationService service)
        {
            try
            {
                var userId = GetCurrentUserId(service);
                return RetrieveUserPrivileges(service, userId);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to grant a security principal (user or team) access to the specified record.
        /// Availability : Account, Annotation, Appointment, Campaign, CampaignActivity, CampaignResponse, Connection, Contact, Contract, ConvertRule
        /// CustomerOpportunityRole, CustomerRelationship, DuplicateRule, Email, EmailServerProfile, Entitlement, Fax, Goal
        /// GoalRollupQuery, Import, ImportFile, ImportMap, Incident, IncidentResolution, Invoice, Lead, Letter, List, Mailbox
        /// MailMergeTemplate, msdyn_PostAlbum, msdyn_wallsavedqueryusersettings, Opportunity, OpportunityClose, OrderClose
        /// PhoneCall, ProcessSession, Queue, Quote, QuoteClose, RecurringAppointmentMaster, Report, RoutingRule, SalesOrder
        /// ServiceAppointment, SharePointDocumentLocation, SharePointSite, SLA, SLAKPIInstance, SocialActivity, SocialProfile
        /// Task, Template, UserForm, UserQuery, UserQueryVisualization, Workflow
        /// need test
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.grantaccessrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="principalAccess">principal is team EntityReference.</param>
        /// <param name="target">target entity reference</param>
        public static void GrantAccess(IOrganizationService service, PrincipalAccess principalAccess, EntityReference target)
        {
            try
            {
                //var teamReference = new EntityReference("team", teamid);
                //var pr = new PrincipalAccess()
                //{
                //    AccessMask = AccessRights.ReadAccess | AccessRights.WriteAccess,
                //    Principal = teamReference
                //};

                var reponse = (GrantAccessResponse)service.Execute(new GrantAccessRequest()
                {
                    PrincipalAccess = principalAccess,
                    Target = target,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to qualify a lead and create account, contact, and opportunity records that are linked to the originating lead record.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.qualifyleadrequest?view=dynamics-general-ce-9"/>
        /// <see cref="https://community.dynamics.com/365/b/crmmemories/posts/qualify-a-lead-in-c"/>
        /// <param name="service"></param>
        /// <param name="targetLead">The ID of the lead that is qualified</param>
        /// <param name="statusCode">The status of the lead.</param>
        /// <param name="qualifyLeadEntity">A value that indicates whether to create an Entity from the originating lead.</param>
        /// <param name="opportunityCurrency">The Currency to use for the Opportunity.</param>
        /// <param name="opportunityCustomer">The Account or Contact that will be associated with the Opportunity.</param>
        /// <param name="sourceCampaign">The source Campaign that will be associated with the Opportunity.</param>
        /// <returns>The collection of references to the newly created account, contact, and opportunity records.</returns>
        public static EntityReferenceCollection QualifyLead(IOrganizationService service, EntityReference targetLead,
            int statusCode, QualifyLeadEntity qualifyLeadEntity, EntityReference opportunityCustomer = null,
            EntityReference opportunityCurrency = null, EntityReference sourceCampaign = null)
        {
            try
            {
                /*
                   Messages.QualifyLead(Connection.OrgService,
                   new EntityReference("lead", new Guid("561231D5-78E0-454C-8C80-374BB5E3FA26")), 3,
                   QualifyLeadEntity.Account | QualifyLeadEntity.Contact | QualifyLeadEntity.Opportunity,
                   new EntityReference("account", new Guid("475B158C-541C-E511-80D3-3863BB347BA8") ));
                 */

                //statusCode Value 3 is Qualify StatusCode. (Default)
                var createAccount = qualifyLeadEntity.HasFlag(QualifyLeadEntity.Account);
                var createContact = qualifyLeadEntity.HasFlag(QualifyLeadEntity.Contact);
                var createOpportunity = qualifyLeadEntity.HasFlag(QualifyLeadEntity.Opportunity);

                var response = (QualifyLeadResponse)service.Execute(new QualifyLeadRequest()
                {
                    Parameters = new ParameterCollection() { GetDisableDuplicateDetectionParameter },

                    LeadId = targetLead,
                    Status = new OptionSetValue(statusCode),

                    CreateAccount = createAccount,
                    CreateContact = createContact,
                    CreateOpportunity = createOpportunity,

                    // The Currency to use for the Opportunity.
                    OpportunityCurrencyId = null,

                    // The Account or Contact that will be associated with the Opportunity.
                    OpportunityCustomerId = null,

                    // The source Campaign that will be associated with the Opportunity.
                    SourceCampaignId = null,


                });
                return response.CreatedEntities;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
