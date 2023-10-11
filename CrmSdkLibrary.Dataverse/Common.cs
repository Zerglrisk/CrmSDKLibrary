using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Add a button to create a new related record
 * https://community.dynamics.com/crm/b/crminogic/archive/2011/08/25/add-a-button-to-create-a-new-related-record
 * var url = Xrm.Page.context.getServerUrl()+"main.aspx?etn= “+Child entity schema name+” &extraqs=%3f_CreateFromId%3d"+ parentRecordId +"%26_CreateFromType%3d”+Parent Entity type code +”%26etn%“+Child entity schema name+” &pagetype=entityrecord";
 */

namespace CrmSdkLibrary.Dataverse
{
	public class Common
	{
		/// <summary>
		/// get user's entityimage's uri string. only can use which Entity has entityimage field.
		/// you can use crm address + uri string
		/// </summary>
		public static string GetUserImageUri(IOrganizationService service, string entity, Guid userId)
		{
			//Image URL 가져오기
			var strEntityImageURL = string.Empty;

			//https://msdn.microsoft.com/ko-kr/library/dn817886.aspx
			//http://mscrmtechie.blogspot.kr/2015/03/retrieve-entityimage-url-of-record-in.html
			//guid - contactid
			var entObject = service.Retrieve(entity, userId, new ColumnSet(new string[] { "entityimage_url" }));
			if (entObject != null && entObject.Contains("entityimage_url"))
			{
				strEntityImageURL = entObject.Attributes["entityimage_url"].ToString();
			}

			return strEntityImageURL;
		}

		/// <summary>
		/// get all user entityimage's uri string. only can use which Entity has entityimage field.
		/// you can use crm address + uri string
		/// </summary>
		public static string GetAllUserImageUri(IOrganizationService service, string entity)
		{
			return string.Empty;
		}

		//조건에 맞는 사용자의 엔티티 이미지 Uri 가져옴, entityimage 필드가 있는 엔티티에서만 사용 가능
		//리턴으로 뒷부분 uri만 주므로 crm 어드레스 주소도 필요함
		/// <summary>
		/// get user entityimage's uri string that contain conditions. only can use which Entity has entityimage field.
		/// you can use crm address + uri string
		/// </summary>
		public static string GetUsersImageUri(IOrganizationService service, string entity, string[] conditions)

		//컨디션 데이터타입 고치기
		{
			return string.Empty;
		}

		//CRM 서버에 연결하여 엔티티의 애트리뷰트의 타입명을 가져온다.
		/// <summary>
		/// Communicate to server for get entity's attribute's type name
		/// </summary>
		/// <param name="service"></param>
		/// <param name="entity"></param>
		/// <param name="attribute"></param>
		/// <returns></returns>
		public static string GetAttributeType(IOrganizationService service, Entity entity, string attribute)
		{
			var attributeRequest = new RetrieveAttributeRequest
			{
				EntityLogicalName = entity.LogicalName,
				LogicalName = attribute,
				RetrieveAsIfPublished = true
			};

			var attributeResponse = (RetrieveAttributeResponse)service.Execute(attributeRequest);

			//AttributeMetadata attrMetadata = (AttributeMetadata)attributeResponse.AttributeMetadata;
			return attributeResponse.AttributeMetadata.AttributeType.ToString();
		}

