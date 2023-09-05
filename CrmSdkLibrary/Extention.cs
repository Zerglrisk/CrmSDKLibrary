using CrmSdkLibrary.Definition.Attribute;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrmSdkLibrary
{
	public static class Extention
	{
		/// <summary>
		/// Generate Random String
		/// </summary>
		/// <param name="str"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateRandomString(int length = 16, string charset = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789")
		{
			var random = new Random();
			return new string(Enumerable.Repeat(charset, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public static T GetAliasedValue<T>(this Entity entity, string attributeName)
		{
			if (!entity.Contains(attributeName))
			{
				return default(T);
			}
			if (entity.Attributes[attributeName].GetType() != typeof(AliasedValue))
			{
				return default(T);
			}

			return (T)entity.GetAttributeValue<AliasedValue>(attributeName).Value;
		}

		/// <summary>
		/// Get System.ComponentModel.DescriptionAttribute  Value
		/// </summary>
		/// <see href="https://stackoverflow.com/a/479417"/>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerationValue"></param>
		/// <returns></returns>
		public static string GetDescription<T>(this T enumerationValue) where T : struct
		{
			var type = enumerationValue.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("EnumerationValue must be of Enum Type", "enumerationValue");
			}

			var memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo.Length <= 0) return enumerationValue.ToString();
			var attrs = memberInfo.First().GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attrs.Length > 0 ? ((DescriptionAttribute)attrs.First()).Description : enumerationValue.ToString();
		}

		public static string GetStringValue<T>(this T enumerationValue) where T : struct
		{
			var type = enumerationValue.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("EnumerationValue must be of Enum Type", "enumerationValue");
			}

			var memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo.Length <= 0) return enumerationValue.ToString();
			var attrs = memberInfo.First().GetCustomAttributes(typeof(StringValue), false);
			return attrs.Length > 0 ? ((StringValue)attrs.First()).Value : enumerationValue.ToString();
		}

		public static AliasedValue ToAliasedValue(this object attr)
		{
			return ((AliasedValue)attr);
		}

		public static T ToCrmValue<T>(this Entity entity, string attributeName, bool isFormattedValue = false)
		{
			if (typeof(T) != typeof(string) && typeof(T) != typeof(int)
				&& typeof(T) != typeof(DateTime) && typeof(T) != typeof(KeyValuePair<Guid, string>)
				&& typeof(T) != typeof(bool) && typeof(T) != typeof(EntityReference))
			{
				throw new Exception("Type not Supported");
			}

			if (entity == null)
			{
				throw new Exception("Entity is null");
			}

			var attr = entity.Contains(attributeName) ? entity[attributeName] : null;
			if (attr == null)
			{
				if (typeof(T) == typeof(string))
				{
					return (T)Convert.ChangeType("", typeof(T));
				}
				else if (typeof(T) == typeof(int))
				{
					return (T)Convert.ChangeType(-1, typeof(T));
				}
				else if (typeof(T) == typeof(DateTime))
				{
					return (T)Convert.ChangeType(DateTime.MinValue, typeof(T));
				}
				else if (typeof(T) == typeof(KeyValuePair<Guid, string>))
				{
					return (T)Convert.ChangeType(new KeyValuePair<Guid, string>(), typeof(T));
				}
				else if (typeof(T) == typeof(EntityReference))
				{
					return (T)Convert.ChangeType(new EntityReference(string.Empty, Guid.Empty) { Name = string.Empty }, typeof(T));
				}
				else if (typeof(T) == typeof(bool))
				{
					return (T)Convert.ChangeType(false, typeof(T));
				}
				else
				{
					return (T)Convert.ChangeType(null, typeof(T));
				}
			}

			if (isFormattedValue)
			{
				return (T)Convert.ChangeType(entity.FormattedValues[attributeName], typeof(T));
			}
			if (attr is AliasedValue)
			{
				attr = attr.ToAliasedValue().Value;
			}
			if (attr is OptionSetValue)
			{
				return (T)Convert.ChangeType(attr.ToOptionSetValue().Value, typeof(T));
			}
			else if (attr is Money)
			{
				return (T)Convert.ChangeType(attr.ToMoney().Value, typeof(T));
			}
			else if (attr is string)
			{
				return (T)Convert.ChangeType(attr, typeof(T));
			}
			else if (attr is DateTime)
			{
				return (T)Convert.ChangeType(((DateTime)attr).AddHours(9), typeof(T));
			}
			else if (attr is EntityReference)
			{
				if (typeof(T) == typeof(KeyValuePair<Guid, string>))
				{
					return (T)Convert.ChangeType(new KeyValuePair<Guid, string>(attr.ToEntityReference().Id, attr.ToEntityReference().Name), typeof(T));
				}
				else
				{
					return (T)Convert.ChangeType(attr, typeof(T));
				}
			}
			else
			{
				return (T)Convert.ChangeType(attr.ToString(), typeof(T));
			}
		}

		public static DateTime? ToDateTime(this object attr, bool isAliasedValue = false)
		{
			if (DateTime.TryParse(isAliasedValue ? attr.ToAliasedValue().Value.ToString() : attr.ToString(), out var temp))
			{
				return temp.AddHours(9);
			}
			else
			{
				return null;
			}
		}

		public static string ToDigitString(this string str)
		{
			var regex = new Regex(@"[^\d]");
			return regex.Replace(str, "");
		}

		public static string ToDigitString(this object str)
		{
			var regex = new Regex(@"[^\d]");
			return regex.Replace(str.ToString(), "");
		}

		public static EntityReference ToEntityReference(this object attr, bool isAliasedValue = false)
		{
			return isAliasedValue ? (EntityReference)attr.ToAliasedValue().Value : (EntityReference)attr;
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/dynamics365/customer-engagement/web-api/msdyn_rmasubstatus?view=dynamics-ce-odata-9
		/// </summary>
		/// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt593046(v=crm.8)"/>
		/// <param name="attr"></param>
		/// <returns></returns>
		public static string ToEntitySetPath(this EntityReference attr)
		{
			switch (attr.LogicalName.ToLower())
			{
				case "account": return "accounts";
				case "accountleads": return "accountleadscollection";
				case "aciviewmapper": return "aciviewmappers";
				case "actioncard": return "actioncards";
				case "actioncarduserstate": return "actioncarduserstates";
				case "activitymimeattachment": return "activitymimeattachments";
				case "activityparty": return "activityparties";
				case "activitypointer": return "activitypointers";
				case "annotation": return "annotations";
				case "annualfiscalcalendar": return "annualfiscalcalendars";
				case "appconfig": return "appconfigs";
				case "appconfiginstance": return "appconfiginstances";
				case "appconfigmaster": return "appconfigmasters";
				case "appmodule": return "appmodules";
				case "appmodulecomponent": return "appmodulecomponents";
				case "appmoduleroles": return "appmodulerolescollection";
				case "appointment": return "appointments";
				case "asyncoperation": return "asyncoperations";
				case "attachment": return "attachments";
				case "audit": return "audits";
				case "bookableresource": return "bookableresources";
				case "bookableresourcebooking": return "bookableresourcebookings";
				case "bookableresourcebookingheader": return "bookableresourcebookingheaders";
				case "bookableresourcecategory": return "bookableresourcecategories";
				case "bookableresourcecategoryassn": return "bookableresourcecategoryassns";
				case "bookableresourcecharacteristic": return "bookableresourcecharacteristics";
				case "bookableresourcegroup": return "bookableresourcegroups";
				case "bookingstatus": return "bookingstatuses";
				case "bulkdeletefailure": return "bulkdeletefailures";
				case "bulkdeleteoperation": return "bulkdeleteoperations";
				case "bulkoperation": return "bulkoperations";
				case "bulkoperationlog": return "bulkoperationlogs";
				case "businessunit": return "businessunits";
				case "businessunitnewsarticle": return "businessunitnewsarticles";
				case "calendar": return "calendars";
				case "calendarrule": return "calendarrules";
				case "campaign": return "campaigns";
				case "campaignactivity": return "campaignactivities";
				case "campaignactivityitem": return "campaignactivityitems";
				case "campaignitem": return "campaignitems";
				case "campaignresponse": return "campaignresponses";
				case "category": return "categories";
				case "characteristic": return "characteristics";
				case "columnmapping": return "columnmappings";
				case "competitor": return "competitors";
				case "competitoraddress": return "competitoraddresses";
				case "competitorproduct": return "competitorproducts";
				case "competitorsalesliterature": return "competitorsalesliteratures";
				case "complexcontrol": return "complexcontrols";
				case "connection": return "connections";
				case "connectionrole": return "connectionroles";
				case "constraintbasedgroup": return "constraintbasedgroups";
				case "contact": return "contacts";
				case "contactinvoices": return "contactinvoicescollection";
				case "contactleads": return "contactleadscollection";
				case "contactorders": return "contactorderscollection";
				case "contactquotes": return "contactquotescollection";
				case "contract": return "contracts";
				case "contractdetail": return "contractdetails";
				case "contracttemplate": return "contracttemplates";
				case "customcontrol": return "customcontrols";
				case "customcontroldefaultconfig": return "customcontroldefaultconfigs";
				case "customcontrolresource": return "customcontrolresources";
				case "customeraddress": return "customeraddresses";
				case "dataperformance": return "dataperformances";
				case "dependency": return "dependencies";
				case "discount": return "discounts";
				case "discounttype": return "discounttypes";
				case "displaystring": return "displaystrings";
				case "documenttemplate": return "documenttemplates";
				case "duplicaterecord": return "duplicaterecords";
				case "duplicaterule": return "duplicaterules";
				case "duplicaterulecondition": return "duplicateruleconditions";
				case "dynamicproperty": return "dynamicproperties";
				case "dynamicpropertyassociation": return "dynamicpropertyassociations";
				case "dynamicpropertyinstance": return "dynamicpropertyinstances";
				case "dynamicpropertyoptionsetitem": return "dynamicpropertyoptionsetitems";
				case "email": return "emails";
				case "emailserverprofile": return "emailserverprofiles";
				case "entitlement": return "entitlements";
				case "entitlementchannel": return "entitlementchannels";
				case "entitlementcontacts": return "entitlementcontactscollection";
				case "entitlementproducts": return "entitlementproductscollection";
				case "entitlementtemplate": return "entitlementtemplates";
				case "entitlementtemplatechannel": return "entitlementtemplatechannels";
				case "entitlementtemplateproducts": return "entitlementtemplateproductscollection";
				case "entitydataprovider": return "entitydataproviders";
				case "equipment": return "equipments";
				case "exchangesyncidmapping": return "exchangesyncidmappings";
				case "expiredprocess": return "expiredprocesses";
				case "fax": return "faxes";
				case "feedback": return "feedback";
				case "fieldpermission": return "fieldpermissions";
				case "fieldsecurityprofile": return "fieldsecurityprofiles";
				case "fixedmonthlyfiscalcalendar": return "fixedmonthlyfiscalcalendars";
				case "goal": return "goals";
				case "goalrollupquery": return "goalrollupqueries";
				case "import": return "imports";
				case "importdata": return "importdataset";
				case "importentitymapping": return "importentitymappings";
				case "importfile": return "importfiles";
				case "importjob": return "importjobs";
				case "importlog": return "importlogs";
				case "importmap": return "importmaps";
				case "incident": return "incidents";
				case "incidentknowledgebaserecord": return "incidentknowledgebaserecords";
				case "incidentresolution": return "incidentresolutions";
				case "interactionforemail": return "interactionforemails";
				case "invaliddependency": return "invaliddependencies";
				case "invoice": return "invoices";
				case "invoicedetail": return "invoicedetails";
				case "kbarticle": return "kbarticles";
				case "kbarticlecomment": return "kbarticlecomments";
				case "kbarticletemplate": return "kbarticletemplates";
				case "knowledgearticle": return "knowledgearticles";
				case "knowledgearticleincident": return "knowledgearticleincidents";
				case "knowledgearticleviews": return "knowledgearticleviews";
				case "knowledgebaserecord": return "knowledgebaserecords";
				case "languagelocale": return "languagelocale";
				case "lead": return "leads";
				case "leadaddress": return "leadaddresses";
				case "leadcompetitors": return "leadcompetitorscollection";
				case "leadproduct": return "leadproducts";
				case "leadtoopportunitysalesprocess": return "leadtoopportunitysalesprocesses";
				case "letter": return "letters";
				case "list": return "lists";
				case "listmember": return "listmembers";
				case "lookupmapping": return "lookupmappings";
				case "mailbox": return "mailboxes";
				case "mailboxtrackingfolder": return "mailboxtrackingfolders";
				case "mailmergetemplate": return "mailmergetemplates";
				case "mbs_pluginprofile": return "mbs_pluginprofiles";
				case "metric": return "metrics";
				case "mobileofflineprofile": return "mobileofflineprofiles";
				case "mobileofflineprofileitem": return "mobileofflineprofileitems";
				case "mobileofflineprofileitemassociation": return "mobileofflineprofileitemassociations";
				case "monthlyfiscalcalendar": return "monthlyfiscalcalendars";
				case "ms_newsitem": return "ms_newsitems";
				case "ms_satori": return "ms_satoris";
				case "msdyn_accountpricelist": return "msdyn_accountpricelists";
				case "msdyn_actual": return "msdyn_actuals";
				case "msdyn_agreement": return "msdyn_agreements";
				case "msdyn_agreementbookingdate": return "msdyn_agreementbookingdates";
				case "msdyn_agreementbookingincident": return "msdyn_agreementbookingincidents";
				case "msdyn_agreementbookingproduct": return "msdyn_agreementbookingproducts";
				case "msdyn_agreementbookingservice": return "msdyn_agreementbookingservices";
				case "msdyn_agreementbookingservicetask": return "msdyn_agreementbookingservicetasks";
				case "msdyn_agreementbookingsetup": return "msdyn_agreementbookingsetups";
				case "msdyn_agreementinvoicedate": return "msdyn_agreementinvoicedates";
				case "msdyn_agreementinvoiceproduct": return "msdyn_agreementinvoiceproducts";
				case "msdyn_agreementinvoicesetup": return "msdyn_agreementinvoicesetups";
				case "msdyn_agreementsubstatus": return "msdyn_agreementsubstatuses";
				case "msdyn_approval": return "msdyn_approvals";
				case "msdyn_batchjob": return "msdyn_batchjobs";
				case "msdyn_bookingalert": return "msdyn_bookingalerts";
				case "msdyn_bookingalertstatus": return "msdyn_bookingalertstatuses";
				case "msdyn_bookingchange": return "msdyn_bookingchanges";
				case "msdyn_bookingjournal": return "msdyn_bookingjournals";
				case "msdyn_bookingrule": return "msdyn_bookingrules";
				case "msdyn_bookingsetupmetadata": return "msdyn_bookingsetupmetadatas";
				case "msdyn_bookingtimestamp": return "msdyn_bookingtimestamps";
				case "msdyn_bpf_2c5fe86acc8b414b8322ae571000c799": return "msdyn_bpf_2c5fe86acc8b414b8322ae571000c799s";
				case "msdyn_bpf_477c16f59170487b8b4dc895c5dcd09b": return "msdyn_bpf_477c16f59170487b8b4dc895c5dcd09bs";
				case "msdyn_bpf_665e73aa18c247d886bfc50499c73b82": return "msdyn_bpf_665e73aa18c247d886bfc50499c73b82s";
				case "msdyn_bpf_989e9b1857e24af18787d5143b67523b": return "msdyn_bpf_989e9b1857e24af18787d5143b67523bs";
				case "msdyn_bpf_baa0a411a239410cb8bded8b5fdd88e3": return "msdyn_bpf_baa0a411a239410cb8bded8b5fdd88e3s";
				case "msdyn_bpf_d3d97bac8c294105840e99e37a9d1c39": return "msdyn_bpf_d3d97bac8c294105840e99e37a9d1c39s";
				case "msdyn_bpf_d8f9dc7f099f44db9d641dd81fbd470d": return "msdyn_bpf_d8f9dc7f099f44db9d641dd81fbd470ds";
				case "msdyn_characteristicreqforteammember": return "msdyn_characteristicreqforteammembers";
				case "msdyn_clientextension": return "msdyn_clientextensions";
				case "msdyn_configuration": return "msdyn_configurations";
				case "msdyn_contactpricelist": return "msdyn_contactpricelists";
				case "msdyn_contractlineinvoiceschedule": return "msdyn_contractlineinvoiceschedules";
				case "msdyn_contractlinescheduleofvalue": return "msdyn_contractlinescheduleofvalues";
				case "msdyn_customerasset": return "msdyn_customerassets";
				case "msdyn_dataexport": return "msdyn_dataexports";
				case "msdyn_delegation": return "msdyn_delegations";
				case "msdyn_estimate": return "msdyn_estimates";
				case "msdyn_estimateline": return "msdyn_estimatelines";
				case "msdyn_expense": return "msdyn_expenses";
				case "msdyn_expensecategory": return "msdyn_expensecategories";
				case "msdyn_expensereceipt": return "msdyn_expensereceipts";
				case "msdyn_fact": return "msdyn_facts";
				case "msdyn_fieldcomputation": return "msdyn_fieldcomputations";
				case "msdyn_fieldservicepricelistitem": return "msdyn_fieldservicepricelistitems";
				case "msdyn_fieldservicesetting": return "msdyn_fieldservicesettings";
				case "msdyn_fieldservicesystemjob": return "msdyn_fieldservicesystemjobs";
				case "msdyn_findworkevent": return "msdyn_findworkevents";
				case "msdyn_incidenttype": return "msdyn_incidenttypes";
				case "msdyn_incidenttypecharacteristic": return "msdyn_incidenttypecharacteristics";
				case "msdyn_incidenttypeproduct": return "msdyn_incidenttypeproducts";
				case "msdyn_incidenttypeservice": return "msdyn_incidenttypeservices";
				case "msdyn_incidenttypeservicetask": return "msdyn_incidenttypeservicetasks";
				case "msdyn_integrationjob": return "msdyn_integrationjobs";
				case "msdyn_integrationjobdetail": return "msdyn_integrationjobdetails";
				case "msdyn_inventoryadjustment": return "msdyn_inventoryadjustments";
				case "msdyn_inventoryadjustmentproduct": return "msdyn_inventoryadjustmentproducts";
				case "msdyn_inventoryjournal": return "msdyn_inventoryjournals";
				case "msdyn_inventorytransfer": return "msdyn_inventorytransfers";
				case "msdyn_invoicefrequency": return "msdyn_invoicefrequencies";
				case "msdyn_invoicefrequencydetail": return "msdyn_invoicefrequencydetails";
				case "msdyn_invoicelinetransaction": return "msdyn_invoicelinetransactions";
				case "msdyn_iotalert": return "msdyn_iotalerts";
				case "msdyn_iotdevice": return "msdyn_iotdevices";
				case "msdyn_iotdevicecategory": return "msdyn_iotdevicecategories";
				case "msdyn_iotdevicecommand": return "msdyn_iotdevicecommands";
				case "msdyn_iotdeviceregistrationhistory": return "msdyn_iotdeviceregistrationhistories";
				case "msdyn_journal": return "msdyn_journals";
				case "msdyn_journalline": return "msdyn_journallines";
				case "msdyn_mlresultcache": return "msdyn_mlresultcaches";
				case "msdyn_odatav4ds": return "msdyn_odatav4ds";
				case "msdyn_opportunitylineresourcecategory": return "msdyn_opportunitylineresourcecategories";
				case "msdyn_opportunitylinetransaction": return "msdyn_opportunitylinetransactions";
				case "msdyn_opportunitylinetransactioncategory": return "msdyn_opportunitylinetransactioncategories";
				case "msdyn_opportunitylinetransactionclassificatio": return "msdyn_opportunitylinetransactionclassificatios";
				case "msdyn_opportunitypricelist": return "msdyn_opportunitypricelists";
				case "msdyn_orderinvoicingdate": return "msdyn_orderinvoicingdates";
				case "msdyn_orderinvoicingproduct": return "msdyn_orderinvoicingproducts";
				case "msdyn_orderinvoicingsetup": return "msdyn_orderinvoicingsetups";
				case "msdyn_orderinvoicingsetupdate": return "msdyn_orderinvoicingsetupdates";
				case "msdyn_orderlineresourcecategory": return "msdyn_orderlineresourcecategories";
				case "msdyn_orderlinetransaction": return "msdyn_orderlinetransactions";
				case "msdyn_orderlinetransactioncategory": return "msdyn_orderlinetransactioncategories";
				case "msdyn_orderlinetransactionclassification": return "msdyn_orderlinetransactionclassifications";
				case "msdyn_orderpricelist": return "msdyn_orderpricelists";
				case "msdyn_organizationalunit": return "msdyn_organizationalunits";
				case "msdyn_orginsightsuserdashboarddefinition": return "msdyn_orginsightsuserdashboarddefinitions";
				case "msdyn_payment": return "msdyn_payments";
				case "msdyn_paymentdetail": return "msdyn_paymentdetailes";
				case "msdyn_paymentmethod": return "msdyn_paymentmethods";
				case "msdyn_paymentterm": return "msdyn_paymentterms";
				case "msdyn_postalbum": return "msdyn_postalbums";
				case "msdyn_postalcode": return "msdyn_postalcodes";
				case "msdyn_postconfig": return "msdyn_postconfigs";
				case "msdyn_postruleconfig": return "msdyn_postruleconfigs";
				case "msdyn_priority": return "msdyn_priorities";
				case "msdyn_processnotes": return "msdyn_processnoteses";
				case "msdyn_productinventory": return "msdyn_productinventories";
				case "msdyn_project": return "msdyn_projects";
				case "msdyn_projectapproval": return "msdyn_projectapprovals";
				case "msdyn_projectparameter": return "msdyn_projectparameters";
				case "msdyn_projectparameterpricelist": return "msdyn_projectparameterpricelists";
				case "msdyn_projectpricelist": return "msdyn_projectpricelists";
				case "msdyn_projecttask": return "msdyn_projecttasks";
				case "msdyn_projecttaskdependency": return "msdyn_projecttaskdependencies";
				case "msdyn_projecttaskstatususer": return "msdyn_projecttaskstatususers";
				case "msdyn_projectteam": return "msdyn_projectteams";
				case "msdyn_projectteammembersignup": return "msdyn_projectteammembersignups";
				case "msdyn_projecttransactioncategory": return "msdyn_projecttransactioncategories";
				case "msdyn_purchaseorder": return "msdyn_purchaseorders";
				case "msdyn_purchaseorderbill": return "msdyn_purchaseorderbills";
				case "msdyn_purchaseorderproduct": return "msdyn_purchaseorderproducts";
				case "msdyn_purchaseorderreceipt": return "msdyn_purchaseorderreceipts";
				case "msdyn_purchaseorderreceiptproduct": return "msdyn_purchaseorderreceiptproducts";
				case "msdyn_purchaseordersubstatus": return "msdyn_purchaseordersubstatuses";
				case "msdyn_quotebookingincident": return "msdyn_quotebookingincidents";
				case "msdyn_quotebookingproduct": return "msdyn_quotebookingproducts";
				case "msdyn_quotebookingservice": return "msdyn_quotebookingservices";
				case "msdyn_quotebookingservicetask": return "msdyn_quotebookingservicetasks";
				case "msdyn_quotebookingsetup": return "msdyn_quotebookingsetups";
				case "msdyn_quoteinvoicingproduct": return "msdyn_quoteinvoicingproducts";
				case "msdyn_quoteinvoicingsetup": return "msdyn_quoteinvoicingsetups";
				case "msdyn_quotelineanalyticsbreakdown": return "msdyn_quotelineanalyticsbreakdowns";
				case "msdyn_quotelineinvoiceschedule": return "msdyn_quotelineinvoiceschedules";
				case "msdyn_quotelineresourcecategory": return "msdyn_quotelineresourcecategories";
				case "msdyn_quotelinescheduleofvalue": return "msdyn_quotelinescheduleofvalues";
				case "msdyn_quotelinetransaction": return "msdyn_quotelinetransactions";
				case "msdyn_quotelinetransactioncategory": return "msdyn_quotelinetransactioncategories";
				case "msdyn_quotelinetransactionclassification": return "msdyn_quotelinetransactionclassifications";
				case "msdyn_quotepricelist": return "msdyn_quotepricelists";
				case "msdyn_requirementcharacteristic": return "msdyn_requirementcharacteristics";
				case "msdyn_requirementorganizationunit": return "msdyn_requirementorganizationunits";
				case "msdyn_requirementresourcecategory": return "msdyn_requirementresourcecategories";
				case "msdyn_requirementresourcepreference": return "msdyn_requirementresourcepreferences";
				case "msdyn_requirementstatus": return "msdyn_requirementstatuses";
				case "msdyn_resourceassignment": return "msdyn_resourceassignments";
				case "msdyn_resourceassignmentdetail": return "msdyn_resourceassignmentdetails";
				case "msdyn_resourcecategorypricelevel": return "msdyn_resourcecategorypricelevels";
				case "msdyn_resourcepaytype": return "msdyn_resourcepaytypes";
				case "msdyn_resourcerequest": return "msdyn_resourcerequests";
				case "msdyn_resourcerequirement": return "msdyn_resourcerequirements";
				case "msdyn_resourcerequirementdetail": return "msdyn_resourcerequirementdetails";
				case "msdyn_resourceterritory": return "msdyn_resourceterritories";
				case "msdyn_rma": return "msdyn_rmas";
				case "msdyn_rmaproduct": return "msdyn_rmaproducts";
				case "msdyn_rmareceipt": return "msdyn_rmareceipts";
				case "msdyn_rmareceiptproduct": return "msdyn_rmareceiptproducts";
				case "msdyn_rmasubstatus": return "msdyn_rmasubstatuses";
				case "msdyn_rolecompetencyrequirement": return "";
				case "msdyn_roleutilization": return "";
				case "msdyn_rtv": return "";
				case "msdyn_rtvproduct": return "";
				case "msdyn_rtvsubstatus": return "";
				case "msdyn_scheduleboardsetting": return "";
				case "msdyn_schedulingparameter": return "";
				case "msdyn_servicetasktype": return "";
				case "msdyn_shipvia": return "";
				case "msdyn_systemuserschedulersetting": return "";
				case "msdyn_taxcode": return "";
				case "msdyn_taxcodedetail": return "";
				case "msdyn_timeentry": return "";
				case "msdyn_timegroup": return "";
				case "msdyn_timegroupdetail": return "";
				case "msdyn_timeoffcalendar": return "";
				case "msdyn_timeoffrequest": return "";
				case "msdyn_transactioncategory": return "";
				case "msdyn_transactioncategoryclassification": return "";
				case "msdyn_transactioncategoryhierarchyelement": return "";
				case "msdyn_transactioncategorypricelevel": return "";
				case "msdyn_transactionconnection": return "";
				case "msdyn_transactionorigin": return "";
				case "msdyn_transactiontype": return "";
				case "msdyn_uniquenumber": return "";
				case "msdyn_userworkhistory": return "";
				case "msdyn_wallsavedquery": return "";
				case "msdyn_wallsavedqueryusersettings": return "";
				case "msdyn_warehouse": return "";
				case "msdyn_workhourtemplate": return "";
				case "msdyn_workorder": return "";
				case "msdyn_workordercharacteristic": return "";
				case "msdyn_workorderdetailsgenerationqueue": return "";
				case "msdyn_workorderincident": return "";
				case "msdyn_workorderproduct": return "";
				case "msdyn_workorderresourcerestriction": return "";
				case "msdyn_workorderservice": return "";
				case "msdyn_workorderservicetask": return "";
				case "msdyn_workordersubstatus": return "";
				case "msdyn_workordertype": return "";
				case "navigationsetting": return "";
				case "newprocess": return "";
				case "officegraphdocument": return "";
				case "opportunity": return "";
				case "opportunityclose": return "";
				case "opportunitycompetitors": return "";
				case "opportunityproduct": return "";
				case "opportunitysalesprocess": return "";
				case "orderclose": return "";
				case "organization": return "";
				case "ownermapping": return "";
				case "personaldocumenttemplate": return "";
				case "phonecall": return "";
				case "phonetocaseprocess": return "";
				case "picklistmapping": return "";
				case "pluginassembly": return "";
				case "plugintracelog": return "";
				case "plugintype": return "";
				case "plugintypestatistic": return "";
				case "position": return "";
				case "post": return "";
				case "postcomment": return "";
				case "postfollow": return "";
				case "postlike": return "";
				case "postregarding": return "";
				case "pricelevel": return "";
				case "principal": return "";
				case "principalobjectaccess": return "";
				case "principalobjectattributeaccess": return "";
				case "privilege": return "";
				case "processsession": return "";
				case "processstage": return "";
				case "processtrigger": return "";
				case "product": return "";
				case "productassociation": return "";
				case "productpricelevel": return "";
				case "productsalesliterature": return "";
				case "productsubstitute": return "";
				case "publisher": return "";
				case "publisheraddress": return "";
				case "quarterlyfiscalcalendar": return "";
				case "queue": return "";
				case "queueitem": return "";
				case "quote": return "";
				case "quoteclose": return "";
				case "quotedetail": return "";
				case "ratingmodel": return "";
				case "ratingvalue": return "";
				case "recommendeddocument": return "";
				case "recurrencerule": return "";
				case "recurringappointmentmaster": return "";
				case "report": return "";
				case "reportcategory": return "";
				case "resource": return "";
				case "resourcegroup": return "";
				case "resourcespec": return "";
				case "role": return "";
				case "roleprivileges": return "";
				case "roletemplate": return "";
				case "roletemplateprivileges": return "";
				case "rollupfield": return "";
				case "runtimedependency": return "";
				case "salesliterature": return "";
				case "salesliteratureitem": return "";
				case "salesorder": return "";
				case "salesorderdetail": return "";
				case "savedquery": return "savedqueries";
				case "savedqueryvisualization": return "";
				case "sdkmessage": return "";
				case "sdkmessagefilter": return "";
				case "sdkmessageprocessingstep": return "";
				case "sdkmessageprocessingstepimage": return "";
				case "sdkmessageprocessingstepsecureconfig": return "";
				case "semiannualfiscalcalendar": return "";
				case "service": return "";
				case "serviceappointment": return "";
				case "servicecontractcontacts": return "";
				case "serviceendpoint": return "";
				case "sharepointdocumentlocation": return "";
				case "sharepointsite": return "";
				case "similarityrule": return "";
				case "site": return "";
				case "sitemap": return "";
				case "sla": return "";
				case "slaitem": return "";
				case "slakpiinstance": return "";
				case "socialactivity": return "";
				case "socialprofile": return "";
				case "solution": return "";
				case "solutioncomponent": return "";
				case "subject": return "";
				case "subscriptionmanuallytrackedobject": return "";
				case "subscriptionstatisticsoffline": return "";
				case "subscriptionstatisticsoutlook": return "";
				case "subscriptionsyncentryoffline": return "";
				case "subscriptionsyncentryoutlook": return "";
				case "syncerror": return "";
				case "systemform": return "";
				case "systemuser": return "";
				case "task": return "";
				case "team": return "";
				case "teamtemplate": return "";
				case "template": return "";
				case "territory": return "";
				case "theme": return "";
				case "timestampdatemapping": return "";
				case "timezonedefinition": return "";
				case "timezonelocalizedname": return "";
				case "timezonerule": return "";
				case "tracelog": return "";
				case "transactioncurrency": return "";
				case "transformationmapping": return "";
				case "transformationparametermapping": return "";
				case "translationprocess": return "";
				case "uom": return "";
				case "uomschedule": return "";
				case "userform": return "";
				case "usermapping": return "";
				case "userquery": return "";
				case "userqueryvisualization": return "";
				case "usersettings": return "";
				case "webresource": return "";
				case "webwizard": return "";
				case "workflow": return "";
				case "workflowlog": return "";
			}

			return null;
		}

		public static string ToEntitySetPath(this Entity attr)
		{
			return attr.ToEntityReference().ToEntitySetPath();
		}

		public static KeyValuePair<Guid, string> ToKeyValuePair(this EntityReference attr)
		{
			return attr != null ? new KeyValuePair<Guid, string>(attr.Id, attr.Name) : new KeyValuePair<Guid, string>();
		}

		public static Money ToMoney(this object attr, bool isAliasedValue = false)
		{
			return isAliasedValue ? (Money)attr.ToAliasedValue().Value : (Money)attr;
		}

		public static OptionSetValue ToOptionSetValue(this object attr, bool isAliasedValue = false)
		{
			return isAliasedValue ? (OptionSetValue)attr.ToAliasedValue().Value : (OptionSetValue)attr;
		}
	}
}