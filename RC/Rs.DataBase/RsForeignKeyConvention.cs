using FluentMigrator.Expressions;
using FluentMigrator.Model;
using FluentMigrator.Runner.Conventions;

namespace Rs.DataBase
{
    internal class RsForeignKeyConvention : IForeignKeyConvention
    {
        private IRsDataProvider _dataProvider;

        public RsForeignKeyConvention(IRsDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Gets the default name of a foreign key
        /// </summary>
        /// <param name="foreignKey">The foreign key definition</param>
        /// <returns>Name of a foreign key</returns>
        private string GetForeignKeyName(ForeignKeyDefinition foreignKey)
        {
            var foreignColumns = string.Join('_', foreignKey.ForeignColumns);
            var primaryColumns = string.Join('_', foreignKey.PrimaryColumns);

            var keyName = _dataProvider.CreateForeignKeyName(foreignKey.ForeignTable, foreignColumns, foreignKey.PrimaryTable, primaryColumns);

            return keyName;
        }

        /// <summary>
        /// Applies a convention to a FluentMigrator.Expressions.IForeignKeyExpression
        /// </summary>
        /// <param name="expression">The expression this convention should be applied to</param>
        /// <returns>The same or a new expression. The underlying type must stay the same</returns>
        public IForeignKeyExpression Apply(IForeignKeyExpression expression)
        {
            if (string.IsNullOrEmpty(expression.ForeignKey.Name))
                expression.ForeignKey.Name = GetForeignKeyName(expression.ForeignKey);

            return expression;
        }
    }
}