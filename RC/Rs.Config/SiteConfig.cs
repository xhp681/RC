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
        public string SiteName { get; set; } = "川渝人才网|川渝两地专业的人才网";
        /// <summary>
        /// 系统域名
        /// </summary>
        public string Http { get; set; } = "CyRc.com";
        /// <summary>
        /// 系统SEO优化，关键字
        /// </summary>
        public string KeyWords { get; set; } = "川渝人才,川渝人才网,大四川大重庆人才网,四川招聘，重庆招聘,CyRc.com,成渝找工作";
        /// <summary>
        /// 系统SEO优化，描述
        /// </summary>
        public string Description { get; set; } = "川渝人才网是四川重庆两地人才求职和大四川大重庆企业招聘最佳选择，作为川渝人才网更专注于四川重庆两地网络招聘和人才精英的选拔，给企业部门提供精确人才简历查询，让四川、重庆两地人才透过职位搜索功能查阅川渝人才市场动态行情，正确的测评四川重庆两地人才能力等。";
        /// <summary>
        /// 电信业务经营许可证
        /// </summary>
        public string ICPLience { get; set; }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string WRNCode { get; set; }
        /// <summary>
        /// 网公安备案号
        /// </summary>
        public string IPSCode { get; set; }
    }
}
