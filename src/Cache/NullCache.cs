using System.Threading.Tasks;

namespace PipServices.Components.Cache
{
    /// <summary>
    /// Null cache component that doesn't cache at all.
    /// It is primarily used in testing and can be temporarily
    /// used to disable cache for troubleshooting purposes.
    /// </summary>
    public class NullCache : AbstractCache
    {
        /// <summary>
        /// Retrieves a value from cache by unique key.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying a data object.</param>
        /// <returns>Cached value or null if the value is not found.</returns>
        public async override Task<T> RetrieveAsync<T>(string correlationId, string key)
        {
            return await Task.FromResult(default(T));
        }

        /// <summary>
        /// Stores an object identified by a unique key in cache.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying a data object.</param>
        /// <param name="value">The data object to store.</param>
        /// <param name="timeout">Time to live for the object in milliseconds.</param>
        /// <returns>Cached object stored in the cache.</returns>
        public async override Task<T> StoreAsync<T>(string correlationId, string key, T value, long timeout)
        {
            return await Task.FromResult(value);
        }

        /// <summary>
        /// Removes an object from cache.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying the object.</param>
        public async override Task RemoveAsync(string correlationId, string key)
        {
            await Task.Delay(0);
        }
    }
}