		/// <summary>
		/// attribute의 값의 레이블 값을 리턴하는 함수
		/// </summary>
		/// <param name="service"></param>
		/// <param name="entity"></param>
		/// <param name="attribute"></param>
		/// <returns></returns>
		public static string GetAttributeLabel(IOrganizationService service, Entity entity, string attribute)
		{
			//If value is null return null
			if (!entity.Contains(attribute))
			{
				//TODO: Write or return null Exception
				return "NULL";//String.Empty;
			}

			//Initialize
			var strLabel = string.Empty;

			//For OptionSet and EtntiyReference and Virtual

			//Debug
			//Console.Write("\tDebug attributeType : " + entity[attribute].GetType().Name + "\t");

			#region Switch

			switch (entity[attribute].GetType().Name)
			{
				#region OptionSet Switch

				case "Byte[]": //이미지
				case "OptionSetValue": //옵션 셋
					OptionSetValue option = null;

					var attributeRequest = new RetrieveAttributeRequest
					{
						EntityLogicalName = entity.LogicalName,
						LogicalName = attribute,
						RetrieveAsIfPublished = true
					};

					RetrieveAttributeResponse attributeResponse = (RetrieveAttributeResponse)service.Execute(attributeRequest);
					AttributeMetadata attrMetadata = attributeResponse.AttributeMetadata;
					OptionMetadataCollection optionMeta = null;

					//Debug
					//Console.Write("\tDebug OptionSetType : " + attrMetadata.AttributeType.ToString() + "\t");
					switch (attrMetadata.AttributeType.ToString())
					{
						case "Status": //상태 설명
							optionMeta = ((StatusAttributeMetadata)attrMetadata).OptionSet.Options;
							break;

						case "Picklist": //옵션 집합 단순
							optionMeta = ((PicklistAttributeMetadata)attrMetadata).OptionSet.Options;
							break;

						case "State": //상태
							optionMeta = ((StateAttributeMetadata)attrMetadata).OptionSet.Options;
							break;

						case "Virtual": //이미지

							//https://community.dynamics.com/crm/b/crminogic/archive/2013/10/01/now-store-images-in-crm-2013
							//https://msdn.microsoft.com/en-us/library/dn511697.aspx 이 예제는 파일 이름까지 같이 저장함(사용자 정의 필드로)
							strLabel = "Cant Read File name only can retrieve byte[] type";
							break;

						default:

							//TODO: Write Err Exception
							break;
					}

					//If this attr is OptionSet, Find Label
					if (optionMeta != null)
					{
						option = (OptionSetValue)entity.Attributes[attribute];
						foreach (OptionMetadata metadata in optionMeta)
						{
							if (metadata.Value == option.Value)
							{
								strLabel = metadata.Label.UserLocalizedLabel.Label;
							}
						}
					}
					break;

				#endregion OptionSet Switch

				#region EntityReference

				case "EntityReference":
					var attributeRequestEntity = new RetrieveAttributeRequest
					{
						EntityLogicalName = entity.LogicalName,
						LogicalName = attribute,
						RetrieveAsIfPublished = true
					};

					RetrieveAttributeResponse attributeResponseEntity = (RetrieveAttributeResponse)service.Execute(attributeRequestEntity);
					AttributeMetadata attrMetadataEntity = attributeResponseEntity.AttributeMetadata;

					//Debug
					//Console.Write("\tDebug EntityReferenceType : " + attrMetadataEntity.AttributeType.ToString() + "\t");
					switch (attrMetadataEntity.AttributeType.ToString())
					{
						case "Lookup": //조회

							//strLabel = ((LookupAttributeMetadata)attrMetadata).DisplayName.UserLocalizedLabel.ToString();
							strLabel = ((EntityReference)entity.Attributes[attribute]).Name;
							break;

						case "Owner": //담당자
						case "Customer": //고객
							strLabel = ((EntityReference)entity.Attributes[attribute]).Id.ToString();
							break;

						default:

							//TODO: Write Err Exception
							break;
					}
					break;

				#endregion EntityReference

				case "Enum": //Enum
					break;

				case "Memo": //여러 줄 텍스트

					//strLabel = ((MemoAttributeMetadata)attrMetadata).ColumnNumber.Value.ToString();
					strLabel = entity[attribute].ToString();
					break;

				case "Money": //통화

					//strLabel = ((Money)entity[attribute]).Value.ToString().Substring(0, ((Money)entity[attribute]).Value.ToString().Length - 2);
					strLabel = ((Money)entity[attribute]).Value.ToString("#.##");
					break;

				case "Decimal": //10진수
					strLabel = ((decimal)entity[attribute]).ToString("#.##");
					break;

				case "Integer": //정수
					strLabel = ((int)entity[attribute]).ToString();
					break;

				case "DateTime": //날짜 및 시간
					strLabel = Convert.ToDateTime(entity.Attributes[attribute].ToString()).ToString();
					break;

				case "Boolean": //두 개 옵션
					strLabel = (bool)entity.Attributes[attribute] ? "True" : "False";
					break;

				case "String": //한 줄 텍스트
					strLabel = entity[attribute].ToString();
					break;

				case "Double": //부동 소수점 수
					strLabel = ((double)entity[attribute]).ToString();
					break;

				case "EntityName": //Entity Name

					break;

				case "Int64": // "BigInt": //타임스탬프
					strLabel = entity[attribute].ToString();
					break;

				case "ManagedProperty":
					break;

				case "Guid"://"Uniqueidentifier": //고유 식별자 or 기본 키
					strLabel = entity[attribute].ToString();
					break;

				case "Image":
					break;

				default:

					//TODO: Write Err Exception
					break;
			}

			#endregion Switch

			return strLabel;
		}

