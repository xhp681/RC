using Rs.Common;
using Rs.DataBase.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public partial class DataProviderManager : IDataProviderManager
    {
        /// <summary>
        /// Gets data provider by specific type
        /// </summary>
        /// <param name="dataProviderType">Data provider type</param>
        /// <returns></returns>
        public static IRsDataProvider GetDataProvider(DataProviderType dataProviderType)
        {
            return dataProviderType switch
            {
                DataProviderType.SqlServer => new MsSqlRsDataProvider(),
                //DataProviderType.MySql => new MySqlRsDataProvider(),
                DataProviderType.PostgreSQL => new PostgreSqlDataProvider(),
                _ => throw new RsException($"Not supported data provider name: '{dataProviderType}'"),
            };
        }

        /// <summary>
        /// Gets data provider
        /// </summary>
        public IRsDataProvider DataProvider
        {
            get
            {
                var dataProviderType = Singleton<DataSettings>.Instance.DataProvider;

                return GetDataProvider(dataProviderType);
            }
        }
    }
}
