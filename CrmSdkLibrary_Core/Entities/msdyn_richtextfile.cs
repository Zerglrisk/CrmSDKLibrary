using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary_Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/powerapps/maker/model-driven-apps/rich-text-editor-control"/>
    /// <see cref="https://docs.microsoft.com/ru-ru/powerapps/developer/common-data-service/reference/entities/msdyn_richtextfile"/>
    public class msdyn_richtextfile
    {
        public static void getblob()
        {
            var qe = new QueryExpression("msdyn_richtextfile")
            {
                ColumnSet = new ColumnSet("msdyn_imageblob"),
                Criteria = new FilterExpression()
                {
                    Conditions =
                    {
                         new ConditionExpression("msdyn_richtextfileid", ConditionOperator.Equal, new Guid("8deff917-1035-eb11-a813-000d3a085bd4"))
                    }
                }
            };
            var ab = "";

            RetrieveMultipleRequest p = new RetrieveMultipleRequest()
            {
                //Parameters = new ParameterCollection() { new System.Collections.Generic.KeyValuePair<string, object>("size", "null") },
                Query = qe,
            };
            var rep = (RetrieveMultipleResponse)Connection.Service.Execute(p);
            if (rep.EntityCollection.Entities[0].Contains("msdyn_imageblob"))
            {
                ab = Convert.ToBase64String(rep.EntityCollection.Entities[0]["msdyn_imageblob"] as byte[]);
            }

            //"msdyn_imageblobid"
            var a = Connection.Service.RetrieveMultiple(qe);
            if (a.Entities[0].Contains("msdyn_imageblob"))
            {
                ab = Convert.ToBase64String(a.Entities[0]["msdyn_imageblob"] as byte[]);
            }
        }
    }
}
