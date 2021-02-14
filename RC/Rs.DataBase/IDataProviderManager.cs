using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public partial interface IDataProviderManager
    {
        /// <summary>
        /// Gets data provider
        /// </summary>
        IRsDataProvider DataProvider { get; }
    }
}
