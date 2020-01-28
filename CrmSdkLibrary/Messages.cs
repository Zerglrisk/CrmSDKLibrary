using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary
{
    public class Messages
    {
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
        public void CalculatePrice(IOrganizationService service, EntityReference target)
        {
            try
            {
                service.Execute(new CalculatePriceRequest(){Target = target});
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
        public Entity CalculateRollupField(IOrganizationService service, EntityReference target, string fieldName)
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
        /// 
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveduplicatesrequest?view=dynamics-general-ce-9"/>
        /// <param name="service"></param>
        /// <param name="businessEntity">Gets or sets a record for which the duplicates are retrieved.Required.</param>
        /// <param name="pagingInfo">Gets or sets a paging information for the retrieved duplicates.Required.</param>
        /// <returns>Gets a collection of duplicate entity instances.</returns>
        public EntityCollection RetrieveDuplicates(IOrganizationService service, Entity businessEntity,  PagingInfo pagingInfo)
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
    }
}
