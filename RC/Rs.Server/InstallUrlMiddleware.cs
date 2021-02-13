using Microsoft.AspNetCore.Http;
using Rs.Common;
using Rs.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server
{
    public class InstallUrlMiddleware
    {
        private readonly RequestDelegate _next;
        public InstallUrlMiddleware(RequestDelegate next)
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
            if (!await DataSettingsManager.IsDatabaseInstalledAsync())
            {
                var installUrl = $"{webHelper.GetStoreLocation()}{RsInstallationDefaults.InstallPath}";
                if (!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
                {
                    //redirect
                    context.Response.Redirect(installUrl);
                    return;
                }
            }

            //or call the next middleware in the request pipeline
            await _next(context);
        }
    }
}
