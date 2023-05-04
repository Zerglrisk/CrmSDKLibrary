using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmSdkLibrary_Core;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;

namespace CrmSdkLibrary_Core
{
    public class Bulk
    {

        public static void UpdateBulk(EntityCollection ec, bool continueOnError = true)
        {
            var service = Connection.Service;

            var loopCount = (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);

            for (var i = 0; i < loopCount; i++)
            {
                try
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
                        var updateRequest = new UpdateRequest() { Target = ec.Entities.ElementAt(j) };
                        multipleRequest.Requests.Add(updateRequest);
                    }

                    // Execute all the requests in the request collection using a single web method call.
                    var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);

                    if (!multipleResponse.Responses.Any()) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) +
                                                    Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                        ec.Entities[(i * 1000) + response.RequestIndex]));
                            }
                        }
                        else
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                        ec.Entities[(i * 1000) + response.RequestIndex]));
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

        public static void CreateBulk(EntityCollection ec, bool continueOnError = true)
        {
            var service = Connection.Service;

            var loopCount = (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);

            for (var i = 0; i < loopCount; i++)
            {
                try
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
                        var createRequest = new CreateRequest { Target = ec.Entities.ElementAt(j) };
                        multipleRequest.Requests.Add(createRequest);
                    }

                    // Execute all the requests in the request collection using a single web method call.
                    var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);

                    if (!multipleResponse.Responses.Any()) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(ec.Entities[(i * 1000) + response.RequestIndex]));
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
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static void DeleteBulk(string entityLogicalName, List<Guid> entities, bool continueOnError = true)
        {
            Bulk.DeleteBulk(entities.Select(x => new EntityReference(entityLogicalName, x)).ToList(), continueOnError);
        }
        public static void DeleteBulk(List<EntityReference> entityReferences, bool continueOnError = true)
        {
            var service = Connection.Service;

            var loopCount = (entityReferences.Count / 1000) + (entityReferences.Count % 1000 != 0 ? 1 : 0);

            for (var i = 0; i < loopCount; i++)
            {
                try
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
                    var end = entityReferences.Count <= (i + 1) * 1000 ? entityReferences.Count : (i + 1) * 1000;

                    for (var j = start; j < end; j++)
                    {
                        var deleteRequest = new DeleteRequest() { Target = entityReferences.ElementAt(j) };
                        multipleRequest.Requests.Add(deleteRequest);
                    }

                    // Execute all the requests in the request collection using a single web method call.
                    var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);

                    if (!multipleResponse.Responses.Any()) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) +
                                                    Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                       entityReferences[(i * 1000) + response.RequestIndex]));
                            }
                        }
                        else
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                        entityReferences[(i * 1000) + response.RequestIndex]));
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
        public static void DeleteBulk(EntityCollection ec, bool continueOnError = true)
        {
            var service = Connection.Service;
            var loopCount = (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);
            for (var i = 0; i < loopCount; i++)
            {
                try
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
                        var deleteRequest = new DeleteRequest() { Target = ec.Entities.ElementAt(j).ToEntityReference() };
                        multipleRequest.Requests.Add(deleteRequest);
                    }
                    // Execute all the requests in the request collection using a single web method call.
                    var multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);
                    if (!multipleResponse.Responses.Any()) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) +
                                                    Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                        ec.Entities[(i * 1000) + response.RequestIndex]));
                            }
                        }
                        else
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(
                                                        ec.Entities[(i * 1000) + response.RequestIndex]));
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

        /// <summary>
        /// Add Member List Into Marketing List(마케팅 목록)
        /// </summary>
        /// <param name="listId">Marketing List Id</param>
        /// <param name="ec"></param>
        /// <param name="continueOnError"></param>
        public static void AddMemberList(Guid listId, EntityCollection ec, bool continueOnError = true)
        {
            var service = Connection.Service;
            try
            {
                var loopCount = (ec.Entities.Count / 1000) + (ec.Entities.Count % 1000 != 0 ? 1 : 0);
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

                    if (!multipleResponse.Responses.Any()) continue;
                    foreach (var response in multipleResponse.Responses)
                    {
                        if (response.Fault == null) continue;
                        if (response.Fault.InnerFault != null)
                        {
                            //error
                            if (!continueOnError)
                            {
                                throw new Exception(JsonConvert.SerializeObject(response.Fault.InnerFault) + Environment.NewLine +
                                                    JsonConvert.SerializeObject(ec.Entities[(i * 1000) + response.RequestIndex]));
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
