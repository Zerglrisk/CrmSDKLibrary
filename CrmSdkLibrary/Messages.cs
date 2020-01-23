using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

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
    }
}
