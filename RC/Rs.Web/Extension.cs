using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Rs.Common;
using Rs.Config;


namespace Rs.Web
{
    public static class Extension
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="jsonfilename">Json文件名称,默认为Rs.json</param>
        /// <returns></returns>
        public static IConfiguration ReadConfigFile(string jsonfilename= "Rs.json")
        {
            string filename = Utils.ContentRootMapPath($"Config\\{jsonfilename}");
            IConfigurationBuilder builder= new ConfigurationBuilder().AddJsonFile(filename);
            return builder.Build();
        }
        /// <summary>
        /// 读取相应的配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonfilename"></param>
        /// <returns></returns>
        public static T ReadConfigFile<T>(string jsonfilename = "Rs.json")where T:BaseConfig,new()
        {
            T t = new T();
            IConfiguration configuration = ReadConfigFile(jsonfilename);
            t = configuration.Get<T>();
            return t;
        }
    }
}
