using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rs.Config
{
    /// <summary>
    /// 数据库配置文件
    /// </summary>
    [Serializable]
    internal class DbConfig:BaseConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        [JsonPropertyName("DataConnectionString")]
        public string ConnectionString { get; set; }
        //public int? SQLCommandTimeout { get; set; }
    }
}
