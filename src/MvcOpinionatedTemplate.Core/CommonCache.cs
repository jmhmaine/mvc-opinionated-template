using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace MvcOpinionatedTemplate.Core
{
    public static class CommonCache<T>
    {
        private static readonly object _cacheLock = new object();
        private static MemoryCache _memoryCache;

        static CommonCache()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public static IReadOnlyList<T> GetAll(string cacheKey)
        {
            // Return null if the key doesn't exist to prevent race condition where cache invalidates between the contains method and retreival. 
            lock (_cacheLock)
            {
                return _memoryCache.Get<IReadOnlyList<T>>(cacheKey);
            }
        }

        /// <summary>
        /// Set list to Cache if it doesn't exist or if overwrite is true. Cache has no expiration. 
        /// </summary>
        /// <param name="dataList">List to store in Cache</param>
        /// <param name="cacheKey">Name of Cache Key</param>
        /// <param name="overwrite">Overwrite cache if value exists, default is false</param>
        /// <returns>true if method executed successful</returns>
        public static bool Set(IReadOnlyList<T> dataList, string cacheKey, bool overwrite = false)
        {
            List<T> list = null;

            if (GetAll(cacheKey) != null)
                list = GetAll(cacheKey).ToList();

            if (list != null && overwrite != true) return true;

            lock (_cacheLock)
            {
                // has cache been written to since begining of process
                list = _memoryCache.Get<List<T>>(cacheKey);

                if (list != null || dataList == null) return true;

                list = dataList.ToList(); // MemoryCache doesn't support IReadOnlyList, convert to list // TODO: Test if this is still true

                _memoryCache.Set(cacheKey, list);
            }

            return true;
        }

        /// <summary>
        /// Removes item from Cache
        /// </summary>
        /// <returns></returns>
        public static bool Remove(string cachekey)
        {
            lock (_cacheLock)
            {
                _memoryCache.Remove(cachekey);
            }

            return true;
        }
    }
}
