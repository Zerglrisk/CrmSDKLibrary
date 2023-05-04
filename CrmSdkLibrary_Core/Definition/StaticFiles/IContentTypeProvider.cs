using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CrmSdkLibrary_Core.Definition.StaticFiles
{
    /// <summary>
    /// Used to look up MIME types given a file path
    /// </summary>
    /// <see href="https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/IContentTypeProvider.cs"/>
    public interface IContentTypeProvider
    {
        /// <summary>
        /// Given a file path, determine the MIME type
        /// </summary>
        /// <param name="subpath">A file path</param>
        /// <param name="contentType">The resulting MIME type</param>
        /// <returns>True if MIME type could be determined</returns>
        bool TryGetContentType(string subpath, [MaybeNullWhen(false)] out string contentType);
    }
}
