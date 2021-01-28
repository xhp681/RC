﻿using System;
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
        public string SiteName { get; set; }
    }
}
