using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmSdkLibrary.Definition;
using CrmSdkLibrary.Definition.Enum;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow.Activities;

namespace CrmSdkLibrary
{
    public class Messages
    {
        public static bool DisableDuplicateDetection { get; set; } = false;

        public static KeyValuePair<string, object> GetDisableDuplicateDetectionParameter => new KeyValuePair<string, object>("SuppressDuplicateDetection", DisableDuplicateDetection);

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
        //        var metaData = RetrieveEntity(service, entityLogicalName);
        //        return metaData.Privileges;
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

        public static int GetEntityTypeCode(IOrganizationService service, string entityLogicalName)
        {
            try
            {
                var metaData = RetrieveEntity(service, entityLogicalName);
                if (!metaData.ObjectTypeCode.HasValue)
                {
                    throw new Exception("ObjectTypeCode is nUll");
                }

                return (int) metaData.ObjectTypeCode;
            }
            catch (Exception)
            {
                throw;
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
        public static IEnumerable<RolePrivilege> RetrieveUserPrivileges(IOrganizationService service)
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

                    Messages.DisableDuplicateDetection = true;
                    Messages.QualifyLead(Connection.OrgService,
                    new EntityReference("lead", new Guid("A461CA69-7A34-4416-A6D4-224C9D91E945")), 3,
                    QualifyLeadEntity.Account | QualifyLeadEntity.Contact | QualifyLeadEntity.Opportunity);
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

        /// <summary>
        /// Contains the data that is needed to send an email message.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.sendemailrequest?view=dynamics-general-ce-9"/>
        /// <see cref="https://docs.microsoft.com/en-us/dynamics365/customerengagement/on-premises/developer/entities/email"/>
        /// <param name="service"></param>
        /// <param name="email"></param>
        public static void SendEmail(IOrganizationService service, EmailFormat email)
        {
            //Sender
            var fromEntity = new EntityCollection();

             var fromentity = new Entity("activityparty")
            {
                Attributes =
                {
                    ["partyid"] = email.From
                }
            };
             fromEntity.Entities.Add(fromentity);

            var toEntity = new EntityCollection();
            foreach (var reference in email.To)
            {
                var entity = new Entity("activityparty")
                {
                    Attributes =
                    {
                        ["partyid"] = reference
                    }
                };
                toEntity.Entities.Add(entity);
            }
            foreach (var address in email.EmailAddress)
            {
                var entity = new Entity("activityparty")
                {
                    Attributes =
                    {
                        ["addressused"] = address
                    }
                };
                toEntity.Entities.Add(entity);
            }

            var emailEntity = new Entity("email")
            {
                  Attributes  =
                  {
                      ["subjct"] = email.Subject,
                      ["description"] = email.Description,
                      ["from"] = fromEntity,
                      ["to"] = toEntity,
                  }
            };

            var emailId = service.Create(emailEntity);


            var response = (SendEmailResponse) service.Execute(new SendEmailRequest()
            {
                Parameters = new ParameterCollection() {GetDisableDuplicateDetectionParameter},
                EmailId = emailId,
                IssueSend = true,
                TrackingToken = string.Empty
            });
            
        }

        /// <summary>
        /// Contains the data that is needed to add a set of existing privileges to an existing role.
        /// </summary>
        /// <see cref=""/>
        /// <param name="service"></param>
        /// <param name="roleId"></param>
        /// <param name="privileges"></param>
        /// <returns>There is no return value from this operation.</returns>
        public static void AddPrivilegesRole(IOrganizationService service, Guid roleId, IEnumerable<RolePrivilege> privileges)
        {
            try
            {
                var response = (AddPrivilegesRoleResponse)service.Execute(new AddPrivilegesRoleRequest()
                {
                    RoleId = roleId,
                    Privileges = privileges.ToArray()
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve the privileges that are assigned to the specified role.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveroleprivilegesrolerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IEnumerable<RolePrivilege> RetrieveRolePrivilegesRole(IOrganizationService service, Guid roleId)
        {
            try
            {
                var response = (RetrieveRolePrivilegesRoleResponse)service.Execute(new RetrieveRolePrivilegesRoleRequest()
                {
                    RoleId = roleId,
                });
                return response.RolePrivileges;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievemembersteamrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="teamId"></param>
        /// <param name="columnSet"></param>
        public static EntityCollection RetrieveMembersTeamDeprecated(IOrganizationService service, Guid teamId, ColumnSet columnSet)
        {
            try
            {
                var response = (RetrieveMembersTeamResponse) service.Execute(new RetrieveMembersTeamRequest()
                {
                    EntityId = teamId,
                    MemberColumnSet = columnSet
                });

                return response.EntityCollection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Members(SystemUser) in provided Team
        /// </summary>
        /// <param name="serivce"></param>
        /// <param name="teamId"></param>
        /// <param name="columnSet">default, All ColumnSet</param>
        /// <returns></returns>
        public static EntityCollection RetrieveMembersTeam(IOrganizationService serivce, Guid teamId, ColumnSet columnSet = null)
        {
            try
            {
                if (columnSet == null)
                {
                    columnSet = new ColumnSet(true);
                }

                var qe = new QueryExpression("systemuser")
                {
                    ColumnSet = columnSet,
                    LinkEntities =
                    {
                        new LinkEntity("systemuser","teammembership","systemuserid","systemuserid", JoinOperator.Inner)
                        {
                            LinkCriteria = new FilterExpression()
                            {
                                Conditions =
                                {
                                    new ConditionExpression("teamid", ConditionOperator.Equal, teamId)
                                }
                            }
                        }
                    }
                };
                return serivce.RetrieveMultiple(qe);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to retrieve all security principals (users or teams) that have access to, and access rights for, the specified record.
        /// Availability : Account, Annotation, Appointment, Campaign, CampaignActivity, CampaignResponse, Connection, Contact, Contract, ConvertRule
        /// CustomerOpportunityRole, CustomerRelationship, DuplicateRule, Email, EmailServerProfile, Entitlement, Fax, Goal
        /// GoalRollupQuery, Import, ImportFile, ImportMap, Incident, IncidentResolution, Invoice, Lead, Letter, List, Mailbox
        /// MailMergeTemplate, msdyn_PostAlbum, msdyn_wallsavedqueryusersettings, Opportunity, OpportunityClose, OrderClose
        /// PhoneCall, ProcessSession, Queue, Quote, QuoteClose, RecurringAppointmentMaster, Report, RoutingRule, SalesOrder
        /// ServiceAppointment, SharePointDocumentLocation, SharePointSite, SLA, SLAKPIInstance, SocialActivity, SocialProfile
        /// Task, Template, UserForm, UserQuery, UserQueryVisualization, Workflow
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievesharedprincipalsandaccessrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<PrincipalAccess> RetrieveSharedPrincipalsAndAccess(IOrganizationService service, EntityReference target)
        {
            try
            {
                var response= (RetrieveSharedPrincipalsAndAccessResponse)service.Execute(new RetrieveSharedPrincipalsAndAccessRequest()
                {
                     Target = target
                });
                return response.PrincipalAccesses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to retrieve entity metadata.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveentityrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <param name="entityFilters"></param>
        /// <returns></returns>
        public static EntityMetadata RetrieveEntity(IOrganizationService service, string entityLogicalName,
            EntityFilters entityFilters = EntityFilters.Default)
        {
            try
            {
                var response = (RetrieveEntityResponse) service.Execute(new RetrieveEntityRequest()
                {
                    EntityFilters =  entityFilters,
                    LogicalName =  entityLogicalName
                });
                return response.EntityMetadata;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to retrieve metadata information about all the entities.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveallentitiesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityFilters"></param>
        /// <returns></returns>
        public static IEnumerable<EntityMetadata> RetrieveAllEntities(IOrganizationService service, EntityFilters entityFilters = EntityFilters.Default)
        {
            try
            {
                var response = (RetrieveAllEntitiesResponse)service.Execute(new RetrieveAllEntitiesRequest()
                {
                    EntityFilters = entityFilters
                });
                return response.EntityMetadata;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get EntityPrimaryFieldName
        /// Custom Entities Default Primary Field Name is new_name
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static string GetEntityPrimaryFieldName(IOrganizationService service, string entityLogicalName)
        {
            try
            {
                var entityMetadata = RetrieveEntity(service, entityLogicalName, EntityFilters.Entity);
                return entityMetadata.PrimaryNameAttribute;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Entity Set Name
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.entitymetadata.entitysetname?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static string GetEntitySetName(IOrganizationService service, string entityLogicalName)
        {
            try
            {
                var entityMetadata = RetrieveEntity(service, entityLogicalName, EntityFilters.Entity);
                return entityMetadata.EntitySetName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get All Entity Set Name
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllEntitySetName(IOrganizationService service)
        {
            try
            {
                var entityMetadatas = RetrieveAllEntities(service, EntityFilters.Entity);
                return entityMetadatas.ToDictionary(
                    delegate(EntityMetadata metadata) { return metadata.LogicalName; },
                    delegate(EntityMetadata metadata) { return metadata.EntitySetName; });
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Contains the data that is needed to create a new global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.createoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSet"></param>
        /// <returns>Created Option Set Guid</returns>
        public static Guid CreateOptionSet(IOrganizationService service, OptionSetMetadata optionSet)
        {
            try
            {
                var response = (CreateOptionSetResponse) service.Execute(new CreateOptionSetRequest()
                {
                    OptionSet = optionSet
                });
                return response.OptionSetId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to update the definition of a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateoptionsetresponse?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSet"></param>
        public static void UpdateOptionSet(IOrganizationService service, OptionSetMetadata optionSet)
        {
            try
            {
                var response = (UpdateOptionSetResponse)service.Execute(new UpdateOptionSetRequest()
                {
                    OptionSet = optionSet
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to delete a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.deleteoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="globalOptionSetName"></param>
        public static void DeleteOptionSet(IOrganizationService service, string globalOptionSetName)
        {
            try
            {
                var response = (DeleteOptionSetResponse)service.Execute(new DeleteOptionSetRequest()
                {
                    Name = globalOptionSetName
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to retrieve a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="servie"></param>
        /// <param name="globalOptionSetName"></param>
        /// <returns></returns>
        public static OptionSetMetadataBase RetrieveOptionSet(IOrganizationService service, string globalOptionSetName)
        {
            try
            {
                var response = (RetrieveOptionSetResponse)service.Execute(new RetrieveOptionSetRequest()
                {
                    Name = globalOptionSetName, 
                    RetrieveAsIfPublished = true
                });
                return response.OptionSetMetadata;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to retrieve information about all global option sets.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrievealloptionsetsrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IEnumerable<OptionSetMetadataBase> RetrieveAllOptionSets(IOrganizationService service)
        {
            try
            {
                var response = (RetrieveAllOptionSetsResponse) service.Execute(new RetrieveAllOptionSetsRequest()
                {
                    RetrieveAsIfPublished = true
                });

                return response.OptionSetMetadata;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to delete an option value in a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.deleteoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName">Gets or sets the name of the option set that contains the value.</param>
        /// <param name="value">Gets or sets the value of the option to delete.</param>
        public static void DeleteOptionValue(IOrganizationService service, string optionSetName, int value)
        {
            try
            {
                var response = (DeleteOptionValueResponse) service.Execute(new DeleteOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Value = value, 
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to delete an option value in a local option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.deleteoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName">Gets or sets the name of the option set that contains the value.</param>
        /// <param name="value">Gets or sets the value of the option to delete.</param>
        /// <param name="entityLogicalName">Gets or sets the logical name of the entity that contains the attribute.</param>
        /// <param name="attributeLogicalName">Gets or sets the logical name of the attribute from which to delete the option value.</param>
        /// <param name="solutionUniqueName">Gets or sets the solution name associated with this option value. Optional.</param>
        public static void DeleteOptionValue(IOrganizationService service, string optionSetName, int value,
            string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            try
            {
                var response = (DeleteOptionValueResponse)service.Execute(new DeleteOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Value = value,
                    EntityLogicalName = entityLogicalName,
                    AttributeLogicalName = attributeLogicalName,
                    SolutionUniqueName = solutionUniqueName
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to insert a new option value for a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.insertoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <returns>Gets the option value for the new option.</returns>
        public static int InsertOptionValue(IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label)
        {
            try
            {
                var response = (InsertOptionValueResponse)service.Execute(new InsertOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Label = label
                });
                return response.NewOptionValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to insert a new option value for a local option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.insertoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <returns>Gets the option value for the new option.</returns>
        public static int InsertOptionValue(IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label, string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            try
            {
                var response = (InsertOptionValueResponse)service.Execute(new InsertOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Label = label,
                    EntityLogicalName = entityLogicalName,
                    AttributeLogicalName = attributeLogicalName,
                    SolutionUniqueName = solutionUniqueName, 
                    
                });
                return response.NewOptionValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to update an option value in a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <param name="value"></param>
        public static void UpdateOptionValue(IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label, int value)
        {
            try
            {
                var response = (UpdateOptionValueResponse)service.Execute(new UpdateOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Value = value,
                    Label = label
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to update an option value in a local option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <param name="entityLogicalName"></param>
        /// <param name="attributeLogicalName"></param>
        /// <param name="solutionUniqueName"></param>
        public static void UpdateOptionValue(IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label, int value, string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            try
            {
                var response = (UpdateOptionValueResponse)service.Execute(new UpdateOptionValueRequest()
                {
                    OptionSetName = optionSetName,
                    Value = value,
                    Label = label,
                    EntityLogicalName = entityLogicalName,
                    AttributeLogicalName =  attributeLogicalName,
                    SolutionUniqueName = solutionUniqueName
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dynamics365/customer-engagement/web-api/savedquery?view=dynamics-ce-odata-9
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static EntityCollection RetrieveViews(IOrganizationService service, string entityLogicalName)
        {
            try
            {
                var qe = new QueryExpression("savedquery")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria =  new FilterExpression()
                    {
                        Conditions =
                        {
                            new ConditionExpression("returnedtypecode", ConditionOperator.Equal, GetEntityTypeCode(service ,entityLogicalName))
                        }
                    }
                };
                return service.RetrieveMultiple(qe);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Entity RetrieveView(IOrganizationService service, Guid viewId)
        {
            try
            {
                return service.Retrieve("savedquery", viewId, new ColumnSet(true));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Contains the data that is needed to convert a query in FetchXML to a QueryExpression.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.fetchxmltoqueryexpressionrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="fetchXml"></param>
        /// <returns></returns>
        public static QueryExpression FetchXmlToQueryExpression(IOrganizationService service, string fetchXml)
        {
            try
            {
                return ((FetchXmlToQueryExpressionResponse) service.Execute(new FetchXmlToQueryExpressionRequest()
                {
                    FetchXml = fetchXml
                })).Query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Columns(Attributes) From View
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public static IEnumerable<string> RetrieveViewAttributes(IOrganizationService service, Guid viewId)
        {
            try
            {
                var view = RetrieveView(service, viewId);
                if (view.Contains("fetchxml"))
                {
                    var qe = FetchXmlToQueryExpression(service, view["fetchxml"].ToString());
                    return qe.ColumnSet.Columns;

                }
                else
                {
                    throw new Exception("Cannot find fetchxml string");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Entities(Records) By View
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public static EntityCollection RetrieveEntitiesByView(IOrganizationService service, Guid viewId)
        {
            try
            {
                var view = RetrieveView(service, viewId);
                if (view.Contains("fetchxml"))
                {
                    return service.RetrieveMultiple(new FetchExpression(view["fetchxml"].ToString()));
                }
                else
                {
                    throw new Exception("Cannot find fetchxml string");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
