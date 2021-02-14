using Microsoft.AspNetCore.Http;
using Rs.Common;
using Rs.Config;
using Rs.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server
{
    public class KeepAliveMiddleware
    {
        private readonly RequestDelegate _next;
        public KeepAliveMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke middleware actions
        /// </summary>
        /// <param name="context">HTTP context</param>
        /// <param name="webHelper">Web helper</param>
        /// <returns>Task</returns>
        public async Task InvokeAsync(HttpContext context, IWebHelper webHelper)
        {
            //whether database is installed
            if (await DataSettingsManager.IsDatabaseInstalledAsync())
            {
                //keep alive page requested (we ignore it to prevent creating a guest customer records)
                var keepAliveUrl = $"{webHelper.GetStoreLocation()}{Rs.Config.RsCommonDefaults.KeepAlivePath}";
                if ((webHelper.GetThisPageUrl(false)).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                    return;
            }

            //or call the next middleware in the request pipeline
            await _next(context);
        }
    }
}
