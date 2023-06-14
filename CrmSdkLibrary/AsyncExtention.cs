using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    public static class AsyncExtention
    {
        public static async Task AssociateAsync(this IOrganizationService service, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            var t = Task.Factory.StartNew(() =>
            {
                service.Associate(entityName, entityId, relationship, relatedEntities);
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
            });

            await t;
        }

        public static async Task AuthenticateAsync(this ServiceProxy<IOrganizationService> sdk)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Authenticate();
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
            });

            await t;
        }

        public static async Task<Guid> CreateAsync(this IOrganizationService sdk, Entity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Create(entity);
                return response;
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
                else { return task.Result; }
            });

            return await t;
            //await t;
            //if (t.IsFaulted) { throw t.Exception.Flatten(); }
            //return t.Result;
        }

        public static async Task DeleteAsync(this IOrganizationService sdk, string entityName, Guid id)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Delete(entityName, id);
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
            });

            await t;
        }

        public static async Task DisassociateAsync(this IOrganizationService sdk, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Disassociate(entityName, entityId, relationship, relatedEntities);
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
            });

            await t;
        }

        public static async Task<T> ExecuteAsync<T>(this IOrganizationService sdk, OrganizationRequest request) where T : OrganizationResponse
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Execute(request) as T;
                return response;
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
                else { return task.Result; }
            });

            return await t;
        }

        public static async Task<Entity> RetrieveAsync(this IOrganizationService sdk, string entityName, Guid id, ColumnSet columnSet)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.Retrieve(entityName, id, columnSet);
                return response;
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
                else { return task.Result; }
            });

            return await t;
        }

        public static async Task<EntityCollection> RetrieveMultipleAsync(this IOrganizationService sdk, QueryBase query)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var response = sdk.RetrieveMultiple(query);
                return response;
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
                else { return task.Result; }
            });

            return await t;
        }

        public static async Task UpdateAsync(this IOrganizationService sdk, Entity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                sdk.Update(entity);
            }).ContinueWith(task =>
            {
                if (task.IsFaulted) { throw task.Exception.Flatten(); }
            });

            await t;
        }
    }
}