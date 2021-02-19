using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Rs.Common;

namespace Rs.DataBase
{
    public partial class DataSettingsManager
    {
        private static bool? _databaseIsInstalled;

        /// <summary>
        /// Gets data settings from the old txt file
        /// </summary>
        /// <param name="data">Old txt file data</param>
        /// <returns>Data settings</returns>
        protected static DataSettings LoadDataSettingsFromOldFile(string data)
        {
            var dataSettings = new DataSettings();
            using var reader = new StringReader(data);
            string settingsLine;
            while ((settingsLine = reader.ReadLine()) != null)
            {
                var separatorIndex = settingsLine.IndexOf(':');
                if (separatorIndex == -1)
                    continue;

                var key = settingsLine[0..separatorIndex].Trim();
                var value = settingsLine[(separatorIndex + 1)..].Trim();

                switch (key)
                {
                    case "DataProvider":
                        dataSettings.DataProvider = Enum.TryParse(value, true, out DataProviderType providerType) ? providerType : DataProviderType.Unknown;
                        continue;
                    case "DataConnectionString":
                        dataSettings.ConnectionString = value;
                        continue;
                    case "SQLCommandTimeout":
                        //If parsing isn't successful, we set a negative timeout, that means the current provider will usе a default value
                        dataSettings.SQLCommandTimeout = int.TryParse(value, out var timeout) ? timeout : -1;
                        continue;
                    default:
                        dataSettings.RawDataSettings.Add(key, value);
                        continue;
                }
            }

            return dataSettings;
        }

        /// <summary>
        /// Load data settings
        /// </summary>
        /// <param name="filePath">File path; pass null to use the default settings file</param>
        /// <param name="reloadSettings">Whether to reload data, if they already loaded</param>
        /// <param name="fileProvider">File provider</param>
        /// <returns>Data settings</returns>
        public static async Task<DataSettings> LoadSettingsAsync(string filePath = null, bool reloadSettings = false, IRsFileProvider fileProvider = null)
        {
            if (!reloadSettings && Singleton<DataSettings>.Instance != null)
                return Singleton<DataSettings>.Instance;

            fileProvider ??= Utils.DefaultFileProvider;
            filePath ??= fileProvider.MapPath(DataSettingsDefaults.FilePath);

            //check whether file exists
            if (!fileProvider.FileExists(filePath))
            {
                //if not, try to parse the file that was used in previous nopCommerce versions
                filePath = fileProvider.MapPath(DataSettingsDefaults.ObsoleteFilePath);
                if (!fileProvider.FileExists(filePath))
                    return new DataSettings();

                //get data settings from the old txt file
                var dataSettings =
                    LoadDataSettingsFromOldFile(await fileProvider.ReadAllTextAsync(filePath, Encoding.UTF8));

                //save data settings to the new file
                await SaveSettingsAsync(dataSettings, fileProvider);

                //and delete the old one
                fileProvider.DeleteFile(filePath);

                Singleton<DataSettings>.Instance = dataSettings;
                return Singleton<DataSettings>.Instance;
            }

            var text = await fileProvider.ReadAllTextAsync(filePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(text))
                return new DataSettings();

            //get data settings from the JSON file
            Singleton<DataSettings>.Instance = JsonSerializer.Deserialize<DataSettings>(text);

            return Singleton<DataSettings>.Instance;
        }

        /// <summary>
        /// Load data settings
        /// </summary>
        /// <param name="filePath">File path; pass null to use the default settings file</param>
        /// <param name="reloadSettings">Whether to reload data, if they already loaded</param>
        /// <param name="fileProvider">File provider</param>
        /// <returns>Data settings</returns>
        public static DataSettings LoadSettings(string filePath = null, bool reloadSettings = false, IRsFileProvider fileProvider = null)
        {
            if (!reloadSettings && Singleton<DataSettings>.Instance != null)
                return Singleton<DataSettings>.Instance;

            fileProvider ??= Utils.DefaultFileProvider;
            filePath ??= fileProvider.MapPath(DataSettingsDefaults.FilePath);

            //check whether file exists
            if (!fileProvider.FileExists(filePath))
            {
                //if not, try to parse the file that was used in previous nopCommerce versions
                filePath = fileProvider.MapPath(DataSettingsDefaults.ObsoleteFilePath);
                if (!fileProvider.FileExists(filePath))
                    return new DataSettings();

                //get data settings from the old txt file
                var dataSettings = LoadDataSettingsFromOldFile(fileProvider.ReadAllText(filePath, Encoding.UTF8));

                //save data settings to the new file
                SaveSettings(dataSettings, fileProvider);

                //and delete the old one
                fileProvider.DeleteFile(filePath);

                Singleton<DataSettings>.Instance = dataSettings;
                return Singleton<DataSettings>.Instance;
            }

            var text = fileProvider.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(text))
                return new DataSettings();

