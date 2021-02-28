using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Rs.Common;

namespace Rs.Config
{
    internal static class JsonExtensions
    {
        public static T ReadConfigFile<T>(string jsonfile) where T : BaseConfig, new()
        {
            string CurrentPath = Directory.GetCurrentDirectory();
            string FileName= $"{CurrentPath}//{RsDefaults.ConfigDirectory}//{jsonfile}";
            if (!File.Exists(FileName))
                SaveConfigFile<T>(null, FileName);
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(FileName);
            IConfiguration configuration = builder.Build();
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
        public static void SaveConfigFile<T>(T obj, string jsonfile) where T : BaseConfig, new()
        {
            T t = obj == null ? new T() : obj;
            string CurrentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists($"{CurrentPath}//{RsDefaults.ConfigDirectory}"))
                Directory.CreateDirectory($"{CurrentPath}//{RsDefaults.ConfigDirectory}");
            if (!File.Exists(jsonfile))
            {
                string Content = JsonSerializer.Serialize<T>(t, new JsonSerializerOptions() { WriteIndented = true });
                using (FileStream fs = new FileStream(jsonfile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
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
