namespace Rs.Config
{
    public static partial class RsConfigurationDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static CacheKey SettingsAllAsDictionaryCacheKey => new CacheKey("Nop.setting.all.dictionary.", RsEntityCacheDefaults<Setting>.Prefix);


        /// <summary>
        /// Gets the path to file that contains app settings
        /// </summary>
        public static string AppSettingsFilePath => "App_Data/appsettings.json";
    }
}