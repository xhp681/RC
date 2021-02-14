using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.PostgreSQL;
using System.Data;

namespace Rs.DataBase.DataProviders
{
    public class LinqToDBPostgreSQLDataProvider : PostgreSQLDataProvider
    {
        public LinqToDBPostgreSQLDataProvider() : base(PostgreSQLVersion.v95) { }

        public override void SetParameter(DataConnection dataConnection, IDbDataParameter parameter, string name, DbDataType dataType, object value)
        {
            if (value is string && dataType.DataType == DataType.NVarChar)
            {
                dataType = dataType.WithDbType("citext");
            }

            base.SetParameter(dataConnection, parameter, name, dataType, value);
        }
    }
}