using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial interface IDownloadService
    {
        /// <summary>
        /// Gets a download
        /// </summary>
        /// <param name="downloadId">Download identifier</param>
        /// <returns>Download</returns>
        Task<Download> GetDownloadByIdAsync(int downloadId);

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>Download</returns>
        Task<Download> GetDownloadByGuidAsync(Guid downloadGuid);

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        Task DeleteDownloadAsync(Download download);

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        Task InsertDownloadAsync(Download download);

        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Download binary array</returns>
        Task<byte[]> GetDownloadBitsAsync(IFormFile file);
    }
}
