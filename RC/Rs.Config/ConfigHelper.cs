using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rs.Common;

namespace Rs.Config
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 初始化系统配置文件
        /// </summary>
        public static RsConfig InitRsConfig()
        {
            return JsonExtensions.ReadConfigFile<RsConfig>(RsDefaults.RsConfig);
        }
        /// <summary>
        /// 读取数据库配置文件
        /// </summary>
        public static string ReadDbConfig()
        {
            DbConfig config=JsonExtensions.ReadConfigFile<DbConfig>(RsDefaults.DbConfig);
            return config.ConnectionString;
        }
    }
}