            //get data settings from the JSON file
            Singleton<DataSettings>.Instance = JsonSerializer.Deserialize<DataSettings>(text);

            return Singleton<DataSettings>.Instance;
        }

        /// <summary>
        /// Save data settings to the file
        /// </summary>
        /// <param name="settings">Data settings</param>
        /// <param name="fileProvider">File provider</param>
        public static async Task SaveSettingsAsync(DataSettings settings, IRsFileProvider fileProvider = null)
        {
            Singleton<DataSettings>.Instance = settings ?? throw new ArgumentNullException(nameof(settings));

            fileProvider ??= Utils.DefaultFileProvider;
            var filePath = fileProvider.MapPath(DataSettingsDefaults.FilePath);

            //create file if not exists
            fileProvider.CreateFile(filePath);

            //save data settings to the file
            var text = JsonSerializer.Serialize(Singleton<DataSettings>.Instance, new JsonSerializerOptions() { WriteIndented = true });
            await fileProvider.WriteAllTextAsync(filePath, text, Encoding.UTF8);
        }

        /// <summary>
        /// Save data settings to the file
        /// </summary>
        /// <param name="settings">Data settings</param>
        /// <param name="fileProvider">File provider</param>
        public static void SaveSettings(DataSettings settings, IRsFileProvider fileProvider = null)
        {
            Singleton<DataSettings>.Instance = settings ?? throw new ArgumentNullException(nameof(settings));

            fileProvider ??= Utils.DefaultFileProvider;
            var filePath = fileProvider.MapPath(DataSettingsDefaults.FilePath);

            //create file if not exists
            fileProvider.CreateFile(filePath);

            //save data settings to the file
            var text =JsonSerializer.Serialize(Singleton<DataSettings>.Instance);
            fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }

        /// <summary>
        /// Reset "database is installed" cached information
        /// </summary>
        public static void ResetCache()
        {
            _databaseIsInstalled = null;
        }

        /// <summary>
        /// Gets a value indicating whether database is already installed
        /// </summary>
        public static async Task<bool> IsDatabaseInstalledAsync()
        {
            _databaseIsInstalled ??= !string.IsNullOrEmpty((await LoadSettingsAsync(reloadSettings: true))?.ConnectionString);

            return _databaseIsInstalled.Value;
        }

        /// <summary>
        /// Gets a value indicating whether database is already installed
        /// </summary>
        public static bool IsDatabaseInstalled()
        {
            _databaseIsInstalled ??= !string.IsNullOrEmpty(LoadSettings(reloadSettings: true)?.ConnectionString);

            return _databaseIsInstalled.Value;
        }

        /// <summary>
        /// Gets the command execution timeout.
        /// </summary>
        /// <value>
        /// Number of seconds. Negative timeout value means that a default timeout will be used. 0 timeout value corresponds to infinite timeout.
        /// </value>
        public static async Task<int> GetSqlCommandTimeoutAsync()
        {
            return (await LoadSettingsAsync())?.SQLCommandTimeout ?? -1;
        }

        /// <summary>
        /// Gets the command execution timeout.
        /// </summary>
        /// <value>
        /// Number of seconds. Negative timeout value means that a default timeout will be used. 0 timeout value corresponds to infinite timeout.
        /// </value>
        public static int GetSqlCommandTimeout()
        {
            return (LoadSettings())?.SQLCommandTimeout ?? -1;
        }

    }
}