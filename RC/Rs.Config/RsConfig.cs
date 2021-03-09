using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rs.Config
{
    /// <summary>
    /// 应用程序设置
    /// </summary>
    [Serializable]
    public class RsConfig: BaseConfig
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "鹿璞生态城";
        [JsonPropertyName("keyword")]
        public string KeyWords { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Descriptions { get; set; } = string.Empty;
        /// <summary>
        /// 是否关闭注册功能
        /// </summary>
        [JsonPropertyName("iscloseregflag")]
        public bool IsCloseReg { get; set; } = false;
    }
}
