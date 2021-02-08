using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rs.DataBase
{
    [Serializable]
    public class DataSettings: IConnectionStringAccessor
    {
        public DataSettings()
        {
            RawDataSettings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets a connection string
        /// </summary>
        [JsonPropertyName("DataConnectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets a data provider
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataProviderType DataProvider { get; set; }

        /// <summary>
        /// Gets or sets the wait time (in seconds) before terminating the attempt to execute a command and generating an error.
        /// By default, timeout isn't set and a default value for the current provider used. 
        /// Set 0 to use infinite timeout.
        /// </summary>
        public int? SQLCommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets a raw settings
        /// </summary>
        public IDictionary<string, string> RawDataSettings { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the information is entered
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public bool IsValid => DataProvider != DataProviderType.Unknown && !string.IsNullOrEmpty(ConnectionString);
    }
}
