using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Linq;

namespace CrmSdkLibrary.Dataverse
{
    public class EntityUtility
    {
        private readonly ServiceClient Service;

        public EntityUtility(ServiceClient service)
        {
            this.Service = service;
        }

        public EntityMetadataCollection GetEntitiesMetadata(params string[] entityLogicalNames)
        {
            this.Service.Validate();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)this.Service.Execute(request);

            EntityMetadataCollection entityMetadatas = new EntityMetadataCollection();

            if (entityLogicalNames != null && entityLogicalNames.Length > 0)
            {
                foreach (string entityLogicalName in entityLogicalNames)
                {
                    var temp = response.EntityMetadata.FirstOrDefault(x => x.LogicalName.Equals(entityLogicalName, StringComparison.CurrentCultureIgnoreCase));
                    if (temp != null)
                    {
                        //if (isOnlyCustomEntity && temp.IsCustomEntity.HasValue && temp.IsCustomEntity.Value)
                        //{
                        //    entities.Add(temp);
                        //}
                        entityMetadatas.Add(temp);
                    }
                }
            }
            else
            {
                entityMetadatas.AddRange(response.EntityMetadata);
            }

            return entityMetadatas;
        }

        public EntityMetadataCollection GetEntitiesMetadata(Func<EntityMetadata, bool> predicate)
        {
            this.Service.Validate();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)this.Service.Execute(request);

            var customEntities = response.EntityMetadata
                .Where(x => x.IsCustomEntity == true && predicate(x))
                .ToList();

            EntityMetadataCollection entityMetadatas = new EntityMetadataCollection();
            entityMetadatas.AddRange(customEntities);

            return entityMetadatas;
        }

        public DateTime? GetEntityCreatedOn(string entityLogicalName)
        {
            if (string.IsNullOrEmpty(entityLogicalName))
            {
                return null;
            }

            this.Service.Validate();

            RetrieveEntityRequest request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true,
                LogicalName = entityLogicalName
            };

            var response = (RetrieveEntityResponse)this.Service.Execute(request);

            return response.EntityMetadata.CreatedOn;
        }

        public EntityMetadata GetEntityMetadata(string entityLogicalName)
        {
            if (string.IsNullOrEmpty(entityLogicalName))
            {
                return null;
            }

            this.Service.Validate();

            RetrieveEntityRequest request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true,
                LogicalName = entityLogicalName
            };

            var response = (RetrieveEntityResponse)this.Service.Execute(request);

            return response.EntityMetadata;
        }
    }
}