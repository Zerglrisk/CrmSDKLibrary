using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CrmSdkLibrary.CustomAPI
{
	/// <summary>
	/// This method retrieves information from the Global OptionSet Metadata.
	/// 1. Enter the Power Apps Site(https://make.powerapps.com/).
	/// 2. Select Invironment Top Right
	/// 2. Click the Solutions Tab menu.
	/// 3. Select Solution.
	/// 4. Create 3 Records Based On The Content Below
	/// /*-------------------Custom API----------------------*/
	/// uniquename : CrmSdkLibrary.CustomAPI.RetrieveOptionSet
	/// bindingtype : Global
	/// allowedcustomprocessingsteptype : Sync and Async [maybe]
	/// plugintypeid : CrmSdkLibrary.CustomAPI.RetrieveOptionSet
	/// /*---------------------------------------------------*/
	/// /*------------Custom API Request Parameter-----------*/
	/// customapiid : CrmSdkLibrary.CustomAPI.RetrieveOptionSet
	/// uniquename : crmsdklibraryglobaloptionsetlogicalname
	/// type : String
	/// isoptional : No
	/// /*---------------------------------------------------*/
	/// /*------------Custom API Response Property-----------*/
	/// customapiid : CrmSdkLibrary.CustomAPI.RetrieveOptionSet
	/// uniquename : crmsdklibrarystringresult
	/// type : String
	/// /*---------------------------------------------------*/
	/// </summary>
	public class RetrieveOptionSet : CustomAPI
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PostOperationChangeOpportunityDealType"/> class.
		/// </summary>
		/// <param name="unsecure">Contains public (unsecured) configuration information.</param>
		/// <param name="secure">Contains non-public (secured) configuration information.</param>
		public RetrieveOptionSet(string unsecure, string secure)
				: base(typeof(RetrieveOptionSet))
		{
			// TODO: Implement your custom configuration handling.
		}

		protected override void ExecuteCdsPlugin(ILocalPluginContext localContext)
		{
			if (localContext == null)
			{
				throw new InvalidPluginExecutionException(nameof(localContext));
			}

			try
			{
				//var messageName = localContext.PluginExecutionContext.MessageName;
				//var stage = localContext.PluginExecutionContext.Stage;
				//if (!messageName.Equals("RetrieveOptionSet"))
				//{
				//	throw new Exception($"'{messageName}' RetrieveOptionSet plug-in is not associated with the expected message or is not registered for the main operation.");
				//}
				string globaloptionsetlogicalname = (string)localContext.PluginExecutionContext.InputParameters["crmsdklibraryglobaloptionsetlogicalname"];

				if (string.IsNullOrEmpty(globaloptionsetlogicalname))
				{
					throw new Exception("The globaloptionsetlogicalname parameter is required for the RetrieveOptionSet function. Please provide a valid value");
				}

				var optionset = this.RetrieveOptionSetMetadata(localContext.CurrentUserService, globaloptionsetlogicalname, true);

				//Simply reversing the characters of the string
				localContext.PluginExecutionContext.OutputParameters["crmsdklibrarystringresult"] = JsonConvert.SerializeObject(new OptionSetMetadataString(optionset));
			}
			catch (System.ServiceModel.FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
			{
				localContext.TracingService?.Trace("An error occurred executing Plugin CrmSdkLibrary.CustomAPI.RetrieveOptionSet : {0}", ex.ToString());
				throw new InvalidPluginExecutionException(ex.Message, ex);
			}

			// Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
			catch (Exception ex)
			{
				localContext.TracingService?.Trace("An error occurred executing Plugin CrmSdkLibrary.CustomAPI.RetrieveOptionSet : {0}", ex.ToString());
				throw new InvalidPluginExecutionException($"An error occurred. : {ex.Message}", ex);
			}
		}

		private OptionSetMetadata RetrieveOptionSetMetadata(in IOrganizationService service, string globalOptionSetName, bool retrieveAsIfPublished = false) => (service.Execute(new RetrieveOptionSetRequest()
		{
			Name = globalOptionSetName,
			RetrieveAsIfPublished = retrieveAsIfPublished
		}) as RetrieveOptionSetResponse).OptionSetMetadata as OptionSetMetadata;
	}

	public class OptionSetMetadataString
	{
		[JsonProperty("@odata.type")]
		public static string ODataType => "CrmSdkLibrary.CustomAPI.RetrieveOptionSet";

		public string ParentOptionSetName { get; set; }

		public string Description { get; set; }

		public string DisplayName { get; set; }

		public bool? IsCustomOptionSet { get; set; }

		public bool? IsManaged { get; set; }

		public BooleanManagedPropertyString IsCustomizable { get; set; }

		public string Name { get; set; }

		public string ExternalTypeName { get; set; }

		public string OptionSetType { get; set; }

		//[JsonProperty("OptionSetType@odata.type")]
		//public static string OptionSetTypeType => "Enum";
		public string IntroducedVersion { get; set; }

		public bool? IsGlobal { get; set; }

		public OptionMetadataString[] Options { get; set; }

		public OptionSetMetadataString(OptionSetMetadata meta)
		{
			this.ParentOptionSetName = meta.ParentOptionSetName;
			this.Description = meta.Description?.UserLocalizedLabel?.Label ?? meta.Description?.LocalizedLabels.FirstOrDefault()?.Label;
			this.DisplayName = meta.Name;
			this.IsCustomOptionSet = meta.IsCustomOptionSet;
			this.IsManaged = meta.IsManaged;
			if (meta.IsCustomizable != null)
			{
				this.IsCustomizable = new BooleanManagedPropertyString
				{
					Value = meta.IsCustomizable.Value,
					CanBeChanged = meta.IsCustomizable.CanBeChanged,
					ManagedPropertyLogicalName = meta.IsCustomizable.ManagedPropertyLogicalName
				};
			}
			else { this.IsCustomizable = null; }
			this.Name = meta.Name;
			this.ExternalTypeName = meta.ExternalTypeName;
			this.OptionSetType = meta.OptionSetType?.ToString("G");
			this.IntroducedVersion = meta.IntroducedVersion;
			this.IsGlobal = meta.IsGlobal;
			if (meta.Options != null)
			{
				this.Options = meta.Options.Select(x => new OptionMetadataString(x)).ToArray();
			}
			else { this.Options = null; }
		}
	}

	public class OptionMetadataString
	{
		public int? Value { get; set; }

		public string Label { get; set; }

		public string Description { get; set; }

		public string Color { get; set; }

		public bool? IsManaged { get; set; }

		public int[] ParentValues { get; set; }

		public string ExternalValue { get; set; }

		public string Tag { get; set; }

		public OptionMetadataString(OptionMetadata meta)
		{
			this.Value = meta.Value;
			this.Label = meta.Label?.UserLocalizedLabel?.Label ?? meta.Label?.LocalizedLabels.FirstOrDefault()?.Label;
			this.Description = meta.Description?.UserLocalizedLabel?.Label ?? meta.Description?.LocalizedLabels.FirstOrDefault()?.Label;
			this.Color = meta.Color;
			this.IsManaged = meta.IsManaged;
			this.ParentValues = meta.ParentValues;
			this.ExternalValue = meta.ExternalValue;
			this.Tag = meta.Tag;
		}
	}

	public class BooleanManagedPropertyString
	{
		public bool? Value { get; set; }

		public bool CanBeChanged { get; set; }

		public string ManagedPropertyLogicalName { get; set; }
	}
}