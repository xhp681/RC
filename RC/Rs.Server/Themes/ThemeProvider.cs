using Rs.Common;
using Rs.Server.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rs.Server.Themes
{
    public partial class ThemeProvider:IThemeProvider
    {
        private static readonly object _locker = new object();

        private readonly IRsFileProvider _fileProvider;

        protected Dictionary<string, ThemeDescriptor> _themeDescriptors;
        public ThemeProvider(IRsFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            Initialize();
        }

        /// <summary>
        /// Initializes theme provider
        /// </summary>
        protected virtual void Initialize()
        {
            if (_themeDescriptors != null)
                return;

            //prevent multi loading data
            lock (_locker)
            {
                //data can be loaded while we waited
                if (_themeDescriptors != null)
                    return;

                //load all theme descriptors
                _themeDescriptors =
                    new Dictionary<string, ThemeDescriptor>(StringComparer.InvariantCultureIgnoreCase);

                var themeDirectoryPath = _fileProvider.MapPath(RsPluginDefaults.ThemesPath);
                foreach (var descriptionFile in _fileProvider.GetFiles(themeDirectoryPath,
                    RsPluginDefaults.ThemeDescriptionFileName, false))
                {
                    var text = _fileProvider.ReadAllText(descriptionFile, Encoding.UTF8);
                    if (string.IsNullOrEmpty(text))
                        continue;

                    //get theme descriptor
                    var themeDescriptor = GetThemeDescriptorFromText(text);

                    //some validation
                    if (string.IsNullOrEmpty(themeDescriptor?.SystemName))
                        throw new Exception($"A theme descriptor '{descriptionFile}' has no system name");

                    _themeDescriptors.TryAdd(themeDescriptor.SystemName, themeDescriptor);
                }
            }
        }

        /// <summary>
        /// Get theme descriptor from the description text
        /// </summary>
        /// <param name="text">Description text</param>
        /// <returns>Theme descriptor</returns>
        public ThemeDescriptor GetThemeDescriptorFromText(string text)
        {
            //get theme description from the JSON file
            var themeDescriptor =JsonSerializer.Deserialize<ThemeDescriptor>(text);

            //some validation
            if (_themeDescriptors.ContainsKey(themeDescriptor.SystemName))
                throw new Exception($"A theme with '{themeDescriptor.SystemName}' system name is already defined");

            return themeDescriptor;
        }

        /// <summary>
        /// Get all themes
        /// </summary>
        /// <returns>List of the theme descriptor</returns>
        public Task<IList<ThemeDescriptor>> GetThemesAsync()
        {
            return Task.FromResult<IList<ThemeDescriptor>>(_themeDescriptors.Values.ToList());
        }

        /// <summary>
        /// Get a theme by the system name
        /// </summary>
        /// <param name="systemName">Theme system name</param>
        /// <returns>Theme descriptor</returns>
        public Task<ThemeDescriptor> GetThemeBySystemNameAsync(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return Task.FromResult<ThemeDescriptor>(null);

            _themeDescriptors.TryGetValue(systemName, out var descriptor);

            return Task.FromResult(descriptor);
        }

        /// <summary>
        /// Check whether the theme with specified system name exists
        /// </summary>
        /// <param name="systemName">Theme system name</param>
        /// <returns>True if the theme exists; otherwise false</returns>
        public Task<bool> ThemeExistsAsync(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return Task.FromResult(false);

            return Task.FromResult(_themeDescriptors.ContainsKey(systemName));
        }
    }
}
