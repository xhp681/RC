using Rs.Common;
using Rs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server
{
    public partial class StoreHttpClient
    {
        private readonly HttpClient _httpClient;
        public StoreHttpClient(HttpClient client,
            IWebHelper webHelper)
        {
            //configure client
            client.BaseAddress = new Uri(webHelper.GetStoreLocation());

            _httpClient = client;
        }

        /// <summary>
        /// Keep the current store site alive
        /// </summary>
        /// <returns>The asynchronous task whose result determines that request completed</returns>
        public virtual async Task KeepAliveAsync()
        {
            await _httpClient.GetStringAsync(RsCommonDefaults.KeepAlivePath);
        }
    }
}
