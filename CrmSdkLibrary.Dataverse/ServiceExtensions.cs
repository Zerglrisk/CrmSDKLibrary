using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerPlatform.Dataverse.Client;
using System.Threading;

namespace CrmSdkLibrary.Dataverse
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Retrieves all records matching the query by handling paging automatically
        /// </summary>
        /// <param name="service">The organization service</param>
        /// <param name="query">The query to execute</param>
        /// <returns>An EntityCollection containing all matching records</returns>
        public static EntityCollection RetrieveMultipleAll(this IOrganizationService service, QueryExpression query)
        {
            var temp = service.RetrieveMultiple(query);
            var ec = new EntityCollection(temp.Entities);

            int pageNumber = 1;
            while (temp.MoreRecords)
            {
                // 다음 페이지를 위한 설정
                query.PageInfo = new PagingInfo
                {
                    PageNumber = ++pageNumber,
                    PagingCookie = temp.PagingCookie,
                    Count = query.PageInfo?.Count ?? 5000
                };

                // 다음 페이지 조회
                temp = service.RetrieveMultiple(query);

                // 결과를 누적
                ec.Entities.AddRange(temp.Entities);

                // MoreRecords 상태 업데이트
                ec.MoreRecords = temp.MoreRecords;
                ec.PagingCookie = temp.PagingCookie;
                ec.TotalRecordCount += temp.Entities.Count;
            }

            return ec;
        }

        /// <summary>
        /// Asynchronously retrieves all records matching the query by handling paging automatically
        /// </summary>
        /// <param name="service">The organization service</param>
        /// <param name="query">The query to execute</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public static async Task<EntityCollection> RetrieveMultipleAllAsync(
            this ServiceClient service,
            QueryExpression query,
            CancellationToken cancellationToken = default)
        {
            var result = await service.RetrieveMultipleAsync(query, cancellationToken);
            var allRecords = new EntityCollection(result.Entities);

            int pageNumber = 1;
            while (result.MoreRecords)
            {
                cancellationToken.ThrowIfCancellationRequested();

                query.PageInfo = new PagingInfo
                {
                    PageNumber = ++pageNumber,
                    PagingCookie = result.PagingCookie,
                    Count = query.PageInfo?.Count ?? 5000
                };

                result = await service.RetrieveMultipleAsync(query, cancellationToken);

                allRecords.Entities.AddRange(result.Entities);
                allRecords.MoreRecords = result.MoreRecords;
                allRecords.PagingCookie = result.PagingCookie;
                allRecords.TotalRecordCount += result.Entities.Count;
            }

            return allRecords;
        }

        /// <summary>
        /// Asynchronously retrieves all records matching the query by handling paging automatically with progress reporting
        /// </summary>
        /// <param name="service">The organization service</param>
        /// <param name="query">The query to execute</param>
        /// <param name="progress">Optional progress reporter</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public static async Task<EntityCollection> RetrieveMultipleAllAsync(
            this ServiceClient service,
            QueryExpression query,
            IProgress<(int CurrentPage, int RetrievedRecords)> progress,
            CancellationToken cancellationToken = default)
        {
            var result = await service.RetrieveMultipleAsync(query, cancellationToken);
            var allRecords = new EntityCollection(result.Entities);

            progress?.Report((1, result.Entities.Count));

            int pageNumber = 1;
            while (result.MoreRecords)
            {
                cancellationToken.ThrowIfCancellationRequested();

                query.PageInfo = new PagingInfo
                {
                    PageNumber = ++pageNumber,
                    PagingCookie = result.PagingCookie,
                    Count = query.PageInfo?.Count ?? 5000
                };

                result = await service.RetrieveMultipleAsync(query, cancellationToken);

                allRecords.Entities.AddRange(result.Entities);
                allRecords.MoreRecords = result.MoreRecords;
                allRecords.PagingCookie = result.PagingCookie;
                allRecords.TotalRecordCount += result.Entities.Count;

                progress?.Report((pageNumber, allRecords.TotalRecordCount));
            }

            return allRecords;
        }
    }
}
