using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Dataverse
{
	public static class AsyncExtensions
    {
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.AssociateAsync instead.")]

        public static async Task AssociateAsync(this IOrganizationService service, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				service.Associate(entityName, entityId, relationship, relatedEntities);
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
			});

			await t;
		}


        public static async Task AuthenticateAsync(this ServiceProxy<IOrganizationService> service, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				service.Authenticate();
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
			});

			await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.CreateAsync instead.")]

        public static async Task<Guid> CreateAsync(this IOrganizationService service, Entity entity, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				var response = service.Create(entity);
				return response;
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
				else { return task.Result; }
			});

			return await t;

			//await t;
			//if (t.IsFaulted) { throw t.Exception.Flatten(); }
			//return t.Result;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.DeleteAsync instead.")]

        public static async Task DeleteAsync(this IOrganizationService service, string entityName, Guid id, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				service.Delete(entityName, id);
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
			});

			await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.DisassociateAsync instead.")]

        public static async Task DisassociateAsync(this IOrganizationService service, string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				service.Disassociate(entityName, entityId, relationship, relatedEntities);
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
			});

			await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.ExecuteAsync instead.")]

        public static async Task<T> ExecuteAsync<T>(this IOrganizationService service, OrganizationRequest request, CancellationToken cancellationToken = default) where T : OrganizationResponse
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				var response = service.Execute(request) as T;
				return response;
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
				else { return task.Result; }
			});

			return await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.RetrieveAsync instead.")]

        public static async Task<Entity> RetrieveAsync(this IOrganizationService service, string entityName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();
				var response = service.Retrieve(entityName, id, columnSet);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				return response;
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
				else { return task.Result; }
			});

			return await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.RetrieveMultipleAsync instead.")]

        public static async Task<EntityCollection> RetrieveMultipleAsync(this IOrganizationService service, QueryBase query, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();
				var response = service.RetrieveMultiple(query);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				return response;
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
				else { return task.Result; }
			});

			return await t;
		}
        [Obsolete("This method is deprecated as it is now officially supported in Microsoft.PowerPlatform.Dataverse.Client (v1.1.32 or later). Please use ServiceClient.UpdateAsync instead.")]

        public static async Task UpdateAsync(this IOrganizationService service, Entity entity, CancellationToken cancellationToken = default)
		{
			var t = Task.Factory.StartNew(() =>
			{
				// throw if already canceled
				cancellationToken.ThrowIfCancellationRequested();

				//Wait 0.1 Sec Who Cancel Command - Cuz cannot revert doing Execute
				Thread.Sleep(100);
				if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
				service.Update(entity);
			}, cancellationToken).ContinueWith(task =>
			{
				if (task.IsFaulted) { throw task.Exception.Flatten(); }
			});

			await t;
		}
	}
}