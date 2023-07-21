using CrmSdkLibrary.Definition;
using CrmSdkLibrary.Definition.Enum;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmSdkLibrary
{
    public static partial class Messages
    {
        /// <summary>
        /// Disable Duplication Detection (Default : false)
        /// 중복 탐지 비활성화
        /// </summary>
        public static bool DisableDuplicateDetection { get; set; } = false;

        public static KeyValuePair<string, object> GetDisableDuplicateDetectionParameter => new KeyValuePair<string, object>("SuppressDuplicateDetection", DisableDuplicateDetection);

        /// <summary>
        /// Activate a record
        /// </summary>
        /// <see cref="https://msdynamicscrmblog.wordpress.com/2013/05/02/activatedeactivate-a-record-using-c-in-dynamics-crm-2011/"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <param name="recordId"></param>
        public static void ActivateRecord(in IOrganizationService service, string entityLogicalName, Guid recordId, int stateCode = 0, int statusCode = 1)
        {
            var cols = new ColumnSet(new[] { "statecode", "statuscode" });

            //Check if it is Inactive or not
            var entity = service.Retrieve(entityLogicalName, recordId, cols);

            if (entity != null && entity.GetAttributeValue<OptionSetValue>("statecode").Value == 1)
            {
                //StateCode = 0 and StatusCode = 1 for activating Account or Contact
                SetStateRequest setStateRequest = new SetStateRequest()
                {
                    EntityMoniker = new EntityReference
                    {
                        Id = recordId,
                        LogicalName = entityLogicalName,
                    },
                    State = new OptionSetValue(stateCode),
                    Status = new OptionSetValue(statusCode)
                };
                service.Execute(setStateRequest);
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
        public static void CalculatePrice(in IOrganizationService service, EntityReference target)
        {
            service.Execute(new CalculatePriceRequest() { Target = target });
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
        public static Entity CalculateRollupField(in IOrganizationService service, EntityReference target, string fieldName)
        {
            return (service.Execute(new CalculateRollupFieldRequest()
            {
                Target = target,
                FieldName = fieldName
            }) as CalculateRollupFieldResponse).Entity;
        }

        /// <summary>
        ///
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.closeincidentrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="targetId"></param>
        /// <param name="statusCode"></param>
        public static void CloseIncident(in IOrganizationService service, Guid targetId, string resolution, int statusCode = 5, Guid resolutionId = new Guid())
        {
            service.Execute(new CloseIncidentRequest
            {
                IncidentResolution = new Entity("incidentresolution")
                {
                    Attributes =
                    {
                        ["subject"] = resolution,
                        ["incidentid"] = new EntityReference("incident", targetId)
                    },
                    Id = resolutionId
                },
                Status = new OptionSetValue(statusCode)
            });
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="service"></param>
        /// <param name="fileFullPath"></param>
        /// <param name="target"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static Guid CreateAnnotationtWithFileAttach(in IOrganizationService service, string fileFullPath, EntityReference target, string subject = "", string description = "")
        {
            var mimetype = System.Web.MimeMapping.GetMimeMapping(fileFullPath);
            var filebytes = System.IO.File.ReadAllBytes(fileFullPath);
            var encodedData = System.Convert.ToBase64String(filebytes);
            Entity entity = new Entity("annotation");
            entity["objectid"] = target;
            entity["subject"] = subject;
            entity["documentbody"] = encodedData;
            entity["mimetype"] = mimetype;
            entity["isdocument"] = true;
            entity["filename"] = System.IO.Path.GetFileName(fileFullPath);
            entity["notetext"] = subject;
            //AnnotationEntityObject["objecttypecode"] = "";

            return service.Create(entity);
        }

        /// <summary>
        /// Contains the data that is needed to create a new global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.createoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSet"></param>
        /// <returns>Created Option Set Guid</returns>
        public static Guid CreateOptionSet(in IOrganizationService service, OptionSetMetadata optionSet)
        {
            return (service.Execute(new CreateOptionSetRequest()
            {
                OptionSet = optionSet
            }) as CreateOptionSetResponse).OptionSetId;
        }

        /// <summary>
        /// Deactivate a record
        /// </summary>
        /// <see cref="https://msdynamicscrmblog.wordpress.com/2013/05/02/activatedeactivate-a-record-using-c-in-dynamics-crm-2011/"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <param name="recordId"></param>
        public static void DeactivateRecord(in IOrganizationService service, string entityLogicalName, Guid recordId, int stateCode = 1, int statusCode = 2)
        {
            var cols = new ColumnSet(new[] { "statecode", "statuscode" });

            //Check if it is Active or not
            var entity = service.Retrieve(entityLogicalName, recordId, cols);

            if (entity != null && entity.GetAttributeValue<OptionSetValue>("statecode").Value == 0)
            {
                //StateCode = 1 and StatusCode = 2 for deactivating Account or Contact
                SetStateRequest setStateRequest = new SetStateRequest()
                {
                    EntityMoniker = new EntityReference
                    {
                        Id = recordId,
                        LogicalName = entityLogicalName,
                    },
                    State = new OptionSetValue(stateCode),
                    Status = new OptionSetValue(statusCode)
                };
                service.Execute(setStateRequest);
            }
        }

        /// <summary>
        /// Deletes all partitions containing audit data created before a given end date.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/gg327533(v=crm.8)"/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.deleteauditdatarequest?view=dataverse-sdk-latest"/>
        /// <param name="service"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static void DeleteAuditData(in IOrganizationService service, DateTime endDate)
        {
            //// Get the list of audit partitions.
            //RetrieveAuditPartitionListResponse partitionRequest =
            //    (RetrieveAuditPartitionListResponse)service.Execute(new RetrieveAuditPartitionListRequest());
            //AuditPartitionDetailCollection partitions = partitionRequest.AuditPartitionDetailCollection;

            //// Create a delete request with an end date earlier than possible.
            //DeleteAuditDataRequest deleteRequest = new DeleteAuditDataRequest();
            //deleteRequest.EndDate = new DateTime(2000, 1, 1);

            //// Check if partitions are not supported as is the case with SQL Server Standard edition.
            //if (partitions.IsLogicalCollection)
            //{
            //    // Delete all audit records created up until now.
            //    deleteRequest.EndDate = DateTime.Now;
            //}

            //// Otherwise, delete all partitions that are older than the current partition.
            //// Hint: The partitions in the collection are returned in sorted order where the
            //// partition with the oldest end date is at index 0.
            //else
            //{
            //    for (int n = partitions.Count - 1; n >= 0; --n)
            //    {
            //        if (partitions[n].EndDate <= DateTime.Now && partitions[n].EndDate > deleteRequest.EndDate)
            //        {
            //            deleteRequest.EndDate = (DateTime)partitions[n].EndDate;
            //            break;
            //        }
            //    }
            //}

            //// Delete the audit records.
            //if (deleteRequest.EndDate != new DateTime(2000, 1, 1))
            //{
            //    service.Execute(deleteRequest);
            //    Console.WriteLine("Audit records have been deleted.");
            //}
            //else
            //    Console.WriteLine("There were no audit records that could be deleted.");
        }

        /// <summary>
        /// Contains the data that is needed to delete a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.deleteoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="globalOptionSetName"></param>
        public static void DeleteOptionSet(in IOrganizationService service, string globalOptionSetName)
        {
            service.Execute(new DeleteOptionSetRequest()
            {
                Name = globalOptionSetName
            });
        }

        /// <summary>
        /// Contains the data that is needed to delete an option value in a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.deleteoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName">Gets or sets the name of the option set that contains the value.</param>
        /// <param name="value">Gets or sets the value of the option to delete.</param>
        public static void DeleteOptionValue(in IOrganizationService service, string optionSetName, int value)
        {
            service.Execute(new DeleteOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Value = value,
            });
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
        public static void DeleteOptionValue(in IOrganizationService service, string optionSetName, int value,
            string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            service.Execute(new DeleteOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Value = value,
                EntityLogicalName = entityLogicalName,
                AttributeLogicalName = attributeLogicalName,
                SolutionUniqueName = solutionUniqueName
            });
        }

        /// <summary>
        /// [TODO] Test using old version
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/org-service/discovery-service"/>
        /// <param name="token"></param>
        /// <param name="url"></param>
        public static void DiscoverUrl(string token, string url)
        {
            var a = new Microsoft.Xrm.Sdk.WebServiceClient.DiscoveryWebProxyClient(
                new Uri(url))
            {
                HeaderToken = token,
            };

            var request = new Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationsRequest();
            var response = (Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationsResponse)a.Execute(request);
            var b = response.Details;
        }

        /// <summary>
        /// Contains the data that is needed to convert a query in FetchXML to a QueryExpression.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.fetchxmltoqueryexpressionrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="fetchXml"></param>
        /// <returns></returns>
        public static QueryExpression FetchXmlToQueryExpression(in IOrganizationService service, string fetchXml)
        {
            return (service.Execute(new FetchXmlToQueryExpressionRequest()
            {
                FetchXml = fetchXml
            }) as FetchXmlToQueryExpressionResponse).Query;
        }

        /// <summary>
        /// Get All Entity Set Name
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllEntitySetName(in IOrganizationService service)
        {
            var entityMetadatas = RetrieveAllEntities(service, EntityFilters.Entity);
            return entityMetadatas.ToDictionary(
                delegate (EntityMetadata metadata) { return metadata.LogicalName; },
                delegate (EntityMetadata metadata) { return metadata.EntitySetName; });
        }

        public static Guid GetCurrentBusinessUnitId(in IOrganizationService service)
        {
            return (service.Execute(new WhoAmIRequest()) as WhoAmIResponse).BusinessUnitId;
        }

        /// <summary>
        /// Get Current Microsoft Dynamics CRM version
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Version</returns>
        public static string GetCurrentCRMVersion(in IOrganizationService service)
        {
            return (service.Execute(new RetrieveVersionRequest()) as RetrieveVersionResponse).Version;
        }

        public static Guid GetCurrentOrganizationId(in IOrganizationService service)
        {
            return (service.Execute(new WhoAmIRequest()) as WhoAmIResponse).OrganizationId;
        }

        /// <summary>
        /// Get logged-in user id
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [Obsolete("GetCurrentUseById is deprecated. Please use CrmServiceClient.GetMyCrmUserId().", true)]
        public static Guid GetCurrentUserId(this CrmServiceClient service)
        {
            return (service.Execute(new WhoAmIRequest()) as WhoAmIResponse).UserId;
        }

        #region A

        /// <summary>
        /// Contains the data that is needed to add app components to a business app.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addappcomponentsrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="appId"></param>
        /// <param name="components"></param>
        public static void AddAppComponents(in IOrganizationService service, Guid appId, EntityReferenceCollection components)
        {
            service.Execute(new AddAppComponentsRequest
            {
                AppId = appId,
                Components = components
            });
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addchannelaccessprofileprivilegesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="channelAccessProfileid"></param>
        /// <param name="privileges"></param>
        public static void AddChannelAccessProfilePrivileges(in IOrganizationService service, Guid channelAccessProfileid, IEnumerable<ChannelAccessProfilePrivilege> privileges)
        {
            service.Execute(new AddChannelAccessProfilePrivilegesRequest
            {
                ChannelAccessProfileId = channelAccessProfileid,
                Privileges = privileges.ToArray()
            });
        }

        /// <summary>
        /// Contains the data that is needed to add an item to a campaign activity.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.additemcampaignactivityrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="campaignActivityId"></param>
        /// <param name="entityName"></param>
        /// <param name="itemId"></param>
        public static void AddItemCampaignActivity(in IOrganizationService service, Guid campaignActivityId, string entityName, Guid itemId)
        {
            service.Execute(new AddItemCampaignActivityRequest
            {
                CampaignActivityId = campaignActivityId,
                EntityName = entityName,
                ItemId = itemId
            });
        }

        /// <summary>
        /// Contains the data that is needed to add members to the list.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addlistmemberslistrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="listId"></param>
        /// <param name="memberIds"></param>
        public static void AddListMembersList(in IOrganizationService service, Guid listId, IEnumerable<Guid> memberIds)
        {
            service.Execute(new AddListMembersListRequest
            {
                ListId = listId,
                MemberIds = memberIds.ToArray()
            });
        }

        /// <summary>
        /// Contains the data that is needed to add a member to a list (marketing list).
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addmemberlistrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="listId"></param>
        /// <param name="entityId"></param>
        /// <returns>Gets the ID of the resulting list member.</returns>
        public static Guid AddMemberList(in IOrganizationService service, Guid listId, Guid entityId)
        {
            return (service.Execute(new AddMemberListRequest
            {
                ListId = listId,
                EntityId = entityId
            }) as AddMemberListResponse).Id;
        }

        /// <summary>
        /// Contains the data that is needed to add members to a team.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addmembersteamrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="teamId"></param>
        /// <param name="memberIds"></param>
        public static void AddMembersTeam(in IOrganizationService service, Guid teamId, IEnumerable<Guid> memberIds)
        {
            service.Execute(new AddMembersTeamRequest
            {
                TeamId = teamId,
                MemberIds = memberIds.ToArray()
            });
        }

        /// <summary>
        /// Contains the data to add the specified principal to the list of queue members. If the principal is a team, add each team member to the queue.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addprincipaltoqueuerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="principal"></param>
        /// <param name="queueId"></param>
        public static void AddPrincipalToQueue(in IOrganizationService service, Entity principal, Guid queueId)
        {
            service.Execute(new AddPrincipalToQueueRequest
            {
                Principal = principal,
                QueueId = queueId
            });
        }

        /// <summary>
        /// Contains the data that is needed to add a set of existing privileges to an existing role.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addprivilegesrolerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="roleId"></param>
        /// <param name="privileges"></param>
        /// <returns>There is no return value from this operation.</returns>
        public static void AddPrivilegesRole(in IOrganizationService service, Guid roleId, IEnumerable<RolePrivilege> privileges)
        {
            service.Execute(new AddPrivilegesRoleRequest()
            {
                RoleId = roleId,
                Privileges = privileges.ToArray()
            });
        }

        /// <summary>
        /// Deprecated. Use the <see cref="ProductAssociation"/> entity. Contains the data that is needed to add a product to a kit.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addproducttokitrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="productId"></param>
        /// <param name="kitId"></param>
        public static void AddProductToKit(in IOrganizationService service, Guid productId, Guid kitId)
        {
            service.Execute(new AddProductToKitRequest
            {
                ProductId = productId,
                KitId = kitId
            });
        }

        /// <summary>
        /// Contains the data that is needed to add recurrence information to an existing appointment.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addrecurrencerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="appointmentId"></param>
        /// <param name="target"></param>
        /// <returns>Gets the ID of the newly created recurring appointment.</returns>
        public static Guid AddRecurrence(in IOrganizationService service, Guid appointmentId, Entity target)
        {
            return (service.Execute(new AddRecurrenceRequest
            {
                AppointmentId = appointmentId,
                Target = target
            }) as AddRecurrenceResponse).id;
        }

        /// <summary>
        /// Contains the data that is needed to add a solution component to an unmanaged solution.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addsolutioncomponentrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="addRequiredComponents">Gets or sets a value that indicates whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution. Required.</param>
        /// <param name="componentType">Gets or sets the value that represents the solution component that you are adding.Required.</param>
        /// <param name="componentId">Gets or sets the ID of the solution component. Required.</param>
        /// <param name="solutionUniqueName">Gets or sets the unique name of the solution you are adding the solution component to. Required.</param>
        /// <returns></returns>
        public static Guid AddSolutionComponent(in IOrganizationService service, bool addRequiredComponents, int componentType, Guid componentId, string solutionUniqueName)
        {
            return (service.Execute(new AddSolutionComponentRequest
            {
                AddRequiredComponents = addRequiredComponents,
                ComponentType = componentType,
                ComponentId = componentId,
                SolutionUniqueName = solutionUniqueName,
            }) as AddSolutionComponentResponse).id;
        }

        /// <summary>
        /// Remove member to marketing list.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.removememberlistrequest?view=dynamics-general-ce-9"/>
        /// <param name="listId">Marketing List Id</param>
        /// <param name="memberId">Member Id</param>
        /// <returns>
        /// <see cref="RemoveMemberListResponse"/>
        /// </returns>
        public static void RemoveMemberList(in IOrganizationService service, Guid listId, Guid memberId)
        {
            service.Execute(new RemoveMemberListRequest()
            {
                ListId = listId,
                EntityId = memberId
            });
        }

        /// <summary>
        /// Contains the data that is needed to add members to a team.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.removemembersteamrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="teamId"></param>
        /// <param name="memberIds"></param>
        public static void RemoveMembersTeam(in IOrganizationService service, Guid teamId, IEnumerable<Guid> memberIds)
        {
            service.Execute(new RemoveMembersTeamRequest
            {
                TeamId = teamId,
                MemberIds = memberIds.ToArray()
            });
        }

        public static void ReplacePrivilegesRole(in IOrganizationService service, Guid roleId, IEnumerable<RolePrivilege> privileges)
        {
            service.Execute(new ReplacePrivilegesRoleRequest
            {
                RoleId = roleId,
                Privileges = privileges.ToArray()
            });
        }

        #endregion A

        /// <summary>
        /// Get LogicalName from ObjectTypeCode
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityTypeCode"></param>
        /// <returns></returns>
        public static string GetEntityLogicalNameFromTypeCode(in IOrganizationService service, int entityTypeCode)
        {
            var response = service.Execute(new RetrieveMetadataChangesRequest()
            {
                Query = new EntityQueryExpression()
                {
                    Criteria = new MetadataFilterExpression()
                    {
                        Conditions =
                            {
                                new MetadataConditionExpression("ObjectTypeCode", MetadataConditionOperator.Equals, entityTypeCode)
                            }
                    },
                    Properties = new MetadataPropertiesExpression()
                    {
                        AllProperties = false,
                        PropertyNames = { "LogicalName" }
                    },
                    //AttributeQuery = new AttributeQueryExpression()
                    //{
                    //    Criteria = new MetadataFilterExpression(),
                    //    Properties = new MetadataPropertiesExpression()
                    //},
                    //LabelQuery = new LabelQueryExpression()
                },
                ClientVersionStamp = null,
                //DeletedMetadataFilters = DeletedMetadataFilters.OptionSet
            }) as RetrieveMetadataChangesResponse;

            return response.EntityMetadata.Any() ? response.EntityMetadata.FirstOrDefault()?.LogicalName : null;
        }

        /// <summary>
        /// Get EntityMetadata from ObjectTypeCode
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityTypeCode"></param>
        /// <returns></returns>
        public static EntityMetadata GetEntityMetadataFromTypeCode(in IOrganizationService service, int entityTypeCode)
        {
            var response = service.Execute(new RetrieveMetadataChangesRequest()
            {
                Query = new EntityQueryExpression()
                {
                    Criteria = new MetadataFilterExpression()
                    {
                        Conditions =
                            {
                                new MetadataConditionExpression("ObjectTypeCode", MetadataConditionOperator.Equals, entityTypeCode)
                            }
                    },
                    Properties = new MetadataPropertiesExpression()
                    {
                        AllProperties = true
                    },
                    //AttributeQuery = new AttributeQueryExpression()
                    //{
                    //    Criteria = new MetadataFilterExpression(),
                    //    Properties = new MetadataPropertiesExpression()
                    //},
                    //LabelQuery = new LabelQueryExpression()
                },
                ClientVersionStamp = null,
                //DeletedMetadataFilters = DeletedMetadataFilters.OptionSet
            }) as RetrieveMetadataChangesResponse;

            return response.EntityMetadata.Any() ? response.EntityMetadata.FirstOrDefault() : null;
        }

        /// <summary>
        /// Get EntityPrimaryFieldName
        /// Custom Entities Default Primary Field Name is new_name
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static string GetEntityPrimaryFieldName(in IOrganizationService service, string entityLogicalName)
        {
            return RetrieveEntity(service, entityLogicalName, EntityFilters.Entity).PrimaryNameAttribute;
        }

        /// <summary>
        /// Get Entity Set Name
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.entitymetadata.entitysetname?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static string GetEntitySetName(in IOrganizationService service, string entityLogicalName)
        {
            return RetrieveEntity(service, entityLogicalName, EntityFilters.Entity).EntitySetName;
        }

        /// <summary>
        /// Get EntityTypeCode from EntityLgoicalName
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static int GetEntityTypeCode(in IOrganizationService service, string entityLogicalName)
        {
            var metaData = RetrieveEntity(service, entityLogicalName);
            if (!metaData.ObjectTypeCode.HasValue)
            {
                throw new Exception("ObjectTypeCode is null.");
            }

            return metaData.ObjectTypeCode.Value;
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
        public static void GrantAccess(in IOrganizationService service, PrincipalAccess principalAccess, EntityReference target)
        {
            //var teamReference = new EntityReference("team", teamid);
            //var pr = new PrincipalAccess()
            //{
            //    AccessMask = AccessRights.ReadAccess | AccessRights.WriteAccess,
            //    Principal = teamReference
            //};

            service.Execute(new GrantAccessRequest()
            {
                PrincipalAccess = principalAccess,
                Target = target,
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.grantaccessrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="principalAccess"></param>
        /// <param name="target"></param>
        public static void GrantAccessRequest(in IOrganizationService service, PrincipalAccess principalAccess, EntityReference target)
        {
            //new PrincipalAccess { AccessMask = AccessRights.ReadAccess, Principal = systemUser1Ref }, Target = leadReference
            service.Execute(new GrantAccessRequest
            {
                PrincipalAccess = principalAccess,
                Target = target
            });
        }

        /// <summary>
        /// Contains the data that is needed to insert a new option value for a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.insertoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <returns>Gets the option value for the new option.</returns>
        public static int InsertOptionValue(in IOrganizationService service, string optionSetName, Microsoft.Xrm.Sdk.Label label)
        {
            return (service.Execute(new InsertOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Label = label
            }) as InsertOptionValueResponse).NewOptionValue;
        }

        /// <summary>
        /// Contains the data that is needed to insert a new option value for a local option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.insertoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <returns>Gets the option value for the new option.</returns>
        public static int InsertOptionValue(in IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label, string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            return (service.Execute(new InsertOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Label = label,
                EntityLogicalName = entityLogicalName,
                AttributeLogicalName = attributeLogicalName,
                SolutionUniqueName = solutionUniqueName,
            }) as InsertOptionValueResponse).NewOptionValue;
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
        public static EntityReferenceCollection QualifyLead(in IOrganizationService service, EntityReference targetLead,
            int statusCode, QualifyLeadEntity qualifyLeadEntity, EntityReference opportunityCustomer = null,
            EntityReference opportunityCurrency = null, EntityReference sourceCampaign = null)
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

            var response = service.Execute(new QualifyLeadRequest()
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
            }) as QualifyLeadResponse;
            return response.CreatedEntities;
        }

        /// <summary>
        /// Contains the data that is needed to convert a query, which is represented as a QueryExpression class, to its equivalent query, which is represented as FetchXML.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.queryexpressiontofetchxmlrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="queryExpression"></param>
        /// <returns></returns>
        public static string QueryExpressionToFetchXml(in IOrganizationService service, QueryExpression queryExpression)
        {
            return (service.Execute(new QueryExpressionToFetchXmlRequest()
            {
                Query = queryExpression
            }) as QueryExpressionToFetchXmlResponse).FetchXml;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve metadata information about all the entities.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveallentitiesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityFilters"></param>
        /// <returns></returns>
        public static IEnumerable<EntityMetadata> RetrieveAllEntities(in IOrganizationService service, EntityFilters entityFilters = EntityFilters.Default)
        {
            return (service.Execute(new RetrieveAllEntitiesRequest()
            {
                EntityFilters = entityFilters
            }) as RetrieveAllEntitiesResponse).EntityMetadata;
        }

        public static IEnumerable<Guid> RetrieveAllMembers(in IOrganizationService service, Guid listId)
        {
            var qe = new QueryExpression("listmember")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
                {
                    Conditions =
                    {
                        new ConditionExpression("listid", ConditionOperator.Equal, listId)
                    }
                },
                PageInfo = new PagingInfo()
                {
                    Count = 5000,
                    PageNumber = 1,
                }
            };

            var ec = service.RetrieveMultiple(qe);

            List<Guid> memberList = ec.Entities.Select(entity => entity.ToCrmValue<EntityReference>("entityid").Id).ToList();

            while (ec.MoreRecords)
            {
                qe.PageInfo.PageNumber += 1;
                qe.PageInfo.PagingCookie = ec.PagingCookie;
                ec = service.RetrieveMultiple(qe);

                memberList.AddRange(ec.Entities.Select(entity => entity.ToCrmValue<EntityReference>("entityid").Id));
            }

            return memberList;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve information about all global option sets.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrievealloptionsetsrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IEnumerable<OptionSetMetadataBase> RetrieveAllOptionSets(in IOrganizationService service, bool retrieveAsIfPublished = false)
        {
            return (service.Execute(new RetrieveAllOptionSetsRequest()
            {
                RetrieveAsIfPublished = retrieveAsIfPublished
            }) as RetrieveAllOptionSetsResponse).OptionSetMetadata;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve attribute metadata.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveattributerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="logicalName"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static AttributeMetadata RetrieveAttribute(in IOrganizationService service, bool retrieveAsIfPublished = false, string logicalName = null, string attributeName = null, int columnNumber = 0)
        {
            return (service.Execute(new RetrieveAttributeRequest
            {
                EntityLogicalName = logicalName, // optional
                LogicalName = attributeName, // optional
                RetrieveAsIfPublished = retrieveAsIfPublished, // required
                ColumnNumber = columnNumber, // optional
            }) as RetrieveAttributeResponse).AttributeMetadata;
        }

        /// <summary>
        /// Retrieves all changes to a specific attribute.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/gg308132(v=crm.8)"/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveattributechangehistoryrequest?view=dataverse-sdk-latest"/>
        /// <param name="service"></param>
        /// <param name="target"></param>
        /// <param name="targetAttributeLogicalName"></param>
        /// <returns></returns>
        public static AuditDetailCollection RetrieveAttributeChangeHistory(in IOrganizationService service, EntityReference target, string targetAttributeLogicalName)
        {
            return (service.Execute(new RetrieveAttributeChangeHistoryRequest
            {
                Target = target,
                AttributeLogicalName = targetAttributeLogicalName
            }) as RetrieveAttributeChangeHistoryResponse).AuditDetailCollection;
        }

        /// <summary>
        /// Retrieves the full audit details of a particular audit record. The record to retrieve is specified in the AuditId property.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/gg308134(v=crm.8)"/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveauditdetailsrequest?view=dataverse-sdk-latest"/>
        /// <param name="service"></param>
        /// <param name="auditId"></param>
        /// <returns></returns>
        public static AuditDetail RetrieveAuditDetails(in IOrganizationService service, Guid auditId)
        {
            return (service.Execute(new RetrieveAuditDetailsRequest
            {
                AuditId = auditId
            }) as RetrieveAuditDetailsResponse).AuditDetail;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve the list of database partitions that are used to store audited history data.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/gg308136(v=crm.8)"/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveauditpartitionlistrequest?view=dataverse-sdk-latest"/>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AuditPartitionDetailCollection RetrieveAuditPartitionList(in IOrganizationService service)
        {
            return (service.Execute(new RetrieveAuditPartitionListRequest()) as RetrieveAuditPartitionListResponse).AuditPartitionDetailCollection;
        }

        /// <summary>
        /// Contains the data that’s needed to retrieve information about the current organization.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievecurrentorganizationrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns></returns>
        public static Microsoft.Xrm.Sdk.Organization.OrganizationDetail RetrieveCurrentOrganization(in IOrganizationService service)
        {
            return (service.Execute(new RetrieveCurrentOrganizationRequest()) as RetrieveCurrentOrganizationResponse).Detail;
        }

        public static string RetrieveCurrentOrganzizationWebApplicationUrl(in IOrganizationService service)
        {
            return Messages.RetrieveCurrentOrganization(service).Endpoints.FirstOrDefault(e => e.Key == Microsoft.Xrm.Sdk.Organization.EndpointType.WebApplication).Value;
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
        public static EntityCollection RetrieveDuplicates(in IOrganizationService service, Entity businessEntity, PagingInfo pagingInfo)
        {
            return (service.Execute(new RetrieveDuplicatesRequest
            {
                BusinessEntity = businessEntity,
                MatchingEntityName = businessEntity.LogicalName,
                PagingInfo = pagingInfo
            }) as RetrieveDuplicatesResponse).DuplicateCollection;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve entity metadata.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveentityrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <param name="entityFilters"></param>
        /// <param name="metadataId">A unique identifier for the entity. Optional.</param>
        /// <returns></returns>
        public static EntityMetadata RetrieveEntity(in IOrganizationService service, string entityLogicalName, EntityFilters entityFilters = EntityFilters.Default, Guid metadataId = default)
        {
            return (service.Execute(new RetrieveEntityRequest()
            {
                EntityFilters = entityFilters,
                LogicalName = entityLogicalName,
                MetadataId = metadataId,
            }) as RetrieveEntityResponse).EntityMetadata;
        }

        /// <summary>
        /// Retrieve Members(SystemUser) in provided Team
        /// </summary>
        /// <param name="serivce"></param>
        /// <param name="teamId"></param>
        /// <param name="columnSet">default, All ColumnSet</param>
        /// <returns></returns>
        public static EntityCollection RetrieveMembersTeam(in IOrganizationService serivce, Guid teamId, ColumnSet columnSet = null)
        {
            return serivce.RetrieveMultiple(new QueryExpression("systemuser")
            {
                ColumnSet = columnSet ?? new ColumnSet(true),
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
            });
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievemembersteamrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="teamId"></param>
        /// <param name="columnSet"></param>
        public static EntityCollection RetrieveMembersTeamDeprecated(in IOrganizationService service, Guid teamId, ColumnSet columnSet)
        {
            return (service.Execute(new RetrieveMembersTeamRequest()
            {
                EntityId = teamId,
                MemberColumnSet = columnSet
            }) as RetrieveMembersTeamResponse).EntityCollection;
        }

        /// <summary>
        /// Contains the data that is needed to retrieve a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.retrieveoptionsetrequest?view=dynamics-general-ce-9"/>
        /// <param name="servie"></param>
        /// <param name="globalOptionSetName"></param>
        /// <returns></returns>
        public static OptionSetMetadata RetrieveOptionSet(in IOrganizationService service, string globalOptionSetName, bool retrieveAsIfPublished = false)
        {
            return (service.Execute(new RetrieveOptionSetRequest()
            {
                Name = globalOptionSetName,
                RetrieveAsIfPublished = retrieveAsIfPublished
            }) as RetrieveOptionSetResponse).OptionSetMetadata as OptionSetMetadata;
        }

        /// <summary>
        ///
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveprincipalaccessrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        public static AccessRights RetrievePrincipalAccessRequest(in IOrganizationService service, EntityReference target, EntityReference principal)
        {
            return (service.Execute(new RetrievePrincipalAccessRequest
            {
                Principal = principal,
                Target = target
            }) as RetrievePrincipalAccessResponse).AccessRights;
        }

        /// <summary>
        /// Retrieves all changes to a specific entity.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/gg308221(v=crm.8)"/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieverecordchangehistoryrequest?view=dataverse-sdk-latest"/>
        /// <param name="service"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static AuditDetailCollection RetrieveRecordChangeHistory(in IOrganizationService service, EntityReference target)
        {
            return (service.Execute(new RetrieveRecordChangeHistoryRequest()
            {
                Target = target
            }) as RetrieveRecordChangeHistoryResponse).AuditDetailCollection;
        }

        /// <summary>
        /// Retrieve the privileges that are assigned to the specified role.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveroleprivilegesrolerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IEnumerable<RolePrivilege> RetrieveRolePrivilegesRole(in IOrganizationService service, Guid roleId)
        {
            return (service.Execute(new RetrieveRolePrivilegesRoleRequest()
            {
                RoleId = roleId,
            }) as RetrieveRolePrivilegesRoleResponse).RolePrivileges;
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
        public static IEnumerable<PrincipalAccess> RetrieveSharedPrincipalsAndAccess(in IOrganizationService service, EntityReference target)
        {
            return (service.Execute(new RetrieveSharedPrincipalsAndAccessRequest()
            {
                Target = target
            }) as RetrieveSharedPrincipalsAndAccessResponse).PrincipalAccesses;
        }

        /// <summary>
        ///
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievesharedprincipalsandaccessrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<PrincipalAccess> RetrieveSharedPrincipalsAndAccessRequest(in IOrganizationService service, EntityReference target)
        {
            return (service.Execute(new RetrieveSharedPrincipalsAndAccessRequest
            {
                Target = target
            }) as RetrieveSharedPrincipalsAndAccessResponse).PrincipalAccesses;
        }

        /// <summary>
        /// Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="userId"></param>
        /// <returns>Gets an array of privileges that the user holds.</returns>
        public static RolePrivilege[] RetrieveUserPrivileges(in IOrganizationService service, Guid userId)
        {
            return (service.Execute(new RetrieveUserPrivilegesRequest()
            {
                UserId = userId
            }) as RetrieveUserPrivilegesResponse).RolePrivileges;
        }

        /// <summary>
        /// Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <returns>Gets an array of privileges that the user holds.</returns>
        public static IEnumerable<RolePrivilege> RetrieveUserPrivileges(this CrmServiceClient service)
        {
            return RetrieveUserPrivileges(service, service.GetMyCrmUserId());
        }

        /// <summary>
        /// Contains the data that is needed to send an email message.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.sendemailrequest?view=dynamics-general-ce-9"/>
        /// <see cref="https://docs.microsoft.com/en-us/dynamics365/customerengagement/on-premises/developer/entities/email"/>
        /// <param name="service"></param>
        /// <param name="email"></param>
        public static void SendEmail(in IOrganizationService service, EmailFormat email)
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
                Attributes =
                  {
                      ["subjct"] = email.Subject,
                      ["description"] = email.Description,
                      ["from"] = fromEntity,
                      ["to"] = toEntity,
                  }
            };

            var emailId = service.Create(emailEntity);

            service.Execute(new SendEmailRequest()
            {
                Parameters = new ParameterCollection() { GetDisableDuplicateDetectionParameter },
                EmailId = emailId,
                IssueSend = true,
                TrackingToken = string.Empty
            });// as SendEmailResponse;
        }

        /// <summary>
        /// Contains the data that is needed to update the definition of a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateoptionsetresponse?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSet"></param>
        public static void UpdateOptionSet(in IOrganizationService service, OptionSetMetadata optionSet)
        {
            service.Execute(new UpdateOptionSetRequest()
            {
                OptionSet = optionSet
            });
        }

        /// <summary>
        /// Contains the data that is needed to update an option value in a global option set.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateoptionvaluerequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="optionSetName"></param>
        /// <param name="label"></param>
        /// <param name="value"></param>
        public static void UpdateOptionValue(in IOrganizationService service, string optionSetName, Microsoft.Xrm.Sdk.Label label, int value)
        {
            service.Execute(new UpdateOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Value = value,
                Label = label
            });
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
        public static void UpdateOptionValue(in IOrganizationService service, string optionSetName,
            Microsoft.Xrm.Sdk.Label label, int value, string entityLogicalName, string attributeLogicalName, string solutionUniqueName = null)
        {
            service.Execute(new UpdateOptionValueRequest()
            {
                OptionSetName = optionSetName,
                Value = value,
                Label = label,
                EntityLogicalName = entityLogicalName,
                AttributeLogicalName = attributeLogicalName,
                SolutionUniqueName = solutionUniqueName
            });
        }
    }
}