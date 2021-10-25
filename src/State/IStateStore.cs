using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipServices3.Components.State
{
    /// <summary>
    /// Interface for state storages that are used to store and retrieve transaction states.
    /// </summary>
    public interface IStateStore
    {
        /// <summary>
        /// Loads state from the store using its key.
        /// If value is missing in the store it returns null.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <returns>the state value or null if value wasn't found.</returns>
        Task<T> LoadAsync<T>(string correlationId, string key);

        /// <summary>
        /// Loads an array of states from the store using their keys.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="keys">unique state keys.</param>
        /// <returns>an array with state values and their corresponding keys.</returns>
        Task<List<StateValue<T>>> LoadBulkAsync<T>(string correlationId, List<string> keys);

        /// <summary>
        /// Saves state into the store.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <param name="value">a state value.</param>
        /// <returns>The state that was stored in the store.</returns>
        Task<T> SaveAsync<T>(string correlationId, string key, T value);

        /// <summary>
        /// Deletes a state from the store by its key.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique value key.</param>
        /// <returns>removed item</returns>
        Task<T> DeleteAsync<T>(string correlationId, string key);

    }
}
