using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    [Serializable]
    /// <summary>
    /// 数据库配置
    /// </summary>
    public sealed class DbConfig:BaseConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
