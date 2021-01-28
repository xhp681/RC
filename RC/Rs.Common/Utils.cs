using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Common
{
    public class Utils
    {
        /// <summary>
        /// 系统绝对目录
        /// </summary>
        public static string RootDictionaryPath { get; set; } = AppContext.BaseDirectory;
        /// <summary>
        /// 系统虚拟目录
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public static string ContentRootMapPath(string virtualPath)
        {
            if (string.IsNullOrEmpty(virtualPath))
            {
                return string.Empty;
            }
            else
            {
                var path = Path.DirectorySeparatorChar.ToString();
                var altPath = Path.AltDirectorySeparatorChar.ToString();
                if (!RootDictionaryPath.EndsWith(path) && !RootDictionaryPath.EndsWith(altPath))
                {
                    RootDictionaryPath += path;
                }

                if (virtualPath.StartsWith("~/"))
                {
                    return virtualPath.Replace("~/", RootDictionaryPath).Replace("/", path);
                }
                else
                {
                    return Path.Combine(RootDictionaryPath, virtualPath);
                }
            }
        }
    }
}
