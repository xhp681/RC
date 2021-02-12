﻿using Microsoft.Extensions.DependencyInjection;
using Rs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server
{
    public static class HttpClientBuilderExtensions
    {
        /// <summary>
        /// Configure proxy connection for HTTP client (if enabled)
        /// </summary>
        /// <param name="httpClientBuilder">A builder for configuring HttpClient</param>
        public static void WithProxy(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();

                //whether proxy is enabled
                var proxySettings = EngineContext.Current.Resolve<ProxySettings>();
                if (!proxySettings.Enabled)
                    return handler;

                //configure proxy connection
                var webProxy = new WebProxy($"{proxySettings.Address}:{proxySettings.Port}", proxySettings.BypassOnLocal);
                if (!string.IsNullOrEmpty(proxySettings.Username) && !string.IsNullOrEmpty(proxySettings.Password))
                {
                    webProxy.UseDefaultCredentials = false;
                    webProxy.Credentials = new NetworkCredential
                    {
                        UserName = proxySettings.Username,
                        Password = proxySettings.Password
                    };
                }
                else
                {
                    webProxy.UseDefaultCredentials = true;
                    webProxy.Credentials = CredentialCache.DefaultCredentials;
                }

                //configure HTTP client handler
                handler.UseDefaultCredentials = webProxy.UseDefaultCredentials;
                handler.Proxy = webProxy;
                handler.PreAuthenticate = proxySettings.PreAuthenticate;

                return handler;
            });
        }
    }
}
