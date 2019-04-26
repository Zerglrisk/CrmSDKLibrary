using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary.Entities
{
    public partial class SystemUser
    {
        public void RetrieveRolesFromUserOrganization(RoleTargets target)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-remove-role-user"/>
        /// <param name="target"></param>
        public void DisassociateRoleFromUser(RoleTargets target)
        {
            QueryExpression query = new QueryExpression("role")
            {
                ColumnSet =  new ColumnSet("roleid"),
                Criteria = new FilterExpression()
                {
                    //Conditions = { new ConditionExpression("name",ConditionOperator.Equal,)}
                }
            };
        }
    }

    public enum RoleTargets : short
    {
        SystemUser= 0,
        Team,
        Organization
    }
}
