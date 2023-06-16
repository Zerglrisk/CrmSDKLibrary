using Microsoft.Xrm.Sdk;

namespace CrmSdkLibrary_Core.Services
{
    public interface IXrmMapper
    {
        public T Map<T>(Entity entity) where T : new();

        public Entity UnMap<T>(string entityLogicalName, T item);
    }
}