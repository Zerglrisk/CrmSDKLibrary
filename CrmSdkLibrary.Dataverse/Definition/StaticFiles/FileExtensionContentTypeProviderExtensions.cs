using System;
using System.Collections.Generic;
using System.Text;

namespace CrmSdkLibrary.Dataverse.Definition.StaticFiles
{
	public static class FileExtensionContentTypeProviderExtensions
	{
		public static string GetMimeMapping(this FileExtensionContentTypeProvider provider, string fileFullPath, string defaultContentType = "application/octet-stream")
		{
			if (!provider.TryGetContentType(fileFullPath, out string contentType))
			{
				contentType = defaultContentType;
			}
			return contentType;
		}
	}
}
