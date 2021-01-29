using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    [Serializable]
    /// <summary>
    /// 系统配置
    /// </summary>
    public sealed class SiteConfig:BaseConfig
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SiteName { get; set; } = "川渝人才网";
        /// <summary>
        /// 系统域名
        /// </summary>
        public string Http { get; set; }
        /// <summary>
        /// 系统SEO优化，关键字
        /// </summary>
        public string KeyWords { get; set; }
        /// <summary>
        /// 系统SEO优化，描述
        /// </summary>
        public string Description { get; set; }
    }
}
