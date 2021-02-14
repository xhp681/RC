﻿using LinqToDB.Data;
using Rs.Common;
using Rs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>Entity entry</returns>
        Task<TEntity> GetByIdAsync(int? id, Func<IStaticCacheManager, CacheKey> getCacheKey = null);

        /// <summary>
        /// Get entity entries by identifiers
        /// </summary>
        /// <param name="ids">Entity entry identifiers</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>Entity entries</returns>
        Task<IList<TEntity>> GetByIdsAsync(IList<int> ids, Func<IStaticCacheManager, CacheKey> getCacheKey = null);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>Entity entries</returns>
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            Func<IStaticCacheManager, CacheKey> getCacheKey = null);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>Entity entries</returns>
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
            Func<IStaticCacheManager, CacheKey> getCacheKey = null);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>Entity entries</returns>
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func,
            Func<IStaticCacheManager, Task<CacheKey>> getCacheKey);

        /// <param name="func">Function to select entries</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
        /// <returns>Paged list of entity entries</returns>
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);

        /// <param name="func">Function to select entries</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
        /// <returns>Paged list of entity entries</returns>
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task InsertAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task InsertAsync(IList<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task UpdateAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task UpdateAsync(IList<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task DeleteAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Delete entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        Task DeleteAsync(IList<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>Number of deleted records</returns>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Loads the original copy of the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <returns>Copy of the passed entity entry</returns>
        Task<TEntity> LoadOriginalCopyAsync(TEntity entity);

        /// <summary>
        /// Executes SQL using System.Data.CommandType.StoredProcedure command type and returns results as collection of values of specified type
        /// </summary>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="parameters">Command parameters</param>
        /// <returns>Entity entries</returns>
        Task<IList<TEntity>> EntityFromSqlAsync(string procedureName, params DataParameter[] parameters);

        /// <summary>
        /// Truncates database table
        /// </summary>
        /// <param name="resetIdentity">Performs reset identity column</param>
        Task TruncateAsync(bool resetIdentity = false);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }
    }
}