		/// <summary>
		/// 지정한 엔티티의 메타데이터를 가져온 후 메타데이터에서 지정한 필드의 지정한 값과 연결된 이름을 가져오는 함수.
		/// This function that get the metadata of a specified entity and then get the name associated with the specified value of the specified filed in the metadata.
		/// </summary>
		/// <param name="service"></param>
		/// <param name="entityName"></param>
		/// <param name="attributeName"></param>
		/// <param name="optionSetValue"></param>
		/// <see href="https://www.codeproject.com/Tips/553178/Get-the-OptionsetValue-and-OptionsetText-for-Dynam"/>
		/// <returns>string</returns>
		public static string GetOptionSetText(IOrganizationService service, string entityName, string attributeName, int optionSetValue)
		{
			var retrieveDetails = new RetrieveEntityRequest
			{
				EntityFilters = EntityFilters.All,
				LogicalName = entityName,
				RetrieveAsIfPublished = true
			};
			var retrieveEntityResponseObj = (RetrieveEntityResponse)service.Execute(retrieveDetails);
			var metadata = retrieveEntityResponseObj.EntityMetadata;
			var pickListMetadata = metadata.Attributes.FirstOrDefault(attribute => string.Equals(attribute.LogicalName, attributeName, StringComparison.OrdinalIgnoreCase)) as PicklistAttributeMetadata;
			var options = pickListMetadata?.OptionSet;

			IList<OptionMetadata> optionsList = (from o in options?.Options
												 where o.Value != null && o.Value.Value == optionSetValue
												 select o).ToList();
			var optionSetLabel = optionsList.First().Label.UserLocalizedLabel.Label;

			return optionSetLabel;
		}

		/// <summary>
		/// Get OptinSetValue List From Attribute.
		/// </summary>
		/// <param name="service"></param>
		/// <param name="entityName"></param>
		/// <param name="attributeName"></param>
		/// <see href="https://community.dynamics.com/365/b/crmmemories/archive/2017/04/20/retrieve-option-set-metadata-in-c"/>
		/// <returns></returns>
		public static List<OptionMetadata> GetOptionSetList(IOrganizationService service, string entityName,
			string attributeName)
		{
			var attributeRequest = new RetrieveAttributeRequest
			{
				EntityLogicalName = entityName,
				LogicalName = attributeName,
				RetrieveAsIfPublished = true
			};

			var attributeResponse = (RetrieveAttributeResponse)service.Execute(attributeRequest);
			var attributeMetadata = (EnumAttributeMetadata)attributeResponse.AttributeMetadata;

			//var optionList = (from o in attributeMetadata.OptionSet.Options
			//    select new { Value = o.Value, Text = o.Label.UserLocalizedLabel.Label }).ToList();

			return (from o in attributeMetadata.OptionSet.Options select o).ToList();
		}
	}
}