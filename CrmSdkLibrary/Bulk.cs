using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;

namespace CrmSdkLibrary
{
    public  class Bulk
    {

        public static void UpdateBulk()
        {

        }

        public static void CreateBulk()
        {

        }

        public static void DeleteBulk()
        {

        }

        public static void a()
        {

        }

        /// <summary>
        /// Add Member List Into Marketing List(마케팅 목록)
        /// </summary>
        /// <param name="listId">Marketing List Id</param>
        /// <param name="ec"></param>
        /// <param name="continueOnError"></param>
        public static void AddMemberList(Guid listId, EntityCollection ec,bool continueOnError = true)
        {
            var service = Connection.OrgService;
            try
            {
                var loopCount= (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);
                for (var i = 0; i < loopCount; i++)
                {
                    var multipleRequest = new ExecuteMultipleRequest()
                    {
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = continueOnError,
                            ReturnResponses = true,
                        },
                        Requests = new OrganizationRequestCollection()
                    };


                    var start = (i * 1000);
                    var end = ec.Entities.Count <= (i + 1) * 1000 ? ec.Entities.Count : (i + 1) * 1000;

                    for (var j = start; j < end; j++)
                    {
                        var addMemberListRequest = new AddMemberListRequest()
                        {
                            EntityId = ec.Entities.ElementAt(j).Id,
                            ListId = listId
                        };
                        multipleRequest.Requests.Add(addMemberListRequest);
                    }

                    // Execute all the requests in the request collection using a single web method call.
                    var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);

                    if (multipleResponse.Responses.Count <= 0) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(ec.Entities[(i*1000) + response.RequestIndex]));
                            }
                        }
                        else
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(ec.Entities[(i * 1000) + response.RequestIndex]));
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
