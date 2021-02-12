﻿namespace Rs.Config
{
    public static class RsEntityCacheDefaults<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets an entity type name used in cache keys
        /// </summary>
        public static string EntityTypeName => typeof(TEntity).Name.ToLowerInvariant();

        /// <summary>
        /// Gets a key for caching entity by identifier
        /// </summary>
        /// <remarks>
        /// {0} : entity id
        /// </remarks>
        public static CacheKey ByIdCacheKey => new CacheKey($"Rs.{EntityTypeName}.byid.{{0}}", ByIdPrefix, Prefix);

        /// <summary>
        /// Gets a key for caching entities by identifiers
        /// </summary>
        /// <remarks>
        /// {0} : entity ids
        /// </remarks>
        public static CacheKey ByIdsCacheKey => new CacheKey($"Rs.{EntityTypeName}.byids.{{0}}", ByIdsPrefix, Prefix);

        /// <summary>
        /// Gets a key for caching all entities
        /// </summary>
        public static CacheKey AllCacheKey => new CacheKey($"Rs.{EntityTypeName}.all.", AllPrefix, Prefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string Prefix => $"Rs.{EntityTypeName}.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ByIdPrefix => $"Rs.{EntityTypeName}.byid.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ByIdsPrefix => $"Rs.{EntityTypeName}.byids.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string AllPrefix => $"Rs.{EntityTypeName}.all.";
    }
}