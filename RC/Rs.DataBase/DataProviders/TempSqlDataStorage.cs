using LinqToDB;
using LinqToDB.Data;
using System.Linq;

namespace Rs.DataBase.DataProviders
{
    public class TempSqlDataStorage<T> : TempTable<T>, ITempDataStorage<T> where T : class
    {

        public TempSqlDataStorage(string storageName, IQueryable<T> query, DataConnection dataConnection)
            : base(dataConnection, storageName, query)
        {
        }
    }
}