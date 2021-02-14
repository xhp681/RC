using Rs.Common;
using Rs.Config;
using Rs.Server.Plugins;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rs.Server
{
    public partial class RedisPluginsInfo: PluginsInfo
    {
        private readonly IDatabase _db;

        public RedisPluginsInfo(AppSettings appSettings, IRsFileProvider fileProvider, IRedisConnectionWrapper connectionWrapper)
            : base(fileProvider)
        {
            _db = connectionWrapper.GetDatabase(appSettings.RedisConfig.DatabaseId ?? (int)RedisDatabaseNumber.Plugin);
        }

        /// <summary>
        /// Save plugins info to the redis
        /// </summary>
        public override async Task SaveAsync()
        {
            var text = JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
            await _db.StringSetAsync(nameof(RedisPluginsInfo), text);
        }

        /// <summary>
        /// Save plugins info to the redis
        /// </summary>
        public override void Save()
        {
            var text = JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
            _db.StringSet(nameof(RedisPluginsInfo), text);
        }

        /// <summary>
        /// Get plugins info
        /// </summary>
        /// <returns>True if data are loaded, otherwise False</returns>
        public override async Task<bool> LoadPluginInfoAsync()
        {
            //try to get plugin info from the JSON file
            var serializedItem = await _db.StringGetAsync(nameof(RedisPluginsInfo));

            var loaded = false;

            if (serializedItem.HasValue)
                loaded = DeserializePluginInfo(serializedItem);

            if (loaded)
                return true;

            if (await base.LoadPluginInfoAsync())
            {
                await SaveAsync();
                loaded = true;
            }

            //delete the plugins info file
            var filePath = _fileProvider.MapPath(RsPluginDefaults.PluginsInfoFilePath);
            _fileProvider.DeleteFile(filePath);

            return loaded;
        }
    }
}
