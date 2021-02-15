using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server.ExportImport
{
    public partial interface IImportManager
    {
        /// <summary>
        /// Import products from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        Task ImportProductsFromXlsxAsync(Stream stream);

        /// <summary>
        /// Import newsletter subscribers from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Number of imported subscribers</returns>
        Task<int> ImportNewsletterSubscribersFromTxtAsync(Stream stream);

        /// <summary>
        /// Import states from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="writeLog">Indicates whether to add logging</param>
        /// <returns>Number of imported states</returns>
        Task<int> ImportStatesFromTxtAsync(Stream stream, bool writeLog = true);

        /// <summary>
        /// Import manufacturers from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        Task ImportManufacturersFromXlsxAsync(Stream stream);

        /// <summary>
        /// Import categories from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        Task ImportCategoriesFromXlsxAsync(Stream stream);
    }
}
