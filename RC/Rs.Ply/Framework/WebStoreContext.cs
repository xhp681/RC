﻿using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Rs.Config;
using Rs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework
{
    public class WebStoreContext: IStoreContext
    {
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStoreService _storeService;

        private Store _cachedStore;
        private int? _cachedActiveStoreScopeConfiguration;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="genericAttributeService">Generic attribute service</param>
        /// <param name="httpContextAccessor">HTTP context accessor</param>
        /// <param name="storeService">Store service</param>
        public WebStoreContext(IGenericAttributeService genericAttributeService,
            IHttpContextAccessor httpContextAccessor,
            IStoreService storeService)
        {
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _storeService = storeService;
        }

        /// <summary>
        /// Gets the current store
        /// </summary>
        public virtual async Task<Store> GetCurrentStoreAsync()
        {
            if (_cachedStore != null)
                return _cachedStore;

            //try to determine the current store by HOST header
            string host = _httpContextAccessor.HttpContext?.Request?.Headers[HeaderNames.Host];

            var allStores = await _storeService.GetAllStoresAsync();
            var store = allStores.FirstOrDefault(s => _storeService.ContainsHostValue(s, host));

            if (store == null)
                //load the first found store
                store = allStores.FirstOrDefault();

            _cachedStore = store ?? throw new Exception("No store could be loaded");

            return _cachedStore;
        }

        /// <summary>
        /// Gets active store scope configuration
        /// </summary>
        public virtual async Task<int> GetActiveStoreScopeConfigurationAsync()
        {
            if (_cachedActiveStoreScopeConfiguration.HasValue)
                return _cachedActiveStoreScopeConfiguration.Value;

            //ensure that we have 2 (or more) stores
            if ((await _storeService.GetAllStoresAsync()).Count > 1)
            {
                //do not inject IWorkContext via constructor because it'll cause circular references
                var currentCustomer = await EngineContext.Current.Resolve<IWorkContext>().GetCurrentCustomerAsync();

                //try to get store identifier from attributes
                var storeId = await _genericAttributeService
                    .GetAttributeAsync<int>(currentCustomer, RsCustomerDefaults.AdminAreaStoreScopeConfigurationAttribute);

                _cachedActiveStoreScopeConfiguration = (await _storeService.GetStoreByIdAsync(storeId))?.Id ?? 0;
            }
            else
                _cachedActiveStoreScopeConfiguration = 0;

            return _cachedActiveStoreScopeConfiguration ?? 0;
        }
    }
}
