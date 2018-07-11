using Microsoft.Extensions.Caching.Distributed;
using MvcOpinionatedTemplate.Core.Extensions;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MvcOpinionatedTemplate.Services.Infrastructure
{
    public class CacheClass : ICacheClass
    {
        private readonly IDistributedCache _cache;

        public CacheClass(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Set item in Cache base on Key and expiration.
        /// </summary>
        /// <typeparam name="T">Type of object that will be set to cache</typeparam>
        /// <param name="key">Unique value of cached item</param>
        /// <param name="item">Item to be cached, must support serialization</param>
        /// <returns>Task</returns>
        public async Task SetAsync<T>(string key, T item) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (item != null && !item.IsSerializable())
                throw new InvalidOperationException("Only objects that can be serialized can be saved to cache.");

            var serializedObject = item == null ? null : JsonConvert.SerializeObject(item, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });

            await _cache.SetStringAsync(key, serializedObject);
        }

        /// <summary>
        /// Retrieve item from cache associated with Key.
        /// </summary>
        /// <typeparam name="T">Type of object expected to be returned from cache</typeparam>
        /// <param name="key">Unique value of cached item</param>
        /// <returns>Task of Type</returns>
        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var serializedObject = await _cache.GetStringAsync(key);

            if (serializedObject == null) return await Task.FromResult<T>(null);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }
    }
}
