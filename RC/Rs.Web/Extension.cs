using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Rs.Common;
using Rs.Config;


namespace Rs.Web
{
    public static partial class Extension
    {
        /// <summary>
        /// 所有的配置文件均保留在此文件夹下
        /// </summary>
        private static string ConfitDir = Utils.ContentRootMapPath("Config");
        /// <summary>
        /// 系统配置文件名称
        /// </summary>
        public static string SiteConfigFile = "site.json";
        /// <summary>
        /// 读取相应的配置文件
        /// </summary>
        /// <typeparam name="T">配置文件对象</typeparam>
        /// <param name="jsonfilename">JSON文件名称</param>
        /// <returns></returns>
        public static T ReadConfigFile<T>(string jsonfilename = "rs.json")where T:BaseConfig,new()
        {
            if (!Directory.Exists(ConfitDir))
                Directory.CreateDirectory(ConfitDir);
            string filename = $"{ConfitDir}\\{jsonfilename}";
            if (!File.Exists(filename))
                SaveConfigFile<T>(null,jsonfilename);
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(filename);
            IConfiguration configuration= builder.Build();
            T t = configuration.Get<T>();
            return t;
        }
        /// <summary>
        /// 配置文件保存
        /// 保存后的JSON是字符串，未被格式化，有待解决
        /// </summary>
        /// <typeparam name="T">被保存对象</typeparam>
        /// <param name="Path">文件保存路径</param>
        /// <param name="jsonfilename">JSON文件名称</param>
        public static void SaveConfigFile<T>(T obj, string jsonfilename = "rs.json") where T : BaseConfig, new()
        {
            T t =obj==null?new T():obj;
            if (!Directory.Exists(ConfitDir))
                Directory.CreateDirectory(ConfitDir);
            string filename = $"{ConfitDir}\\{jsonfilename}";
            if (!File.Exists(filename))
            {
                string Content = JsonSerializer.Serialize<T>(t);
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.GetEncoding("utf-8")))
                    {
                        writer.WriteAsync(Content);
                    }
                }
            }
        }
    }
}
