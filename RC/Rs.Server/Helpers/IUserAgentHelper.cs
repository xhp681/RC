using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server.Helpers
{
    public interface IUserAgentHelper
    {
        /// <summary>
        /// Get a value indicating whether the request is made by search engine (web crawler)
        /// </summary>
        /// <returns>Result</returns>
        bool IsSearchEngine();

        /// <summary>
        /// Get a value indicating whether the request is made by mobile device
        /// </summary>
        /// <returns></returns>
        bool IsMobileDevice();
    }
}
