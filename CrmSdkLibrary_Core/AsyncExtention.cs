using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary_Core
{
    public static class AsyncExtention
    {
        public static async Task<T> ExecuteAsync<T>(this IOrganizationService sdk, OrganizationRequest request) where T : OrganizationResponse
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Execute(request) as T;
                return response;
            });

            return await t;
        }

        public static async Task<Entity> RetrieveAsync(this IOrganizationService sdk, string entityName, Guid id, ColumnSet columnSet)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Retrieve(entityName, id, columnSet);
                return response;
            });

            return await t;
        }

        public static async Task<EntityCollection> RetrieveMultipleAsync(this IOrganizationService sdk, QueryBase query)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.RetrieveMultiple(query);
                return response;
            });

            return await t;
        }

        public static async Task<Guid> CreateAsync(this IOrganizationService sdk, Entity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Create(entity);
                return response;
            });

            return await t;
        }

        public static async Task AssociateAsync(this IOrganizationService sdk, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Associate(entityName, entityId, relationship, relatedEntities);
            });

            await t;
        }

        public static async Task DeleteAsync(this IOrganizationService sdk, string entityName, Guid id)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Delete(entityName, id);
            });

            await t;
        }

        public static async Task DisassociateAsync(this IOrganizationService sdk, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Disassociate(entityName, entityId, relationship, relatedEntities);
            });

            await t;
        }

        public static async Task UpdateAsync(this IOrganizationService sdk, Entity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Update(entity);
            });

            await t;
        }

        public static async Task AuthenticateAsync(this ServiceProxy<IOrganizationService> sdk, Entity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Authenticate();
            });

            await t;
        }
    }
}
