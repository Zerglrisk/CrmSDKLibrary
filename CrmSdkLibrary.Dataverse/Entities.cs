using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.PowerPlatform.Dataverse.Client.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

// How to Make AutoGenerate File  :
//  .\CrmSvcUtil.exe /url:https://orgname.api.crm5.dynamics.com/XRMServices/2011/Organization.svc /username:domain\crmadmin /password:pass /out:CRMSdkTypes.cs
namespace CrmSdkLibrary.Dataverse
{
	/// <summary>
	/// 고객 회사 또는 잠재 고객 회사를 나타내며, 비즈니스 거래에서 청구 대상이 되는 회사입니다.
	/// </summary>
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("account")]
	[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
	public partial class Accounts : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		#region Field

		[System.Runtime.Serialization.DataContract()]
		[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
		public enum AccountState
		{
			[System.Runtime.Serialization.EnumMember()]
			Active = 0,

			[System.Runtime.Serialization.EnumMember()]
			Inactive = 1,
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public Accounts() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "account";

		public const int EntityTypeCode = 1;

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

		/// <summary>
		/// 고객 거래처가 표준 거래처인지, 아니면 선호 거래처인지를 나타내는 범주를 선택합니다.
		/// </summary>
		[AttributeLogicalName("accountcategorycode")]
		public OptionSetValue AccountCategoryCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("accountcategorycode");
			}
			set
			{
				OnPropertyChanging("AccountCategoryCode");
				SetAttributeValue("accountcategorycode", value);
				OnPropertyChanged("AccountCategoryCode");
			}
		}

		/// <summary>
		/// 투자, 협력 수준, 영업 주기 길이 또는 기타 조건에 대한 예상 수익에 근거하여 고객 거래처의 잠재적인 가치를 나타내는 분류 코드를 선택합니다.
		/// </summary>
		[AttributeLogicalName("accountclassificationcode")]
		public OptionSetValue AccountClassificationCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("accountclassificationcode");
			}
			set
			{
				OnPropertyChanging("AccountClassificationCode");
				SetAttributeValue("accountclassificationcode", value);
				OnPropertyChanged("AccountClassificationCode");
			}
		}

		/// <summary>
		/// 거래처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("accountid")]
		public Guid? AccountId
		{
			get
			{
				return GetAttributeValue<Guid?>("accountid");
			}
			set
			{
				OnPropertyChanging("AccountId");
				SetAttributeValue("accountid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = Guid.Empty;
				}
				OnPropertyChanged("AccountId");
			}
		}

		[AttributeLogicalName("accountid")]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				AccountId = value;
			}
		}

		/// <summary>
		/// 시스템 보기에서 거래처를 빠르게 검색 및 식별하기 위해 거래처의 ID 번호 또는 코드를 입력합니다.
		/// </summary>
		[AttributeLogicalName("accountnumber")]
		public string AccountNumber
		{
			get
			{
				return GetAttributeValue<string>("accountnumber");
			}
			set
			{
				OnPropertyChanging("AccountNumber");
				SetAttributeValue("accountnumber", value);
				OnPropertyChanged("AccountNumber");
			}
		}

		/// <summary>
		/// 고객 거래처의 가치를 나타내는 등급을 선택합니다.
		/// </summary>
		[AttributeLogicalName("accountratingcode")]
		public OptionSetValue AccountRatingCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("accountratingcode");
			}
			set
			{
				OnPropertyChanging("AccountRatingCode");
				SetAttributeValue("accountratingcode", value);
				OnPropertyChanged("AccountRatingCode");
			}
		}

		/// <summary>
		/// 주소 1의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("address1_addressid")]
		public Guid? Address1_AddressId
		{
			get
			{
				return GetAttributeValue<Guid?>("address1_addressid");
			}
			set
			{
				OnPropertyChanging("Address1_AddressId");
				SetAttributeValue("address1_addressid", value);
				OnPropertyChanged("Address1_AddressId");
			}
		}

		/// <summary>
		/// 기본 주소 유형을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_addresstypecode")]
		public OptionSetValue Address1_AddressTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_addresstypecode");
			}
			set
			{
				OnPropertyChanging("Address1_AddressTypeCode");
				SetAttributeValue("address1_addresstypecode", value);
				OnPropertyChanged("Address1_AddressTypeCode");
			}
		}

		/// <summary>
		/// 기본 주소의 구/군/시를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_city")]
		public string Address1_City
		{
			get
			{
				return GetAttributeValue<string>("address1_city");
			}
			set
			{
				OnPropertyChanging("Address1_City");
				SetAttributeValue("address1_city", value);
				OnPropertyChanged("Address1_City");
			}
		}

		/// <summary>
		/// 전체 기본 주소를 표시합니다.
		/// </summary>
		[AttributeLogicalName("address1_composite")]
		public string Address1_Composite
		{
			get
			{
				return GetAttributeValue<string>("address1_composite");
			}
		}

		/// <summary>
		/// 기본 주소의 국가 또는 지역을 입력합니다
		/// </summary>
		[AttributeLogicalName("address1_country")]
		public string Address1_Country
		{
			get
			{
				return GetAttributeValue<string>("address1_country");
			}
			set
			{
				OnPropertyChanging("Address1_Country");
				SetAttributeValue("address1_country", value);
				OnPropertyChanged("Address1_Country");
			}
		}

		/// <summary>
		/// 기본 주소의 군을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_county")]
		public string Address1_County
		{
			get
			{
				return GetAttributeValue<string>("address1_county");
			}
			set
			{
				OnPropertyChanging("Address1_County");
				SetAttributeValue("address1_county", value);
				OnPropertyChanged("Address1_County");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_fax")]
		public string Address1_Fax
		{
			get
			{
				return GetAttributeValue<string>("address1_fax");
			}
			set
			{
				OnPropertyChanging("Address1_Fax");
				SetAttributeValue("address1_fax", value);
				OnPropertyChanged("Address1_Fax");
			}
		}

		/// <summary>
		/// 운송 주문이 제대로 처리되도록 기본 주소의 운송료 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_freighttermscode")]
		public OptionSetValue Address1_FreightTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_freighttermscode");
			}
			set
			{
				OnPropertyChanging("Address1_FreightTermsCode");
				SetAttributeValue("address1_freighttermscode", value);
				OnPropertyChanged("Address1_FreightTermsCode");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 위도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_latitude")]
		public double? Address1_Latitude
		{
			get
			{
				return GetAttributeValue<double?>("address1_latitude");
			}
			set
			{
				OnPropertyChanging("Address1_Latitude");
				SetAttributeValue("address1_latitude", value);
				OnPropertyChanged("Address1_Latitude");
			}
		}

		/// <summary>
		/// 기본 주소의 첫 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line1")]
		public string Address1_Line1
		{
			get
			{
				return GetAttributeValue<string>("address1_line1");
			}
			set
			{
				OnPropertyChanging("Address1_Line1");
				SetAttributeValue("address1_line1", value);
				OnPropertyChanged("Address1_Line1");
			}
		}

		/// <summary>
		/// 기본 주소의 두 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line2")]
		public string Address1_Line2
		{
			get
			{
				return GetAttributeValue<string>("address1_line2");
			}
			set
			{
				OnPropertyChanging("Address1_Line2");
				SetAttributeValue("address1_line2", value);
				OnPropertyChanged("Address1_Line2");
			}
		}

		/// <summary>
		/// 기본 주소의 세 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line3")]
		public string Address1_Line3
		{
			get
			{
				return GetAttributeValue<string>("address1_line3");
			}
			set
			{
				OnPropertyChanging("Address1_Line3");
				SetAttributeValue("address1_line3", value);
				OnPropertyChanged("Address1_Line3");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 경도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_longitude")]
		public double? Address1_Longitude
		{
			get
			{
				return GetAttributeValue<double?>("address1_longitude");
			}
			set
			{
				OnPropertyChanging("Address1_Longitude");
				SetAttributeValue("address1_longitude", value);
				OnPropertyChanged("Address1_Longitude");
			}
		}

		/// <summary>
		/// 기본 주소를 설명하는 이름을 입력합니다(예: 본사).
		/// </summary>
		[AttributeLogicalName("address1_name")]
		public string Address1_Name
		{
			get
			{
				return GetAttributeValue<string>("address1_name");
			}
			set
			{
				OnPropertyChanging("Address1_Name");
				SetAttributeValue("address1_name", value);
				OnPropertyChanged("Address1_Name");
			}
		}

		/// <summary>
		/// 기본 주소의 우편 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_postalcode")]
		public string Address1_PostalCode
		{
			get
			{
				return GetAttributeValue<string>("address1_postalcode");
			}
			set
			{
				OnPropertyChanging("Address1_PostalCode");
				SetAttributeValue("address1_postalcode", value);
				OnPropertyChanged("Address1_PostalCode");
			}
		}

		/// <summary>
		/// 기본 주소의 사서함 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_postofficebox")]
		public string Address1_PostOfficeBox
		{
			get
			{
				return GetAttributeValue<string>("address1_postofficebox");
			}
			set
			{
				OnPropertyChanging("Address1_PostOfficeBox");
				SetAttributeValue("address1_postofficebox", value);
				OnPropertyChanged("Address1_PostOfficeBox");
			}
		}

		/// <summary>
		/// 거래처의 기본 주소에 기본 연락처 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_primarycontactname")]
		public string Address1_PrimaryContactName
		{
			get
			{
				return GetAttributeValue<string>("address1_primarycontactname");
			}
			set
			{
				OnPropertyChanging("Address1_PrimaryContactName");
				SetAttributeValue("address1_primarycontactname", value);
				OnPropertyChanged("Address1_PrimaryContactName");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_shippingmethodcode")]
		public OptionSetValue Address1_ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("Address1_ShippingMethodCode");
				SetAttributeValue("address1_shippingmethodcode", value);
				OnPropertyChanged("Address1_ShippingMethodCode");
			}
		}

		/// <summary>
		/// 기본 주소의 시/도를 입력합니다
		/// </summary>
		[AttributeLogicalName("address1_stateorprovince")]
		public string Address1_StateOrProvince
		{
			get
			{
				return GetAttributeValue<string>("address1_stateorprovince");
			}
			set
			{
				OnPropertyChanging("Address1_StateOrProvince");
				SetAttributeValue("address1_stateorprovince", value);
				OnPropertyChanged("Address1_StateOrProvince");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone1")]
		public string Address1_Telephone1
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone1");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone1");
				SetAttributeValue("address1_telephone1", value);
				OnPropertyChanged("Address1_Telephone1");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone2")]
		public string Address1_Telephone2
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone2");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone2");
				SetAttributeValue("address1_telephone2", value);
				OnPropertyChanged("Address1_Telephone2");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone3")]
		public string Address1_Telephone3
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone3");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone3");
				SetAttributeValue("address1_telephone3", value);
				OnPropertyChanged("Address1_Telephone3");
			}
		}

		/// <summary>
		/// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 기본 주소의 UPS 영역을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_upszone")]
		public string Address1_UPSZone
		{
			get
			{
				return GetAttributeValue<string>("address1_upszone");
			}
			set
			{
				OnPropertyChanging("Address1_UPSZone");
				SetAttributeValue("address1_upszone", value);
				OnPropertyChanged("Address1_UPSZone");
			}
		}

		/// <summary>
		/// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_utcoffset")]
		public int? Address1_UTCOffset
		{
			get
			{
				return GetAttributeValue<int?>("address1_utcoffset");
			}
			set
			{
				OnPropertyChanging("Address1_UTCOffset");
				SetAttributeValue("address1_utcoffset", value);
				OnPropertyChanged("Address1_UTCOffset");
			}
		}

		/// <summary>
		/// 주소 2의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("address2_addressid")]
		public Guid? Address2_AddressId
		{
			get
			{
				return GetAttributeValue<Guid?>("address2_addressid");
			}
			set
			{
				OnPropertyChanging("Address2_AddressId");
				SetAttributeValue("address2_addressid", value);
				OnPropertyChanged("Address2_AddressId");
			}
		}

		/// <summary>
		/// 보조 주소 유형을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_addresstypecode")]
		public OptionSetValue Address2_AddressTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_addresstypecode");
			}
			set
			{
				OnPropertyChanging("Address2_AddressTypeCode");
				SetAttributeValue("address2_addresstypecode", value);
				OnPropertyChanged("Address2_AddressTypeCode");
			}
		}

		/// <summary>
		/// 보조 주소의 구/군/시를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_city")]
		public string Address2_City
		{
			get
			{
				return GetAttributeValue<string>("address2_city");
			}
			set
			{
				OnPropertyChanging("Address2_City");
				SetAttributeValue("address2_city", value);
				OnPropertyChanged("Address2_City");
			}
		}

		/// <summary>
		/// 전체 보조 주소를 표시합니다.
		/// </summary>
		[AttributeLogicalName("address2_composite")]
		public string Address2_Composite
		{
			get
			{
				return GetAttributeValue<string>("address2_composite");
			}
		}

		/// <summary>
		/// 보조 주소의 국가 또는 지역을 입력합니다
		/// </summary>
		[AttributeLogicalName("address2_country")]
		public string Address2_Country
		{
			get
			{
				return GetAttributeValue<string>("address2_country");
			}
			set
			{
				OnPropertyChanging("Address2_Country");
				SetAttributeValue("address2_country", value);
				OnPropertyChanged("Address2_Country");
			}
		}

		/// <summary>
		/// 보조 주소의 군을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_county")]
		public string Address2_County
		{
			get
			{
				return GetAttributeValue<string>("address2_county");
			}
			set
			{
				OnPropertyChanging("Address2_County");
				SetAttributeValue("address2_county", value);
				OnPropertyChanged("Address2_County");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_fax")]
		public string Address2_Fax
		{
			get
			{
				return GetAttributeValue<string>("address2_fax");
			}
			set
			{
				OnPropertyChanging("Address2_Fax");
				SetAttributeValue("address2_fax", value);
				OnPropertyChanged("Address2_Fax");
			}
		}

		/// <summary>
		/// 운송 주문이 제대로 처리되도록 보조 주소의 운송료 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_freighttermscode")]
		public OptionSetValue Address2_FreightTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_freighttermscode");
			}
			set
			{
				OnPropertyChanging("Address2_FreightTermsCode");
				SetAttributeValue("address2_freighttermscode", value);
				OnPropertyChanged("Address2_FreightTermsCode");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 위도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_latitude")]
		public double? Address2_Latitude
		{
			get
			{
				return GetAttributeValue<double?>("address2_latitude");
			}
			set
			{
				OnPropertyChanging("Address2_Latitude");
				SetAttributeValue("address2_latitude", value);
				OnPropertyChanged("Address2_Latitude");
			}
		}

		/// <summary>
		/// 보조 주소의 첫 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line1")]
		public string Address2_Line1
		{
			get
			{
				return GetAttributeValue<string>("address2_line1");
			}
			set
			{
				OnPropertyChanging("Address2_Line1");
				SetAttributeValue("address2_line1", value);
				OnPropertyChanged("Address2_Line1");
			}
		}

		/// <summary>
		/// 보조 주소의 두 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line2")]
		public string Address2_Line2
		{
			get
			{
				return GetAttributeValue<string>("address2_line2");
			}
			set
			{
				OnPropertyChanging("Address2_Line2");
				SetAttributeValue("address2_line2", value);
				OnPropertyChanged("Address2_Line2");
			}
		}

		/// <summary>
		/// 보조 주소의 세 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line3")]
		public string Address2_Line3
		{
			get
			{
				return GetAttributeValue<string>("address2_line3");
			}
			set
			{
				OnPropertyChanging("Address2_Line3");
				SetAttributeValue("address2_line3", value);
				OnPropertyChanged("Address2_Line3");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 경도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_longitude")]
		public double? Address2_Longitude
		{
			get
			{
				return GetAttributeValue<double?>("address2_longitude");
			}
			set
			{
				OnPropertyChanging("Address2_Longitude");
				SetAttributeValue("address2_longitude", value);
				OnPropertyChanged("Address2_Longitude");
			}
		}

		/// <summary>
		/// 보조 주소를 설명하는 이름을 입력합니다(예: 본사).
		/// </summary>
		[AttributeLogicalName("address2_name")]
		public string Address2_Name
		{
			get
			{
				return GetAttributeValue<string>("address2_name");
			}
			set
			{
				OnPropertyChanging("Address2_Name");
				SetAttributeValue("address2_name", value);
				OnPropertyChanged("Address2_Name");
			}
		}

		/// <summary>
		/// 보조 주소의 우편 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_postalcode")]
		public string Address2_PostalCode
		{
			get
			{
				return GetAttributeValue<string>("address2_postalcode");
			}
			set
			{
				OnPropertyChanging("Address2_PostalCode");
				SetAttributeValue("address2_postalcode", value);
				OnPropertyChanged("Address2_PostalCode");
			}
		}

		/// <summary>
		/// 보조 주소의 사서함 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_postofficebox")]
		public string Address2_PostOfficeBox
		{
			get
			{
				return GetAttributeValue<string>("address2_postofficebox");
			}
			set
			{
				OnPropertyChanging("Address2_PostOfficeBox");
				SetAttributeValue("address2_postofficebox", value);
				OnPropertyChanged("Address2_PostOfficeBox");
			}
		}

		/// <summary>
		/// 거래처의 보조 주소에 기본 연락처 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_primarycontactname")]
		public string Address2_PrimaryContactName
		{
			get
			{
				return GetAttributeValue<string>("address2_primarycontactname");
			}
			set
			{
				OnPropertyChanging("Address2_PrimaryContactName");
				SetAttributeValue("address2_primarycontactname", value);
				OnPropertyChanged("Address2_PrimaryContactName");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_shippingmethodcode")]
		public OptionSetValue Address2_ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("Address2_ShippingMethodCode");
				SetAttributeValue("address2_shippingmethodcode", value);
				OnPropertyChanged("Address2_ShippingMethodCode");
			}
		}

		/// <summary>
		/// 보조 주소의 시/도를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_stateorprovince")]
		public string Address2_StateOrProvince
		{
			get
			{
				return GetAttributeValue<string>("address2_stateorprovince");
			}
			set
			{
				OnPropertyChanging("Address2_StateOrProvince");
				SetAttributeValue("address2_stateorprovince", value);
				OnPropertyChanged("Address2_StateOrProvince");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone1")]
		public string Address2_Telephone1
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone1");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone1");
				SetAttributeValue("address2_telephone1", value);
				OnPropertyChanged("Address2_Telephone1");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone2")]
		public string Address2_Telephone2
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone2");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone2");
				SetAttributeValue("address2_telephone2", value);
				OnPropertyChanged("Address2_Telephone2");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone3")]
		public string Address2_Telephone3
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone3");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone3");
				SetAttributeValue("address2_telephone3", value);
				OnPropertyChanged("Address2_Telephone3");
			}
		}

		/// <summary>
		/// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 보조 주소의 UPS 영역을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_upszone")]
		public string Address2_UPSZone
		{
			get
			{
				return GetAttributeValue<string>("address2_upszone");
			}
			set
			{
				OnPropertyChanging("Address2_UPSZone");
				SetAttributeValue("address2_upszone", value);
				OnPropertyChanged("Address2_UPSZone");
			}
		}

		/// <summary>
		/// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_utcoffset")]
		public int? Address2_UTCOffset
		{
			get
			{
				return GetAttributeValue<int?>("address2_utcoffset");
			}
			set
			{
				OnPropertyChanging("Address2_UTCOffset");
				SetAttributeValue("address2_utcoffset", value);
				OnPropertyChanged("Address2_UTCOffset");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging30")]
		public Money Aging30
		{
			get
			{
				return GetAttributeValue<Money>("aging30");
			}
		}

		/// <summary>
		/// 30일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
		/// </summary>
		[AttributeLogicalName("aging30_base")]
		public Money Aging30_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging30_base");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging60")]
		public Money Aging60
		{
			get
			{
				return GetAttributeValue<Money>("aging60");
			}
		}

		/// <summary>
		/// 60일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
		/// </summary>
		[AttributeLogicalName("aging60_base")]
		public Money Aging60_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging60_base");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging90")]
		public Money Aging90
		{
			get
			{
				return GetAttributeValue<Money>("aging90");
			}
		}

		/// <summary>
		/// 90일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
		/// </summary>
		[AttributeLogicalName("aging90_base")]
		public Money Aging90_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging90_base");
			}
		}

		/// <summary>
		/// 계약 또는 보고용으로 거래처의 법적 명칭 또는 기타 비즈니스 종류를 선택합니다.
		/// </summary>
		[AttributeLogicalName("businesstypecode")]
		public OptionSetValue BusinessTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("businesstypecode");
			}
			set
			{
				OnPropertyChanging("BusinessTypeCode");
				SetAttributeValue("businesstypecode", value);
				OnPropertyChanged("BusinessTypeCode");
			}
		}

		/// <summary>
		/// 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdby")]
		public EntityReference CreatedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdby");
			}
		}

		/// <summary>
		/// 레코드를 만든 외부 대상을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdbyexternalparty")]
		public EntityReference CreatedByExternalParty
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdbyexternalparty");
			}
		}

		/// <summary>
		/// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("createdon")]
		public DateTime? CreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("createdon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdonbehalfby")]
		public EntityReference CreatedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdonbehalfby");
			}
		}

		/// <summary>
		/// 거래처의 신용 한도액을 입력합니다. 송장 및 회계 문제를 고객에게 보낼 때 유용한 참조가 됩니다.
		/// </summary>
		[AttributeLogicalName("creditlimit")]
		public Money CreditLimit
		{
			get
			{
				return GetAttributeValue<Money>("creditlimit");
			}
			set
			{
				OnPropertyChanging("CreditLimit");
				SetAttributeValue("creditlimit", value);
				OnPropertyChanged("CreditLimit");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 신용 한도액을 표시합니다.
		/// </summary>
		[AttributeLogicalName("creditlimit_base")]
		public Money CreditLimit_Base
		{
			get
			{
				return GetAttributeValue<Money>("creditlimit_base");
			}
		}

		/// <summary>
		/// 거래처의 신용이 보류 중인지 여부를 선택합니다. 송장 및 회계 문제를 고객에게 보내는 동안 유용한 참조가 됩니다.
		/// </summary>
		[AttributeLogicalName("creditonhold")]
		public bool? CreditOnHold
		{
			get
			{
				return GetAttributeValue<bool?>("creditonhold");
			}
			set
			{
				OnPropertyChanging("CreditOnHold");
				SetAttributeValue("creditonhold", value);
				OnPropertyChanged("CreditOnHold");
			}
		}

		/// <summary>
		/// 세분화 및 보고용으로 거래처의 크기 범주 또는 범위를 선택합니다.
		/// </summary>
		[AttributeLogicalName("customersizecode")]
		public OptionSetValue CustomerSizeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("customersizecode");
			}
			set
			{
				OnPropertyChanging("CustomerSizeCode");
				SetAttributeValue("customersizecode", value);
				OnPropertyChanged("CustomerSizeCode");
			}
		}

		/// <summary>
		/// 거래처 및 조직 간의 관계를 가장 잘 설명하는 범주를 선택합니다.
		/// </summary>
		[AttributeLogicalName("customertypecode")]
		public OptionSetValue CustomerTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("customertypecode");
			}
			set
			{
				OnPropertyChanging("CustomerTypeCode");
				SetAttributeValue("customertypecode", value);
				OnPropertyChanged("CustomerTypeCode");
			}
		}

		/// <summary>
		/// 해당 고객에 대해 올바른 제품 가격이 영업 기회, 견적 및 주문에 적용되도록 거래처에 연결된 기본 가격표를 선택합니다.
		/// </summary>
		[AttributeLogicalName("defaultpricelevelid")]
		public EntityReference DefaultPriceLevelId
		{
			get
			{
				return GetAttributeValue<EntityReference>("defaultpricelevelid");
			}
			set
			{
				OnPropertyChanging("DefaultPriceLevelId");
				SetAttributeValue("defaultpricelevelid", value);
				OnPropertyChanged("DefaultPriceLevelId");
			}
		}

		/// <summary>
		/// 거래처를 설명하는 추가 정보를 입력합니다(예: 회사 웹 사이트에서의 발췌).
		/// </summary>
		[AttributeLogicalName("description")]
		public string Description
		{
			get
			{
				return GetAttributeValue<string>("description");
			}
			set
			{
				OnPropertyChanging("Description");
				SetAttributeValue("description", value);
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// 캠페인을 통해 보내는 대량 전자 메일을 거래처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 목록에는 추가될 수 있지만 전자 메일에서는 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotbulkemail")]
		public bool? DoNotBulkEMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotbulkemail");
			}
			set
			{
				OnPropertyChanging("DoNotBulkEMail");
				SetAttributeValue("donotbulkemail", value);
				OnPropertyChanged("DoNotBulkEMail");
			}
		}

		/// <summary>
		/// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 우편 메일을 거래처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 목록에는 추가될 수 있지만 우편 메일에서는 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotbulkpostalmail")]
		public bool? DoNotBulkPostalMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotbulkpostalmail");
			}
			set
			{
				OnPropertyChanging("DoNotBulkPostalMail");
				SetAttributeValue("donotbulkpostalmail", value);
				OnPropertyChanged("DoNotBulkPostalMail");
			}
		}

		/// <summary>
		/// Microsoft Dynamics 365에서 보내는 다이렉트 전자 메일을 거래처에서 허용할지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("donotemail")]
		public bool? DoNotEMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotemail");
			}
			set
			{
				OnPropertyChanging("DoNotEMail");
				SetAttributeValue("donotemail", value);
				OnPropertyChanged("DoNotEMail");
			}
		}

		/// <summary>
		/// 거래처에서 팩스를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 팩스 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotfax")]
		public bool? DoNotFax
		{
			get
			{
				return GetAttributeValue<bool?>("donotfax");
			}
			set
			{
				OnPropertyChanging("DoNotFax");
				SetAttributeValue("donotfax", value);
				OnPropertyChanged("DoNotFax");
			}
		}

		/// <summary>
		/// 거래처에서 전화 통화를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 전화 통화 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotphone")]
		public bool? DoNotPhone
		{
			get
			{
				return GetAttributeValue<bool?>("donotphone");
			}
			set
			{
				OnPropertyChanging("DoNotPhone");
				SetAttributeValue("donotphone", value);
				OnPropertyChanged("DoNotPhone");
			}
		}

		/// <summary>
		/// 거래처에서 다이렉트 메일을 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 편지 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotpostalmail")]
		public bool? DoNotPostalMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotpostalmail");
			}
			set
			{
				OnPropertyChanging("DoNotPostalMail");
				SetAttributeValue("donotpostalmail", value);
				OnPropertyChanged("DoNotPostalMail");
			}
		}

		/// <summary>
		/// 거래처에서 마케팅 자료(예: 브로슈어 또는 카탈로그)를 허용할지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("donotsendmm")]
		public bool? DoNotSendMM
		{
			get
			{
				return GetAttributeValue<bool?>("donotsendmm");
			}
			set
			{
				OnPropertyChanging("DoNotSendMM");
				SetAttributeValue("donotsendmm", value);
				OnPropertyChanged("DoNotSendMM");
			}
		}

		/// <summary>
		/// 거래처의 기본 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress1")]
		public string EMailAddress1
		{
			get
			{
				return GetAttributeValue<string>("emailaddress1");
			}
			set
			{
				OnPropertyChanging("EMailAddress1");
				SetAttributeValue("emailaddress1", value);
				OnPropertyChanged("EMailAddress1");
			}
		}

		/// <summary>
		/// 거래처의 보조 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress2")]
		public string EMailAddress2
		{
			get
			{
				return GetAttributeValue<string>("emailaddress2");
			}
			set
			{
				OnPropertyChanging("EMailAddress2");
				SetAttributeValue("emailaddress2", value);
				OnPropertyChanged("EMailAddress2");
			}
		}

		/// <summary>
		/// 거래처의 대체 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress3")]
		public string EMailAddress3
		{
			get
			{
				return GetAttributeValue<string>("emailaddress3");
			}
			set
			{
				OnPropertyChanging("EMailAddress3");
				SetAttributeValue("emailaddress3", value);
				OnPropertyChanged("EMailAddress3");
			}
		}

		/// <summary>
		/// 레코드의 기본 이미지를 표시합니다.
		/// </summary>
		[AttributeLogicalName("entityimage")]
		public byte[] EntityImage
		{
			get
			{
				return GetAttributeValue<byte[]>("entityimage");
			}
			set
			{
				OnPropertyChanging("EntityImage");
				SetAttributeValue("entityimage", value);
				OnPropertyChanged("EntityImage");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("entityimage_timestamp")]
		public long? EntityImage_Timestamp
		{
			get
			{
				return GetAttributeValue<long?>("entityimage_timestamp");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("entityimage_url")]
		public string EntityImage_URL
		{
			get
			{
				return GetAttributeValue<string>("entityimage_url");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("entityimageid")]
		public Guid? EntityImageId
		{
			get
			{
				return GetAttributeValue<Guid?>("entityimageid");
			}
		}

		/// <summary>
		/// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("exchangerate")]
		public decimal? ExchangeRate
		{
			get
			{
				return GetAttributeValue<decimal?>("exchangerate");
			}
		}

		/// <summary>
		/// 거래처의 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("fax")]
		public string Fax
		{
			get
			{
				return GetAttributeValue<string>("fax");
			}
			set
			{
				OnPropertyChanging("Fax");
				SetAttributeValue("fax", value);
				OnPropertyChanged("Fax");
			}
		}

		/// <summary>
		/// 거래처에 전송된 전자 메일에 대한 개봉, 첨부 파일 보기, 링크 클릭과 같은 전자 메일 활동을 팔로우하도록 허용할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("followemail")]
		public bool? FollowEmail
		{
			get
			{
				return GetAttributeValue<bool?>("followemail");
			}
			set
			{
				OnPropertyChanging("FollowEmail");
				SetAttributeValue("followemail", value);
				OnPropertyChanged("FollowEmail");
			}
		}

		/// <summary>
		/// 사용자가 데이터에 액세스하고 문서를 공유할 수 있도록 거래처의 FTP 사이트에 대한 URL을 입력합니다.
		/// </summary>
		[AttributeLogicalName("ftpsiteurl")]
		public string FtpSiteURL
		{
			get
			{
				return GetAttributeValue<string>("ftpsiteurl");
			}
			set
			{
				OnPropertyChanging("FtpSiteURL");
				SetAttributeValue("ftpsiteurl", value);
				OnPropertyChanged("FtpSiteURL");
			}
		}

		/// <summary>
		/// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("importsequencenumber")]
		public int? ImportSequenceNumber
		{
			get
			{
				return GetAttributeValue<int?>("importsequencenumber");
			}
			set
			{
				OnPropertyChanging("ImportSequenceNumber");
				SetAttributeValue("importsequencenumber", value);
				OnPropertyChanged("ImportSequenceNumber");
			}
		}

		/// <summary>
		/// 마케팅 세분화 및 인구 통계 분석에 사용할 거래처의 기본 산업을 선택합니다.
		/// </summary>
		[AttributeLogicalName("industrycode")]
		public OptionSetValue IndustryCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("industrycode");
			}
			set
			{
				OnPropertyChanging("IndustryCode");
				SetAttributeValue("industrycode", value);
				OnPropertyChanged("IndustryCode");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_facebook")]
		public string int_Facebook
		{
			get
			{
				return GetAttributeValue<string>("int_facebook");
			}
			set
			{
				OnPropertyChanging("int_Facebook");
				SetAttributeValue("int_facebook", value);
				OnPropertyChanged("int_Facebook");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_twitter")]
		public string int_Twitter
		{
			get
			{
				return GetAttributeValue<string>("int_twitter");
			}
			set
			{
				OnPropertyChanging("int_Twitter");
				SetAttributeValue("int_twitter", value);
				OnPropertyChanged("int_Twitter");
			}
		}

		/// <summary>
		/// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
		/// </summary>
		[AttributeLogicalName("lastonholdtime")]
		public DateTime? LastOnHoldTime
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastonholdtime");
			}
			set
			{
				OnPropertyChanging("LastOnHoldTime");
				SetAttributeValue("lastonholdtime", value);
				OnPropertyChanged("LastOnHoldTime");
			}
		}

		/// <summary>
		/// 거래처가 마지막으로 마케팅 캠페인 및 퀵 캠페인에 포함된 날짜를 표시합니다.
		/// </summary>
		[AttributeLogicalName("lastusedincampaign")]
		public DateTime? LastUsedInCampaign
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastusedincampaign");
			}
			set
			{
				OnPropertyChanging("LastUsedInCampaign");
				SetAttributeValue("lastusedincampaign", value);
				OnPropertyChanged("LastUsedInCampaign");
			}
		}

		/// <summary>
		/// 재무 성과 분석 지표로 사용되는 회사의 지분을 식별하는 거래처의 시가 총액을 입력합니다.
		/// </summary>
		[AttributeLogicalName("marketcap")]
		public Money MarketCap
		{
			get
			{
				return GetAttributeValue<Money>("marketcap");
			}
			set
			{
				OnPropertyChanging("MarketCap");
				SetAttributeValue("marketcap", value);
				OnPropertyChanged("MarketCap");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 시가 총액을 표시합니다.
		/// </summary>
		[AttributeLogicalName("marketcap_base")]
		public Money MarketCap_Base
		{
			get
			{
				return GetAttributeValue<Money>("marketcap_base");
			}
		}

		/// <summary>
		/// 마케팅 전용인지 여부
		/// </summary>
		[AttributeLogicalName("marketingonly")]
		public bool? MarketingOnly
		{
			get
			{
				return GetAttributeValue<bool?>("marketingonly");
			}
			set
			{
				OnPropertyChanging("MarketingOnly");
				SetAttributeValue("marketingonly", value);
				OnPropertyChanged("MarketingOnly");
			}
		}

		/// <summary>
		/// 거래처가 병합된 마스터 거래처를 표시합니다.
		/// </summary>
		[AttributeLogicalName("masterid")]
		public EntityReference MasterId
		{
			get
			{
				return GetAttributeValue<EntityReference>("masterid");
			}
		}

		/// <summary>
		/// 거래처가 다른 거래처와 병합되었는지 여부를 표시합니다.
		/// </summary>
		[AttributeLogicalName("merged")]
		public bool? Merged
		{
			get
			{
				return GetAttributeValue<bool?>("merged");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedby")]
		public EntityReference ModifiedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedby");
			}
		}

		/// <summary>
		/// 레코드를 수정한 외부 대상을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedbyexternalparty")]
		public EntityReference ModifiedByExternalParty
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedbyexternalparty");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("modifiedon")]
		public DateTime? ModifiedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("modifiedon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedonbehalfby")]
		public EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedonbehalfby");
			}
		}

		/// <summary>
		/// 청구에 사용되는 다른 계정에 대한 참조(청구 계정이 다른 경우에만 사용됨)
		/// </summary>
		[AttributeLogicalName("msdyn_billingaccount")]
		public EntityReference msdyn_BillingAccount
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_billingaccount");
			}
			set
			{
				OnPropertyChanging("msdyn_BillingAccount");
				SetAttributeValue("msdyn_billingaccount", value);
				OnPropertyChanged("msdyn_BillingAccount");
			}
		}

		/// <summary>
		/// 다른 시스템의 외부 계정 ID입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_externalaccountid")]
		public string msdyn_externalaccountid
		{
			get
			{
				return GetAttributeValue<string>("msdyn_externalaccountid");
			}
			set
			{
				OnPropertyChanging("msdyn_externalaccountid");
				SetAttributeValue("msdyn_externalaccountid", value);
				OnPropertyChanged("msdyn_externalaccountid");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("msdyn_preferredresource")]
		public EntityReference msdyn_PreferredResource
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_preferredresource");
			}
			set
			{
				OnPropertyChanging("msdyn_PreferredResource");
				SetAttributeValue("msdyn_preferredresource", value);
				OnPropertyChanged("msdyn_PreferredResource");
			}
		}

		/// <summary>
		/// 기본 판매세 코드
		/// </summary>
		[AttributeLogicalName("msdyn_salestaxcode")]
		public EntityReference msdyn_SalesTaxCode
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_salestaxcode");
			}
			set
			{
				OnPropertyChanging("msdyn_SalesTaxCode");
				SetAttributeValue("msdyn_salestaxcode", value);
				OnPropertyChanged("msdyn_SalesTaxCode");
			}
		}

		/// <summary>
		/// 이 거래처가 속한 서비스 지역입니다. 예약 및 회람을 최적화하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("msdyn_serviceterritory")]
		public EntityReference msdyn_ServiceTerritory
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_serviceterritory");
			}
			set
			{
				OnPropertyChanging("msdyn_ServiceTerritory");
				SetAttributeValue("msdyn_serviceterritory", value);
				OnPropertyChanged("msdyn_ServiceTerritory");
			}
		}

		/// <summary>
		/// 거래처가 면세인지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("msdyn_taxexempt")]
		public bool? msdyn_TaxExempt
		{
			get
			{
				return GetAttributeValue<bool?>("msdyn_taxexempt");
			}
			set
			{
				OnPropertyChanging("msdyn_TaxExempt");
				SetAttributeValue("msdyn_taxexempt", value);
				OnPropertyChanged("msdyn_TaxExempt");
			}
		}

		/// <summary>
		/// 정부의 세금 면제 번호를 표시합니다.
		/// </summary>
		[AttributeLogicalName("msdyn_taxexemptnumber")]
		public string msdyn_TaxExemptNumber
		{
			get
			{
				return GetAttributeValue<string>("msdyn_taxexemptnumber");
			}
			set
			{
				OnPropertyChanging("msdyn_TaxExemptNumber");
				SetAttributeValue("msdyn_taxexemptnumber", value);
				OnPropertyChanged("msdyn_TaxExemptNumber");
			}
		}

		/// <summary>
		/// 작업 주문에 포함할 이동 요금을 입력합니다. 이 값에 이동 요금 유형을 곱합니다.
		/// </summary>
		[AttributeLogicalName("msdyn_travelcharge")]
		public Money msdyn_TravelCharge
		{
			get
			{
				return GetAttributeValue<Money>("msdyn_travelcharge");
			}
			set
			{
				OnPropertyChanging("msdyn_TravelCharge");
				SetAttributeValue("msdyn_travelcharge", value);
				OnPropertyChanged("msdyn_TravelCharge");
			}
		}

		/// <summary>
		/// 기본 통화로 표시된 이동 요금 값입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_travelcharge_base")]
		public Money msdyn_travelcharge_Base
		{
			get
			{
				return GetAttributeValue<Money>("msdyn_travelcharge_base");
			}
		}

		/// <summary>
		/// 이 거래처에 부과되는 이동 방법을 지정합니다.
		/// </summary>
		[AttributeLogicalName("msdyn_travelchargetype")]
		public OptionSetValue msdyn_TravelChargeType
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("msdyn_travelchargetype");
			}
			set
			{
				OnPropertyChanging("msdyn_TravelChargeType");
				SetAttributeValue("msdyn_travelchargetype", value);
				OnPropertyChanged("msdyn_TravelChargeType");
			}
		}

		/// <summary>
		/// 새 작업 주문에 표시할 기본 지침을 표시합니다.
		/// </summary>
		[AttributeLogicalName("msdyn_workorderinstructions")]
		public string msdyn_WorkOrderInstructions
		{
			get
			{
				return GetAttributeValue<string>("msdyn_workorderinstructions");
			}
			set
			{
				OnPropertyChanging("msdyn_WorkOrderInstructions");
				SetAttributeValue("msdyn_workorderinstructions", value);
				OnPropertyChanged("msdyn_WorkOrderInstructions");
			}
		}

		/// <summary>
		/// 회사 또는 사업체 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("name")]
		public string Name
		{
			get
			{
				return GetAttributeValue<string>("name");
			}
			set
			{
				OnPropertyChanging("Name");
				SetAttributeValue("name", value);
				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("new_dt_found")]
		public DateTime? new_dt_found
		{
			get
			{
				return GetAttributeValue<DateTime?>("new_dt_found");
			}
			set
			{
				OnPropertyChanging("new_dt_found");
				SetAttributeValue("new_dt_found", value);
				OnPropertyChanged("new_dt_found");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("new_p_customer_level")]
		public OptionSetValue new_p_customer_level
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("new_p_customer_level");
			}
			set
			{
				OnPropertyChanging("new_p_customer_level");
				SetAttributeValue("new_p_customer_level", value);
				OnPropertyChanged("new_p_customer_level");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("new_txt_bizno")]
		public string new_txt_bizno
		{
			get
			{
				return GetAttributeValue<string>("new_txt_bizno");
			}
			set
			{
				OnPropertyChanging("new_txt_bizno");
				SetAttributeValue("new_txt_bizno", value);
				OnPropertyChanged("new_txt_bizno");
			}
		}

		/// <summary>
		/// 마케팅 세분화 및 인구 통계 분석에 사용할 거래처에서 일하는 직원 수를 입력합니다.
		/// </summary>
		[AttributeLogicalName("numberofemployees")]
		public int? NumberOfEmployees
		{
			get
			{
				return GetAttributeValue<int?>("numberofemployees");
			}
			set
			{
				OnPropertyChanging("NumberOfEmployees");
				SetAttributeValue("numberofemployees", value);
				OnPropertyChanged("NumberOfEmployees");
			}
		}

		/// <summary>
		/// 레코드가 보류 중인 시간을 분으로 표시합니다.
		/// </summary>
		[AttributeLogicalName("onholdtime")]
		public int? OnHoldTime
		{
			get
			{
				return GetAttributeValue<int?>("onholdtime");
			}
		}

		/// <summary>
		/// 거래처 및 해당 하위 거래처에 대해 시작된 영업 기회 수입니다.
		/// </summary>
		[AttributeLogicalName("opendeals")]
		public int? OpenDeals
		{
			get
			{
				return GetAttributeValue<int?>("opendeals");
			}
		}

		/// <summary>
		/// 시작된 거래의 날짜 시간입니다.
		/// </summary>
		[AttributeLogicalName("opendeals_date")]
		public DateTime? OpenDeals_Date
		{
			get
			{
				return GetAttributeValue<DateTime?>("opendeals_date");
			}
		}

		/// <summary>
		/// 시작된 거래의 상태입니다.
		/// </summary>
		[AttributeLogicalName("opendeals_state")]
		public int? OpenDeals_State
		{
			get
			{
				return GetAttributeValue<int?>("opendeals_state");
			}
		}

		/// <summary>
		/// 거래처 및 해당 하위 거래처에 대해 시작된 매출의 합계입니다.
		/// </summary>
		[AttributeLogicalName("openrevenue")]
		public Money OpenRevenue
		{
			get
			{
				return GetAttributeValue<Money>("openrevenue");
			}
		}

		/// <summary>
		/// 거래처 및 해당 하위 거래처에 대해 시작된 매출의 합계입니다.
		/// </summary>
		[AttributeLogicalName("openrevenue_base")]
		public Money OpenRevenue_Base
		{
			get
			{
				return GetAttributeValue<Money>("openrevenue_base");
			}
		}

		/// <summary>
		/// 시작된 매출의 날짜 시간입니다.
		/// </summary>
		[AttributeLogicalName("openrevenue_date")]
		public DateTime? OpenRevenue_Date
		{
			get
			{
				return GetAttributeValue<DateTime?>("openrevenue_date");
			}
		}

		/// <summary>
		/// 시작된 매출의 상태입니다.
		/// </summary>
		[AttributeLogicalName("openrevenue_state")]
		public int? OpenRevenue_State
		{
			get
			{
				return GetAttributeValue<int?>("openrevenue_state");
			}
		}

		/// <summary>
		/// 거래처가 Microsoft Dynamics 365의 잠재 고객을 변환하여 만들어진 경우 거래처가 만들어진 잠재 고객을 표시합니다. 이 값은 보고 및 분석용으로 거래처와 원래 잠재 고객의 데이터를 연결하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("originatingleadid")]
		public EntityReference OriginatingLeadId
		{
			get
			{
				return GetAttributeValue<EntityReference>("originatingleadid");
			}
			set
			{
				OnPropertyChanging("OriginatingLeadId");
				SetAttributeValue("originatingleadid", value);
				OnPropertyChanged("OriginatingLeadId");
			}
		}

		/// <summary>
		/// 레코드를 마이그레이션한 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("overriddencreatedon")]
		public DateTime? OverriddenCreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("overriddencreatedon");
			}
			set
			{
				OnPropertyChanging("OverriddenCreatedOn");
				SetAttributeValue("overriddencreatedon", value);
				OnPropertyChanged("OverriddenCreatedOn");
			}
		}

		/// <summary>
		/// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
		/// </summary>
		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("ownerid");
			}
			set
			{
				OnPropertyChanging("OwnerId");
				SetAttributeValue("ownerid", value);
				OnPropertyChanged("OwnerId");
			}
		}

		/// <summary>
		/// 거래처의 소유권 형태 구조를 선택합니다(예: 상장 또는 비상장).
		/// </summary>
		[AttributeLogicalName("ownershipcode")]
		public OptionSetValue OwnershipCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("ownershipcode");
			}
			set
			{
				OnPropertyChanging("OwnershipCode");
				SetAttributeValue("ownershipcode", value);
				OnPropertyChanged("OwnershipCode");
			}
		}

		/// <summary>
		/// 레코드 담당자가 속한 사업부를 표시합니다.
		/// </summary>
		[AttributeLogicalName("owningbusinessunit")]
		public EntityReference OwningBusinessUnit
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningbusinessunit");
			}
		}

		/// <summary>
		/// 거래처를 담당하는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningteam")]
		public EntityReference OwningTeam
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningteam");
			}
		}

		/// <summary>
		/// 거래처를 담당하는 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owninguser")]
		public EntityReference OwningUser
		{
			get
			{
				return GetAttributeValue<EntityReference>("owninguser");
			}
		}

		/// <summary>
		/// 보고 및 분석 시 상위 및 하위 사업을 표시하도록 이 거래처에 연결된 상위 거래처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("parentaccountid")]
		public EntityReference ParentAccountId
		{
			get
			{
				return GetAttributeValue<EntityReference>("parentaccountid");
			}
			set
			{
				OnPropertyChanging("ParentAccountId");
				SetAttributeValue("parentaccountid", value);
				OnPropertyChanged("ParentAccountId");
			}
		}

		/// <summary>
		/// 시스템 전용입니다. 레거시 Microsoft Dynamics CRM 3.0 워크플로 데이터입니다.
		/// </summary>
		[AttributeLogicalName("participatesinworkflow")]
		public bool? ParticipatesInWorkflow
		{
			get
			{
				return GetAttributeValue<bool?>("participatesinworkflow");
			}
			set
			{
				OnPropertyChanging("ParticipatesInWorkflow");
				SetAttributeValue("participatesinworkflow", value);
				OnPropertyChanged("ParticipatesInWorkflow");
			}
		}

		/// <summary>
		/// 고객이 총 금액을 지불해야 할 때 표시할 지불 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("paymenttermscode")]
		public OptionSetValue PaymentTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("paymenttermscode");
			}
			set
			{
				OnPropertyChanging("PaymentTermsCode");
				SetAttributeValue("paymenttermscode", value);
				OnPropertyChanged("PaymentTermsCode");
			}
		}

		/// <summary>
		/// 서비스 약속에 대해 선호하는 요일을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredappointmentdaycode")]
		public OptionSetValue PreferredAppointmentDayCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredappointmentdaycode");
			}
			set
			{
				OnPropertyChanging("PreferredAppointmentDayCode");
				SetAttributeValue("preferredappointmentdaycode", value);
				OnPropertyChanged("PreferredAppointmentDayCode");
			}
		}

		/// <summary>
		/// 서비스 약속에 대해 선호하는 하루 중 시간을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredappointmenttimecode")]
		public OptionSetValue PreferredAppointmentTimeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredappointmenttimecode");
			}
			set
			{
				OnPropertyChanging("PreferredAppointmentTimeCode");
				SetAttributeValue("preferredappointmenttimecode", value);
				OnPropertyChanged("PreferredAppointmentTimeCode");
			}
		}

		/// <summary>
		/// 선호하는 연락 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredcontactmethodcode")]
		public OptionSetValue PreferredContactMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredcontactmethodcode");
			}
			set
			{
				OnPropertyChanging("PreferredContactMethodCode");
				SetAttributeValue("preferredcontactmethodcode", value);
				OnPropertyChanged("PreferredContactMethodCode");
			}
		}

		/// <summary>
		/// 고객에 대한 서비스가 제대로 예약되도록 거래처의 선호 서비스 시설 또는 장비를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredequipmentid")]
		public EntityReference PreferredEquipmentId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredequipmentid");
			}
			set
			{
				OnPropertyChanging("PreferredEquipmentId");
				SetAttributeValue("preferredequipmentid", value);
				OnPropertyChanged("PreferredEquipmentId");
			}
		}

		/// <summary>
		/// 서비스 활동을 예약할 때 참조할 거래처의 선호 서비스를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredserviceid")]
		public EntityReference PreferredServiceId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredserviceid");
			}
			set
			{
				OnPropertyChanging("PreferredServiceId");
				SetAttributeValue("preferredserviceid", value);
				OnPropertyChanged("PreferredServiceId");
			}
		}

		/// <summary>
		/// 거래처에 대한 서비스 활동을 예약할 때 참조할 선호 서비스 담당자를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredsystemuserid")]
		public EntityReference PreferredSystemUserId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredsystemuserid");
			}
			set
			{
				OnPropertyChanging("PreferredSystemUserId");
				SetAttributeValue("preferredsystemuserid", value);
				OnPropertyChanged("PreferredSystemUserId");
			}
		}

		/// <summary>
		/// 연락처 정보에 대한 빠른 액세스를 제공하도록 거래처의 기본 연락처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("primarycontactid")]
		public EntityReference PrimaryContactId
		{
			get
			{
				return GetAttributeValue<EntityReference>("primarycontactid");
			}
			set
			{
				OnPropertyChanging("PrimaryContactId");
				SetAttributeValue("primarycontactid", value);
				OnPropertyChanged("PrimaryContactId");
			}
		}

		/// <summary>
		/// 계정의 기본 Satori ID
		/// </summary>
		[AttributeLogicalName("primarysatoriid")]
		public string PrimarySatoriId
		{
			get
			{
				return GetAttributeValue<string>("primarysatoriid");
			}
			set
			{
				OnPropertyChanging("PrimarySatoriId");
				SetAttributeValue("primarysatoriid", value);
				OnPropertyChanged("PrimarySatoriId");
			}
		}

		/// <summary>
		/// 계정의 기본 Twitter ID
		/// </summary>
		[AttributeLogicalName("primarytwitterid")]
		public string PrimaryTwitterId
		{
			get
			{
				return GetAttributeValue<string>("primarytwitterid");
			}
			set
			{
				OnPropertyChanging("PrimaryTwitterId");
				SetAttributeValue("primarytwitterid", value);
				OnPropertyChanged("PrimaryTwitterId");
			}
		}

		/// <summary>
		/// 프로세스의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("processid")]
		public Guid? ProcessId
		{
			get
			{
				return GetAttributeValue<Guid?>("processid");
			}
			set
			{
				OnPropertyChanging("ProcessId");
				SetAttributeValue("processid", value);
				OnPropertyChanged("ProcessId");
			}
		}

		/// <summary>
		/// 재무 성과 분석 지표로 사용되는 거래처의 연간 수익을 입력합니다.
		/// </summary>
		[AttributeLogicalName("revenue")]
		public Money Revenue
		{
			get
			{
				return GetAttributeValue<Money>("revenue");
			}
			set
			{
				OnPropertyChanging("Revenue");
				SetAttributeValue("revenue", value);
				OnPropertyChanged("Revenue");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 연간 수익을 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("revenue_base")]
		public Money Revenue_Base
		{
			get
			{
				return GetAttributeValue<Money>("revenue_base");
			}
		}

		/// <summary>
		/// 대중에게 허용되는 거래처의 주식 수를 입력합니다. 이 수는 재무 성과 분석 지표로 사용됩니다.
		/// </summary>
		[AttributeLogicalName("sharesoutstanding")]
		public int? SharesOutstanding
		{
			get
			{
				return GetAttributeValue<int?>("sharesoutstanding");
			}
			set
			{
				OnPropertyChanging("SharesOutstanding");
				SetAttributeValue("sharesoutstanding", value);
				OnPropertyChanged("SharesOutstanding");
			}
		}

		/// <summary>
		/// 선호 운송업체 또는 기타 배송 옵션을 지정하도록 거래처의 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("shippingmethodcode")]
		public OptionSetValue ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("ShippingMethodCode");
				SetAttributeValue("shippingmethodcode", value);
				OnPropertyChanged("ShippingMethodCode");
			}
		}

		/// <summary>
		/// 마케팅 세분화 및 인구 통계 분석용으로 거래처의 기본 산업을 나타내는 SIC(Standard Industrial Classification) 코드를 입력합니다.
		/// </summary>
		[AttributeLogicalName("sic")]
		public string SIC
		{
			get
			{
				return GetAttributeValue<string>("sic");
			}
			set
			{
				OnPropertyChanging("SIC");
				SetAttributeValue("sic", value);
				OnPropertyChanged("SIC");
			}
		}

		/// <summary>
		/// 거래처 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
		/// </summary>
		[AttributeLogicalName("slaid")]
		public EntityReference SLAId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slaid");
			}
			set
			{
				OnPropertyChanging("SLAId");
				SetAttributeValue("slaid", value);
				OnPropertyChanged("SLAId");
			}
		}

		/// <summary>
		/// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("slainvokedid")]
		public EntityReference SLAInvokedId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slainvokedid");
			}
		}

		/// <summary>
		/// 스테이지의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("stageid")]
		public Guid? StageId
		{
			get
			{
				return GetAttributeValue<Guid?>("stageid");
			}
			set
			{
				OnPropertyChanging("StageId");
				SetAttributeValue("stageid", value);
				OnPropertyChanged("StageId");
			}
		}

		/// <summary>
		/// 거래처가 활성인지, 아니면 비활성인지를 표시합니다. 비활성 거래처는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
		/// </summary>
		[AttributeLogicalName("statecode")]
		public AccountState? StateCode
		{
			get
			{
				OptionSetValue optionSet = GetAttributeValue<OptionSetValue>("statecode");
				if (optionSet != null)
				{
					return (AccountState)Enum.ToObject(typeof(AccountState), optionSet.Value);
				}
				else
				{
					return null;
				}
			}
			set
			{
				OnPropertyChanging("StateCode");
				if (value == null)
				{
					SetAttributeValue("statecode", null);
				}
				else
				{
					SetAttributeValue("statecode", new OptionSetValue((int)value));
				}
				OnPropertyChanged("StateCode");
			}
		}

		/// <summary>
		/// 거래처의 상태를 선택합니다.
		/// </summary>
		[AttributeLogicalName("statuscode")]
		public OptionSetValue StatusCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("statuscode");
			}
			set
			{
				OnPropertyChanging("StatusCode");
				SetAttributeValue("statuscode", value);
				OnPropertyChanged("StatusCode");
			}
		}

		/// <summary>
		/// 거래처에서 주식 및 회사의 재무 성과를 추적하기 위해 표시되는 증권 거래소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("stockexchange")]
		public string StockExchange
		{
			get
			{
				return GetAttributeValue<string>("stockexchange");
			}
			set
			{
				OnPropertyChanging("StockExchange");
				SetAttributeValue("stockexchange", value);
				OnPropertyChanged("StockExchange");
			}
		}

		/// <summary>
		/// 이 거래처의 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone1")]
		public string Telephone1
		{
			get
			{
				return GetAttributeValue<string>("telephone1");
			}
			set
			{
				OnPropertyChanging("Telephone1");
				SetAttributeValue("telephone1", value);
				OnPropertyChanged("Telephone1");
			}
		}

		/// <summary>
		/// 이 거래처의 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone2")]
		public string Telephone2
		{
			get
			{
				return GetAttributeValue<string>("telephone2");
			}
			set
			{
				OnPropertyChanging("Telephone2");
				SetAttributeValue("telephone2", value);
				OnPropertyChanged("Telephone2");
			}
		}

		/// <summary>
		/// 이 거래처의 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone3")]
		public string Telephone3
		{
			get
			{
				return GetAttributeValue<string>("telephone3");
			}
			set
			{
				OnPropertyChanging("Telephone3");
				SetAttributeValue("telephone3", value);
				OnPropertyChanged("Telephone3");
			}
		}

		/// <summary>
		/// 세분화 및 분석에 사용할 거래처의 지역 또는 권역을 선택합니다.
		/// </summary>
		[AttributeLogicalName("territorycode")]
		public OptionSetValue TerritoryCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("territorycode");
			}
			set
			{
				OnPropertyChanging("TerritoryCode");
				SetAttributeValue("territorycode", value);
				OnPropertyChanged("TerritoryCode");
			}
		}

		/// <summary>
		/// 거래처가 올바른 담당자에게 할당되고 세분화 및 분석에 사용하도록 거래처의 영업 지역 또는 권역을 선택합니다.
		/// </summary>
		[AttributeLogicalName("territoryid")]
		public EntityReference TerritoryId
		{
			get
			{
				return GetAttributeValue<EntityReference>("territoryid");
			}
			set
			{
				OnPropertyChanging("TerritoryId");
				SetAttributeValue("territoryid", value);
				OnPropertyChanged("TerritoryId");
			}
		}

		/// <summary>
		/// 회사의 재무 성과를 추적하기 위해 거래처에 대한 증권 거래소 종목 코드를 입력합니다. 이 필드에 입력한 코드를 클릭하면 MSN Money의 최신 거래 정보에 액세스할 수 있습니다.
		/// </summary>
		[AttributeLogicalName("tickersymbol")]
		public string TickerSymbol
		{
			get
			{
				return GetAttributeValue<string>("tickersymbol");
			}
			set
			{
				OnPropertyChanging("TickerSymbol");
				SetAttributeValue("tickersymbol", value);
				OnPropertyChanged("TickerSymbol");
			}
		}

		/// <summary>
		/// 거래처 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
		/// </summary>
		[AttributeLogicalName("timespentbymeonemailandmeetings")]
		public string TimeSpentByMeOnEmailAndMeetings
		{
			get
			{
				return GetAttributeValue<string>("timespentbymeonemailandmeetings");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("timezoneruleversionnumber")]
		public int? TimeZoneRuleVersionNumber
		{
			get
			{
				return GetAttributeValue<int?>("timezoneruleversionnumber");
			}
			set
			{
				OnPropertyChanging("TimeZoneRuleVersionNumber");
				SetAttributeValue("timezoneruleversionnumber", value);
				OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}

		/// <summary>
		/// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
		/// </summary>
		[AttributeLogicalName("transactioncurrencyid")]
		public EntityReference TransactionCurrencyId
		{
			get
			{
				return GetAttributeValue<EntityReference>("transactioncurrencyid");
			}
			set
			{
				OnPropertyChanging("TransactionCurrencyId");
				SetAttributeValue("transactioncurrencyid", value);
				OnPropertyChanged("TransactionCurrencyId");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("traversedpath")]
		public string TraversedPath
		{
			get
			{
				return GetAttributeValue<string>("traversedpath");
			}
			set
			{
				OnPropertyChanging("TraversedPath");
				SetAttributeValue("traversedpath", value);
				OnPropertyChanged("TraversedPath");
			}
		}

		/// <summary>
		/// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
		/// </summary>
		[AttributeLogicalName("utcconversiontimezonecode")]
		public int? UTCConversionTimeZoneCode
		{
			get
			{
				return GetAttributeValue<int?>("utcconversiontimezonecode");
			}
			set
			{
				OnPropertyChanging("UTCConversionTimeZoneCode");
				SetAttributeValue("utcconversiontimezonecode", value);
				OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}

		/// <summary>
		/// 거래처의 버전 번호입니다.
		/// </summary>
		[AttributeLogicalName("versionnumber")]
		public long? VersionNumber
		{
			get
			{
				return GetAttributeValue<long?>("versionnumber");
			}
		}

		/// <summary>
		/// 회사 프로필에 대한 빠른 정보를 얻기 위해 거래처의 웹 사이트 URL을 입력합니다.
		/// </summary>
		[AttributeLogicalName("websiteurl")]
		public string WebSiteURL
		{
			get
			{
				return GetAttributeValue<string>("websiteurl");
			}
			set
			{
				OnPropertyChanging("WebSiteURL");
				SetAttributeValue("websiteurl", value);
				OnPropertyChanged("WebSiteURL");
			}
		}

		/// <summary>
		/// 일본어로 지정된 경우 이름이 전화 통화 및 기타 통신 시 올바르게 발음되도록 회사 이름의 표음식 철자를 입력합니다.
		/// </summary>
		[AttributeLogicalName("yominame")]
		public string YomiName
		{
			get
			{
				return GetAttributeValue<string>("yominame");
			}
			set
			{
				OnPropertyChanging("YomiName");
				SetAttributeValue("yominame", value);
				OnPropertyChanged("YomiName");
			}
		}

		#endregion Field
	}

	/// <summary>
	/// 사업부와 관계가 있는 사람(예: 고객, 공급자, 동료)입니다.
	/// </summary>
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("contact")]
	[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
	public partial class Contacts : Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		#region Field

		[System.Runtime.Serialization.DataContract()]
		[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
		public enum ContactState
		{
			[System.Runtime.Serialization.EnumMember()]
			Active = 0,

			[System.Runtime.Serialization.EnumMember()]
			Inactive = 1,
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public Contacts() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "contact";

		public const int EntityTypeCode = 2;

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

		/// <summary>
		/// 연락처와 연관된 거래처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("accountid")]
		public EntityReference AccountId
		{
			get
			{
				return GetAttributeValue<EntityReference>("accountid");
			}
		}

		/// <summary>
		/// 회사 또는 영업 프로세스에서 연락처의 역할을 선택합니다(예: 의사 결정자, 직원 또는 영향력 행사자).
		/// </summary>
		[AttributeLogicalName("accountrolecode")]
		public OptionSetValue AccountRoleCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("accountrolecode");
			}
			set
			{
				OnPropertyChanging("AccountRoleCode");
				SetAttributeValue("accountrolecode", value);
				OnPropertyChanged("AccountRoleCode");
			}
		}

		/// <summary>
		/// 주소 1의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("address1_addressid")]
		public Guid? Address1_AddressId
		{
			get
			{
				return GetAttributeValue<Guid?>("address1_addressid");
			}
			set
			{
				OnPropertyChanging("Address1_AddressId");
				SetAttributeValue("address1_addressid", value);
				OnPropertyChanged("Address1_AddressId");
			}
		}

		/// <summary>
		/// 기본 주소 유형을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_addresstypecode")]
		public OptionSetValue Address1_AddressTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_addresstypecode");
			}
			set
			{
				OnPropertyChanging("Address1_AddressTypeCode");
				SetAttributeValue("address1_addresstypecode", value);
				OnPropertyChanged("Address1_AddressTypeCode");
			}
		}

		/// <summary>
		/// 기본 주소의 구/군/시를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_city")]
		public string Address1_City
		{
			get
			{
				return GetAttributeValue<string>("address1_city");
			}
			set
			{
				OnPropertyChanging("Address1_City");
				SetAttributeValue("address1_city", value);
				OnPropertyChanged("Address1_City");
			}
		}

		/// <summary>
		/// 전체 기본 주소를 표시합니다.
		/// </summary>
		[AttributeLogicalName("address1_composite")]
		public string Address1_Composite
		{
			get
			{
				return GetAttributeValue<string>("address1_composite");
			}
		}

		/// <summary>
		/// 기본 주소의 국가 또는 지역을 입력합니다
		/// </summary>
		[AttributeLogicalName("address1_country")]
		public string Address1_Country
		{
			get
			{
				return GetAttributeValue<string>("address1_country");
			}
			set
			{
				OnPropertyChanging("Address1_Country");
				SetAttributeValue("address1_country", value);
				OnPropertyChanged("Address1_Country");
			}
		}

		/// <summary>
		/// 기본 주소의 군을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_county")]
		public string Address1_County
		{
			get
			{
				return GetAttributeValue<string>("address1_county");
			}
			set
			{
				OnPropertyChanging("Address1_County");
				SetAttributeValue("address1_county", value);
				OnPropertyChanged("Address1_County");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_fax")]
		public string Address1_Fax
		{
			get
			{
				return GetAttributeValue<string>("address1_fax");
			}
			set
			{
				OnPropertyChanging("Address1_Fax");
				SetAttributeValue("address1_fax", value);
				OnPropertyChanged("Address1_Fax");
			}
		}

		/// <summary>
		/// 운송 주문이 제대로 처리되도록 기본 주소의 운송료 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_freighttermscode")]
		public OptionSetValue Address1_FreightTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_freighttermscode");
			}
			set
			{
				OnPropertyChanging("Address1_FreightTermsCode");
				SetAttributeValue("address1_freighttermscode", value);
				OnPropertyChanged("Address1_FreightTermsCode");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 위도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_latitude")]
		public double? Address1_Latitude
		{
			get
			{
				return GetAttributeValue<double?>("address1_latitude");
			}
			set
			{
				OnPropertyChanging("Address1_Latitude");
				SetAttributeValue("address1_latitude", value);
				OnPropertyChanged("Address1_Latitude");
			}
		}

		/// <summary>
		/// 기본 주소의 첫 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line1")]
		public string Address1_Line1
		{
			get
			{
				return GetAttributeValue<string>("address1_line1");
			}
			set
			{
				OnPropertyChanging("Address1_Line1");
				SetAttributeValue("address1_line1", value);
				OnPropertyChanged("Address1_Line1");
			}
		}

		/// <summary>
		/// 기본 주소의 두 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line2")]
		public string Address1_Line2
		{
			get
			{
				return GetAttributeValue<string>("address1_line2");
			}
			set
			{
				OnPropertyChanging("Address1_Line2");
				SetAttributeValue("address1_line2", value);
				OnPropertyChanged("Address1_Line2");
			}
		}

		/// <summary>
		/// 기본 주소의 세 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_line3")]
		public string Address1_Line3
		{
			get
			{
				return GetAttributeValue<string>("address1_line3");
			}
			set
			{
				OnPropertyChanging("Address1_Line3");
				SetAttributeValue("address1_line3", value);
				OnPropertyChanged("Address1_Line3");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 경도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_longitude")]
		public double? Address1_Longitude
		{
			get
			{
				return GetAttributeValue<double?>("address1_longitude");
			}
			set
			{
				OnPropertyChanging("Address1_Longitude");
				SetAttributeValue("address1_longitude", value);
				OnPropertyChanged("Address1_Longitude");
			}
		}

		/// <summary>
		/// 기본 주소를 설명하는 이름을 입력합니다(예: 본사).
		/// </summary>
		[AttributeLogicalName("address1_name")]
		public string Address1_Name
		{
			get
			{
				return GetAttributeValue<string>("address1_name");
			}
			set
			{
				OnPropertyChanging("Address1_Name");
				SetAttributeValue("address1_name", value);
				OnPropertyChanged("Address1_Name");
			}
		}

		/// <summary>
		/// 기본 주소의 우편 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_postalcode")]
		public string Address1_PostalCode
		{
			get
			{
				return GetAttributeValue<string>("address1_postalcode");
			}
			set
			{
				OnPropertyChanging("Address1_PostalCode");
				SetAttributeValue("address1_postalcode", value);
				OnPropertyChanged("Address1_PostalCode");
			}
		}

		/// <summary>
		/// 기본 주소의 사서함 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_postofficebox")]
		public string Address1_PostOfficeBox
		{
			get
			{
				return GetAttributeValue<string>("address1_postofficebox");
			}
			set
			{
				OnPropertyChanging("Address1_PostOfficeBox");
				SetAttributeValue("address1_postofficebox", value);
				OnPropertyChanged("Address1_PostOfficeBox");
			}
		}

		/// <summary>
		/// 거래처의 기본 주소에 기본 연락처 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_primarycontactname")]
		public string Address1_PrimaryContactName
		{
			get
			{
				return GetAttributeValue<string>("address1_primarycontactname");
			}
			set
			{
				OnPropertyChanging("Address1_PrimaryContactName");
				SetAttributeValue("address1_primarycontactname", value);
				OnPropertyChanged("Address1_PrimaryContactName");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_shippingmethodcode")]
		public OptionSetValue Address1_ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address1_shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("Address1_ShippingMethodCode");
				SetAttributeValue("address1_shippingmethodcode", value);
				OnPropertyChanged("Address1_ShippingMethodCode");
			}
		}

		/// <summary>
		/// 기본 주소의 시/도를 입력합니다
		/// </summary>
		[AttributeLogicalName("address1_stateorprovince")]
		public string Address1_StateOrProvince
		{
			get
			{
				return GetAttributeValue<string>("address1_stateorprovince");
			}
			set
			{
				OnPropertyChanging("Address1_StateOrProvince");
				SetAttributeValue("address1_stateorprovince", value);
				OnPropertyChanged("Address1_StateOrProvince");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone1")]
		public string Address1_Telephone1
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone1");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone1");
				SetAttributeValue("address1_telephone1", value);
				OnPropertyChanged("Address1_Telephone1");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone2")]
		public string Address1_Telephone2
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone2");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone2");
				SetAttributeValue("address1_telephone2", value);
				OnPropertyChanged("Address1_Telephone2");
			}
		}

		/// <summary>
		/// 기본 주소와 연관된 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_telephone3")]
		public string Address1_Telephone3
		{
			get
			{
				return GetAttributeValue<string>("address1_telephone3");
			}
			set
			{
				OnPropertyChanging("Address1_Telephone3");
				SetAttributeValue("address1_telephone3", value);
				OnPropertyChanged("Address1_Telephone3");
			}
		}

		/// <summary>
		/// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 기본 주소의 UPS 영역을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address1_upszone")]
		public string Address1_UPSZone
		{
			get
			{
				return GetAttributeValue<string>("address1_upszone");
			}
			set
			{
				OnPropertyChanging("Address1_UPSZone");
				SetAttributeValue("address1_upszone", value);
				OnPropertyChanged("Address1_UPSZone");
			}
		}

		/// <summary>
		/// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
		/// </summary>
		[AttributeLogicalName("address1_utcoffset")]
		public int? Address1_UTCOffset
		{
			get
			{
				return GetAttributeValue<int?>("address1_utcoffset");
			}
			set
			{
				OnPropertyChanging("Address1_UTCOffset");
				SetAttributeValue("address1_utcoffset", value);
				OnPropertyChanged("Address1_UTCOffset");
			}
		}

		/// <summary>
		/// 주소 2의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("address2_addressid")]
		public Guid? Address2_AddressId
		{
			get
			{
				return GetAttributeValue<Guid?>("address2_addressid");
			}
			set
			{
				OnPropertyChanging("Address2_AddressId");
				SetAttributeValue("address2_addressid", value);
				OnPropertyChanged("Address2_AddressId");
			}
		}

		/// <summary>
		/// 보조 주소 유형을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_addresstypecode")]
		public OptionSetValue Address2_AddressTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_addresstypecode");
			}
			set
			{
				OnPropertyChanging("Address2_AddressTypeCode");
				SetAttributeValue("address2_addresstypecode", value);
				OnPropertyChanged("Address2_AddressTypeCode");
			}
		}

		/// <summary>
		/// 보조 주소의 구/군/시를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_city")]
		public string Address2_City
		{
			get
			{
				return GetAttributeValue<string>("address2_city");
			}
			set
			{
				OnPropertyChanging("Address2_City");
				SetAttributeValue("address2_city", value);
				OnPropertyChanged("Address2_City");
			}
		}

		/// <summary>
		/// 전체 보조 주소를 표시합니다.
		/// </summary>
		[AttributeLogicalName("address2_composite")]
		public string Address2_Composite
		{
			get
			{
				return GetAttributeValue<string>("address2_composite");
			}
		}

		/// <summary>
		/// 보조 주소의 국가 또는 지역을 입력합니다
		/// </summary>
		[AttributeLogicalName("address2_country")]
		public string Address2_Country
		{
			get
			{
				return GetAttributeValue<string>("address2_country");
			}
			set
			{
				OnPropertyChanging("Address2_Country");
				SetAttributeValue("address2_country", value);
				OnPropertyChanged("Address2_Country");
			}
		}

		/// <summary>
		/// 보조 주소의 군을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_county")]
		public string Address2_County
		{
			get
			{
				return GetAttributeValue<string>("address2_county");
			}
			set
			{
				OnPropertyChanging("Address2_County");
				SetAttributeValue("address2_county", value);
				OnPropertyChanged("Address2_County");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_fax")]
		public string Address2_Fax
		{
			get
			{
				return GetAttributeValue<string>("address2_fax");
			}
			set
			{
				OnPropertyChanging("Address2_Fax");
				SetAttributeValue("address2_fax", value);
				OnPropertyChanged("Address2_Fax");
			}
		}

		/// <summary>
		/// 운송 주문이 제대로 처리되도록 보조 주소의 운송료 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_freighttermscode")]
		public OptionSetValue Address2_FreightTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_freighttermscode");
			}
			set
			{
				OnPropertyChanging("Address2_FreightTermsCode");
				SetAttributeValue("address2_freighttermscode", value);
				OnPropertyChanged("Address2_FreightTermsCode");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 위도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_latitude")]
		public double? Address2_Latitude
		{
			get
			{
				return GetAttributeValue<double?>("address2_latitude");
			}
			set
			{
				OnPropertyChanging("Address2_Latitude");
				SetAttributeValue("address2_latitude", value);
				OnPropertyChanged("Address2_Latitude");
			}
		}

		/// <summary>
		/// 보조 주소의 첫 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line1")]
		public string Address2_Line1
		{
			get
			{
				return GetAttributeValue<string>("address2_line1");
			}
			set
			{
				OnPropertyChanging("Address2_Line1");
				SetAttributeValue("address2_line1", value);
				OnPropertyChanged("Address2_Line1");
			}
		}

		/// <summary>
		/// 보조 주소의 두 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line2")]
		public string Address2_Line2
		{
			get
			{
				return GetAttributeValue<string>("address2_line2");
			}
			set
			{
				OnPropertyChanging("Address2_Line2");
				SetAttributeValue("address2_line2", value);
				OnPropertyChanged("Address2_Line2");
			}
		}

		/// <summary>
		/// 보조 주소의 세 번째 줄을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_line3")]
		public string Address2_Line3
		{
			get
			{
				return GetAttributeValue<string>("address2_line3");
			}
			set
			{
				OnPropertyChanging("Address2_Line3");
				SetAttributeValue("address2_line3", value);
				OnPropertyChanged("Address2_Line3");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 경도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_longitude")]
		public double? Address2_Longitude
		{
			get
			{
				return GetAttributeValue<double?>("address2_longitude");
			}
			set
			{
				OnPropertyChanging("Address2_Longitude");
				SetAttributeValue("address2_longitude", value);
				OnPropertyChanged("Address2_Longitude");
			}
		}

		/// <summary>
		/// 보조 주소를 설명하는 이름을 입력합니다(예: 본사).
		/// </summary>
		[AttributeLogicalName("address2_name")]
		public string Address2_Name
		{
			get
			{
				return GetAttributeValue<string>("address2_name");
			}
			set
			{
				OnPropertyChanging("Address2_Name");
				SetAttributeValue("address2_name", value);
				OnPropertyChanged("Address2_Name");
			}
		}

		/// <summary>
		/// 보조 주소의 우편 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_postalcode")]
		public string Address2_PostalCode
		{
			get
			{
				return GetAttributeValue<string>("address2_postalcode");
			}
			set
			{
				OnPropertyChanging("Address2_PostalCode");
				SetAttributeValue("address2_postalcode", value);
				OnPropertyChanged("Address2_PostalCode");
			}
		}

		/// <summary>
		/// 보조 주소의 사서함 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_postofficebox")]
		public string Address2_PostOfficeBox
		{
			get
			{
				return GetAttributeValue<string>("address2_postofficebox");
			}
			set
			{
				OnPropertyChanging("Address2_PostOfficeBox");
				SetAttributeValue("address2_postofficebox", value);
				OnPropertyChanged("Address2_PostOfficeBox");
			}
		}

		/// <summary>
		/// 거래처의 보조 주소에 기본 연락처 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_primarycontactname")]
		public string Address2_PrimaryContactName
		{
			get
			{
				return GetAttributeValue<string>("address2_primarycontactname");
			}
			set
			{
				OnPropertyChanging("Address2_PrimaryContactName");
				SetAttributeValue("address2_primarycontactname", value);
				OnPropertyChanged("Address2_PrimaryContactName");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_shippingmethodcode")]
		public OptionSetValue Address2_ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address2_shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("Address2_ShippingMethodCode");
				SetAttributeValue("address2_shippingmethodcode", value);
				OnPropertyChanged("Address2_ShippingMethodCode");
			}
		}

		/// <summary>
		/// 보조 주소의 시/도를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_stateorprovince")]
		public string Address2_StateOrProvince
		{
			get
			{
				return GetAttributeValue<string>("address2_stateorprovince");
			}
			set
			{
				OnPropertyChanging("Address2_StateOrProvince");
				SetAttributeValue("address2_stateorprovince", value);
				OnPropertyChanged("Address2_StateOrProvince");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone1")]
		public string Address2_Telephone1
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone1");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone1");
				SetAttributeValue("address2_telephone1", value);
				OnPropertyChanged("Address2_Telephone1");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone2")]
		public string Address2_Telephone2
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone2");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone2");
				SetAttributeValue("address2_telephone2", value);
				OnPropertyChanged("Address2_Telephone2");
			}
		}

		/// <summary>
		/// 보조 주소와 연관된 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_telephone3")]
		public string Address2_Telephone3
		{
			get
			{
				return GetAttributeValue<string>("address2_telephone3");
			}
			set
			{
				OnPropertyChanging("Address2_Telephone3");
				SetAttributeValue("address2_telephone3", value);
				OnPropertyChanged("Address2_Telephone3");
			}
		}

		/// <summary>
		/// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 보조 주소의 UPS 영역을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address2_upszone")]
		public string Address2_UPSZone
		{
			get
			{
				return GetAttributeValue<string>("address2_upszone");
			}
			set
			{
				OnPropertyChanging("Address2_UPSZone");
				SetAttributeValue("address2_upszone", value);
				OnPropertyChanged("Address2_UPSZone");
			}
		}

		/// <summary>
		/// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
		/// </summary>
		[AttributeLogicalName("address2_utcoffset")]
		public int? Address2_UTCOffset
		{
			get
			{
				return GetAttributeValue<int?>("address2_utcoffset");
			}
			set
			{
				OnPropertyChanging("Address2_UTCOffset");
				SetAttributeValue("address2_utcoffset", value);
				OnPropertyChanged("Address2_UTCOffset");
			}
		}

		/// <summary>
		/// 주소 3의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("address3_addressid")]
		public Guid? Address3_AddressId
		{
			get
			{
				return GetAttributeValue<Guid?>("address3_addressid");
			}
			set
			{
				OnPropertyChanging("Address3_AddressId");
				SetAttributeValue("address3_addressid", value);
				OnPropertyChanged("Address3_AddressId");
			}
		}

		/// <summary>
		/// 세 번째 주소 유형을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address3_addresstypecode")]
		public OptionSetValue Address3_AddressTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address3_addresstypecode");
			}
			set
			{
				OnPropertyChanging("Address3_AddressTypeCode");
				SetAttributeValue("address3_addresstypecode", value);
				OnPropertyChanged("Address3_AddressTypeCode");
			}
		}

		/// <summary>
		/// 세 번째 주소의 구/군/시를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_city")]
		public string Address3_City
		{
			get
			{
				return GetAttributeValue<string>("address3_city");
			}
			set
			{
				OnPropertyChanging("Address3_City");
				SetAttributeValue("address3_city", value);
				OnPropertyChanged("Address3_City");
			}
		}

		/// <summary>
		/// 전체 세 번째 주소를 표시합니다.
		/// </summary>
		[AttributeLogicalName("address3_composite")]
		public string Address3_Composite
		{
			get
			{
				return GetAttributeValue<string>("address3_composite");
			}
		}

		/// <summary>
		/// 세 번째 주소의 국가 또는 지역입니다.
		/// </summary>
		[AttributeLogicalName("address3_country")]
		public string Address3_Country
		{
			get
			{
				return GetAttributeValue<string>("address3_country");
			}
			set
			{
				OnPropertyChanging("Address3_Country");
				SetAttributeValue("address3_country", value);
				OnPropertyChanged("Address3_Country");
			}
		}

		/// <summary>
		/// 세 번째 주소의 군을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_county")]
		public string Address3_County
		{
			get
			{
				return GetAttributeValue<string>("address3_county");
			}
			set
			{
				OnPropertyChanging("Address3_County");
				SetAttributeValue("address3_county", value);
				OnPropertyChanged("Address3_County");
			}
		}

		/// <summary>
		/// 세 번째 주소에 연결된 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_fax")]
		public string Address3_Fax
		{
			get
			{
				return GetAttributeValue<string>("address3_fax");
			}
			set
			{
				OnPropertyChanging("Address3_Fax");
				SetAttributeValue("address3_fax", value);
				OnPropertyChanged("Address3_Fax");
			}
		}

		/// <summary>
		/// 운송 주문이 제대로 처리되도록 세 번째 주소의 운송료 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address3_freighttermscode")]
		public OptionSetValue Address3_FreightTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address3_freighttermscode");
			}
			set
			{
				OnPropertyChanging("Address3_FreightTermsCode");
				SetAttributeValue("address3_freighttermscode", value);
				OnPropertyChanged("Address3_FreightTermsCode");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 세 번째 주소의 위도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_latitude")]
		public double? Address3_Latitude
		{
			get
			{
				return GetAttributeValue<double?>("address3_latitude");
			}
			set
			{
				OnPropertyChanging("Address3_Latitude");
				SetAttributeValue("address3_latitude", value);
				OnPropertyChanged("Address3_Latitude");
			}
		}

		/// <summary>
		/// 세 번째 주소의 첫 번째 줄입니다.
		/// </summary>
		[AttributeLogicalName("address3_line1")]
		public string Address3_Line1
		{
			get
			{
				return GetAttributeValue<string>("address3_line1");
			}
			set
			{
				OnPropertyChanging("Address3_Line1");
				SetAttributeValue("address3_line1", value);
				OnPropertyChanged("Address3_Line1");
			}
		}

		/// <summary>
		/// 세 번째 주소의 두 번째 줄입니다.
		/// </summary>
		[AttributeLogicalName("address3_line2")]
		public string Address3_Line2
		{
			get
			{
				return GetAttributeValue<string>("address3_line2");
			}
			set
			{
				OnPropertyChanging("Address3_Line2");
				SetAttributeValue("address3_line2", value);
				OnPropertyChanged("Address3_Line2");
			}
		}

		/// <summary>
		/// 세 번째 주소의 세 번째 줄입니다.
		/// </summary>
		[AttributeLogicalName("address3_line3")]
		public string Address3_Line3
		{
			get
			{
				return GetAttributeValue<string>("address3_line3");
			}
			set
			{
				OnPropertyChanging("Address3_Line3");
				SetAttributeValue("address3_line3", value);
				OnPropertyChanged("Address3_Line3");
			}
		}

		/// <summary>
		/// 매핑 및 기타 응용 프로그램에 사용하도록 세 번째 주소의 경도 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_longitude")]
		public double? Address3_Longitude
		{
			get
			{
				return GetAttributeValue<double?>("address3_longitude");
			}
			set
			{
				OnPropertyChanging("Address3_Longitude");
				SetAttributeValue("address3_longitude", value);
				OnPropertyChanged("Address3_Longitude");
			}
		}

		/// <summary>
		/// 세 번째 주소를 설명하는 이름을 입력합니다(예: 본사).
		/// </summary>
		[AttributeLogicalName("address3_name")]
		public string Address3_Name
		{
			get
			{
				return GetAttributeValue<string>("address3_name");
			}
			set
			{
				OnPropertyChanging("Address3_Name");
				SetAttributeValue("address3_name", value);
				OnPropertyChanged("Address3_Name");
			}
		}

		/// <summary>
		/// 세 번째 주소의 우편 번호입니다.
		/// </summary>
		[AttributeLogicalName("address3_postalcode")]
		public string Address3_PostalCode
		{
			get
			{
				return GetAttributeValue<string>("address3_postalcode");
			}
			set
			{
				OnPropertyChanging("Address3_PostalCode");
				SetAttributeValue("address3_postalcode", value);
				OnPropertyChanged("Address3_PostalCode");
			}
		}

		/// <summary>
		/// 세 번째 주소의 사서함 번호입니다.
		/// </summary>
		[AttributeLogicalName("address3_postofficebox")]
		public string Address3_PostOfficeBox
		{
			get
			{
				return GetAttributeValue<string>("address3_postofficebox");
			}
			set
			{
				OnPropertyChanging("Address3_PostOfficeBox");
				SetAttributeValue("address3_postofficebox", value);
				OnPropertyChanged("Address3_PostOfficeBox");
			}
		}

		/// <summary>
		/// 거래처의 세 번째 주소에 기본 연락처 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_primarycontactname")]
		public string Address3_PrimaryContactName
		{
			get
			{
				return GetAttributeValue<string>("address3_primarycontactname");
			}
			set
			{
				OnPropertyChanging("Address3_PrimaryContactName");
				SetAttributeValue("address3_primarycontactname", value);
				OnPropertyChanged("Address3_PrimaryContactName");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("address3_shippingmethodcode")]
		public OptionSetValue Address3_ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("address3_shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("Address3_ShippingMethodCode");
				SetAttributeValue("address3_shippingmethodcode", value);
				OnPropertyChanged("Address3_ShippingMethodCode");
			}
		}

		/// <summary>
		/// 세 번째 주소의 시/도입니다.
		/// </summary>
		[AttributeLogicalName("address3_stateorprovince")]
		public string Address3_StateOrProvince
		{
			get
			{
				return GetAttributeValue<string>("address3_stateorprovince");
			}
			set
			{
				OnPropertyChanging("Address3_StateOrProvince");
				SetAttributeValue("address3_stateorprovince", value);
				OnPropertyChanged("Address3_StateOrProvince");
			}
		}

		/// <summary>
		/// 세 번째 주소에 연결된 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_telephone1")]
		public string Address3_Telephone1
		{
			get
			{
				return GetAttributeValue<string>("address3_telephone1");
			}
			set
			{
				OnPropertyChanging("Address3_Telephone1");
				SetAttributeValue("address3_telephone1", value);
				OnPropertyChanged("Address3_Telephone1");
			}
		}

		/// <summary>
		/// 세 번째 주소에 연결된 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_telephone2")]
		public string Address3_Telephone2
		{
			get
			{
				return GetAttributeValue<string>("address3_telephone2");
			}
			set
			{
				OnPropertyChanging("Address3_Telephone2");
				SetAttributeValue("address3_telephone2", value);
				OnPropertyChanged("Address3_Telephone2");
			}
		}

		/// <summary>
		/// 기본 주소에 연결된 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_telephone3")]
		public string Address3_Telephone3
		{
			get
			{
				return GetAttributeValue<string>("address3_telephone3");
			}
			set
			{
				OnPropertyChanging("Address3_Telephone3");
				SetAttributeValue("address3_telephone3", value);
				OnPropertyChanged("Address3_Telephone3");
			}
		}

		/// <summary>
		/// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 세 번째 주소의 UPS 영역을 입력합니다.
		/// </summary>
		[AttributeLogicalName("address3_upszone")]
		public string Address3_UPSZone
		{
			get
			{
				return GetAttributeValue<string>("address3_upszone");
			}
			set
			{
				OnPropertyChanging("Address3_UPSZone");
				SetAttributeValue("address3_upszone", value);
				OnPropertyChanged("Address3_UPSZone");
			}
		}

		/// <summary>
		/// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
		/// </summary>
		[AttributeLogicalName("address3_utcoffset")]
		public int? Address3_UTCOffset
		{
			get
			{
				return GetAttributeValue<int?>("address3_utcoffset");
			}
			set
			{
				OnPropertyChanging("Address3_UTCOffset");
				SetAttributeValue("address3_utcoffset", value);
				OnPropertyChanged("Address3_UTCOffset");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging30")]
		public Money Aging30
		{
			get
			{
				return GetAttributeValue<Money>("aging30");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 [30일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("aging30_base")]
		public Money Aging30_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging30_base");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging60")]
		public Money Aging60
		{
			get
			{
				return GetAttributeValue<Money>("aging60");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 [60일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("aging60_base")]
		public Money Aging60_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging60_base");
			}
		}

		/// <summary>
		/// 시스템 전용입니다.
		/// </summary>
		[AttributeLogicalName("aging90")]
		public Money Aging90
		{
			get
			{
				return GetAttributeValue<Money>("aging90");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 [90일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("aging90_base")]
		public Money Aging90_Base
		{
			get
			{
				return GetAttributeValue<Money>("aging90_base");
			}
		}

		/// <summary>
		/// 고객 선물 프로그램 또는 기타 연락용으로 연락처의 결혼식 또는 서비스 기념일을 입력합니다.
		/// </summary>
		[AttributeLogicalName("anniversary")]
		public DateTime? Anniversary
		{
			get
			{
				return GetAttributeValue<DateTime?>("anniversary");
			}
			set
			{
				OnPropertyChanging("Anniversary");
				SetAttributeValue("anniversary", value);
				OnPropertyChanged("Anniversary");
			}
		}

		/// <summary>
		/// 자료 수집 및 재무 분석용으로 연락처의 연간 수입을 입력합니다.
		/// </summary>
		[AttributeLogicalName("annualincome")]
		public Money AnnualIncome
		{
			get
			{
				return GetAttributeValue<Money>("annualincome");
			}
			set
			{
				OnPropertyChanging("AnnualIncome");
				SetAttributeValue("annualincome", value);
				OnPropertyChanged("AnnualIncome");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 [연간 수입] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("annualincome_base")]
		public Money AnnualIncome_Base
		{
			get
			{
				return GetAttributeValue<Money>("annualincome_base");
			}
		}

		/// <summary>
		/// 연락처의 비서 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("assistantname")]
		public string AssistantName
		{
			get
			{
				return GetAttributeValue<string>("assistantname");
			}
			set
			{
				OnPropertyChanging("AssistantName");
				SetAttributeValue("assistantname", value);
				OnPropertyChanged("AssistantName");
			}
		}

		/// <summary>
		/// 연락처의 비서 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("assistantphone")]
		public string AssistantPhone
		{
			get
			{
				return GetAttributeValue<string>("assistantphone");
			}
			set
			{
				OnPropertyChanging("AssistantPhone");
				SetAttributeValue("assistantphone", value);
				OnPropertyChanged("AssistantPhone");
			}
		}

		/// <summary>
		/// 고객 선물 프로그램 또는 기타 연락용으로 연락처의 생일을 입력합니다.
		/// </summary>
		[AttributeLogicalName("birthdate")]
		public DateTime? BirthDate
		{
			get
			{
				return GetAttributeValue<DateTime?>("birthdate");
			}
			set
			{
				OnPropertyChanging("BirthDate");
				SetAttributeValue("birthdate", value);
				OnPropertyChanged("BirthDate");
			}
		}

		/// <summary>
		/// 이 연락처의 두 번째 근무처 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("business2")]
		public string Business2
		{
			get
			{
				return GetAttributeValue<string>("business2");
			}
			set
			{
				OnPropertyChanging("Business2");
				SetAttributeValue("business2", value);
				OnPropertyChanged("Business2");
			}
		}

		/// <summary>
		/// 이 연락처의 콜백 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("callback")]
		public string Callback
		{
			get
			{
				return GetAttributeValue<string>("callback");
			}
			set
			{
				OnPropertyChanging("Callback");
				SetAttributeValue("callback", value);
				OnPropertyChanged("Callback");
			}
		}

		/// <summary>
		/// 연락 및 클라이언트 프로그램 참조용으로 연락처의 자녀 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("childrensnames")]
		public string ChildrensNames
		{
			get
			{
				return GetAttributeValue<string>("childrensnames");
			}
			set
			{
				OnPropertyChanging("ChildrensNames");
				SetAttributeValue("childrensnames", value);
				OnPropertyChanged("ChildrensNames");
			}
		}

		/// <summary>
		/// 연락처의 회사 전화를 입력합니다.
		/// </summary>
		[AttributeLogicalName("company")]
		public string Company
		{
			get
			{
				return GetAttributeValue<string>("company");
			}
			set
			{
				OnPropertyChanging("Company");
				SetAttributeValue("company", value);
				OnPropertyChanged("Company");
			}
		}

		/// <summary>
		/// 연락처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("contactid")]
		public Guid? ContactId
		{
			get
			{
				return GetAttributeValue<Guid?>("contactid");
			}
			set
			{
				OnPropertyChanging("ContactId");
				SetAttributeValue("contactid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = Guid.Empty;
				}
				OnPropertyChanged("ContactId");
			}
		}

		[AttributeLogicalName("contactid")]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				ContactId = value;
			}
		}

		/// <summary>
		/// 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdby")]
		public EntityReference CreatedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdby");
			}
		}

		/// <summary>
		/// 레코드를 만든 외부 대상을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdbyexternalparty")]
		public EntityReference CreatedByExternalParty
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdbyexternalparty");
			}
		}

		/// <summary>
		/// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("createdon")]
		public DateTime? CreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("createdon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdonbehalfby")]
		public EntityReference CreatedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdonbehalfby");
			}
		}

		/// <summary>
		/// 송장 및 회계 문제를 고객에게 보낼 때 참조용으로 연락처의 신용 한도액을 입력합니다.
		/// </summary>
		[AttributeLogicalName("creditlimit")]
		public Money CreditLimit
		{
			get
			{
				return GetAttributeValue<Money>("creditlimit");
			}
			set
			{
				OnPropertyChanging("CreditLimit");
				SetAttributeValue("creditlimit", value);
				OnPropertyChanged("CreditLimit");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [신용 한도액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("creditlimit_base")]
		public Money CreditLimit_Base
		{
			get
			{
				return GetAttributeValue<Money>("creditlimit_base");
			}
		}

		/// <summary>
		/// 송장 및 회계 문제를 보낼 때 참조용으로 연락처가 신용 보류 상태인지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("creditonhold")]
		public bool? CreditOnHold
		{
			get
			{
				return GetAttributeValue<bool?>("creditonhold");
			}
			set
			{
				OnPropertyChanging("CreditOnHold");
				SetAttributeValue("creditonhold", value);
				OnPropertyChanged("CreditOnHold");
			}
		}

		/// <summary>
		/// 세분화 및 보고용으로 연락처 회사의 크기를 선택합니다.
		/// </summary>
		[AttributeLogicalName("customersizecode")]
		public OptionSetValue CustomerSizeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("customersizecode");
			}
			set
			{
				OnPropertyChanging("CustomerSizeCode");
				SetAttributeValue("customersizecode", value);
				OnPropertyChanged("CustomerSizeCode");
			}
		}

		/// <summary>
		/// 연락처 및 조직 간의 관계를 가장 잘 설명하는 범주를 선택합니다.
		/// </summary>
		[AttributeLogicalName("customertypecode")]
		public OptionSetValue CustomerTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("customertypecode");
			}
			set
			{
				OnPropertyChanging("CustomerTypeCode");
				SetAttributeValue("customertypecode", value);
				OnPropertyChanged("CustomerTypeCode");
			}
		}

		/// <summary>
		/// 해당 고객에 대해 올바른 제품 가격이 영업 기회, 견적 및 주문에 적용되도록 연락처와 연관된 기본 가격표를 선택합니다.
		/// </summary>
		[AttributeLogicalName("defaultpricelevelid")]
		public EntityReference DefaultPriceLevelId
		{
			get
			{
				return GetAttributeValue<EntityReference>("defaultpricelevelid");
			}
			set
			{
				OnPropertyChanging("DefaultPriceLevelId");
				SetAttributeValue("defaultpricelevelid", value);
				OnPropertyChanged("DefaultPriceLevelId");
			}
		}

		/// <summary>
		/// 연락처가 상위 회사 또는 사업에서 일하는 부서 또는 사업부를 입력합니다.
		/// </summary>
		[AttributeLogicalName("department")]
		public string Department
		{
			get
			{
				return GetAttributeValue<string>("department");
			}
			set
			{
				OnPropertyChanging("Department");
				SetAttributeValue("department", value);
				OnPropertyChanged("Department");
			}
		}

		/// <summary>
		/// 연락처를 설명하는 추가 정보를 입력합니다(예: 회사 웹 사이트에서의 발췌).
		/// </summary>
		[AttributeLogicalName("description")]
		public string Description
		{
			get
			{
				return GetAttributeValue<string>("description");
			}
			set
			{
				OnPropertyChanging("Description");
				SetAttributeValue("description", value);
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 전자 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 목록에는 추가될 수 있지만 전자 메일에서는 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotbulkemail")]
		public bool? DoNotBulkEMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotbulkemail");
			}
			set
			{
				OnPropertyChanging("DoNotBulkEMail");
				SetAttributeValue("donotbulkemail", value);
				OnPropertyChanged("DoNotBulkEMail");
			}
		}

		/// <summary>
		/// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 우편 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 목록에는 추가될 수 있지만 편지에서는 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotbulkpostalmail")]
		public bool? DoNotBulkPostalMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotbulkpostalmail");
			}
			set
			{
				OnPropertyChanging("DoNotBulkPostalMail");
				SetAttributeValue("donotbulkpostalmail", value);
				OnPropertyChanged("DoNotBulkPostalMail");
			}
		}

		/// <summary>
		/// Microsoft Dynamics 365에서 보내는 다이렉트 전자 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 Microsoft Dynamics 365에서 전자 메일을 보내지 않습니다.
		/// </summary>
		[AttributeLogicalName("donotemail")]
		public bool? DoNotEMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotemail");
			}
			set
			{
				OnPropertyChanging("DoNotEMail");
				SetAttributeValue("donotemail", value);
				OnPropertyChanged("DoNotEMail");
			}
		}

		/// <summary>
		/// 연락처에서 팩스를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 모든 팩스 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotfax")]
		public bool? DoNotFax
		{
			get
			{
				return GetAttributeValue<bool?>("donotfax");
			}
			set
			{
				OnPropertyChanging("DoNotFax");
				SetAttributeValue("donotfax", value);
				OnPropertyChanged("DoNotFax");
			}
		}

		/// <summary>
		/// 연락처에서 전화 통화를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 모든 전화 통화 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotphone")]
		public bool? DoNotPhone
		{
			get
			{
				return GetAttributeValue<bool?>("donotphone");
			}
			set
			{
				OnPropertyChanging("DoNotPhone");
				SetAttributeValue("donotphone", value);
				OnPropertyChanged("DoNotPhone");
			}
		}

		/// <summary>
		/// 연락처에서 다이렉트 메일을 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 편지 활동에서 제외됩니다.
		/// </summary>
		[AttributeLogicalName("donotpostalmail")]
		public bool? DoNotPostalMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotpostalmail");
			}
			set
			{
				OnPropertyChanging("DoNotPostalMail");
				SetAttributeValue("donotpostalmail", value);
				OnPropertyChanged("DoNotPostalMail");
			}
		}

		/// <summary>
		/// 연락처에서 마케팅 자료(예: 브로슈어 또는 카탈로그)를 허용할지 여부를 선택합니다. 마케팅 이니셔티브에서 옵트아웃이 제외될 수 있는 연락처입니다.
		/// </summary>
		[AttributeLogicalName("donotsendmm")]
		public bool? DoNotSendMM
		{
			get
			{
				return GetAttributeValue<bool?>("donotsendmm");
			}
			set
			{
				OnPropertyChanging("DoNotSendMM");
				SetAttributeValue("donotsendmm", value);
				OnPropertyChanged("DoNotSendMM");
			}
		}

		/// <summary>
		/// 마케팅 세분화 및 분석에 사용할 연락처의 최고 교육 수준을 선택합니다.
		/// </summary>
		[AttributeLogicalName("educationcode")]
		public OptionSetValue EducationCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("educationcode");
			}
			set
			{
				OnPropertyChanging("EducationCode");
				SetAttributeValue("educationcode", value);
				OnPropertyChanged("EducationCode");
			}
		}

		/// <summary>
		/// 연락처의 기본 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress1")]
		public string EMailAddress1
		{
			get
			{
				return GetAttributeValue<string>("emailaddress1");
			}
			set
			{
				OnPropertyChanging("EMailAddress1");
				SetAttributeValue("emailaddress1", value);
				OnPropertyChanged("EMailAddress1");
			}
		}

		/// <summary>
		/// 연락처의 보조 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress2")]
		public string EMailAddress2
		{
			get
			{
				return GetAttributeValue<string>("emailaddress2");
			}
			set
			{
				OnPropertyChanging("EMailAddress2");
				SetAttributeValue("emailaddress2", value);
				OnPropertyChanged("EMailAddress2");
			}
		}

		/// <summary>
		/// 연락처의 대체 전자 메일 주소를 입력합니다.
		/// </summary>
		[AttributeLogicalName("emailaddress3")]
		public string EMailAddress3
		{
			get
			{
				return GetAttributeValue<string>("emailaddress3");
			}
			set
			{
				OnPropertyChanging("EMailAddress3");
				SetAttributeValue("emailaddress3", value);
				OnPropertyChanged("EMailAddress3");
			}
		}

		/// <summary>
		/// 주문, 서비스 케이스 또는 기타 연락처 조직과의 연락 참조용으로 직원 ID 또는 연락처 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("employeeid")]
		public string EmployeeId
		{
			get
			{
				return GetAttributeValue<string>("employeeid");
			}
			set
			{
				OnPropertyChanging("EmployeeId");
				SetAttributeValue("employeeid", value);
				OnPropertyChanged("EmployeeId");
			}
		}

		/// <summary>
		/// 레코드의 기본 이미지를 표시합니다.
		/// </summary>
		[AttributeLogicalName("entityimage")]
		public byte[] EntityImage
		{
			get
			{
				return GetAttributeValue<byte[]>("entityimage");
			}
			set
			{
				OnPropertyChanging("EntityImage");
				SetAttributeValue("entityimage", value);
				OnPropertyChanged("EntityImage");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("entityimage_timestamp")]
		public long? EntityImage_Timestamp
		{
			get
			{
				return GetAttributeValue<long?>("entityimage_timestamp");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("entityimage_url")]
		public string EntityImage_URL
		{
			get
			{
				return GetAttributeValue<string>("entityimage_url");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("entityimageid")]
		public Guid? EntityImageId
		{
			get
			{
				return GetAttributeValue<Guid?>("entityimageid");
			}
		}

		/// <summary>
		/// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("exchangerate")]
		public decimal? ExchangeRate
		{
			get
			{
				return GetAttributeValue<decimal?>("exchangerate");
			}
		}

		/// <summary>
		/// 외부 사용자의 식별자입니다.
		/// </summary>
		[AttributeLogicalName("externaluseridentifier")]
		public string ExternalUserIdentifier
		{
			get
			{
				return GetAttributeValue<string>("externaluseridentifier");
			}
			set
			{
				OnPropertyChanging("ExternalUserIdentifier");
				SetAttributeValue("externaluseridentifier", value);
				OnPropertyChanged("ExternalUserIdentifier");
			}
		}

		/// <summary>
		/// 후속 전화 통화 및 기타 연락 참조용으로 연락처의 결혼 상태를 선택합니다.
		/// </summary>
		[AttributeLogicalName("familystatuscode")]
		public OptionSetValue FamilyStatusCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("familystatuscode");
			}
			set
			{
				OnPropertyChanging("FamilyStatusCode");
				SetAttributeValue("familystatuscode", value);
				OnPropertyChanged("FamilyStatusCode");
			}
		}

		/// <summary>
		/// 연락처의 팩스 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("fax")]
		public string Fax
		{
			get
			{
				return GetAttributeValue<string>("fax");
			}
			set
			{
				OnPropertyChanging("Fax");
				SetAttributeValue("fax", value);
				OnPropertyChanged("Fax");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("firstname")]
		public string FirstName
		{
			get
			{
				return GetAttributeValue<string>("firstname");
			}
			set
			{
				OnPropertyChanging("FirstName");
				SetAttributeValue("firstname", value);
				OnPropertyChanged("FirstName");
			}
		}

		/// <summary>
		/// 연락처에 전송된 전자 메일에 대한 개봉, 첨부 파일 보기, 링크 클릭과 같은 전자 메일 활동을 팔로우하도록 허용할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("followemail")]
		public bool? FollowEmail
		{
			get
			{
				return GetAttributeValue<bool?>("followemail");
			}
			set
			{
				OnPropertyChanging("FollowEmail");
				SetAttributeValue("followemail", value);
				OnPropertyChanged("FollowEmail");
			}
		}

		/// <summary>
		/// 사용자가 데이터에 액세스하고 문서를 공유할 수 있도록 연락처의 FTP 사이트에 대한 URL을 입력합니다.
		/// </summary>
		[AttributeLogicalName("ftpsiteurl")]
		public string FtpSiteUrl
		{
			get
			{
				return GetAttributeValue<string>("ftpsiteurl");
			}
			set
			{
				OnPropertyChanging("FtpSiteUrl");
				SetAttributeValue("ftpsiteurl", value);
				OnPropertyChanged("FtpSiteUrl");
			}
		}

		/// <summary>
		/// 보기 및 보고서에 전체 이름을 표시할 수 있도록 연락처의 이름과 성을 결합하여 표시합니다.
		/// </summary>
		[AttributeLogicalName("fullname")]
		public string FullName
		{
			get
			{
				return GetAttributeValue<string>("fullname");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 성별을 선택합니다.
		/// </summary>
		[AttributeLogicalName("gendercode")]
		public OptionSetValue GenderCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("gendercode");
			}
			set
			{
				OnPropertyChanging("GenderCode");
				SetAttributeValue("gendercode", value);
				OnPropertyChanged("GenderCode");
			}
		}

		/// <summary>
		/// 문서 및 보고서용으로 연락처의 여권 번호 또는 주민 등록 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("governmentid")]
		public string GovernmentId
		{
			get
			{
				return GetAttributeValue<string>("governmentid");
			}
			set
			{
				OnPropertyChanging("GovernmentId");
				SetAttributeValue("governmentid", value);
				OnPropertyChanged("GovernmentId");
			}
		}

		/// <summary>
		/// 후속 전화 통화 및 기타 연락 참조용으로 연락처에게 자녀가 있는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("haschildrencode")]
		public OptionSetValue HasChildrenCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("haschildrencode");
			}
			set
			{
				OnPropertyChanging("HasChildrenCode");
				SetAttributeValue("haschildrencode", value);
				OnPropertyChanged("HasChildrenCode");
			}
		}

		/// <summary>
		/// 이 연락처의 두 번째 집 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("home2")]
		public string Home2
		{
			get
			{
				return GetAttributeValue<string>("home2");
			}
			set
			{
				OnPropertyChanging("Home2");
				SetAttributeValue("home2", value);
				OnPropertyChanged("Home2");
			}
		}

		/// <summary>
		/// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("importsequencenumber")]
		public int? ImportSequenceNumber
		{
			get
			{
				return GetAttributeValue<int?>("importsequencenumber");
			}
			set
			{
				OnPropertyChanging("ImportSequenceNumber");
				SetAttributeValue("importsequencenumber", value);
				OnPropertyChanged("ImportSequenceNumber");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_facebook")]
		public string int_Facebook
		{
			get
			{
				return GetAttributeValue<string>("int_facebook");
			}
			set
			{
				OnPropertyChanging("int_Facebook");
				SetAttributeValue("int_facebook", value);
				OnPropertyChanged("int_Facebook");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_facebookservice")]
		public string int_FacebookService
		{
			get
			{
				return GetAttributeValue<string>("int_facebookservice");
			}
			set
			{
				OnPropertyChanging("int_FacebookService");
				SetAttributeValue("int_facebookservice", value);
				OnPropertyChanged("int_FacebookService");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_kloutscore")]
		public int? int_KloutScore
		{
			get
			{
				return GetAttributeValue<int?>("int_kloutscore");
			}
			set
			{
				OnPropertyChanging("int_KloutScore");
				SetAttributeValue("int_kloutscore", value);
				OnPropertyChanged("int_KloutScore");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_kloutscoreservice")]
		public int? int_KloutScoreService
		{
			get
			{
				return GetAttributeValue<int?>("int_kloutscoreservice");
			}
			set
			{
				OnPropertyChanging("int_KloutScoreService");
				SetAttributeValue("int_kloutscoreservice", value);
				OnPropertyChanged("int_KloutScoreService");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_twitter")]
		public string int_Twitter
		{
			get
			{
				return GetAttributeValue<string>("int_twitter");
			}
			set
			{
				OnPropertyChanging("int_Twitter");
				SetAttributeValue("int_twitter", value);
				OnPropertyChanged("int_Twitter");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("int_twitterservice")]
		public string int_TwitterService
		{
			get
			{
				return GetAttributeValue<string>("int_twitterservice");
			}
			set
			{
				OnPropertyChanging("int_TwitterService");
				SetAttributeValue("int_twitterservice", value);
				OnPropertyChanged("int_TwitterService");
			}
		}

		/// <summary>
		/// 통합 프로세스용으로 연락처가 별도의 회계 또는 기타 시스템에 있는지 여부를 선택합니다(예: Microsoft Dynamics GP 또는 기타 ERP 데이터베이스).
		/// </summary>
		[AttributeLogicalName("isbackofficecustomer")]
		public bool? IsBackofficeCustomer
		{
			get
			{
				return GetAttributeValue<bool?>("isbackofficecustomer");
			}
			set
			{
				OnPropertyChanging("IsBackofficeCustomer");
				SetAttributeValue("isbackofficecustomer", value);
				OnPropertyChanged("IsBackofficeCustomer");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 직함을 입력합니다.
		/// </summary>
		[AttributeLogicalName("jobtitle")]
		public string JobTitle
		{
			get
			{
				return GetAttributeValue<string>("jobtitle");
			}
			set
			{
				OnPropertyChanging("JobTitle");
				SetAttributeValue("jobtitle", value);
				OnPropertyChanged("JobTitle");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 성을 입력합니다.
		/// </summary>
		[AttributeLogicalName("lastname")]
		public string LastName
		{
			get
			{
				return GetAttributeValue<string>("lastname");
			}
			set
			{
				OnPropertyChanging("LastName");
				SetAttributeValue("lastname", value);
				OnPropertyChanged("LastName");
			}
		}

		/// <summary>
		/// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
		/// </summary>
		[AttributeLogicalName("lastonholdtime")]
		public DateTime? LastOnHoldTime
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastonholdtime");
			}
			set
			{
				OnPropertyChanging("LastOnHoldTime");
				SetAttributeValue("lastonholdtime", value);
				OnPropertyChanged("LastOnHoldTime");
			}
		}

		/// <summary>
		/// 연락처가 마지막으로 마케팅 캠페인 및 퀵 캠페인에 포함된 날짜를 표시합니다.
		/// </summary>
		[AttributeLogicalName("lastusedincampaign")]
		public DateTime? LastUsedInCampaign
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastusedincampaign");
			}
			set
			{
				OnPropertyChanging("LastUsedInCampaign");
				SetAttributeValue("lastusedincampaign", value);
				OnPropertyChanged("LastUsedInCampaign");
			}
		}

		/// <summary>
		/// 사용자 조직에 연락처를 알려 준 기본 마케팅 자료를 선택합니다.
		/// </summary>
		[AttributeLogicalName("leadsourcecode")]
		public OptionSetValue LeadSourceCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("leadsourcecode");
			}
			set
			{
				OnPropertyChanging("LeadSourceCode");
				SetAttributeValue("leadsourcecode", value);
				OnPropertyChanged("LeadSourceCode");
			}
		}

		/// <summary>
		/// 늘어나는 문제 또는 연락처와의 기타 후속 연락용으로 연락처의 관리자 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("managername")]
		public string ManagerName
		{
			get
			{
				return GetAttributeValue<string>("managername");
			}
			set
			{
				OnPropertyChanging("ManagerName");
				SetAttributeValue("managername", value);
				OnPropertyChanged("ManagerName");
			}
		}

		/// <summary>
		/// 연락처의 관리자 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("managerphone")]
		public string ManagerPhone
		{
			get
			{
				return GetAttributeValue<string>("managerphone");
			}
			set
			{
				OnPropertyChanging("ManagerPhone");
				SetAttributeValue("managerphone", value);
				OnPropertyChanged("ManagerPhone");
			}
		}

		/// <summary>
		/// 마케팅 전용인지 여부
		/// </summary>
		[AttributeLogicalName("marketingonly")]
		public bool? MarketingOnly
		{
			get
			{
				return GetAttributeValue<bool?>("marketingonly");
			}
			set
			{
				OnPropertyChanging("MarketingOnly");
				SetAttributeValue("marketingonly", value);
				OnPropertyChanged("MarketingOnly");
			}
		}

		/// <summary>
		/// 병합할 마스터 연락처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("masterid")]
		public EntityReference MasterId
		{
			get
			{
				return GetAttributeValue<EntityReference>("masterid");
			}
		}

		/// <summary>
		/// 거래처가 마스터 연락처와 병합되었는지 여부를 표시합니다.
		/// </summary>
		[AttributeLogicalName("merged")]
		public bool? Merged
		{
			get
			{
				return GetAttributeValue<bool?>("merged");
			}
		}

		/// <summary>
		/// 연락처가 제대로 처리되도록 연락처의 중간 이름 또는 이니셜을 입력합니다.
		/// </summary>
		[AttributeLogicalName("middlename")]
		public string MiddleName
		{
			get
			{
				return GetAttributeValue<string>("middlename");
			}
			set
			{
				OnPropertyChanging("MiddleName");
				SetAttributeValue("middlename", value);
				OnPropertyChanged("MiddleName");
			}
		}

		/// <summary>
		/// 연락처의 휴대폰 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("mobilephone")]
		public string MobilePhone
		{
			get
			{
				return GetAttributeValue<string>("mobilephone");
			}
			set
			{
				OnPropertyChanging("MobilePhone");
				SetAttributeValue("mobilephone", value);
				OnPropertyChanged("MobilePhone");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedby")]
		public EntityReference ModifiedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedby");
			}
		}

		/// <summary>
		/// 레코드를 수정한 외부 대상을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedbyexternalparty")]
		public EntityReference ModifiedByExternalParty
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedbyexternalparty");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("modifiedon")]
		public DateTime? ModifiedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("modifiedon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedonbehalfby")]
		public EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedonbehalfby");
			}
		}

		/// <summary>
		/// 연락처의 애칭을 입력합니다.
		/// </summary>
		[AttributeLogicalName("nickname")]
		public string NickName
		{
			get
			{
				return GetAttributeValue<string>("nickname");
			}
			set
			{
				OnPropertyChanging("NickName");
				SetAttributeValue("nickname", value);
				OnPropertyChanged("NickName");
			}
		}

		/// <summary>
		/// 후속 전화 통화 및 기타 연락 참조용으로 연락처의 자녀 수를 입력합니다.
		/// </summary>
		[AttributeLogicalName("numberofchildren")]
		public int? NumberOfChildren
		{
			get
			{
				return GetAttributeValue<int?>("numberofchildren");
			}
			set
			{
				OnPropertyChanging("NumberOfChildren");
				SetAttributeValue("numberofchildren", value);
				OnPropertyChanged("NumberOfChildren");
			}
		}

		/// <summary>
		/// 레코드가 보류 중인 시간을 분으로 표시합니다.
		/// </summary>
		[AttributeLogicalName("onholdtime")]
		public int? OnHoldTime
		{
			get
			{
				return GetAttributeValue<int?>("onholdtime");
			}
		}

		/// <summary>
		/// 연락처가 Microsoft Dynamics 365의 잠재 고객을 변환하여 만들어진 경우 연락처가 만들어진 잠재 고객을 표시합니다. 이 값은 보고 및 분석용으로 연락처와 원래 잠재 고객의 데이터를 연결하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("originatingleadid")]
		public EntityReference OriginatingLeadId
		{
			get
			{
				return GetAttributeValue<EntityReference>("originatingleadid");
			}
			set
			{
				OnPropertyChanging("OriginatingLeadId");
				SetAttributeValue("originatingleadid", value);
				OnPropertyChanged("OriginatingLeadId");
			}
		}

		/// <summary>
		/// 레코드를 마이그레이션한 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("overriddencreatedon")]
		public DateTime? OverriddenCreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("overriddencreatedon");
			}
			set
			{
				OnPropertyChanging("OverriddenCreatedOn");
				SetAttributeValue("overriddencreatedon", value);
				OnPropertyChanged("OverriddenCreatedOn");
			}
		}

		/// <summary>
		/// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
		/// </summary>
		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("ownerid");
			}
			set
			{
				OnPropertyChanging("OwnerId");
				SetAttributeValue("ownerid", value);
				OnPropertyChanged("OwnerId");
			}
		}

		/// <summary>
		/// 연락처를 담당하는 사업부의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningbusinessunit")]
		public EntityReference OwningBusinessUnit
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningbusinessunit");
			}
		}

		/// <summary>
		/// 연락처를 담당하는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningteam")]
		public EntityReference OwningTeam
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningteam");
			}
		}

		/// <summary>
		/// 연락처를 담당하는 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owninguser")]
		public EntityReference OwningUser
		{
			get
			{
				return GetAttributeValue<EntityReference>("owninguser");
			}
		}

		/// <summary>
		/// 연락처의 호출기 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("pager")]
		public string Pager
		{
			get
			{
				return GetAttributeValue<string>("pager");
			}
			set
			{
				OnPropertyChanging("Pager");
				SetAttributeValue("pager", value);
				OnPropertyChanged("Pager");
			}
		}

		/// <summary>
		/// 상위 연락처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("parentcontactid")]
		public EntityReference ParentContactId
		{
			get
			{
				return GetAttributeValue<EntityReference>("parentcontactid");
			}
		}

		/// <summary>
		/// 재무 정보, 활동, 영업 기회와 같은 추가 정보에 대한 퀵 링크를 제공하는 거래처의 상위 거래처 또는 상위 연락처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("parentcustomerid")]
		public EntityReference ParentCustomerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("parentcustomerid");
			}
			set
			{
				OnPropertyChanging("ParentCustomerId");
				SetAttributeValue("parentcustomerid", value);
				OnPropertyChanged("ParentCustomerId");
			}
		}

		/// <summary>
		/// 연락처가 워크플로 규칙에 관여하는지 여부를 표시합니다.
		/// </summary>
		[AttributeLogicalName("participatesinworkflow")]
		public bool? ParticipatesInWorkflow
		{
			get
			{
				return GetAttributeValue<bool?>("participatesinworkflow");
			}
			set
			{
				OnPropertyChanging("ParticipatesInWorkflow");
				SetAttributeValue("participatesinworkflow", value);
				OnPropertyChanged("ParticipatesInWorkflow");
			}
		}

		/// <summary>
		/// 고객이 총 금액을 지불해야 할 때 표시할 지불 조건을 선택합니다.
		/// </summary>
		[AttributeLogicalName("paymenttermscode")]
		public OptionSetValue PaymentTermsCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("paymenttermscode");
			}
			set
			{
				OnPropertyChanging("PaymentTermsCode");
				SetAttributeValue("paymenttermscode", value);
				OnPropertyChanged("PaymentTermsCode");
			}
		}

		/// <summary>
		/// 서비스 약속에 대해 선호하는 요일을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredappointmentdaycode")]
		public OptionSetValue PreferredAppointmentDayCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredappointmentdaycode");
			}
			set
			{
				OnPropertyChanging("PreferredAppointmentDayCode");
				SetAttributeValue("preferredappointmentdaycode", value);
				OnPropertyChanged("PreferredAppointmentDayCode");
			}
		}

		/// <summary>
		/// 서비스 약속에 대해 선호하는 하루 중 시간을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredappointmenttimecode")]
		public OptionSetValue PreferredAppointmentTimeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredappointmenttimecode");
			}
			set
			{
				OnPropertyChanging("PreferredAppointmentTimeCode");
				SetAttributeValue("preferredappointmenttimecode", value);
				OnPropertyChanged("PreferredAppointmentTimeCode");
			}
		}

		/// <summary>
		/// 선호하는 연락 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredcontactmethodcode")]
		public OptionSetValue PreferredContactMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("preferredcontactmethodcode");
			}
			set
			{
				OnPropertyChanging("PreferredContactMethodCode");
				SetAttributeValue("preferredcontactmethodcode", value);
				OnPropertyChanged("PreferredContactMethodCode");
			}
		}

		/// <summary>
		/// 고객에 대한 서비스가 제대로 예약되도록 연락처의 선호 서비스 시설 또는 장비를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredequipmentid")]
		public EntityReference PreferredEquipmentId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredequipmentid");
			}
			set
			{
				OnPropertyChanging("PreferredEquipmentId");
				SetAttributeValue("preferredequipmentid", value);
				OnPropertyChanged("PreferredEquipmentId");
			}
		}

		/// <summary>
		/// 고객에 대한 서비스가 제대로 예약되도록 연락처의 선호 서비스를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredserviceid")]
		public EntityReference PreferredServiceId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredserviceid");
			}
			set
			{
				OnPropertyChanging("PreferredServiceId");
				SetAttributeValue("preferredserviceid", value);
				OnPropertyChanged("PreferredServiceId");
			}
		}

		/// <summary>
		/// 연락처에 대한 서비스 활동을 예약할 때 참조할 정규 또는 선호 고객 지원 담당자를 선택합니다.
		/// </summary>
		[AttributeLogicalName("preferredsystemuserid")]
		public EntityReference PreferredSystemUserId
		{
			get
			{
				return GetAttributeValue<EntityReference>("preferredsystemuserid");
			}
			set
			{
				OnPropertyChanging("PreferredSystemUserId");
				SetAttributeValue("preferredsystemuserid", value);
				OnPropertyChanged("PreferredSystemUserId");
			}
		}

		/// <summary>
		/// 프로세스의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("processid")]
		public Guid? ProcessId
		{
			get
			{
				return GetAttributeValue<Guid?>("processid");
			}
			set
			{
				OnPropertyChanging("ProcessId");
				SetAttributeValue("processid", value);
				OnPropertyChanged("ProcessId");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 메시지 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 인사말을 입력합니다.
		/// </summary>
		[AttributeLogicalName("salutation")]
		public string Salutation
		{
			get
			{
				return GetAttributeValue<string>("salutation");
			}
			set
			{
				OnPropertyChanging("Salutation");
				SetAttributeValue("salutation", value);
				OnPropertyChanged("Salutation");
			}
		}

		/// <summary>
		/// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
		/// </summary>
		[AttributeLogicalName("shippingmethodcode")]
		public OptionSetValue ShippingMethodCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("shippingmethodcode");
			}
			set
			{
				OnPropertyChanging("ShippingMethodCode");
				SetAttributeValue("shippingmethodcode", value);
				OnPropertyChanged("ShippingMethodCode");
			}
		}

		/// <summary>
		/// 연락처 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
		/// </summary>
		[AttributeLogicalName("slaid")]
		public EntityReference SLAId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slaid");
			}
			set
			{
				OnPropertyChanging("SLAId");
				SetAttributeValue("slaid", value);
				OnPropertyChanged("SLAId");
			}
		}

		/// <summary>
		/// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("slainvokedid")]
		public EntityReference SLAInvokedId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slainvokedid");
			}
		}

		/// <summary>
		/// 통화, 이벤트 또는 기타 연락처와의 연락 시 참조용으로 연락처의 배우자 또는 파트너 이름을 입력합니다.
		/// </summary>
		[AttributeLogicalName("spousesname")]
		public string SpousesName
		{
			get
			{
				return GetAttributeValue<string>("spousesname");
			}
			set
			{
				OnPropertyChanging("SpousesName");
				SetAttributeValue("spousesname", value);
				OnPropertyChanged("SpousesName");
			}
		}

		/// <summary>
		/// 스테이지의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("stageid")]
		public Guid? StageId
		{
			get
			{
				return GetAttributeValue<Guid?>("stageid");
			}
			set
			{
				OnPropertyChanging("StageId");
				SetAttributeValue("stageid", value);
				OnPropertyChanged("StageId");
			}
		}

		/// <summary>
		/// 연락처가 활성인지, 아니면 비활성인지를 표시합니다. 비활성 연락처는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
		/// </summary>
		[AttributeLogicalName("statecode")]
		public ContactState? StateCode
		{
			get
			{
				OptionSetValue optionSet = GetAttributeValue<OptionSetValue>("statecode");
				if (optionSet != null)
				{
					return (ContactState)Enum.ToObject(typeof(ContactState), optionSet.Value);
				}
				else
				{
					return null;
				}
			}
			set
			{
				OnPropertyChanging("StateCode");
				if (value == null)
				{
					SetAttributeValue("statecode", null);
				}
				else
				{
					SetAttributeValue("statecode", new OptionSetValue((int)value));
				}
				OnPropertyChanged("StateCode");
			}
		}

		/// <summary>
		/// 연락처의 상태를 선택합니다.
		/// </summary>
		[AttributeLogicalName("statuscode")]
		public OptionSetValue StatusCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("statuscode");
			}
			set
			{
				OnPropertyChanging("StatusCode");
				SetAttributeValue("statuscode", value);
				OnPropertyChanged("StatusCode");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("subscriptionid")]
		public Guid? SubscriptionId
		{
			get
			{
				return GetAttributeValue<Guid?>("subscriptionid");
			}
			set
			{
				OnPropertyChanging("SubscriptionId");
				SetAttributeValue("subscriptionid", value);
				OnPropertyChanged("SubscriptionId");
			}
		}

		/// <summary>
		/// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 이름에 사용되는 호칭(예: 박사, 양, 군, 씨, 님, 교수)을 입력합니다.
		/// </summary>
		[AttributeLogicalName("suffix")]
		public string Suffix
		{
			get
			{
				return GetAttributeValue<string>("suffix");
			}
			set
			{
				OnPropertyChanging("Suffix");
				SetAttributeValue("suffix", value);
				OnPropertyChanged("Suffix");
			}
		}

		/// <summary>
		/// 이 연락처의 기본 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone1")]
		public string Telephone1
		{
			get
			{
				return GetAttributeValue<string>("telephone1");
			}
			set
			{
				OnPropertyChanging("Telephone1");
				SetAttributeValue("telephone1", value);
				OnPropertyChanged("Telephone1");
			}
		}

		/// <summary>
		/// 이 연락처의 두 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone2")]
		public string Telephone2
		{
			get
			{
				return GetAttributeValue<string>("telephone2");
			}
			set
			{
				OnPropertyChanging("Telephone2");
				SetAttributeValue("telephone2", value);
				OnPropertyChanged("Telephone2");
			}
		}

		/// <summary>
		/// 이 연락처의 세 번째 전화 번호를 입력합니다.
		/// </summary>
		[AttributeLogicalName("telephone3")]
		public string Telephone3
		{
			get
			{
				return GetAttributeValue<string>("telephone3");
			}
			set
			{
				OnPropertyChanging("Telephone3");
				SetAttributeValue("telephone3", value);
				OnPropertyChanged("Telephone3");
			}
		}

		/// <summary>
		/// 세분화 및 분석에 사용할 연락처의 지역 또는 권역을 선택합니다.
		/// </summary>
		[AttributeLogicalName("territorycode")]
		public OptionSetValue TerritoryCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("territorycode");
			}
			set
			{
				OnPropertyChanging("TerritoryCode");
				SetAttributeValue("territorycode", value);
				OnPropertyChanged("TerritoryCode");
			}
		}

		/// <summary>
		/// 연락처 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
		/// </summary>
		[AttributeLogicalName("timespentbymeonemailandmeetings")]
		public string TimeSpentByMeOnEmailAndMeetings
		{
			get
			{
				return GetAttributeValue<string>("timespentbymeonemailandmeetings");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("timezoneruleversionnumber")]
		public int? TimeZoneRuleVersionNumber
		{
			get
			{
				return GetAttributeValue<int?>("timezoneruleversionnumber");
			}
			set
			{
				OnPropertyChanging("TimeZoneRuleVersionNumber");
				SetAttributeValue("timezoneruleversionnumber", value);
				OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}

		/// <summary>
		/// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
		/// </summary>
		[AttributeLogicalName("transactioncurrencyid")]
		public EntityReference TransactionCurrencyId
		{
			get
			{
				return GetAttributeValue<EntityReference>("transactioncurrencyid");
			}
			set
			{
				OnPropertyChanging("TransactionCurrencyId");
				SetAttributeValue("transactioncurrencyid", value);
				OnPropertyChanged("TransactionCurrencyId");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("traversedpath")]
		public string TraversedPath
		{
			get
			{
				return GetAttributeValue<string>("traversedpath");
			}
			set
			{
				OnPropertyChanging("TraversedPath");
				SetAttributeValue("traversedpath", value);
				OnPropertyChanged("TraversedPath");
			}
		}

		/// <summary>
		/// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
		/// </summary>
		[AttributeLogicalName("utcconversiontimezonecode")]
		public int? UTCConversionTimeZoneCode
		{
			get
			{
				return GetAttributeValue<int?>("utcconversiontimezonecode");
			}
			set
			{
				OnPropertyChanging("UTCConversionTimeZoneCode");
				SetAttributeValue("utcconversiontimezonecode", value);
				OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}

		/// <summary>
		/// 연락처의 버전 번호입니다.
		/// </summary>
		[AttributeLogicalName("versionnumber")]
		public long? VersionNumber
		{
			get
			{
				return GetAttributeValue<long?>("versionnumber");
			}
		}

		/// <summary>
		/// 연락처의 전문 또는 개인 웹 사이트나 블로그 URL을 입력합니다.
		/// </summary>
		[AttributeLogicalName("websiteurl")]
		public string WebSiteUrl
		{
			get
			{
				return GetAttributeValue<string>("websiteurl");
			}
			set
			{
				OnPropertyChanging("WebSiteUrl");
				SetAttributeValue("websiteurl", value);
				OnPropertyChanged("WebSiteUrl");
			}
		}

		/// <summary>
		/// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 이름의 표음식 철자를 입력합니다.
		/// </summary>
		[AttributeLogicalName("yomifirstname")]
		public string YomiFirstName
		{
			get
			{
				return GetAttributeValue<string>("yomifirstname");
			}
			set
			{
				OnPropertyChanging("YomiFirstName");
				SetAttributeValue("yomifirstname", value);
				OnPropertyChanged("YomiFirstName");
			}
		}

		/// <summary>
		/// 보기 및 보고서에 전체 발음 이름을 표시할 수 있도록 연락처의 이름과 성(일본어 요미)을 결합하여 표시합니다.
		/// </summary>
		[AttributeLogicalName("yomifullname")]
		public string YomiFullName
		{
			get
			{
				return GetAttributeValue<string>("yomifullname");
			}
		}

		/// <summary>
		/// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 성의 표음식 철자를 입력합니다.
		/// </summary>
		[AttributeLogicalName("yomilastname")]
		public string YomiLastName
		{
			get
			{
				return GetAttributeValue<string>("yomilastname");
			}
			set
			{
				OnPropertyChanging("YomiLastName");
				SetAttributeValue("yomilastname", value);
				OnPropertyChanged("YomiLastName");
			}
		}

		/// <summary>
		/// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 중간 이름의 표음식 철자를 입력합니다.
		/// </summary>
		[AttributeLogicalName("yomimiddlename")]
		public string YomiMiddleName
		{
			get
			{
				return GetAttributeValue<string>("yomimiddlename");
			}
			set
			{
				OnPropertyChanging("YomiMiddleName");
				SetAttributeValue("yomimiddlename", value);
				OnPropertyChanged("YomiMiddleName");
			}
		}

		#endregion Field

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
			InitializeFromRequest initialize = new InitializeFromRequest();

			// Set the target entity (i.e.,Contact)
			initialize.TargetEntityName = "contact";

			// Create the EntityMoniker of Source (i.e.,Account)
			initialize.EntityMoniker = new EntityReference("account", accountId);

			// Execute the request
			InitializeFromResponse initialized = (InitializeFromResponse)service.Execute(initialize);

			// Read Intitialized entity (i.e.,Contact with copied attributes from Account)
			if (initialized.Entity != null)
			{
				// Get entContact from the response
				Entity entContact = initialized.Entity;

				// Set the additional attributes of the Contact
				entContact.Attributes.Add(FirstName, firstName);
				entContact.Attributes.Add(LastName, LastName);

				// Create a new contact
				return service.Create(entContact);
			}
			else return new Guid();
		}
	}

	/// <summary>
	/// 잠재적 매출 창출 이벤트, 즉 거래처에 대한 영업으로, 완료될 때까지 영업 프로세스를 통해 추적해야 합니다.
	/// </summary>
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("opportunity")]
	[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
	public partial class Opportunity : Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		#region Field

		[System.Runtime.Serialization.DataContract()]
		[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
		public enum OpportunityState
		{
			[System.Runtime.Serialization.EnumMember()]
			Open = 0,

			[System.Runtime.Serialization.EnumMember()]
			Won = 1,

			[System.Runtime.Serialization.EnumMember()]
			Lost = 2,
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public Opportunity() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "opportunity";

		public const int EntityTypeCode = 3;

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

		/// <summary>
		/// 영업 기회와 연관된 거래처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("accountid")]
		public EntityReference AccountId
		{
			get
			{
				return GetAttributeValue<EntityReference>("accountid");
			}
		}

		/// <summary>
		/// 영업 기회가 종료 또는 취소된 날짜 및 시간을 표시합니다.
		/// </summary>
		[AttributeLogicalName("actualclosedate")]
		public DateTime? ActualCloseDate
		{
			get
			{
				return GetAttributeValue<DateTime?>("actualclosedate");
			}
			set
			{
				OnPropertyChanging("ActualCloseDate");
				SetAttributeValue("actualclosedate", value);
				OnPropertyChanged("ActualCloseDate");
			}
		}

		/// <summary>
		/// 예상 및 실제 영업 보고 및 분석용으로 영업 기회의 실제 수익 금액을 입력합니다. 영업 기회가 성공하면 필드 기본값은 예상 수익 값이 됩니다.
		/// </summary>
		[AttributeLogicalName("actualvalue")]
		public Money ActualValue
		{
			get
			{
				return GetAttributeValue<Money>("actualvalue");
			}
			set
			{
				OnPropertyChanging("ActualValue");
				SetAttributeValue("actualvalue", value);
				OnPropertyChanged("ActualValue");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [실제 매출] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("actualvalue_base")]
		public Money ActualValue_Base
		{
			get
			{
				return GetAttributeValue<Money>("actualvalue_base");
			}
		}

		/// <summary>
		/// 잠재 고객의 잠재적으로 사용 가능한 예산을 나타내는 0에서 1,000,000,000,000 사이의 값을 입력합니다.
		/// </summary>
		[AttributeLogicalName("budgetamount")]
		public Money BudgetAmount
		{
			get
			{
				return GetAttributeValue<Money>("budgetamount");
			}
			set
			{
				OnPropertyChanging("BudgetAmount");
				SetAttributeValue("budgetamount", value);
				OnPropertyChanged("BudgetAmount");
			}
		}

		/// <summary>
		/// 시스템의 기본 통화로 변환된 예산 금액을 표시합니다.
		/// </summary>
		[AttributeLogicalName("budgetamount_base")]
		public Money BudgetAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("budgetamount_base");
			}
		}

		/// <summary>
		/// 잠재 고객이 속한 회사의 예산 상태와 가장 근사한 항목을 선택합니다. 잠재 고객 등급 또는 영업 방식을 결정하는 데 도움이 될 수 있습니다.
		/// </summary>
		[AttributeLogicalName("budgetstatus")]
		public OptionSetValue BudgetStatus
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("budgetstatus");
			}
			set
			{
				OnPropertyChanging("BudgetStatus");
				SetAttributeValue("budgetstatus", value);
				OnPropertyChanged("BudgetStatus");
			}
		}

		/// <summary>
		/// 영업 기회가 만들어진 캠페인을 표시합니다. ID는 캠페인의 성공을 추적하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("campaignid")]
		public EntityReference CampaignId
		{
			get
			{
				return GetAttributeValue<EntityReference>("campaignid");
			}
			set
			{
				OnPropertyChanging("CampaignId");
				SetAttributeValue("campaignid", value);
				OnPropertyChanged("CampaignId");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 제안 피드백을 받았는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("captureproposalfeedback")]
		public bool? CaptureProposalFeedback
		{
			get
			{
				return GetAttributeValue<bool?>("captureproposalfeedback");
			}
			set
			{
				OnPropertyChanging("CaptureProposalFeedback");
				SetAttributeValue("captureproposalfeedback", value);
				OnPropertyChanged("CaptureProposalFeedback");
			}
		}

		/// <summary>
		/// 영업 기회 종료 가능성을 나타내는 0에서 100 사이의 숫자를 입력합니다. 이 값은 영업 시 영업 기회를 변환하기 위한 노력으로 영업 팀을 도울 수 있습니다.
		/// </summary>
		[AttributeLogicalName("closeprobability")]
		public int? CloseProbability
		{
			get
			{
				return GetAttributeValue<int?>("closeprobability");
			}
			set
			{
				OnPropertyChanging("CloseProbability");
				SetAttributeValue("closeprobability", value);
				OnPropertyChanged("CloseProbability");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 최종 제안이 완료되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("completefinalproposal")]
		public bool? CompleteFinalProposal
		{
			get
			{
				return GetAttributeValue<bool?>("completefinalproposal");
			}
			set
			{
				OnPropertyChanging("CompleteFinalProposal");
				SetAttributeValue("completefinalproposal", value);
				OnPropertyChanged("CompleteFinalProposal");
			}
		}

		/// <summary>
		/// 이 영업 기회에 대한 내부 검토가 완료되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("completeinternalreview")]
		public bool? CompleteInternalReview
		{
			get
			{
				return GetAttributeValue<bool?>("completeinternalreview");
			}
			set
			{
				OnPropertyChanging("CompleteInternalReview");
				SetAttributeValue("completeinternalreview", value);
				OnPropertyChanged("CompleteInternalReview");
			}
		}

		/// <summary>
		/// 잠재 고객이 제공 사항에 관심이 있는 것으로 확인되었는지 여부를 선택합니다. 이 값은 잠재 고객의 관심도와 영업 기회로 전환될 가능성을 판별하는 데 도움이 됩니다.
		/// </summary>
		[AttributeLogicalName("confirminterest")]
		public bool? ConfirmInterest
		{
			get
			{
				return GetAttributeValue<bool?>("confirminterest");
			}
			set
			{
				OnPropertyChanging("ConfirmInterest");
				SetAttributeValue("confirminterest", value);
				OnPropertyChanged("ConfirmInterest");
			}
		}

		/// <summary>
		/// 영업 기회와 연관된 연락처의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("contactid")]
		public EntityReference ContactId
		{
			get
			{
				return GetAttributeValue<EntityReference>("contactid");
			}
		}

		/// <summary>
		/// 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdby")]
		public EntityReference CreatedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdby");
			}
		}

		/// <summary>
		/// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("createdon")]
		public DateTime? CreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("createdon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("createdonbehalfby")]
		public EntityReference CreatedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdonbehalfby");
			}
		}

		/// <summary>
		/// 영업 기회와 연관된 회사나 조직에 대한 메모를 입력합니다.
		/// </summary>
		[AttributeLogicalName("currentsituation")]
		public string CurrentSituation
		{
			get
			{
				return GetAttributeValue<string>("currentsituation");
			}
			set
			{
				OnPropertyChanging("CurrentSituation");
				SetAttributeValue("currentsituation", value);
				OnPropertyChanged("CurrentSituation");
			}
		}

		/// <summary>
		/// 주소, 전화 번호, 활동, 주문과 같은 추가 고객 정보에 대한 퀵 링크를 제공하는 고객 거래처 또는 연락처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("customerid")]
		public EntityReference CustomerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("customerid");
			}
			set
			{
				OnPropertyChanging("CustomerId");
				SetAttributeValue("customerid", value);
				OnPropertyChanged("CustomerId");
			}
		}

		/// <summary>
		/// 고객의 요구 사항을 충족할 수 있는 제품 및 서비스를 영업 팀에서 식별하는 데 도움이 되도록 고객의 요구 사항에 대한 메모를 입력합니다.
		/// </summary>
		[AttributeLogicalName("customerneed")]
		public string CustomerNeed
		{
			get
			{
				return GetAttributeValue<string>("customerneed");
			}
			set
			{
				OnPropertyChanging("CustomerNeed");
				SetAttributeValue("customerneed", value);
				OnPropertyChanged("CustomerNeed");
			}
		}

		/// <summary>
		/// 고객의 문제점을 다룰 수 있는 제품 및 서비스를 영업 팀에서 식별하는 데 도움이 되도록 고객의 문제점에 대한 메모를 입력합니다.
		/// </summary>
		[AttributeLogicalName("customerpainpoints")]
		public string CustomerPainPoints
		{
			get
			{
				return GetAttributeValue<string>("customerpainpoints");
			}
			set
			{
				OnPropertyChanging("CustomerPainPoints");
				SetAttributeValue("customerpainpoints", value);
				OnPropertyChanged("CustomerPainPoints");
			}
		}

		/// <summary>
		/// 메모에 잠재 고객이 속한 회사에서 구매 결정을 내린 사람에 대한 정보를 포함할지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("decisionmaker")]
		public bool? DecisionMaker
		{
			get
			{
				return GetAttributeValue<bool?>("decisionmaker");
			}
			set
			{
				OnPropertyChanging("DecisionMaker");
				SetAttributeValue("decisionmaker", value);
				OnPropertyChanged("DecisionMaker");
			}
		}

		/// <summary>
		/// 영업 기회를 설명하는 추가 정보를 입력합니다(예: 판매 가능한 제품 또는 고객의 과거 구매).
		/// </summary>
		[AttributeLogicalName("description")]
		public string Description
		{
			get
			{
				return GetAttributeValue<string>("description");
			}
			set
			{
				OnPropertyChanging("Description");
				SetAttributeValue("description", value);
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 제안이 전개되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("developproposal")]
		public bool? DevelopProposal
		{
			get
			{
				return GetAttributeValue<bool?>("developproposal");
			}
			set
			{
				OnPropertyChanging("DevelopProposal");
				SetAttributeValue("developproposal", value);
				OnPropertyChanged("DevelopProposal");
			}
		}

		/// <summary>
		/// 고객이 특별 절감액을 받을 수 있을 경우 영업 기회의 할인 금액을 입력합니다.
		/// </summary>
		[AttributeLogicalName("discountamount")]
		public Money DiscountAmount
		{
			get
			{
				return GetAttributeValue<Money>("discountamount");
			}
			set
			{
				OnPropertyChanging("DiscountAmount");
				SetAttributeValue("discountamount", value);
				OnPropertyChanged("DiscountAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [영업 기회 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("discountamount_base")]
		public Money DiscountAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("discountamount_base");
			}
		}

		/// <summary>
		/// 영업 기회의 고객에 대해 추가 절감액을 포함하도록 [제품 합계] 필드에 적용되어야 하는 할인율을 입력합니다.
		/// </summary>
		[AttributeLogicalName("discountpercentage")]
		public decimal? DiscountPercentage
		{
			get
			{
				return GetAttributeValue<decimal?>("discountpercentage");
			}
			set
			{
				OnPropertyChanging("DiscountPercentage");
				SetAttributeValue("discountpercentage", value);
				OnPropertyChanged("DiscountPercentage");
			}
		}

		/// <summary>
		/// 정확한 수익을 예상하는 데 도움이 되도록 영업 기회의 예상 종료 날짜를 입력합니다.
		/// </summary>
		[AttributeLogicalName("estimatedclosedate")]
		public DateTime? EstimatedCloseDate
		{
			get
			{
				return GetAttributeValue<DateTime?>("estimatedclosedate");
			}
			set
			{
				OnPropertyChanging("EstimatedCloseDate");
				SetAttributeValue("estimatedclosedate", value);
				OnPropertyChanged("EstimatedCloseDate");
			}
		}

		/// <summary>
		/// 수익 예상을 위해 영업 기회의 가치 또는 잠재적 영업을 나타내는 예상 수익 금액을 입력합니다. 이 필드는 시스템에서 입력되거나 [수익] 필드의 선택 사항에 따라 편집 가능합니다.
		/// </summary>
		[AttributeLogicalName("estimatedvalue")]
		public Money EstimatedValue
		{
			get
			{
				return GetAttributeValue<Money>("estimatedvalue");
			}
			set
			{
				OnPropertyChanging("EstimatedValue");
				SetAttributeValue("estimatedvalue", value);
				OnPropertyChanged("EstimatedValue");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [실제 매출] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("estimatedvalue_base")]
		public Money EstimatedValue_Base
		{
			get
			{
				return GetAttributeValue<Money>("estimatedvalue_base");
			}
		}

		/// <summary>
		/// 잠재 고객의 요구와 귀하의 제공 사항 사이의 조화가 이루어졌는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("evaluatefit")]
		public bool? EvaluateFit
		{
			get
			{
				return GetAttributeValue<bool?>("evaluatefit");
			}
			set
			{
				OnPropertyChanging("EvaluateFit");
				SetAttributeValue("evaluatefit", value);
				OnPropertyChanged("EvaluateFit");
			}
		}

		/// <summary>
		/// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
		/// </summary>
		[AttributeLogicalName("exchangerate")]
		public decimal? ExchangeRate
		{
			get
			{
				return GetAttributeValue<decimal?>("exchangerate");
			}
		}

		/// <summary>
		/// 영업 팀에서 제안 및 거래처의 응답에 대한 자세한 메모를 기록했는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("filedebrief")]
		public bool? FileDebrief
		{
			get
			{
				return GetAttributeValue<bool?>("filedebrief");
			}
			set
			{
				OnPropertyChanging("FileDebrief");
				SetAttributeValue("filedebrief", value);
				OnPropertyChanged("FileDebrief");
			}
		}

		/// <summary>
		/// 영업 기회의 최종 결정이 이루어진 날짜와 시간을 입력합니다.
		/// </summary>
		[AttributeLogicalName("finaldecisiondate")]
		public DateTime? FinalDecisionDate
		{
			get
			{
				return GetAttributeValue<DateTime?>("finaldecisiondate");
			}
			set
			{
				OnPropertyChanging("FinalDecisionDate");
				SetAttributeValue("finaldecisiondate", value);
				OnPropertyChanged("FinalDecisionDate");
			}
		}

		/// <summary>
		/// [총 금액] 필드 계산용으로 영업 기회에 포함된 제품의 화물 또는 운송 비용을 입력합니다.
		/// </summary>
		[AttributeLogicalName("freightamount")]
		public Money FreightAmount
		{
			get
			{
				return GetAttributeValue<Money>("freightamount");
			}
			set
			{
				OnPropertyChanging("FreightAmount");
				SetAttributeValue("freightamount", value);
				OnPropertyChanged("FreightAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [운송료] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("freightamount_base")]
		public Money FreightAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("freightamount_base");
			}
		}

		/// <summary>
		/// 경쟁 업체에 대한 정보가 포함되는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("identifycompetitors")]
		public bool? IdentifyCompetitors
		{
			get
			{
				return GetAttributeValue<bool?>("identifycompetitors");
			}
			set
			{
				OnPropertyChanging("IdentifyCompetitors");
				SetAttributeValue("identifycompetitors", value);
				OnPropertyChanged("IdentifyCompetitors");
			}
		}

		/// <summary>
		/// 이 영업 기회에 대한 고객 연락처가 식별되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("identifycustomercontacts")]
		public bool? IdentifyCustomerContacts
		{
			get
			{
				return GetAttributeValue<bool?>("identifycustomercontacts");
			}
			set
			{
				OnPropertyChanging("IdentifyCustomerContacts");
				SetAttributeValue("identifycustomercontacts", value);
				OnPropertyChanged("IdentifyCustomerContacts");
			}
		}

		/// <summary>
		/// 영업 기회를 추구하는 사람을 기록했는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("identifypursuitteam")]
		public bool? IdentifyPursuitTeam
		{
			get
			{
				return GetAttributeValue<bool?>("identifypursuitteam");
			}
			set
			{
				OnPropertyChanging("IdentifyPursuitTeam");
				SetAttributeValue("identifypursuitteam", value);
				OnPropertyChanged("IdentifyPursuitTeam");
			}
		}

		/// <summary>
		/// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("importsequencenumber")]
		public int? ImportSequenceNumber
		{
			get
			{
				return GetAttributeValue<int?>("importsequencenumber");
			}
			set
			{
				OnPropertyChanging("ImportSequenceNumber");
				SetAttributeValue("importsequencenumber", value);
				OnPropertyChanged("ImportSequenceNumber");
			}
		}

		/// <summary>
		/// 영업 팀의 구성원이 이 잠재 고객에게 이전에 연락했는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("initialcommunication")]
		public OptionSetValue InitialCommunication
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("initialcommunication");
			}
			set
			{
				OnPropertyChanging("InitialCommunication");
				SetAttributeValue("initialcommunication", value);
				OnPropertyChanged("InitialCommunication");
			}
		}

		/// <summary>
		/// Commits the Opportunity Revenue to the Sales Forecast.
		/// </summary>
		[AttributeLogicalName("int_addtoforecast")]
		public bool? int_AddtoForecast
		{
			get
			{
				return GetAttributeValue<bool?>("int_addtoforecast");
			}
			set
			{
				OnPropertyChanging("int_AddtoForecast");
				SetAttributeValue("int_addtoforecast", value);
				OnPropertyChanged("int_AddtoForecast");
			}
		}

		/// <summary>
		/// Shows whether a discount has been approved for an Opportunity.
		/// </summary>
		[AttributeLogicalName("int_discountapproved")]
		public bool? int_DiscountApproved
		{
			get
			{
				return GetAttributeValue<bool?>("int_discountapproved");
			}
			set
			{
				OnPropertyChanging("int_DiscountApproved");
				SetAttributeValue("int_discountapproved", value);
				OnPropertyChanged("int_DiscountApproved");
			}
		}

		/// <summary>
		/// Shows the forecasted revenue for an Opportunity.
		/// </summary>
		[AttributeLogicalName("int_forecast")]
		public Money int_Forecast
		{
			get
			{
				return GetAttributeValue<Money>("int_forecast");
			}
			set
			{
				OnPropertyChanging("int_Forecast");
				SetAttributeValue("int_forecast", value);
				OnPropertyChanged("int_Forecast");
			}
		}

		/// <summary>
		/// 기본 통화의 예측 값입니다.
		/// </summary>
		[AttributeLogicalName("int_forecast_base")]
		public Money int_forecast_Base
		{
			get
			{
				return GetAttributeValue<Money>("int_forecast_base");
			}
		}

		/// <summary>
		/// 영업 기회의 예상 수익이 입력한 제품에 따라 자동으로 계산될지, 아니면 사용자가 직접 입력할지를 선택합니다.
		/// </summary>
		[AttributeLogicalName("isrevenuesystemcalculated")]
		public bool? IsRevenueSystemCalculated
		{
			get
			{
				return GetAttributeValue<bool?>("isrevenuesystemcalculated");
			}
			set
			{
				OnPropertyChanging("IsRevenueSystemCalculated");
				SetAttributeValue("isrevenuesystemcalculated", value);
				OnPropertyChanged("IsRevenueSystemCalculated");
			}
		}

		/// <summary>
		/// 마지막 보류 중 시간의 날짜 시간 스탬프가 포함됩니다.
		/// </summary>
		[AttributeLogicalName("lastonholdtime")]
		public DateTime? LastOnHoldTime
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastonholdtime");
			}
			set
			{
				OnPropertyChanging("LastOnHoldTime");
				SetAttributeValue("lastonholdtime", value);
				OnPropertyChanged("LastOnHoldTime");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedby")]
		public EntityReference ModifiedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedby");
			}
		}

		/// <summary>
		/// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
		/// </summary>
		[AttributeLogicalName("modifiedon")]
		public DateTime? ModifiedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("modifiedon");
			}
		}

		/// <summary>
		/// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
		/// </summary>
		[AttributeLogicalName("modifiedonbehalfby")]
		public EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedonbehalfby");
			}
		}

		/// <summary>
		/// 영업 기회를 담당하는 거래처 관리자입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_accountmanagerid")]
		public EntityReference msdyn_AccountManagerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_accountmanagerid");
			}
			set
			{
				OnPropertyChanging("msdyn_AccountManagerId");
				SetAttributeValue("msdyn_accountmanagerid", value);
				OnPropertyChanged("msdyn_AccountManagerId");
			}
		}

		/// <summary>
		/// 영업 기회를 담당하는 조직 구성 단위입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_contractorganizationalunitid")]
		public EntityReference msdyn_ContractOrganizationalUnitId
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_contractorganizationalunitid");
			}
			set
			{
				OnPropertyChanging("msdyn_ContractOrganizationalUnitId");
				SetAttributeValue("msdyn_contractorganizationalunitid", value);
				OnPropertyChanged("msdyn_ContractOrganizationalUnitId");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_ordertype")]
		public OptionSetValue msdyn_OrderType
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("msdyn_ordertype");
			}
			set
			{
				OnPropertyChanging("msdyn_OrderType");
				SetAttributeValue("msdyn_ordertype", value);
				OnPropertyChanged("msdyn_OrderType");
			}
		}

		/// <summary>
		/// 영업 기회에 연결된 작업 주문 유형의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("msdyn_workordertype")]
		public EntityReference msdyn_WorkOrderType
		{
			get
			{
				return GetAttributeValue<EntityReference>("msdyn_workordertype");
			}
			set
			{
				OnPropertyChanging("msdyn_WorkOrderType");
				SetAttributeValue("msdyn_workordertype", value);
				OnPropertyChanged("msdyn_WorkOrderType");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 주제 또는 설명하는 이름을 입력합니다(예: 예상 주문 또는 회사 이름).
		/// </summary>
		[AttributeLogicalName("name")]
		public string Name
		{
			get
			{
				return GetAttributeValue<string>("name");
			}
			set
			{
				OnPropertyChanging("Name");
				SetAttributeValue("name", value);
				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		/// 잠재 고객이 속한 회사에 대한 요구 수준을 선택합니다.
		/// </summary>
		[AttributeLogicalName("need")]
		public OptionSetValue Need
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("need");
			}
			set
			{
				OnPropertyChanging("Need");
				SetAttributeValue("need", value);
				OnPropertyChanged("Need");
			}
		}

		/// <summary>
		/// Field to be removed in future release. Current sample data dependencies exist.
		/// </summary>
		[AttributeLogicalName("new_addtoforecast")]
		public bool? new_AddtoForecast
		{
			get
			{
				return GetAttributeValue<bool?>("new_addtoforecast");
			}
			set
			{
				OnPropertyChanging("new_AddtoForecast");
				SetAttributeValue("new_addtoforecast", value);
				OnPropertyChanged("new_AddtoForecast");
			}
		}

		/// <summary>
		/// Field to be removed in future release. Current sample data dependencies exist.
		/// </summary>
		[AttributeLogicalName("new_forecast")]
		public Money new_Forecast
		{
			get
			{
				return GetAttributeValue<Money>("new_forecast");
			}
			set
			{
				OnPropertyChanging("new_Forecast");
				SetAttributeValue("new_forecast", value);
				OnPropertyChanged("new_Forecast");
			}
		}

		/// <summary>
		/// Field to be removed in future release. Current sample data dependencies exist.
		/// </summary>
		[AttributeLogicalName("new_forecast_base")]
		public Money new_forecast_Base
		{
			get
			{
				return GetAttributeValue<Money>("new_forecast_base");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("new_p_step")]
		public OptionSetValue new_p_step
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("new_p_step");
			}
			set
			{
				OnPropertyChanging("new_p_step");
				SetAttributeValue("new_p_step", value);
				OnPropertyChanged("new_p_step");
			}
		}

		/// <summary>
		/// 영업 기회가 보류 중인 기간(분)을 표시합니다.
		/// </summary>
		[AttributeLogicalName("onholdtime")]
		public int? OnHoldTime
		{
			get
			{
				return GetAttributeValue<int?>("onholdtime");
			}
		}

		/// <summary>
		/// 영업 기회의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("opportunityid")]
		public Guid? OpportunityId
		{
			get
			{
				return GetAttributeValue<Guid?>("opportunityid");
			}
			set
			{
				OnPropertyChanging("OpportunityId");
				SetAttributeValue("opportunityid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = Guid.Empty;
				}
				OnPropertyChanged("OpportunityId");
			}
		}

		[AttributeLogicalName("opportunityid")]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				OpportunityId = value;
			}
		}

		/// <summary>
		/// 수익, 고객 상태 또는 종료 가능성에 따라 영업 기회의 예상 가치 또는 우선 순위를 선택합니다.
		/// </summary>
		[AttributeLogicalName("opportunityratingcode")]
		public OptionSetValue OpportunityRatingCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("opportunityratingcode");
			}
			set
			{
				OnPropertyChanging("OpportunityRatingCode");
				SetAttributeValue("opportunityratingcode", value);
				OnPropertyChanged("OpportunityRatingCode");
			}
		}

		/// <summary>
		/// 보고 및 분석용으로 영업 기회가 만들어진 잠재 고객을 선택합니다. 변환된 잠재 고객이 영업 기회를 만들 경우, 영업 기회가 만들어지고 올바른 잠재 고객이 기본값이 된 후에 필드는 읽기 전용입니다.
		/// </summary>
		[AttributeLogicalName("originatingleadid")]
		public EntityReference OriginatingLeadId
		{
			get
			{
				return GetAttributeValue<EntityReference>("originatingleadid");
			}
			set
			{
				OnPropertyChanging("OriginatingLeadId");
				SetAttributeValue("originatingleadid", value);
				OnPropertyChanged("OriginatingLeadId");
			}
		}

		/// <summary>
		/// 레코드를 마이그레이션한 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("overriddencreatedon")]
		public DateTime? OverriddenCreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("overriddencreatedon");
			}
			set
			{
				OnPropertyChanging("OverriddenCreatedOn");
				SetAttributeValue("overriddencreatedon", value);
				OnPropertyChanged("OverriddenCreatedOn");
			}
		}

		/// <summary>
		/// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
		/// </summary>
		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("ownerid");
			}
			set
			{
				OnPropertyChanging("OwnerId");
				SetAttributeValue("ownerid", value);
				OnPropertyChanged("OwnerId");
			}
		}

		/// <summary>
		/// 영업 기회를 담당하는 사업부의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningbusinessunit")]
		public EntityReference OwningBusinessUnit
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningbusinessunit");
			}
		}

		/// <summary>
		/// 영업 기회를 담당하는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningteam")]
		public EntityReference OwningTeam
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningteam");
			}
		}

		/// <summary>
		/// 영업 기회를 담당하는 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owninguser")]
		public EntityReference OwningUser
		{
			get
			{
				return GetAttributeValue<EntityReference>("owninguser");
			}
		}

		/// <summary>
		/// 관계가 보고서 및 분석표에 표시되고 추가 정보(예: 재무 정보 및 활동)에 대한 퀵 링크를 제공하도록 이 영업 기회를 연결할 거래처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("parentaccountid")]
		public EntityReference ParentAccountId
		{
			get
			{
				return GetAttributeValue<EntityReference>("parentaccountid");
			}
			set
			{
				OnPropertyChanging("ParentAccountId");
				SetAttributeValue("parentaccountid", value);
				OnPropertyChanged("ParentAccountId");
			}
		}

		/// <summary>
		/// 관계가 보고서 및 분석표에 표시되도록 이 영업 기회를 연결하는 연락처를 선택합니다.
		/// </summary>
		[AttributeLogicalName("parentcontactid")]
		public EntityReference ParentContactId
		{
			get
			{
				return GetAttributeValue<EntityReference>("parentcontactid");
			}
			set
			{
				OnPropertyChanging("ParentContactId");
				SetAttributeValue("parentcontactid", value);
				OnPropertyChanged("ParentContactId");
			}
		}

		/// <summary>
		/// 영업 기회가 워크플로 규칙에 관여하는지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("participatesinworkflow")]
		public bool? ParticipatesInWorkflow
		{
			get
			{
				return GetAttributeValue<bool?>("participatesinworkflow");
			}
			set
			{
				OnPropertyChanging("ParticipatesInWorkflow");
				SetAttributeValue("participatesinworkflow", value);
				OnPropertyChanged("ParticipatesInWorkflow");
			}
		}

		/// <summary>
		/// 최종 제안이 거래처에 제시되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("presentfinalproposal")]
		public bool? PresentFinalProposal
		{
			get
			{
				return GetAttributeValue<bool?>("presentfinalproposal");
			}
			set
			{
				OnPropertyChanging("PresentFinalProposal");
				SetAttributeValue("presentfinalproposal", value);
				OnPropertyChanged("PresentFinalProposal");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 제안이 거래처에 제시되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("presentproposal")]
		public bool? PresentProposal
		{
			get
			{
				return GetAttributeValue<bool?>("presentproposal");
			}
			set
			{
				OnPropertyChanging("PresentProposal");
				SetAttributeValue("presentproposal", value);
				OnPropertyChanged("PresentProposal");
			}
		}

		/// <summary>
		/// 캠페인과 연관된 제품이 올바른 가격으로 제공되도록 이 레코드와 연관된 가격표를 선택합니다.
		/// </summary>
		[AttributeLogicalName("pricelevelid")]
		public EntityReference PriceLevelId
		{
			get
			{
				return GetAttributeValue<EntityReference>("pricelevelid");
			}
			set
			{
				OnPropertyChanging("PriceLevelId");
				SetAttributeValue("pricelevelid", value);
				OnPropertyChanged("PriceLevelId");
			}
		}

		/// <summary>
		/// 영업 기회의 가격 산정 오류입니다.
		/// </summary>
		[AttributeLogicalName("pricingerrorcode")]
		public OptionSetValue PricingErrorCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("pricingerrorcode");
			}
			set
			{
				OnPropertyChanging("PricingErrorCode");
				SetAttributeValue("pricingerrorcode", value);
				OnPropertyChanged("PricingErrorCode");
			}
		}

		/// <summary>
		/// 선호 고객 또는 주요 문제를 빠르게 처리하도록 우선 순위를 선택합니다.
		/// </summary>
		[AttributeLogicalName("prioritycode")]
		public OptionSetValue PriorityCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("prioritycode");
			}
			set
			{
				OnPropertyChanging("PriorityCode");
				SetAttributeValue("prioritycode", value);
				OnPropertyChanged("PriorityCode");
			}
		}

		/// <summary>
		/// 프로세스의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("processid")]
		public Guid? ProcessId
		{
			get
			{
				return GetAttributeValue<Guid?>("processid");
			}
			set
			{
				OnPropertyChanging("ProcessId");
				SetAttributeValue("processid", value);
				OnPropertyChanged("ProcessId");
			}
		}

		/// <summary>
		/// 영업 기회의 제안된 솔루션에 대한 메모를 입력합니다.
		/// </summary>
		[AttributeLogicalName("proposedsolution")]
		public string ProposedSolution
		{
			get
			{
				return GetAttributeValue<string>("proposedsolution");
			}
			set
			{
				OnPropertyChanging("ProposedSolution");
				SetAttributeValue("proposedsolution", value);
				OnPropertyChanged("ProposedSolution");
			}
		}

		/// <summary>
		/// 개인 또는 위원회가 잠재 고객의 구매 프로세스에 관여하는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("purchaseprocess")]
		public OptionSetValue PurchaseProcess
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("purchaseprocess");
			}
			set
			{
				OnPropertyChanging("PurchaseProcess");
				SetAttributeValue("purchaseprocess", value);
				OnPropertyChanged("PurchaseProcess");
			}
		}

		/// <summary>
		/// 잠재 고객이 구매하기까지 소요될 수 있는 기간을 선택합니다.
		/// </summary>
		[AttributeLogicalName("purchasetimeframe")]
		public OptionSetValue PurchaseTimeframe
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("purchasetimeframe");
			}
			set
			{
				OnPropertyChanging("PurchaseTimeframe");
				SetAttributeValue("purchasetimeframe", value);
				OnPropertyChanged("PurchaseTimeframe");
			}
		}

		/// <summary>
		/// 영업 기회 추구에 대한 결정이 내려졌는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("pursuitdecision")]
		public bool? PursuitDecision
		{
			get
			{
				return GetAttributeValue<bool?>("pursuitdecision");
			}
			set
			{
				OnPropertyChanging("PursuitDecision");
				SetAttributeValue("pursuitdecision", value);
				OnPropertyChanged("PursuitDecision");
			}
		}

		/// <summary>
		/// 잠재 고객 선별 또는 점수에 대한 설명을 입력합니다.
		/// </summary>
		[AttributeLogicalName("qualificationcomments")]
		public string QualificationComments
		{
			get
			{
				return GetAttributeValue<string>("qualificationcomments");
			}
			set
			{
				OnPropertyChanging("QualificationComments");
				SetAttributeValue("qualificationcomments", value);
				OnPropertyChanged("QualificationComments");
			}
		}

		/// <summary>
		/// 영업 기회와 연관된 견적에 대한 설명을 입력합니다.
		/// </summary>
		[AttributeLogicalName("quotecomments")]
		public string QuoteComments
		{
			get
			{
				return GetAttributeValue<string>("quotecomments");
			}
			set
			{
				OnPropertyChanging("QuoteComments");
				SetAttributeValue("quotecomments", value);
				OnPropertyChanged("QuoteComments");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 제안 피드백을 받아 해결되었는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("resolvefeedback")]
		public bool? ResolveFeedback
		{
			get
			{
				return GetAttributeValue<bool?>("resolvefeedback");
			}
			set
			{
				OnPropertyChanging("ResolveFeedback");
				SetAttributeValue("resolvefeedback", value);
				OnPropertyChanged("ResolveFeedback");
			}
		}

		/// <summary>
		/// 이 영업 기회를 성공하기 위한 노력으로 영업 팀을 돕기 위해 이 영업 기회의 영업 스테이지를 선택합니다.
		/// </summary>
		[AttributeLogicalName("salesstage")]
		public OptionSetValue SalesStage
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("salesstage");
			}
			set
			{
				OnPropertyChanging("SalesStage");
				SetAttributeValue("salesstage", value);
				OnPropertyChanged("SalesStage");
			}
		}

		/// <summary>
		/// 영업 기회를 종료할 가능성을 나타내도록 영업 기회의 영업 프로세스 스테이지를 선택합니다.
		/// </summary>
		[AttributeLogicalName("salesstagecode")]
		public OptionSetValue SalesStageCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("salesstagecode");
			}
			set
			{
				OnPropertyChanging("SalesStageCode");
				SetAttributeValue("salesstagecode", value);
				OnPropertyChanged("SalesStageCode");
			}
		}

		/// <summary>
		/// 잠재 고객과의 조사 후속작업 모임의 날짜와 시간을 입력합니다.
		/// </summary>
		[AttributeLogicalName("schedulefollowup_prospect")]
		public DateTime? ScheduleFollowup_Prospect
		{
			get
			{
				return GetAttributeValue<DateTime?>("schedulefollowup_prospect");
			}
			set
			{
				OnPropertyChanging("ScheduleFollowup_Prospect");
				SetAttributeValue("schedulefollowup_prospect", value);
				OnPropertyChanged("ScheduleFollowup_Prospect");
			}
		}

		/// <summary>
		/// 잠재 고객과의 선별 후속작업 모임의 날짜와 시간을 입력합니다.
		/// </summary>
		[AttributeLogicalName("schedulefollowup_qualify")]
		public DateTime? ScheduleFollowup_Qualify
		{
			get
			{
				return GetAttributeValue<DateTime?>("schedulefollowup_qualify");
			}
			set
			{
				OnPropertyChanging("ScheduleFollowup_Qualify");
				SetAttributeValue("schedulefollowup_qualify", value);
				OnPropertyChanged("ScheduleFollowup_Qualify");
			}
		}

		/// <summary>
		/// 영업 기회를 위한 제안 모임의 날짜와 시간을 입력합니다.
		/// </summary>
		[AttributeLogicalName("scheduleproposalmeeting")]
		public DateTime? ScheduleProposalMeeting
		{
			get
			{
				return GetAttributeValue<DateTime?>("scheduleproposalmeeting");
			}
			set
			{
				OnPropertyChanging("ScheduleProposalMeeting");
				SetAttributeValue("scheduleproposalmeeting", value);
				OnPropertyChanged("ScheduleProposalMeeting");
			}
		}

		/// <summary>
		/// 제안 고려에 대한 감사 메시지를 거래처에 보냈는지 여부를 선택합니다.
		/// </summary>
		[AttributeLogicalName("sendthankyounote")]
		public bool? SendThankYouNote
		{
			get
			{
				return GetAttributeValue<bool?>("sendthankyounote");
			}
			set
			{
				OnPropertyChanging("SendThankYouNote");
				SetAttributeValue("sendthankyounote", value);
				OnPropertyChanged("SendThankYouNote");
			}
		}

		/// <summary>
		/// 영업 기회 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
		/// </summary>
		[AttributeLogicalName("slaid")]
		public EntityReference SLAId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slaid");
			}
			set
			{
				OnPropertyChanging("SLAId");
				SetAttributeValue("slaid", value);
				OnPropertyChanged("SLAId");
			}
		}

		/// <summary>
		/// 이 영업 기회에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("slainvokedid")]
		public EntityReference SLAInvokedId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slainvokedid");
			}
		}

		/// <summary>
		/// 스테이지의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("stageid")]
		public Guid? StageId
		{
			get
			{
				return GetAttributeValue<Guid?>("stageid");
			}
			set
			{
				OnPropertyChanging("StageId");
				SetAttributeValue("stageid", value);
				OnPropertyChanged("StageId");
			}
		}

		/// <summary>
		/// 영업 기회가 시작되었는지, 성공했는지, 아니면 실패했는지를 표시합니다. 성공 및 실패한 영업 기회는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
		/// </summary>
		[AttributeLogicalName("statecode")]
		public OpportunityState? StateCode
		{
			get
			{
				OptionSetValue optionSet = GetAttributeValue<OptionSetValue>("statecode");
				if (optionSet != null)
				{
					return (OpportunityState)Enum.ToObject(typeof(OpportunityState), optionSet.Value);
				}
				else
				{
					return null;
				}
			}
			set
			{
				OnPropertyChanging("StateCode");
				if (value == null)
				{
					SetAttributeValue("statecode", null);
				}
				else
				{
					SetAttributeValue("statecode", new OptionSetValue((int)value));
				}
				OnPropertyChanged("StateCode");
			}
		}

		/// <summary>
		/// 영업 기회의 상태를 선택합니다.
		/// </summary>
		[AttributeLogicalName("statuscode")]
		public OptionSetValue StatusCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("statuscode");
			}
			set
			{
				OnPropertyChanging("StatusCode");
				SetAttributeValue("statuscode", value);
				OnPropertyChanged("StatusCode");
			}
		}

		/// <summary>
		/// 워크플로 단계의 ID를 표시합니다.
		/// </summary>
		[AttributeLogicalName("stepid")]
		public Guid? StepId
		{
			get
			{
				return GetAttributeValue<Guid?>("stepid");
			}
			set
			{
				OnPropertyChanging("StepId");
				SetAttributeValue("stepid", value);
				OnPropertyChanged("StepId");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 영업 기회 보유 현황의 현재 단계를 표시합니다. 워크플로에서 업데이트됩니다.
		/// </summary>
		[AttributeLogicalName("stepname")]
		public string StepName
		{
			get
			{
				return GetAttributeValue<string>("stepname");
			}
			set
			{
				OnPropertyChanging("StepName");
				SetAttributeValue("stepname", value);
				OnPropertyChanged("StepName");
			}
		}

		/// <summary>
		/// 영업 기회 종료 가능성이 있는 날짜를 선택합니다.
		/// </summary>
		[AttributeLogicalName("timeline")]
		public OptionSetValue TimeLine
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("timeline");
			}
			set
			{
				OnPropertyChanging("TimeLine");
				SetAttributeValue("timeline", value);
				OnPropertyChanged("TimeLine");
			}
		}

		/// <summary>
		/// 영업 기회 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
		/// </summary>
		[AttributeLogicalName("timespentbymeonemailandmeetings")]
		public string TimeSpentByMeOnEmailAndMeetings
		{
			get
			{
				return GetAttributeValue<string>("timespentbymeonemailandmeetings");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("timezoneruleversionnumber")]
		public int? TimeZoneRuleVersionNumber
		{
			get
			{
				return GetAttributeValue<int?>("timezoneruleversionnumber");
			}
			set
			{
				OnPropertyChanging("TimeZoneRuleVersionNumber");
				SetAttributeValue("timezoneruleversionnumber", value);
				OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}

		/// <summary>
		/// 영업 기회에 대한 제품, 할인, 운송 및 세금합계로 계산된 총 금액을 표시합니다.
		/// </summary>
		[AttributeLogicalName("totalamount")]
		public Money TotalAmount
		{
			get
			{
				return GetAttributeValue<Money>("totalamount");
			}
			set
			{
				OnPropertyChanging("TotalAmount");
				SetAttributeValue("totalamount", value);
				OnPropertyChanged("TotalAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totalamount_base")]
		public Money TotalAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("totalamount_base");
			}
		}

		/// <summary>
		/// 할인액을 차감한 영업 기회의 총 제품 금액을 표시합니다. 이 값은 영업 기회의 총 금액을 계산하여 운송료 및 세금에 추가됩니다.
		/// </summary>
		[AttributeLogicalName("totalamountlessfreight")]
		public Money TotalAmountLessFreight
		{
			get
			{
				return GetAttributeValue<Money>("totalamountlessfreight");
			}
			set
			{
				OnPropertyChanging("TotalAmountLessFreight");
				SetAttributeValue("totalamountlessfreight", value);
				OnPropertyChanged("TotalAmountLessFreight");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 운송료 미포함 가격] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totalamountlessfreight_base")]
		public Money TotalAmountLessFreight_Base
		{
			get
			{
				return GetAttributeValue<Money>("totalamountlessfreight_base");
			}
		}

		/// <summary>
		/// 영업 기회에 입력한 할인 가격 및 비율에 따라 총 할인 금액을 표시합니다.
		/// </summary>
		[AttributeLogicalName("totaldiscountamount")]
		public Money TotalDiscountAmount
		{
			get
			{
				return GetAttributeValue<Money>("totaldiscountamount");
			}
			set
			{
				OnPropertyChanging("TotalDiscountAmount");
				SetAttributeValue("totaldiscountamount", value);
				OnPropertyChanged("TotalDiscountAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totaldiscountamount_base")]
		public Money TotalDiscountAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("totaldiscountamount_base");
			}
		}

		/// <summary>
		/// 지정된 가격표와 수량에 따라 영업 기회에 포함된 모든 기존 및 직접 입력 제품 합계를 표시합니다.
		/// </summary>
		[AttributeLogicalName("totallineitemamount")]
		public Money TotalLineItemAmount
		{
			get
			{
				return GetAttributeValue<Money>("totallineitemamount");
			}
			set
			{
				OnPropertyChanging("TotalLineItemAmount");
				SetAttributeValue("totallineitemamount", value);
				OnPropertyChanged("TotalLineItemAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 소계] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totallineitemamount_base")]
		public Money TotalLineItemAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("totallineitemamount_base");
			}
		}

		/// <summary>
		/// 영업 기회에 포함된 모든 제품에 지정된 총 일반 할인 금액을 표시합니다. 이 값은 영업 기회의 [총 소계] 필드에 반영되며 영업 기회에 지정된 모든 할인 금액 또는 비율에 추가됩니다.
		/// </summary>
		[AttributeLogicalName("totallineitemdiscountamount")]
		public Money TotalLineItemDiscountAmount
		{
			get
			{
				return GetAttributeValue<Money>("totallineitemdiscountamount");
			}
			set
			{
				OnPropertyChanging("TotalLineItemDiscountAmount");
				SetAttributeValue("totallineitemdiscountamount", value);
				OnPropertyChanged("TotalLineItemDiscountAmount");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 품목 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totallineitemdiscountamount_base")]
		public Money TotalLineItemDiscountAmount_Base
		{
			get
			{
				return GetAttributeValue<Money>("totallineitemdiscountamount_base");
			}
		}

		/// <summary>
		/// 영업 기회에 포함된 모든 제품에 지정된 총 세금을 표시합니다. 이 값은 영업 기회에 대한 [총 금액] 필드 계산에 포함됩니다.
		/// </summary>
		[AttributeLogicalName("totaltax")]
		public Money TotalTax
		{
			get
			{
				return GetAttributeValue<Money>("totaltax");
			}
			set
			{
				OnPropertyChanging("TotalTax");
				SetAttributeValue("totaltax", value);
				OnPropertyChanged("TotalTax");
			}
		}

		/// <summary>
		/// 보고용으로 시스템의 기본 통화로 변환된 [총 세금] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
		/// </summary>
		[AttributeLogicalName("totaltax_base")]
		public Money TotalTax_Base
		{
			get
			{
				return GetAttributeValue<Money>("totaltax_base");
			}
		}

		/// <summary>
		/// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
		/// </summary>
		[AttributeLogicalName("transactioncurrencyid")]
		public EntityReference TransactionCurrencyId
		{
			get
			{
				return GetAttributeValue<EntityReference>("transactioncurrencyid");
			}
			set
			{
				OnPropertyChanging("TransactionCurrencyId");
				SetAttributeValue("transactioncurrencyid", value);
				OnPropertyChanged("TransactionCurrencyId");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("traversedpath")]
		public string TraversedPath
		{
			get
			{
				return GetAttributeValue<string>("traversedpath");
			}
			set
			{
				OnPropertyChanging("TraversedPath");
				SetAttributeValue("traversedpath", value);
				OnPropertyChanged("TraversedPath");
			}
		}

		/// <summary>
		/// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
		/// </summary>
		[AttributeLogicalName("utcconversiontimezonecode")]
		public int? UTCConversionTimeZoneCode
		{
			get
			{
				return GetAttributeValue<int?>("utcconversiontimezonecode");
			}
			set
			{
				OnPropertyChanging("UTCConversionTimeZoneCode");
				SetAttributeValue("utcconversiontimezonecode", value);
				OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}

		/// <summary>
		/// 영업 기회의 버전 번호입니다.
		/// </summary>
		[AttributeLogicalName("versionnumber")]
		public long? VersionNumber
		{
			get
			{
				return GetAttributeValue<long?>("versionnumber");
			}
		}

		#endregion Field

		//새 레코드를 생성할 때 값을 지정해야하는 데 이 값의 타입을 서버에 커넥트한 후 opportunity의 타입을 모두 가져와서 dictionary의 키와 비교한 후 타입에 맞게 값을 넣어 create한다.
		///<seealso cref="https://stackoverflow.com/a/18293398"/>
		public Guid CreateRecord(IOrganizationService service, EntityAttributeCollection entityAttirbutes)
		{
			Entity e = new Entity("opportunity");

			e.Attributes["Name"] = "help";
			var ee = new Entity("account")
			{
				["Name"] = "help",
			};
			service.Create(ee);

			/*
            Dictionary<string, object> items = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> item in items)
            {
                if (item.Value.ToString() == "Microsoft.Xrm.Sdk.OptionSetValue") ;

                //Console.WriteLine(((OptionSetValue)item.Value).Value);
                else if (item.Value.ToString() == "Microsoft.Xrm.Sdk.Money") ;

                //Console.WriteLine(((Money)item.Value).Value);
            }
            */

			return service.Create(e);
		}
	}

	//서비스 케이스
	/// <summary>
	/// 계약과 연관된 서비스 요청 서비스 케이스입니다.
	/// </summary>

	public partial class SystemUser
	{
		private SystemUser()
		{ }

		public string GetCurrentUserName(IOrganizationService service, Guid userId)
		{
			try
			{
				// Lookup User
				var User = service.Retrieve("systemuser", userId, new ColumnSet("fullname"));
				return User.Contains("fullname") ? User["fullname"].ToString() : string.Empty;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public string GetCurrentUserName(ServiceClient service)
		{
			try
			{
				// Get a system user
				//var userId = Messages.GetCurrentUserId(service);
				var userId = service.GetMyUserId();

				// Lookup User
				return GetCurrentUserName(service, userId);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}

	/// <summary>
	/// 사용자가 수행했거나 수행할 작업입니다. 활동은 일정에 항목을 만들 수 있는 작업입니다.
	/// </summary>
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("activitypointer")]
	[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
	public partial class ActivityPointer : Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		#region Field

		[System.Runtime.Serialization.DataContract()]
		[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
		public enum ActivityPointerState
		{
			[System.Runtime.Serialization.EnumMember()]
			Open = 0,

			[System.Runtime.Serialization.EnumMember()]
			Completed = 1,

			[System.Runtime.Serialization.EnumMember()]
			Canceled = 2,

			[System.Runtime.Serialization.EnumMember()]
			Scheduled = 3,
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public ActivityPointer() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "activitypointer";

		public const int EntityTypeCode = 4200;

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

		/// <summary>
		/// 외부 응용 프로그램에서 JSON으로 제공된 추가 정보입니다. 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("activityadditionalparams")]
		public string ActivityAdditionalParams
		{
			get
			{
				return GetAttributeValue<string>("activityadditionalparams");
			}
			set
			{
				OnPropertyChanging("ActivityAdditionalParams");
				SetAttributeValue("activityadditionalparams", value);
				OnPropertyChanged("ActivityAdditionalParams");
			}
		}

		/// <summary>
		/// 활동의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("activityid")]
		public Guid? ActivityId
		{
			get
			{
				return GetAttributeValue<Guid?>("activityid");
			}
			set
			{
				OnPropertyChanging("ActivityId");
				SetAttributeValue("activityid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = Guid.Empty;
				}
				OnPropertyChanged("ActivityId");
			}
		}

		[AttributeLogicalName("activityid")]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				ActivityId = value;
			}
		}

		/// <summary>
		/// 활동의 유형입니다.
		/// </summary>
		[AttributeLogicalName("activitytypecode")]
		public string ActivityTypeCode
		{
			get
			{
				return GetAttributeValue<string>("activitytypecode");
			}
		}

		/// <summary>
		/// 활동의 실제 기간(분)입니다.
		/// </summary>
		[AttributeLogicalName("actualdurationminutes")]
		public int? ActualDurationMinutes
		{
			get
			{
				return GetAttributeValue<int?>("actualdurationminutes");
			}
			set
			{
				OnPropertyChanging("ActualDurationMinutes");
				SetAttributeValue("actualdurationminutes", value);
				OnPropertyChanged("ActualDurationMinutes");
			}
		}

		/// <summary>
		/// 활동의 실제 종료 시간입니다.
		/// </summary>
		[AttributeLogicalName("actualend")]
		public DateTime? ActualEnd
		{
			get
			{
				return GetAttributeValue<DateTime?>("actualend");
			}
			set
			{
				OnPropertyChanging("ActualEnd");
				SetAttributeValue("actualend", value);
				OnPropertyChanged("ActualEnd");
			}
		}

		/// <summary>
		/// 활동의 실제 시작 시간입니다.
		/// </summary>
		[AttributeLogicalName("actualstart")]
		public DateTime? ActualStart
		{
			get
			{
				return GetAttributeValue<DateTime?>("actualstart");
			}
			set
			{
				OnPropertyChanging("ActualStart");
				SetAttributeValue("actualstart", value);
				OnPropertyChanged("ActualStart");
			}
		}

		/// <summary>
		/// 이 활동과 연관된 모든 활동 당사자입니다.
		/// </summary>
		[AttributeLogicalName("allparties")]
		public System.Collections.Generic.IEnumerable<ActivityParty> allparties
		{
			get
			{
				EntityCollection collection = GetAttributeValue<EntityCollection>("allparties");
				if (collection != null
							&& collection.Entities != null)
				{
					return System.Linq.Enumerable.Cast<ActivityParty>(collection.Entities);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Twitter 또는 Facebook과 같이 소셜 활동 연락처의 출처를 표시합니다. 이 필드는 읽기 전용입니다.
		/// </summary>
		[AttributeLogicalName("community")]
		public OptionSetValue Community
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("community");
			}
			set
			{
				OnPropertyChanging("Community");
				SetAttributeValue("community", value);
				OnPropertyChanged("Community");
			}
		}

		/// <summary>
		/// 활동을 만든 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("createdby")]
		public EntityReference CreatedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdby");
			}
		}

		/// <summary>
		/// 활동을 만든 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("createdon")]
		public DateTime? CreatedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("createdon");
			}
		}

		/// <summary>
		/// 활동 포인터를 만든 대리인 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("createdonbehalfby")]
		public EntityReference CreatedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("createdonbehalfby");
			}
		}

		/// <summary>
		/// 활동 배달을 마지막으로 시도한 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("deliverylastattemptedon")]
		public DateTime? DeliveryLastAttemptedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("deliverylastattemptedon");
			}
		}

		/// <summary>
		/// 전자 메일 서버에 활동 배달 우선 순위입니다.
		/// </summary>
		[AttributeLogicalName("deliveryprioritycode")]
		public OptionSetValue DeliveryPriorityCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("deliveryprioritycode");
			}
			set
			{
				OnPropertyChanging("DeliveryPriorityCode");
				SetAttributeValue("deliveryprioritycode", value);
				OnPropertyChanged("DeliveryPriorityCode");
			}
		}

		/// <summary>
		/// 활동에 대한 설명입니다.
		/// </summary>
		[AttributeLogicalName("description")]
		public string Description
		{
			get
			{
				return GetAttributeValue<string>("description");
			}
			set
			{
				OnPropertyChanging("Description");
				SetAttributeValue("description", value);
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// Exchange Server에서 반환된 활동의 메시지 id입니다.
		/// </summary>
		[AttributeLogicalName("exchangeitemid")]
		public string ExchangeItemId
		{
			get
			{
				return GetAttributeValue<string>("exchangeitemid");
			}
			set
			{
				OnPropertyChanging("ExchangeItemId");
				SetAttributeValue("exchangeitemid", value);
				OnPropertyChanged("ExchangeItemId");
			}
		}

		/// <summary>
		/// 활동 포인터와 연결된 통화의 기본 통화 기준 환율입니다.
		/// </summary>
		[AttributeLogicalName("exchangerate")]
		public decimal? ExchangeRate
		{
			get
			{
				return GetAttributeValue<decimal?>("exchangerate");
			}
		}

		/// <summary>
		/// 전자 메일 유형의 활동의 웹 링크를 표시합니다.
		/// </summary>
		[AttributeLogicalName("exchangeweblink")]
		public string ExchangeWebLink
		{
			get
			{
				return GetAttributeValue<string>("exchangeweblink");
			}
			set
			{
				OnPropertyChanging("ExchangeWebLink");
				SetAttributeValue("exchangeweblink", value);
				OnPropertyChanged("ExchangeWebLink");
			}
		}

		/// <summary>
		/// 되풀이 항목의 인스턴스 유형입니다.
		/// </summary>
		[AttributeLogicalName("instancetypecode")]
		public OptionSetValue InstanceTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("instancetypecode");
			}
		}

		/// <summary>
		/// 서비스 케이스를 해결하기 위한 일환으로 해당 활동에 대한 대금이 청구되었는지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("isbilled")]
		public bool? IsBilled
		{
			get
			{
				return GetAttributeValue<bool?>("isbilled");
			}
			set
			{
				OnPropertyChanging("IsBilled");
				SetAttributeValue("isbilled", value);
				OnPropertyChanged("IsBilled");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("ismapiprivate")]
		public bool? IsMapiPrivate
		{
			get
			{
				return GetAttributeValue<bool?>("ismapiprivate");
			}
			set
			{
				OnPropertyChanging("IsMapiPrivate");
				SetAttributeValue("ismapiprivate", value);
				OnPropertyChanged("IsMapiPrivate");
			}
		}

		/// <summary>
		/// 활동이 정기 활동 유형 또는 이벤트 유형인지와 관련된 정보입니다.
		/// </summary>
		[AttributeLogicalName("isregularactivity")]
		public bool? IsRegularActivity
		{
			get
			{
				return GetAttributeValue<bool?>("isregularactivity");
			}
		}

		/// <summary>
		/// 활동을 워크플로 규칙에서 만들었는지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("isworkflowcreated")]
		public bool? IsWorkflowCreated
		{
			get
			{
				return GetAttributeValue<bool?>("isworkflowcreated");
			}
			set
			{
				OnPropertyChanging("IsWorkflowCreated");
				SetAttributeValue("isworkflowcreated", value);
				OnPropertyChanged("IsWorkflowCreated");
			}
		}

		/// <summary>
		/// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
		/// </summary>
		[AttributeLogicalName("lastonholdtime")]
		public DateTime? LastOnHoldTime
		{
			get
			{
				return GetAttributeValue<DateTime?>("lastonholdtime");
			}
			set
			{
				OnPropertyChanging("LastOnHoldTime");
				SetAttributeValue("lastonholdtime", value);
				OnPropertyChanged("LastOnHoldTime");
			}
		}

		/// <summary>
		/// 음성 사서함 나감
		/// </summary>
		[AttributeLogicalName("leftvoicemail")]
		public bool? LeftVoiceMail
		{
			get
			{
				return GetAttributeValue<bool?>("leftvoicemail");
			}
			set
			{
				OnPropertyChanging("LeftVoiceMail");
				SetAttributeValue("leftvoicemail", value);
				OnPropertyChanged("LeftVoiceMail");
			}
		}

		/// <summary>
		/// 활동을 마지막으로 수정한 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("modifiedby")]
		public EntityReference ModifiedBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedby");
			}
		}

		/// <summary>
		/// 활동을 마지막으로 수정한 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("modifiedon")]
		public DateTime? ModifiedOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("modifiedon");
			}
		}

		/// <summary>
		/// 활동 포인터를 마지막으로 수정한 대리인 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("modifiedonbehalfby")]
		public EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return GetAttributeValue<EntityReference>("modifiedonbehalfby");
			}
		}

		/// <summary>
		/// 레코드가 보류 중인 시간을 분으로 표시합니다.
		/// </summary>
		[AttributeLogicalName("onholdtime")]
		public int? OnHoldTime
		{
			get
			{
				return GetAttributeValue<int?>("onholdtime");
			}
		}

		/// <summary>
		/// 활동을 담당하는 사용자 또는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("ownerid");
			}
			set
			{
				OnPropertyChanging("OwnerId");
				SetAttributeValue("ownerid", value);
				OnPropertyChanged("OwnerId");
			}
		}

		/// <summary>
		/// 활동을 담당하는 사업부의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningbusinessunit")]
		public EntityReference OwningBusinessUnit
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningbusinessunit");
			}
		}

		/// <summary>
		/// 활동을 담당하는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owningteam")]
		public EntityReference OwningTeam
		{
			get
			{
				return GetAttributeValue<EntityReference>("owningteam");
			}
		}

		/// <summary>
		/// 활동을 담당하는 사용자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("owninguser")]
		public EntityReference OwningUser
		{
			get
			{
				return GetAttributeValue<EntityReference>("owninguser");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("postponeactivityprocessinguntil")]
		public DateTime? PostponeActivityProcessingUntil
		{
			get
			{
				return GetAttributeValue<DateTime?>("postponeactivityprocessinguntil");
			}
		}

		/// <summary>
		/// 활동의 우선 순위입니다.
		/// </summary>
		[AttributeLogicalName("prioritycode")]
		public OptionSetValue PriorityCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("prioritycode");
			}
			set
			{
				OnPropertyChanging("PriorityCode");
				SetAttributeValue("prioritycode", value);
				OnPropertyChanged("PriorityCode");
			}
		}

		/// <summary>
		/// 프로세스의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("processid")]
		public Guid? ProcessId
		{
			get
			{
				return GetAttributeValue<Guid?>("processid");
			}
			set
			{
				OnPropertyChanging("ProcessId");
				SetAttributeValue("processid", value);
				OnPropertyChanged("ProcessId");
			}
		}

		/// <summary>
		/// 활동이 연결된 개체의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("regardingobjectid")]
		public EntityReference RegardingObjectId
		{
			get
			{
				return GetAttributeValue<EntityReference>("regardingobjectid");
			}
			set
			{
				OnPropertyChanging("RegardingObjectId");
				SetAttributeValue("regardingobjectid", value);
				OnPropertyChanged("RegardingObjectId");
			}
		}

		/// <summary>
		/// 활동의 예약된 기간(분)입니다.
		/// </summary>
		[AttributeLogicalName("scheduleddurationminutes")]
		public int? ScheduledDurationMinutes
		{
			get
			{
				return GetAttributeValue<int?>("scheduleddurationminutes");
			}
			set
			{
				OnPropertyChanging("ScheduledDurationMinutes");
				SetAttributeValue("scheduleddurationminutes", value);
				OnPropertyChanged("ScheduledDurationMinutes");
			}
		}

		/// <summary>
		/// 활동의 예약된 종료 시간입니다.
		/// </summary>
		[AttributeLogicalName("scheduledend")]
		public DateTime? ScheduledEnd
		{
			get
			{
				return GetAttributeValue<DateTime?>("scheduledend");
			}
			set
			{
				OnPropertyChanging("ScheduledEnd");
				SetAttributeValue("scheduledend", value);
				OnPropertyChanged("ScheduledEnd");
			}
		}

		/// <summary>
		/// 활동의 예약된 시작 시간입니다.
		/// </summary>
		[AttributeLogicalName("scheduledstart")]
		public DateTime? ScheduledStart
		{
			get
			{
				return GetAttributeValue<DateTime?>("scheduledstart");
			}
			set
			{
				OnPropertyChanging("ScheduledStart");
				SetAttributeValue("scheduledstart", value);
				OnPropertyChanged("ScheduledStart");
			}
		}

		/// <summary>
		/// 전자 메일 메시지를 보낸 사람과 연관된 사서함의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("sendermailboxid")]
		public EntityReference SenderMailboxId
		{
			get
			{
				return GetAttributeValue<EntityReference>("sendermailboxid");
			}
		}

		/// <summary>
		/// 활동을 보낸 날짜 및 시간입니다.
		/// </summary>
		[AttributeLogicalName("senton")]
		public DateTime? SentOn
		{
			get
			{
				return GetAttributeValue<DateTime?>("senton");
			}
		}

		/// <summary>
		/// 인스턴스의 되풀이 항목 ID를 지정하는 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("seriesid")]
		public Guid? SeriesId
		{
			get
			{
				return GetAttributeValue<Guid?>("seriesid");
			}
		}

		/// <summary>
		/// 연관된 서비스의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("serviceid")]
		public EntityReference ServiceId
		{
			get
			{
				return GetAttributeValue<EntityReference>("serviceid");
			}
			set
			{
				OnPropertyChanging("ServiceId");
				SetAttributeValue("serviceid", value);
				OnPropertyChanged("ServiceId");
			}
		}

		/// <summary>
		/// 서비스 케이스 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
		/// </summary>
		[AttributeLogicalName("slaid")]
		public EntityReference SLAId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slaid");
			}
			set
			{
				OnPropertyChanging("SLAId");
				SetAttributeValue("slaid", value);
				OnPropertyChanged("SLAId");
			}
		}

		/// <summary>
		/// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("slainvokedid")]
		public EntityReference SLAInvokedId
		{
			get
			{
				return GetAttributeValue<EntityReference>("slainvokedid");
			}
		}

		/// <summary>
		/// 활동이 정렬된 날짜 및 시간을 표시합니다.
		/// </summary>
		[AttributeLogicalName("sortdate")]
		public DateTime? SortDate
		{
			get
			{
				return GetAttributeValue<DateTime?>("sortdate");
			}
			set
			{
				OnPropertyChanging("SortDate");
				SetAttributeValue("sortdate", value);
				OnPropertyChanged("SortDate");
			}
		}

		/// <summary>
		/// 스테이지의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("stageid")]
		public Guid? StageId
		{
			get
			{
				return GetAttributeValue<Guid?>("stageid");
			}
			set
			{
				OnPropertyChanging("StageId");
				SetAttributeValue("stageid", value);
				OnPropertyChanged("StageId");
			}
		}

		/// <summary>
		/// 활동의 상태입니다.
		/// </summary>
		[AttributeLogicalName("statecode")]
		public ActivityPointerState? StateCode
		{
			get
			{
				OptionSetValue optionSet = GetAttributeValue<OptionSetValue>("statecode");
				if (optionSet != null)
				{
					return (ActivityPointerState)Enum.ToObject(typeof(ActivityPointerState), optionSet.Value);
				}
				else
				{
					return null;
				}
			}
			set
			{
				OnPropertyChanging("StateCode");
				if (value == null)
				{
					SetAttributeValue("statecode", null);
				}
				else
				{
					SetAttributeValue("statecode", new OptionSetValue((int)value));
				}
				OnPropertyChanged("StateCode");
			}
		}

		/// <summary>
		/// 활동의 상태에 대한 설명입니다.
		/// </summary>
		[AttributeLogicalName("statuscode")]
		public OptionSetValue StatusCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("statuscode");
			}
			set
			{
				OnPropertyChanging("StatusCode");
				SetAttributeValue("statuscode", value);
				OnPropertyChanged("StatusCode");
			}
		}

		/// <summary>
		/// 활동과 연관된 주제입니다.
		/// </summary>
		[AttributeLogicalName("subject")]
		public string Subject
		{
			get
			{
				return GetAttributeValue<string>("subject");
			}
			set
			{
				OnPropertyChanging("Subject");
				SetAttributeValue("subject", value);
				OnPropertyChanged("Subject");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("timezoneruleversionnumber")]
		public int? TimeZoneRuleVersionNumber
		{
			get
			{
				return GetAttributeValue<int?>("timezoneruleversionnumber");
			}
			set
			{
				OnPropertyChanging("TimeZoneRuleVersionNumber");
				SetAttributeValue("timezoneruleversionnumber", value);
				OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}

		/// <summary>
		/// 활동 포인터와 연결된 통화의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("transactioncurrencyid")]
		public EntityReference TransactionCurrencyId
		{
			get
			{
				return GetAttributeValue<EntityReference>("transactioncurrencyid");
			}
			set
			{
				OnPropertyChanging("TransactionCurrencyId");
				SetAttributeValue("transactioncurrencyid", value);
				OnPropertyChanged("TransactionCurrencyId");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("traversedpath")]
		public string TraversedPath
		{
			get
			{
				return GetAttributeValue<string>("traversedpath");
			}
			set
			{
				OnPropertyChanging("TraversedPath");
				SetAttributeValue("traversedpath", value);
				OnPropertyChanged("TraversedPath");
			}
		}

		/// <summary>
		/// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
		/// </summary>
		[AttributeLogicalName("utcconversiontimezonecode")]
		public int? UTCConversionTimeZoneCode
		{
			get
			{
				return GetAttributeValue<int?>("utcconversiontimezonecode");
			}
			set
			{
				OnPropertyChanging("UTCConversionTimeZoneCode");
				SetAttributeValue("utcconversiontimezonecode", value);
				OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}

		/// <summary>
		/// 활동의 버전 번호입니다.
		/// </summary>
		[AttributeLogicalName("versionnumber")]
		public long? VersionNumber
		{
			get
			{
				return GetAttributeValue<long?>("versionnumber");
			}
		}

		#endregion Field
	}

	/// <summary>
	/// 활동과 연관된 사람 또는 그룹입니다. 한 활동에 여러 활동 당사자가 있을 수 있습니다.
	/// </summary>
	[System.Runtime.Serialization.DataContract()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalName("activityparty")]
	[System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "8.2.1.8676")]
	public partial class ActivityParty : Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		#region Field

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public ActivityParty() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "activityparty";

		public const int EntityTypeCode = 135;

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

		/// <summary>
		/// 활동 당사자와 연관된 활동의 고유 식별자입니다. "당사자"는 활동과 연관된 사람입니다.
		/// </summary>
		[AttributeLogicalName("activityid")]
		public EntityReference ActivityId
		{
			get
			{
				return GetAttributeValue<EntityReference>("activityid");
			}
			set
			{
				OnPropertyChanging("ActivityId");
				SetAttributeValue("activityid", value);
				OnPropertyChanged("ActivityId");
			}
		}

		/// <summary>
		/// 활동 당사자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("activitypartyid")]
		public Guid? ActivityPartyId
		{
			get
			{
				return GetAttributeValue<Guid?>("activitypartyid");
			}
			set
			{
				OnPropertyChanging("ActivityPartyId");
				SetAttributeValue("activitypartyid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = Guid.Empty;
				}
				OnPropertyChanged("ActivityPartyId");
			}
		}

		[AttributeLogicalName("activitypartyid")]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				ActivityPartyId = value;
			}
		}

		/// <summary>
		/// 전자 메일이 배달되며 대상 엔터티와 연관된 전자 메일 주소입니다.
		/// </summary>
		[AttributeLogicalName("addressused")]
		public string AddressUsed
		{
			get
			{
				return GetAttributeValue<string>("addressused");
			}
			set
			{
				OnPropertyChanging("AddressUsed");
				SetAttributeValue("addressused", value);
				OnPropertyChanged("AddressUsed");
			}
		}

		/// <summary>
		/// 관련 당사자의 전자 메일 주소 열 번호입니다.
		/// </summary>
		[AttributeLogicalName("addressusedemailcolumnnumber")]
		public int? AddressUsedEmailColumnNumber
		{
			get
			{
				return GetAttributeValue<int?>("addressusedemailcolumnnumber");
			}
		}

		/// <summary>
		/// 활동 당사자에게 전자 메일을 보낼 수 있도록 할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("donotemail")]
		public bool? DoNotEmail
		{
			get
			{
				return GetAttributeValue<bool?>("donotemail");
			}
		}

		/// <summary>
		/// 활동 당사자에게 팩스를 보낼 수 있도록 할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("donotfax")]
		public bool? DoNotFax
		{
			get
			{
				return GetAttributeValue<bool?>("donotfax");
			}
		}

		/// <summary>
		/// 잠재 고객에게 전화를 걸 수 있도록 할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("donotphone")]
		public bool? DoNotPhone
		{
			get
			{
				return GetAttributeValue<bool?>("donotphone");
			}
		}

		/// <summary>
		/// 잠재 고객에게 우편을 보낼 수 있도록 할지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("donotpostalmail")]
		public bool? DoNotPostalMail
		{
			get
			{
				return GetAttributeValue<bool?>("donotpostalmail");
			}
		}

		/// <summary>
		/// 리소스가 서비스 약속 활동에 사용하는 작업량입니다.
		/// </summary>
		[AttributeLogicalName("effort")]
		public double? Effort
		{
			get
			{
				return GetAttributeValue<double?>("effort");
			}
			set
			{
				OnPropertyChanging("Effort");
				SetAttributeValue("effort", value);
				OnPropertyChanged("Effort");
			}
		}

		/// <summary>
		/// 내부 전용입니다.
		/// </summary>
		[AttributeLogicalName("exchangeentryid")]
		public string ExchangeEntryId
		{
			get
			{
				return GetAttributeValue<string>("exchangeentryid");
			}
			set
			{
				OnPropertyChanging("ExchangeEntryId");
				SetAttributeValue("exchangeentryid", value);
				OnPropertyChanged("ExchangeEntryId");
			}
		}

		/// <summary>
		/// 되풀이 항목의 인스턴스 유형입니다.
		/// </summary>
		[AttributeLogicalName("instancetypecode")]
		public OptionSetValue InstanceTypeCode
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("instancetypecode");
			}
		}

		/// <summary>
		/// 기본 엔터티 레코드가 삭제되었는지 여부에 대한 정보입니다.
		/// </summary>
		[AttributeLogicalName("ispartydeleted")]
		public bool? IsPartyDeleted
		{
			get
			{
				return GetAttributeValue<bool?>("ispartydeleted");
			}
		}

		/// <summary>
		/// 활동 당사자를 담당하는 사용자 또는 팀의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get
			{
				return GetAttributeValue<EntityReference>("ownerid");
			}
		}

		/// <summary>
		/// 활동에 관련된 사람의 역할(예: 보낸 사람, 받는 사람, 참조, 숨은 참조, 필수 참석자, 선택 참석자, 이끌이, 관련 항목, 담당자)입니다.
		/// </summary>
		[AttributeLogicalName("participationtypemask")]
		public OptionSetValue ParticipationTypeMask
		{
			get
			{
				return GetAttributeValue<OptionSetValue>("participationtypemask");
			}
			set
			{
				OnPropertyChanging("ParticipationTypeMask");
				SetAttributeValue("participationtypemask", value);
				OnPropertyChanged("ParticipationTypeMask");
			}
		}

		/// <summary>
		/// 활동과 연관된 당사자의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("partyid")]
		public EntityReference PartyId
		{
			get
			{
				return GetAttributeValue<EntityReference>("partyid");
			}
			set
			{
				OnPropertyChanging("PartyId");
				SetAttributeValue("partyid", value);
				OnPropertyChanged("PartyId");
			}
		}

		/// <summary>
		/// 활동 당사자에 대한 리소스 사양의 고유 식별자입니다.
		/// </summary>
		[AttributeLogicalName("resourcespecid")]
		public EntityReference ResourceSpecId
		{
			get
			{
				return GetAttributeValue<EntityReference>("resourcespecid");
			}
			set
			{
				OnPropertyChanging("ResourceSpecId");
				SetAttributeValue("resourcespecid", value);
				OnPropertyChanged("ResourceSpecId");
			}
		}

		/// <summary>
		/// 활동의 예약된 종료 시간입니다.
		/// </summary>
		[AttributeLogicalName("scheduledend")]
		public DateTime? ScheduledEnd
		{
			get
			{
				return GetAttributeValue<DateTime?>("scheduledend");
			}
		}

		/// <summary>
		/// 활동의 예약된 시작 시간입니다.
		/// </summary>
		[AttributeLogicalName("scheduledstart")]
		public DateTime? ScheduledStart
		{
			get
			{
				return GetAttributeValue<DateTime?>("scheduledstart");
			}
		}

		/// <summary>
		///
		/// </summary>
		[AttributeLogicalName("versionnumber")]
		public long? VersionNumber
		{
			get
			{
				return GetAttributeValue<long?>("versionnumber");
			}
		}

		#endregion Field
	}
}