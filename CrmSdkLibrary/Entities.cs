using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xrm.Sdk.Query;

// How to Make AutoGenerate File  :
//  .\CrmSvcUtil.exe /url:https://orgname.api.crm5.dynamics.com/XRMServices/2011/Organization.svc /username:domain\crmadmin /password:pass /out:CRMSdkTypes.cs
namespace CrmSdkLibrary.Entities
{
    /// <summary>
    /// 고객 회사 또는 잠재 고객 회사를 나타내며, 비즈니스 거래에서 청구 대상이 되는 회사입니다.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("account")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class Account : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        #region Field
        [System.Runtime.Serialization.DataContractAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
        public enum AccountState
        {

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Active = 0,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Inactive = 1,
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Account() :
                base(EntityLogicalName)
        {
        }

        public const string EntityLogicalName = "account";

        public const int EntityTypeCode = 1;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChanged(string propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 고객 거래처가 표준 거래처인지, 아니면 선호 거래처인지를 나타내는 범주를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountcategorycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue AccountCategoryCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountcategorycode");
            }
            set
            {
                this.OnPropertyChanging("AccountCategoryCode");
                this.SetAttributeValue("accountcategorycode", value);
                this.OnPropertyChanged("AccountCategoryCode");
            }
        }

        /// <summary>
        /// 투자, 협력 수준, 영업 주기 길이 또는 기타 조건에 대한 예상 수익에 근거하여 고객 거래처의 잠재적인 가치를 나타내는 분류 코드를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountclassificationcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue AccountClassificationCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountclassificationcode");
            }
            set
            {
                this.OnPropertyChanging("AccountClassificationCode");
                this.SetAttributeValue("accountclassificationcode", value);
                this.OnPropertyChanged("AccountClassificationCode");
            }
        }

        /// <summary>
        /// 거래처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
        public System.Nullable<System.Guid> AccountId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("accountid");
            }
            set
            {
                this.OnPropertyChanging("AccountId");
                this.SetAttributeValue("accountid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("AccountId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.AccountId = value;
            }
        }

        /// <summary>
        /// 시스템 보기에서 거래처를 빠르게 검색 및 식별하기 위해 거래처의 ID 번호 또는 코드를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountnumber")]
        public string AccountNumber
        {
            get
            {
                return this.GetAttributeValue<string>("accountnumber");
            }
            set
            {
                this.OnPropertyChanging("AccountNumber");
                this.SetAttributeValue("accountnumber", value);
                this.OnPropertyChanged("AccountNumber");
            }
        }

        /// <summary>
        /// 고객 거래처의 가치를 나타내는 등급을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountratingcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue AccountRatingCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountratingcode");
            }
            set
            {
                this.OnPropertyChanging("AccountRatingCode");
                this.SetAttributeValue("accountratingcode", value);
                this.OnPropertyChanged("AccountRatingCode");
            }
        }

        /// <summary>
        /// 주소 1의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addressid")]
        public System.Nullable<System.Guid> Address1_AddressId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("address1_addressid");
            }
            set
            {
                this.OnPropertyChanging("Address1_AddressId");
                this.SetAttributeValue("address1_addressid", value);
                this.OnPropertyChanged("Address1_AddressId");
            }
        }

        /// <summary>
        /// 기본 주소 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addresstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_AddressTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_addresstypecode");
            }
            set
            {
                this.OnPropertyChanging("Address1_AddressTypeCode");
                this.SetAttributeValue("address1_addresstypecode", value);
                this.OnPropertyChanged("Address1_AddressTypeCode");
            }
        }

        /// <summary>
        /// 기본 주소의 구/군/시를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_city")]
        public string Address1_City
        {
            get
            {
                return this.GetAttributeValue<string>("address1_city");
            }
            set
            {
                this.OnPropertyChanging("Address1_City");
                this.SetAttributeValue("address1_city", value);
                this.OnPropertyChanged("Address1_City");
            }
        }

        /// <summary>
        /// 전체 기본 주소를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_composite")]
        public string Address1_Composite
        {
            get
            {
                return this.GetAttributeValue<string>("address1_composite");
            }
        }

        /// <summary>
        /// 기본 주소의 국가 또는 지역을 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_country")]
        public string Address1_Country
        {
            get
            {
                return this.GetAttributeValue<string>("address1_country");
            }
            set
            {
                this.OnPropertyChanging("Address1_Country");
                this.SetAttributeValue("address1_country", value);
                this.OnPropertyChanged("Address1_Country");
            }
        }

        /// <summary>
        /// 기본 주소의 군을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_county")]
        public string Address1_County
        {
            get
            {
                return this.GetAttributeValue<string>("address1_county");
            }
            set
            {
                this.OnPropertyChanging("Address1_County");
                this.SetAttributeValue("address1_county", value);
                this.OnPropertyChanged("Address1_County");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_fax")]
        public string Address1_Fax
        {
            get
            {
                return this.GetAttributeValue<string>("address1_fax");
            }
            set
            {
                this.OnPropertyChanging("Address1_Fax");
                this.SetAttributeValue("address1_fax", value);
                this.OnPropertyChanged("Address1_Fax");
            }
        }

        /// <summary>
        /// 운송 주문이 제대로 처리되도록 기본 주소의 운송료 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_freighttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_FreightTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_freighttermscode");
            }
            set
            {
                this.OnPropertyChanging("Address1_FreightTermsCode");
                this.SetAttributeValue("address1_freighttermscode", value);
                this.OnPropertyChanged("Address1_FreightTermsCode");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 위도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_latitude")]
        public System.Nullable<double> Address1_Latitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address1_latitude");
            }
            set
            {
                this.OnPropertyChanging("Address1_Latitude");
                this.SetAttributeValue("address1_latitude", value);
                this.OnPropertyChanged("Address1_Latitude");
            }
        }

        /// <summary>
        /// 기본 주소의 첫 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line1")]
        public string Address1_Line1
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line1");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line1");
                this.SetAttributeValue("address1_line1", value);
                this.OnPropertyChanged("Address1_Line1");
            }
        }

        /// <summary>
        /// 기본 주소의 두 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line2")]
        public string Address1_Line2
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line2");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line2");
                this.SetAttributeValue("address1_line2", value);
                this.OnPropertyChanged("Address1_Line2");
            }
        }

        /// <summary>
        /// 기본 주소의 세 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line3")]
        public string Address1_Line3
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line3");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line3");
                this.SetAttributeValue("address1_line3", value);
                this.OnPropertyChanged("Address1_Line3");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 경도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_longitude")]
        public System.Nullable<double> Address1_Longitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address1_longitude");
            }
            set
            {
                this.OnPropertyChanging("Address1_Longitude");
                this.SetAttributeValue("address1_longitude", value);
                this.OnPropertyChanged("Address1_Longitude");
            }
        }

        /// <summary>
        /// 기본 주소를 설명하는 이름을 입력합니다(예: 본사).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_name")]
        public string Address1_Name
        {
            get
            {
                return this.GetAttributeValue<string>("address1_name");
            }
            set
            {
                this.OnPropertyChanging("Address1_Name");
                this.SetAttributeValue("address1_name", value);
                this.OnPropertyChanged("Address1_Name");
            }
        }

        /// <summary>
        /// 기본 주소의 우편 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postalcode")]
        public string Address1_PostalCode
        {
            get
            {
                return this.GetAttributeValue<string>("address1_postalcode");
            }
            set
            {
                this.OnPropertyChanging("Address1_PostalCode");
                this.SetAttributeValue("address1_postalcode", value);
                this.OnPropertyChanged("Address1_PostalCode");
            }
        }

        /// <summary>
        /// 기본 주소의 사서함 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postofficebox")]
        public string Address1_PostOfficeBox
        {
            get
            {
                return this.GetAttributeValue<string>("address1_postofficebox");
            }
            set
            {
                this.OnPropertyChanging("Address1_PostOfficeBox");
                this.SetAttributeValue("address1_postofficebox", value);
                this.OnPropertyChanged("Address1_PostOfficeBox");
            }
        }

        /// <summary>
        /// 거래처의 기본 주소에 기본 연락처 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_primarycontactname")]
        public string Address1_PrimaryContactName
        {
            get
            {
                return this.GetAttributeValue<string>("address1_primarycontactname");
            }
            set
            {
                this.OnPropertyChanging("Address1_PrimaryContactName");
                this.SetAttributeValue("address1_primarycontactname", value);
                this.OnPropertyChanged("Address1_PrimaryContactName");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("Address1_ShippingMethodCode");
                this.SetAttributeValue("address1_shippingmethodcode", value);
                this.OnPropertyChanged("Address1_ShippingMethodCode");
            }
        }

        /// <summary>
        /// 기본 주소의 시/도를 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_stateorprovince")]
        public string Address1_StateOrProvince
        {
            get
            {
                return this.GetAttributeValue<string>("address1_stateorprovince");
            }
            set
            {
                this.OnPropertyChanging("Address1_StateOrProvince");
                this.SetAttributeValue("address1_stateorprovince", value);
                this.OnPropertyChanged("Address1_StateOrProvince");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone1")]
        public string Address1_Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone1");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone1");
                this.SetAttributeValue("address1_telephone1", value);
                this.OnPropertyChanged("Address1_Telephone1");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone2")]
        public string Address1_Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone2");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone2");
                this.SetAttributeValue("address1_telephone2", value);
                this.OnPropertyChanged("Address1_Telephone2");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone3")]
        public string Address1_Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone3");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone3");
                this.SetAttributeValue("address1_telephone3", value);
                this.OnPropertyChanged("Address1_Telephone3");
            }
        }

        /// <summary>
        /// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 기본 주소의 UPS 영역을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_upszone")]
        public string Address1_UPSZone
        {
            get
            {
                return this.GetAttributeValue<string>("address1_upszone");
            }
            set
            {
                this.OnPropertyChanging("Address1_UPSZone");
                this.SetAttributeValue("address1_upszone", value);
                this.OnPropertyChanged("Address1_UPSZone");
            }
        }

        /// <summary>
        /// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_utcoffset")]
        public System.Nullable<int> Address1_UTCOffset
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("address1_utcoffset");
            }
            set
            {
                this.OnPropertyChanging("Address1_UTCOffset");
                this.SetAttributeValue("address1_utcoffset", value);
                this.OnPropertyChanged("Address1_UTCOffset");
            }
        }

        /// <summary>
        /// 주소 2의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addressid")]
        public System.Nullable<System.Guid> Address2_AddressId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("address2_addressid");
            }
            set
            {
                this.OnPropertyChanging("Address2_AddressId");
                this.SetAttributeValue("address2_addressid", value);
                this.OnPropertyChanged("Address2_AddressId");
            }
        }

        /// <summary>
        /// 보조 주소 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addresstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_AddressTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_addresstypecode");
            }
            set
            {
                this.OnPropertyChanging("Address2_AddressTypeCode");
                this.SetAttributeValue("address2_addresstypecode", value);
                this.OnPropertyChanged("Address2_AddressTypeCode");
            }
        }

        /// <summary>
        /// 보조 주소의 구/군/시를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_city")]
        public string Address2_City
        {
            get
            {
                return this.GetAttributeValue<string>("address2_city");
            }
            set
            {
                this.OnPropertyChanging("Address2_City");
                this.SetAttributeValue("address2_city", value);
                this.OnPropertyChanged("Address2_City");
            }
        }

        /// <summary>
        /// 전체 보조 주소를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_composite")]
        public string Address2_Composite
        {
            get
            {
                return this.GetAttributeValue<string>("address2_composite");
            }
        }

        /// <summary>
        /// 보조 주소의 국가 또는 지역을 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_country")]
        public string Address2_Country
        {
            get
            {
                return this.GetAttributeValue<string>("address2_country");
            }
            set
            {
                this.OnPropertyChanging("Address2_Country");
                this.SetAttributeValue("address2_country", value);
                this.OnPropertyChanged("Address2_Country");
            }
        }

        /// <summary>
        /// 보조 주소의 군을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_county")]
        public string Address2_County
        {
            get
            {
                return this.GetAttributeValue<string>("address2_county");
            }
            set
            {
                this.OnPropertyChanging("Address2_County");
                this.SetAttributeValue("address2_county", value);
                this.OnPropertyChanged("Address2_County");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_fax")]
        public string Address2_Fax
        {
            get
            {
                return this.GetAttributeValue<string>("address2_fax");
            }
            set
            {
                this.OnPropertyChanging("Address2_Fax");
                this.SetAttributeValue("address2_fax", value);
                this.OnPropertyChanged("Address2_Fax");
            }
        }

        /// <summary>
        /// 운송 주문이 제대로 처리되도록 보조 주소의 운송료 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_freighttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_FreightTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_freighttermscode");
            }
            set
            {
                this.OnPropertyChanging("Address2_FreightTermsCode");
                this.SetAttributeValue("address2_freighttermscode", value);
                this.OnPropertyChanged("Address2_FreightTermsCode");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 위도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_latitude")]
        public System.Nullable<double> Address2_Latitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address2_latitude");
            }
            set
            {
                this.OnPropertyChanging("Address2_Latitude");
                this.SetAttributeValue("address2_latitude", value);
                this.OnPropertyChanged("Address2_Latitude");
            }
        }

        /// <summary>
        /// 보조 주소의 첫 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line1")]
        public string Address2_Line1
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line1");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line1");
                this.SetAttributeValue("address2_line1", value);
                this.OnPropertyChanged("Address2_Line1");
            }
        }

        /// <summary>
        /// 보조 주소의 두 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line2")]
        public string Address2_Line2
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line2");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line2");
                this.SetAttributeValue("address2_line2", value);
                this.OnPropertyChanged("Address2_Line2");
            }
        }

        /// <summary>
        /// 보조 주소의 세 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line3")]
        public string Address2_Line3
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line3");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line3");
                this.SetAttributeValue("address2_line3", value);
                this.OnPropertyChanged("Address2_Line3");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 경도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_longitude")]
        public System.Nullable<double> Address2_Longitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address2_longitude");
            }
            set
            {
                this.OnPropertyChanging("Address2_Longitude");
                this.SetAttributeValue("address2_longitude", value);
                this.OnPropertyChanged("Address2_Longitude");
            }
        }

        /// <summary>
        /// 보조 주소를 설명하는 이름을 입력합니다(예: 본사).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_name")]
        public string Address2_Name
        {
            get
            {
                return this.GetAttributeValue<string>("address2_name");
            }
            set
            {
                this.OnPropertyChanging("Address2_Name");
                this.SetAttributeValue("address2_name", value);
                this.OnPropertyChanged("Address2_Name");
            }
        }

        /// <summary>
        /// 보조 주소의 우편 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postalcode")]
        public string Address2_PostalCode
        {
            get
            {
                return this.GetAttributeValue<string>("address2_postalcode");
            }
            set
            {
                this.OnPropertyChanging("Address2_PostalCode");
                this.SetAttributeValue("address2_postalcode", value);
                this.OnPropertyChanged("Address2_PostalCode");
            }
        }

        /// <summary>
        /// 보조 주소의 사서함 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postofficebox")]
        public string Address2_PostOfficeBox
        {
            get
            {
                return this.GetAttributeValue<string>("address2_postofficebox");
            }
            set
            {
                this.OnPropertyChanging("Address2_PostOfficeBox");
                this.SetAttributeValue("address2_postofficebox", value);
                this.OnPropertyChanged("Address2_PostOfficeBox");
            }
        }

        /// <summary>
        /// 거래처의 보조 주소에 기본 연락처 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_primarycontactname")]
        public string Address2_PrimaryContactName
        {
            get
            {
                return this.GetAttributeValue<string>("address2_primarycontactname");
            }
            set
            {
                this.OnPropertyChanging("Address2_PrimaryContactName");
                this.SetAttributeValue("address2_primarycontactname", value);
                this.OnPropertyChanged("Address2_PrimaryContactName");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("Address2_ShippingMethodCode");
                this.SetAttributeValue("address2_shippingmethodcode", value);
                this.OnPropertyChanged("Address2_ShippingMethodCode");
            }
        }

        /// <summary>
        /// 보조 주소의 시/도를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_stateorprovince")]
        public string Address2_StateOrProvince
        {
            get
            {
                return this.GetAttributeValue<string>("address2_stateorprovince");
            }
            set
            {
                this.OnPropertyChanging("Address2_StateOrProvince");
                this.SetAttributeValue("address2_stateorprovince", value);
                this.OnPropertyChanged("Address2_StateOrProvince");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone1")]
        public string Address2_Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone1");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone1");
                this.SetAttributeValue("address2_telephone1", value);
                this.OnPropertyChanged("Address2_Telephone1");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone2")]
        public string Address2_Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone2");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone2");
                this.SetAttributeValue("address2_telephone2", value);
                this.OnPropertyChanged("Address2_Telephone2");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone3")]
        public string Address2_Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone3");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone3");
                this.SetAttributeValue("address2_telephone3", value);
                this.OnPropertyChanged("Address2_Telephone3");
            }
        }

        /// <summary>
        /// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 보조 주소의 UPS 영역을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_upszone")]
        public string Address2_UPSZone
        {
            get
            {
                return this.GetAttributeValue<string>("address2_upszone");
            }
            set
            {
                this.OnPropertyChanging("Address2_UPSZone");
                this.SetAttributeValue("address2_upszone", value);
                this.OnPropertyChanged("Address2_UPSZone");
            }
        }

        /// <summary>
        /// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_utcoffset")]
        public System.Nullable<int> Address2_UTCOffset
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("address2_utcoffset");
            }
            set
            {
                this.OnPropertyChanging("Address2_UTCOffset");
                this.SetAttributeValue("address2_utcoffset", value);
                this.OnPropertyChanged("Address2_UTCOffset");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging30")]
        public Microsoft.Xrm.Sdk.Money Aging30
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging30");
            }
        }

        /// <summary>
        /// 30일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging30_base")]
        public Microsoft.Xrm.Sdk.Money Aging30_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging30_base");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging60")]
        public Microsoft.Xrm.Sdk.Money Aging60
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging60");
            }
        }

        /// <summary>
        /// 60일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging60_base")]
        public Microsoft.Xrm.Sdk.Money Aging60_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging60_base");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging90")]
        public Microsoft.Xrm.Sdk.Money Aging90
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging90");
            }
        }

        /// <summary>
        /// 90일 유예 기간 필드에 해당하는 기본 통화 환산 금액입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging90_base")]
        public Microsoft.Xrm.Sdk.Money Aging90_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging90_base");
            }
        }

        /// <summary>
        /// 계약 또는 보고용으로 거래처의 법적 명칭 또는 기타 비즈니스 종류를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businesstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue BusinessTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("businesstypecode");
            }
            set
            {
                this.OnPropertyChanging("BusinessTypeCode");
                this.SetAttributeValue("businesstypecode", value);
                this.OnPropertyChanged("BusinessTypeCode");
            }
        }

        /// <summary>
        /// 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// 레코드를 만든 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// 거래처의 신용 한도액을 입력합니다. 송장 및 회계 문제를 고객에게 보낼 때 유용한 참조가 됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditlimit")]
        public Microsoft.Xrm.Sdk.Money CreditLimit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("creditlimit");
            }
            set
            {
                this.OnPropertyChanging("CreditLimit");
                this.SetAttributeValue("creditlimit", value);
                this.OnPropertyChanged("CreditLimit");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 신용 한도액을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditlimit_base")]
        public Microsoft.Xrm.Sdk.Money CreditLimit_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("creditlimit_base");
            }
        }

        /// <summary>
        /// 거래처의 신용이 보류 중인지 여부를 선택합니다. 송장 및 회계 문제를 고객에게 보내는 동안 유용한 참조가 됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditonhold")]
        public System.Nullable<bool> CreditOnHold
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("creditonhold");
            }
            set
            {
                this.OnPropertyChanging("CreditOnHold");
                this.SetAttributeValue("creditonhold", value);
                this.OnPropertyChanged("CreditOnHold");
            }
        }

        /// <summary>
        /// 세분화 및 보고용으로 거래처의 크기 범주 또는 범위를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customersizecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CustomerSizeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customersizecode");
            }
            set
            {
                this.OnPropertyChanging("CustomerSizeCode");
                this.SetAttributeValue("customersizecode", value);
                this.OnPropertyChanged("CustomerSizeCode");
            }
        }

        /// <summary>
        /// 거래처 및 조직 간의 관계를 가장 잘 설명하는 범주를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customertypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CustomerTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customertypecode");
            }
            set
            {
                this.OnPropertyChanging("CustomerTypeCode");
                this.SetAttributeValue("customertypecode", value);
                this.OnPropertyChanged("CustomerTypeCode");
            }
        }

        /// <summary>
        /// 해당 고객에 대해 올바른 제품 가격이 영업 기회, 견적 및 주문에 적용되도록 거래처에 연결된 기본 가격표를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultpricelevelid")]
        public Microsoft.Xrm.Sdk.EntityReference DefaultPriceLevelId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("defaultpricelevelid");
            }
            set
            {
                this.OnPropertyChanging("DefaultPriceLevelId");
                this.SetAttributeValue("defaultpricelevelid", value);
                this.OnPropertyChanged("DefaultPriceLevelId");
            }
        }

        /// <summary>
        /// 거래처를 설명하는 추가 정보를 입력합니다(예: 회사 웹 사이트에서의 발췌).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// 캠페인을 통해 보내는 대량 전자 메일을 거래처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 목록에는 추가될 수 있지만 전자 메일에서는 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotbulkemail")]
        public System.Nullable<bool> DoNotBulkEMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotbulkemail");
            }
            set
            {
                this.OnPropertyChanging("DoNotBulkEMail");
                this.SetAttributeValue("donotbulkemail", value);
                this.OnPropertyChanged("DoNotBulkEMail");
            }
        }

        /// <summary>
        /// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 우편 메일을 거래처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 목록에는 추가될 수 있지만 우편 메일에서는 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotbulkpostalmail")]
        public System.Nullable<bool> DoNotBulkPostalMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotbulkpostalmail");
            }
            set
            {
                this.OnPropertyChanging("DoNotBulkPostalMail");
                this.SetAttributeValue("donotbulkpostalmail", value);
                this.OnPropertyChanged("DoNotBulkPostalMail");
            }
        }

        /// <summary>
        /// Microsoft Dynamics 365에서 보내는 다이렉트 전자 메일을 거래처에서 허용할지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotemail")]
        public System.Nullable<bool> DoNotEMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotemail");
            }
            set
            {
                this.OnPropertyChanging("DoNotEMail");
                this.SetAttributeValue("donotemail", value);
                this.OnPropertyChanged("DoNotEMail");
            }
        }

        /// <summary>
        /// 거래처에서 팩스를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 팩스 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotfax")]
        public System.Nullable<bool> DoNotFax
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotfax");
            }
            set
            {
                this.OnPropertyChanging("DoNotFax");
                this.SetAttributeValue("donotfax", value);
                this.OnPropertyChanged("DoNotFax");
            }
        }

        /// <summary>
        /// 거래처에서 전화 통화를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 전화 통화 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotphone")]
        public System.Nullable<bool> DoNotPhone
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotphone");
            }
            set
            {
                this.OnPropertyChanging("DoNotPhone");
                this.SetAttributeValue("donotphone", value);
                this.OnPropertyChanged("DoNotPhone");
            }
        }

        /// <summary>
        /// 거래처에서 다이렉트 메일을 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 거래처가 마케팅 캠페인으로 배포된 편지 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotpostalmail")]
        public System.Nullable<bool> DoNotPostalMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotpostalmail");
            }
            set
            {
                this.OnPropertyChanging("DoNotPostalMail");
                this.SetAttributeValue("donotpostalmail", value);
                this.OnPropertyChanged("DoNotPostalMail");
            }
        }

        /// <summary>
        /// 거래처에서 마케팅 자료(예: 브로슈어 또는 카탈로그)를 허용할지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotsendmm")]
        public System.Nullable<bool> DoNotSendMM
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotsendmm");
            }
            set
            {
                this.OnPropertyChanging("DoNotSendMM");
                this.SetAttributeValue("donotsendmm", value);
                this.OnPropertyChanged("DoNotSendMM");
            }
        }

        /// <summary>
        /// 거래처의 기본 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress1")]
        public string EMailAddress1
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress1");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress1");
                this.SetAttributeValue("emailaddress1", value);
                this.OnPropertyChanged("EMailAddress1");
            }
        }

        /// <summary>
        /// 거래처의 보조 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress2")]
        public string EMailAddress2
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress2");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress2");
                this.SetAttributeValue("emailaddress2", value);
                this.OnPropertyChanged("EMailAddress2");
            }
        }

        /// <summary>
        /// 거래처의 대체 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress3")]
        public string EMailAddress3
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress3");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress3");
                this.SetAttributeValue("emailaddress3", value);
                this.OnPropertyChanged("EMailAddress3");
            }
        }

        /// <summary>
        /// 레코드의 기본 이미지를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
        public byte[] EntityImage
        {
            get
            {
                return this.GetAttributeValue<byte[]>("entityimage");
            }
            set
            {
                this.OnPropertyChanging("EntityImage");
                this.SetAttributeValue("entityimage", value);
                this.OnPropertyChanged("EntityImage");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
        public System.Nullable<long> EntityImage_Timestamp
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
        public string EntityImage_URL
        {
            get
            {
                return this.GetAttributeValue<string>("entityimage_url");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
        public System.Nullable<System.Guid> EntityImageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
            }
        }

        /// <summary>
        /// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
        public System.Nullable<decimal> ExchangeRate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
            }
        }

        /// <summary>
        /// 거래처의 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fax")]
        public string Fax
        {
            get
            {
                return this.GetAttributeValue<string>("fax");
            }
            set
            {
                this.OnPropertyChanging("Fax");
                this.SetAttributeValue("fax", value);
                this.OnPropertyChanged("Fax");
            }
        }

        /// <summary>
        /// 거래처에 전송된 전자 메일에 대한 개봉, 첨부 파일 보기, 링크 클릭과 같은 전자 메일 활동을 팔로우하도록 허용할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followemail")]
        public System.Nullable<bool> FollowEmail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("followemail");
            }
            set
            {
                this.OnPropertyChanging("FollowEmail");
                this.SetAttributeValue("followemail", value);
                this.OnPropertyChanged("FollowEmail");
            }
        }

        /// <summary>
        /// 사용자가 데이터에 액세스하고 문서를 공유할 수 있도록 거래처의 FTP 사이트에 대한 URL을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ftpsiteurl")]
        public string FtpSiteURL
        {
            get
            {
                return this.GetAttributeValue<string>("ftpsiteurl");
            }
            set
            {
                this.OnPropertyChanging("FtpSiteURL");
                this.SetAttributeValue("ftpsiteurl", value);
                this.OnPropertyChanged("FtpSiteURL");
            }
        }

        /// <summary>
        /// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
        public System.Nullable<int> ImportSequenceNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
            }
            set
            {
                this.OnPropertyChanging("ImportSequenceNumber");
                this.SetAttributeValue("importsequencenumber", value);
                this.OnPropertyChanged("ImportSequenceNumber");
            }
        }

        /// <summary>
        /// 마케팅 세분화 및 인구 통계 분석에 사용할 거래처의 기본 산업을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("industrycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue IndustryCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("industrycode");
            }
            set
            {
                this.OnPropertyChanging("IndustryCode");
                this.SetAttributeValue("industrycode", value);
                this.OnPropertyChanged("IndustryCode");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_facebook")]
        public string int_Facebook
        {
            get
            {
                return this.GetAttributeValue<string>("int_facebook");
            }
            set
            {
                this.OnPropertyChanging("int_Facebook");
                this.SetAttributeValue("int_facebook", value);
                this.OnPropertyChanged("int_Facebook");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_twitter")]
        public string int_Twitter
        {
            get
            {
                return this.GetAttributeValue<string>("int_twitter");
            }
            set
            {
                this.OnPropertyChanging("int_Twitter");
                this.SetAttributeValue("int_twitter", value);
                this.OnPropertyChanged("int_Twitter");
            }
        }

        /// <summary>
        /// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
        public System.Nullable<System.DateTime> LastOnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
            }
            set
            {
                this.OnPropertyChanging("LastOnHoldTime");
                this.SetAttributeValue("lastonholdtime", value);
                this.OnPropertyChanged("LastOnHoldTime");
            }
        }

        /// <summary>
        /// 거래처가 마지막으로 마케팅 캠페인 및 퀵 캠페인에 포함된 날짜를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastusedincampaign")]
        public System.Nullable<System.DateTime> LastUsedInCampaign
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastusedincampaign");
            }
            set
            {
                this.OnPropertyChanging("LastUsedInCampaign");
                this.SetAttributeValue("lastusedincampaign", value);
                this.OnPropertyChanged("LastUsedInCampaign");
            }
        }

        /// <summary>
        /// 재무 성과 분석 지표로 사용되는 회사의 지분을 식별하는 거래처의 시가 총액을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("marketcap")]
        public Microsoft.Xrm.Sdk.Money MarketCap
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("marketcap");
            }
            set
            {
                this.OnPropertyChanging("MarketCap");
                this.SetAttributeValue("marketcap", value);
                this.OnPropertyChanged("MarketCap");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 시가 총액을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("marketcap_base")]
        public Microsoft.Xrm.Sdk.Money MarketCap_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("marketcap_base");
            }
        }

        /// <summary>
        /// 마케팅 전용인지 여부
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("marketingonly")]
        public System.Nullable<bool> MarketingOnly
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("marketingonly");
            }
            set
            {
                this.OnPropertyChanging("MarketingOnly");
                this.SetAttributeValue("marketingonly", value);
                this.OnPropertyChanged("MarketingOnly");
            }
        }

        /// <summary>
        /// 거래처가 병합된 마스터 거래처를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("masterid")]
        public Microsoft.Xrm.Sdk.EntityReference MasterId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("masterid");
            }
        }

        /// <summary>
        /// 거래처가 다른 거래처와 병합되었는지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("merged")]
        public System.Nullable<bool> Merged
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("merged");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// 레코드를 수정한 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// 청구에 사용되는 다른 계정에 대한 참조(청구 계정이 다른 경우에만 사용됨)
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_billingaccount")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_BillingAccount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_billingaccount");
            }
            set
            {
                this.OnPropertyChanging("msdyn_BillingAccount");
                this.SetAttributeValue("msdyn_billingaccount", value);
                this.OnPropertyChanged("msdyn_BillingAccount");
            }
        }

        /// <summary>
        /// 다른 시스템의 외부 계정 ID입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_externalaccountid")]
        public string msdyn_externalaccountid
        {
            get
            {
                return this.GetAttributeValue<string>("msdyn_externalaccountid");
            }
            set
            {
                this.OnPropertyChanging("msdyn_externalaccountid");
                this.SetAttributeValue("msdyn_externalaccountid", value);
                this.OnPropertyChanged("msdyn_externalaccountid");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_preferredresource")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_PreferredResource
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_preferredresource");
            }
            set
            {
                this.OnPropertyChanging("msdyn_PreferredResource");
                this.SetAttributeValue("msdyn_preferredresource", value);
                this.OnPropertyChanged("msdyn_PreferredResource");
            }
        }

        /// <summary>
        /// 기본 판매세 코드
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_salestaxcode")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_SalesTaxCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_salestaxcode");
            }
            set
            {
                this.OnPropertyChanging("msdyn_SalesTaxCode");
                this.SetAttributeValue("msdyn_salestaxcode", value);
                this.OnPropertyChanged("msdyn_SalesTaxCode");
            }
        }

        /// <summary>
        /// 이 거래처가 속한 서비스 지역입니다. 예약 및 회람을 최적화하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_serviceterritory")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_ServiceTerritory
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_serviceterritory");
            }
            set
            {
                this.OnPropertyChanging("msdyn_ServiceTerritory");
                this.SetAttributeValue("msdyn_serviceterritory", value);
                this.OnPropertyChanged("msdyn_ServiceTerritory");
            }
        }

        /// <summary>
        /// 거래처가 면세인지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_taxexempt")]
        public System.Nullable<bool> msdyn_TaxExempt
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("msdyn_taxexempt");
            }
            set
            {
                this.OnPropertyChanging("msdyn_TaxExempt");
                this.SetAttributeValue("msdyn_taxexempt", value);
                this.OnPropertyChanged("msdyn_TaxExempt");
            }
        }

        /// <summary>
        /// 정부의 세금 면제 번호를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_taxexemptnumber")]
        public string msdyn_TaxExemptNumber
        {
            get
            {
                return this.GetAttributeValue<string>("msdyn_taxexemptnumber");
            }
            set
            {
                this.OnPropertyChanging("msdyn_TaxExemptNumber");
                this.SetAttributeValue("msdyn_taxexemptnumber", value);
                this.OnPropertyChanged("msdyn_TaxExemptNumber");
            }
        }

        /// <summary>
        /// 작업 주문에 포함할 이동 요금을 입력합니다. 이 값에 이동 요금 유형을 곱합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_travelcharge")]
        public Microsoft.Xrm.Sdk.Money msdyn_TravelCharge
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("msdyn_travelcharge");
            }
            set
            {
                this.OnPropertyChanging("msdyn_TravelCharge");
                this.SetAttributeValue("msdyn_travelcharge", value);
                this.OnPropertyChanged("msdyn_TravelCharge");
            }
        }

        /// <summary>
        /// 기본 통화로 표시된 이동 요금 값입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_travelcharge_base")]
        public Microsoft.Xrm.Sdk.Money msdyn_travelcharge_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("msdyn_travelcharge_base");
            }
        }

        /// <summary>
        /// 이 거래처에 부과되는 이동 방법을 지정합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_travelchargetype")]
        public Microsoft.Xrm.Sdk.OptionSetValue msdyn_TravelChargeType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("msdyn_travelchargetype");
            }
            set
            {
                this.OnPropertyChanging("msdyn_TravelChargeType");
                this.SetAttributeValue("msdyn_travelchargetype", value);
                this.OnPropertyChanged("msdyn_TravelChargeType");
            }
        }

        /// <summary>
        /// 새 작업 주문에 표시할 기본 지침을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_workorderinstructions")]
        public string msdyn_WorkOrderInstructions
        {
            get
            {
                return this.GetAttributeValue<string>("msdyn_workorderinstructions");
            }
            set
            {
                this.OnPropertyChanging("msdyn_WorkOrderInstructions");
                this.SetAttributeValue("msdyn_workorderinstructions", value);
                this.OnPropertyChanged("msdyn_WorkOrderInstructions");
            }
        }

        /// <summary>
        /// 회사 또는 사업체 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetAttributeValue<string>("name");
            }
            set
            {
                this.OnPropertyChanging("Name");
                this.SetAttributeValue("name", value);
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_dt_found")]
        public System.Nullable<System.DateTime> new_dt_found
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("new_dt_found");
            }
            set
            {
                this.OnPropertyChanging("new_dt_found");
                this.SetAttributeValue("new_dt_found", value);
                this.OnPropertyChanged("new_dt_found");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_p_customer_level")]
        public Microsoft.Xrm.Sdk.OptionSetValue new_p_customer_level
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("new_p_customer_level");
            }
            set
            {
                this.OnPropertyChanging("new_p_customer_level");
                this.SetAttributeValue("new_p_customer_level", value);
                this.OnPropertyChanged("new_p_customer_level");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_txt_bizno")]
        public string new_txt_bizno
        {
            get
            {
                return this.GetAttributeValue<string>("new_txt_bizno");
            }
            set
            {
                this.OnPropertyChanging("new_txt_bizno");
                this.SetAttributeValue("new_txt_bizno", value);
                this.OnPropertyChanged("new_txt_bizno");
            }
        }

        /// <summary>
        /// 마케팅 세분화 및 인구 통계 분석에 사용할 거래처에서 일하는 직원 수를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberofemployees")]
        public System.Nullable<int> NumberOfEmployees
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("numberofemployees");
            }
            set
            {
                this.OnPropertyChanging("NumberOfEmployees");
                this.SetAttributeValue("numberofemployees", value);
                this.OnPropertyChanged("NumberOfEmployees");
            }
        }

        /// <summary>
        /// 레코드가 보류 중인 시간을 분으로 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
        public System.Nullable<int> OnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
            }
        }

        /// <summary>
        /// 거래처 및 해당 하위 거래처에 대해 시작된 영업 기회 수입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opendeals")]
        public System.Nullable<int> OpenDeals
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("opendeals");
            }
        }

        /// <summary>
        /// 시작된 거래의 날짜 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opendeals_date")]
        public System.Nullable<System.DateTime> OpenDeals_Date
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("opendeals_date");
            }
        }

        /// <summary>
        /// 시작된 거래의 상태입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opendeals_state")]
        public System.Nullable<int> OpenDeals_State
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("opendeals_state");
            }
        }

        /// <summary>
        /// 거래처 및 해당 하위 거래처에 대해 시작된 매출의 합계입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("openrevenue")]
        public Microsoft.Xrm.Sdk.Money OpenRevenue
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("openrevenue");
            }
        }

        /// <summary>
        /// 거래처 및 해당 하위 거래처에 대해 시작된 매출의 합계입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("openrevenue_base")]
        public Microsoft.Xrm.Sdk.Money OpenRevenue_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("openrevenue_base");
            }
        }

        /// <summary>
        /// 시작된 매출의 날짜 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("openrevenue_date")]
        public System.Nullable<System.DateTime> OpenRevenue_Date
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("openrevenue_date");
            }
        }

        /// <summary>
        /// 시작된 매출의 상태입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("openrevenue_state")]
        public System.Nullable<int> OpenRevenue_State
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("openrevenue_state");
            }
        }

        /// <summary>
        /// 거래처가 Microsoft Dynamics 365의 잠재 고객을 변환하여 만들어진 경우 거래처가 만들어진 잠재 고객을 표시합니다. 이 값은 보고 및 분석용으로 거래처와 원래 잠재 고객의 데이터를 연결하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("originatingleadid")]
        public Microsoft.Xrm.Sdk.EntityReference OriginatingLeadId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("originatingleadid");
            }
            set
            {
                this.OnPropertyChanging("OriginatingLeadId");
                this.SetAttributeValue("originatingleadid", value);
                this.OnPropertyChanged("OriginatingLeadId");
            }
        }

        /// <summary>
        /// 레코드를 마이그레이션한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
        public System.Nullable<System.DateTime> OverriddenCreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
            }
            set
            {
                this.OnPropertyChanging("OverriddenCreatedOn");
                this.SetAttributeValue("overriddencreatedon", value);
                this.OnPropertyChanged("OverriddenCreatedOn");
            }
        }

        /// <summary>
        /// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
            set
            {
                this.OnPropertyChanging("OwnerId");
                this.SetAttributeValue("ownerid", value);
                this.OnPropertyChanged("OwnerId");
            }
        }

        /// <summary>
        /// 거래처의 소유권 형태 구조를 선택합니다(예: 상장 또는 비상장).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownershipcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue OwnershipCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("ownershipcode");
            }
            set
            {
                this.OnPropertyChanging("OwnershipCode");
                this.SetAttributeValue("ownershipcode", value);
                this.OnPropertyChanged("OwnershipCode");
            }
        }

        /// <summary>
        /// 레코드 담당자가 속한 사업부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
        public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
            }
        }

        /// <summary>
        /// 거래처를 담당하는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
        public Microsoft.Xrm.Sdk.EntityReference OwningTeam
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
            }
        }

        /// <summary>
        /// 거래처를 담당하는 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
        public Microsoft.Xrm.Sdk.EntityReference OwningUser
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
            }
        }

        /// <summary>
        /// 보고 및 분석 시 상위 및 하위 사업을 표시하도록 이 거래처에 연결된 상위 거래처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentaccountid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentAccountId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentaccountid");
            }
            set
            {
                this.OnPropertyChanging("ParentAccountId");
                this.SetAttributeValue("parentaccountid", value);
                this.OnPropertyChanged("ParentAccountId");
            }
        }

        /// <summary>
        /// 시스템 전용입니다. 레거시 Microsoft Dynamics CRM 3.0 워크플로 데이터입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("participatesinworkflow")]
        public System.Nullable<bool> ParticipatesInWorkflow
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("participatesinworkflow");
            }
            set
            {
                this.OnPropertyChanging("ParticipatesInWorkflow");
                this.SetAttributeValue("participatesinworkflow", value);
                this.OnPropertyChanged("ParticipatesInWorkflow");
            }
        }

        /// <summary>
        /// 고객이 총 금액을 지불해야 할 때 표시할 지불 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("paymenttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PaymentTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("paymenttermscode");
            }
            set
            {
                this.OnPropertyChanging("PaymentTermsCode");
                this.SetAttributeValue("paymenttermscode", value);
                this.OnPropertyChanged("PaymentTermsCode");
            }
        }

        /// <summary>
        /// 서비스 약속에 대해 선호하는 요일을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredappointmentdaycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredAppointmentDayCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredappointmentdaycode");
            }
            set
            {
                this.OnPropertyChanging("PreferredAppointmentDayCode");
                this.SetAttributeValue("preferredappointmentdaycode", value);
                this.OnPropertyChanged("PreferredAppointmentDayCode");
            }
        }

        /// <summary>
        /// 서비스 약속에 대해 선호하는 하루 중 시간을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredappointmenttimecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredAppointmentTimeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredappointmenttimecode");
            }
            set
            {
                this.OnPropertyChanging("PreferredAppointmentTimeCode");
                this.SetAttributeValue("preferredappointmenttimecode", value);
                this.OnPropertyChanged("PreferredAppointmentTimeCode");
            }
        }

        /// <summary>
        /// 선호하는 연락 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredcontactmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredContactMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredcontactmethodcode");
            }
            set
            {
                this.OnPropertyChanging("PreferredContactMethodCode");
                this.SetAttributeValue("preferredcontactmethodcode", value);
                this.OnPropertyChanged("PreferredContactMethodCode");
            }
        }

        /// <summary>
        /// 고객에 대한 서비스가 제대로 예약되도록 거래처의 선호 서비스 시설 또는 장비를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredequipmentid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredEquipmentId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredequipmentid");
            }
            set
            {
                this.OnPropertyChanging("PreferredEquipmentId");
                this.SetAttributeValue("preferredequipmentid", value);
                this.OnPropertyChanged("PreferredEquipmentId");
            }
        }

        /// <summary>
        /// 서비스 활동을 예약할 때 참조할 거래처의 선호 서비스를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredserviceid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredServiceId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredserviceid");
            }
            set
            {
                this.OnPropertyChanging("PreferredServiceId");
                this.SetAttributeValue("preferredserviceid", value);
                this.OnPropertyChanged("PreferredServiceId");
            }
        }

        /// <summary>
        /// 거래처에 대한 서비스 활동을 예약할 때 참조할 선호 서비스 담당자를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredsystemuserid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredSystemUserId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredsystemuserid");
            }
            set
            {
                this.OnPropertyChanging("PreferredSystemUserId");
                this.SetAttributeValue("preferredsystemuserid", value);
                this.OnPropertyChanged("PreferredSystemUserId");
            }
        }

        /// <summary>
        /// 연락처 정보에 대한 빠른 액세스를 제공하도록 거래처의 기본 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primarycontactid")]
        public Microsoft.Xrm.Sdk.EntityReference PrimaryContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("primarycontactid");
            }
            set
            {
                this.OnPropertyChanging("PrimaryContactId");
                this.SetAttributeValue("primarycontactid", value);
                this.OnPropertyChanged("PrimaryContactId");
            }
        }

        /// <summary>
        /// 계정의 기본 Satori ID
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primarysatoriid")]
        public string PrimarySatoriId
        {
            get
            {
                return this.GetAttributeValue<string>("primarysatoriid");
            }
            set
            {
                this.OnPropertyChanging("PrimarySatoriId");
                this.SetAttributeValue("primarysatoriid", value);
                this.OnPropertyChanged("PrimarySatoriId");
            }
        }

        /// <summary>
        /// 계정의 기본 Twitter ID
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primarytwitterid")]
        public string PrimaryTwitterId
        {
            get
            {
                return this.GetAttributeValue<string>("primarytwitterid");
            }
            set
            {
                this.OnPropertyChanging("PrimaryTwitterId");
                this.SetAttributeValue("primarytwitterid", value);
                this.OnPropertyChanged("PrimaryTwitterId");
            }
        }

        /// <summary>
        /// 프로세스의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
        public System.Nullable<System.Guid> ProcessId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
            }
            set
            {
                this.OnPropertyChanging("ProcessId");
                this.SetAttributeValue("processid", value);
                this.OnPropertyChanged("ProcessId");
            }
        }

        /// <summary>
        /// 재무 성과 분석 지표로 사용되는 거래처의 연간 수익을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("revenue")]
        public Microsoft.Xrm.Sdk.Money Revenue
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("revenue");
            }
            set
            {
                this.OnPropertyChanging("Revenue");
                this.SetAttributeValue("revenue", value);
                this.OnPropertyChanged("Revenue");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 연간 수익을 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("revenue_base")]
        public Microsoft.Xrm.Sdk.Money Revenue_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("revenue_base");
            }
        }

        /// <summary>
        /// 대중에게 허용되는 거래처의 주식 수를 입력합니다. 이 수는 재무 성과 분석 지표로 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sharesoutstanding")]
        public System.Nullable<int> SharesOutstanding
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("sharesoutstanding");
            }
            set
            {
                this.OnPropertyChanging("SharesOutstanding");
                this.SetAttributeValue("sharesoutstanding", value);
                this.OnPropertyChanged("SharesOutstanding");
            }
        }

        /// <summary>
        /// 선호 운송업체 또는 기타 배송 옵션을 지정하도록 거래처의 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("ShippingMethodCode");
                this.SetAttributeValue("shippingmethodcode", value);
                this.OnPropertyChanged("ShippingMethodCode");
            }
        }

        /// <summary>
        /// 마케팅 세분화 및 인구 통계 분석용으로 거래처의 기본 산업을 나타내는 SIC(Standard Industrial Classification) 코드를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sic")]
        public string SIC
        {
            get
            {
                return this.GetAttributeValue<string>("sic");
            }
            set
            {
                this.OnPropertyChanging("SIC");
                this.SetAttributeValue("sic", value);
                this.OnPropertyChanged("SIC");
            }
        }

        /// <summary>
        /// 거래처 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
            }
            set
            {
                this.OnPropertyChanging("SLAId");
                this.SetAttributeValue("slaid", value);
                this.OnPropertyChanged("SLAId");
            }
        }

        /// <summary>
        /// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
            }
        }

        /// <summary>
        /// 스테이지의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
        public System.Nullable<System.Guid> StageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
            }
            set
            {
                this.OnPropertyChanging("StageId");
                this.SetAttributeValue("stageid", value);
                this.OnPropertyChanged("StageId");
            }
        }

        /// <summary>
        /// 거래처가 활성인지, 아니면 비활성인지를 표시합니다. 비활성 거래처는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<AccountState> StateCode
        {
            get
            {
                Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if ((optionSet != null))
                {
                    return ((AccountState)(System.Enum.ToObject(typeof(AccountState), optionSet.Value)));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if ((value == null))
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// 거래처의 상태를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// 거래처에서 주식 및 회사의 재무 성과를 추적하기 위해 표시되는 증권 거래소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stockexchange")]
        public string StockExchange
        {
            get
            {
                return this.GetAttributeValue<string>("stockexchange");
            }
            set
            {
                this.OnPropertyChanging("StockExchange");
                this.SetAttributeValue("stockexchange", value);
                this.OnPropertyChanged("StockExchange");
            }
        }

        /// <summary>
        /// 이 거래처의 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone1")]
        public string Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("telephone1");
            }
            set
            {
                this.OnPropertyChanging("Telephone1");
                this.SetAttributeValue("telephone1", value);
                this.OnPropertyChanged("Telephone1");
            }
        }

        /// <summary>
        /// 이 거래처의 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone2")]
        public string Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("telephone2");
            }
            set
            {
                this.OnPropertyChanging("Telephone2");
                this.SetAttributeValue("telephone2", value);
                this.OnPropertyChanged("Telephone2");
            }
        }

        /// <summary>
        /// 이 거래처의 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone3")]
        public string Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("telephone3");
            }
            set
            {
                this.OnPropertyChanging("Telephone3");
                this.SetAttributeValue("telephone3", value);
                this.OnPropertyChanged("Telephone3");
            }
        }

        /// <summary>
        /// 세분화 및 분석에 사용할 거래처의 지역 또는 권역을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territorycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue TerritoryCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("territorycode");
            }
            set
            {
                this.OnPropertyChanging("TerritoryCode");
                this.SetAttributeValue("territorycode", value);
                this.OnPropertyChanged("TerritoryCode");
            }
        }

        /// <summary>
        /// 거래처가 올바른 담당자에게 할당되고 세분화 및 분석에 사용하도록 거래처의 영업 지역 또는 권역을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territoryid")]
        public Microsoft.Xrm.Sdk.EntityReference TerritoryId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("territoryid");
            }
            set
            {
                this.OnPropertyChanging("TerritoryId");
                this.SetAttributeValue("territoryid", value);
                this.OnPropertyChanged("TerritoryId");
            }
        }

        /// <summary>
        /// 회사의 재무 성과를 추적하기 위해 거래처에 대한 증권 거래소 종목 코드를 입력합니다. 이 필드에 입력한 코드를 클릭하면 MSN Money의 최신 거래 정보에 액세스할 수 있습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("tickersymbol")]
        public string TickerSymbol
        {
            get
            {
                return this.GetAttributeValue<string>("tickersymbol");
            }
            set
            {
                this.OnPropertyChanging("TickerSymbol");
                this.SetAttributeValue("tickersymbol", value);
                this.OnPropertyChanged("TickerSymbol");
            }
        }

        /// <summary>
        /// 거래처 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timespentbymeonemailandmeetings")]
        public string TimeSpentByMeOnEmailAndMeetings
        {
            get
            {
                return this.GetAttributeValue<string>("timespentbymeonemailandmeetings");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
        public System.Nullable<int> TimeZoneRuleVersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
            }
            set
            {
                this.OnPropertyChanging("TimeZoneRuleVersionNumber");
                this.SetAttributeValue("timezoneruleversionnumber", value);
                this.OnPropertyChanged("TimeZoneRuleVersionNumber");
            }
        }

        /// <summary>
        /// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
        public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
            }
            set
            {
                this.OnPropertyChanging("TransactionCurrencyId");
                this.SetAttributeValue("transactioncurrencyid", value);
                this.OnPropertyChanged("TransactionCurrencyId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
        public string TraversedPath
        {
            get
            {
                return this.GetAttributeValue<string>("traversedpath");
            }
            set
            {
                this.OnPropertyChanging("TraversedPath");
                this.SetAttributeValue("traversedpath", value);
                this.OnPropertyChanged("TraversedPath");
            }
        }

        /// <summary>
        /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
        public System.Nullable<int> UTCConversionTimeZoneCode
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
            }
            set
            {
                this.OnPropertyChanging("UTCConversionTimeZoneCode");
                this.SetAttributeValue("utcconversiontimezonecode", value);
                this.OnPropertyChanged("UTCConversionTimeZoneCode");
            }
        }

        /// <summary>
        /// 거래처의 버전 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }

        /// <summary>
        /// 회사 프로필에 대한 빠른 정보를 얻기 위해 거래처의 웹 사이트 URL을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("websiteurl")]
        public string WebSiteURL
        {
            get
            {
                return this.GetAttributeValue<string>("websiteurl");
            }
            set
            {
                this.OnPropertyChanging("WebSiteURL");
                this.SetAttributeValue("websiteurl", value);
                this.OnPropertyChanged("WebSiteURL");
            }
        }

        /// <summary>
        /// 일본어로 지정된 경우 이름이 전화 통화 및 기타 통신 시 올바르게 발음되도록 회사 이름의 표음식 철자를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yominame")]
        public string YomiName
        {
            get
            {
                return this.GetAttributeValue<string>("yominame");
            }
            set
            {
                this.OnPropertyChanging("YomiName");
                this.SetAttributeValue("yominame", value);
                this.OnPropertyChanged("YomiName");
            }
        }
        #endregion Field

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://community.dynamics.com/crm/b/misscrm360exploration/archive/2015/05/10/tips-crm-c-create-validated-parent-and-child-records-at-once-as-one-big-compound-using-related-entities"/>
        /// <param name="service"></param>
        /// <param name="name"></param>
        /// <param name="subject"></param>  
        /// <param name="contents"></param>
        public void CreateLetterRecordWithRelatedEntities(IOrganizationService service, string name, string subject, string contents)
        {
            try
            {
                //Define the account for which we will add letters
                //Account
                var entity = new Entity("account");
                entity["name"] = name;

                //This acts as a container for each letter we create, Note that we haven't
                //define the relationship between the letter and account yet.
                var entityCollection = new EntityCollection();
                var eLetter = new Entity("letter");
                eLetter["subject"] = string.Format(subject);

                //bind to the EntityCollection of the related records
                entityCollection.Entities.Add(eLetter);

                //Creates the reference between which relationship between Letter and
                //Account we would be like to use.
                var relationship = new Relationship("Account_Letters");

                //Adds the letters to the account under the specified relationship
                entity.RelatedEntities.Add(relationship, entityCollection);

                //Passes the Account (which contains the letters)
                service.Create(entity);
                //and guess, you only need 1 request for all records!!
            }
            catch (Exception e)
            {
                throw e;

            }

        }
    }

    /// <summary>
    /// 사업부와 관계가 있는 사람(예: 고객, 공급자, 동료)입니다.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("contact")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class Contact : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        #region Field
        [System.Runtime.Serialization.DataContractAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
        public enum ContactState
        {

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Active = 0,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Inactive = 1,
        }
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Contact() :
                base(EntityLogicalName)
        {
        }

        public const string EntityLogicalName = "contact";

        public const int EntityTypeCode = 2;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChanged(string propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 연락처와 연관된 거래처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
        public Microsoft.Xrm.Sdk.EntityReference AccountId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("accountid");
            }
        }

        /// <summary>
        /// 회사 또는 영업 프로세스에서 연락처의 역할을 선택합니다(예: 의사 결정자, 직원 또는 영향력 행사자).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountrolecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue AccountRoleCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountrolecode");
            }
            set
            {
                this.OnPropertyChanging("AccountRoleCode");
                this.SetAttributeValue("accountrolecode", value);
                this.OnPropertyChanged("AccountRoleCode");
            }
        }

        /// <summary>
        /// 주소 1의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addressid")]
        public System.Nullable<System.Guid> Address1_AddressId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("address1_addressid");
            }
            set
            {
                this.OnPropertyChanging("Address1_AddressId");
                this.SetAttributeValue("address1_addressid", value);
                this.OnPropertyChanged("Address1_AddressId");
            }
        }

        /// <summary>
        /// 기본 주소 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_addresstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_AddressTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_addresstypecode");
            }
            set
            {
                this.OnPropertyChanging("Address1_AddressTypeCode");
                this.SetAttributeValue("address1_addresstypecode", value);
                this.OnPropertyChanged("Address1_AddressTypeCode");
            }
        }

        /// <summary>
        /// 기본 주소의 구/군/시를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_city")]
        public string Address1_City
        {
            get
            {
                return this.GetAttributeValue<string>("address1_city");
            }
            set
            {
                this.OnPropertyChanging("Address1_City");
                this.SetAttributeValue("address1_city", value);
                this.OnPropertyChanged("Address1_City");
            }
        }

        /// <summary>
        /// 전체 기본 주소를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_composite")]
        public string Address1_Composite
        {
            get
            {
                return this.GetAttributeValue<string>("address1_composite");
            }
        }

        /// <summary>
        /// 기본 주소의 국가 또는 지역을 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_country")]
        public string Address1_Country
        {
            get
            {
                return this.GetAttributeValue<string>("address1_country");
            }
            set
            {
                this.OnPropertyChanging("Address1_Country");
                this.SetAttributeValue("address1_country", value);
                this.OnPropertyChanged("Address1_Country");
            }
        }

        /// <summary>
        /// 기본 주소의 군을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_county")]
        public string Address1_County
        {
            get
            {
                return this.GetAttributeValue<string>("address1_county");
            }
            set
            {
                this.OnPropertyChanging("Address1_County");
                this.SetAttributeValue("address1_county", value);
                this.OnPropertyChanged("Address1_County");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_fax")]
        public string Address1_Fax
        {
            get
            {
                return this.GetAttributeValue<string>("address1_fax");
            }
            set
            {
                this.OnPropertyChanging("Address1_Fax");
                this.SetAttributeValue("address1_fax", value);
                this.OnPropertyChanged("Address1_Fax");
            }
        }

        /// <summary>
        /// 운송 주문이 제대로 처리되도록 기본 주소의 운송료 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_freighttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_FreightTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_freighttermscode");
            }
            set
            {
                this.OnPropertyChanging("Address1_FreightTermsCode");
                this.SetAttributeValue("address1_freighttermscode", value);
                this.OnPropertyChanged("Address1_FreightTermsCode");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 위도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_latitude")]
        public System.Nullable<double> Address1_Latitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address1_latitude");
            }
            set
            {
                this.OnPropertyChanging("Address1_Latitude");
                this.SetAttributeValue("address1_latitude", value);
                this.OnPropertyChanged("Address1_Latitude");
            }
        }

        /// <summary>
        /// 기본 주소의 첫 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line1")]
        public string Address1_Line1
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line1");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line1");
                this.SetAttributeValue("address1_line1", value);
                this.OnPropertyChanged("Address1_Line1");
            }
        }

        /// <summary>
        /// 기본 주소의 두 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line2")]
        public string Address1_Line2
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line2");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line2");
                this.SetAttributeValue("address1_line2", value);
                this.OnPropertyChanged("Address1_Line2");
            }
        }

        /// <summary>
        /// 기본 주소의 세 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_line3")]
        public string Address1_Line3
        {
            get
            {
                return this.GetAttributeValue<string>("address1_line3");
            }
            set
            {
                this.OnPropertyChanging("Address1_Line3");
                this.SetAttributeValue("address1_line3", value);
                this.OnPropertyChanged("Address1_Line3");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 기본 주소의 경도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_longitude")]
        public System.Nullable<double> Address1_Longitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address1_longitude");
            }
            set
            {
                this.OnPropertyChanging("Address1_Longitude");
                this.SetAttributeValue("address1_longitude", value);
                this.OnPropertyChanged("Address1_Longitude");
            }
        }

        /// <summary>
        /// 기본 주소를 설명하는 이름을 입력합니다(예: 본사).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_name")]
        public string Address1_Name
        {
            get
            {
                return this.GetAttributeValue<string>("address1_name");
            }
            set
            {
                this.OnPropertyChanging("Address1_Name");
                this.SetAttributeValue("address1_name", value);
                this.OnPropertyChanged("Address1_Name");
            }
        }

        /// <summary>
        /// 기본 주소의 우편 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postalcode")]
        public string Address1_PostalCode
        {
            get
            {
                return this.GetAttributeValue<string>("address1_postalcode");
            }
            set
            {
                this.OnPropertyChanging("Address1_PostalCode");
                this.SetAttributeValue("address1_postalcode", value);
                this.OnPropertyChanged("Address1_PostalCode");
            }
        }

        /// <summary>
        /// 기본 주소의 사서함 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_postofficebox")]
        public string Address1_PostOfficeBox
        {
            get
            {
                return this.GetAttributeValue<string>("address1_postofficebox");
            }
            set
            {
                this.OnPropertyChanging("Address1_PostOfficeBox");
                this.SetAttributeValue("address1_postofficebox", value);
                this.OnPropertyChanged("Address1_PostOfficeBox");
            }
        }

        /// <summary>
        /// 거래처의 기본 주소에 기본 연락처 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_primarycontactname")]
        public string Address1_PrimaryContactName
        {
            get
            {
                return this.GetAttributeValue<string>("address1_primarycontactname");
            }
            set
            {
                this.OnPropertyChanging("Address1_PrimaryContactName");
                this.SetAttributeValue("address1_primarycontactname", value);
                this.OnPropertyChanged("Address1_PrimaryContactName");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address1_ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address1_shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("Address1_ShippingMethodCode");
                this.SetAttributeValue("address1_shippingmethodcode", value);
                this.OnPropertyChanged("Address1_ShippingMethodCode");
            }
        }

        /// <summary>
        /// 기본 주소의 시/도를 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_stateorprovince")]
        public string Address1_StateOrProvince
        {
            get
            {
                return this.GetAttributeValue<string>("address1_stateorprovince");
            }
            set
            {
                this.OnPropertyChanging("Address1_StateOrProvince");
                this.SetAttributeValue("address1_stateorprovince", value);
                this.OnPropertyChanged("Address1_StateOrProvince");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone1")]
        public string Address1_Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone1");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone1");
                this.SetAttributeValue("address1_telephone1", value);
                this.OnPropertyChanged("Address1_Telephone1");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone2")]
        public string Address1_Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone2");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone2");
                this.SetAttributeValue("address1_telephone2", value);
                this.OnPropertyChanged("Address1_Telephone2");
            }
        }

        /// <summary>
        /// 기본 주소와 연관된 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_telephone3")]
        public string Address1_Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("address1_telephone3");
            }
            set
            {
                this.OnPropertyChanging("Address1_Telephone3");
                this.SetAttributeValue("address1_telephone3", value);
                this.OnPropertyChanged("Address1_Telephone3");
            }
        }

        /// <summary>
        /// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 기본 주소의 UPS 영역을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_upszone")]
        public string Address1_UPSZone
        {
            get
            {
                return this.GetAttributeValue<string>("address1_upszone");
            }
            set
            {
                this.OnPropertyChanging("Address1_UPSZone");
                this.SetAttributeValue("address1_upszone", value);
                this.OnPropertyChanged("Address1_UPSZone");
            }
        }

        /// <summary>
        /// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address1_utcoffset")]
        public System.Nullable<int> Address1_UTCOffset
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("address1_utcoffset");
            }
            set
            {
                this.OnPropertyChanging("Address1_UTCOffset");
                this.SetAttributeValue("address1_utcoffset", value);
                this.OnPropertyChanged("Address1_UTCOffset");
            }
        }

        /// <summary>
        /// 주소 2의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addressid")]
        public System.Nullable<System.Guid> Address2_AddressId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("address2_addressid");
            }
            set
            {
                this.OnPropertyChanging("Address2_AddressId");
                this.SetAttributeValue("address2_addressid", value);
                this.OnPropertyChanged("Address2_AddressId");
            }
        }

        /// <summary>
        /// 보조 주소 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_addresstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_AddressTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_addresstypecode");
            }
            set
            {
                this.OnPropertyChanging("Address2_AddressTypeCode");
                this.SetAttributeValue("address2_addresstypecode", value);
                this.OnPropertyChanged("Address2_AddressTypeCode");
            }
        }

        /// <summary>
        /// 보조 주소의 구/군/시를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_city")]
        public string Address2_City
        {
            get
            {
                return this.GetAttributeValue<string>("address2_city");
            }
            set
            {
                this.OnPropertyChanging("Address2_City");
                this.SetAttributeValue("address2_city", value);
                this.OnPropertyChanged("Address2_City");
            }
        }

        /// <summary>
        /// 전체 보조 주소를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_composite")]
        public string Address2_Composite
        {
            get
            {
                return this.GetAttributeValue<string>("address2_composite");
            }
        }

        /// <summary>
        /// 보조 주소의 국가 또는 지역을 입력합니다
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_country")]
        public string Address2_Country
        {
            get
            {
                return this.GetAttributeValue<string>("address2_country");
            }
            set
            {
                this.OnPropertyChanging("Address2_Country");
                this.SetAttributeValue("address2_country", value);
                this.OnPropertyChanged("Address2_Country");
            }
        }

        /// <summary>
        /// 보조 주소의 군을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_county")]
        public string Address2_County
        {
            get
            {
                return this.GetAttributeValue<string>("address2_county");
            }
            set
            {
                this.OnPropertyChanging("Address2_County");
                this.SetAttributeValue("address2_county", value);
                this.OnPropertyChanged("Address2_County");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_fax")]
        public string Address2_Fax
        {
            get
            {
                return this.GetAttributeValue<string>("address2_fax");
            }
            set
            {
                this.OnPropertyChanging("Address2_Fax");
                this.SetAttributeValue("address2_fax", value);
                this.OnPropertyChanged("Address2_Fax");
            }
        }

        /// <summary>
        /// 운송 주문이 제대로 처리되도록 보조 주소의 운송료 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_freighttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_FreightTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_freighttermscode");
            }
            set
            {
                this.OnPropertyChanging("Address2_FreightTermsCode");
                this.SetAttributeValue("address2_freighttermscode", value);
                this.OnPropertyChanged("Address2_FreightTermsCode");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 위도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_latitude")]
        public System.Nullable<double> Address2_Latitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address2_latitude");
            }
            set
            {
                this.OnPropertyChanging("Address2_Latitude");
                this.SetAttributeValue("address2_latitude", value);
                this.OnPropertyChanged("Address2_Latitude");
            }
        }

        /// <summary>
        /// 보조 주소의 첫 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line1")]
        public string Address2_Line1
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line1");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line1");
                this.SetAttributeValue("address2_line1", value);
                this.OnPropertyChanged("Address2_Line1");
            }
        }

        /// <summary>
        /// 보조 주소의 두 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line2")]
        public string Address2_Line2
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line2");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line2");
                this.SetAttributeValue("address2_line2", value);
                this.OnPropertyChanged("Address2_Line2");
            }
        }

        /// <summary>
        /// 보조 주소의 세 번째 줄을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_line3")]
        public string Address2_Line3
        {
            get
            {
                return this.GetAttributeValue<string>("address2_line3");
            }
            set
            {
                this.OnPropertyChanging("Address2_Line3");
                this.SetAttributeValue("address2_line3", value);
                this.OnPropertyChanged("Address2_Line3");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 보조 주소의 경도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_longitude")]
        public System.Nullable<double> Address2_Longitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address2_longitude");
            }
            set
            {
                this.OnPropertyChanging("Address2_Longitude");
                this.SetAttributeValue("address2_longitude", value);
                this.OnPropertyChanged("Address2_Longitude");
            }
        }

        /// <summary>
        /// 보조 주소를 설명하는 이름을 입력합니다(예: 본사).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_name")]
        public string Address2_Name
        {
            get
            {
                return this.GetAttributeValue<string>("address2_name");
            }
            set
            {
                this.OnPropertyChanging("Address2_Name");
                this.SetAttributeValue("address2_name", value);
                this.OnPropertyChanged("Address2_Name");
            }
        }

        /// <summary>
        /// 보조 주소의 우편 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postalcode")]
        public string Address2_PostalCode
        {
            get
            {
                return this.GetAttributeValue<string>("address2_postalcode");
            }
            set
            {
                this.OnPropertyChanging("Address2_PostalCode");
                this.SetAttributeValue("address2_postalcode", value);
                this.OnPropertyChanged("Address2_PostalCode");
            }
        }

        /// <summary>
        /// 보조 주소의 사서함 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_postofficebox")]
        public string Address2_PostOfficeBox
        {
            get
            {
                return this.GetAttributeValue<string>("address2_postofficebox");
            }
            set
            {
                this.OnPropertyChanging("Address2_PostOfficeBox");
                this.SetAttributeValue("address2_postofficebox", value);
                this.OnPropertyChanged("Address2_PostOfficeBox");
            }
        }

        /// <summary>
        /// 거래처의 보조 주소에 기본 연락처 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_primarycontactname")]
        public string Address2_PrimaryContactName
        {
            get
            {
                return this.GetAttributeValue<string>("address2_primarycontactname");
            }
            set
            {
                this.OnPropertyChanging("Address2_PrimaryContactName");
                this.SetAttributeValue("address2_primarycontactname", value);
                this.OnPropertyChanged("Address2_PrimaryContactName");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address2_ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address2_shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("Address2_ShippingMethodCode");
                this.SetAttributeValue("address2_shippingmethodcode", value);
                this.OnPropertyChanged("Address2_ShippingMethodCode");
            }
        }

        /// <summary>
        /// 보조 주소의 시/도를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_stateorprovince")]
        public string Address2_StateOrProvince
        {
            get
            {
                return this.GetAttributeValue<string>("address2_stateorprovince");
            }
            set
            {
                this.OnPropertyChanging("Address2_StateOrProvince");
                this.SetAttributeValue("address2_stateorprovince", value);
                this.OnPropertyChanged("Address2_StateOrProvince");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone1")]
        public string Address2_Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone1");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone1");
                this.SetAttributeValue("address2_telephone1", value);
                this.OnPropertyChanged("Address2_Telephone1");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone2")]
        public string Address2_Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone2");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone2");
                this.SetAttributeValue("address2_telephone2", value);
                this.OnPropertyChanged("Address2_Telephone2");
            }
        }

        /// <summary>
        /// 보조 주소와 연관된 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_telephone3")]
        public string Address2_Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("address2_telephone3");
            }
            set
            {
                this.OnPropertyChanging("Address2_Telephone3");
                this.SetAttributeValue("address2_telephone3", value);
                this.OnPropertyChanged("Address2_Telephone3");
            }
        }

        /// <summary>
        /// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 보조 주소의 UPS 영역을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_upszone")]
        public string Address2_UPSZone
        {
            get
            {
                return this.GetAttributeValue<string>("address2_upszone");
            }
            set
            {
                this.OnPropertyChanging("Address2_UPSZone");
                this.SetAttributeValue("address2_upszone", value);
                this.OnPropertyChanged("Address2_UPSZone");
            }
        }

        /// <summary>
        /// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address2_utcoffset")]
        public System.Nullable<int> Address2_UTCOffset
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("address2_utcoffset");
            }
            set
            {
                this.OnPropertyChanging("Address2_UTCOffset");
                this.SetAttributeValue("address2_utcoffset", value);
                this.OnPropertyChanged("Address2_UTCOffset");
            }
        }

        /// <summary>
        /// 주소 3의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_addressid")]
        public System.Nullable<System.Guid> Address3_AddressId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("address3_addressid");
            }
            set
            {
                this.OnPropertyChanging("Address3_AddressId");
                this.SetAttributeValue("address3_addressid", value);
                this.OnPropertyChanged("Address3_AddressId");
            }
        }

        /// <summary>
        /// 세 번째 주소 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_addresstypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address3_AddressTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address3_addresstypecode");
            }
            set
            {
                this.OnPropertyChanging("Address3_AddressTypeCode");
                this.SetAttributeValue("address3_addresstypecode", value);
                this.OnPropertyChanged("Address3_AddressTypeCode");
            }
        }

        /// <summary>
        /// 세 번째 주소의 구/군/시를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_city")]
        public string Address3_City
        {
            get
            {
                return this.GetAttributeValue<string>("address3_city");
            }
            set
            {
                this.OnPropertyChanging("Address3_City");
                this.SetAttributeValue("address3_city", value);
                this.OnPropertyChanged("Address3_City");
            }
        }

        /// <summary>
        /// 전체 세 번째 주소를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_composite")]
        public string Address3_Composite
        {
            get
            {
                return this.GetAttributeValue<string>("address3_composite");
            }
        }

        /// <summary>
        /// 세 번째 주소의 국가 또는 지역입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_country")]
        public string Address3_Country
        {
            get
            {
                return this.GetAttributeValue<string>("address3_country");
            }
            set
            {
                this.OnPropertyChanging("Address3_Country");
                this.SetAttributeValue("address3_country", value);
                this.OnPropertyChanged("Address3_Country");
            }
        }

        /// <summary>
        /// 세 번째 주소의 군을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_county")]
        public string Address3_County
        {
            get
            {
                return this.GetAttributeValue<string>("address3_county");
            }
            set
            {
                this.OnPropertyChanging("Address3_County");
                this.SetAttributeValue("address3_county", value);
                this.OnPropertyChanged("Address3_County");
            }
        }

        /// <summary>
        /// 세 번째 주소에 연결된 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_fax")]
        public string Address3_Fax
        {
            get
            {
                return this.GetAttributeValue<string>("address3_fax");
            }
            set
            {
                this.OnPropertyChanging("Address3_Fax");
                this.SetAttributeValue("address3_fax", value);
                this.OnPropertyChanged("Address3_Fax");
            }
        }

        /// <summary>
        /// 운송 주문이 제대로 처리되도록 세 번째 주소의 운송료 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_freighttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address3_FreightTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address3_freighttermscode");
            }
            set
            {
                this.OnPropertyChanging("Address3_FreightTermsCode");
                this.SetAttributeValue("address3_freighttermscode", value);
                this.OnPropertyChanged("Address3_FreightTermsCode");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 세 번째 주소의 위도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_latitude")]
        public System.Nullable<double> Address3_Latitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address3_latitude");
            }
            set
            {
                this.OnPropertyChanging("Address3_Latitude");
                this.SetAttributeValue("address3_latitude", value);
                this.OnPropertyChanged("Address3_Latitude");
            }
        }

        /// <summary>
        /// 세 번째 주소의 첫 번째 줄입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_line1")]
        public string Address3_Line1
        {
            get
            {
                return this.GetAttributeValue<string>("address3_line1");
            }
            set
            {
                this.OnPropertyChanging("Address3_Line1");
                this.SetAttributeValue("address3_line1", value);
                this.OnPropertyChanged("Address3_Line1");
            }
        }

        /// <summary>
        /// 세 번째 주소의 두 번째 줄입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_line2")]
        public string Address3_Line2
        {
            get
            {
                return this.GetAttributeValue<string>("address3_line2");
            }
            set
            {
                this.OnPropertyChanging("Address3_Line2");
                this.SetAttributeValue("address3_line2", value);
                this.OnPropertyChanged("Address3_Line2");
            }
        }

        /// <summary>
        /// 세 번째 주소의 세 번째 줄입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_line3")]
        public string Address3_Line3
        {
            get
            {
                return this.GetAttributeValue<string>("address3_line3");
            }
            set
            {
                this.OnPropertyChanging("Address3_Line3");
                this.SetAttributeValue("address3_line3", value);
                this.OnPropertyChanged("Address3_Line3");
            }
        }

        /// <summary>
        /// 매핑 및 기타 응용 프로그램에 사용하도록 세 번째 주소의 경도 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_longitude")]
        public System.Nullable<double> Address3_Longitude
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("address3_longitude");
            }
            set
            {
                this.OnPropertyChanging("Address3_Longitude");
                this.SetAttributeValue("address3_longitude", value);
                this.OnPropertyChanged("Address3_Longitude");
            }
        }

        /// <summary>
        /// 세 번째 주소를 설명하는 이름을 입력합니다(예: 본사).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_name")]
        public string Address3_Name
        {
            get
            {
                return this.GetAttributeValue<string>("address3_name");
            }
            set
            {
                this.OnPropertyChanging("Address3_Name");
                this.SetAttributeValue("address3_name", value);
                this.OnPropertyChanged("Address3_Name");
            }
        }

        /// <summary>
        /// 세 번째 주소의 우편 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_postalcode")]
        public string Address3_PostalCode
        {
            get
            {
                return this.GetAttributeValue<string>("address3_postalcode");
            }
            set
            {
                this.OnPropertyChanging("Address3_PostalCode");
                this.SetAttributeValue("address3_postalcode", value);
                this.OnPropertyChanged("Address3_PostalCode");
            }
        }

        /// <summary>
        /// 세 번째 주소의 사서함 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_postofficebox")]
        public string Address3_PostOfficeBox
        {
            get
            {
                return this.GetAttributeValue<string>("address3_postofficebox");
            }
            set
            {
                this.OnPropertyChanging("Address3_PostOfficeBox");
                this.SetAttributeValue("address3_postofficebox", value);
                this.OnPropertyChanged("Address3_PostOfficeBox");
            }
        }

        /// <summary>
        /// 거래처의 세 번째 주소에 기본 연락처 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_primarycontactname")]
        public string Address3_PrimaryContactName
        {
            get
            {
                return this.GetAttributeValue<string>("address3_primarycontactname");
            }
            set
            {
                this.OnPropertyChanging("Address3_PrimaryContactName");
                this.SetAttributeValue("address3_primarycontactname", value);
                this.OnPropertyChanged("Address3_PrimaryContactName");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Address3_ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("address3_shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("Address3_ShippingMethodCode");
                this.SetAttributeValue("address3_shippingmethodcode", value);
                this.OnPropertyChanged("Address3_ShippingMethodCode");
            }
        }

        /// <summary>
        /// 세 번째 주소의 시/도입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_stateorprovince")]
        public string Address3_StateOrProvince
        {
            get
            {
                return this.GetAttributeValue<string>("address3_stateorprovince");
            }
            set
            {
                this.OnPropertyChanging("Address3_StateOrProvince");
                this.SetAttributeValue("address3_stateorprovince", value);
                this.OnPropertyChanged("Address3_StateOrProvince");
            }
        }

        /// <summary>
        /// 세 번째 주소에 연결된 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_telephone1")]
        public string Address3_Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("address3_telephone1");
            }
            set
            {
                this.OnPropertyChanging("Address3_Telephone1");
                this.SetAttributeValue("address3_telephone1", value);
                this.OnPropertyChanged("Address3_Telephone1");
            }
        }

        /// <summary>
        /// 세 번째 주소에 연결된 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_telephone2")]
        public string Address3_Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("address3_telephone2");
            }
            set
            {
                this.OnPropertyChanging("Address3_Telephone2");
                this.SetAttributeValue("address3_telephone2", value);
                this.OnPropertyChanged("Address3_Telephone2");
            }
        }

        /// <summary>
        /// 기본 주소에 연결된 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_telephone3")]
        public string Address3_Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("address3_telephone3");
            }
            set
            {
                this.OnPropertyChanging("Address3_Telephone3");
                this.SetAttributeValue("address3_telephone3", value);
                this.OnPropertyChanged("Address3_Telephone3");
            }
        }

        /// <summary>
        /// UPS로 운송될 경우 운송료를 제대로 계산하고 즉시 배송하도록 세 번째 주소의 UPS 영역을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_upszone")]
        public string Address3_UPSZone
        {
            get
            {
                return this.GetAttributeValue<string>("address3_upszone");
            }
            set
            {
                this.OnPropertyChanging("Address3_UPSZone");
                this.SetAttributeValue("address3_upszone", value);
                this.OnPropertyChanged("Address3_UPSZone");
            }
        }

        /// <summary>
        /// 이 주소의 누군가와 연락할 때 다른 사람이 참조할 수 있도록 이 주소의 표준 시간대 또는 UTC 시차를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("address3_utcoffset")]
        public System.Nullable<int> Address3_UTCOffset
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("address3_utcoffset");
            }
            set
            {
                this.OnPropertyChanging("Address3_UTCOffset");
                this.SetAttributeValue("address3_utcoffset", value);
                this.OnPropertyChanged("Address3_UTCOffset");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging30")]
        public Microsoft.Xrm.Sdk.Money Aging30
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging30");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 [30일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging30_base")]
        public Microsoft.Xrm.Sdk.Money Aging30_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging30_base");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging60")]
        public Microsoft.Xrm.Sdk.Money Aging60
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging60");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 [60일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging60_base")]
        public Microsoft.Xrm.Sdk.Money Aging60_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging60_base");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging90")]
        public Microsoft.Xrm.Sdk.Money Aging90
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging90");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 [90일 유예 기간] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("aging90_base")]
        public Microsoft.Xrm.Sdk.Money Aging90_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("aging90_base");
            }
        }

        /// <summary>
        /// 고객 선물 프로그램 또는 기타 연락용으로 연락처의 결혼식 또는 서비스 기념일을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("anniversary")]
        public System.Nullable<System.DateTime> Anniversary
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("anniversary");
            }
            set
            {
                this.OnPropertyChanging("Anniversary");
                this.SetAttributeValue("anniversary", value);
                this.OnPropertyChanged("Anniversary");
            }
        }

        /// <summary>
        /// 자료 수집 및 재무 분석용으로 연락처의 연간 수입을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("annualincome")]
        public Microsoft.Xrm.Sdk.Money AnnualIncome
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("annualincome");
            }
            set
            {
                this.OnPropertyChanging("AnnualIncome");
                this.SetAttributeValue("annualincome", value);
                this.OnPropertyChanged("AnnualIncome");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 [연간 수입] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("annualincome_base")]
        public Microsoft.Xrm.Sdk.Money AnnualIncome_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("annualincome_base");
            }
        }

        /// <summary>
        /// 연락처의 비서 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("assistantname")]
        public string AssistantName
        {
            get
            {
                return this.GetAttributeValue<string>("assistantname");
            }
            set
            {
                this.OnPropertyChanging("AssistantName");
                this.SetAttributeValue("assistantname", value);
                this.OnPropertyChanged("AssistantName");
            }
        }

        /// <summary>
        /// 연락처의 비서 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("assistantphone")]
        public string AssistantPhone
        {
            get
            {
                return this.GetAttributeValue<string>("assistantphone");
            }
            set
            {
                this.OnPropertyChanging("AssistantPhone");
                this.SetAttributeValue("assistantphone", value);
                this.OnPropertyChanged("AssistantPhone");
            }
        }

        /// <summary>
        /// 고객 선물 프로그램 또는 기타 연락용으로 연락처의 생일을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("birthdate")]
        public System.Nullable<System.DateTime> BirthDate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("birthdate");
            }
            set
            {
                this.OnPropertyChanging("BirthDate");
                this.SetAttributeValue("birthdate", value);
                this.OnPropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// 이 연락처의 두 번째 근무처 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("business2")]
        public string Business2
        {
            get
            {
                return this.GetAttributeValue<string>("business2");
            }
            set
            {
                this.OnPropertyChanging("Business2");
                this.SetAttributeValue("business2", value);
                this.OnPropertyChanged("Business2");
            }
        }

        /// <summary>
        /// 이 연락처의 콜백 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("callback")]
        public string Callback
        {
            get
            {
                return this.GetAttributeValue<string>("callback");
            }
            set
            {
                this.OnPropertyChanging("Callback");
                this.SetAttributeValue("callback", value);
                this.OnPropertyChanged("Callback");
            }
        }

        /// <summary>
        /// 연락 및 클라이언트 프로그램 참조용으로 연락처의 자녀 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("childrensnames")]
        public string ChildrensNames
        {
            get
            {
                return this.GetAttributeValue<string>("childrensnames");
            }
            set
            {
                this.OnPropertyChanging("ChildrensNames");
                this.SetAttributeValue("childrensnames", value);
                this.OnPropertyChanged("ChildrensNames");
            }
        }

        /// <summary>
        /// 연락처의 회사 전화를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("company")]
        public string Company
        {
            get
            {
                return this.GetAttributeValue<string>("company");
            }
            set
            {
                this.OnPropertyChanging("Company");
                this.SetAttributeValue("company", value);
                this.OnPropertyChanged("Company");
            }
        }

        /// <summary>
        /// 연락처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contactid")]
        public System.Nullable<System.Guid> ContactId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("contactid");
            }
            set
            {
                this.OnPropertyChanging("ContactId");
                this.SetAttributeValue("contactid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("ContactId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contactid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.ContactId = value;
            }
        }

        /// <summary>
        /// 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// 레코드를 만든 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// 송장 및 회계 문제를 고객에게 보낼 때 참조용으로 연락처의 신용 한도액을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditlimit")]
        public Microsoft.Xrm.Sdk.Money CreditLimit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("creditlimit");
            }
            set
            {
                this.OnPropertyChanging("CreditLimit");
                this.SetAttributeValue("creditlimit", value);
                this.OnPropertyChanged("CreditLimit");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [신용 한도액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditlimit_base")]
        public Microsoft.Xrm.Sdk.Money CreditLimit_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("creditlimit_base");
            }
        }

        /// <summary>
        /// 송장 및 회계 문제를 보낼 때 참조용으로 연락처가 신용 보류 상태인지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("creditonhold")]
        public System.Nullable<bool> CreditOnHold
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("creditonhold");
            }
            set
            {
                this.OnPropertyChanging("CreditOnHold");
                this.SetAttributeValue("creditonhold", value);
                this.OnPropertyChanged("CreditOnHold");
            }
        }

        /// <summary>
        /// 세분화 및 보고용으로 연락처 회사의 크기를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customersizecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CustomerSizeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customersizecode");
            }
            set
            {
                this.OnPropertyChanging("CustomerSizeCode");
                this.SetAttributeValue("customersizecode", value);
                this.OnPropertyChanged("CustomerSizeCode");
            }
        }

        /// <summary>
        /// 연락처 및 조직 간의 관계를 가장 잘 설명하는 범주를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customertypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CustomerTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customertypecode");
            }
            set
            {
                this.OnPropertyChanging("CustomerTypeCode");
                this.SetAttributeValue("customertypecode", value);
                this.OnPropertyChanged("CustomerTypeCode");
            }
        }

        /// <summary>
        /// 해당 고객에 대해 올바른 제품 가격이 영업 기회, 견적 및 주문에 적용되도록 연락처와 연관된 기본 가격표를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("defaultpricelevelid")]
        public Microsoft.Xrm.Sdk.EntityReference DefaultPriceLevelId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("defaultpricelevelid");
            }
            set
            {
                this.OnPropertyChanging("DefaultPriceLevelId");
                this.SetAttributeValue("defaultpricelevelid", value);
                this.OnPropertyChanged("DefaultPriceLevelId");
            }
        }

        /// <summary>
        /// 연락처가 상위 회사 또는 사업에서 일하는 부서 또는 사업부를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("department")]
        public string Department
        {
            get
            {
                return this.GetAttributeValue<string>("department");
            }
            set
            {
                this.OnPropertyChanging("Department");
                this.SetAttributeValue("department", value);
                this.OnPropertyChanged("Department");
            }
        }

        /// <summary>
        /// 연락처를 설명하는 추가 정보를 입력합니다(예: 회사 웹 사이트에서의 발췌).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 전자 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 목록에는 추가될 수 있지만 전자 메일에서는 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotbulkemail")]
        public System.Nullable<bool> DoNotBulkEMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotbulkemail");
            }
            set
            {
                this.OnPropertyChanging("DoNotBulkEMail");
                this.SetAttributeValue("donotbulkemail", value);
                this.OnPropertyChanged("DoNotBulkEMail");
            }
        }

        /// <summary>
        /// 마케팅 캠페인 또는 퀵 캠페인을 통해 보내는 대량 우편 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 목록에는 추가될 수 있지만 편지에서는 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotbulkpostalmail")]
        public System.Nullable<bool> DoNotBulkPostalMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotbulkpostalmail");
            }
            set
            {
                this.OnPropertyChanging("DoNotBulkPostalMail");
                this.SetAttributeValue("donotbulkpostalmail", value);
                this.OnPropertyChanged("DoNotBulkPostalMail");
            }
        }

        /// <summary>
        /// Microsoft Dynamics 365에서 보내는 다이렉트 전자 메일을 연락처에서 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 Microsoft Dynamics 365에서 전자 메일을 보내지 않습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotemail")]
        public System.Nullable<bool> DoNotEMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotemail");
            }
            set
            {
                this.OnPropertyChanging("DoNotEMail");
                this.SetAttributeValue("donotemail", value);
                this.OnPropertyChanged("DoNotEMail");
            }
        }

        /// <summary>
        /// 연락처에서 팩스를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 모든 팩스 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotfax")]
        public System.Nullable<bool> DoNotFax
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotfax");
            }
            set
            {
                this.OnPropertyChanging("DoNotFax");
                this.SetAttributeValue("donotfax", value);
                this.OnPropertyChanged("DoNotFax");
            }
        }

        /// <summary>
        /// 연락처에서 전화 통화를 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 모든 전화 통화 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotphone")]
        public System.Nullable<bool> DoNotPhone
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotphone");
            }
            set
            {
                this.OnPropertyChanging("DoNotPhone");
                this.SetAttributeValue("donotphone", value);
                this.OnPropertyChanged("DoNotPhone");
            }
        }

        /// <summary>
        /// 연락처에서 다이렉트 메일을 허용할지 여부를 선택합니다. [허용 안 함]을 선택하면 연락처가 마케팅 캠페인으로 배포된 편지 활동에서 제외됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotpostalmail")]
        public System.Nullable<bool> DoNotPostalMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotpostalmail");
            }
            set
            {
                this.OnPropertyChanging("DoNotPostalMail");
                this.SetAttributeValue("donotpostalmail", value);
                this.OnPropertyChanged("DoNotPostalMail");
            }
        }

        /// <summary>
        /// 연락처에서 마케팅 자료(예: 브로슈어 또는 카탈로그)를 허용할지 여부를 선택합니다. 마케팅 이니셔티브에서 옵트아웃이 제외될 수 있는 연락처입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotsendmm")]
        public System.Nullable<bool> DoNotSendMM
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotsendmm");
            }
            set
            {
                this.OnPropertyChanging("DoNotSendMM");
                this.SetAttributeValue("donotsendmm", value);
                this.OnPropertyChanged("DoNotSendMM");
            }
        }

        /// <summary>
        /// 마케팅 세분화 및 분석에 사용할 연락처의 최고 교육 수준을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("educationcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue EducationCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("educationcode");
            }
            set
            {
                this.OnPropertyChanging("EducationCode");
                this.SetAttributeValue("educationcode", value);
                this.OnPropertyChanged("EducationCode");
            }
        }

        /// <summary>
        /// 연락처의 기본 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress1")]
        public string EMailAddress1
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress1");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress1");
                this.SetAttributeValue("emailaddress1", value);
                this.OnPropertyChanged("EMailAddress1");
            }
        }

        /// <summary>
        /// 연락처의 보조 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress2")]
        public string EMailAddress2
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress2");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress2");
                this.SetAttributeValue("emailaddress2", value);
                this.OnPropertyChanged("EMailAddress2");
            }
        }

        /// <summary>
        /// 연락처의 대체 전자 메일 주소를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress3")]
        public string EMailAddress3
        {
            get
            {
                return this.GetAttributeValue<string>("emailaddress3");
            }
            set
            {
                this.OnPropertyChanging("EMailAddress3");
                this.SetAttributeValue("emailaddress3", value);
                this.OnPropertyChanged("EMailAddress3");
            }
        }

        /// <summary>
        /// 주문, 서비스 케이스 또는 기타 연락처 조직과의 연락 참조용으로 직원 ID 또는 연락처 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("employeeid")]
        public string EmployeeId
        {
            get
            {
                return this.GetAttributeValue<string>("employeeid");
            }
            set
            {
                this.OnPropertyChanging("EmployeeId");
                this.SetAttributeValue("employeeid", value);
                this.OnPropertyChanged("EmployeeId");
            }
        }

        /// <summary>
        /// 레코드의 기본 이미지를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
        public byte[] EntityImage
        {
            get
            {
                return this.GetAttributeValue<byte[]>("entityimage");
            }
            set
            {
                this.OnPropertyChanging("EntityImage");
                this.SetAttributeValue("entityimage", value);
                this.OnPropertyChanged("EntityImage");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
        public System.Nullable<long> EntityImage_Timestamp
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
        public string EntityImage_URL
        {
            get
            {
                return this.GetAttributeValue<string>("entityimage_url");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
        public System.Nullable<System.Guid> EntityImageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
            }
        }

        /// <summary>
        /// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
        public System.Nullable<decimal> ExchangeRate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
            }
        }

        /// <summary>
        /// 외부 사용자의 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("externaluseridentifier")]
        public string ExternalUserIdentifier
        {
            get
            {
                return this.GetAttributeValue<string>("externaluseridentifier");
            }
            set
            {
                this.OnPropertyChanging("ExternalUserIdentifier");
                this.SetAttributeValue("externaluseridentifier", value);
                this.OnPropertyChanged("ExternalUserIdentifier");
            }
        }

        /// <summary>
        /// 후속 전화 통화 및 기타 연락 참조용으로 연락처의 결혼 상태를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("familystatuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue FamilyStatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("familystatuscode");
            }
            set
            {
                this.OnPropertyChanging("FamilyStatusCode");
                this.SetAttributeValue("familystatuscode", value);
                this.OnPropertyChanged("FamilyStatusCode");
            }
        }

        /// <summary>
        /// 연락처의 팩스 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fax")]
        public string Fax
        {
            get
            {
                return this.GetAttributeValue<string>("fax");
            }
            set
            {
                this.OnPropertyChanging("Fax");
                this.SetAttributeValue("fax", value);
                this.OnPropertyChanged("Fax");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstname")]
        public string FirstName
        {
            get
            {
                return this.GetAttributeValue<string>("firstname");
            }
            set
            {
                this.OnPropertyChanging("FirstName");
                this.SetAttributeValue("firstname", value);
                this.OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// 연락처에 전송된 전자 메일에 대한 개봉, 첨부 파일 보기, 링크 클릭과 같은 전자 메일 활동을 팔로우하도록 허용할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followemail")]
        public System.Nullable<bool> FollowEmail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("followemail");
            }
            set
            {
                this.OnPropertyChanging("FollowEmail");
                this.SetAttributeValue("followemail", value);
                this.OnPropertyChanged("FollowEmail");
            }
        }

        /// <summary>
        /// 사용자가 데이터에 액세스하고 문서를 공유할 수 있도록 연락처의 FTP 사이트에 대한 URL을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ftpsiteurl")]
        public string FtpSiteUrl
        {
            get
            {
                return this.GetAttributeValue<string>("ftpsiteurl");
            }
            set
            {
                this.OnPropertyChanging("FtpSiteUrl");
                this.SetAttributeValue("ftpsiteurl", value);
                this.OnPropertyChanged("FtpSiteUrl");
            }
        }

        /// <summary>
        /// 보기 및 보고서에 전체 이름을 표시할 수 있도록 연락처의 이름과 성을 결합하여 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fullname")]
        public string FullName
        {
            get
            {
                return this.GetAttributeValue<string>("fullname");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 성별을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("gendercode")]
        public Microsoft.Xrm.Sdk.OptionSetValue GenderCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("gendercode");
            }
            set
            {
                this.OnPropertyChanging("GenderCode");
                this.SetAttributeValue("gendercode", value);
                this.OnPropertyChanged("GenderCode");
            }
        }

        /// <summary>
        /// 문서 및 보고서용으로 연락처의 여권 번호 또는 주민 등록 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("governmentid")]
        public string GovernmentId
        {
            get
            {
                return this.GetAttributeValue<string>("governmentid");
            }
            set
            {
                this.OnPropertyChanging("GovernmentId");
                this.SetAttributeValue("governmentid", value);
                this.OnPropertyChanged("GovernmentId");
            }
        }

        /// <summary>
        /// 후속 전화 통화 및 기타 연락 참조용으로 연락처에게 자녀가 있는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("haschildrencode")]
        public Microsoft.Xrm.Sdk.OptionSetValue HasChildrenCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("haschildrencode");
            }
            set
            {
                this.OnPropertyChanging("HasChildrenCode");
                this.SetAttributeValue("haschildrencode", value);
                this.OnPropertyChanged("HasChildrenCode");
            }
        }

        /// <summary>
        /// 이 연락처의 두 번째 집 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("home2")]
        public string Home2
        {
            get
            {
                return this.GetAttributeValue<string>("home2");
            }
            set
            {
                this.OnPropertyChanging("Home2");
                this.SetAttributeValue("home2", value);
                this.OnPropertyChanged("Home2");
            }
        }

        /// <summary>
        /// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
        public System.Nullable<int> ImportSequenceNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
            }
            set
            {
                this.OnPropertyChanging("ImportSequenceNumber");
                this.SetAttributeValue("importsequencenumber", value);
                this.OnPropertyChanged("ImportSequenceNumber");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_facebook")]
        public string int_Facebook
        {
            get
            {
                return this.GetAttributeValue<string>("int_facebook");
            }
            set
            {
                this.OnPropertyChanging("int_Facebook");
                this.SetAttributeValue("int_facebook", value);
                this.OnPropertyChanged("int_Facebook");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_facebookservice")]
        public string int_FacebookService
        {
            get
            {
                return this.GetAttributeValue<string>("int_facebookservice");
            }
            set
            {
                this.OnPropertyChanging("int_FacebookService");
                this.SetAttributeValue("int_facebookservice", value);
                this.OnPropertyChanged("int_FacebookService");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_kloutscore")]
        public System.Nullable<int> int_KloutScore
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("int_kloutscore");
            }
            set
            {
                this.OnPropertyChanging("int_KloutScore");
                this.SetAttributeValue("int_kloutscore", value);
                this.OnPropertyChanged("int_KloutScore");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_kloutscoreservice")]
        public System.Nullable<int> int_KloutScoreService
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("int_kloutscoreservice");
            }
            set
            {
                this.OnPropertyChanging("int_KloutScoreService");
                this.SetAttributeValue("int_kloutscoreservice", value);
                this.OnPropertyChanged("int_KloutScoreService");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_twitter")]
        public string int_Twitter
        {
            get
            {
                return this.GetAttributeValue<string>("int_twitter");
            }
            set
            {
                this.OnPropertyChanging("int_Twitter");
                this.SetAttributeValue("int_twitter", value);
                this.OnPropertyChanged("int_Twitter");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_twitterservice")]
        public string int_TwitterService
        {
            get
            {
                return this.GetAttributeValue<string>("int_twitterservice");
            }
            set
            {
                this.OnPropertyChanging("int_TwitterService");
                this.SetAttributeValue("int_twitterservice", value);
                this.OnPropertyChanged("int_TwitterService");
            }
        }

        /// <summary>
        /// 통합 프로세스용으로 연락처가 별도의 회계 또는 기타 시스템에 있는지 여부를 선택합니다(예: Microsoft Dynamics GP 또는 기타 ERP 데이터베이스).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isbackofficecustomer")]
        public System.Nullable<bool> IsBackofficeCustomer
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isbackofficecustomer");
            }
            set
            {
                this.OnPropertyChanging("IsBackofficeCustomer");
                this.SetAttributeValue("isbackofficecustomer", value);
                this.OnPropertyChanged("IsBackofficeCustomer");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 직함을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("jobtitle")]
        public string JobTitle
        {
            get
            {
                return this.GetAttributeValue<string>("jobtitle");
            }
            set
            {
                this.OnPropertyChanging("JobTitle");
                this.SetAttributeValue("jobtitle", value);
                this.OnPropertyChanged("JobTitle");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 성을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastname")]
        public string LastName
        {
            get
            {
                return this.GetAttributeValue<string>("lastname");
            }
            set
            {
                this.OnPropertyChanging("LastName");
                this.SetAttributeValue("lastname", value);
                this.OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
        public System.Nullable<System.DateTime> LastOnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
            }
            set
            {
                this.OnPropertyChanging("LastOnHoldTime");
                this.SetAttributeValue("lastonholdtime", value);
                this.OnPropertyChanged("LastOnHoldTime");
            }
        }

        /// <summary>
        /// 연락처가 마지막으로 마케팅 캠페인 및 퀵 캠페인에 포함된 날짜를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastusedincampaign")]
        public System.Nullable<System.DateTime> LastUsedInCampaign
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastusedincampaign");
            }
            set
            {
                this.OnPropertyChanging("LastUsedInCampaign");
                this.SetAttributeValue("lastusedincampaign", value);
                this.OnPropertyChanged("LastUsedInCampaign");
            }
        }

        /// <summary>
        /// 사용자 조직에 연락처를 알려 준 기본 마케팅 자료를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("leadsourcecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue LeadSourceCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("leadsourcecode");
            }
            set
            {
                this.OnPropertyChanging("LeadSourceCode");
                this.SetAttributeValue("leadsourcecode", value);
                this.OnPropertyChanged("LeadSourceCode");
            }
        }

        /// <summary>
        /// 늘어나는 문제 또는 연락처와의 기타 후속 연락용으로 연락처의 관리자 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("managername")]
        public string ManagerName
        {
            get
            {
                return this.GetAttributeValue<string>("managername");
            }
            set
            {
                this.OnPropertyChanging("ManagerName");
                this.SetAttributeValue("managername", value);
                this.OnPropertyChanged("ManagerName");
            }
        }

        /// <summary>
        /// 연락처의 관리자 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("managerphone")]
        public string ManagerPhone
        {
            get
            {
                return this.GetAttributeValue<string>("managerphone");
            }
            set
            {
                this.OnPropertyChanging("ManagerPhone");
                this.SetAttributeValue("managerphone", value);
                this.OnPropertyChanged("ManagerPhone");
            }
        }

        /// <summary>
        /// 마케팅 전용인지 여부
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("marketingonly")]
        public System.Nullable<bool> MarketingOnly
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("marketingonly");
            }
            set
            {
                this.OnPropertyChanging("MarketingOnly");
                this.SetAttributeValue("marketingonly", value);
                this.OnPropertyChanged("MarketingOnly");
            }
        }

        /// <summary>
        /// 병합할 마스터 연락처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("masterid")]
        public Microsoft.Xrm.Sdk.EntityReference MasterId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("masterid");
            }
        }

        /// <summary>
        /// 거래처가 마스터 연락처와 병합되었는지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("merged")]
        public System.Nullable<bool> Merged
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("merged");
            }
        }

        /// <summary>
        /// 연락처가 제대로 처리되도록 연락처의 중간 이름 또는 이니셜을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("middlename")]
        public string MiddleName
        {
            get
            {
                return this.GetAttributeValue<string>("middlename");
            }
            set
            {
                this.OnPropertyChanging("MiddleName");
                this.SetAttributeValue("middlename", value);
                this.OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// 연락처의 휴대폰 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mobilephone")]
        public string MobilePhone
        {
            get
            {
                return this.GetAttributeValue<string>("mobilephone");
            }
            set
            {
                this.OnPropertyChanging("MobilePhone");
                this.SetAttributeValue("mobilephone", value);
                this.OnPropertyChanged("MobilePhone");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// 레코드를 수정한 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// 연락처의 애칭을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nickname")]
        public string NickName
        {
            get
            {
                return this.GetAttributeValue<string>("nickname");
            }
            set
            {
                this.OnPropertyChanging("NickName");
                this.SetAttributeValue("nickname", value);
                this.OnPropertyChanged("NickName");
            }
        }

        /// <summary>
        /// 후속 전화 통화 및 기타 연락 참조용으로 연락처의 자녀 수를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberofchildren")]
        public System.Nullable<int> NumberOfChildren
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("numberofchildren");
            }
            set
            {
                this.OnPropertyChanging("NumberOfChildren");
                this.SetAttributeValue("numberofchildren", value);
                this.OnPropertyChanged("NumberOfChildren");
            }
        }

        /// <summary>
        /// 레코드가 보류 중인 시간을 분으로 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
        public System.Nullable<int> OnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
            }
        }

        /// <summary>
        /// 연락처가 Microsoft Dynamics 365의 잠재 고객을 변환하여 만들어진 경우 연락처가 만들어진 잠재 고객을 표시합니다. 이 값은 보고 및 분석용으로 연락처와 원래 잠재 고객의 데이터를 연결하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("originatingleadid")]
        public Microsoft.Xrm.Sdk.EntityReference OriginatingLeadId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("originatingleadid");
            }
            set
            {
                this.OnPropertyChanging("OriginatingLeadId");
                this.SetAttributeValue("originatingleadid", value);
                this.OnPropertyChanged("OriginatingLeadId");
            }
        }

        /// <summary>
        /// 레코드를 마이그레이션한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
        public System.Nullable<System.DateTime> OverriddenCreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
            }
            set
            {
                this.OnPropertyChanging("OverriddenCreatedOn");
                this.SetAttributeValue("overriddencreatedon", value);
                this.OnPropertyChanged("OverriddenCreatedOn");
            }
        }

        /// <summary>
        /// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
            set
            {
                this.OnPropertyChanging("OwnerId");
                this.SetAttributeValue("ownerid", value);
                this.OnPropertyChanged("OwnerId");
            }
        }

        /// <summary>
        /// 연락처를 담당하는 사업부의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
        public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
            }
        }

        /// <summary>
        /// 연락처를 담당하는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
        public Microsoft.Xrm.Sdk.EntityReference OwningTeam
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
            }
        }

        /// <summary>
        /// 연락처를 담당하는 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
        public Microsoft.Xrm.Sdk.EntityReference OwningUser
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
            }
        }

        /// <summary>
        /// 연락처의 호출기 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pager")]
        public string Pager
        {
            get
            {
                return this.GetAttributeValue<string>("pager");
            }
            set
            {
                this.OnPropertyChanging("Pager");
                this.SetAttributeValue("pager", value);
                this.OnPropertyChanged("Pager");
            }
        }

        /// <summary>
        /// 상위 연락처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentcontactid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentcontactid");
            }
        }

        /// <summary>
        /// 재무 정보, 활동, 영업 기회와 같은 추가 정보에 대한 퀵 링크를 제공하는 거래처의 상위 거래처 또는 상위 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentcustomerid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentCustomerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentcustomerid");
            }
            set
            {
                this.OnPropertyChanging("ParentCustomerId");
                this.SetAttributeValue("parentcustomerid", value);
                this.OnPropertyChanged("ParentCustomerId");
            }
        }

        /// <summary>
        /// 연락처가 워크플로 규칙에 관여하는지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("participatesinworkflow")]
        public System.Nullable<bool> ParticipatesInWorkflow
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("participatesinworkflow");
            }
            set
            {
                this.OnPropertyChanging("ParticipatesInWorkflow");
                this.SetAttributeValue("participatesinworkflow", value);
                this.OnPropertyChanged("ParticipatesInWorkflow");
            }
        }

        /// <summary>
        /// 고객이 총 금액을 지불해야 할 때 표시할 지불 조건을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("paymenttermscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PaymentTermsCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("paymenttermscode");
            }
            set
            {
                this.OnPropertyChanging("PaymentTermsCode");
                this.SetAttributeValue("paymenttermscode", value);
                this.OnPropertyChanged("PaymentTermsCode");
            }
        }

        /// <summary>
        /// 서비스 약속에 대해 선호하는 요일을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredappointmentdaycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredAppointmentDayCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredappointmentdaycode");
            }
            set
            {
                this.OnPropertyChanging("PreferredAppointmentDayCode");
                this.SetAttributeValue("preferredappointmentdaycode", value);
                this.OnPropertyChanged("PreferredAppointmentDayCode");
            }
        }

        /// <summary>
        /// 서비스 약속에 대해 선호하는 하루 중 시간을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredappointmenttimecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredAppointmentTimeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredappointmenttimecode");
            }
            set
            {
                this.OnPropertyChanging("PreferredAppointmentTimeCode");
                this.SetAttributeValue("preferredappointmenttimecode", value);
                this.OnPropertyChanged("PreferredAppointmentTimeCode");
            }
        }

        /// <summary>
        /// 선호하는 연락 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredcontactmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PreferredContactMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("preferredcontactmethodcode");
            }
            set
            {
                this.OnPropertyChanging("PreferredContactMethodCode");
                this.SetAttributeValue("preferredcontactmethodcode", value);
                this.OnPropertyChanged("PreferredContactMethodCode");
            }
        }

        /// <summary>
        /// 고객에 대한 서비스가 제대로 예약되도록 연락처의 선호 서비스 시설 또는 장비를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredequipmentid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredEquipmentId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredequipmentid");
            }
            set
            {
                this.OnPropertyChanging("PreferredEquipmentId");
                this.SetAttributeValue("preferredequipmentid", value);
                this.OnPropertyChanged("PreferredEquipmentId");
            }
        }

        /// <summary>
        /// 고객에 대한 서비스가 제대로 예약되도록 연락처의 선호 서비스를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredserviceid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredServiceId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredserviceid");
            }
            set
            {
                this.OnPropertyChanging("PreferredServiceId");
                this.SetAttributeValue("preferredserviceid", value);
                this.OnPropertyChanged("PreferredServiceId");
            }
        }

        /// <summary>
        /// 연락처에 대한 서비스 활동을 예약할 때 참조할 정규 또는 선호 고객 지원 담당자를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("preferredsystemuserid")]
        public Microsoft.Xrm.Sdk.EntityReference PreferredSystemUserId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("preferredsystemuserid");
            }
            set
            {
                this.OnPropertyChanging("PreferredSystemUserId");
                this.SetAttributeValue("preferredsystemuserid", value);
                this.OnPropertyChanged("PreferredSystemUserId");
            }
        }

        /// <summary>
        /// 프로세스의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
        public System.Nullable<System.Guid> ProcessId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
            }
            set
            {
                this.OnPropertyChanging("ProcessId");
                this.SetAttributeValue("processid", value);
                this.OnPropertyChanged("ProcessId");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 메시지 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 인사말을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("salutation")]
        public string Salutation
        {
            get
            {
                return this.GetAttributeValue<string>("salutation");
            }
            set
            {
                this.OnPropertyChanging("Salutation");
                this.SetAttributeValue("salutation", value);
                this.OnPropertyChanged("Salutation");
            }
        }

        /// <summary>
        /// 이 주소로 보내는 배송품의 운송 방법을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("shippingmethodcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue ShippingMethodCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("shippingmethodcode");
            }
            set
            {
                this.OnPropertyChanging("ShippingMethodCode");
                this.SetAttributeValue("shippingmethodcode", value);
                this.OnPropertyChanged("ShippingMethodCode");
            }
        }

        /// <summary>
        /// 연락처 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
            }
            set
            {
                this.OnPropertyChanging("SLAId");
                this.SetAttributeValue("slaid", value);
                this.OnPropertyChanged("SLAId");
            }
        }

        /// <summary>
        /// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
            }
        }

        /// <summary>
        /// 통화, 이벤트 또는 기타 연락처와의 연락 시 참조용으로 연락처의 배우자 또는 파트너 이름을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("spousesname")]
        public string SpousesName
        {
            get
            {
                return this.GetAttributeValue<string>("spousesname");
            }
            set
            {
                this.OnPropertyChanging("SpousesName");
                this.SetAttributeValue("spousesname", value);
                this.OnPropertyChanged("SpousesName");
            }
        }

        /// <summary>
        /// 스테이지의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
        public System.Nullable<System.Guid> StageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
            }
            set
            {
                this.OnPropertyChanging("StageId");
                this.SetAttributeValue("stageid", value);
                this.OnPropertyChanged("StageId");
            }
        }

        /// <summary>
        /// 연락처가 활성인지, 아니면 비활성인지를 표시합니다. 비활성 연락처는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<ContactState> StateCode
        {
            get
            {
                Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if ((optionSet != null))
                {
                    return ((ContactState)(System.Enum.ToObject(typeof(ContactState), optionSet.Value)));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if ((value == null))
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// 연락처의 상태를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subscriptionid")]
        public System.Nullable<System.Guid> SubscriptionId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("subscriptionid");
            }
            set
            {
                this.OnPropertyChanging("SubscriptionId");
                this.SetAttributeValue("subscriptionid", value);
                this.OnPropertyChanged("SubscriptionId");
            }
        }

        /// <summary>
        /// 영업 통화, 전자 메일 및 마케팅 캠페인에 연락처가 제대로 처리되도록 연락처의 이름에 사용되는 호칭(예: 박사, 양, 군, 씨, 님, 교수)을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("suffix")]
        public string Suffix
        {
            get
            {
                return this.GetAttributeValue<string>("suffix");
            }
            set
            {
                this.OnPropertyChanging("Suffix");
                this.SetAttributeValue("suffix", value);
                this.OnPropertyChanged("Suffix");
            }
        }

        /// <summary>
        /// 이 연락처의 기본 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone1")]
        public string Telephone1
        {
            get
            {
                return this.GetAttributeValue<string>("telephone1");
            }
            set
            {
                this.OnPropertyChanging("Telephone1");
                this.SetAttributeValue("telephone1", value);
                this.OnPropertyChanged("Telephone1");
            }
        }

        /// <summary>
        /// 이 연락처의 두 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone2")]
        public string Telephone2
        {
            get
            {
                return this.GetAttributeValue<string>("telephone2");
            }
            set
            {
                this.OnPropertyChanging("Telephone2");
                this.SetAttributeValue("telephone2", value);
                this.OnPropertyChanged("Telephone2");
            }
        }

        /// <summary>
        /// 이 연락처의 세 번째 전화 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("telephone3")]
        public string Telephone3
        {
            get
            {
                return this.GetAttributeValue<string>("telephone3");
            }
            set
            {
                this.OnPropertyChanging("Telephone3");
                this.SetAttributeValue("telephone3", value);
                this.OnPropertyChanged("Telephone3");
            }
        }

        /// <summary>
        /// 세분화 및 분석에 사용할 연락처의 지역 또는 권역을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("territorycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue TerritoryCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("territorycode");
            }
            set
            {
                this.OnPropertyChanging("TerritoryCode");
                this.SetAttributeValue("territorycode", value);
                this.OnPropertyChanged("TerritoryCode");
            }
        }

        /// <summary>
        /// 연락처 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timespentbymeonemailandmeetings")]
        public string TimeSpentByMeOnEmailAndMeetings
        {
            get
            {
                return this.GetAttributeValue<string>("timespentbymeonemailandmeetings");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
        public System.Nullable<int> TimeZoneRuleVersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
            }
            set
            {
                this.OnPropertyChanging("TimeZoneRuleVersionNumber");
                this.SetAttributeValue("timezoneruleversionnumber", value);
                this.OnPropertyChanged("TimeZoneRuleVersionNumber");
            }
        }

        /// <summary>
        /// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
        public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
            }
            set
            {
                this.OnPropertyChanging("TransactionCurrencyId");
                this.SetAttributeValue("transactioncurrencyid", value);
                this.OnPropertyChanged("TransactionCurrencyId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
        public string TraversedPath
        {
            get
            {
                return this.GetAttributeValue<string>("traversedpath");
            }
            set
            {
                this.OnPropertyChanging("TraversedPath");
                this.SetAttributeValue("traversedpath", value);
                this.OnPropertyChanged("TraversedPath");
            }
        }

        /// <summary>
        /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
        public System.Nullable<int> UTCConversionTimeZoneCode
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
            }
            set
            {
                this.OnPropertyChanging("UTCConversionTimeZoneCode");
                this.SetAttributeValue("utcconversiontimezonecode", value);
                this.OnPropertyChanged("UTCConversionTimeZoneCode");
            }
        }

        /// <summary>
        /// 연락처의 버전 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }

        /// <summary>
        /// 연락처의 전문 또는 개인 웹 사이트나 블로그 URL을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("websiteurl")]
        public string WebSiteUrl
        {
            get
            {
                return this.GetAttributeValue<string>("websiteurl");
            }
            set
            {
                this.OnPropertyChanging("WebSiteUrl");
                this.SetAttributeValue("websiteurl", value);
                this.OnPropertyChanged("WebSiteUrl");
            }
        }

        /// <summary>
        /// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 이름의 표음식 철자를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomifirstname")]
        public string YomiFirstName
        {
            get
            {
                return this.GetAttributeValue<string>("yomifirstname");
            }
            set
            {
                this.OnPropertyChanging("YomiFirstName");
                this.SetAttributeValue("yomifirstname", value);
                this.OnPropertyChanged("YomiFirstName");
            }
        }

        /// <summary>
        /// 보기 및 보고서에 전체 발음 이름을 표시할 수 있도록 연락처의 이름과 성(일본어 요미)을 결합하여 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomifullname")]
        public string YomiFullName
        {
            get
            {
                return this.GetAttributeValue<string>("yomifullname");
            }
        }

        /// <summary>
        /// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 성의 표음식 철자를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomilastname")]
        public string YomiLastName
        {
            get
            {
                return this.GetAttributeValue<string>("yomilastname");
            }
            set
            {
                this.OnPropertyChanging("YomiLastName");
                this.SetAttributeValue("yomilastname", value);
                this.OnPropertyChanged("YomiLastName");
            }
        }

        /// <summary>
        /// 이름이 일본어로 지정된 경우 연락처와의 전화 통화 시 이름이 올바르게 발음되도록 연락처 중간 이름의 표음식 철자를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yomimiddlename")]
        public string YomiMiddleName
        {
            get
            {
                return this.GetAttributeValue<string>("yomimiddlename");
            }
            set
            {
                this.OnPropertyChanging("YomiMiddleName");
                this.SetAttributeValue("yomimiddlename", value);
                this.OnPropertyChanged("YomiMiddleName");
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
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("opportunity")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class Opportunity : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        #region Field
        [System.Runtime.Serialization.DataContractAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
        public enum OpportunityState
        {

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Open = 0,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Won = 1,

            [System.Runtime.Serialization.EnumMemberAttribute()]
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
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 영업 기회와 연관된 거래처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
        public Microsoft.Xrm.Sdk.EntityReference AccountId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("accountid");
            }
        }

        /// <summary>
        /// 영업 기회가 종료 또는 취소된 날짜 및 시간을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualclosedate")]
        public System.Nullable<System.DateTime> ActualCloseDate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("actualclosedate");
            }
            set
            {
                this.OnPropertyChanging("ActualCloseDate");
                this.SetAttributeValue("actualclosedate", value);
                this.OnPropertyChanged("ActualCloseDate");
            }
        }

        /// <summary>
        /// 예상 및 실제 영업 보고 및 분석용으로 영업 기회의 실제 수익 금액을 입력합니다. 영업 기회가 성공하면 필드 기본값은 예상 수익 값이 됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualvalue")]
        public Microsoft.Xrm.Sdk.Money ActualValue
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("actualvalue");
            }
            set
            {
                this.OnPropertyChanging("ActualValue");
                this.SetAttributeValue("actualvalue", value);
                this.OnPropertyChanged("ActualValue");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [실제 매출] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualvalue_base")]
        public Microsoft.Xrm.Sdk.Money ActualValue_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("actualvalue_base");
            }
        }

        /// <summary>
        /// 잠재 고객의 잠재적으로 사용 가능한 예산을 나타내는 0에서 1,000,000,000,000 사이의 값을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("budgetamount")]
        public Microsoft.Xrm.Sdk.Money BudgetAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("budgetamount");
            }
            set
            {
                this.OnPropertyChanging("BudgetAmount");
                this.SetAttributeValue("budgetamount", value);
                this.OnPropertyChanged("BudgetAmount");
            }
        }

        /// <summary>
        /// 시스템의 기본 통화로 변환된 예산 금액을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("budgetamount_base")]
        public Microsoft.Xrm.Sdk.Money BudgetAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("budgetamount_base");
            }
        }

        /// <summary>
        /// 잠재 고객이 속한 회사의 예산 상태와 가장 근사한 항목을 선택합니다. 잠재 고객 등급 또는 영업 방식을 결정하는 데 도움이 될 수 있습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("budgetstatus")]
        public Microsoft.Xrm.Sdk.OptionSetValue BudgetStatus
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("budgetstatus");
            }
            set
            {
                this.OnPropertyChanging("BudgetStatus");
                this.SetAttributeValue("budgetstatus", value);
                this.OnPropertyChanged("BudgetStatus");
            }
        }

        /// <summary>
        /// 영업 기회가 만들어진 캠페인을 표시합니다. ID는 캠페인의 성공을 추적하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("campaignid")]
        public Microsoft.Xrm.Sdk.EntityReference CampaignId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("campaignid");
            }
            set
            {
                this.OnPropertyChanging("CampaignId");
                this.SetAttributeValue("campaignid", value);
                this.OnPropertyChanged("CampaignId");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 제안 피드백을 받았는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("captureproposalfeedback")]
        public System.Nullable<bool> CaptureProposalFeedback
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("captureproposalfeedback");
            }
            set
            {
                this.OnPropertyChanging("CaptureProposalFeedback");
                this.SetAttributeValue("captureproposalfeedback", value);
                this.OnPropertyChanged("CaptureProposalFeedback");
            }
        }

        /// <summary>
        /// 영업 기회 종료 가능성을 나타내는 0에서 100 사이의 숫자를 입력합니다. 이 값은 영업 시 영업 기회를 변환하기 위한 노력으로 영업 팀을 도울 수 있습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("closeprobability")]
        public System.Nullable<int> CloseProbability
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("closeprobability");
            }
            set
            {
                this.OnPropertyChanging("CloseProbability");
                this.SetAttributeValue("closeprobability", value);
                this.OnPropertyChanged("CloseProbability");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 최종 제안이 완료되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("completefinalproposal")]
        public System.Nullable<bool> CompleteFinalProposal
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("completefinalproposal");
            }
            set
            {
                this.OnPropertyChanging("CompleteFinalProposal");
                this.SetAttributeValue("completefinalproposal", value);
                this.OnPropertyChanged("CompleteFinalProposal");
            }
        }

        /// <summary>
        /// 이 영업 기회에 대한 내부 검토가 완료되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("completeinternalreview")]
        public System.Nullable<bool> CompleteInternalReview
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("completeinternalreview");
            }
            set
            {
                this.OnPropertyChanging("CompleteInternalReview");
                this.SetAttributeValue("completeinternalreview", value);
                this.OnPropertyChanged("CompleteInternalReview");
            }
        }

        /// <summary>
        /// 잠재 고객이 제공 사항에 관심이 있는 것으로 확인되었는지 여부를 선택합니다. 이 값은 잠재 고객의 관심도와 영업 기회로 전환될 가능성을 판별하는 데 도움이 됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("confirminterest")]
        public System.Nullable<bool> ConfirmInterest
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("confirminterest");
            }
            set
            {
                this.OnPropertyChanging("ConfirmInterest");
                this.SetAttributeValue("confirminterest", value);
                this.OnPropertyChanged("ConfirmInterest");
            }
        }

        /// <summary>
        /// 영업 기회와 연관된 연락처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contactid")]
        public Microsoft.Xrm.Sdk.EntityReference ContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contactid");
            }
        }

        /// <summary>
        /// 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// 영업 기회와 연관된 회사나 조직에 대한 메모를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("currentsituation")]
        public string CurrentSituation
        {
            get
            {
                return this.GetAttributeValue<string>("currentsituation");
            }
            set
            {
                this.OnPropertyChanging("CurrentSituation");
                this.SetAttributeValue("currentsituation", value);
                this.OnPropertyChanged("CurrentSituation");
            }
        }

        /// <summary>
        /// 주소, 전화 번호, 활동, 주문과 같은 추가 고객 정보에 대한 퀵 링크를 제공하는 고객 거래처 또는 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customerid")]
        public Microsoft.Xrm.Sdk.EntityReference CustomerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("customerid");
            }
            set
            {
                this.OnPropertyChanging("CustomerId");
                this.SetAttributeValue("customerid", value);
                this.OnPropertyChanged("CustomerId");
            }
        }

        /// <summary>
        /// 고객의 요구 사항을 충족할 수 있는 제품 및 서비스를 영업 팀에서 식별하는 데 도움이 되도록 고객의 요구 사항에 대한 메모를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customerneed")]
        public string CustomerNeed
        {
            get
            {
                return this.GetAttributeValue<string>("customerneed");
            }
            set
            {
                this.OnPropertyChanging("CustomerNeed");
                this.SetAttributeValue("customerneed", value);
                this.OnPropertyChanged("CustomerNeed");
            }
        }

        /// <summary>
        /// 고객의 문제점을 다룰 수 있는 제품 및 서비스를 영업 팀에서 식별하는 데 도움이 되도록 고객의 문제점에 대한 메모를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customerpainpoints")]
        public string CustomerPainPoints
        {
            get
            {
                return this.GetAttributeValue<string>("customerpainpoints");
            }
            set
            {
                this.OnPropertyChanging("CustomerPainPoints");
                this.SetAttributeValue("customerpainpoints", value);
                this.OnPropertyChanged("CustomerPainPoints");
            }
        }

        /// <summary>
        /// 메모에 잠재 고객이 속한 회사에서 구매 결정을 내린 사람에 대한 정보를 포함할지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("decisionmaker")]
        public System.Nullable<bool> DecisionMaker
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("decisionmaker");
            }
            set
            {
                this.OnPropertyChanging("DecisionMaker");
                this.SetAttributeValue("decisionmaker", value);
                this.OnPropertyChanged("DecisionMaker");
            }
        }

        /// <summary>
        /// 영업 기회를 설명하는 추가 정보를 입력합니다(예: 판매 가능한 제품 또는 고객의 과거 구매).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 제안이 전개되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("developproposal")]
        public System.Nullable<bool> DevelopProposal
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("developproposal");
            }
            set
            {
                this.OnPropertyChanging("DevelopProposal");
                this.SetAttributeValue("developproposal", value);
                this.OnPropertyChanged("DevelopProposal");
            }
        }

        /// <summary>
        /// 고객이 특별 절감액을 받을 수 있을 경우 영업 기회의 할인 금액을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("discountamount")]
        public Microsoft.Xrm.Sdk.Money DiscountAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("discountamount");
            }
            set
            {
                this.OnPropertyChanging("DiscountAmount");
                this.SetAttributeValue("discountamount", value);
                this.OnPropertyChanged("DiscountAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [영업 기회 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("discountamount_base")]
        public Microsoft.Xrm.Sdk.Money DiscountAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("discountamount_base");
            }
        }

        /// <summary>
        /// 영업 기회의 고객에 대해 추가 절감액을 포함하도록 [제품 합계] 필드에 적용되어야 하는 할인율을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("discountpercentage")]
        public System.Nullable<decimal> DiscountPercentage
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("discountpercentage");
            }
            set
            {
                this.OnPropertyChanging("DiscountPercentage");
                this.SetAttributeValue("discountpercentage", value);
                this.OnPropertyChanged("DiscountPercentage");
            }
        }

        /// <summary>
        /// 정확한 수익을 예상하는 데 도움이 되도록 영업 기회의 예상 종료 날짜를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("estimatedclosedate")]
        public System.Nullable<System.DateTime> EstimatedCloseDate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("estimatedclosedate");
            }
            set
            {
                this.OnPropertyChanging("EstimatedCloseDate");
                this.SetAttributeValue("estimatedclosedate", value);
                this.OnPropertyChanged("EstimatedCloseDate");
            }
        }

        /// <summary>
        /// 수익 예상을 위해 영업 기회의 가치 또는 잠재적 영업을 나타내는 예상 수익 금액을 입력합니다. 이 필드는 시스템에서 입력되거나 [수익] 필드의 선택 사항에 따라 편집 가능합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("estimatedvalue")]
        public Microsoft.Xrm.Sdk.Money EstimatedValue
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("estimatedvalue");
            }
            set
            {
                this.OnPropertyChanging("EstimatedValue");
                this.SetAttributeValue("estimatedvalue", value);
                this.OnPropertyChanged("EstimatedValue");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [실제 매출] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("estimatedvalue_base")]
        public Microsoft.Xrm.Sdk.Money EstimatedValue_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("estimatedvalue_base");
            }
        }

        /// <summary>
        /// 잠재 고객의 요구와 귀하의 제공 사항 사이의 조화가 이루어졌는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("evaluatefit")]
        public System.Nullable<bool> EvaluateFit
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("evaluatefit");
            }
            set
            {
                this.OnPropertyChanging("EvaluateFit");
                this.SetAttributeValue("evaluatefit", value);
                this.OnPropertyChanged("EvaluateFit");
            }
        }

        /// <summary>
        /// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
        public System.Nullable<decimal> ExchangeRate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
            }
        }

        /// <summary>
        /// 영업 팀에서 제안 및 거래처의 응답에 대한 자세한 메모를 기록했는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("filedebrief")]
        public System.Nullable<bool> FileDebrief
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("filedebrief");
            }
            set
            {
                this.OnPropertyChanging("FileDebrief");
                this.SetAttributeValue("filedebrief", value);
                this.OnPropertyChanged("FileDebrief");
            }
        }

        /// <summary>
        /// 영업 기회의 최종 결정이 이루어진 날짜와 시간을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("finaldecisiondate")]
        public System.Nullable<System.DateTime> FinalDecisionDate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("finaldecisiondate");
            }
            set
            {
                this.OnPropertyChanging("FinalDecisionDate");
                this.SetAttributeValue("finaldecisiondate", value);
                this.OnPropertyChanged("FinalDecisionDate");
            }
        }

        /// <summary>
        /// [총 금액] 필드 계산용으로 영업 기회에 포함된 제품의 화물 또는 운송 비용을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("freightamount")]
        public Microsoft.Xrm.Sdk.Money FreightAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("freightamount");
            }
            set
            {
                this.OnPropertyChanging("FreightAmount");
                this.SetAttributeValue("freightamount", value);
                this.OnPropertyChanged("FreightAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [운송료] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("freightamount_base")]
        public Microsoft.Xrm.Sdk.Money FreightAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("freightamount_base");
            }
        }

        /// <summary>
        /// 경쟁 업체에 대한 정보가 포함되는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("identifycompetitors")]
        public System.Nullable<bool> IdentifyCompetitors
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("identifycompetitors");
            }
            set
            {
                this.OnPropertyChanging("IdentifyCompetitors");
                this.SetAttributeValue("identifycompetitors", value);
                this.OnPropertyChanged("IdentifyCompetitors");
            }
        }

        /// <summary>
        /// 이 영업 기회에 대한 고객 연락처가 식별되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("identifycustomercontacts")]
        public System.Nullable<bool> IdentifyCustomerContacts
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("identifycustomercontacts");
            }
            set
            {
                this.OnPropertyChanging("IdentifyCustomerContacts");
                this.SetAttributeValue("identifycustomercontacts", value);
                this.OnPropertyChanged("IdentifyCustomerContacts");
            }
        }

        /// <summary>
        /// 영업 기회를 추구하는 사람을 기록했는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("identifypursuitteam")]
        public System.Nullable<bool> IdentifyPursuitTeam
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("identifypursuitteam");
            }
            set
            {
                this.OnPropertyChanging("IdentifyPursuitTeam");
                this.SetAttributeValue("identifypursuitteam", value);
                this.OnPropertyChanged("IdentifyPursuitTeam");
            }
        }

        /// <summary>
        /// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
        public System.Nullable<int> ImportSequenceNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
            }
            set
            {
                this.OnPropertyChanging("ImportSequenceNumber");
                this.SetAttributeValue("importsequencenumber", value);
                this.OnPropertyChanged("ImportSequenceNumber");
            }
        }

        /// <summary>
        /// 영업 팀의 구성원이 이 잠재 고객에게 이전에 연락했는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("initialcommunication")]
        public Microsoft.Xrm.Sdk.OptionSetValue InitialCommunication
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("initialcommunication");
            }
            set
            {
                this.OnPropertyChanging("InitialCommunication");
                this.SetAttributeValue("initialcommunication", value);
                this.OnPropertyChanged("InitialCommunication");
            }
        }

        /// <summary>
        /// Commits the Opportunity Revenue to the Sales Forecast.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_addtoforecast")]
        public System.Nullable<bool> int_AddtoForecast
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("int_addtoforecast");
            }
            set
            {
                this.OnPropertyChanging("int_AddtoForecast");
                this.SetAttributeValue("int_addtoforecast", value);
                this.OnPropertyChanged("int_AddtoForecast");
            }
        }

        /// <summary>
        /// Shows whether a discount has been approved for an Opportunity.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_discountapproved")]
        public System.Nullable<bool> int_DiscountApproved
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("int_discountapproved");
            }
            set
            {
                this.OnPropertyChanging("int_DiscountApproved");
                this.SetAttributeValue("int_discountapproved", value);
                this.OnPropertyChanged("int_DiscountApproved");
            }
        }

        /// <summary>
        /// Shows the forecasted revenue for an Opportunity.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_forecast")]
        public Microsoft.Xrm.Sdk.Money int_Forecast
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("int_forecast");
            }
            set
            {
                this.OnPropertyChanging("int_Forecast");
                this.SetAttributeValue("int_forecast", value);
                this.OnPropertyChanged("int_Forecast");
            }
        }

        /// <summary>
        /// 기본 통화의 예측 값입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_forecast_base")]
        public Microsoft.Xrm.Sdk.Money int_forecast_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("int_forecast_base");
            }
        }

        /// <summary>
        /// 영업 기회의 예상 수익이 입력한 제품에 따라 자동으로 계산될지, 아니면 사용자가 직접 입력할지를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isrevenuesystemcalculated")]
        public System.Nullable<bool> IsRevenueSystemCalculated
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isrevenuesystemcalculated");
            }
            set
            {
                this.OnPropertyChanging("IsRevenueSystemCalculated");
                this.SetAttributeValue("isrevenuesystemcalculated", value);
                this.OnPropertyChanged("IsRevenueSystemCalculated");
            }
        }

        /// <summary>
        /// 마지막 보류 중 시간의 날짜 시간 스탬프가 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
        public System.Nullable<System.DateTime> LastOnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
            }
            set
            {
                this.OnPropertyChanging("LastOnHoldTime");
                this.SetAttributeValue("lastonholdtime", value);
                this.OnPropertyChanged("LastOnHoldTime");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// 영업 기회를 담당하는 거래처 관리자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_accountmanagerid")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_AccountManagerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_accountmanagerid");
            }
            set
            {
                this.OnPropertyChanging("msdyn_AccountManagerId");
                this.SetAttributeValue("msdyn_accountmanagerid", value);
                this.OnPropertyChanged("msdyn_AccountManagerId");
            }
        }

        /// <summary>
        /// 영업 기회를 담당하는 조직 구성 단위입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_contractorganizationalunitid")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_ContractOrganizationalUnitId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_contractorganizationalunitid");
            }
            set
            {
                this.OnPropertyChanging("msdyn_ContractOrganizationalUnitId");
                this.SetAttributeValue("msdyn_contractorganizationalunitid", value);
                this.OnPropertyChanged("msdyn_ContractOrganizationalUnitId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_ordertype")]
        public Microsoft.Xrm.Sdk.OptionSetValue msdyn_OrderType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("msdyn_ordertype");
            }
            set
            {
                this.OnPropertyChanging("msdyn_OrderType");
                this.SetAttributeValue("msdyn_ordertype", value);
                this.OnPropertyChanged("msdyn_OrderType");
            }
        }

        /// <summary>
        /// 영업 기회에 연결된 작업 주문 유형의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_workordertype")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_WorkOrderType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_workordertype");
            }
            set
            {
                this.OnPropertyChanging("msdyn_WorkOrderType");
                this.SetAttributeValue("msdyn_workordertype", value);
                this.OnPropertyChanged("msdyn_WorkOrderType");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 주제 또는 설명하는 이름을 입력합니다(예: 예상 주문 또는 회사 이름).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetAttributeValue<string>("name");
            }
            set
            {
                this.OnPropertyChanging("Name");
                this.SetAttributeValue("name", value);
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// 잠재 고객이 속한 회사에 대한 요구 수준을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("need")]
        public Microsoft.Xrm.Sdk.OptionSetValue Need
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("need");
            }
            set
            {
                this.OnPropertyChanging("Need");
                this.SetAttributeValue("need", value);
                this.OnPropertyChanged("Need");
            }
        }

        /// <summary>
        /// Field to be removed in future release. Current sample data dependencies exist.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_addtoforecast")]
        public System.Nullable<bool> new_AddtoForecast
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("new_addtoforecast");
            }
            set
            {
                this.OnPropertyChanging("new_AddtoForecast");
                this.SetAttributeValue("new_addtoforecast", value);
                this.OnPropertyChanged("new_AddtoForecast");
            }
        }

        /// <summary>
        /// Field to be removed in future release. Current sample data dependencies exist.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_forecast")]
        public Microsoft.Xrm.Sdk.Money new_Forecast
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("new_forecast");
            }
            set
            {
                this.OnPropertyChanging("new_Forecast");
                this.SetAttributeValue("new_forecast", value);
                this.OnPropertyChanged("new_Forecast");
            }
        }

        /// <summary>
        /// Field to be removed in future release. Current sample data dependencies exist.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_forecast_base")]
        public Microsoft.Xrm.Sdk.Money new_forecast_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("new_forecast_base");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("new_p_step")]
        public Microsoft.Xrm.Sdk.OptionSetValue new_p_step
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("new_p_step");
            }
            set
            {
                this.OnPropertyChanging("new_p_step");
                this.SetAttributeValue("new_p_step", value);
                this.OnPropertyChanged("new_p_step");
            }
        }

        /// <summary>
        /// 영업 기회가 보류 중인 기간(분)을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
        public System.Nullable<int> OnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
            }
        }

        /// <summary>
        /// 영업 기회의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opportunityid")]
        public System.Nullable<System.Guid> OpportunityId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("opportunityid");
            }
            set
            {
                this.OnPropertyChanging("OpportunityId");
                this.SetAttributeValue("opportunityid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("OpportunityId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opportunityid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.OpportunityId = value;
            }
        }

        /// <summary>
        /// 수익, 고객 상태 또는 종료 가능성에 따라 영업 기회의 예상 가치 또는 우선 순위를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("opportunityratingcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue OpportunityRatingCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("opportunityratingcode");
            }
            set
            {
                this.OnPropertyChanging("OpportunityRatingCode");
                this.SetAttributeValue("opportunityratingcode", value);
                this.OnPropertyChanged("OpportunityRatingCode");
            }
        }

        /// <summary>
        /// 보고 및 분석용으로 영업 기회가 만들어진 잠재 고객을 선택합니다. 변환된 잠재 고객이 영업 기회를 만들 경우, 영업 기회가 만들어지고 올바른 잠재 고객이 기본값이 된 후에 필드는 읽기 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("originatingleadid")]
        public Microsoft.Xrm.Sdk.EntityReference OriginatingLeadId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("originatingleadid");
            }
            set
            {
                this.OnPropertyChanging("OriginatingLeadId");
                this.SetAttributeValue("originatingleadid", value);
                this.OnPropertyChanged("OriginatingLeadId");
            }
        }

        /// <summary>
        /// 레코드를 마이그레이션한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
        public System.Nullable<System.DateTime> OverriddenCreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
            }
            set
            {
                this.OnPropertyChanging("OverriddenCreatedOn");
                this.SetAttributeValue("overriddencreatedon", value);
                this.OnPropertyChanged("OverriddenCreatedOn");
            }
        }

        /// <summary>
        /// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
            set
            {
                this.OnPropertyChanging("OwnerId");
                this.SetAttributeValue("ownerid", value);
                this.OnPropertyChanged("OwnerId");
            }
        }

        /// <summary>
        /// 영업 기회를 담당하는 사업부의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
        public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
            }
        }

        /// <summary>
        /// 영업 기회를 담당하는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
        public Microsoft.Xrm.Sdk.EntityReference OwningTeam
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
            }
        }

        /// <summary>
        /// 영업 기회를 담당하는 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
        public Microsoft.Xrm.Sdk.EntityReference OwningUser
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
            }
        }

        /// <summary>
        /// 관계가 보고서 및 분석표에 표시되고 추가 정보(예: 재무 정보 및 활동)에 대한 퀵 링크를 제공하도록 이 영업 기회를 연결할 거래처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentaccountid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentAccountId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentaccountid");
            }
            set
            {
                this.OnPropertyChanging("ParentAccountId");
                this.SetAttributeValue("parentaccountid", value);
                this.OnPropertyChanged("ParentAccountId");
            }
        }

        /// <summary>
        /// 관계가 보고서 및 분석표에 표시되도록 이 영업 기회를 연결하는 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentcontactid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentcontactid");
            }
            set
            {
                this.OnPropertyChanging("ParentContactId");
                this.SetAttributeValue("parentcontactid", value);
                this.OnPropertyChanged("ParentContactId");
            }
        }

        /// <summary>
        /// 영업 기회가 워크플로 규칙에 관여하는지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("participatesinworkflow")]
        public System.Nullable<bool> ParticipatesInWorkflow
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("participatesinworkflow");
            }
            set
            {
                this.OnPropertyChanging("ParticipatesInWorkflow");
                this.SetAttributeValue("participatesinworkflow", value);
                this.OnPropertyChanged("ParticipatesInWorkflow");
            }
        }

        /// <summary>
        /// 최종 제안이 거래처에 제시되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("presentfinalproposal")]
        public System.Nullable<bool> PresentFinalProposal
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("presentfinalproposal");
            }
            set
            {
                this.OnPropertyChanging("PresentFinalProposal");
                this.SetAttributeValue("presentfinalproposal", value);
                this.OnPropertyChanged("PresentFinalProposal");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 제안이 거래처에 제시되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("presentproposal")]
        public System.Nullable<bool> PresentProposal
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("presentproposal");
            }
            set
            {
                this.OnPropertyChanging("PresentProposal");
                this.SetAttributeValue("presentproposal", value);
                this.OnPropertyChanged("PresentProposal");
            }
        }

        /// <summary>
        /// 캠페인과 연관된 제품이 올바른 가격으로 제공되도록 이 레코드와 연관된 가격표를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pricelevelid")]
        public Microsoft.Xrm.Sdk.EntityReference PriceLevelId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("pricelevelid");
            }
            set
            {
                this.OnPropertyChanging("PriceLevelId");
                this.SetAttributeValue("pricelevelid", value);
                this.OnPropertyChanged("PriceLevelId");
            }
        }

        /// <summary>
        /// 영업 기회의 가격 산정 오류입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pricingerrorcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PricingErrorCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("pricingerrorcode");
            }
            set
            {
                this.OnPropertyChanging("PricingErrorCode");
                this.SetAttributeValue("pricingerrorcode", value);
                this.OnPropertyChanged("PricingErrorCode");
            }
        }

        /// <summary>
        /// 선호 고객 또는 주요 문제를 빠르게 처리하도록 우선 순위를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PriorityCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("prioritycode");
            }
            set
            {
                this.OnPropertyChanging("PriorityCode");
                this.SetAttributeValue("prioritycode", value);
                this.OnPropertyChanged("PriorityCode");
            }
        }

        /// <summary>
        /// 프로세스의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
        public System.Nullable<System.Guid> ProcessId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
            }
            set
            {
                this.OnPropertyChanging("ProcessId");
                this.SetAttributeValue("processid", value);
                this.OnPropertyChanged("ProcessId");
            }
        }

        /// <summary>
        /// 영업 기회의 제안된 솔루션에 대한 메모를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("proposedsolution")]
        public string ProposedSolution
        {
            get
            {
                return this.GetAttributeValue<string>("proposedsolution");
            }
            set
            {
                this.OnPropertyChanging("ProposedSolution");
                this.SetAttributeValue("proposedsolution", value);
                this.OnPropertyChanged("ProposedSolution");
            }
        }

        /// <summary>
        /// 개인 또는 위원회가 잠재 고객의 구매 프로세스에 관여하는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("purchaseprocess")]
        public Microsoft.Xrm.Sdk.OptionSetValue PurchaseProcess
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("purchaseprocess");
            }
            set
            {
                this.OnPropertyChanging("PurchaseProcess");
                this.SetAttributeValue("purchaseprocess", value);
                this.OnPropertyChanged("PurchaseProcess");
            }
        }

        /// <summary>
        /// 잠재 고객이 구매하기까지 소요될 수 있는 기간을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("purchasetimeframe")]
        public Microsoft.Xrm.Sdk.OptionSetValue PurchaseTimeframe
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("purchasetimeframe");
            }
            set
            {
                this.OnPropertyChanging("PurchaseTimeframe");
                this.SetAttributeValue("purchasetimeframe", value);
                this.OnPropertyChanged("PurchaseTimeframe");
            }
        }

        /// <summary>
        /// 영업 기회 추구에 대한 결정이 내려졌는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pursuitdecision")]
        public System.Nullable<bool> PursuitDecision
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("pursuitdecision");
            }
            set
            {
                this.OnPropertyChanging("PursuitDecision");
                this.SetAttributeValue("pursuitdecision", value);
                this.OnPropertyChanged("PursuitDecision");
            }
        }

        /// <summary>
        /// 잠재 고객 선별 또는 점수에 대한 설명을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("qualificationcomments")]
        public string QualificationComments
        {
            get
            {
                return this.GetAttributeValue<string>("qualificationcomments");
            }
            set
            {
                this.OnPropertyChanging("QualificationComments");
                this.SetAttributeValue("qualificationcomments", value);
                this.OnPropertyChanged("QualificationComments");
            }
        }

        /// <summary>
        /// 영업 기회와 연관된 견적에 대한 설명을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("quotecomments")]
        public string QuoteComments
        {
            get
            {
                return this.GetAttributeValue<string>("quotecomments");
            }
            set
            {
                this.OnPropertyChanging("QuoteComments");
                this.SetAttributeValue("quotecomments", value);
                this.OnPropertyChanged("QuoteComments");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 제안 피드백을 받아 해결되었는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolvefeedback")]
        public System.Nullable<bool> ResolveFeedback
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("resolvefeedback");
            }
            set
            {
                this.OnPropertyChanging("ResolveFeedback");
                this.SetAttributeValue("resolvefeedback", value);
                this.OnPropertyChanged("ResolveFeedback");
            }
        }

        /// <summary>
        /// 이 영업 기회를 성공하기 위한 노력으로 영업 팀을 돕기 위해 이 영업 기회의 영업 스테이지를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("salesstage")]
        public Microsoft.Xrm.Sdk.OptionSetValue SalesStage
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("salesstage");
            }
            set
            {
                this.OnPropertyChanging("SalesStage");
                this.SetAttributeValue("salesstage", value);
                this.OnPropertyChanged("SalesStage");
            }
        }

        /// <summary>
        /// 영업 기회를 종료할 가능성을 나타내도록 영업 기회의 영업 프로세스 스테이지를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("salesstagecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue SalesStageCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("salesstagecode");
            }
            set
            {
                this.OnPropertyChanging("SalesStageCode");
                this.SetAttributeValue("salesstagecode", value);
                this.OnPropertyChanged("SalesStageCode");
            }
        }

        /// <summary>
        /// 잠재 고객과의 조사 후속작업 모임의 날짜와 시간을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("schedulefollowup_prospect")]
        public System.Nullable<System.DateTime> ScheduleFollowup_Prospect
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("schedulefollowup_prospect");
            }
            set
            {
                this.OnPropertyChanging("ScheduleFollowup_Prospect");
                this.SetAttributeValue("schedulefollowup_prospect", value);
                this.OnPropertyChanged("ScheduleFollowup_Prospect");
            }
        }

        /// <summary>
        /// 잠재 고객과의 선별 후속작업 모임의 날짜와 시간을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("schedulefollowup_qualify")]
        public System.Nullable<System.DateTime> ScheduleFollowup_Qualify
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("schedulefollowup_qualify");
            }
            set
            {
                this.OnPropertyChanging("ScheduleFollowup_Qualify");
                this.SetAttributeValue("schedulefollowup_qualify", value);
                this.OnPropertyChanged("ScheduleFollowup_Qualify");
            }
        }

        /// <summary>
        /// 영업 기회를 위한 제안 모임의 날짜와 시간을 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduleproposalmeeting")]
        public System.Nullable<System.DateTime> ScheduleProposalMeeting
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduleproposalmeeting");
            }
            set
            {
                this.OnPropertyChanging("ScheduleProposalMeeting");
                this.SetAttributeValue("scheduleproposalmeeting", value);
                this.OnPropertyChanged("ScheduleProposalMeeting");
            }
        }

        /// <summary>
        /// 제안 고려에 대한 감사 메시지를 거래처에 보냈는지 여부를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sendthankyounote")]
        public System.Nullable<bool> SendThankYouNote
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("sendthankyounote");
            }
            set
            {
                this.OnPropertyChanging("SendThankYouNote");
                this.SetAttributeValue("sendthankyounote", value);
                this.OnPropertyChanged("SendThankYouNote");
            }
        }

        /// <summary>
        /// 영업 기회 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
            }
            set
            {
                this.OnPropertyChanging("SLAId");
                this.SetAttributeValue("slaid", value);
                this.OnPropertyChanged("SLAId");
            }
        }

        /// <summary>
        /// 이 영업 기회에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
            }
        }

        /// <summary>
        /// 스테이지의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
        public System.Nullable<System.Guid> StageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
            }
            set
            {
                this.OnPropertyChanging("StageId");
                this.SetAttributeValue("stageid", value);
                this.OnPropertyChanged("StageId");
            }
        }

        /// <summary>
        /// 영업 기회가 시작되었는지, 성공했는지, 아니면 실패했는지를 표시합니다. 성공 및 실패한 영업 기회는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<OpportunityState> StateCode
        {
            get
            {
                Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if ((optionSet != null))
                {
                    return ((OpportunityState)(System.Enum.ToObject(typeof(OpportunityState), optionSet.Value)));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if ((value == null))
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// 영업 기회의 상태를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// 워크플로 단계의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stepid")]
        public System.Nullable<System.Guid> StepId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stepid");
            }
            set
            {
                this.OnPropertyChanging("StepId");
                this.SetAttributeValue("stepid", value);
                this.OnPropertyChanged("StepId");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 영업 기회 보유 현황의 현재 단계를 표시합니다. 워크플로에서 업데이트됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stepname")]
        public string StepName
        {
            get
            {
                return this.GetAttributeValue<string>("stepname");
            }
            set
            {
                this.OnPropertyChanging("StepName");
                this.SetAttributeValue("stepname", value);
                this.OnPropertyChanged("StepName");
            }
        }

        /// <summary>
        /// 영업 기회 종료 가능성이 있는 날짜를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timeline")]
        public Microsoft.Xrm.Sdk.OptionSetValue TimeLine
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("timeline");
            }
            set
            {
                this.OnPropertyChanging("TimeLine");
                this.SetAttributeValue("timeline", value);
                this.OnPropertyChanged("TimeLine");
            }
        }

        /// <summary>
        /// 영업 기회 레코드와 관련하여 전자 메일(읽기 및 쓰기)과 모임에 본인이 사용한 총 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timespentbymeonemailandmeetings")]
        public string TimeSpentByMeOnEmailAndMeetings
        {
            get
            {
                return this.GetAttributeValue<string>("timespentbymeonemailandmeetings");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
        public System.Nullable<int> TimeZoneRuleVersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
            }
            set
            {
                this.OnPropertyChanging("TimeZoneRuleVersionNumber");
                this.SetAttributeValue("timezoneruleversionnumber", value);
                this.OnPropertyChanged("TimeZoneRuleVersionNumber");
            }
        }

        /// <summary>
        /// 영업 기회에 대한 제품, 할인, 운송 및 세금합계로 계산된 총 금액을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totalamount")]
        public Microsoft.Xrm.Sdk.Money TotalAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totalamount");
            }
            set
            {
                this.OnPropertyChanging("TotalAmount");
                this.SetAttributeValue("totalamount", value);
                this.OnPropertyChanged("TotalAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totalamount_base")]
        public Microsoft.Xrm.Sdk.Money TotalAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totalamount_base");
            }
        }

        /// <summary>
        /// 할인액을 차감한 영업 기회의 총 제품 금액을 표시합니다. 이 값은 영업 기회의 총 금액을 계산하여 운송료 및 세금에 추가됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totalamountlessfreight")]
        public Microsoft.Xrm.Sdk.Money TotalAmountLessFreight
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totalamountlessfreight");
            }
            set
            {
                this.OnPropertyChanging("TotalAmountLessFreight");
                this.SetAttributeValue("totalamountlessfreight", value);
                this.OnPropertyChanged("TotalAmountLessFreight");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 운송료 미포함 가격] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totalamountlessfreight_base")]
        public Microsoft.Xrm.Sdk.Money TotalAmountLessFreight_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totalamountlessfreight_base");
            }
        }

        /// <summary>
        /// 영업 기회에 입력한 할인 가격 및 비율에 따라 총 할인 금액을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totaldiscountamount")]
        public Microsoft.Xrm.Sdk.Money TotalDiscountAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totaldiscountamount");
            }
            set
            {
                this.OnPropertyChanging("TotalDiscountAmount");
                this.SetAttributeValue("totaldiscountamount", value);
                this.OnPropertyChanged("TotalDiscountAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totaldiscountamount_base")]
        public Microsoft.Xrm.Sdk.Money TotalDiscountAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totaldiscountamount_base");
            }
        }

        /// <summary>
        /// 지정된 가격표와 수량에 따라 영업 기회에 포함된 모든 기존 및 직접 입력 제품 합계를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totallineitemamount")]
        public Microsoft.Xrm.Sdk.Money TotalLineItemAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totallineitemamount");
            }
            set
            {
                this.OnPropertyChanging("TotalLineItemAmount");
                this.SetAttributeValue("totallineitemamount", value);
                this.OnPropertyChanged("TotalLineItemAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 소계] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totallineitemamount_base")]
        public Microsoft.Xrm.Sdk.Money TotalLineItemAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totallineitemamount_base");
            }
        }

        /// <summary>
        /// 영업 기회에 포함된 모든 제품에 지정된 총 일반 할인 금액을 표시합니다. 이 값은 영업 기회의 [총 소계] 필드에 반영되며 영업 기회에 지정된 모든 할인 금액 또는 비율에 추가됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totallineitemdiscountamount")]
        public Microsoft.Xrm.Sdk.Money TotalLineItemDiscountAmount
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totallineitemdiscountamount");
            }
            set
            {
                this.OnPropertyChanging("TotalLineItemDiscountAmount");
                this.SetAttributeValue("totallineitemdiscountamount", value);
                this.OnPropertyChanged("TotalLineItemDiscountAmount");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 품목 할인 금액] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totallineitemdiscountamount_base")]
        public Microsoft.Xrm.Sdk.Money TotalLineItemDiscountAmount_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totallineitemdiscountamount_base");
            }
        }

        /// <summary>
        /// 영업 기회에 포함된 모든 제품에 지정된 총 세금을 표시합니다. 이 값은 영업 기회에 대한 [총 금액] 필드 계산에 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totaltax")]
        public Microsoft.Xrm.Sdk.Money TotalTax
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totaltax");
            }
            set
            {
                this.OnPropertyChanging("TotalTax");
                this.SetAttributeValue("totaltax", value);
                this.OnPropertyChanged("TotalTax");
            }
        }

        /// <summary>
        /// 보고용으로 시스템의 기본 통화로 변환된 [총 세금] 필드를 표시합니다. [통화] 영역에 지정된 환율을 사용하여 계산됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totaltax_base")]
        public Microsoft.Xrm.Sdk.Money TotalTax_Base
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("totaltax_base");
            }
        }

        /// <summary>
        /// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
        public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
            }
            set
            {
                this.OnPropertyChanging("TransactionCurrencyId");
                this.SetAttributeValue("transactioncurrencyid", value);
                this.OnPropertyChanged("TransactionCurrencyId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
        public string TraversedPath
        {
            get
            {
                return this.GetAttributeValue<string>("traversedpath");
            }
            set
            {
                this.OnPropertyChanging("TraversedPath");
                this.SetAttributeValue("traversedpath", value);
                this.OnPropertyChanged("TraversedPath");
            }
        }

        /// <summary>
        /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
        public System.Nullable<int> UTCConversionTimeZoneCode
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
            }
            set
            {
                this.OnPropertyChanging("UTCConversionTimeZoneCode");
                this.SetAttributeValue("utcconversiontimezonecode", value);
                this.OnPropertyChanged("UTCConversionTimeZoneCode");
            }
        }

        /// <summary>
        /// 영업 기회의 버전 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }
        #endregion Field

        //새 레코드를 생성할 때 값을 지정해야하는 데 이 값의 타입을 서버에 커넥트한 후 opportunity의 타입을 모두 가져와서 dictionary의 키와 비교한 후 타입에 맞게 값을 넣어 create한다. 
        ///<seealso cref="https://stackoverflow.com/a/18293398"/>
        public Guid CreateRecord(IOrganizationService service, EntityAttributeCollection entityAttirbutes)
        {
            Entity e = new Entity("opportunity");

            e.Attributes["Name"] = "help";
            Account ee = new Account()
            {
                Name = "help",

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
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("incident")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class Incident : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        #region Field
        [System.Runtime.Serialization.DataContractAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
        public enum IncidentState
        {

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Active = 0,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Resolved = 1,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Canceled = 2,
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Incident() :
                base(EntityLogicalName)
        {
        }

        public const string EntityLogicalName = "incident";

        public const int EntityTypeCode = 112;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChanged(string propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 서비스 케이스와 연관된 거래처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("accountid")]
        public Microsoft.Xrm.Sdk.EntityReference AccountId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("accountid");
            }
        }

        /// <summary>
        /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitiescomplete")]
        public System.Nullable<bool> ActivitiesComplete
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("activitiescomplete");
            }
            set
            {
                this.OnPropertyChanging("ActivitiesComplete");
                this.SetAttributeValue("activitiescomplete", value);
                this.OnPropertyChanged("ActivitiesComplete");
            }
        }

        /// <summary>
        /// 서비스 케이스를 해결하는 데 실제로 필요한 서비스 단위 수를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualserviceunits")]
        public System.Nullable<int> ActualServiceUnits
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("actualserviceunits");
            }
            set
            {
                this.OnPropertyChanging("ActualServiceUnits");
                this.SetAttributeValue("actualserviceunits", value);
                this.OnPropertyChanged("ActualServiceUnits");
            }
        }

        /// <summary>
        /// 서비스 케이스에 대해 고객에게 청구된 서비스 단위 수를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("billedserviceunits")]
        public System.Nullable<int> BilledServiceUnits
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("billedserviceunits");
            }
            set
            {
                this.OnPropertyChanging("BilledServiceUnits");
                this.SetAttributeValue("billedserviceunits", value);
                this.OnPropertyChanged("BilledServiceUnits");
            }
        }

        /// <summary>
        /// 프로필이 차단되었는지 여부에 대한 세부 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("blockedprofile")]
        public System.Nullable<bool> BlockedProfile
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("blockedprofile");
            }
            set
            {
                this.OnPropertyChanging("BlockedProfile");
                this.SetAttributeValue("blockedprofile", value);
                this.OnPropertyChanged("BlockedProfile");
            }
        }

        /// <summary>
        /// 보고 및 분석용으로 서비스 케이스에 대한 연락처가 생성된 방법을 선택합니다(예: 전자 메일, 전화 또는 웹).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("caseorigincode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CaseOriginCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("caseorigincode");
            }
            set
            {
                this.OnPropertyChanging("CaseOriginCode");
                this.SetAttributeValue("caseorigincode", value);
                this.OnPropertyChanged("CaseOriginCode");
            }
        }

        /// <summary>
        /// 서비스 케이스 라우팅 및 분석용으로 문제를 식별하는 서비스 케이스 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("casetypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CaseTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("casetypecode");
            }
            set
            {
                this.OnPropertyChanging("CaseTypeCode");
                this.SetAttributeValue("casetypecode", value);
                this.OnPropertyChanged("CaseTypeCode");
            }
        }

        /// <summary>
        /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("checkemail")]
        public System.Nullable<bool> CheckEmail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("checkemail");
            }
            set
            {
                this.OnPropertyChanging("CheckEmail");
                this.SetAttributeValue("checkemail", value);
                this.OnPropertyChanged("CheckEmail");
            }
        }

        /// <summary>
        /// 서비스 케이스와 연관된 연락처의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contactid")]
        public Microsoft.Xrm.Sdk.EntityReference ContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contactid");
            }
        }

        /// <summary>
        /// 고객에게 올바르게 부과되도록 서비스 케이스가 기록되어야 하는 계약 내용을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractdetailid")]
        public Microsoft.Xrm.Sdk.EntityReference ContractDetailId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contractdetailid");
            }
            set
            {
                this.OnPropertyChanging("ContractDetailId");
                this.SetAttributeValue("contractdetailid", value);
                this.OnPropertyChanged("ContractDetailId");
            }
        }

        /// <summary>
        /// 고객이 지원 서비스를 받을 수 있도록 서비스 케이스가 기록되어야 하는 서비스 계약을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractid")]
        public Microsoft.Xrm.Sdk.EntityReference ContractId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contractid");
            }
            set
            {
                this.OnPropertyChanging("ContractId");
                this.SetAttributeValue("contractid", value);
                this.OnPropertyChanged("ContractId");
            }
        }

        /// <summary>
        /// 서비스 케이스가 올바르게 처리되도록 서비스 케이스의 서비스 수준을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contractservicelevelcode")]
        public Microsoft.Xrm.Sdk.OptionSetValue ContractServiceLevelCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("contractservicelevelcode");
            }
            set
            {
                this.OnPropertyChanging("ContractServiceLevelCode");
                this.SetAttributeValue("contractservicelevelcode", value);
                this.OnPropertyChanged("ContractServiceLevelCode");
            }
        }

        /// <summary>
        /// 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// 레코드를 만든 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 만든 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 만든 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// 고객 지원 담당자가 고객에게 연락할지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customercontacted")]
        public System.Nullable<bool> CustomerContacted
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("customercontacted");
            }
            set
            {
                this.OnPropertyChanging("CustomerContacted");
                this.SetAttributeValue("customercontacted", value);
                this.OnPropertyChanged("CustomerContacted");
            }
        }

        /// <summary>
        /// 거래처 정보, 활동, 영업 기회와 같은 추가 고객 정보에 대한 퀵 링크를 제공하는 고객 거래처 또는 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customerid")]
        public Microsoft.Xrm.Sdk.EntityReference CustomerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("customerid");
            }
            set
            {
                this.OnPropertyChanging("CustomerId");
                this.SetAttributeValue("customerid", value);
                this.OnPropertyChanged("CustomerId");
            }
        }

        /// <summary>
        /// 서비스 케이스 처리 및 해결에 대한 고객의 만족도 수준을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customersatisfactioncode")]
        public Microsoft.Xrm.Sdk.OptionSetValue CustomerSatisfactionCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("customersatisfactioncode");
            }
            set
            {
                this.OnPropertyChanging("CustomerSatisfactionCode");
                this.SetAttributeValue("customersatisfactioncode", value);
                this.OnPropertyChanged("CustomerSatisfactionCode");
            }
        }

        /// <summary>
        /// 연결된 권리 유형의 조건을 줄일지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("decremententitlementterm")]
        public System.Nullable<bool> DecrementEntitlementTerm
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("decremententitlementterm");
            }
            set
            {
                this.OnPropertyChanging("DecrementEntitlementTerm");
                this.SetAttributeValue("decremententitlementterm", value);
                this.OnPropertyChanged("DecrementEntitlementTerm");
            }
        }

        /// <summary>
        /// 서비스 케이스 해결 시 서비스 팀을 지원하도록 서비스 케이스를 설명하는 추가 정보를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// 서비스 케이스에 적용되는 권리 유형을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entitlementid")]
        public Microsoft.Xrm.Sdk.EntityReference EntitlementId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("entitlementid");
            }
            set
            {
                this.OnPropertyChanging("EntitlementId");
                this.SetAttributeValue("entitlementid", value);
                this.OnPropertyChanged("EntitlementId");
            }
        }

        /// <summary>
        /// 엔터티의 기본 이미지입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage")]
        public byte[] EntityImage
        {
            get
            {
                return this.GetAttributeValue<byte[]>("entityimage");
            }
            set
            {
                this.OnPropertyChanging("EntityImage");
                this.SetAttributeValue("entityimage", value);
                this.OnPropertyChanged("EntityImage");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_timestamp")]
        public System.Nullable<long> EntityImage_Timestamp
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("entityimage_timestamp");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimage_url")]
        public string EntityImage_URL
        {
            get
            {
                return this.GetAttributeValue<string>("entityimage_url");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entityimageid")]
        public System.Nullable<System.Guid> EntityImageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("entityimageid");
            }
        }

        /// <summary>
        /// 서비스 케이스가 에스컬레이션된 날짜 및 시간을 나타냅니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("escalatedon")]
        public System.Nullable<System.DateTime> EscalatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("escalatedon");
            }
        }

        /// <summary>
        /// 레코드의 통화 환율을 표시합니다. 환율은 레코드의 모든 금액 필드를 현지 통화에서 시스템 기본 통화로 변환하는 데 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
        public System.Nullable<decimal> ExchangeRate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
            }
        }

        /// <summary>
        /// 채워진 고객에 대한 기존 서비스 케이스를 선택하십시오. 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("existingcase")]
        public Microsoft.Xrm.Sdk.EntityReference ExistingCase
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("existingcase");
            }
            set
            {
                this.OnPropertyChanging("ExistingCase");
                this.SetAttributeValue("existingcase", value);
                this.OnPropertyChanged("ExistingCase");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponsebykpiid")]
        public Microsoft.Xrm.Sdk.EntityReference FirstResponseByKPIId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("firstresponsebykpiid");
            }
            set
            {
                this.OnPropertyChanging("FirstResponseByKPIId");
                this.SetAttributeValue("firstresponsebykpiid", value);
                this.OnPropertyChanged("FirstResponseByKPIId");
            }
        }

        /// <summary>
        /// 첫 응답을 보냈는지 여부를 나타냅니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponsesent")]
        public System.Nullable<bool> FirstResponseSent
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("firstresponsesent");
            }
            set
            {
                this.OnPropertyChanging("FirstResponseSent");
                this.SetAttributeValue("firstresponsesent", value);
                this.OnPropertyChanged("FirstResponseSent");
            }
        }

        /// <summary>
        /// SLA 조건에 따라 서비스 케이스에 대한 첫 응답 시간의 상태를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("firstresponseslastatus")]
        public Microsoft.Xrm.Sdk.OptionSetValue FirstResponseSLAStatus
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("firstresponseslastatus");
            }
            set
            {
                this.OnPropertyChanging("FirstResponseSLAStatus");
                this.SetAttributeValue("firstresponseslastatus", value);
                this.OnPropertyChanged("FirstResponseSLAStatus");
            }
        }

        /// <summary>
        /// 고객 지원 담당자가 이 서비스 케이스의 고객에 대한 후속작업을 수행해야 하는 날짜를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followupby")]
        public System.Nullable<System.DateTime> FollowupBy
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("followupby");
            }
            set
            {
                this.OnPropertyChanging("FollowupBy");
                this.SetAttributeValue("followupby", value);
                this.OnPropertyChanged("FollowupBy");
            }
        }

        /// <summary>
        /// 이 특성은 샘플 서비스 비즈니스 프로세스에 사용됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("followuptaskcreated")]
        public System.Nullable<bool> FollowUpTaskCreated
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("followuptaskcreated");
            }
            set
            {
                this.OnPropertyChanging("FollowUpTaskCreated");
                this.SetAttributeValue("followuptaskcreated", value);
                this.OnPropertyChanged("FollowUpTaskCreated");
            }
        }

        /// <summary>
        /// 이 레코드를 만든 데이터 가져오기 또는 데이터 마이그레이션의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
        public System.Nullable<int> ImportSequenceNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
            }
            set
            {
                this.OnPropertyChanging("ImportSequenceNumber");
                this.SetAttributeValue("importsequencenumber", value);
                this.OnPropertyChanged("ImportSequenceNumber");
            }
        }

        /// <summary>
        /// 서비스 케이스의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentid")]
        public System.Nullable<System.Guid> IncidentId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("incidentid");
            }
            set
            {
                this.OnPropertyChanging("IncidentId");
                this.SetAttributeValue("incidentid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("IncidentId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.IncidentId = value;
            }
        }

        /// <summary>
        /// 서비스 팀 구성원이 서비스 케이스를 검토하거나 전송할 때 서비스 팀 구성원을 지원하도록 서비스 케이스에 대해 서비스 프로세스의 현재 스테이지를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("incidentstagecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue IncidentStageCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("incidentstagecode");
            }
            set
            {
                this.OnPropertyChanging("IncidentStageCode");
                this.SetAttributeValue("incidentstagecode", value);
                this.OnPropertyChanged("IncidentStageCode");
            }
        }

        /// <summary>
        /// NetBreeze의 영향도를 포함합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("influencescore")]
        public System.Nullable<double> InfluenceScore
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("influencescore");
            }
            set
            {
                this.OnPropertyChanging("InfluenceScore");
                this.SetAttributeValue("influencescore", value);
                this.OnPropertyChanged("InfluenceScore");
            }
        }

        /// <summary>
        /// Shows customer satisfaction by tracking effort required by the customer. Low scores typically mean higher customer satisfaction as the customer had to travel through less channels to find a resolution
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_customereffort")]
        public Microsoft.Xrm.Sdk.OptionSetValue int_CustomerEffort
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("int_customereffort");
            }
            set
            {
                this.OnPropertyChanging("int_CustomerEffort");
                this.SetAttributeValue("int_customereffort", value);
                this.OnPropertyChanged("int_CustomerEffort");
            }
        }

        /// <summary>
        /// Identifies whether a customer is willing to participate in a customer satisfaction survey.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_surveryparticipation")]
        public System.Nullable<bool> int_SurveryParticipation
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("int_surveryparticipation");
            }
            set
            {
                this.OnPropertyChanging("int_SurveryParticipation");
                this.SetAttributeValue("int_surveryparticipation", value);
                this.OnPropertyChanged("int_SurveryParticipation");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_surveyparticipation")]
        public System.Nullable<bool> int_SurveyParticipation
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("int_surveyparticipation");
            }
            set
            {
                this.OnPropertyChanging("int_SurveyParticipation");
                this.SetAttributeValue("int_surveyparticipation", value);
                this.OnPropertyChanged("int_SurveyParticipation");
            }
        }

        /// <summary>
        /// Mark Yes if an opportunity exists to sell additional products or services to the customer.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("int_upsellreferral")]
        public System.Nullable<bool> int_UpSellReferral
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("int_upsellreferral");
            }
            set
            {
                this.OnPropertyChanging("int_UpSellReferral");
                this.SetAttributeValue("int_upsellreferral", value);
                this.OnPropertyChanged("int_UpSellReferral");
            }
        }

        /// <summary>
        /// 시스템 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdecrementing")]
        public System.Nullable<bool> IsDecrementing
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isdecrementing");
            }
            set
            {
                this.OnPropertyChanging("IsDecrementing");
                this.SetAttributeValue("isdecrementing", value);
                this.OnPropertyChanged("IsDecrementing");
            }
        }

        /// <summary>
        /// 서비스 케이스가 에스컬레이션되었는지 여부를 나타냅니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isescalated")]
        public System.Nullable<bool> IsEscalated
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isescalated");
            }
            set
            {
                this.OnPropertyChanging("IsEscalated");
                this.SetAttributeValue("isescalated", value);
                this.OnPropertyChanged("IsEscalated");
            }
        }

        /// <summary>
        /// 고객에 대한 후속작업 또는 조사 시 참조용으로 추가 정보 또는 서비스 케이스 해결 방법을 포함하는 문서를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kbarticleid")]
        public Microsoft.Xrm.Sdk.EntityReference KbArticleId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("kbarticleid");
            }
            set
            {
                this.OnPropertyChanging("KbArticleId");
                this.SetAttributeValue("kbarticleid", value);
                this.OnPropertyChanged("KbArticleId");
            }
        }

        /// <summary>
        /// 마지막 보류 중 시간의 날짜 시간 스탬프가 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
        public System.Nullable<System.DateTime> LastOnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
            }
            set
            {
                this.OnPropertyChanging("LastOnHoldTime");
                this.SetAttributeValue("lastonholdtime", value);
                this.OnPropertyChanged("LastOnHoldTime");
            }
        }

        /// <summary>
        /// 현재 서비스 케이스가 병합된 기본 서비스 케이스를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("masterid")]
        public Microsoft.Xrm.Sdk.EntityReference MasterId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("masterid");
            }
            set
            {
                this.OnPropertyChanging("MasterId");
                this.SetAttributeValue("masterid", value);
                this.OnPropertyChanged("MasterId");
            }
        }

        /// <summary>
        /// 문제가 다른 문제와 병합되었는지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("merged")]
        public System.Nullable<bool> Merged
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("merged");
            }
        }

        /// <summary>
        /// 게시물이 공개 메시지인지 아니면 개인 메시지인지를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("messagetypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue MessageTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("messagetypecode");
            }
            set
            {
                this.OnPropertyChanging("MessageTypeCode");
                this.SetAttributeValue("messagetypecode", value);
                this.OnPropertyChanged("MessageTypeCode");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// 레코드를 수정한 외부 대상을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyexternalparty")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedByExternalParty
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedbyexternalparty");
            }
        }

        /// <summary>
        /// 레코드를 마지막으로 업데이트한 날짜와 시간을 표시합니다. 날짜와 시간은 Microsoft Dynamics 365 옵션에서 선택한 표준 시간대로 표시됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// 다른 사용자 대신 레코드를 마지막으로 업데이트한 사람을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// 서비스 케이스에 연결된 문제 유형의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_incidenttype")]
        public Microsoft.Xrm.Sdk.EntityReference msdyn_IncidentType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("msdyn_incidenttype");
            }
            set
            {
                this.OnPropertyChanging("msdyn_IncidentType");
                this.SetAttributeValue("msdyn_incidenttype", value);
                this.OnPropertyChanged("msdyn_IncidentType");
            }
        }

        /// <summary>
        /// 문제와 연관된 하위 문제 수입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberofchildincidents")]
        public System.Nullable<int> NumberOfChildIncidents
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("numberofchildincidents");
            }
        }

        /// <summary>
        /// 서비스 케이스가 보류 중인 기간(분)을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
        public System.Nullable<int> OnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
            }
        }

        /// <summary>
        /// 레코드를 마이그레이션한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
        public System.Nullable<System.DateTime> OverriddenCreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
            }
            set
            {
                this.OnPropertyChanging("OverriddenCreatedOn");
                this.SetAttributeValue("overriddencreatedon", value);
                this.OnPropertyChanged("OverriddenCreatedOn");
            }
        }

        /// <summary>
        /// 레코드를 관리하도록 할당된 사용자 또는 팀을 입력합니다. 이 필드는 레코드가 다른 사용자에게 할당될 때마다 업데이트됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
            set
            {
                this.OnPropertyChanging("OwnerId");
                this.SetAttributeValue("ownerid", value);
                this.OnPropertyChanged("OwnerId");
            }
        }

        /// <summary>
        /// 서비스 케이스를 담당하는 사업부의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
        public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
            }
        }

        /// <summary>
        /// 서비스 케이스를 담당하는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
        public Microsoft.Xrm.Sdk.EntityReference OwningTeam
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
            }
        }

        /// <summary>
        /// 서비스 케이스를 담당하는 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
        public Microsoft.Xrm.Sdk.EntityReference OwningUser
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
            }
        }

        /// <summary>
        /// 서비스 케이스의 상위 서비스 케이스를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentcaseid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentCaseId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentcaseid");
            }
            set
            {
                this.OnPropertyChanging("ParentCaseId");
                this.SetAttributeValue("parentcaseid", value);
                this.OnPropertyChanged("ParentCaseId");
            }
        }

        /// <summary>
        /// 이 서비스 케이스의 기본 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primarycontactid")]
        public Microsoft.Xrm.Sdk.EntityReference PrimaryContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("primarycontactid");
            }
            set
            {
                this.OnPropertyChanging("PrimaryContactId");
                this.SetAttributeValue("primarycontactid", value);
                this.OnPropertyChanged("PrimaryContactId");
            }
        }

        /// <summary>
        /// 선호 고객 또는 주요 문제를 빠르게 처리하도록 우선 순위를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PriorityCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("prioritycode");
            }
            set
            {
                this.OnPropertyChanging("PriorityCode");
                this.SetAttributeValue("prioritycode", value);
                this.OnPropertyChanged("PriorityCode");
            }
        }

        /// <summary>
        /// 프로세스의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
        public System.Nullable<System.Guid> ProcessId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
            }
            set
            {
                this.OnPropertyChanging("ProcessId");
                this.SetAttributeValue("processid", value);
                this.OnPropertyChanged("ProcessId");
            }
        }

        /// <summary>
        /// 보증, 서비스 또는 기타 제품 문제를 식별하고 각 제품의 문제 수를 보고할 수 있도록 서비스 케이스와 연관된 제품을 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productid")]
        public Microsoft.Xrm.Sdk.EntityReference ProductId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("productid");
            }
            set
            {
                this.OnPropertyChanging("ProductId");
                this.SetAttributeValue("productid", value);
                this.OnPropertyChanged("ProductId");
            }
        }

        /// <summary>
        /// 제품 당 서비스 케이스 수를 보고할 수 있도록 이 서비스 케이스와 연관된 제품 일련 번호를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productserialnumber")]
        public string ProductSerialNumber
        {
            get
            {
                return this.GetAttributeValue<string>("productserialnumber");
            }
            set
            {
                this.OnPropertyChanging("ProductSerialNumber");
                this.SetAttributeValue("productserialnumber", value);
                this.OnPropertyChanged("ProductSerialNumber");
            }
        }

        /// <summary>
        /// 서비스 케이스가 해결되어야 하는 날짜를 입력합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolveby")]
        public System.Nullable<System.DateTime> ResolveBy
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("resolveby");
            }
            set
            {
                this.OnPropertyChanging("ResolveBy");
                this.SetAttributeValue("resolveby", value);
                this.OnPropertyChanged("ResolveBy");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolvebykpiid")]
        public Microsoft.Xrm.Sdk.EntityReference ResolveByKPIId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("resolvebykpiid");
            }
            set
            {
                this.OnPropertyChanging("ResolveByKPIId");
                this.SetAttributeValue("resolvebykpiid", value);
                this.OnPropertyChanged("ResolveByKPIId");
            }
        }

        /// <summary>
        /// SLA 조건에 따라 서비스 케이스에 대한 해결 시간의 상태를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resolvebyslastatus")]
        public Microsoft.Xrm.Sdk.OptionSetValue ResolveBySLAStatus
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("resolvebyslastatus");
            }
            set
            {
                this.OnPropertyChanging("ResolveBySLAStatus");
                this.SetAttributeValue("resolvebyslastatus", value);
                this.OnPropertyChanged("ResolveBySLAStatus");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("responseby")]
        public System.Nullable<System.DateTime> ResponseBy
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("responseby");
            }
            set
            {
                this.OnPropertyChanging("ResponseBy");
                this.SetAttributeValue("responseby", value);
                this.OnPropertyChanged("ResponseBy");
            }
        }

        /// <summary>
        /// 서비스 케이스를 해결하는 데도 도움이 되는 추가 고객 연락처를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("responsiblecontactid")]
        [System.ObsoleteAttribute()]
        public Microsoft.Xrm.Sdk.EntityReference ResponsibleContactId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("responsiblecontactid");
            }
            set
            {
                this.OnPropertyChanging("ResponsibleContactId");
                this.SetAttributeValue("responsiblecontactid", value);
                this.OnPropertyChanged("ResponsibleContactId");
            }
        }

        /// <summary>
        /// 문제가 큐로 회람되었는지 여부를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("routecase")]
        public System.Nullable<bool> RouteCase
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("routecase");
            }
            set
            {
                this.OnPropertyChanging("RouteCase");
                this.SetAttributeValue("routecase", value);
                this.OnPropertyChanged("RouteCase");
            }
        }

        /// <summary>
        /// 소셜 게시물에서 발생하는 부정적, 중립적, 긍정적 관심도와 연결된 단어를 평가한 후 산출된 값입니다. 관심도 정보는 숫자 값으로 보고될 수도 있습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sentimentvalue")]
        public System.Nullable<double> SentimentValue
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("sentimentvalue");
            }
            set
            {
                this.OnPropertyChanging("SentimentValue");
                this.SetAttributeValue("sentimentvalue", value);
                this.OnPropertyChanged("SentimentValue");
            }
        }

        /// <summary>
        /// 서비스 케이스 해결 프로세스에서 서비스 케이스가 있는 스테이지를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("servicestage")]
        public Microsoft.Xrm.Sdk.OptionSetValue ServiceStage
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("servicestage");
            }
            set
            {
                this.OnPropertyChanging("ServiceStage");
                this.SetAttributeValue("servicestage", value);
                this.OnPropertyChanged("ServiceStage");
            }
        }

        /// <summary>
        /// 고객의 비즈니스에 대해 문제의 영향을 나타내기 위해 이 서비스 케이스의 심각도를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("severitycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue SeverityCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("severitycode");
            }
            set
            {
                this.OnPropertyChanging("SeverityCode");
                this.SetAttributeValue("severitycode", value);
                this.OnPropertyChanged("SeverityCode");
            }
        }

        /// <summary>
        /// 서비스 케이스 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
            }
            set
            {
                this.OnPropertyChanging("SLAId");
                this.SetAttributeValue("slaid", value);
                this.OnPropertyChanged("SLAId");
            }
        }

        /// <summary>
        /// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
            }
        }

        /// <summary>
        /// 서비스 케이스가 연결된 소셜 프로필의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("socialprofileid")]
        public Microsoft.Xrm.Sdk.EntityReference SocialProfileId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("socialprofileid");
            }
            set
            {
                this.OnPropertyChanging("SocialProfileId");
                this.SetAttributeValue("socialprofileid", value);
                this.OnPropertyChanged("SocialProfileId");
            }
        }

        /// <summary>
        /// 스테이지의 ID를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
        public System.Nullable<System.Guid> StageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
            }
            set
            {
                this.OnPropertyChanging("StageId");
                this.SetAttributeValue("stageid", value);
                this.OnPropertyChanged("StageId");
            }
        }

        /// <summary>
        /// 서비스 케이스가 활성 상태인지, 해결되었는지, 아니면 취소되었는지를 표시합니다. 해결 및 취소된 서비스 케이스는 읽기 전용이므로 다시 활성화하지 않으면 편집할 수 없습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<IncidentState> StateCode
        {
            get
            {
                Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if ((optionSet != null))
                {
                    return ((IncidentState)(System.Enum.ToObject(typeof(IncidentState), optionSet.Value)));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if ((value == null))
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// 서비스 케이스의 상태를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// 고객 서비스 관리자가 잦은 요청 또는 문제 영역을 식별할 수 있도록 카탈로그 요청 또는 제품 불만과 같은 서비스 케이스에 대한 주제를 선택합니다. 관리자는 [설정] 영역의 [비즈니스 관리]에서 주제를 구성할 수 있습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subjectid")]
        public Microsoft.Xrm.Sdk.EntityReference SubjectId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("subjectid");
            }
            set
            {
                this.OnPropertyChanging("SubjectId");
                this.SetAttributeValue("subjectid", value);
                this.OnPropertyChanged("SubjectId");
            }
        }

        /// <summary>
        /// 고객 참조 및 검색 가능성을 위해 서비스 케이스 번호를 표시합니다. 이 값은 수정할 수 없습니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ticketnumber")]
        public string TicketNumber
        {
            get
            {
                return this.GetAttributeValue<string>("ticketnumber");
            }
            set
            {
                this.OnPropertyChanging("TicketNumber");
                this.SetAttributeValue("ticketnumber", value);
                this.OnPropertyChanged("TicketNumber");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
        public System.Nullable<int> TimeZoneRuleVersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
            }
            set
            {
                this.OnPropertyChanging("TimeZoneRuleVersionNumber");
                this.SetAttributeValue("timezoneruleversionnumber", value);
                this.OnPropertyChanged("TimeZoneRuleVersionNumber");
            }
        }

        /// <summary>
        /// Microsoft Dynamics 365 보기에서 서비스 케이스를 식별하도록 주제 또는 설명하는 이름을 입력합니다(예: 요청, 문제 또는 회사 이름).
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetAttributeValue<string>("title");
            }
            set
            {
                this.OnPropertyChanging("Title");
                this.SetAttributeValue("title", value);
                this.OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// 예산이 올바른 통화로 보고되도록 레코드에 대해 현지 통화를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
        public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
            }
            set
            {
                this.OnPropertyChanging("TransactionCurrencyId");
                this.SetAttributeValue("transactioncurrencyid", value);
                this.OnPropertyChanged("TransactionCurrencyId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
        public string TraversedPath
        {
            get
            {
                return this.GetAttributeValue<string>("traversedpath");
            }
            set
            {
                this.OnPropertyChanging("TraversedPath");
                this.SetAttributeValue("traversedpath", value);
                this.OnPropertyChanged("TraversedPath");
            }
        }

        /// <summary>
        /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
        public System.Nullable<int> UTCConversionTimeZoneCode
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
            }
            set
            {
                this.OnPropertyChanging("UTCConversionTimeZoneCode");
                this.SetAttributeValue("utcconversiontimezonecode", value);
                this.OnPropertyChanged("UTCConversionTimeZoneCode");
            }
        }

        /// <summary>
        /// 서비스 케이스의 버전 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }
        #endregion Field
    }

    public partial class SystemUser
    {
        SystemUser() { }

      

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

        public string GetCurrentUserName(IOrganizationService service)
        {
            try
            {
                // Get a system user
                var userId = Messages.GetCurrentUserId(service);

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
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("activitypointer")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class ActivityPointer : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        #region Field
        [System.Runtime.Serialization.DataContractAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
        public enum ActivityPointerState
        {

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Open = 0,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Completed = 1,

            [System.Runtime.Serialization.EnumMemberAttribute()]
            Canceled = 2,

            [System.Runtime.Serialization.EnumMemberAttribute()]
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
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 외부 응용 프로그램에서 JSON으로 제공된 추가 정보입니다. 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityadditionalparams")]
        public string ActivityAdditionalParams
        {
            get
            {
                return this.GetAttributeValue<string>("activityadditionalparams");
            }
            set
            {
                this.OnPropertyChanging("ActivityAdditionalParams");
                this.SetAttributeValue("activityadditionalparams", value);
                this.OnPropertyChanged("ActivityAdditionalParams");
            }
        }

        /// <summary>
        /// 활동의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityid")]
        public System.Nullable<System.Guid> ActivityId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("activityid");
            }
            set
            {
                this.OnPropertyChanging("ActivityId");
                this.SetAttributeValue("activityid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("ActivityId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.ActivityId = value;
            }
        }

        /// <summary>
        /// 활동의 유형입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitytypecode")]
        public string ActivityTypeCode
        {
            get
            {
                return this.GetAttributeValue<string>("activitytypecode");
            }
        }

        /// <summary>
        /// 활동의 실제 기간(분)입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualdurationminutes")]
        public System.Nullable<int> ActualDurationMinutes
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("actualdurationminutes");
            }
            set
            {
                this.OnPropertyChanging("ActualDurationMinutes");
                this.SetAttributeValue("actualdurationminutes", value);
                this.OnPropertyChanged("ActualDurationMinutes");
            }
        }

        /// <summary>
        /// 활동의 실제 종료 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualend")]
        public System.Nullable<System.DateTime> ActualEnd
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("actualend");
            }
            set
            {
                this.OnPropertyChanging("ActualEnd");
                this.SetAttributeValue("actualend", value);
                this.OnPropertyChanged("ActualEnd");
            }
        }

        /// <summary>
        /// 활동의 실제 시작 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("actualstart")]
        public System.Nullable<System.DateTime> ActualStart
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("actualstart");
            }
            set
            {
                this.OnPropertyChanging("ActualStart");
                this.SetAttributeValue("actualstart", value);
                this.OnPropertyChanged("ActualStart");
            }
        }

        /// <summary>
        /// 이 활동과 연관된 모든 활동 당사자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("allparties")]
        public System.Collections.Generic.IEnumerable<ActivityParty> allparties
        {
            get
            {
                Microsoft.Xrm.Sdk.EntityCollection collection = this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityCollection>("allparties");
                if (((collection != null)
                            && (collection.Entities != null)))
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
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("community")]
        public Microsoft.Xrm.Sdk.OptionSetValue Community
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("community");
            }
            set
            {
                this.OnPropertyChanging("Community");
                this.SetAttributeValue("community", value);
                this.OnPropertyChanged("Community");
            }
        }

        /// <summary>
        /// 활동을 만든 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// 활동을 만든 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// 활동 포인터를 만든 대리인 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// 활동 배달을 마지막으로 시도한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("deliverylastattemptedon")]
        public System.Nullable<System.DateTime> DeliveryLastAttemptedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("deliverylastattemptedon");
            }
        }

        /// <summary>
        /// 전자 메일 서버에 활동 배달 우선 순위입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("deliveryprioritycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue DeliveryPriorityCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("deliveryprioritycode");
            }
            set
            {
                this.OnPropertyChanging("DeliveryPriorityCode");
                this.SetAttributeValue("deliveryprioritycode", value);
                this.OnPropertyChanged("DeliveryPriorityCode");
            }
        }

        /// <summary>
        /// 활동에 대한 설명입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Exchange Server에서 반환된 활동의 메시지 id입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangeitemid")]
        public string ExchangeItemId
        {
            get
            {
                return this.GetAttributeValue<string>("exchangeitemid");
            }
            set
            {
                this.OnPropertyChanging("ExchangeItemId");
                this.SetAttributeValue("exchangeitemid", value);
                this.OnPropertyChanged("ExchangeItemId");
            }
        }

        /// <summary>
        /// 활동 포인터와 연결된 통화의 기본 통화 기준 환율입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
        public System.Nullable<decimal> ExchangeRate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
            }
        }

        /// <summary>
        /// 전자 메일 유형의 활동의 웹 링크를 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangeweblink")]
        public string ExchangeWebLink
        {
            get
            {
                return this.GetAttributeValue<string>("exchangeweblink");
            }
            set
            {
                this.OnPropertyChanging("ExchangeWebLink");
                this.SetAttributeValue("exchangeweblink", value);
                this.OnPropertyChanged("ExchangeWebLink");
            }
        }

        /// <summary>
        /// 되풀이 항목의 인스턴스 유형입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("instancetypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue InstanceTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("instancetypecode");
            }
        }

        /// <summary>
        /// 서비스 케이스를 해결하기 위한 일환으로 해당 활동에 대한 대금이 청구되었는지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isbilled")]
        public System.Nullable<bool> IsBilled
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isbilled");
            }
            set
            {
                this.OnPropertyChanging("IsBilled");
                this.SetAttributeValue("isbilled", value);
                this.OnPropertyChanged("IsBilled");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismapiprivate")]
        public System.Nullable<bool> IsMapiPrivate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("ismapiprivate");
            }
            set
            {
                this.OnPropertyChanging("IsMapiPrivate");
                this.SetAttributeValue("ismapiprivate", value);
                this.OnPropertyChanged("IsMapiPrivate");
            }
        }

        /// <summary>
        /// 활동이 정기 활동 유형 또는 이벤트 유형인지와 관련된 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isregularactivity")]
        public System.Nullable<bool> IsRegularActivity
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isregularactivity");
            }
        }

        /// <summary>
        /// 활동을 워크플로 규칙에서 만들었는지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isworkflowcreated")]
        public System.Nullable<bool> IsWorkflowCreated
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isworkflowcreated");
            }
            set
            {
                this.OnPropertyChanging("IsWorkflowCreated");
                this.SetAttributeValue("isworkflowcreated", value);
                this.OnPropertyChanged("IsWorkflowCreated");
            }
        }

        /// <summary>
        /// 마지막으로 보류 중인 날짜 및 시간 스탬프가 포함됩니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("lastonholdtime")]
        public System.Nullable<System.DateTime> LastOnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("lastonholdtime");
            }
            set
            {
                this.OnPropertyChanging("LastOnHoldTime");
                this.SetAttributeValue("lastonholdtime", value);
                this.OnPropertyChanged("LastOnHoldTime");
            }
        }

        /// <summary>
        /// 음성 사서함 나감
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("leftvoicemail")]
        public System.Nullable<bool> LeftVoiceMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("leftvoicemail");
            }
            set
            {
                this.OnPropertyChanging("LeftVoiceMail");
                this.SetAttributeValue("leftvoicemail", value);
                this.OnPropertyChanged("LeftVoiceMail");
            }
        }

        /// <summary>
        /// 활동을 마지막으로 수정한 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// 활동을 마지막으로 수정한 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// 활동 포인터를 마지막으로 수정한 대리인 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// 레코드가 보류 중인 시간을 분으로 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("onholdtime")]
        public System.Nullable<int> OnHoldTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("onholdtime");
            }
        }

        /// <summary>
        /// 활동을 담당하는 사용자 또는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
            set
            {
                this.OnPropertyChanging("OwnerId");
                this.SetAttributeValue("ownerid", value);
                this.OnPropertyChanged("OwnerId");
            }
        }

        /// <summary>
        /// 활동을 담당하는 사업부의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
        public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
            }
        }

        /// <summary>
        /// 활동을 담당하는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
        public Microsoft.Xrm.Sdk.EntityReference OwningTeam
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
            }
        }

        /// <summary>
        /// 활동을 담당하는 사용자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
        public Microsoft.Xrm.Sdk.EntityReference OwningUser
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("postponeactivityprocessinguntil")]
        public System.Nullable<System.DateTime> PostponeActivityProcessingUntil
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("postponeactivityprocessinguntil");
            }
        }

        /// <summary>
        /// 활동의 우선 순위입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
        public Microsoft.Xrm.Sdk.OptionSetValue PriorityCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("prioritycode");
            }
            set
            {
                this.OnPropertyChanging("PriorityCode");
                this.SetAttributeValue("prioritycode", value);
                this.OnPropertyChanged("PriorityCode");
            }
        }

        /// <summary>
        /// 프로세스의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
        public System.Nullable<System.Guid> ProcessId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
            }
            set
            {
                this.OnPropertyChanging("ProcessId");
                this.SetAttributeValue("processid", value);
                this.OnPropertyChanged("ProcessId");
            }
        }

        /// <summary>
        /// 활동이 연결된 개체의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("regardingobjectid")]
        public Microsoft.Xrm.Sdk.EntityReference RegardingObjectId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("regardingobjectid");
            }
            set
            {
                this.OnPropertyChanging("RegardingObjectId");
                this.SetAttributeValue("regardingobjectid", value);
                this.OnPropertyChanged("RegardingObjectId");
            }
        }

        /// <summary>
        /// 활동의 예약된 기간(분)입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduleddurationminutes")]
        public System.Nullable<int> ScheduledDurationMinutes
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("scheduleddurationminutes");
            }
            set
            {
                this.OnPropertyChanging("ScheduledDurationMinutes");
                this.SetAttributeValue("scheduleddurationminutes", value);
                this.OnPropertyChanged("ScheduledDurationMinutes");
            }
        }

        /// <summary>
        /// 활동의 예약된 종료 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledend")]
        public System.Nullable<System.DateTime> ScheduledEnd
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledend");
            }
            set
            {
                this.OnPropertyChanging("ScheduledEnd");
                this.SetAttributeValue("scheduledend", value);
                this.OnPropertyChanged("ScheduledEnd");
            }
        }

        /// <summary>
        /// 활동의 예약된 시작 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledstart")]
        public System.Nullable<System.DateTime> ScheduledStart
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledstart");
            }
            set
            {
                this.OnPropertyChanging("ScheduledStart");
                this.SetAttributeValue("scheduledstart", value);
                this.OnPropertyChanged("ScheduledStart");
            }
        }

        /// <summary>
        /// 전자 메일 메시지를 보낸 사람과 연관된 사서함의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sendermailboxid")]
        public Microsoft.Xrm.Sdk.EntityReference SenderMailboxId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sendermailboxid");
            }
        }

        /// <summary>
        /// 활동을 보낸 날짜 및 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("senton")]
        public System.Nullable<System.DateTime> SentOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("senton");
            }
        }

        /// <summary>
        /// 인스턴스의 되풀이 항목 ID를 지정하는 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("seriesid")]
        public System.Nullable<System.Guid> SeriesId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("seriesid");
            }
        }

        /// <summary>
        /// 연관된 서비스의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("serviceid")]
        public Microsoft.Xrm.Sdk.EntityReference ServiceId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("serviceid");
            }
            set
            {
                this.OnPropertyChanging("ServiceId");
                this.SetAttributeValue("serviceid", value);
                this.OnPropertyChanged("ServiceId");
            }
        }

        /// <summary>
        /// 서비스 케이스 레코드에 적용할 SLA(서비스 수준 약정)를 선택합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slaid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slaid");
            }
            set
            {
                this.OnPropertyChanging("SLAId");
                this.SetAttributeValue("slaid", value);
                this.OnPropertyChanged("SLAId");
            }
        }

        /// <summary>
        /// 이 서비스 케이스에 적용된 마지막 SLA입니다. 이 필드는 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("slainvokedid")]
        public Microsoft.Xrm.Sdk.EntityReference SLAInvokedId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("slainvokedid");
            }
        }

        /// <summary>
        /// 활동이 정렬된 날짜 및 시간을 표시합니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sortdate")]
        public System.Nullable<System.DateTime> SortDate
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("sortdate");
            }
            set
            {
                this.OnPropertyChanging("SortDate");
                this.SetAttributeValue("sortdate", value);
                this.OnPropertyChanged("SortDate");
            }
        }

        /// <summary>
        /// 스테이지의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
        public System.Nullable<System.Guid> StageId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
            }
            set
            {
                this.OnPropertyChanging("StageId");
                this.SetAttributeValue("stageid", value);
                this.OnPropertyChanged("StageId");
            }
        }

        /// <summary>
        /// 활동의 상태입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<ActivityPointerState> StateCode
        {
            get
            {
                Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if ((optionSet != null))
                {
                    return ((ActivityPointerState)(System.Enum.ToObject(typeof(ActivityPointerState), optionSet.Value)));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if ((value == null))
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// 활동의 상태에 대한 설명입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// 활동과 연관된 주제입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subject")]
        public string Subject
        {
            get
            {
                return this.GetAttributeValue<string>("subject");
            }
            set
            {
                this.OnPropertyChanging("Subject");
                this.SetAttributeValue("subject", value);
                this.OnPropertyChanged("Subject");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
        public System.Nullable<int> TimeZoneRuleVersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
            }
            set
            {
                this.OnPropertyChanging("TimeZoneRuleVersionNumber");
                this.SetAttributeValue("timezoneruleversionnumber", value);
                this.OnPropertyChanged("TimeZoneRuleVersionNumber");
            }
        }

        /// <summary>
        /// 활동 포인터와 연결된 통화의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
        public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
            }
            set
            {
                this.OnPropertyChanging("TransactionCurrencyId");
                this.SetAttributeValue("transactioncurrencyid", value);
                this.OnPropertyChanged("TransactionCurrencyId");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
        public string TraversedPath
        {
            get
            {
                return this.GetAttributeValue<string>("traversedpath");
            }
            set
            {
                this.OnPropertyChanging("TraversedPath");
                this.SetAttributeValue("traversedpath", value);
                this.OnPropertyChanged("TraversedPath");
            }
        }

        /// <summary>
        /// 레코드를 만들 때 사용된 표준 시간대 코드입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
        public System.Nullable<int> UTCConversionTimeZoneCode
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
            }
            set
            {
                this.OnPropertyChanging("UTCConversionTimeZoneCode");
                this.SetAttributeValue("utcconversiontimezonecode", value);
                this.OnPropertyChanged("UTCConversionTimeZoneCode");
            }
        }

        /// <summary>
        /// 활동의 버전 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }
        #endregion Field
    }

    /// <summary>
    /// 활동과 연관된 사람 또는 그룹입니다. 한 활동에 여러 활동 당사자가 있을 수 있습니다.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("activityparty")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class ActivityParty : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
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
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 활동 당사자와 연관된 활동의 고유 식별자입니다. "당사자"는 활동과 연관된 사람입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activityid")]
        public Microsoft.Xrm.Sdk.EntityReference ActivityId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("activityid");
            }
            set
            {
                this.OnPropertyChanging("ActivityId");
                this.SetAttributeValue("activityid", value);
                this.OnPropertyChanged("ActivityId");
            }
        }

        /// <summary>
        /// 활동 당사자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitypartyid")]
        public System.Nullable<System.Guid> ActivityPartyId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("activitypartyid");
            }
            set
            {
                this.OnPropertyChanging("ActivityPartyId");
                this.SetAttributeValue("activitypartyid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("ActivityPartyId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activitypartyid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.ActivityPartyId = value;
            }
        }

        /// <summary>
        /// 전자 메일이 배달되며 대상 엔터티와 연관된 전자 메일 주소입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("addressused")]
        public string AddressUsed
        {
            get
            {
                return this.GetAttributeValue<string>("addressused");
            }
            set
            {
                this.OnPropertyChanging("AddressUsed");
                this.SetAttributeValue("addressused", value);
                this.OnPropertyChanged("AddressUsed");
            }
        }

        /// <summary>
        /// 관련 당사자의 전자 메일 주소 열 번호입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("addressusedemailcolumnnumber")]
        public System.Nullable<int> AddressUsedEmailColumnNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("addressusedemailcolumnnumber");
            }
        }

        /// <summary>
        /// 활동 당사자에게 전자 메일을 보낼 수 있도록 할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotemail")]
        public System.Nullable<bool> DoNotEmail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotemail");
            }
        }

        /// <summary>
        /// 활동 당사자에게 팩스를 보낼 수 있도록 할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotfax")]
        public System.Nullable<bool> DoNotFax
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotfax");
            }
        }

        /// <summary>
        /// 잠재 고객에게 전화를 걸 수 있도록 할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotphone")]
        public System.Nullable<bool> DoNotPhone
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotphone");
            }
        }

        /// <summary>
        /// 잠재 고객에게 우편을 보낼 수 있도록 할지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("donotpostalmail")]
        public System.Nullable<bool> DoNotPostalMail
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("donotpostalmail");
            }
        }

        /// <summary>
        /// 리소스가 서비스 약속 활동에 사용하는 작업량입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("effort")]
        public System.Nullable<double> Effort
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<double>>("effort");
            }
            set
            {
                this.OnPropertyChanging("Effort");
                this.SetAttributeValue("effort", value);
                this.OnPropertyChanged("Effort");
            }
        }

        /// <summary>
        /// 내부 전용입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangeentryid")]
        public string ExchangeEntryId
        {
            get
            {
                return this.GetAttributeValue<string>("exchangeentryid");
            }
            set
            {
                this.OnPropertyChanging("ExchangeEntryId");
                this.SetAttributeValue("exchangeentryid", value);
                this.OnPropertyChanged("ExchangeEntryId");
            }
        }

        /// <summary>
        /// 되풀이 항목의 인스턴스 유형입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("instancetypecode")]
        public Microsoft.Xrm.Sdk.OptionSetValue InstanceTypeCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("instancetypecode");
            }
        }

        /// <summary>
        /// 기본 엔터티 레코드가 삭제되었는지 여부에 대한 정보입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ispartydeleted")]
        public System.Nullable<bool> IsPartyDeleted
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("ispartydeleted");
            }
        }

        /// <summary>
        /// 활동 당사자를 담당하는 사용자 또는 팀의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
        public Microsoft.Xrm.Sdk.EntityReference OwnerId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
            }
        }

        /// <summary>
        /// 활동에 관련된 사람의 역할(예: 보낸 사람, 받는 사람, 참조, 숨은 참조, 필수 참석자, 선택 참석자, 이끌이, 관련 항목, 담당자)입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("participationtypemask")]
        public Microsoft.Xrm.Sdk.OptionSetValue ParticipationTypeMask
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("participationtypemask");
            }
            set
            {
                this.OnPropertyChanging("ParticipationTypeMask");
                this.SetAttributeValue("participationtypemask", value);
                this.OnPropertyChanged("ParticipationTypeMask");
            }
        }

        /// <summary>
        /// 활동과 연관된 당사자의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("partyid")]
        public Microsoft.Xrm.Sdk.EntityReference PartyId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("partyid");
            }
            set
            {
                this.OnPropertyChanging("PartyId");
                this.SetAttributeValue("partyid", value);
                this.OnPropertyChanged("PartyId");
            }
        }

        /// <summary>
        /// 활동 당사자에 대한 리소스 사양의 고유 식별자입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcespecid")]
        public Microsoft.Xrm.Sdk.EntityReference ResourceSpecId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("resourcespecid");
            }
            set
            {
                this.OnPropertyChanging("ResourceSpecId");
                this.SetAttributeValue("resourcespecid", value);
                this.OnPropertyChanged("ResourceSpecId");
            }
        }

        /// <summary>
        /// 활동의 예약된 종료 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledend")]
        public System.Nullable<System.DateTime> ScheduledEnd
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledend");
            }
        }

        /// <summary>
        /// 활동의 예약된 시작 시간입니다.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scheduledstart")]
        public System.Nullable<System.DateTime> ScheduledStart
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("scheduledstart");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }

        #endregion Field
    }
}