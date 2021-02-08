using FluentMigrator.Builders.Create.Table;

namespace Rs.DataBase
{
    public interface IEntityBuilder
    {
        void MapEntity(CreateTableExpressionBuilder table);
    }
}