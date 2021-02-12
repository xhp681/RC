using Rs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rs.Config
{
    public partial class AppSettingsHelper
    {
        /// <summary>
        /// Save app settings to the file
        /// </summary>
        /// <param name="appSettings">App settings</param>
        /// <param name="fileProvider">File provider</param>
        public static async Task SaveAppSettingsAsync(AppSettings appSettings, IRsFileProvider fileProvider = null)
        {
            Singleton<AppSettings>.Instance = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

            fileProvider ??= Utils.DefaultFileProvider;

            //create file if not exists
            var filePath = fileProvider.MapPath(RsConfigurationDefaults.AppSettingsFilePath);
            fileProvider.CreateFile(filePath);

            //check additional configuration parameters
            var additionalData =JsonSerializer.Deserialize<AppSettings>(await fileProvider.ReadAllTextAsync(filePath, Encoding.UTF8))?.AdditionalData;
            appSettings.AdditionalData = additionalData;

            //save app settings to the file
            var text =JsonSerializer.Serialize(appSettings, new JsonSerializerOptions() { WriteIndented = true });
            await fileProvider.WriteAllTextAsync(filePath, text, Encoding.UTF8);
        }

        /// <summary>
        /// Save app settings to the file
        /// </summary>
        /// <param name="appSettings">App settings</param>
        /// <param name="fileProvider">File provider</param>
        public static void SaveAppSettings(AppSettings appSettings, IRsFileProvider fileProvider = null)
        {
            Singleton<AppSettings>.Instance = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

            fileProvider ??= Utils.DefaultFileProvider;

            //create file if not exists
            var filePath = fileProvider.MapPath(RsConfigurationDefaults.AppSettingsFilePath);
            fileProvider.CreateFile(filePath);

            //check additional configuration parameters
            var additionalData =JsonSerializer.Deserialize<AppSettings>(fileProvider.ReadAllText(filePath, Encoding.UTF8))?.AdditionalData;
            appSettings.AdditionalData = additionalData;

            //save app settings to the file
            var text =JsonSerializer.Serialize(appSettings, new JsonSerializerOptions() { WriteIndented = true });
            fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }
    }
}
