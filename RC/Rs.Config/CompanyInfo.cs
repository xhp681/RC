using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    /// <summary>
    /// 公司基本信息
    /// </summary>
    public sealed class CompanyInfo
    {
        /// <summary>
        /// 公司名字
        /// </summary>
        public string Name { get; set; } = "川渝软件开发工作室有限责任公司";
        /// <summary>
        /// 公司所在地址
        /// </summary>
        public string Address { get; set; } = "平昌县鹿鸣镇向氏集团13楼22号";
        /// <summary>
        /// 公司所在地邮政编码
        /// </summary>
        public string PostCode { get; set; } = "640014";
        /// <summary>
        /// 服务电话,多个电话用'|'分开
        /// </summary>
        public string ServerPhone { get; set; } = "15828469068|0827-6818083|028-86131401";
        /// <summary>
        /// 投诉电话
        /// </summary>
        public string ComplainPhone { get; set; } = "12345";
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Emil
        /// </summary>
        public string Email { get; set; } = "527883283@qq.com";
    }
}
