using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    /// <summary>
    /// 系统配置对象
    /// </summary>
    public sealed class RsConfig:BaseConfig
    {
        /// <summary>
        /// 系统路径
        /// </summary>
        public string ApplicationPath { get; set; } = "/";
        /// <summary>
        /// 文件上传路径
        /// </summary>
        public string UpLoadPath { get; set; } = "~/Upload";
    }
}
