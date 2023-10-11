using CrmSdkLibrary.Dataverse;
using Microsoft.Xrm.Sdk;

namespace CrmSdkLibrary.Dataverse.Entities
{
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("incident")]
	public class Incident : Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		private int? _entityTypeCode;

		public int? EntityTypeCode =>
			_entityTypeCode ?? (_entityTypeCode = Connection.Service != null
				? Messages.GetEntityTypeCode(Connection.Service, EntityLogicalName)
				: _entityTypeCode);

		public const string EntityLogicalName = "incident";
		public const string EntitySetPath = "incidents";
		public const string DisplayName = "Case";
		public const string PrimaryKey = "incidentid";
		public const string PrimaryKeyAttribute = "title";

		[System.Runtime.Serialization.DataContract()]
		public enum IncidentState
		{
			[System.Runtime.Serialization.EnumMember()]
			Active = 0,

			[System.Runtime.Serialization.EnumMember()]
			Resolved = 1,

			[System.Runtime.Serialization.EnumMember()]
			Canceled = 2,
		}

		public enum IncidentStatus
		{
			ProblemSolved = 5,
			InformationProvided = 1000,
			Cancelled = 6,
			Merged = 2000,
			InProgress = 1,
			OnHold = 2,
			WaitingforDetails = 3,
			Researching = 4
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public Incident() :
				base(EntityLogicalName)
		{
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private void OnPropertyChanging(string propertyName)
		{
			if (PropertyChanging != null)
			{
				PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
	}
}

//[System.Runtime.Serialization.DataContractAttribute()]
//[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("incident")]
//[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
//public partial class Incident : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
//{
//    #region Field
//    [System.Runtime.Serialization.DataContractAttribute()]
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
//    public enum IncidentState
//    {
//        [System.Runtime.Serialization.EnumMemberAttribute()]
//        Active = 0,

//        [System.Runtime.Serialization.EnumMemberAttribute()]
//        Resolved = 1,

//        [System.Runtime.Serialization.EnumMemberAttribute()]
//        Canceled = 2,
//    }

//    /// <summary>
//    /// Default Constructor.
//    /// </summary>
//    public Incident() :
//            base(EntityLogicalName)
//    {
//    }

//    public const string EntityLogicalName = "incident";

//    public const int EntityTypeCode = 112;

//    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

//    public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

//    private void OnPropertyChanged(string propertyName)
//    {
//        if ((this.PropertyChanged != null))
//        {
//            this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
//        }
//    }

//    private void OnPropertyChanging(string propertyName)
//    {
//        if ((this.PropertyChanging != null))
//        {
//            this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스와 연관된 거래처의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
//    public Microsoft.Xrm.Sdk.EntityReference AccountId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("accountid");
//        }
//    }

//    /// <summary>
//    /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitiescomplete")]
//    public System.Nullable<bool> ActivitiesComplete
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("activitiescomplete");
//        }
//        set
//        {
//            this.OnPropertyChanging("ActivitiesComplete");
//            this.SetAttributeValue("activitiescomplete", value);
//            this.OnPropertyChanged("ActivitiesComplete");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스를 해결하는 데 실제로 필요한 서비스 단위 수를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualserviceunits")]
//    public System.Nullable<int> ActualServiceUnits
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("actualserviceunits");
//        }
//        set
//        {
//            this.OnPropertyChanging("ActualServiceUnits");
//            this.SetAttributeValue("actualserviceunits", value);
//            this.OnPropertyChanged("ActualServiceUnits");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스에 대해 고객에게 청구된 서비스 단위 수를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("billedserviceunits")]
//    public System.Nullable<int> BilledServiceUnits
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("billedserviceunits");
//        }
//        set
//        {
//            this.OnPropertyChanging("BilledServiceUnits");
//            this.SetAttributeValue("billedserviceunits", value);
//            this.OnPropertyChanged("BilledServiceUnits");
//        }
//    }

//    /// <summary>
//    /// 프로필이 차단되었는지 여부에 대한 세부 정보입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("blockedprofile")]
//    public System.Nullable<bool> BlockedProfile
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("blockedprofile");
//        }
//        set
//        {
//            this.OnPropertyChanging("BlockedProfile");
//            this.SetAttributeValue("blockedprofile", value);
//            this.OnPropertyChanged("BlockedProfile");
//        }
//    }

//    /// <summary>
//    /// 보고 및 분석용으로 서비스 케이스에 대한 연락처가 생성된 방법을 선택합니다(예: 전자 메일, 전화 또는 웹).
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("caseorigincode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue CaseOriginCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("caseorigincode");
//        }
//        set
//        {
//            this.OnPropertyChanging("CaseOriginCode");
//            this.SetAttributeValue("caseorigincode", value);
//            this.OnPropertyChanged("CaseOriginCode");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스 라우팅 및 분석용으로 문제를 식별하는 서비스 케이스 유형을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("casetypecode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue CaseTypeCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("casetypecode");
//        }
//        set
//        {
//            this.OnPropertyChanging("CaseTypeCode");
//            this.SetAttributeValue("casetypecode", value);
//            this.OnPropertyChanged("CaseTypeCode");
//        }
//    }

//    /// <summary>
//    /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("checkemail")]
//    public System.Nullable<bool> CheckEmail
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("checkemail");
//        }
//        set
//        {
//            this.OnPropertyChanging("CheckEmail");
//            this.SetAttributeValue("checkemail", value);
//            this.OnPropertyChanged("CheckEmail");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스와 연관된 연락처의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contactid")]
//    public Microsoft.Xrm.Sdk.EntityReference ContactId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contactid");
//        }
//    }

//    /// <summary>
//    /// 고객에게 올바르게 부과되도록 서비스 케이스가 기록되어야 하는 계약 내용을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractdetailid")]
//    public Microsoft.Xrm.Sdk.EntityReference ContractDetailId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contractdetailid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ContractDetailId");
//            this.SetAttributeValue("contractdetailid", value);
//            this.OnPropertyChanged("ContractDetailId");
//        }
//    }

//    /// <summary>
//    /// 고객이 지원 서비스를 받을 수 있도록 서비스 케이스가 기록되어야 하는 서비스 계약을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractid")]
//    public Microsoft.Xrm.Sdk.EntityReference ContractId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contractid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ContractId");
//            this.SetAttributeValue("contractid", value);
//            this.OnPropertyChanged("ContractId");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 올바르게 처리되도록 서비스 케이스의 서비스 수준을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractservicelevelcode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue ContractServiceLevelCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("contractservicelevelcode");
//        }
//        set
//        {
//            this.OnPropertyChanging("ContractServiceLevelCode");
//            this.SetAttributeValue("contractservicelevelcode", value);
//            this.OnPropertyChanged("ContractServiceLevelCode");
//        }
//    }

//    /// <summary>
//    /// 레코드를 만든 사람을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
//    public Microsoft.Xrm.Sdk.EntityReference CreatedBy
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
//        }
//    }

//    /// <summary>
//    /// 레코드를 만든 외부 대상을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyexternalparty")]
//    public Microsoft.Xrm.Sdk.EntityReference CreatedByExternalParty
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdbyexternalparty");
//        }
//    }

//    /// <summary>
//    /// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
//    public System.Nullable<System.DateTime> CreatedOn
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
//        }
//    }

//    /// <summary>
//    /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
//    public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
//        }
//    }

//    /// <summary>
//    /// 고객 지원 담당자가 고객에게 연락할지 여부를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customercontacted")]
//    public System.Nullable<bool> CustomerContacted
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("customercontacted");
//        }
//        set
//        {
//            this.OnPropertyChanging("CustomerContacted");
//            this.SetAttributeValue("customercontacted", value);
//            this.OnPropertyChanged("CustomerContacted");
//        }
//    }

//    /// <summary>
//    /// 거래처 정보, 활동, 영업 기회와 같은 추가 고객 정보에 대한 퀵 링크를 제공하는 고객 거래처 또는 연락처를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customerid")]
//    public Microsoft.Xrm.Sdk.EntityReference CustomerId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("customerid");
//        }
//        set
//        {
//            this.OnPropertyChanging("CustomerId");
//            this.SetAttributeValue("customerid", value);
//            this.OnPropertyChanged("CustomerId");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스 처리 및 해결에 대한 고객의 만족도 수준을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customersatisfactioncode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue CustomerSatisfactionCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customersatisfactioncode");
//        }
//        set
//        {
//            this.OnPropertyChanging("CustomerSatisfactionCode");
//            this.SetAttributeValue("customersatisfactioncode", value);
//            this.OnPropertyChanged("CustomerSatisfactionCode");
//        }
//    }

//    /// <summary>
//    /// 연결된 권리 유형의 조건을 줄일지 여부를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("decremententitlementterm")]
//    public System.Nullable<bool> DecrementEntitlementTerm
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("decremententitlementterm");
//        }
//        set
//        {
//            this.OnPropertyChanging("DecrementEntitlementTerm");
//            this.SetAttributeValue("decremententitlementterm", value);
//            this.OnPropertyChanged("DecrementEntitlementTerm");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스 해결 시 서비스 팀을 지원하도록 서비스 케이스를 설명하는 추가 정보를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
//    public string Description
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("description");
//        }
//        set
//        {
//            this.OnPropertyChanging("Description");
//            this.SetAttributeValue("description", value);
//            this.OnPropertyChanged("Description");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스에 적용되는 권리 유형을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entitlementid")]
//    public Microsoft.Xrm.Sdk.EntityReference EntitlementId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("entitlementid");
//        }
//        set
//        {
//            this.OnPropertyChanging("EntitlementId");
//            this.SetAttributeValue("entitlementid", value);
//            this.OnPropertyChanged("EntitlementId");
//        }
//    }

//    /// <summary>
//    /// 엔터티의 기본 이미지입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
//    public byte[] EntityImage
//    {
//        get
//        {
//            return this.GetAttributeValue<byte[]>("entityimage");
//        }
//        set
//        {
//            this.OnPropertyChanging("EntityImage");
//            this.SetAttributeValue("entityimage", value);
//            this.OnPropertyChanged("EntityImage");
//        }
//    }

//    /// <summary>
//    ///
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
//    public System.Nullable<long> EntityImage_Timestamp
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
//        }
//    }

//    /// <summary>
//    ///
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
//    public string EntityImage_URL
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("entityimage_url");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
//    public System.Nullable<System.Guid> EntityImageId
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 에스컬레이션된 날짜 및 시간을 나타냅니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("escalatedon")]
//    public System.Nullable<System.DateTime> EscalatedOn
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("escalatedon");
//        }
//    }

//    /// <summary>
//    /// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
//    public System.Nullable<decimal> ExchangeRate
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
//        }
//    }

//    /// <summary>
//    /// 채워진 고객에 대한 기존 서비스 케이스를 선택하십시오. 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("existingcase")]
//    public Microsoft.Xrm.Sdk.EntityReference ExistingCase
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("existingcase");
//        }
//        set
//        {
//            this.OnPropertyChanging("ExistingCase");
//            this.SetAttributeValue("existingcase", value);
//            this.OnPropertyChanged("ExistingCase");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponsebykpiid")]
//    public Microsoft.Xrm.Sdk.EntityReference FirstResponseByKPIId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("firstresponsebykpiid");
//        }
//        set
//        {
//            this.OnPropertyChanging("FirstResponseByKPIId");
//            this.SetAttributeValue("firstresponsebykpiid", value);
//            this.OnPropertyChanged("FirstResponseByKPIId");
//        }
//    }

//    /// <summary>
//    /// 첫 응답을 보냈는지 여부를 나타냅니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponsesent")]
//    public System.Nullable<bool> FirstResponseSent
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("firstresponsesent");
//        }
//        set
//        {
//            this.OnPropertyChanging("FirstResponseSent");
//            this.SetAttributeValue("firstresponsesent", value);
//            this.OnPropertyChanged("FirstResponseSent");
//        }
//    }

//    /// <summary>
//    /// SLA 조건에 따라 서비스 케이스에 대한 첫 응답 시간의 상태를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponseslastatus")]
//    public Microsoft.Xrm.Sdk.OptionSetValue FirstResponseSLAStatus
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("firstresponseslastatus");
//        }
//        set
//        {
//            this.OnPropertyChanging("FirstResponseSLAStatus");
//            this.SetAttributeValue("firstresponseslastatus", value);
//            this.OnPropertyChanged("FirstResponseSLAStatus");
//        }
//    }

//    /// <summary>
//    /// 고객 지원 담당자가 이 서비스 케이스의 고객에 대한 후속작업을 수행해야 하는 날짜를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followupby")]
//    public System.Nullable<System.DateTime> FollowupBy
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("followupby");
//        }
//        set
//        {
//            this.OnPropertyChanging("FollowupBy");
//            this.SetAttributeValue("followupby", value);
//            this.OnPropertyChanged("FollowupBy");
//        }
//    }

//    /// <summary>
//    /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followuptaskcreated")]
//    public System.Nullable<bool> FollowUpTaskCreated
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("followuptaskcreated");
//        }
//        set
//        {
//            this.OnPropertyChanging("FollowUpTaskCreated");
//            this.SetAttributeValue("followuptaskcreated", value);
//            this.OnPropertyChanged("FollowUpTaskCreated");
//        }
//    }

//    /// <summary>
//    /// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
//    public System.Nullable<int> ImportSequenceNumber
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
//        }
//        set
//        {
//            this.OnPropertyChanging("ImportSequenceNumber");
//            this.SetAttributeValue("importsequencenumber", value);
//            this.OnPropertyChanged("ImportSequenceNumber");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentid")]
//    public System.Nullable<System.Guid> IncidentId
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.Guid>>("incidentid");
//        }
//        set
//        {
//            this.OnPropertyChanging("IncidentId");
//            this.SetAttributeValue("incidentid", value);
//            if (value.HasValue)
//            {
//                base.Id = value.Value;
//            }
//            else
//            {
//                base.Id = System.Guid.Empty;
//            }
//            this.OnPropertyChanged("IncidentId");
//        }
//    }

//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentid")]
//    public override System.Guid Id
//    {
//        get
//        {
//            return base.Id;
//        }
//        set
//        {
//            this.IncidentId = value;
//        }
//    }

//    /// <summary>
//    /// 서비스 팀 구성원이 서비스 케이스를 검토하거나 전송할 때 서비스 팀 구성원을 지원하도록 서비스 케이스에 대해 서비스 프로세스의 현재 스테이지를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentstagecode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue IncidentStageCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("incidentstagecode");
//        }
//        set
//        {
//            this.OnPropertyChanging("IncidentStageCode");
//            this.SetAttributeValue("incidentstagecode", value);
//            this.OnPropertyChanged("IncidentStageCode");
//        }
//    }

//    /// <summary>
//    /// NetBreeze의 영향도를 포함합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("influencescore")]
//    public System.Nullable<double> InfluenceScore
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<double>>("influencescore");
//        }
//        set
//        {
//            this.OnPropertyChanging("InfluenceScore");
//            this.SetAttributeValue("influencescore", value);
//            this.OnPropertyChanged("InfluenceScore");
//        }
//    }

//    /// <summary>
//    /// Shows customer satisfaction by tracking effort required by the customer. Low scores typically mean higher customer satisfaction as the customer had to travel through less channels to find a resolution
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_customereffort")]
//    public Microsoft.Xrm.Sdk.OptionSetValue int_CustomerEffort
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("int_customereffort");
//        }
//        set
//        {
//            this.OnPropertyChanging("int_CustomerEffort");
//            this.SetAttributeValue("int_customereffort", value);
//            this.OnPropertyChanged("int_CustomerEffort");
//        }
//    }

//    /// <summary>
//    /// Identifies whether a customer is willing to participate in a customer satisfaction survey.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_surveryparticipation")]
//    public System.Nullable<bool> int_SurveryParticipation
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("int_surveryparticipation");
//        }
//        set
//        {
//            this.OnPropertyChanging("int_SurveryParticipation");
//            this.SetAttributeValue("int_surveryparticipation", value);
//            this.OnPropertyChanged("int_SurveryParticipation");
//        }
//    }

//    /// <summary>
//    ///
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_surveyparticipation")]
//    public System.Nullable<bool> int_SurveyParticipation
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("int_surveyparticipation");
//        }
//        set
//        {
//            this.OnPropertyChanging("int_SurveyParticipation");
//            this.SetAttributeValue("int_surveyparticipation", value);
//            this.OnPropertyChanged("int_SurveyParticipation");
//        }
//    }

//    /// <summary>
//    /// Mark Yes if an opportunity exists to sell additional products or services to the customer.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_upsellreferral")]
//    public System.Nullable<bool> int_UpSellReferral
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("int_upsellreferral");
//        }
//        set
//        {
//            this.OnPropertyChanging("int_UpSellReferral");
//            this.SetAttributeValue("int_upsellreferral", value);
//            this.OnPropertyChanged("int_UpSellReferral");
//        }
//    }

//    /// <summary>
//    /// 시스템 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdecrementing")]
//    public System.Nullable<bool> IsDecrementing
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("isdecrementing");
//        }
//        set
//        {
//            this.OnPropertyChanging("IsDecrementing");
//            this.SetAttributeValue("isdecrementing", value);
//            this.OnPropertyChanged("IsDecrementing");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 에스컬레이션되었는지 여부를 나타냅니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isescalated")]
//    public System.Nullable<bool> IsEscalated
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("isescalated");
//        }
//        set
//        {
//            this.OnPropertyChanging("IsEscalated");
//            this.SetAttributeValue("isescalated", value);
//            this.OnPropertyChanged("IsEscalated");
//        }
//    }

//    /// <summary>
//    /// 고객에 대한 후속작업 또는 조사 시 참조용으로 추가 정보 또는 서비스 케이스 해결 방법을 포함하는 문서를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kbarticleid")]
//    public Microsoft.Xrm.Sdk.EntityReference KbArticleId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("kbarticleid");
//        }
//        set
//        {
//            this.OnPropertyChanging("KbArticleId");
//            this.SetAttributeValue("kbarticleid", value);
//            this.OnPropertyChanged("KbArticleId");
//        }
//    }

//    /// <summary>
//    /// 마지막 보류 중 시간의 날짜 시간 스탬프가 포함됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
//    public System.Nullable<System.DateTime> LastOnHoldTime
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
//        }
//        set
//        {
//            this.OnPropertyChanging("LastOnHoldTime");
//            this.SetAttributeValue("lastonholdtime", value);
//            this.OnPropertyChanged("LastOnHoldTime");
//        }
//    }

//    /// <summary>
//    /// 현재 서비스 케이스가 병합된 기본 서비스 케이스를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("masterid")]
//    public Microsoft.Xrm.Sdk.EntityReference MasterId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("masterid");
//        }
//        set
//        {
//            this.OnPropertyChanging("MasterId");
//            this.SetAttributeValue("masterid", value);
//            this.OnPropertyChanged("MasterId");
//        }
//    }

//    /// <summary>
//    /// 문제가 다른 문제와 병합되었는지 여부를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("merged")]
//    public System.Nullable<bool> Merged
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("merged");
//        }
//    }

//    /// <summary>
//    /// 게시물이 공개 메시지인지 아니면 개인 메시지인지를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("messagetypecode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue MessageTypeCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("messagetypecode");
//        }
//        set
//        {
//            this.OnPropertyChanging("MessageTypeCode");
//            this.SetAttributeValue("messagetypecode", value);
//            this.OnPropertyChanged("MessageTypeCode");
//        }
//    }

//    /// <summary>
//    /// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
//    public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
//        }
//    }

//    /// <summary>
//    /// 레코드를 수정한 외부 대상을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyexternalparty")]
//    public Microsoft.Xrm.Sdk.EntityReference ModifiedByExternalParty
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedbyexternalparty");
//        }
//    }

//    /// <summary>
//    /// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
//    public System.Nullable<System.DateTime> ModifiedOn
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
//        }
//    }

//    /// <summary>
//    /// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
//    public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스에 연결된 문제 유형의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_incidenttype")]
//    public Microsoft.Xrm.Sdk.EntityReference msdyn_IncidentType
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_incidenttype");
//        }
//        set
//        {
//            this.OnPropertyChanging("msdyn_IncidentType");
//            this.SetAttributeValue("msdyn_incidenttype", value);
//            this.OnPropertyChanged("msdyn_IncidentType");
//        }
//    }

//    /// <summary>
//    /// 문제와 연관된 하위 문제 수입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberofchildincidents")]
//    public System.Nullable<int> NumberOfChildIncidents
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("numberofchildincidents");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 보류 중인 기간(분)을 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
//    public System.Nullable<int> OnHoldTime
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
//        }
//    }

//    /// <summary>
//    /// 레코드를 마이그레이션한 날짜 및 시간입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
//    public System.Nullable<System.DateTime> OverriddenCreatedOn
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
//        }
//        set
//        {
//            this.OnPropertyChanging("OverriddenCreatedOn");
//            this.SetAttributeValue("overriddencreatedon", value);
//            this.OnPropertyChanged("OverriddenCreatedOn");
//        }
//    }

//    /// <summary>
//    /// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
//    public Microsoft.Xrm.Sdk.EntityReference OwnerId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
//        }
//        set
//        {
//            this.OnPropertyChanging("OwnerId");
//            this.SetAttributeValue("ownerid", value);
//            this.OnPropertyChanged("OwnerId");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스를 담당하는 사업부의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
//    public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스를 담당하는 팀의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
//    public Microsoft.Xrm.Sdk.EntityReference OwningTeam
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스를 담당하는 사용자의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
//    public Microsoft.Xrm.Sdk.EntityReference OwningUser
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스의 상위 서비스 케이스를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentcaseid")]
//    public Microsoft.Xrm.Sdk.EntityReference ParentCaseId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentcaseid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ParentCaseId");
//            this.SetAttributeValue("parentcaseid", value);
//            this.OnPropertyChanged("ParentCaseId");
//        }
//    }

//    /// <summary>
//    /// 이 서비스 케이스의 기본 연락처를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primarycontactid")]
//    public Microsoft.Xrm.Sdk.EntityReference PrimaryContactId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("primarycontactid");
//        }
//        set
//        {
//            this.OnPropertyChanging("PrimaryContactId");
//            this.SetAttributeValue("primarycontactid", value);
//            this.OnPropertyChanged("PrimaryContactId");
//        }
//    }

//    /// <summary>
//    /// 선호 고객 또는 주요 문제를 빠르게 처리하도록 우선 순위를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue PriorityCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("prioritycode");
//        }
//        set
//        {
//            this.OnPropertyChanging("PriorityCode");
//            this.SetAttributeValue("prioritycode", value);
//            this.OnPropertyChanged("PriorityCode");
//        }
//    }

//    /// <summary>
//    /// 프로세스의 ID를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
//    public System.Nullable<System.Guid> ProcessId
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ProcessId");
//            this.SetAttributeValue("processid", value);
//            this.OnPropertyChanged("ProcessId");
//        }
//    }

//    /// <summary>
//    /// 보증, 서비스 또는 기타 제품 문제를 식별하고 각 제품의 문제 수를 보고할 수 있도록 서비스 케이스와 연관된 제품을 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productid")]
//    public Microsoft.Xrm.Sdk.EntityReference ProductId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("productid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ProductId");
//            this.SetAttributeValue("productid", value);
//            this.OnPropertyChanged("ProductId");
//        }
//    }

//    /// <summary>
//    /// 제품 당 서비스 케이스 수를 보고할 수 있도록 이 서비스 케이스와 연관된 제품 일련 번호를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productserialnumber")]
//    public string ProductSerialNumber
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("productserialnumber");
//        }
//        set
//        {
//            this.OnPropertyChanging("ProductSerialNumber");
//            this.SetAttributeValue("productserialnumber", value);
//            this.OnPropertyChanged("ProductSerialNumber");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 해결되어야 하는 날짜를 입력합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolveby")]
//    public System.Nullable<System.DateTime> ResolveBy
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("resolveby");
//        }
//        set
//        {
//            this.OnPropertyChanging("ResolveBy");
//            this.SetAttributeValue("resolveby", value);
//            this.OnPropertyChanged("ResolveBy");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolvebykpiid")]
//    public Microsoft.Xrm.Sdk.EntityReference ResolveByKPIId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("resolvebykpiid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ResolveByKPIId");
//            this.SetAttributeValue("resolvebykpiid", value);
//            this.OnPropertyChanged("ResolveByKPIId");
//        }
//    }

//    /// <summary>
//    /// SLA 조건에 따라 서비스 케이스에 대한 해결 시간의 상태를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolvebyslastatus")]
//    public Microsoft.Xrm.Sdk.OptionSetValue ResolveBySLAStatus
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("resolvebyslastatus");
//        }
//        set
//        {
//            this.OnPropertyChanging("ResolveBySLAStatus");
//            this.SetAttributeValue("resolvebyslastatus", value);
//            this.OnPropertyChanged("ResolveBySLAStatus");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("responseby")]
//    public System.Nullable<System.DateTime> ResponseBy
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.DateTime>>("responseby");
//        }
//        set
//        {
//            this.OnPropertyChanging("ResponseBy");
//            this.SetAttributeValue("responseby", value);
//            this.OnPropertyChanged("ResponseBy");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스를 해결하는 데도 도움이 되는 추가 고객 연락처를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("responsiblecontactid")]
//    [System.ObsoleteAttribute()]
//    public Microsoft.Xrm.Sdk.EntityReference ResponsibleContactId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("responsiblecontactid");
//        }
//        set
//        {
//            this.OnPropertyChanging("ResponsibleContactId");
//            this.SetAttributeValue("responsiblecontactid", value);
//            this.OnPropertyChanged("ResponsibleContactId");
//        }
//    }

//    /// <summary>
//    /// 문제가 큐로 회람되었는지 여부를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("routecase")]
//    public System.Nullable<bool> RouteCase
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<bool>>("routecase");
//        }
//        set
//        {
//            this.OnPropertyChanging("RouteCase");
//            this.SetAttributeValue("routecase", value);
//            this.OnPropertyChanged("RouteCase");
//        }
//    }

//    /// <summary>
//    /// 소셜 게시물에서 발생하는 부정적, 중립적, 긍정적 관심도와 연결된 단어를 평가한 후 산출된 값입니다. 관심도 정보는 숫자 값으로 보고될 수도 있습니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sentimentvalue")]
//    public System.Nullable<double> SentimentValue
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<double>>("sentimentvalue");
//        }
//        set
//        {
//            this.OnPropertyChanging("SentimentValue");
//            this.SetAttributeValue("sentimentvalue", value);
//            this.OnPropertyChanged("SentimentValue");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스 해결 프로세스에서 서비스 케이스가 있는 스테이지를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("servicestage")]
//    public Microsoft.Xrm.Sdk.OptionSetValue ServiceStage
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("servicestage");
//        }
//        set
//        {
//            this.OnPropertyChanging("ServiceStage");
//            this.SetAttributeValue("servicestage", value);
//            this.OnPropertyChanged("ServiceStage");
//        }
//    }

//    /// <summary>
//    /// 고객의 비즈니스에 대해 문제의 영향을 나타내기 위해 이 서비스 케이스의 심각도를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("severitycode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue SeverityCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("severitycode");
//        }
//        set
//        {
//            this.OnPropertyChanging("SeverityCode");
//            this.SetAttributeValue("severitycode", value);
//            this.OnPropertyChanged("SeverityCode");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
//    public Microsoft.Xrm.Sdk.EntityReference SLAId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
//        }
//        set
//        {
//            this.OnPropertyChanging("SLAId");
//            this.SetAttributeValue("slaid", value);
//            this.OnPropertyChanged("SLAId");
//        }
//    }

//    /// <summary>
//    /// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
//    public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 연결된 소셜 프로필의 고유 식별자입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("socialprofileid")]
//    public Microsoft.Xrm.Sdk.EntityReference SocialProfileId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("socialprofileid");
//        }
//        set
//        {
//            this.OnPropertyChanging("SocialProfileId");
//            this.SetAttributeValue("socialprofileid", value);
//            this.OnPropertyChanged("SocialProfileId");
//        }
//    }

//    /// <summary>
//    /// 스테이지의 ID를 표시합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
//    public System.Nullable<System.Guid> StageId
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
//        }
//        set
//        {
//            this.OnPropertyChanging("StageId");
//            this.SetAttributeValue("stageid", value);
//            this.OnPropertyChanged("StageId");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스가 활성 상태인지, 해결되었는지, 아니면 취소되었는지를 표시합니다. 해결 및 취소된 서비스 케이스는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
//    public System.Nullable<IncidentState> StateCode
//    {
//        get
//        {
//            Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
//            if ((optionSet != null))
//            {
//                return ((IncidentState)(System.Enum.ToObject(typeof(IncidentState), optionSet.Value)));
//            }
//            else
//            {
//                return null;
//            }
//        }
//        set
//        {
//            this.OnPropertyChanging("StateCode");
//            if ((value == null))
//            {
//                this.SetAttributeValue("statecode", null);
//            }
//            else
//            {
//                this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
//            }
//            this.OnPropertyChanged("StateCode");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스의 상태를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
//    public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
//        }
//        set
//        {
//            this.OnPropertyChanging("StatusCode");
//            this.SetAttributeValue("statuscode", value);
//            this.OnPropertyChanged("StatusCode");
//        }
//    }

//    /// <summary>
//    /// 고객 서비스 관리자가 잦은 요청 또는 문제 영역을 식별할 수 있도록 카탈로그 요청 또는 제품 불만과 같은 서비스 케이스에 대한 주제를 선택합니다. 관리자는 [설정] 영역의 [비즈니스 관리]에서 주제를 구성할 수 있습니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subjectid")]
//    public Microsoft.Xrm.Sdk.EntityReference SubjectId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("subjectid");
//        }
//        set
//        {
//            this.OnPropertyChanging("SubjectId");
//            this.SetAttributeValue("subjectid", value);
//            this.OnPropertyChanged("SubjectId");
//        }
//    }

//    /// <summary>
//    /// 고객 참조 및 검색 가능성을 위해 서비스 케이스 번호를 표시합니다. 이 값은 수정할 수 없습니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ticketnumber")]
//    public string TicketNumber
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("ticketnumber");
//        }
//        set
//        {
//            this.OnPropertyChanging("TicketNumber");
//            this.SetAttributeValue("ticketnumber", value);
//            this.OnPropertyChanged("TicketNumber");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
//    public System.Nullable<int> TimeZoneRuleVersionNumber
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
//        }
//        set
//        {
//            this.OnPropertyChanging("TimeZoneRuleVersionNumber");
//            this.SetAttributeValue("timezoneruleversionnumber", value);
//            this.OnPropertyChanged("TimeZoneRuleVersionNumber");
//        }
//    }

//    /// <summary>
//    /// Microsoft Dynamics 365 보기에서 서비스 케이스를 식별하도록 주제 또는 설명하는 이름을 입력합니다(예: 요청, 문제 또는 회사 이름).
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("title")]
//    public string Title
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("title");
//        }
//        set
//        {
//            this.OnPropertyChanging("Title");
//            this.SetAttributeValue("title", value);
//            this.OnPropertyChanged("Title");
//        }
//    }

//    /// <summary>
//    /// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
//    public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
//    {
//        get
//        {
//            return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
//        }
//        set
//        {
//            this.OnPropertyChanging("TransactionCurrencyId");
//            this.SetAttributeValue("transactioncurrencyid", value);
//            this.OnPropertyChanged("TransactionCurrencyId");
//        }
//    }

//    /// <summary>
//    /// 내부 전용입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
//    public string TraversedPath
//    {
//        get
//        {
//            return this.GetAttributeValue<string>("traversedpath");
//        }
//        set
//        {
//            this.OnPropertyChanging("TraversedPath");
//            this.SetAttributeValue("traversedpath", value);
//            this.OnPropertyChanged("TraversedPath");
//        }
//    }

//    /// <summary>
//    /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
//    public System.Nullable<int> UTCConversionTimeZoneCode
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
//        }
//        set
//        {
//            this.OnPropertyChanging("UTCConversionTimeZoneCode");
//            this.SetAttributeValue("utcconversiontimezonecode", value);
//            this.OnPropertyChanged("UTCConversionTimeZoneCode");
//        }
//    }

//    /// <summary>
//    /// 서비스 케이스의 버전 번호입니다.
//    /// </summary>
//    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
//    public System.Nullable<long> VersionNumber
//    {
//        get
//        {
//            return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
//        }
//    }
//    #endregion Field
//}