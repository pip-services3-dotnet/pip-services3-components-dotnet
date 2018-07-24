using System.Threading.Tasks;

namespace PipServices.Components.Cache
{
    /// <summary>
    /// Transient cache used to bypass persistence to increase system performance.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Retrieves a value from cache by unique key.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying a data object.</param>
        /// <returns>Cached value or null if the value is not found.</returns>
        Task<T> RetrieveAsync<T>(string correlationId, string key);

        /// <summary>
        /// Stores an object identified by a unique key in cache.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying a data object.</param>
        /// <param name="value">The data object to store.</param>
        /// <param name="timeout">Time to live for the object in milliseconds.</param>
        Task<T> StoreAsync<T>(string correlationId, string key, T value, long timeout);

        /// <summary>
        /// Removes an object from cache.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="key">Unique key identifying the object.</param>
        Task RemoveAsync(string correlationId, string key);
    }
}
