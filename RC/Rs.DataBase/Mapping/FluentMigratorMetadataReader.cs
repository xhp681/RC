using FluentMigrator.Expressions;
using LinqToDB.Mapping;
using LinqToDB.Metadata;
using LinqToDB.SqlQuery;
using Rs.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase.Mapping
{
    public partial class FluentMigratorMetadataReader : IMetadataReader
    {
        private readonly IMigrationManager _migrationManager;
        public FluentMigratorMetadataReader()
        {
            _migrationManager = EngineContext.Current.Resolve<IMigrationManager>();
        }

        protected T GetAttribute<T>(Type type, MemberInfo memberInfo) where T : Attribute
        {
            var attribute = Types.GetOrAdd((type, memberInfo), t =>
            {
                var tableExpr = Expressions.GetOrAdd(type, entityType => _migrationManager.GetCreateTableExpression(entityType));

                if (typeof(T) == typeof(TableAttribute))
                    return new TableAttribute(tableExpr.TableName) { Schema = tableExpr.SchemaName };

                if (typeof(T) != typeof(ColumnAttribute))
                    return null;

                var column = tableExpr.Columns.SingleOrDefault(cd => cd.Name.Equals(NameCompatibilityManager.GetColumnName(type, memberInfo.Name), StringComparison.OrdinalIgnoreCase));

                if (column is null)
                    return null;

                var columnSystemType = (memberInfo as PropertyInfo)?.PropertyType ?? typeof(string);

                return new ColumnAttribute
                {
                    Name = column.Name,
                    IsPrimaryKey = column.IsPrimaryKey,
                    IsColumn = true,
                    CanBeNull = column.IsNullable ?? false,
                    Length = column.Size ?? 0,
                    Precision = column.Precision ?? 0,
                    IsIdentity = column.IsIdentity,
                    DataType = SqlDataType.GetDataType(columnSystemType).Type.DataType
                };
            });

            return (T)attribute;
        }

        protected T[] GetAttributes<T>(Type type, Type attributeType, MemberInfo memberInfo = null)
            where T : Attribute
        {
            if (type.IsSubclassOf(typeof(BaseEntity)) && typeof(T) == attributeType && GetAttribute<T>(type, memberInfo) is T attr)
            {
                return new[] { attr };
            }

            return Array.Empty<T>();
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Attributes owner type.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(TableAttribute));
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type member.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Member's owner type.</param>
        /// <param name="memberInfo">Attributes owner member.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(ColumnAttribute), memberInfo);
        }

        /// <summary>
        /// Gets the dynamic columns defined on given type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>All dynamic columns defined on given type</returns>
        public MemberInfo[] GetDynamicColumns(Type type)
        {
            return Array.Empty<MemberInfo>();
        }

        protected static ConcurrentDictionary<(Type, MemberInfo), Attribute> Types { get; } = new ConcurrentDictionary<(Type, MemberInfo), Attribute>();
        protected static ConcurrentDictionary<Type, CreateTableExpression> Expressions { get; } = new ConcurrentDictionary<Type, CreateTableExpression>();
    }
}
