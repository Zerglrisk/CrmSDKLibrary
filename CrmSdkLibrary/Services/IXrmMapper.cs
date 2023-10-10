using Microsoft.Xrm.Sdk;

namespace CrmSdkLibrary.Services
{
	public interface IXrmMapper
	{
#if NET48 || NET462 || NET472
		T Map<T>(Entity entity) where T : new();

		Entity UnMap<T>(string entityLogicalName, T item);
#else

		public T Map<T>(Entity entity) where T : new();

		public Entity UnMap<T>(string entityLogicalName, T item);

#endif
	}
}