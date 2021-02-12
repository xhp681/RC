using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    public interface IStoreContext
    {
        /// <summary>
        /// Gets the current store
        /// </summary>
        Task<Store> GetCurrentStoreAsync();

        /// <summary>
        /// Gets active store scope configuration
        /// </summary>
        Task<int> GetActiveStoreScopeConfigurationAsync();
    }
}
