using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace CrmSdkLibrary.Old
{
	/// <summary>
	/// </summary>
	/// <see href="https://bettercrm.blog/2017/08/02/list-of-undocumented-sdk-messages/"/>
	public static partial class Messages
	{
		public static class Undocumented
		{
			/// <summary>
			/// Add Dynamic Property
			/// </summary>
			/// <returns>DynamicPropertyId</returns>
			public static Guid? AddDynamicProperty(in IOrganizationService service, EntityReference regardingObject, Entity dynamicProperty)
			{
				var response = service.Execute(new OrganizationRequest("AddDynamicProperty")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["DynamicProperty"] = dynamicProperty,
					}
				});

				if (response != null && response.Results.Contains("DynamicPropertyId"))
				{
					return (Guid)response.Results["DynamicPropertyId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Add Edit App Module
			/// </summary>
			/// <param name="appModuleComponents"></param>
			/// <param name="appModule"></param>
			/// <param name="isNew"></param>
			/// <param name="retainAppModuleComponents"></param>
			/// <returns>AppModuleComponentIds</returns>
			public static IEnumerable<Guid> AddEditAppModule(in IOrganizationService service, EntityCollection appModuleComponents, Entity appModule, bool isNew, bool retainAppModuleComponents)
			{
				var response = service.Execute(new OrganizationRequest("AddEditAppModule")
				{
					Parameters =
					{
						["AppModuleComponents"] = appModuleComponents,
						["AppModule"] = appModule,
						["IsNew"] = isNew,
						["RetainAppModuleComponents"] = retainAppModuleComponents,
					}
				});

				if (response != null && response.Results.Contains("AppModuleComponentIds"))
				{
					return (Guid[])response.Results["AppModuleComponentIds"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Add Members By FetchXml List It Add Members to List associated campaign
			/// </summary>
			/// <param name="service"></param>
			public static void AddMembersByFetchXmlList(in IOrganizationService service, Guid listId, string fetchXml)
			{
				var response = service.Execute(new OrganizationRequest("AddMembersByFetchXmlList")
				{
					Parameters =
					{
						["ListId"] = listId,
						["FetchXml"] = fetchXml,
					}
				});
			}

			/// <summary>
			/// Add Or Edit Location
			/// </summary>
			/// <param name="service"></param>
			/// <param name="locationName"></param>
			/// <param name="absUrl">Absolute Url</param>
			/// <param name="regardingObjectId"></param>
			/// <param name="relativePath"></param>
			/// <param name="regardingObjType"></param>
			/// <param name="parentType"></param>
			/// <param name="parentId"></param>
			/// <param name="isAddOrEditMode"></param>
			/// <param name="isCreateFolder"></param>
			/// <param name="documentId"></param>
			/// <returns>LocationId</returns>
			public static string AddOrEditLocation(in IOrganizationService service, string locationName, string absUrl, string regardingObjectId, string relativePath, int regardingObjType, int parentType, string parentId, bool isAddOrEditMode, bool isCreateFolder, string documentId)
			{
				var response = service.Execute(new OrganizationRequest("AddOrEditLocation")
				{
					Parameters =
					{
						["LocationName"] = locationName,
						["AbsUrl"] = absUrl,
						["RegardingObjectId"] = regardingObjectId,
						["RelativePath"] = relativePath,
						["RegardingObjType"] = regardingObjType,
						["ParentType"] = parentType,
						["ParentId"] = parentId,
						["IsAddOrEditMode"] = isAddOrEditMode,
						["IsCreateFolder"]=isCreateFolder,
						["DocumentId"] =documentId
					}
				});

				if (response != null && response.Results.Contains("LocationId"))
				{
					return (string)response.Results["LocationId"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Apply Profile Rule
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			public static void ApplyProfileRule(in IOrganizationService service, EntityReference target)
			{
				service.Execute(new OrganizationRequest("ApplyProfileRule")
				{
					Parameters =
					{
						["Target"] = target
					}
				});
			}

			/// <summary>
			/// Assign All Records Team
			/// </summary>
			/// <param name="service"></param>
			/// <param name="oldOwnerId"></param>
			/// <param name="oldOwnerType"></param>
			/// <param name="newOwnerId"></param>
			/// <param name="newOwnerType"></param>
			public static void AssignAllRecordsTeam(in IOrganizationService service, Guid oldOwnerId, int oldOwnerType, Guid newOwnerId, int newOwnerType)
			{
				service.Execute(new OrganizationRequest("AssignAllRecordsTeam")
				{
					Parameters =
					{
						["OldOwnerId"] = oldOwnerId,
						["OldOwnerType"] = oldOwnerType,
						["NewOwnerId"] = newOwnerId,
						["NewOwnerType"] = newOwnerType,
					}
				});
			}

			/// <summary>
			/// Associate Knowledge Article
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="regardingObjectTypeCode"></param>
			/// <param name="associationRelationshipName"></param>
			/// <param name="knowledgeArticleId"></param>
			public static void AssociateKnowledgeArticle(in IOrganizationService service, Guid regardingObjectId, int regardingObjectTypeCode, string associationRelationshipName, Guid knowledgeArticleId)
			{
				service.Execute(new OrganizationRequest("AssociateKnowledgeArticle")
				{
					Parameters =
					{
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["AssociationRelationshipName"] = associationRelationshipName,
						["KnowledgeArticleId"] = knowledgeArticleId,
					}
				});
			}

			/// <summary>
			/// Authenticate And Fetch ACIData
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="entityRecordId"></param>
			/// <param name="aciRequestURI"></param>
			/// <returns>ACIResponse</returns>
			public static string AuthenticateAndFetchACIData(in IOrganizationService service, string entityName, Guid entityRecordId, string aciRequestURI)
			{
				var response = service.Execute(new OrganizationRequest("AuthenticateAndFetchACIData")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["EntityRecordId"] = entityRecordId,
						["ACIRequestURI"] = aciRequestURI,
					}
				});

				if (response != null && response.Results.Contains("ACIResponse"))
				{
					return (string)response.Results["ACIResponse"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// BestTimeToEmail
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityReferenceCollection"></param>
			/// <returns>PreferredTime</returns>
			public static DateTime? BestTimeToEmail(in IOrganizationService service, EntityReferenceCollection entityReferenceCollection)
			{
				var response = service.Execute(new OrganizationRequest("BestTimeToEmail")
				{
					Parameters =
					{
						["EntityReferenceCollection"] = entityReferenceCollection,
					}
				});

				if (response != null && response.Results.Contains("PreferredTime"))
				{
					return (DateTime)response.Results["PreferredTime"]; // System.DateTime
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Build Topic Model
			/// </summary>
			/// <param name="service"></param>
			/// <param name="topicModelId"></param>
			public static void BuildTopicModel(in IOrganizationService service, Guid topicModelId)
			{
				var response = service.Execute(new OrganizationRequest("BuildTopicModel")
				{
					Parameters =
					{
						["TopicModelId"] = topicModelId,
					}
				});
			}

			/// <summary>
			/// Bulk Delete Imported Records
			/// </summary>
			/// <param name="service"></param>
			/// <param name="targetEntityName"></param>
			/// <param name="importSequenceNumber"></param>
			/// <param name="importId"></param>
			/// <param name="deleteImportHistory"></param>
			/// <param name="jobName"></param>
			/// <param name="sendEmailNotification"></param>
			/// <param name="toRecipients"></param>
			/// <param name="ccRecipients"></param>
			/// <param name="recurrencePattern"></param>
			/// <param name="sourceImportId"></param>
			/// <returns>JobId</returns>
			public static Guid? BulkDeleteImportedRecords(in IOrganizationService service, string targetEntityName, int importSequenceNumber, Guid importId, bool deleteImportHistory, string jobName,
				bool sendEmailNotification, string toRecipients, string ccRecipients, string recurrencePattern, Guid sourceImportId)
			{
				var response = service.Execute(new OrganizationRequest("BulkDeleteImportedRecords")
				{
					Parameters =
					{
						["TargetEntityName"] = targetEntityName,
						["ImportSequenceNumber"] = importSequenceNumber,
						["ImportId"] = importId,
						["DeleteImportHistory"] = deleteImportHistory,
						["JobName"] = jobName,
						["SendEmailNotification"] = sendEmailNotification,
						["ToRecipients"] = toRecipients,
						["CCRecipients"] = ccRecipients,
						["RecurrencePattern"] = recurrencePattern,
						["SourceImportId"] = sourceImportId,
					}
				});

				if (response != null && response.Results.Contains("JobId"))
				{
					return (Guid)response.Results["JobId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// BulkOperation Status Close
			/// </summary>
			/// <param name="service"></param>
			/// <param name="bulkOperationId"></param>
			/// <param name="failureCount"></param>
			/// <param name="successCount"></param>
			/// <param name="statusReason"></param>
			/// <param name="errorCode"></param>
			public static void BulkOperationStatusClose(in IOrganizationService service, Guid bulkOperationId, int failureCount, int successCount, int statusReason, int errorCode)
			{
				service.Execute(new OrganizationRequest("BulkOperationStatusClose")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["FailureCount"] = failureCount,
						["SuccessCount"] = successCount,
						["StatusReason"] = statusReason,
						["ErrorCode"] = errorCode,
					}
				});
			}

			/// <summary>
			/// Calculate Trigger DateTime
			/// </summary>
			/// <param name="service"></param>
			/// <param name="calendarId"></param>
			/// <param name="startTime"></param>
			/// <param name="triggerDuration"></param>
			/// <returns>result</returns>
			public static DateTime? CalculateTriggerDateTime(in IOrganizationService service, Guid calendarId, DateTime startTime, int triggerDuration)
			{
				var response = service.Execute(new OrganizationRequest("CalculateTriggerDateTime")
				{
					Parameters =
					{
						["CalendarId"] = calendarId,
						["StartTime"] = startTime,
						["TriggerDuration"] = triggerDuration,
					}
				});

				if (response != null && response.Results.Contains("result"))
				{
					return (DateTime)response.Results["result"]; // System.DateTime
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Can Close Opportunity
			/// </summary>
			/// <param name="service"></param>
			/// <param name="opportunityId"></param>
			/// <param name="quoteId"></param>
			/// <param name="newStatus"></param>
			/// <returns>CanClose</returns>
			public static bool? CanCloseOpportunity(in IOrganizationService service, Guid opportunityId, Guid quoteId, int newStatus)
			{
				var response = service.Execute(new OrganizationRequest("CanCloseOpportunity")
				{
					Parameters =
					{
						["OpportunityId"] = opportunityId,
						["QuoteId"] = quoteId,
						["NewStatus"] = newStatus,
					}
				});

				if (response != null && response.Results.Contains("CanClose"))
				{
					return (bool)response.Results["CanClose"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Can User Send Email
			/// </summary>
			/// <param name="service"></param>
			/// <returns>HasPrivileges</returns>
			public static bool? CanUserSendEmail(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("CanUserSendEmail"));

				if (response != null && response.Results.Contains("HasPrivileges"))
				{
					return (bool)response.Results["HasPrivileges"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// Check Client Compatibility
			/// </summary>
			/// <param name="service"></param>
			/// <param name="crmClientVersion"></param>
			/// <returns>Result</returns>
			public static int? CheckClientCompatibility(in IOrganizationService service, string crmClientVersion)
			{
				var response = service.Execute(new OrganizationRequest("CheckClientCompatibility")
				{
					Parameters =
					{
						["CrmClientVersion"] = crmClientVersion,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (int)response.Results["Result"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CheckInDocument
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			/// <param name="checkInComments"></param>
			/// <param name="retainCheckout"></param>
			public static void CheckInDocument(in IOrganizationService service, Entity entity, string checkInComments, bool retainCheckout)
			{
				service.Execute(new OrganizationRequest("CheckInDocument")
				{
					Parameters =
					{
						["Entity"] = entity,
						["CheckInComments"] = checkInComments,
						["RetainCheckout"] = retainCheckout,
					}
				});
			}

			/// <summary>
			/// CheckInSharePointDocument
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentId"></param>
			/// <param name="checkInComments"></param>
			/// <param name="retainCheckout"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			public static void CheckInSharePointDocument(in IOrganizationService service, string documentId, string checkInComments, bool retainCheckout, string siteUrl, string documentLocation, string referencedEntity)
			{
				var response = service.Execute(new OrganizationRequest("CheckInSharePointDocument")
				{
					Parameters =
					{
						["DocumentId"] = documentId,
						["CheckInComments"] = checkInComments,
						["RetainCheckout"] = retainCheckout,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});
			}

			/// <summary>
			/// CheckNotifications
			/// </summary>
			/// <param name="service"></param>
			/// <param name="lastChecked"></param>
			/// <param name="events"></param>
			/// <returns></returns>
			public static EntityCollection CheckNotifications(in IOrganizationService service, DateTime lastChecked, params int[] events)
			{
				var response = service.Execute(new OrganizationRequest("CheckNotifications")
				{
					Parameters =
					{
						["LastChecked"] = lastChecked,
						["Events"] = events,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CheckoutDocument
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			public static void CheckoutDocument(in IOrganizationService service, Entity entity)
			{
				service.Execute(new OrganizationRequest("CheckoutDocument")
				{
					Parameters =
					{
						["Entity"] = entity,
					}
				});
			}

			/// <summary>
			/// CheckoutSharePointDocument
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentId"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			public static void CheckoutSharePointDocument(in IOrganizationService service, string documentId, string siteUrl, string documentLocation, string referencedEntity)
			{
				service.Execute(new OrganizationRequest("CheckoutSharePointDocument")
				{
					Parameters =
					{
						["DocumentId"] = documentId,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});
			}

			/// <summary>
			/// CheckRouterCompatibility
			/// </summary>
			/// <param name="service"></param>
			/// <param name="crmRouterVersion"></param>
			/// <returns>Result</returns>
			public static int? CheckRouterCompatibility(in IOrganizationService service, string crmRouterVersion)
			{
				var response = service.Execute(new OrganizationRequest("CheckRouterCompatibility")
				{
					Parameters =
					{
						["CrmRouterVersion"] = crmRouterVersion,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (int)response.Results["Result"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CleanUpBulkOperation
			/// </summary>
			/// <param name="service"></param>
			/// <param name="bulkOperationId"></param>
			/// <param name="bulkOperationSource"></param>
			public static void CleanUpBulkOperation(in IOrganizationService service, Guid bulkOperationId, int bulkOperationSource)
			{
				service.Execute(new OrganizationRequest("CleanUpBulkOperation")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["BulkOperationSource"] = bulkOperationSource,
					}
				});
			}

			/// <summary>
			/// CloneProductAssociation
			/// </summary>
			/// <param name="service"></param>
			/// <param name="source"></param>
			public static void CloneProductAssociation(in IOrganizationService service, EntityReference source)
			{
				service.Execute(new OrganizationRequest("CloneProductAssociation")
				{
					Parameters =
					{
						["Source"] = source,
					}
				});
			}

			/// <summary>
			/// CloseOpportunity
			/// </summary>
			/// <param name="service"></param>
			/// <param name="opportunityId"></param>
			/// <param name="status"></param>
			/// <param name="actualRevenue"></param>
			/// <param name="competitorId"></param>
			/// <param name="closeDate"></param>
			/// <param name="description"></param>
			public static void CloseOpportunity(in IOrganizationService service, EntityReference opportunityId, OptionSetValue status, Money actualRevenue, EntityReference competitorId, DateTime closeDate, string description)
			{
				service.Execute(new OrganizationRequest("CloseOpportunity")
				{
					Parameters =
					{
						["OpportunityId"] = opportunityId,
						["Status"] = status,
						["ActualRevenue"] = actualRevenue,
						["CompetitorId"] = competitorId,
						["CloseDate"] = closeDate,
						["Description"] = description
					}
				});
			}

			/// <summary>
			/// ConfigureReportingDataConnector
			/// </summary>
			/// <param name="service"></param>
			/// <param name="dataProviderType"></param>
			public static void ConfigureReportingDataConnector(in IOrganizationService service, int dataProviderType)
			{
				service.Execute(new OrganizationRequest("ConfigureReportingDataConnector")
				{
					Parameters =
					{
						["DataProviderType"] = dataProviderType,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="activityId"></param>
			/// <param name="activityEntityName"></param>
			/// <param name="targetEntity"></param>
			/// <param name="targetEntityName"></param>
			/// <param name="createCampaignResponse"></param>
			/// <returns>RecordId</returns>
			public static Guid? ConvertActivity(in IOrganizationService service, Guid activityId, string activityEntityName, Entity targetEntity, string targetEntityName, bool createCampaignResponse)
			{
				var response = service.Execute(new OrganizationRequest("ConvertActivity")
				{
					Parameters =
					{
						["ActivityId"] = activityId,
						["ActivityEntityName"] = activityEntityName,
						["TargetEntity"] = targetEntity,
						["TargetEntityName"] = targetEntityName,
						["CreateCampaignResponse"] = createCampaignResponse
					}
				});

				if (response != null && response.Results.Contains("RecordId"))
				{
					return (Guid)response.Results["RecordId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// ConvertCampaignResponse
			/// </summary>
			/// <param name="service"></param>
			/// <param name="campaignResponse"></param>
			/// <param name="entityName"></param>
			/// <param name="createOpportunityForExistingCustomer"></param>
			/// <param name="customer"></param>
			/// <param name="currency"></param>
			/// <param name="owner"></param>
			/// <returns>EntityReference</returns>
			public static EntityReference ConvertCampaignResponse(in IOrganizationService service, EntityReference campaignResponse, string entityName, bool createOpportunityForExistingCustomer,
				EntityReference customer, EntityReference currency, EntityReference owner)
			{
				var response = service.Execute(new OrganizationRequest("ConvertCampaignResponse")
				{
					Parameters =
					{
						["CampaignResponse"] = campaignResponse,
						["EntityName"] = entityName,
						["CreateOpportunityForExistingCustomer"] = createOpportunityForExistingCustomer,
						["Customer"] = customer,
						["Currency"] = currency,
						["Owner"] = owner,
					}
				});

				if (response != null && response.Results.Contains("EntityReference"))
				{
					return (EntityReference)response.Results["EntityReference"]; // Microsoft.Xrm.Sdk.EntityReference
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CopySharePointDocuments
			/// </summary>
			/// <param name="service"></param>
			/// <param name="destinationLocation"></param>
			/// <param name="absoluteUrls"></param>
			/// <param name="relativeUrls"></param>
			/// <param name="source"></param>
			/// <returns>Status</returns>
			public static string CopySharePointDocuments(in IOrganizationService service, string destinationLocation, string[] absoluteUrls, string[] relativeUrls, string source)
			{
				var response = service.Execute(new OrganizationRequest("CopySharePointDocuments")
				{
					Parameters =
					{
						["DestinationLocation"] = destinationLocation,
						["AbsoluteUrls"] = absoluteUrls,
						["RelativeUrls"] = relativeUrls,
						["Source"] = source,
					}
				});

				if (response != null && response.Results.Contains("Status"))
				{
					return (string)response.Results["Status"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CreateAndAssociate
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="regardingObjectTypeCode"></param>
			/// <param name="associationRelationshipName"></param>
			/// <param name="article"></param>
			public static void CreateAndAssociate(in IOrganizationService service, Guid regardingObjectId, int regardingObjectTypeCode, string associationRelationshipName, Entity article)
			{
				var response = service.Execute(new OrganizationRequest("CreateAndAssociate")
				{
					Parameters =
					{
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["AssociationRelationshipName"] = associationRelationshipName,
						["Article"] = article,
					}
				});
			}

			/// <summary>
			/// CreateDocumentLibraries
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentLibraryNames"></param>
			/// <param name="url"></param>
			/// <returns>DocumentLibraryResult</returns>
			public static string CreateDocumentLibraries(in IOrganizationService service, string documentLibraryNames, string url)
			{
				var response = service.Execute(new OrganizationRequest("CreateDocumentLibraries")
				{
					Parameters =
					{
						["DocumentLibraryNames"] = documentLibraryNames,
						["Url"] = url,
					}
				});

				if (response != null && response.Results.Contains("DocumentLibraryResult"))
				{
					return (string)response.Results["DocumentLibraryResult"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CreateEmailReplyDraft
			/// </summary>
			/// <param name="service"></param>
			/// <param name="messageId"></param>
			/// <param name="replyText"></param>
			/// <returns>MailWebLink</returns>
			public static string CreateEmailReplyDraft(in IOrganizationService service, string messageId, string replyText)
			{
				var response = service.Execute(new OrganizationRequest("CreateEmailReplyDraft")
				{
					Parameters =
					{
						["MessageId"] = messageId,
						["ReplyText"] = replyText,
					}
				});

				if (response != null && response.Results.Contains("MailWebLink"))
				{
					return (string)response.Results["MailWebLink"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderName"></param>
			/// <param name="regardingObjectType"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="documentType"></param>
			/// <param name="parentLocationId"></param>
			/// <param name="siteType"></param>
			/// <param name="validateFolder"></param>
			/// <returns>LocationId</returns>
			public static Guid? CreateFolder(in IOrganizationService service, string folderName, int regardingObjectType, string regardingObjectId,
				int documentType, string parentLocationId, int siteType, bool validateFolder)
			{
				var response = service.Execute(new OrganizationRequest("CreateFolder")
				{
					Parameters =
					{
						["FolderName"] = folderName,
						["RegardingObjectType"] = regardingObjectType,
						["RegardingObjectId"] = regardingObjectId,
						["DocumentType"] = documentType,
						["ParentLocationId"] = parentLocationId,
						["SiteType"] = siteType,
						["ValidateFolder"] = validateFolder,
					}
				});

				if (response != null && response.Results.Contains("LocationId"))
				{
					return (Guid)response.Results["LocationId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// CreateFolderAndNewDocuments
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderName"></param>
			/// <param name="fileNameList"></param>
			/// <param name="regardingObjectType"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="locationType"></param>
			/// <param name="parentLocationId"></param>
			/// <returns>LocationId</returns>
			public static Guid? CreateFolderAndNewDocuments(in IOrganizationService service, string folderName, string[] fileNameList,
				int regardingObjectType, string regardingObjectId, int locationType, string parentLocationId)
			{
				var response = service.Execute(new OrganizationRequest("CreateFolderAndNewDocuments")
				{
					Parameters =
					{
						["FolderName"] = folderName,
						["FileNameList"] = fileNameList,
						["RegardingObjectType"] = regardingObjectType,
						["RegardingObjectId"] = regardingObjectId,
						["LocationType"] = locationType,
						["ParentLocationId"] = parentLocationId
					}
				});

				if (response != null && response.Results.Contains("LocationId"))
				{
					return (Guid)response.Results["LocationId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="wizardXml"></param>
			/// <param name="isOrgReport"></param>
			/// <returns>id</returns>
			public static Guid? CreateFromTemplate(in IOrganizationService service, string wizardXml, bool isOrgReport)
			{
				var response = service.Execute(new OrganizationRequest("CreateFromTemplate")
				{
					Parameters =
					{
						["WizardXml"] = wizardXml,
						["IsOrgReport"] = isOrgReport,
					}
				});

				if (response != null && response.Results.Contains("id"))
				{
					return (Guid)response.Results["id"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="mapXml"></param>
			/// <param name="colMappingIdsToDelete"></param>
			/// <returns>ImportMapId</returns>
			public static Guid? CreateOrUpdateImportMapFromApp(in IOrganizationService service, string mapXml, params Guid[] colMappingIdsToDelete)
			{
				var response = service.Execute(new OrganizationRequest("CreateOrUpdateImportMapFromApp")
				{
					Parameters =
					{
						["MapXml"] = mapXml,
						["ColMappingIdsToDelete"] = colMappingIdsToDelete,
					}
				});

				if (response != null && response.Results.Contains("ImportMapId"))
				{
					return (Guid)response.Results["ImportMapId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <returns></returns>
			public static Guid? CreateOutlookSubscriptionSubscriptionClients(in IOrganizationService service, Entity target)
			{
				var response = service.Execute(new OrganizationRequest("CreateOutlookSubscriptionSubscriptionClients")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("id"))
				{
					return (Guid)response.Results["id"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityLogicalName"></param>
			public static void CreatePostRelationships(in IOrganizationService service, string entityLogicalName)
			{
				var response = service.Execute(new OrganizationRequest("CreatePostRelationships")
				{
					Parameters =
					{
						["EntityLogicalName"] = entityLogicalName,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entities"></param>
			/// <param name="parentEntity"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection CreateProducts(in IOrganizationService service, EntityCollection entities, Entity parentEntity)
			{
				var response = service.Execute(new OrganizationRequest("CreateProducts")
				{
					Parameters =
					{
						["Entities"] = entities,
						["ParentEntity"] = parentEntity,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="recommendationModelId"></param>
			/// <param name="target"></param>
			/// <returns>id</returns>
			public static Guid? CreateRecommendationModelVersion(in IOrganizationService service, Guid recommendationModelId, Entity target)
			{
				var response = service.Execute(new OrganizationRequest("CreateRecommendationModelVersion")
				{
					Parameters =
					{
						["RecommendationModelId"] = recommendationModelId,
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("id"))
				{
					return (Guid)response.Results["id"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="reportId"></param>
			/// <param name="scheduleXml"></param>
			/// <param name="parameterXml"></param>
			/// <param name="scheduledReportName"></param>
			/// <returns>id</returns>
			public static Guid? CreateSchedule(in IOrganizationService service, Guid reportId, string scheduleXml, string parameterXml, string scheduledReportName)
			{
				var response = service.Execute(new OrganizationRequest("CreateSchedule")
				{
					Parameters =
					{
						["ReportId"] = reportId,
						["ScheduleXml"] = scheduleXml,
						["ParameterXml"] = parameterXml,
						["ScheduledReportName"] = scheduledReportName,
					}
				});

				if (response != null && response.Results.Contains("id"))
				{
					return (Guid)response.Results["id"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="DocumentLibraryNames"></param>
			/// <param name="Url"></param>
			/// <returns>Status</returns>
			public static string[] CreateSharePointDocumentLibraries(in IOrganizationService service, string[] DocumentLibraryNames, string Url)
			{
				var response = service.Execute(new OrganizationRequest("CreateSharePointDocumentLibraries")
				{
					Parameters =
					{
						["DocumentLibraryNames"] = DocumentLibraryNames,
						["Url"] = Url,
					}
				});

				if (response != null && response.Results.Contains("Status"))
				{
					return (string[])response.Results["Status"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderName"></param>
			/// <param name="path"></param>
			/// <param name="documentLibrary"></param>
			/// <param name="siteUrl"></param>
			/// <param name="isNoteBookFolder"></param>
			public static void CreateSharePointFolder(in IOrganizationService service, string folderName, string path, string documentLibrary,
				string siteUrl, bool isNoteBookFolder)
			{
				var response = service.Execute(new OrganizationRequest("CreateSharePointFolder")
				{
					Parameters =
					{
						["FolderName"] = folderName,
						["Path"] = path,
						["DocumentLibrary"] = documentLibrary,
						["SiteUrl"] = siteUrl,
						["IsNoteBookFolder"] = isNoteBookFolder,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderName"></param>
			/// <param name="path"></param>
			/// <param name="documentLibrary"></param>
			/// <param name="siteUrl"></param>
			/// <param name="isNoteBookFolder"></param>
			/// <param name="fileName"></param>
			/// <param name="documentContents"></param>
			/// <returns></returns>
			public static string[] CreateSharePointFolderAndUploadDocuments(in IOrganizationService service, string folderName, string path, string documentLibrary,
				string siteUrl, bool isNoteBookFolder, string[] fileName, string[] documentContents)
			{
				var response = service.Execute(new OrganizationRequest("CreateSharePointFolderAndUploadDocuments")
				{
					Parameters =
					{
						["FolderName"] = folderName,
						["Path"] = path,
						["DocumentLibrary"] = documentLibrary,
						["SiteUrl"] = siteUrl,
						["IsNoteBookFolder"] = isNoteBookFolder,
						["FileName"] = fileName,
						["DocumentContents"] = documentContents,
					}
				});

				if (response != null && response.Results.Contains("FileEditUrls"))
				{
					return (string[])response.Results["FileEditUrls"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			public static void CreateSubscriptionSyncInfo(in IOrganizationService service, Entity target)
			{
				var response = service.Execute(new OrganizationRequest("CreateSubscriptionSyncInfo")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="importMap"></param>
			/// <param name="columnMappings"></param>
			/// <param name="pickListMappings"></param>
			/// <param name="lookUpMappings"></param>
			/// <param name="ownerMappings"></param>
			/// <param name="transformationMappings"></param>
			/// <param name="transformationParameterMappings"></param>
			/// <returns>Id</returns>
			public static Guid? CreateWithMappingImportMap(in IOrganizationService service, Entity importMap, EntityCollection columnMappings, EntityCollection pickListMappings,
				EntityCollection lookUpMappings, EntityCollection ownerMappings, EntityCollection transformationMappings, EntityCollection transformationParameterMappings)
			{
				var response = service.Execute(new OrganizationRequest("CreateWithMappingImportMap")
				{
					Parameters =
					{
						["ImportMap"] = importMap,
						["ColumnMappings"] = columnMappings,
						["PickListMappings"] = pickListMappings,
						["LookUpMappings"] = lookUpMappings,
						["OwnerMappings"] = ownerMappings,
						["TransformationMappings"] = transformationMappings,
						["TransformationParameterMappings"] = transformationParameterMappings,
					}
				});

				if (response != null && response.Results.Contains("Id"))
				{
					return (Guid)response.Results["Id"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			///// <summary>
			///// Applies On CRM 2015
			///// </summary>
			///// <param name="service"></param>
			///// <param name="cacheName"></param>
			///// <returns>CacheItems</returns>
			//public static Microsoft.Crm.Sdk.Messages.CacheItem[] DebugCacheGetContents(in IOrganizationService service, string cacheName)
			//{
			//    var response = service.Execute(new OrganizationRequest("DebugCacheGetContents")
			//    {
			//        Parameters =
			//        {
			//            ["CacheName"] = cacheName,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("CacheItems"))
			//    {
			//        return (Microsoft.Crm.Sdk.Messages.CacheItem[])response.Results["CacheItems"]; // Microsoft.Crm.Sdk.Messages.CacheItem
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="cacheName"></param>
			/// <param name="outputFormat"></param>
			/// <param name="includeLogs"></param>
			/// <returns>CacheSizeDetails</returns>
			public static string DebugCacheGetSize(in IOrganizationService service, string cacheName, string outputFormat, bool includeLogs)
			{
				var response = service.Execute(new OrganizationRequest("DebugCacheGetSize")
				{
					Parameters =
					{
						["CacheName"] = cacheName,
						["OutputFormat"] = outputFormat,
						["IncludeLogs"] = includeLogs,
					}
				});

				if (response != null && response.Results.Contains("CacheSizeDetails"))
				{
					return (string)response.Results["CacheSizeDetails"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="cacheName"></param>
			public static void DebugFlushCache(in IOrganizationService service, string cacheName)
			{
				var response = service.Execute(new OrganizationRequest("DebugFlushCache")
				{
					Parameters =
					{
						["CacheName"] = cacheName,
					}
				});
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="faultType"></param>
			//public static void DebugGenerateFault(in IOrganizationService service, Microsoft.Crm.Sdk.Messages.FaultType faultType)
			//{
			//    var response = service.Execute(new OrganizationRequest("DebugGenerateFault")
			//    {
			//        Parameters =
			//        {
			//            ["FaultType"] = faultType,
			//        }
			//    });
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="webRequestId"></param>
			/// <returns>PerformanceResult</returns>
			public static string DebugRetrievePipelinePerformanceResult(in IOrganizationService service, Guid webRequestId)
			{
				var response = service.Execute(new OrganizationRequest("DebugRetrievePipelinePerformanceResult")
				{
					Parameters =
					{
						["WebRequestId"] = webRequestId,
					}
				});

				if (response != null && response.Results.Contains("PerformanceResult"))
				{
					return (string)response.Results["PerformanceResult"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>TraceBuffer, TraceBufferSizeSetting</returns>
			public static (string[], int?) DebugTraceBufferGetContents(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("DebugTraceBufferGetContents"));

				if (response != null && response.Results.Contains("TraceBuffer") && response.Results.Contains("TraceBufferSizeSetting"))
				{
					return ((string[])response.Results["TraceBuffer"], (int)response.Results["TraceBufferSizeSetting"]); // System.String[], System.Int32
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entities"></param>
			public static void DeleteDocument(in IOrganizationService service, EntityCollection entities)
			{
				var response = service.Execute(new OrganizationRequest("DeleteDocument")
				{
					Parameters =
					{
						["Entities"] = entities,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <returns>IsModelDeletedInAzure</returns>
			public static bool? DeleteRecommendationModel(in IOrganizationService service, EntityReference target)
			{
				var response = service.Execute(new OrganizationRequest("DeleteRecommendationModel")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("IsModelDeletedInAzure"))
				{
					return (bool)response.Results["IsModelDeletedInAzure"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <returns>IsBuildIdDeletedInAzure</returns>
			public static bool? DeleteRecommendationModelVersion(in IOrganizationService service, EntityReference target)
			{
				var response = service.Execute(new OrganizationRequest("DeleteRecommendationModelVersion")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("IsBuildIdDeletedInAzure"))
				{
					return (bool)response.Results["IsBuildIdDeletedInAzure"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentIds"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			public static void DeleteSharePointDocument(in IOrganizationService service, string[] documentIds, string siteUrl, string documentLocation, string referencedEntity)
			{
				var response = service.Execute(new OrganizationRequest("DeleteSharePointDocument")
				{
					Parameters =
					{
						["DocumentIds"] = documentIds,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});
			}

			public static void DisassociateKnowledgeArticle(in IOrganizationService service, Guid regardingObjectId, int regardingObjectTypeCode,
				string associationRelationshipName, Guid knowledgeArticleId)
			{
				var response = service.Execute(new OrganizationRequest("DisassociateKnowledgeArticle")
				{
					Parameters =
					{
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["AssociationRelationshipName"] = associationRelationshipName,
						["KnowledgeArticleId"] = knowledgeArticleId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			public static void DiscardDocumentCheckout(in IOrganizationService service, Entity entity)
			{
				var response = service.Execute(new OrganizationRequest("DiscardDocumentCheckout")
				{
					Parameters =
					{
						["Entity"] = entity,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentId"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			public static void DiscardSharePointDocumentCheckout(in IOrganizationService service, string documentId, string siteUrl, string documentLocation, string referencedEntity)
			{
				var response = service.Execute(new OrganizationRequest("DiscardSharePointDocumentCheckout")
				{
					Parameters =
					{
						["DocumentId"] = documentId,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			public static void EditDocumentProperties(in IOrganizationService service, Entity entity)
			{
				service.Execute(new OrganizationRequest("EditDocumentProperties")
				{
					Parameters =
					{
						["Entity"] = entity,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentId"></param>
			/// <param name="fullName"></param>
			/// <param name="title"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			public static void EditSharePointDocumentProperties(in IOrganizationService service, string documentId, string fullName, string title, string siteUrl, string documentLocation, string referencedEntity)
			{
				var response = service.Execute(new OrganizationRequest("EditSharePointDocumentProperties")
				{
					Parameters =
					{
						["DocumentId"] = documentId,
						["FullName"] = fullName,
						["Title"] = title,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});
			}

			public static void EnableNewFormsForAllUsers(in IOrganizationService service)
			{
				service.Execute(new OrganizationRequest("EnableNewFormsForAllUsers"));
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="queryingUnitId"></param>
			/// <param name="actionName"></param>
			public static void ExecuteDataPerformanceAction(in IOrganizationService service, Guid queryingUnitId, string actionName)
			{
				service.Execute(new OrganizationRequest("ExecuteDataPerformanceAction")
				{
					Parameters =
					{
						["QueryingUnitId"] = queryingUnitId,
						["ActionName"] = actionName,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="searchText"></param>
			/// <param name="entityGroupName"></param>
			/// <param name="entityNames"></param>
			/// <returns>Result</returns>
			public static Microsoft.Xrm.Sdk.QuickFindResultCollection ExecuteQuickFind(in IOrganizationService service, string searchText, string entityGroupName, params string[] entityNames)
			{
				var response = service.Execute(new OrganizationRequest("ExecuteQuickFind")
				{
					Parameters =
					{
						["SearchText"] = searchText,
						["EntityGroupName"] = entityGroupName,
						["EntityNames"] = entityNames,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (Microsoft.Xrm.Sdk.QuickFindResultCollection)response.Results["Result"]; // Microsoft.Xrm.Sdk.QuickFindResultCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="expansionTaskId"></param>
			public static void ExpandWorkflows(in IOrganizationService service, Guid expansionTaskId)
			{
				var response = service.Execute(new OrganizationRequest("ExpandWorkflows")
				{
					Parameters =
					{
						["ExpansionTaskId"] = expansionTaskId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="view"></param>
			/// <param name="fetchXml"></param>
			/// <param name="layoutXml"></param>
			/// <param name="exportType"></param>
			/// <param name="postData"></param>
			/// <param name="isRefresh"></param>
			/// <param name="queryApi"></param>
			/// <param name="queryParameters"></param>
			/// <returns>ExcelFile</returns>
			public static byte[] ExportDynamicToExcel(in IOrganizationService service, EntityReference view, string fetchXml, string layoutXml,
				ExportDynamicToExcelType exportType, string postData, bool isRefresh, string queryApi, InputArgumentCollection queryParameters)
			{
				var response = service.Execute(new OrganizationRequest("ExportDynamicToExcel")
				{
					Parameters =
					{
						["View"] = view,
						["FetchXml"] = fetchXml,
						["LayoutXml"] = layoutXml,
						["ExportType"] = exportType,
						["PostData"] = postData,
						["IsRefresh"] = isRefresh,
						["QueryApi"] = queryApi,
						["QueryParameters"] = queryParameters,
					}
				});

				if (response != null && response.Results.Contains("ExcelFile"))
				{
					return (byte[])response.Results["ExcelFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="solutionName"></param>
			/// <returns>ExportSolutionFile</returns>
			public static byte[] ExportFullSolution(in IOrganizationService service, string solutionName)
			{
				var response = service.Execute(new OrganizationRequest("ExportFullSolution")
				{
					Parameters =
					{
						["SolutionName"] = solutionName,
					}
				});

				if (response != null && response.Results.Contains("ExportSolutionFile"))
				{
					return (byte[])response.Results["ExportSolutionFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="importMapId"></param>
			/// <returns>MappingsXml</returns>
			public static string ExportLinearMappingsImportMap(in IOrganizationService service, Guid importMapId)
			{
				var response = service.Execute(new OrganizationRequest("ExportLinearMappingsImportMap")
				{
					Parameters =
					{
						["ImportMapId"] = importMapId,
					}
				});

				if (response != null && response.Results.Contains("MappingsXml"))
				{
					return (string)response.Results["MappingsXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityLocalizedDisplayName"></param>
			/// <param name="layoutXml"></param>
			/// <param name="fetchXml"></param>
			/// <returns>ExcelFile</returns>
			public static byte[] ExportTemplateToExcel(in IOrganizationService service, string entityLocalizedDisplayName, string layoutXml, string fetchXml)
			{
				var response = service.Execute(new OrganizationRequest("ExportTemplateToExcel")
				{
					Parameters =
					{
						["EntityLocalizedDisplayName"] = entityLocalizedDisplayName,
						["LayoutXml"] = layoutXml,
						["FetchXml"] = fetchXml,
					}
				});

				if (response != null && response.Results.Contains("ExcelFile"))
				{
					return (byte[])response.Results["ExcelFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="template"></param>
			/// <param name="fetchXml"></param>
			/// <param name="queryApi"></param>
			/// <param name="queryParameters"></param>
			/// <returns>EditLink</returns>
			public static string ExportTemplateToExcelOnline(in IOrganizationService service, EntityReference template, string fetchXml, string queryApi, InputArgumentCollection queryParameters)
			{
				var response = service.Execute(new OrganizationRequest("ExportTemplateToExcelOnline")
				{
					Parameters =
					{
						["Template"] = template,
						["FetchXml"] = fetchXml,
						["QueryApi"] = queryApi,
						["QueryParameters"] = queryParameters,
					}
				});

				if (response != null && response.Results.Contains("EditLink"))
				{
					return (string)response.Results["EditLink"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityTypeCode"></param>
			/// <param name="selectedEntities"></param>
			/// <retruens>WordFile</retruens>
			public static byte[] ExportTemplateToWord(in IOrganizationService service, int entityTypeCode, string selectedEntities)
			{
				var response = service.Execute(new OrganizationRequest("ExportTemplateToWord")
				{
					Parameters =
					{
						["EntityTypeCode"] = entityTypeCode,
						["SelectedEntities"] = selectedEntities,
					}
				});

				if (response != null && response.Results.Contains("WordFile"))
				{
					return (byte[])response.Results["WordFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="view">"savedquery" or "userquery" EntityReference</param></param>
			/// <param name="fetchXml"></param>
			/// <param name="layoutXml"></param>
			/// <param name="queryApi"></param>
			/// <param name="queryParameters"></param>
			/// <returns>ExcelFile</returns>
			public static byte[] ExportToExcel(in IOrganizationService service, EntityReference view, string fetchXml, string layoutXml, string queryApi = "", InputArgumentCollection queryParameters = null)
			{
				// Saved View = "userquery"
				// System View = "savedquery"
				queryParameters = queryParameters ?? new InputArgumentCollection();

				var response = service.Execute(new OrganizationRequest("ExportToExcel")
				{
					Parameters =
					{
						["View"] = view,
						["FetchXml"] = fetchXml,
						["LayoutXml"] = layoutXml,
						["QueryApi"] = queryApi,
						["QueryParameters"] = queryParameters,
					}
				});

				if (response != null && response.Results.Contains("ExcelFile"))
				{
					return (byte[])response.Results["ExcelFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="view"></param>
			/// <param name="fetchXml"></param>
			/// <param name="layoutXml"></param>
			/// <param name="queryApi"></param>
			/// <param name=""></param>
			/// <returns>EditLink</returns>
			public static string ExportToExcelOnline(in IOrganizationService service, EntityReference view, string fetchXml, string layoutXml, string queryApi, InputArgumentCollection queryParameters)
			{
				var response = service.Execute(new OrganizationRequest("ExportToExcelOnline")
				{
					Parameters =
					{
						["View"] = view,
						["FetchXml"] = fetchXml,
						["LayoutXml"] = layoutXml,
						["QueryApi"] = queryApi,
						["QueryParameters"] = queryParameters,
					}
				});

				if (response != null && response.Results.Contains("EditLink"))
				{
					return (string)response.Results["EditLink"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityTypeCode"></param>
			/// <param name="selectedTemplate"></param>
			/// <param name="selectedRecords"></param>
			/// <returns>WordFile</returns>
			public static byte[] ExportWordDocument(in IOrganizationService service, int entityTypeCode, EntityReference selectedTemplate, string selectedRecords)
			{
				var response = service.Execute(new OrganizationRequest("ExportWordDocument")
				{
					Parameters =
					{
						["EntityTypeCode"] = entityTypeCode,
						["SelectedTemplate"] = selectedTemplate,
						["SelectedRecords"] = selectedRecords,
					}
				});

				if (response != null && response.Results.Contains("WordFile"))
				{
					return (byte[])response.Results["WordFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentId"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="regardingObjType"></param>
			/// <returns></returns>
			public static string FetchSiteUrl(in IOrganizationService service, string documentId, string regardingObjectId, int regardingObjType)
			{
				var response = service.Execute(new OrganizationRequest("FetchSiteUrl")
				{
					Parameters =
					{
						["DocumentId"] = documentId,
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjType"] = regardingObjType,
					}
				});

				if (response != null && response.Results.Contains("SiteAndLocationUrl"))
				{
					return (string)response.Results["SiteAndLocationUrl"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="eventType"></param>
			/// <param name="eventData"></param>
			public static void FireNotificationEvent(in IOrganizationService service, int eventType, string eventData)
			{
				var response = service.Execute(new OrganizationRequest("FireNotificationEvent")
				{
					Parameters =
					{
						["EventType"] = eventType,
						["EventData"] = eventData,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			public static void FlushMetadataCache(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("FlushMetadataCache"));
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="activityMimeAttachmentId"></param>
			/// <returns>Response</returns>
			public static string FollowEmailAttachment(in IOrganizationService service, Guid activityMimeAttachmentId)
			{
				var response = service.Execute(new OrganizationRequest("FollowEmailAttachment")
				{
					Parameters =
					{
						["ActivityMimeAttachmentId"] = activityMimeAttachmentId,
					}
				});

				if (response != null && response.Results.Contains("Response"))
				{
					return (string)response.Results["Response"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			public static void FollowInYammer(in IOrganizationService service, Entity target)
			{
				var response = service.Execute(new OrganizationRequest("FollowInYammer")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="prefixName"></param>
			/// <param name="currentNumberName"></param>
			/// <param name="addSuffix"></param>
			/// <returns>GeneratedNumber</returns>
			public static string GenerateNumber(in IOrganizationService service, string prefixName, string currentNumberName, bool addSuffix)
			{
				var response = service.Execute(new OrganizationRequest("GenerateNumber")
				{
					Parameters =
					{
						["PrefixName"] = prefixName,
						["CurrentNumberName"] = currentNumberName,
						["AddSuffix"] = addSuffix,
					}
				});

				if (response != null && response.Results.Contains("GeneratedNumber"))
				{
					return (string)response.Results["GeneratedNumber"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="reportId"></param>
			public static void GenerateSnapshot(in IOrganizationService service, Guid reportId)
			{
				var response = service.Execute(new OrganizationRequest("GenerateSnapshot")
				{
					Parameters =
					{
						["ReportId"] = reportId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="date"></param>
			/// <returns>Result</returns>
			public static string GetActualDate(in IOrganizationService service, string date)
			{
				var response = service.Execute(new OrganizationRequest("GetActualDate")
				{
					Parameters =
					{
						["Date"] = date,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="associatedDocumentsRequestParams"></param>
			/// <returns>BusinessEntityCollection</returns>
			public static object GetAssociatedDocuments(in IOrganizationService service, string associatedDocumentsRequestParams)
			{
				var response = service.Execute(new OrganizationRequest("GetAssociatedDocuments")
				{
					Parameters =
					{
						["AssociatedDocumentsRequestParams"] = associatedDocumentsRequestParams,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntityCollection"))
				{
					return (object)response.Results["BusinessEntityCollection"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="connectionType"></param>
			/// <returns>ConnectionId</returns>
			public static Guid? GetAzureServiceConnectionIdByType(in IOrganizationService service, int connectionType)
			{
				var response = service.Execute(new OrganizationRequest("GetAzureServiceConnectionIdByType")
				{
					Parameters =
					{
						["ConnectionType"] = connectionType,
					}
				});

				if (response != null && response.Results.Contains("ConnectionId"))
				{
					return (Guid)response.Results["ConnectionId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="activityIds"></param>
			/// <returns>Subjects</returns>
			public static string[] GetCommitmentSubjects(in IOrganizationService service, params Guid[] activityIds)
			{
				var response = service.Execute(new OrganizationRequest("GetCommitmentSubjects")
				{
					Parameters =
					{
						["ActivityIds"] = activityIds,
					}
				});

				if (response != null && response.Results.Contains("Subjects"))
				{
					return (string[])response.Results["Subjects"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="customizationFile"></param>
			/// <returns>GetComponents</returns>
			public static string GetComponents(in IOrganizationService service, byte[] customizationFile)
			{
				var response = service.Execute(new OrganizationRequest("GetComponents")
				{
					Parameters =
					{
						["CustomizationFile"] = customizationFile,
					}
				});

				if (response != null && response.Results.Contains("GetComponents"))
				{
					return (string)response.Results["GetComponents"]; // System.string
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="entityId"></param>
			/// <returns>ServerDateTime</returns>
			public static string GetCurrentServerDateTimeInUtc(in IOrganizationService service, string entityName, string entityId)
			{
				var response = service.Execute(new OrganizationRequest("GetCurrentServerDateTimeInUtc")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["EntityId"] = entityId,
					}
				});

				if (response != null && response.Results.Contains("ServerDateTime"))
				{
					return (string)response.Results["ServerDateTime"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="filter"></param>
			/// <returns>Topics</returns>
			public static string GetDataForTopicWordCloud(in IOrganizationService service, string filter)
			{
				var response = service.Execute(new OrganizationRequest("GetDataForTopicWordCloud")
				{
					Parameters =
					{
						["Filter"] = filter,
					}
				});

				if (response != null && response.Results.Contains("Topics"))
				{
					return (string)response.Results["Topics"]; // System.String
				}
				else
				{
					return null;
				}
			}

			public static string GetDefaultDocumentLibrary(in IOrganizationService service, string siteUrl)
			{
				var response = service.Execute(new OrganizationRequest("GetDefaultDocumentLibrary")
				{
					Parameters =
					{
						["SiteUrl"] = siteUrl,
					}
				});

				if (response != null && response.Results.Contains("DefaultDocumentLibrary"))
				{
					return (string)response.Results["DefaultDocumentLibrary"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="trackingId"></param>
			/// <param name="conversationTrackingId"></param>
			/// <param name="clientType"></param>
			/// <param name="emailLinkUrls"></param>
			/// <returns>EmailLinkTrackingUrls</returns>
			public static string[] GetEmailLinkTrackingUrls(in IOrganizationService service, Guid trackingId, Guid conversationTrackingId, string clientType, string[] emailLinkUrls)
			{
				var response = service.Execute(new OrganizationRequest("GetEmailLinkTrackingUrls")
				{
					Parameters =
					{
						["TrackingId"] = trackingId,
						["ConversationTrackingId"] = conversationTrackingId,
						["ClientType"] = clientType,
						["EmailLinkUrls"] = emailLinkUrls,
					}
				});

				if (response != null && response.Results.Contains("EmailLinkTrackingUrls"))
				{
					return (string[])response.Results["EmailLinkTrackingUrls"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="trackingId"></param>
			/// <param name="conversationTrackingId"></param>
			/// <param name="clientType"></param>
			/// <returns>EmailTrackingPixelUrl</returns>
			public static string GetEmailTrackingPixelUrl(in IOrganizationService service, Guid trackingId, Guid conversationTrackingId, string clientType)
			{
				var response = service.Execute(new OrganizationRequest("GetEmailTrackingPixelUrl")
				{
					Parameters =
					{
						["TrackingId"] = trackingId,
						["ConversationTrackingId"] = conversationTrackingId,
						["ClientType"] = clientType,
					}
				});

				if (response != null && response.Results.Contains("EmailTrackingPixelUrl"))
				{
					return (string)response.Results["EmailTrackingPixelUrl"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="filter"></param>
			/// <returns>Result</returns>
			public static string GetEntitiesForAzureML(in IOrganizationService service, string filter)
			{
				var response = service.Execute(new OrganizationRequest("GetEntitiesForAzureML")
				{
					Parameters =
					{
						["Filter"] = filter,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			/// <returns>DuplicatesCount, EntityLogicalNames</returns>
			public static (int[], string[]) GetEntityWiseDuplicatesCount(in IOrganizationService service, Entity entity)
			{
				var response = service.Execute(new OrganizationRequest("GetEntityWiseDuplicatesCount")
				{
					Parameters =
					{
						["Entity"] = entity,
					}
				});

				if (response != null && response.Results.Contains("DuplicatesCount") && response.Results.Contains("EntityLogicalNames"))
				{
					return ((int[])response.Results["DuplicatesCount"], (string[])response.Results["EntityLogicalNames"]); // System.Int32[], System.String[]
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="filter"></param>
			/// <returns>Result</returns>
			public static string GetFieldListForAzureML(in IOrganizationService service, string entityName, string filter)
			{
				var response = service.Execute(new OrganizationRequest("GetFieldListForAzureML")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["Filter"] = filter,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="campaignActivityId"></param>
			/// <returns>EntityType</returns>
			public static int? GetMailMergeTargetEntityType(in IOrganizationService service, Guid campaignActivityId)
			{
				var response = service.Execute(new OrganizationRequest("GetMailMergeTargetEntityType")
				{
					Parameters =
					{
						["CampaignActivityId"] = campaignActivityId,
					}
				});

				if (response != null && response.Results.Contains("EntityType"))
				{
					return (int)response.Results["EntityType"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="clientId"></param>
			///// <param name="entityName"></param>
			///// <param name="syncAction"></param>
			///// <param name="batchSize"></param>
			///// <param name="columnSetXml"></param>
			///// <returns>SyncDataXml</returns>
			//public static string GetOutlookSyncDataSubscriptionClients(in IOrganizationService service, Guid clientId, string entityName, Microsoft.Crm.Sdk.Messages.SyncAction syncAction, int batchSize, string columnSetXml)
			//{
			//    var response = service.Execute(new OrganizationRequest("GetOutlookSyncDataSubscriptionClients")
			//    {
			//        Parameters =
			//        {
			//            ["ClientId"] = clientId,
			//            ["EntityName"] = entityName,
			//            ["SyncAction"] = syncAction,
			//            ["BatchSize"] = batchSize,
			//            ["ColumnSetXml"] = columnSetXml,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("SyncDataXml"))
			//    {
			//        return (string)response.Results["SyncDataXml"]; // System.String
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>id</returns>
			public static Guid? GetRecommendationModelId(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("GetRecommendationModelId"));

				if (response != null && response.Results.Contains("id"))
				{
					return (Guid)response.Results["id"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="recommendationModelId"></param>
			/// <returns>BusinessEntity</returns>
			public static object GetRecommendationModelVersionOverLimit(in IOrganizationService service, Guid recommendationModelId)
			{
				var response = service.Execute(new OrganizationRequest("GetRecommendationModelVersionOverLimit")
				{
					Parameters =
					{
						["RecommendationModelId"] = recommendationModelId,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntity"))
				{
					return (object)response.Results["BusinessEntity"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="versionId"></param>
			/// <param name="itemIds"></param>
			/// <param name="numberOfResults"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection GetRecommendations(in IOrganizationService service, Guid versionId, Guid[] itemIds, int numberOfResults)
			{
				var response = service.Execute(new OrganizationRequest("GetRecommendations")
				{
					Parameters =
					{
						["VersionId"] = versionId,
						["ItemIds"] = itemIds,
						["NumberOfResults"] = numberOfResults,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="filter"></param>
			/// <returns>Result</returns>
			public static string GetRelationshipsForAzureML(in IOrganizationService service, string entityName, string filter)
			{
				var response = service.Execute(new OrganizationRequest("GetRelationshipsForAzureML")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["Filter"] = filter,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="reportId"></param>
			/// <returns>ParametersXml</returns>
			public static string GetReportParameters(in IOrganizationService service, Guid reportId)
			{
				var response = service.Execute(new OrganizationRequest("GetReportParameters")
				{
					Parameters =
					{
						["ReportId"] = reportId,
					}
				});

				if (response != null && response.Results.Contains("ParametersXml"))
				{
					return (string)response.Results["ParametersXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>ProvisioningStatus</returns>
			public static string GetRIProvisioningStatus(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("GetRIProvisioningStatus"));

				if (response != null && response.Results.Contains("ProvisioningStatus"))
				{
					return (string)response.Results["ProvisioningStatus"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>TenantEndpointUrl</returns>
			public static string GetRITenantEndpointUrl(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("GetRITenantEndpointUrl"));

				if (response != null && response.Results.Contains("TenantEndpointUrl"))
				{
					return (string)response.Results["TenantEndpointUrl"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="id"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection GetSimilarRecords(in IOrganizationService service, EntityReference id)
			{
				var response = service.Execute(new OrganizationRequest("GetSimilarRecords")
				{
					Parameters =
					{
						["Id"] = id,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="subscriptionId"></param>
			///// <param name="entityName"></param>
			///// <param name="syncAction"></param>
			///// <param name="batchSize"></param>
			///// <param name="columnSetXml"></param>
			///// <returns>SyncDataXml</returns>
			//public static string GetSyncDataSubscription(in IOrganizationService service, Guid subscriptionId, string entityName, Microsoft.Crm.Sdk.Messages.SyncAction syncAction, int batchSize, string columnSetXml)
			//{
			//    var response = service.Execute(new OrganizationRequest("GetSyncDataSubscription")
			//    {
			//        Parameters =
			//        {
			//            ["SubscriptionId"] = subscriptionId,
			//            ["EntityName"] = entityName,
			//            ["SyncAction"] = syncAction,
			//            ["BatchSize"] = batchSize,
			//            ["ColumnSetXml"] = columnSetXml,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("SyncDataXml"))
			//    {
			//        return (string)response.Results["SyncDataXml"]; // System.String
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>TrackingServiceBaseUrl</returns>
			public static string GetTrackingServiceBaseUrl(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("GetTrackingServiceBaseUrl"));

				if (response != null && response.Results.Contains("TrackingServiceBaseUrl"))
				{
					return (string)response.Results["TrackingServiceBaseUrl"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="columns"></param>
			/// <param name="ruleId"></param>
			/// <param name="pageSize"></param>
			/// <returns>UnprocessedRecords, VersionNumbers</returns>
			public static (EntityCollection, string[]) GetUnprocessedRecords(in IOrganizationService service, string entityName, string[] columns, Guid ruleId, int pageSize)
			{
				var response = service.Execute(new OrganizationRequest("GetUnprocessedRecords")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["Columns"] = columns,
						["RuleId"] = ruleId,
						["PageSize"] = pageSize,
					}
				});

				if (response != null && response.Results.Contains("UnprocessedRecords") && response.Results.Contains("VersionNumbers"))
				{
					return ((EntityCollection)response.Results["UnprocessedRecords"], (string[])response.Results["VersionNumbers"]); // Microsoft.Xrm.Sdk.EntityCollection, System.String[]
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="incidentId"></param>
			/// <param name="toStateCode"></param>
			/// <returns>Result</returns>
			public static int? GetValidStatusTransition(in IOrganizationService service, string incidentId, int toStateCode)
			{
				var response = service.Execute(new OrganizationRequest("GetValidStatusTransition")
				{
					Parameters =
					{
						["IncidentId"] = incidentId,
						["ToStateCode"] = toStateCode,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (int)response.Results["Result"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="MappingsXml"></param>
			/// <param name="ReplaceIds"></param>
			/// <returns>ImportMapId</returns>
			public static Guid? ImportLinearMappingsImportMap(in IOrganizationService service, string MappingsXml, bool ReplaceIds)
			{
				var response = service.Execute(new OrganizationRequest("ImportLinearMappingsImportMap")
				{
					Parameters =
					{
						["MappingsXml"] = MappingsXml,
						["ReplaceIds"] = ReplaceIds,
					}
				});

				if (response != null && response.Results.Contains("ImportMapId"))
				{
					return (Guid)response.Results["ImportMapId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="queueId"></param>
			/// <param name="viewId"></param>
			/// <param name="visualizationId"></param>
			/// <param name="interactionCentricFilterXml"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection IntersectRecordsWithQueueAndAggregate(in IOrganizationService service, Guid queueId, Guid viewId, Guid visualizationId, string interactionCentricFilterXml)
			{
				var response = service.Execute(new OrganizationRequest("IntersectRecordsWithQueueAndAggregate")
				{
					Parameters =
					{
						["QueueId"] = queueId,
						["ViewId"] = viewId,
						["VisualizationId"] = visualizationId,
						["InteractionCentricFilterXml"] = interactionCentricFilterXml,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="userId"></param>
			/// <returns>InvitationToken</returns>
			public static string InviteUser(in IOrganizationService service, Guid userId)
			{
				var response = service.Execute(new OrganizationRequest("InviteUser")
				{
					Parameters =
					{
						["UserId"] = userId,
					}
				});

				if (response != null && response.Results.Contains("InvitationToken"))
				{
					return (string)response.Results["InvitationToken"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="solutionName"></param>
			/// <returns>IsPartnerSolutionInstalled</returns>
			public static bool? IsPartnerSolutionInstalled(in IOrganizationService service, string solutionName)
			{
				var response = service.Execute(new OrganizationRequest("IsPartnerSolutionInstalled")
				{
					Parameters =
					{
						["SolutionName"] = solutionName,
					}
				});

				if (response != null && response.Results.Contains("IsPartnerSolutionInstalled"))
				{
					return (bool)response.Results["IsPartnerSolutionInstalled"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="clientId"></param>
			/// <returns>isPrimaryClient</returns>
			public static bool? IsPrimaryClientSubscriptionClients(in IOrganizationService service, Guid clientId)
			{
				var response = service.Execute(new OrganizationRequest("IsPrimaryClientSubscriptionClients")
				{
					Parameters =
					{
						["ClientId"] = clientId,
					}
				});

				if (response != null && response.Results.Contains("isPrimaryClient"))
				{
					return (bool)response.Results["isPrimaryClient"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="dataProviderType"></param>
			/// <returns>IsReportingDataConnectorInstalled</returns>
			public static bool? IsReportingDataConnectorInstalled(in IOrganizationService service, int dataProviderType)
			{
				var response = service.Execute(new OrganizationRequest("IsReportingDataConnectorInstalled")
				{
					Parameters =
					{
						["DataProviderType"] = dataProviderType,
					}
				});

				if (response != null && response.Results.Contains("IsReportingDataConnectorInstalled"))
				{
					return (bool)response.Results["IsReportingDataConnectorInstalled"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>IsWorkgroup</returns>
			public static bool? IsServerWorkgroup(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("IsServerWorkgroup"));

				if (response != null && response.Results.Contains("IsWorkgroup"))
				{
					return (bool)response.Results["IsWorkgroup"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="roleId"></param>
			/// <returns>SupportUserRole</returns>
			public static bool? IsSupportUserRole(in IOrganizationService service, Guid roleId)
			{
				var response = service.Execute(new OrganizationRequest("IsSupportUserRole")
				{
					Parameters =
					{
						["RoleId"] = roleId,
					}
				});

				if (response != null && response.Results.Contains("SupportUserRole"))
				{
					return (bool)response.Results["SupportUserRole"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="roleId"></param>
			/// <returns>SystemAdministratorRole</returns>
			public static bool? IsSystemAdministratorRole(in IOrganizationService service, Guid roleId)
			{
				var response = service.Execute(new OrganizationRequest("IsSystemAdministratorRole")
				{
					Parameters =
					{
						["RoleId"] = roleId,
					}
				});

				if (response != null && response.Results.Contains("SystemAdministratorRole"))
				{
					return (bool)response.Results["SystemAdministratorRole"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="reportId"></param>
			/// <returns>HistoryIds, CreatedDates</returns>
			public static (string[], DateTime[]) ListSnapshots(in IOrganizationService service, Guid reportId)
			{
				var response = service.Execute(new OrganizationRequest("ListSnapshots")
				{
					Parameters =
					{
						["ReportId"] = reportId,
					}
				});

				if (response != null && response.Results.Contains("HistoryIds") && response.Results.Contains("CreatedDates"))
				{
					return ((string[])response.Results["HistoryIds"], (DateTime[])response.Results["CreatedDates"]); // System.String[], System.DateTime[]
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="source"></param>
			public static void LogExternalResultsClicked(in IOrganizationService service, string source)
			{
				var response = service.Execute(new OrganizationRequest("LogExternalResultsClicked")
				{
					Parameters =
					{
						["Source"] = source,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="bulkOperationId"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="regardingObjectTypeCode"></param>
			/// <param name="errorCode"></param>
			/// <param name="message"></param>
			/// <param name="additionalInfo"></param>
			public static void LogFailureBulkOperation(in IOrganizationService service, Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode,
				int errorCode, string message, string additionalInfo)
			{
				service.Execute(new OrganizationRequest("LogFailureBulkOperation")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["ErrorCode"] = errorCode,
						["Message"] = message,
						["AdditionalInfo"] = additionalInfo,
					}
				});
			}

			public static void LogSuccessBulkOperation(in IOrganizationService service, Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode,
				Guid createdObjectId, int createdObjectTypeCode, string additionalInfo)
			{
				service.Execute(new OrganizationRequest("LogSuccessBulkOperation")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["CreatedObjectId"] = createdObjectId,
						["CreatedObjectTypeCode"] = createdObjectTypeCode,
						["AdditionalInfo"] = additionalInfo,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="siteUrl"></param>
			/// <param name="enableOneDrive"></param>
			public static void MigrateToS2S(in IOrganizationService service, string siteUrl, bool enableOneDrive)
			{
				service.Execute(new OrganizationRequest("MigrateToS2S")
				{
					Parameters =
					{
						["SiteUrl"] = siteUrl,
						["EnableOneDrive"] = enableOneDrive,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			public static void MobileOfflineDeprovision(in IOrganizationService service)
			{
				service.Execute(new OrganizationRequest("MobileOfflineDeprovision"));
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			public static void MobileOfflineProvision(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("MobileOfflineProvision"));
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="campaignActivityId"></param>
			/// <param name="propagate"></param>
			/// <param name="activityXml"></param>
			/// <param name="templateId"></param>
			/// <param name="ownershipOptions"></param>
			/// <param name="postWorkflowEvent"></param>
			/// <param name="owner"></param>
			/// <param name="sendEmail"></param>
			/// <param name="queueId"></param>
			/// <returns>BulkOperationId</returns>
			public static Guid? MyExecuteCampaignActivity(in IOrganizationService service, Guid campaignActivityId, bool propagate, string activityXml, Guid templateId,
				Microsoft.Crm.Sdk.Messages.PropagationOwnershipOptions ownershipOptions, bool postWorkflowEvent, EntityReference owner, bool sendEmail, Guid queueId)
			{
				var response = service.Execute(new OrganizationRequest("MyExecuteCampaignActivity")
				{
					Parameters =
					{
						["CampaignActivityId"] = campaignActivityId,
						["Propagate"] = propagate,
						["ActivityXml"] = activityXml,
						["TemplateId"] = templateId,
						["OwnershipOptions"] = ownershipOptions,
						["PostWorkflowEvent"] = postWorkflowEvent,
						["Owner"] = owner,
						["SendEmail"] = sendEmail,
						["QueueId"] = queueId,
					}
				});

				if (response != null && response.Results.Contains("BulkOperationId"))
				{
					return (Guid)response.Results["BulkOperationId"]; // System.Guid
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="currentEntityId"></param>
			/// <param name="currentEntityLogicalName"></param>
			/// <param name="nextEntityId"></param>
			/// <param name="nextEntityLogicalName"></param>
			/// <param name="newActiveStageId"></param>
			/// <param name="newTraversedPath"></param>
			/// <param name="processId"></param>
			/// <param name="processInstanceId"></param>
			public static void NavigateToNextEntity(in IOrganizationService service, Guid currentEntityId, string currentEntityLogicalName, Guid nextEntityId, string nextEntityLogicalName,
				Guid newActiveStageId, string newTraversedPath, Guid processId, Guid processInstanceId)
			{
				service.Execute(new OrganizationRequest("NavigateToNextEntity")
				{
					Parameters =
					{
						["CurrentEntityId"] = currentEntityId,
						["CurrentEntityLogicalName"] = currentEntityLogicalName,
						["NextEntityId"] = nextEntityId,
						["NextEntityLogicalName"] = nextEntityLogicalName,
						["NewActiveStageId"] = newActiveStageId,
						["NewTraversedPath"] = newTraversedPath,
						["ProcessId"] = processId,
						["ProcessInstanceId"] = processInstanceId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="fileName"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="regardingObjectTypeCode"></param>
			/// <param name="locationId"></param>
			/// <returns>EditLink</returns>
			public static string NewDocument(in IOrganizationService service, string fileName, string regardingObjectId, string regardingObjectTypeCode, string locationId)
			{
				var response = service.Execute(new OrganizationRequest("NewDocument")
				{
					Parameters =
					{
						["FileName"] = fileName,
						["RegardingObjectId"] = regardingObjectId,
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
						["LocationId"] = locationId,
					}
				});

				if (response != null && response.Results.Contains("EditLink"))
				{
					return (string)response.Results["EditLink"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObject"></param>
			/// <param name="dynamicPropertyCollection"></param>
			public static void OverrideDynamicProperties(in IOrganizationService service, EntityReference regardingObject, EntityCollection dynamicPropertyCollection)
			{
				service.Execute(new OrganizationRequest("OverrideDynamicProperties")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["DynamicPropertyCollection"] = dynamicPropertyCollection,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObject"></param>
			/// <param name="dynamicProperty"></param>
			/// <returns>Id, DynamicPropertyId</returns>
			public static (Guid?, Guid?) OverrideDynamicProperty(in IOrganizationService service, EntityReference regardingObject, EntityReference dynamicProperty)
			{
				var response = service.Execute(new OrganizationRequest("OverrideDynamicProperty")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["DynamicProperty"] = dynamicProperty,
					}
				});

				if (response != null && response.Results.Contains("Id") && response.Results.Contains("DynamicPropertyId"))
				{
					return ((Guid)response.Results["Id"], (Guid)response.Results["DynamicPropertyId"]); // System.Guid, System.Guid
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObject"></param>
			/// <param name="dynamicProperty"></param>
			/// <returns>Id, DynamicPropertyId</returns>
			public static (Guid?, Guid?) OverwriteDynamicProperty(in IOrganizationService service, EntityReference regardingObject, EntityReference dynamicProperty)
			{
				var response = service.Execute(new OrganizationRequest("OverwriteDynamicProperty")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["DynamicProperty"] = dynamicProperty,
					}
				});

				if (response != null && response.Results.Contains("Id") && response.Results.Contains("DynamicPropertyId"))
				{
					return ((Guid)response.Results["Id"], (Guid)response.Results["DynamicPropertyId"]); // System.Guid, System.Guid
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="userId"></param>
			/// <returns>Data</returns>
			public static string PopulateCard(in IOrganizationService service, Guid userId)
			{
				var response = service.Execute(new OrganizationRequest("PopulateCard")
				{
					Parameters =
					{
						["UserId"] = userId,
					}
				});

				if (response != null && response.Results.Contains("Data"))
				{
					return (string)response.Results["Data"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="itemId"></param>
			/// <returns>ShowAzureRecommendations</returns>
			public static bool? PopulateRecommendationCache(in IOrganizationService service, string entityName, Guid itemId)
			{
				var response = service.Execute(new OrganizationRequest("PopulateRecommendationCache")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["ItemId"] = itemId,
					}
				});

				if (response != null && response.Results.Contains("ShowAzureRecommendations"))
				{
					return (bool)response.Results["ShowAzureRecommendations"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="parentRecord"></param>
			/// <returns>ShowAzureRecommendations</returns>
			public static bool? PopulateRecommendationCacheForRecord(in IOrganizationService service, EntityReference parentRecord)
			{
				var response = service.Execute(new OrganizationRequest("PopulateRecommendationCacheForRecord")
				{
					Parameters =
					{
						["ParentRecord"] = parentRecord,
					}
				});

				if (response != null && response.Results.Contains("ShowAzureRecommendations"))
				{
					return (bool)response.Results["ShowAzureRecommendations"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			//public static void PostOutlookSyncSubscriptionClients(in IOrganizationService service, Guid clientId, string entityName, Microsoft.Crm.Sdk.Messages.SyncAction syncAction, int batchSize)
			//{
			//    var response = service.Execute(new OrganizationRequest("PostOutlookSyncSubscriptionClients")
			//    {
			//        Parameters =
			//        {
			//            ["ClientId"] = clientId,
			//            ["EntityName"] = entityName,
			//            ["SyncAction"] = syncAction,
			//            ["BatchSize"] = batchSize,
			//        }
			//    });
			//}

			//public static void PostSyncSubscription(in IOrganizationService service, Guid subscriptionId, string entityName, Microsoft.Crm.Sdk.Messages.SyncAction syncAction, int batchSize)
			//{
			//    var response = service.Execute(new OrganizationRequest("PostSyncSubscription")
			//    {
			//        Parameters =
			//        {
			//            ["SubscriptionId"] = subscriptionId,
			//            ["EntityName"] = entityName,
			//            ["SyncAction"] = syncAction,
			//            ["BatchSize"] = batchSize,
			//        }
			//    });
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="ClientId"></param>
			/// <param name="type"></param>
			/// <returns>SyncInfoXml</returns>
			public static string PrepareOutlookSyncSubscriptionClients(in IOrganizationService service, Guid clientId, int type)
			{
				var response = service.Execute(new OrganizationRequest("PrepareOutlookSyncSubscriptionClients")
				{
					Parameters =
					{
						["ClientId"] = clientId,
						["Type"] = type,
					}
				});

				if (response != null && response.Results.Contains("SyncInfoXml"))
				{
					return (string)response.Results["SyncInfoXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="subscriptionId"></param>
			/// <param name="type"></param>
			/// <returns>SyncInfoXml</returns>
			public static string PrepareSyncSubscription(in IOrganizationService service, Guid subscriptionId, int type)
			{
				var response = service.Execute(new OrganizationRequest("PrepareSyncSubscription")
				{
					Parameters =
					{
						["SubscriptionId"] = subscriptionId,
						["Type"] = type,
					}
				});

				if (response != null && response.Results.Contains("SyncInfoXml"))
				{
					return (string)response.Results["SyncInfoXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="bulkOperationId"></param>
			/// <param name="entity"></param>
			/// <param name="bulkOperationSource"></param>
			/// <returns>ProcessResult</returns>
			public static int? ProcessOneMemberBulkOperation(in IOrganizationService service, Guid bulkOperationId, Entity entity, int bulkOperationSource)
			{
				var response = service.Execute(new OrganizationRequest("ProcessOneMemberBulkOperation")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["Entity"] = entity,
						["BulkOperationSource"] = bulkOperationSource,
					}
				});

				if (response != null && response.Results.Contains("ProcessResult"))
				{
					return (int)response.Results["ProcessResult"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			public static void ProcessReplicationBacklog(in IOrganizationService service, EntityReference target)
			{
				service.Execute(new OrganizationRequest("ProcessReplicationBacklog")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="userId"></param>
			public static void PromoteToAdmin(in IOrganizationService service, Guid userId)
			{
				service.Execute(new OrganizationRequest("PromoteToAdmin")
				{
					Parameters =
					{
						["UserId"] = userId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="appModuleId"></param>
			public static void PublishAppModule(in IOrganizationService service, Guid appModuleId)
			{
				service.Execute(new OrganizationRequest("PublishAppModule")
				{
					Parameters =
					{
						["AppModuleId"] = appModuleId,
					}
				});
			}

			public static void PublishExternal(in IOrganizationService service, Guid reportId)
			{
				service.Execute(new OrganizationRequest("PublishExternal")
				{
					Parameters =
					{
						["ReportId"] = reportId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entity"></param>
			/// <param name="copyRelatedProductFromAssociatedPrimary"></param>
			/// <param name="copyRelatedCategoryFromAssociatedPrimary"></param>
			/// <param name="publishApprovedRelatedTranslations"></param>
			/// <returns>IsPublish</returns>
			public static bool? PublishKnowledgeArticle(in IOrganizationService service, Entity entity, bool copyRelatedProductFromAssociatedPrimary,
				bool copyRelatedCategoryFromAssociatedPrimary, bool publishApprovedRelatedTranslations)
			{
				var response = service.Execute(new OrganizationRequest("PublishKnowledgeArticle")
				{
					Parameters =
					{
						["Entity"] = entity,
						["CopyRelatedProductFromAssociatedPrimary"] = copyRelatedProductFromAssociatedPrimary,
						["CopyRelatedCategoryFromAssociatedPrimary"] = copyRelatedCategoryFromAssociatedPrimary,
						["PublishApprovedRelatedTranslations"] = publishApprovedRelatedTranslations,
					}
				});

				if (response != null && response.Results.Contains("IsPublish"))
				{
					return (bool)response.Results["IsPublish"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			public static void PublishResourceGroups(in IOrganizationService service)
			{
				service.Execute(new OrganizationRequest("PublishResourceGroups"));
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="PluginAssembly"></param>
			///// <param name="Steps"></param>
			///// <returns>PluginAssemblyId</returns>
			//public static Guid? RegisterSolution(in IOrganizationService service, Entity PluginAssembly, Microsoft.Crm.Sdk.Messages.SdkMessageProcessingStepRegistration[] Steps)
			//{
			//    var response = service.Execute(new OrganizationRequest("RegisterSolution")
			//    {
			//        Parameters =
			//        {
			//            ["PluginAssembly"] = PluginAssembly,
			//            ["Steps"] = Steps,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("PluginAssemblyId"))
			//    {
			//        return (Guid)response.Results["PluginAssemblyId"]; // System.Guid
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="clientId"></param>
			public static void RemoveClientFromSubscriptionSubscriptionClients(in IOrganizationService service, Guid clientId)
			{
				service.Execute(new OrganizationRequest("RemoveClientFromSubscriptionSubscriptionClients")
				{
					Parameters =
					{
						["ClientId"] = clientId,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObject"></param>
			/// <param name="dynamicProperty"></param>
			public static void RemoveDynamicProperty(in IOrganizationService service, EntityReference regardingObject, EntityReference dynamicProperty)
			{
				service.Execute(new OrganizationRequest("RemoveDynamicProperty")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["DynamicProperty"] = dynamicProperty,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="listId"></param>
			/// <param name="fetchXml"></param>
			/// <param name="keepReturned"></param>
			public static void RemoveMembersByFetchXmlList(in IOrganizationService service, Guid listId, string fetchXml, bool keepReturned)
			{
				service.Execute(new OrganizationRequest("RemoveMembersByFetchXmlList")
				{
					Parameters =
					{
						["ListId"] = listId,
						["FetchXml"] = fetchXml,
						["KeepReturned"] = keepReturned,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="siteUrl"></param>
			/// <param name="folderPath"></param>
			/// <param name="newFolderName"></param>
			public static void RenameFolderName(in IOrganizationService service, string siteUrl, string folderPath, string newFolderName)
			{
				service.Execute(new OrganizationRequest("RenameFolderName")
				{
					Parameters =
					{
						["SiteUrl"] = siteUrl,
						["FolderPath"] = folderPath,
						["NewFolderName"] = newFolderName,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderName"></param>
			public static void RenameFolderNameForOneDrive(in IOrganizationService service, string folderName)
			{
				service.Execute(new OrganizationRequest("RenameFolderNameForOneDrive")
				{
					Parameters =
					{
						["FolderName"] = folderName,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="template"></param>
			/// <param name="fetchXml"></param>
			/// <param name="queryApi"></param>
			/// <param name="queryParameters"></param>
			/// <returns>ExcelFile</returns>
			public static byte[] RenderTemplate(in IOrganizationService service, EntityReference template, string fetchXml, string queryApi = "", Microsoft.Crm.Sdk.Messages.InputArgumentCollection queryParameters = null)
			{
				var response = service.Execute(new OrganizationRequest("RenderTemplate")
				{
					Parameters =
					{
						["Template"] = template,
						["FetchXml"] = fetchXml,
						["QueryApi"] = queryApi,
						["QueryParameters"] = queryParameters,
					}
				});

				if (response != null && response.Results.Contains("ExcelFile"))
				{
					return (byte[])response.Results["ExcelFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="template"></param>
			/// <param name="view"></param>
			/// <returns>ExcelFile</returns>
			public static byte[] RenderTemplateFromView(in IOrganizationService service, EntityReference template, EntityReference view)
			{
				var response = service.Execute(new OrganizationRequest("RenderTemplateFromView")
				{
					Parameters =
					{
						["Template"] = template,
						["View"] = view,
					}
				});

				if (response != null && response.Results.Contains("ExcelFile"))
				{
					return (byte[])response.Results["ExcelFile"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			public static void ResetPerformanceReport(in IOrganizationService service)
			{
				service.Execute(new OrganizationRequest("ResetPerformanceReport"));
			}

			//public static void ResetSyncStateSubscription(in IOrganizationService service, Guid SubscriptionId, Microsoft.Crm.Sdk.Messages.ResetSyncStateInfo[] ResetSyncInfo)
			//{
			//    var response = service.Execute(new OrganizationRequest("ResetSyncStateSubscription")
			//    {
			//        Parameters =
			//        {
			//            ["SubscriptionId"] = SubscriptionId,
			//            ["ResetSyncInfo"] = ResetSyncInfo,
			//        }
			//    });
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="emailAddresses"></param>
			/// <param name="objectTypeCodes"></param>
			/// <returns>Entities</returns>
			public static EntityCollection ResolveEmailAddress(in IOrganizationService service, string emailAddresses, params int[] objectTypeCodes)
			{
				var response = service.Execute(new OrganizationRequest("ResolveEmailAddress")
				{
					Parameters =
					{
						["EmailAddresses"] = emailAddresses,
						["ObjectTypeCodes"] = objectTypeCodes,
					}
				});

				if (response != null && response.Results.Contains("Entities"))
				{
					return (EntityCollection)response.Results["Entities"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			public static void ResolveIncident(in IOrganizationService service, EntityReference incidentId, OptionSetValue status, int billableTime,
				string resolution, string remarks)
			{
				var response = service.Execute(new OrganizationRequest("ResolveIncident")
				{
					Parameters =
					{
						["IncidentId"] = incidentId,
						["Status"] = status,
						["BillableTime"] = billableTime,
						["Resolution"] = resolution,
						["Remarks"] = remarks,
					}
				});
			}

			public static void ResolveQuote(in IOrganizationService service, string subject, OptionSetValue status, EntityReference quoteId, string description, DateTime closeDate)
			{
				service.Execute(new OrganizationRequest("ResolveQuote")
				{
					Parameters =
					{
						["Subject"] = subject,
						["Status"] = status,
						["QuoteId"] = quoteId,
						["Description"] = description,
						["CloseDate"] = closeDate,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="clientId"></param>
			/// <param name="serverId"></param>
			/// <param name="tenant"></param>
			/// <returns>AccessToken</returns>
			public static string RetrieveAADAccessToken(in IOrganizationService service, string clientId, string serverId, string tenant)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveAADAccessToken")
				{
					Parameters =
					{
						["ClientId"] = clientId,
						["ServerId"] = serverId,
						["Tenant"] = tenant,
					}
				});

				if (response != null && response.Results.Contains("AccessToken"))
				{
					return (string)response.Results["AccessToken"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="RegardingObjectTypeCode"></param>
			/// <returns>Result</returns>
			public static string RetrieveAttributeList(in IOrganizationService service, int RegardingObjectTypeCode)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveAttributeList")
				{
					Parameters =
					{
						["RegardingObjectTypeCode"] = RegardingObjectTypeCode,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityTypeCode"></param>
			/// <param name="formId"></param>
			/// <param name="businessProcessId"></param>
			/// <param name="includeDraftRules"></param>
			/// <param name="detailGridTypeCollectionString"></param>
			/// <param name="isHomePage"></param>
			/// <param name="isAssociatedGrid"></param>
			/// <returns>BusinessRulesScript</returns>
			public static string RetrieveBusinessRulesForForm(in IOrganizationService service, int entityTypeCode, Guid formId, Guid businessProcessId, bool includeDraftRules, string detailGridTypeCollectionString,
				bool isHomePage, bool isAssociatedGrid)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveBusinessRulesForForm")
				{
					Parameters =
					{
						["EntityTypeCode"] = entityTypeCode,
						["FormId"] = formId,
						["BusinessProcessId"] = businessProcessId,
						["IncludeDraftRules"] = includeDraftRules,
						["DetailGridTypeCollectionString"] = detailGridTypeCollectionString,
						["IsHomePage"] = isHomePage,
						["IsAssociatedGrid"] = isAssociatedGrid,
					}
				});

				if (response != null && response.Results.Contains("BusinessRulesScript"))
				{
					return (string)response.Results["BusinessRulesScript"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="cardTypeId"></param>
			/// <param name="additionalParameter"></param>
			/// <returns>Data</returns>
			public static string RetrieveCardData(in IOrganizationService service, Guid cardTypeId, string additionalParameter)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveCardData")
				{
					Parameters =
					{
						["CardTypeId"] = cardTypeId,
						["AdditionalParameter"] = additionalParameter,
					}
				});

				if (response != null && response.Results.Contains("Data"))
				{
					return (string)response.Results["Data"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="ClientId"></param>
			/// <param name="ColumnSet"></param>
			/// <returns>Entity</returns>
			public static Entity RetrieveClientSubscriptionSubscriptionClients(in IOrganizationService service, Guid ClientId, ColumnSet ColumnSet)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveClientSubscriptionSubscriptionClients")
				{
					Parameters =
					{
						["ClientId"] = ClientId,
						["ColumnSet"] = ColumnSet,
					}
				});

				if (response != null && response.Results.Contains("Entity"))
				{
					return (Entity)response.Results["Entity"]; // Microsoft.Xrm.Sdk.Entity
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>Result</returns>
			public static string RetrieveCollation(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveCollation"));

				if (response != null && response.Results.Contains("Result"))
				{
					return (string)response.Results["Result"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="query"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveCustomersNotPlacedOrders(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase query)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveCustomersNotPlacedOrders")
				{
					Parameters =
					{
						["Query"] = query,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="systemUserId"></param>
			/// <param name="appModuleId"></param>
			/// <returns>SystemForms</returns>
			public static EntityReference RetrieveDashboardForms(in IOrganizationService service, Guid systemUserId, Guid appModuleId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveDashboardForms")
				{
					Parameters =
					{
						["SystemUserId"] = systemUserId,
						["AppModuleId"] = appModuleId,
					}
				});

				if (response != null && response.Results.Contains("SystemForms"))
				{
					return (EntityReference)response.Results["SystemForms"]; // Microsoft.Xrm.Sdk.EntityReferenceCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <param name="state"></param>
			/// <returns>Status</returns>
			public static OptionSetValue RetrieveDefaultStatusForState(in IOrganizationService service, string entityName, OptionSetValue state)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveDefaultStatusForState")
				{
					Parameters =
					{
						["EntityName"] = entityName,
						["State"] = state,
					}
				});

				if (response != null && response.Results.Contains("Status"))
				{
					return (OptionSetValue)response.Results["Status"]; // Microsoft.Xrm.Sdk.OptionSetValue
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="query"></param>
			/// <param name="allSitesAndLocations"></param>
			/// <param name="referencedEntity"></param>
			/// <param name="pageToken"></param>
			/// <param name="sharedDocuments"></param>
			/// <returns>BusinessEntityCollection</returns>
			public static object RetrieveDocumentsFromAllLocationsAndShared(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase query, string allSitesAndLocations, string referencedEntity, string pageToken, bool sharedDocuments)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveDocumentsFromAllLocationsAndShared")
				{
					Parameters =
					{
						["Query"] = query,
						["AllSitesAndLocations"] = allSitesAndLocations,
						["ReferencedEntity"] = referencedEntity,
						["PageToken"] = pageToken,
						["SharedDocuments"] = sharedDocuments,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntityCollection"))
				{
					return (object)response.Results["BusinessEntityCollection"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="EntityTypeCode"></param>
			/// <param name="DocumentType"></param>
			/// <returns>DocumentTemplateEntityCollection</returns>
			public static EntityCollection RetrieveDocumentTemplates(in IOrganizationService service, int EntityTypeCode, int DocumentType)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveDocumentTemplates")
				{
					Parameters =
					{
						["EntityTypeCode"] = EntityTypeCode,
						["DocumentType"] = DocumentType,
					}
				});

				if (response != null && response.Results.Contains("DocumentTemplateEntityCollection"))
				{
					return (EntityCollection)response.Results["DocumentTemplateEntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="outerQuery"></param>
			///// <param name="subQueries"></param>
			///// <returns>EntityCollection</returns>
			//public static EntityCollection RetrieveEntitiesForAggregateQuery(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase outerQuery, Microsoft.Crm.Sdk.Messages.QueryByEntityNameDictionary subQueries)
			//{
			//    var response = service.Execute(new OrganizationRequest("RetrieveEntitiesForAggregateQuery")
			//    {
			//        Parameters =
			//        {
			//            ["OuterQuery"] = outerQuery,
			//            ["SubQueries"] = subQueries,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("EntityCollection"))
			//    {
			//        return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="campaignActivityId"></param>
			/// <param name="EntityName"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveEntitiesToFilter(in IOrganizationService service, Guid campaignActivityId, string entityName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntitiesToFilter")
				{
					Parameters =
					{
						["CampaignActivityId"] = campaignActivityId,
						["EntityName"] = entityName,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="campaignActivityId"></param>
			/// <param name="query"></param>
			/// <param name="entityName"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveEntitiesToMailMerge(in IOrganizationService service, Guid campaignActivityId, Microsoft.Xrm.Sdk.Query.QueryBase query, string entityName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntitiesToMailMerge")
				{
					Parameters =
					{
						["CampaignActivityId"] = campaignActivityId,
						["Query"] = query,
						["EntityName"] = entityName,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			///// <summary>
			/////
			///// </summary>
			///// <param name="service"></param>
			///// <param name="clientId"></param>
			///// <param name="entityName"></param>
			///// <param name="syncAction"></param>
			///// <param name="batchSize"></param>
			///// <param name="columnSetXml"></param>
			///// <returns>EntityCollection</returns>
			//public static EntityCollection RetrieveEntitiesToSync(in IOrganizationService service, Guid clientId, string entityName, Microsoft.Crm.Sdk.Messages.SyncAction syncAction, int batchSize, string columnSetXml)
			//{
			//    var response = service.Execute(new OrganizationRequest("RetrieveEntitiesToSync")
			//    {
			//        Parameters =
			//        {
			//            ["ClientId"] = clientId,
			//            ["EntityName"] = entityName,
			//            ["SyncAction"] = syncAction,
			//            ["BatchSize"] = batchSize,
			//            ["ColumnSetXml"] = columnSetXml,
			//        }
			//    });

			//    if (response != null && response.Results.Contains("EntityCollection"))
			//    {
			//        return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
			//    }
			//    else
			//    {
			//        return null;
			//    }
			//}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="customerId"></param>
			/// <param name="primaryContactId"></param>
			/// <param name="productId"></param>
			/// <param name="query"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveEntitlementsForCase(in IOrganizationService service, string customerId, string primaryContactId, string productId, Microsoft.Xrm.Sdk.Query.QueryBase query)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntitlementsForCase")
				{
					Parameters =
					{
						["CustomerId"] = customerId,
						["PrimaryContactId"] = primaryContactId,
						["ProductId"] = productId,
						["Query"] = query,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObject"></param>
			/// <param name="forDraftRegarding"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveEntityDynamicPropertyDefinitions(in IOrganizationService service, EntityReference regardingObject, bool forDraftRegarding)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntityDynamicPropertyDefinitions")
				{
					Parameters =
					{
						["RegardingObject"] = regardingObject,
						["ForDraftRegarding"] = forDraftRegarding,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityGroupName"></param>
			/// <returns>EntityGroupConfiguration</returns>
			public static QuickFindConfigurationCollection RetrieveEntityGroupConfiguration(in IOrganizationService service, string entityGroupName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntityGroupConfiguration")
				{
					Parameters =
					{
						["EntityGroupName"] = entityGroupName,
					}
				});

				if (response != null && response.Results.Contains("EntityGroupConfiguration"))
				{
					return (QuickFindConfigurationCollection)response.Results["EntityGroupConfiguration"]; // Microsoft.Xrm.Sdk.QuickFindConfigurationCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityName"></param>
			/// <returns>EntityXml</returns>
			public static string RetrieveEntityXml(in IOrganizationService service, string entityName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveEntityXml")
				{
					Parameters =
					{
						["EntityName"] = entityName,
					}
				});

				if (response != null && response.Results.Contains("EntityXml"))
				{
					return (string)response.Results["EntityXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="componentId"></param>
			/// <param name="componentType"></param>
			/// <param name="includeSubcomponents"></param>
			/// <param name="solutionUniqueName"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveExternalRequiredComponents(in IOrganizationService service, Guid componentId, int componentType, bool includeSubcomponents, string solutionUniqueName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveExternalRequiredComponents")
				{
					Parameters =
					{
						["ComponentId"] = componentId,
						["ComponentType"] = componentType,
						["IncludeSubcomponents"] = includeSubcomponents,
						["SolutionUniqueName"] = solutionUniqueName,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="componentId"></param>
			/// <param name="componentType"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveExternalRoots(in IOrganizationService service, Guid componentId, int componentType)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveExternalRoots")
				{
					Parameters =
					{
						["ComponentId"] = componentId,
						["ComponentType"] = componentType,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityLogicalName"></param>
			/// <returns>Processes</returns>
			public static EntityCollection RetrieveFilteredProcesses(in IOrganizationService service, string entityLogicalName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveFilteredProcesses")
				{
					Parameters =
					{
						["EntityLogicalName"] = entityLogicalName,
					}
				});

				if (response != null && response.Results.Contains("Processes"))
				{
					return (EntityCollection)response.Results["Processes"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="ImportJobId"></param>
			/// <returns>Progress</returns>
			public static string RetrieveImportJobProgress(in IOrganizationService service, Guid ImportJobId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveImportJobProgress")
				{
					Parameters =
					{
						["ImportJobId"] = ImportJobId,
					}
				});

				if (response != null && response.Results.Contains("Progress"))
				{
					return (string)response.Results["Progress"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="parentRecord"></param>
			/// <returns>ItemIds</returns>
			public static Guid[] RetrieveItemIdsForRecord(in IOrganizationService service, EntityReference parentRecord)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveItemIdsForRecord")
				{
					Parameters =
					{
						["ParentRecord"] = parentRecord,
					}
				});

				if (response != null && response.Results.Contains("ItemIds"))
				{
					return (Guid[])response.Results["ItemIds"]; // System.Guid[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <returns>KeyPhrases</returns>
			public static string[] RetrieveKeyPhrasesForKnowledgeSearch(in IOrganizationService service, EntityReference target)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveKeyPhrasesForKnowledgeSearch")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("KeyPhrases"))
				{
					return (string[])response.Results["KeyPhrases"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <returns>KeyPhrases</returns>
			public static string[] RetrieveKeyPhrasesForSimilaritySearch(in IOrganizationService service, EntityReference target)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveKeyPhrasesForSimilaritySearch")
				{
					Parameters =
					{
						["Target"] = target,
					}
				});

				if (response != null && response.Results.Contains("KeyPhrases"))
				{
					return (string[])response.Results["KeyPhrases"]; // System.String[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>LanguagesAvailableForProvisioning</returns>
			public static int[] RetrieveLanguagesAvailableForProvisioning(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveLanguagesAvailableForProvisioning"));

				if (response != null && response.Results.Contains("LanguagesAvailableForProvisioning"))
				{
					return (int[])response.Results["LanguagesAvailableForProvisioning"]; // System.Int32[]
				}
				else
				{
					return null;
				}
			}

			public static MetadataChanges RetrieveMetadataChangesForRichClient(in IOrganizationService service, long LastTimestamp, DateTime LastSyncTime, int LastUserLanguage, string MetadataVersion)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveMetadataChangesForRichClient")
				{
					Parameters =
					{
						["LastTimestamp"] = LastTimestamp,
						["LastSyncTime"] = LastSyncTime,
						["LastUserLanguage"] = LastUserLanguage,
						["MetadataVersion"] = MetadataVersion,
					}
				});

				if (response != null)
				{
					var temp = new MetadataChanges
					{
						SyncType = response.Results.Contains("SyncType") ? (byte)response.Results["SyncType"] : default,
						NewTimestamp = response.Results.Contains("NewTimestamp") ? (long)response.Results["NewTimestamp"] : default,
						NewSyncTime = response.Results.Contains("NewSyncTime") ? (DateTime)response.Results["NewSyncTime"] : default,
						NewUserLanguage = response.Results.Contains("NewUserLanguage") ? (int)response.Results["NewUserLanguage"] : default,
						NewCalculatedTimestamp = response.Results.Contains("NewCalculatedTimestamp") ? (string)response.Results["NewCalculatedTimestamp"] : default,
						AddedOrUpdatedLocalizedLabelMetadata = response.Results.Contains("AddedOrUpdatedLocalizedLabelMetadata") ? (byte[])response.Results["AddedOrUpdatedLocalizedLabelMetadata"] : default,
						AddedOrUpdatedOtherMetadata = response.Results.Contains("AddedOrUpdatedOtherMetadata") ? (byte[])response.Results["AddedOrUpdatedOtherMetadata"] : default,
						DeletedMetadata = response.Results.Contains("DeletedMetadata") ? (byte[])response.Results["DeletedMetadata"] : default
					};

					return temp;
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>Metadata</returns>
			public static byte[] RetrieveMetadataForRichClient(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveMetadataForRichClient"));

				if (response != null && response.Results.Contains("Metadata"))
				{
					return (byte[])response.Results["Metadata"]; // System.Byte[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="query"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveMultipleSystemFormsWithAllLabels(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase query)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveMultipleSystemFormsWithAllLabels")
				{
					Parameters =
					{
						["Query"] = query,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="SettingType"></param>
			/// <returns>Setting</returns>
			public static string RetrieveOfficeGroupsSetting(in IOrganizationService service, int SettingType)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveOfficeGroupsSetting")
				{
					Parameters =
					{
						["SettingType"] = SettingType,
					}
				});

				if (response != null && response.Results.Contains("Setting"))
				{
					return (string)response.Results["Setting"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="name"></param>
			/// <returns>IsEnabled, InstallationStatus</returns>
			public static (bool?, int?) RetrieveOptionalFeatureStatus(in IOrganizationService service, string name)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveOptionalFeatureStatus")
				{
					Parameters =
					{
						["Name"] = name,
					}
				});

				if (response != null && response.Results.Contains("IsEnabled") && response.Results.Contains("InstallationStatus"))
				{
					return ((bool)response.Results["IsEnabled"], (int)response.Results["InstallationStatus"]); // System.Boolean, System.Int32
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="dumpStrategy"></param>
			/// <param name="filterByOrganization"></param>
			/// <param name="filterByTestName"></param>
			/// <returns>ReportXml</returns>
			public static string RetrievePerformanceReport(in IOrganizationService service, int dumpStrategy, bool filterByOrganization, string filterByTestName)
			{
				var response = service.Execute(new OrganizationRequest("RetrievePerformanceReport")
				{
					Parameters =
					{
						["DumpStrategy"] = dumpStrategy,
						["FilterByOrganization"] = filterByOrganization,
						["FilterByTestName"] = filterByTestName,
					}
				});

				if (response != null && response.Results.Contains("ReportXml"))
				{
					return (string)response.Results["ReportXml"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="siteUrl"></param>
			/// <returns>PersonalSiteUrl, MainSiteUrl</returns>
			public static (string, string) RetrievePersonalSite(in IOrganizationService service, string siteUrl)
			{
				var response = service.Execute(new OrganizationRequest("RetrievePersonalSite")
				{
					Parameters =
					{
						["SiteUrl"] = siteUrl,
					}
				});

				if (response != null && response.Results.Contains("PersonalSiteUrl") && response.Results.Contains("MainSiteUrl"))
				{
					return ((string)response.Results["PersonalSiteUrl"], (string)response.Results["MainSiteUrl"]); // System.String, System.String
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>PersonalSiteUrl</returns>
			public static string RetrievePersonalSiteUrl(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrievePersonalSiteUrl"));

				if (response != null && response.Results.Contains("PersonalSiteUrl"))
				{
					return (string)response.Results["PersonalSiteUrl"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="userId"></param>
			/// <returns>RolePrivileges</returns>
			public static RolePrivilege[] RetrievePrivilegeMaxDepthFromTeamRoles(in IOrganizationService service, Guid userId)
			{
				var response = service.Execute(new OrganizationRequest("RetrievePrivilegeMaxDepthFromTeamRoles")
				{
					Parameters =
					{
						["UserId"] = userId,
					}
				});

				if (response != null && response.Results.Contains("RolePrivileges"))
				{
					return (RolePrivilege[])response.Results["RolePrivileges"]; // Microsoft.Crm.Sdk.Messages.RolePrivilege[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityId"></param>
			/// <param name="entityLogicalName"></param>
			/// <param name="processId"></param>
			/// <param name="processInstanceId"></param>
			/// <returns>Entity</returns>
			public static Entity RetrieveProcessActiveStage(in IOrganizationService service, Guid entityId, string entityLogicalName, Guid processId, EntityReference processInstanceId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveProcessActiveStage")
				{
					Parameters =
					{
						["EntityId"] = entityId,
						["EntityLogicalName"] = entityLogicalName,
						["ProcessId"] = processId,
						["ProcessInstanceId"] = processInstanceId,
					}
				});

				if (response != null && response.Results.Contains("Entity"))
				{
					return (Entity)response.Results["Entity"]; // Microsoft.Xrm.Sdk.Entity
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="Target"></param>
			/// <param name="ProcessId"></param>
			/// <param name="ProcessInstanceId"></param>
			/// <returns>Entity, GlobalNavigationData</returns>
			public static (Entity, Entity) RetrieveProcessControlData(in IOrganizationService service, EntityReference Target, EntityReference ProcessId, EntityReference ProcessInstanceId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveProcessControlData")
				{
					Parameters =
					{
						["Target"] = Target,
						["ProcessId"] = ProcessId,
						["ProcessInstanceId"] = ProcessInstanceId,
					}
				});

				if (response != null && response.Results.Contains("Entity") && response.Results.Contains("GlobalNavigationData"))
				{
					return ((Entity)response.Results["Entity"], (Entity)response.Results["GlobalNavigationData"]); // Microsoft.Xrm.Sdk.Entity, Microsoft.Xrm.Sdk.Entity
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="entityLogicalName"></param>
			/// <param name="process"></param>
			/// <param name="appModuleId"></param>
			/// <returns>Entity</returns>
			public static Entity RetrieveProcessWithFallback(in IOrganizationService service, string entityLogicalName, EntityReference process, Guid appModuleId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveProcessWithFallback")
				{
					Parameters =
					{
						["EntityLogicalName"] = entityLogicalName,
						["Process"] = process,
						["AppModuleId"] = appModuleId,
					}
				});

				if (response != null && response.Results.Contains("Entity"))
				{
					return (Entity)response.Results["Entity"]; // Microsoft.Xrm.Sdk.Entity
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="lcId"></param>
			/// <returns>AppModuleCollection</returns>
			public static AppModuleCollection RetrievePublishedAppModuleWithLocale(in IOrganizationService service, int lcId)
			{
				var response = service.Execute(new OrganizationRequest("RetrievePublishedAppModuleWithLocale")
				{
					Parameters =
					{
						["LcId"] = lcId,
					}
				});

				if (response != null && response.Results.Contains("AppModuleCollection"))
				{
					return (AppModuleCollection)response.Results["AppModuleCollection"]; // Microsoft.Crm.Sdk.Messages.AppModuleCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="parentEntityName"></param>
			/// <returns>RecommendationLineItemMetadata</returns>
			public static string RetrieveRecommendationLineItemMetadata(in IOrganizationService service, string parentEntityName)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveRecommendationLineItemMetadata")
				{
					Parameters =
					{
						["ParentEntityName"] = parentEntityName,
					}
				});

				if (response != null && response.Results.Contains("RecommendationLineItemMetadata"))
				{
					return (string)response.Results["RecommendationLineItemMetadata"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="parentEntityName"></param>
			/// <param name="parentEntityId"></param>
			/// <returns>RecommendationLineItemProducts</returns>
			public static string RetrieveRecommendationLineItemProducts(in IOrganizationService service, string parentEntityName, Guid parentEntityId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveRecommendationLineItemProducts")
				{
					Parameters =
					{
						["ParentEntityName"] = parentEntityName,
						["ParentEntityId"] = parentEntityId,
					}
				});

				if (response != null && response.Results.Contains("RecommendationLineItemProducts"))
				{
					return (string)response.Results["RecommendationLineItemProducts"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="parentRecord"></param>
			/// <param name="priceLevelId"></param>
			/// <returns>RecommendationsCount</returns>
			public static int? RetrieveRecommendationsCount(in IOrganizationService service, EntityReference parentRecord, Guid priceLevelId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveRecommendationsCount")
				{
					Parameters =
					{
						["ParentRecord"] = parentRecord,
						["PriceLevelId"] = priceLevelId,
					}
				});

				if (response != null && response.Results.Contains("RecommendationsCount"))
				{
					return (int)response.Results["RecommendationsCount"]; // System.Int32
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>Entity</returns>
			public static Entity RetrieveReferenceSiteMap(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveReferenceSiteMap"));

				if (response != null && response.Results.Contains("Entity"))
				{
					return (Entity)response.Results["Entity"]; // Microsoft.Xrm.Sdk.Entity
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="fetchXml"></param>
			/// <param name="useStoredProcedures"></param>
			/// <param name="retrieveAllColumns"></param>
			/// <returns>ReportSql</returns>
			public static string RetrieveReportSqlFromQuery(in IOrganizationService service, string fetchXml, bool useStoredProcedures, bool retrieveAllColumns)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveReportSqlFromQuery")
				{
					Parameters =
					{
						["FetchXml"] = fetchXml,
						["UseStoredProcedures"] = useStoredProcedures,
						["RetrieveAllColumns"] = retrieveAllColumns,
					}
				});

				if (response != null && response.Results.Contains("ReportSql"))
				{
					return (string)response.Results["ReportSql"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="query"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			/// <param name="pageToken"></param>
			/// <returns>BusinessEntityCollection</returns>
			public static object RetrieveSharePointData(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase query, string siteUrl, string documentLocation, string referencedEntity, string pageToken)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveSharePointData")
				{
					Parameters =
					{
						["Query"] = query,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
						["PageToken"] = pageToken,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntityCollection"))
				{
					return (object)response.Results["BusinessEntityCollection"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>SharePointGlobalSetting</returns>
			public static string RetrieveSharePointGlobalSettings(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveSharePointGlobalSettings"));

				if (response != null && response.Results.Contains("SharePointGlobalSetting"))
				{
					return (string)response.Results["SharePointGlobalSetting"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>TenantInfo</returns>
			public static string RetrieveTenantInfo(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveTenantInfo"));

				if (response != null && response.Results.Contains("TenantInfo"))
				{
					return (string)response.Results["TenantInfo"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="query"></param>
			/// <param name="SharePointSiteUrl"></param>
			/// <returns>BusinessEntityCollection</returns>
			public static object RetrieveTrendingDocuments(in IOrganizationService service, Microsoft.Xrm.Sdk.Query.QueryBase query, string SharePointSiteUrl)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveTrendingDocuments")
				{
					Parameters =
					{
						["Query"] = query,
						["SharePointSiteUrl"] = SharePointSiteUrl,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntityCollection"))
				{
					return (object)response.Results["BusinessEntityCollection"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>Currency</returns>
			public static EntityReference RetrieveUserDefaultCurrency(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveUserDefaultCurrency"));

				if (response != null && response.Results.Contains("Currency"))
				{
					return (EntityReference)response.Results["Currency"]; // Microsoft.Xrm.Sdk.EntityReference
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="RecordTypeName"></param>
			/// <param name="RecordId"></param>
			/// <returns>BusinessEntity</returns>
			public static object RetrieveValidSLA(in IOrganizationService service, string RecordTypeName, Guid RecordId)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveValidSLA")
				{
					Parameters =
					{
						["RecordTypeName"] = RecordTypeName,
						["RecordId"] = RecordId,
					}
				});

				if (response != null && response.Results.Contains("BusinessEntity"))
				{
					return (object)response.Results["BusinessEntity"]; // System.Object
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="view"></param>
			/// <param name="pagingCookie"></param>
			/// <param name="pageNumber"></param>
			/// <param name="pageSize"></param>
			/// <param name="commentsPerPost"></param>
			/// <param name="source"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RetrieveWallByView(in IOrganizationService service, EntityReference view, string pagingCookie, int pageNumber, int pageSize, int commentsPerPost, OptionSetValue source)
			{
				var response = service.Execute(new OrganizationRequest("RetrieveWallByView")
				{
					Parameters =
					{
						["View"] = view,
						["PagingCookie"] = pagingCookie,
						["PageNumber"] = pageNumber,
						["PageSize"] = pageSize,
						["CommentsPerPost"] = commentsPerPost,
						["Source"] = source,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <param name="query"></param>
			/// <param name="rollupType"></param>
			/// <returns>EntityCollection</returns>
			public static EntityCollection RollupForActivityWall(in IOrganizationService service, EntityReference target, QueryBase query, Microsoft.Crm.Sdk.Messages.RollupType rollupType)
			{
				var response = service.Execute(new OrganizationRequest("RollupForActivityWall")
				{
					Parameters =
					{
						["Target"] = target,
						["Query"] = query,
						["RollupType"] = rollupType,
					}
				});

				if (response != null && response.Results.Contains("EntityCollection"))
				{
					return (EntityCollection)response.Results["EntityCollection"]; // Microsoft.Xrm.Sdk.EntityCollection
				}
				else
				{
					return null;
				}
			}

			public static void SaveEntityGroupConfiguration(in IOrganizationService service, string entityGroupName, Microsoft.Xrm.Sdk.QuickFindConfigurationCollection entityGroupConfiguration)
			{
				var response = service.Execute(new OrganizationRequest("SaveEntityGroupConfiguration")
				{
					Parameters =
					{
						["EntityGroupName"] = entityGroupName,
						["EntityGroupConfiguration"] = entityGroupConfiguration,
					}
				});
			}

			public static void ScheduleBuildTopicModel(in IOrganizationService service, Guid topicModelId, DateTime scheduleBuildStartTime, string scheduleBuildRecurrence)
			{
				var response = service.Execute(new OrganizationRequest("ScheduleBuildTopicModel")
				{
					Parameters =
					{
						["TopicModelId"] = topicModelId,
						["ScheduleBuildStartTime"] = scheduleBuildStartTime,
						["ScheduleBuildRecurrence"] = scheduleBuildRecurrence,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObjectType"></param>
			/// <param name="regardingObjectId"></param>
			/// <param name="documentId"></param>
			/// <returns>SearchLocation, DocumentLocation</returns>
			public static (string, string) SearchDocument(in IOrganizationService service, int regardingObjectType, string regardingObjectId, string documentId)
			{
				var response = service.Execute(new OrganizationRequest("SearchDocument")
				{
					Parameters =
					{
						["RegardingObjectType"] = regardingObjectType,
						["RegardingObjectId"] = regardingObjectId,
						["DocumentId"] = documentId,
					}
				});

				if (response != null && response.Results.Contains("SearchLocation") && response.Results.Contains("DocumentLocation"))
				{
					return ((string)response.Results["SearchLocation"], (string)response.Results["DocumentLocation"]); // System.String, System.String
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			/// <param name="getSharedDocumentsKeyword"></param>
			/// <returns>SearchLocation</returns>
			public static string SearchSharePointDocument(in IOrganizationService service, string siteUrl, string documentLocation, string referencedEntity, bool getSharedDocumentsKeyword)
			{
				var response = service.Execute(new OrganizationRequest("SearchSharePointDocument")
				{
					Parameters =
					{
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
						["GetSharedDocumentsKeyword"] = getSharedDocumentsKeyword,
					}
				});

				if (response != null && response.Results.Contains("SearchLocation"))
				{
					return (string)response.Results["SearchLocation"]; // System.String
				}
				else
				{
					return null;
				}
			}

			public static void SetActionCardState(in IOrganizationService service, Guid actionCardId, OptionSetValue actionState, string messageId)
			{
				service.Execute(new OrganizationRequest("SetActionCardState")
				{
					Parameters =
					{
						["ActionCardId"] = actionCardId,
						["ActionState"] = actionState,
						["MessageId"] = messageId,
					}
				});
			}

			public static void SetDevErrors(in IOrganizationService service, Guid userId, Guid organizationId, bool value)
			{
				service.Execute(new OrganizationRequest("SetDevErrors")
				{
					Parameters =
					{
						["UserId"] = userId,
						["OrganizationId"] = organizationId,
						["Value"] = value,
					}
				});
			}

			public static void SetOptionalFeatureStatus(in IOrganizationService service, string name, bool newStatus)
			{
				service.Execute(new OrganizationRequest("SetOptionalFeatureStatus")
				{
					Parameters =
					{
						["Name"] = name,
						["NewStatus"] = newStatus,
					}
				});
			}

			public static void SetPrimaryClientSubscriptionClients(in IOrganizationService service, Guid clientId)
			{
				service.Execute(new OrganizationRequest("SetPrimaryClientSubscriptionClients")
				{
					Parameters =
					{
						["ClientId"] = clientId,
					}
				});
			}

			public static void SetStateAzureServiceConnection(in IOrganizationService service, EntityReference entityMoniker, int state, int status, bool cascadeModelState)
			{
				service.Execute(new OrganizationRequest("SetStateAzureServiceConnection")
				{
					Parameters =
					{
						["EntityMoniker"] = entityMoniker,
						["State"] = state,
						["Status"] = status,
						["CascadeModelState"] = cascadeModelState,
					}
				});
			}

			public static void SetWordTemplate(in IOrganizationService service, EntityReference target, EntityReference selectedTemplate)
			{
				service.Execute(new OrganizationRequest("SetWordTemplate")
				{
					Parameters =
					{
						["Target"] = target,
						["SelectedTemplate"] = selectedTemplate,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="regardingObjectTypeCode"></param>
			/// <returns>Result</returns>
			public static bool? ShouldDisplaySLALimitNotification(in IOrganizationService service, int regardingObjectTypeCode)
			{
				var response = service.Execute(new OrganizationRequest("ShouldDisplaySLALimitNotification")
				{
					Parameters =
					{
						["RegardingObjectTypeCode"] = regardingObjectTypeCode,
					}
				});

				if (response != null && response.Results.Contains("Result"))
				{
					return (bool)response.Results["Result"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			public static void SnoozeActionCard(in IOrganizationService service, Guid ActionCardId)
			{
				service.Execute(new OrganizationRequest("SnoozeActionCard")
				{
					Parameters =
					{
						["ActionCardId"] = ActionCardId,
					}
				});
			}

			public static void StartRIProvisioning(in IOrganizationService service, string hubName, string primaryKey)
			{
				service.Execute(new OrganizationRequest("StartRIProvisioning")
				{
					Parameters =
					{
						["HubName"] = hubName,
						["PrimaryKey"] = primaryKey,
					}
				});
			}

			public static void StatusUpdateBulkOperation(in IOrganizationService service, Guid bulkOperationId, int failureCount, int successCount)
			{
				service.Execute(new OrganizationRequest("StatusUpdateBulkOperation")
				{
					Parameters =
					{
						["BulkOperationId"] = bulkOperationId,
						["FailureCount"] = failureCount,
						["SuccessCount"] = successCount,
					}
				});
			}

			public static void TestAzureServiceConnection(in IOrganizationService service, Guid azureServiceConnectionId)
			{
				service.Execute(new OrganizationRequest("TestAzureServiceConnection")
				{
					Parameters =
					{
						["AzureServiceConnectionId"] = azureServiceConnectionId,
					}
				});
			}

			public static void TestTopicModel(in IOrganizationService service, Guid topicModelId, Guid configurationUsedId, int maxTopics)
			{
				service.Execute(new OrganizationRequest("TestTopicModel")
				{
					Parameters =
					{
						["TopicModelId"] = topicModelId,
						["ConfigurationUsedId"] = configurationUsedId,
						["MaxTopics"] = maxTopics,
					}
				});
			}

			public static void ToggleGuidedHelp(in IOrganizationService service, bool value)
			{
				service.Execute(new OrganizationRequest("ToggleGuidedHelp")
				{
					Parameters =
					{
						["Value"] = value,
					}
				});
			}

			public static void TrackEmail(in IOrganizationService service, string exchangeItemId, EntityReference regarding)
			{
				service.Execute(new OrganizationRequest("TrackEmail")
				{
					Parameters =
					{
						["ExchangeItemId"] = exchangeItemId,
						["Regarding"] = regarding,
					}
				});
			}

			public static void UnfollowEmailAttachment(in IOrganizationService service, Guid activityMimeAttachmentId)
			{
				service.Execute(new OrganizationRequest("UnfollowEmailAttachment")
				{
					Parameters =
					{
						["ActivityMimeAttachmentId"] = activityMimeAttachmentId,
					}
				});
			}

			public static void UnregisterSolution(in IOrganizationService service, Guid pluginAssemblyId)
			{
				service.Execute(new OrganizationRequest("UnregisterSolution")
				{
					Parameters =
					{
						["PluginAssemblyId"] = pluginAssemblyId,
					}
				});
			}

			public static void UpdateDelveActionStatus(in IOrganizationService service, string messageId, int actionState, string recordId)
			{
				service.Execute(new OrganizationRequest("UpdateDelveActionStatus")
				{
					Parameters =
					{
						["MessageId"] = messageId,
						["ActionState"] = actionState,
						["RecordId"] = recordId,
					}
				});
			}

			public static void UpdateDocumentManagementSettings(in IOrganizationService service, string siteCollection, int folderStructureEntity, string entityDocMgmtXml, int validateStatus, int validateStatusReason)
			{
				service.Execute(new OrganizationRequest("UpdateDocumentManagementSettings")
				{
					Parameters =
					{
						["SiteCollection"] = siteCollection,
						["FolderStructureEntity"] = folderStructureEntity,
						["EntityDocMgmtXml"] = entityDocMgmtXml,
						["ValidateStatus"] = validateStatus,
						["ValidateStatusReason"] = validateStatusReason,
					}
				});
			}

			public static void UpdateFromTemplate(in IOrganizationService service, Guid reportId, string wizardXml, bool isOrgReport)
			{
				service.Execute(new OrganizationRequest("UpdateFromTemplate")
				{
					Parameters =
					{
						["ReportId"] = reportId,
						["WizardXml"] = wizardXml,
						["IsOrgReport"] = isOrgReport,
					}
				});
			}

			public static void UpdateGlobalSharePointSettings(in IOrganizationService service, string SharePointRealm, bool IsSharePointOnline, bool UseAuthorizationServer)
			{
				service.Execute(new OrganizationRequest("UpdateGlobalSharePointSettings")
				{
					Parameters =
					{
						["SharePointRealm"] = SharePointRealm,
						["IsSharePointOnline"] = IsSharePointOnline,
						["UseAuthorizationServer"] = UseAuthorizationServer,
					}
				});
			}

			public static void UpdateRITenantInfo(in IOrganizationService service, string hubName, string primaryKey)
			{
				service.Execute(new OrganizationRequest("UpdateRITenantInfo")
				{
					Parameters =
					{
						["HubName"] = hubName,
						["PrimaryKey"] = primaryKey,
					}
				});
			}

			public static void UpdateSchedule(in IOrganizationService service, Guid reportId, string scheduleXml, string parameterXml, string scheduledReportName)
			{
				service.Execute(new OrganizationRequest("UpdateSchedule")
				{
					Parameters =
					{
						["ReportId"] = reportId,
						["ScheduleXml"] = scheduleXml,
						["ParameterXml"] = parameterXml,
						["ScheduledReportName"] = scheduledReportName,
					}
				});
			}

			public static void UpdateYammerProperties(in IOrganizationService service, Entity businessEntity)
			{
				service.Execute(new OrganizationRequest("UpdateYammerProperties")
				{
					Parameters =
					{
						["BusinessEntity"] = businessEntity,
					}
				});
			}

			public static void UpgradeToS2S(in IOrganizationService service)
			{
				service.Execute(new OrganizationRequest("UpgradeToS2S"));
			}

			public static void UploadDocument(in IOrganizationService service, byte[] content, Entity entity, bool overwriteExisting)
			{
				var response = service.Execute(new OrganizationRequest("UploadDocument")
				{
					Parameters =
					{
						["Content"] = content,
						["Entity"] = entity,
						["OverwriteExisting"] = overwriteExisting,
					}
				});
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="documentContent"></param>
			/// <param name="fileName"></param>
			/// <param name="overwriteExisting"></param>
			/// <param name="siteUrl"></param>
			/// <param name="documentLocation"></param>
			/// <param name="referencedEntity"></param>
			/// <returns>EditLink</returns>
			public static string UploadSharePointDocument(in IOrganizationService service, string documentContent, string fileName, bool overwriteExisting, string siteUrl, string documentLocation, string referencedEntity)
			{
				var response = service.Execute(new OrganizationRequest("UploadSharePointDocument")
				{
					Parameters =
					{
						["DocumentContent"] = documentContent,
						["FileName"] = fileName,
						["OverwriteExisting"] = overwriteExisting,
						["SiteUrl"] = siteUrl,
						["DocumentLocation"] = documentLocation,
						["ReferencedEntity"] = referencedEntity,
					}
				});

				if (response != null && response.Results.Contains("EditLink"))
				{
					return (string)response.Results["EditLink"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="appModuleId"></param>
			/// <returns>AppModuleValidation</returns>
			public static AppModuleValidationResponse ValidateAppModule(in IOrganizationService service, Guid appModuleId)
			{
				var response = service.Execute(new OrganizationRequest("ValidateAppModule")
				{
					Parameters =
					{
						["AppModuleId"] = appModuleId,
					}
				});

				if (response != null && response.Results.Contains("AppModuleValidation"))
				{
					return (AppModuleValidationResponse)response.Results["AppModuleValidation"]; // Microsoft.Crm.Sdk.Messages.AppModuleValidationResponse
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <returns>ValidationResult</returns>
			public static string ValidateOfficeGraphAuthentication(in IOrganizationService service)
			{
				var response = service.Execute(new OrganizationRequest("ValidateOfficeGraphAuthentication"));

				if (response != null && response.Results.Contains("ValidationResult"))
				{
					return (string)response.Results["ValidationResult"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="folderUrls"></param>
			/// <param name="siteUrls"></param>
			/// <returns>ValidationStatus</returns>
			public static bool[] ValidateSharePointFolder(in IOrganizationService service, string[] folderUrls, string[] siteUrls)
			{
				var response = service.Execute(new OrganizationRequest("ValidateSharePointFolder")
				{
					Parameters =
					{
						["FolderUrls"] = folderUrls,
						["SiteUrls"] = siteUrls,
					}
				});

				if (response != null && response.Results.Contains("ValidationStatus"))
				{
					return (bool[])response.Results["ValidationStatus"]; // System.Boolean[]
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="siteUrls"></param>
			/// <returns>ValidationStatus, ValidationLog</returns>
			public static (bool[], string) ValidateSharePointSite(in IOrganizationService service, string[] siteUrls)
			{
				var response = service.Execute(new OrganizationRequest("ValidateSharePointSite")
				{
					Parameters =
					{
						["SiteUrls"] = siteUrls,
					}
				});

				if (response != null && response.Results.Contains("ValidationStatus") && response.Results.Contains("ValidationLog"))
				{
					return ((bool[])response.Results["ValidationStatus"], (string)response.Results["ValidationLog"]); // System.Boolean[], System.String
				}
				else
				{
					return (null, null);
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="sharePointUrls"></param>
			/// <returns>UrlValidationResult</returns>
			public static string ValidateUrl(in IOrganizationService service, string sharePointUrls)
			{
				var response = service.Execute(new OrganizationRequest("ValidateUrl")
				{
					Parameters =
					{
						["SharePointUrls"] = sharePointUrls,
					}
				});

				if (response != null && response.Results.Contains("UrlValidationResult"))
				{
					return (string)response.Results["UrlValidationResult"]; // System.String
				}
				else
				{
					return null;
				}
			}

			/// <summary>
			/// </summary>
			/// <param name="service"></param>
			/// <param name="target"></param>
			/// <param name="processState"></param>
			/// <returns>IsValid</returns>
			public static bool? VerifyProcessStateData(in IOrganizationService service, EntityReference target, string processState)
			{
				var response = service.Execute(new OrganizationRequest("VerifyProcessStateData")
				{
					Parameters =
					{
						["Target"] = target,
						["ProcessState"] = processState,
					}
				});

				if (response != null && response.Results.Contains("IsValid"))
				{
					return (bool)response.Results["IsValid"]; // System.Boolean
				}
				else
				{
					return null;
				}
			}

			public class MetadataChanges
			{
				public byte[] AddedOrUpdatedLocalizedLabelMetadata { get; set; }
				public byte[] AddedOrUpdatedOtherMetadata { get; set; }
				public byte[] DeletedMetadata { get; set; }
				public string NewCalculatedTimestamp { get; set; }
				public DateTime NewSyncTime { get; set; }
				public long NewTimestamp { get; set; }
				public int NewUserLanguage { get; set; }
				public byte SyncType { get; set; }
			}
		}
	}
}