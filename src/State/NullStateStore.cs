using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipServices3.Components.State
{
    /// <summary>
    /// Dummy state store implementation that doesn't do anything.
    /// 
    /// It can be used in testing or in situations when state management is not required
    /// but shall be disabled.
    /// 
    /// <see cref="ICache"/>
    /// </summary>
    public class NullStateStore : IStateStore
    {
        /// <summary>
        /// Loads state from the store using its key.
        /// If value is missing in the store it returns null.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <returns>the state value or null if value wasn't found.</returns>
        public Task<T> LoadAsync<T>(string correlationId, string key)
        {
            return null;
        }

        /// <summary>
        /// Loads an array of states from the store using their keys.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="keys">unique state keys.</param>
        /// <returns>an array with state values and their corresponding keys.</returns>
        public Task<List<StateValue<T>>> LoadBulkAsync<T>(string correlationId, List<string> keys)
        {
            return Task.FromResult(new List<StateValue<T>>());
        }

        /// <summary>
        /// Saves state into the store.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <param name="value">a state value.</param>
        /// <returns>The state that was stored in the store.</returns>
        public Task<T> SaveAsync<T>(string correlationId, string key, T value)
        {
            return Task.FromResult(value);
        }

        /// <summary>
        /// Deletes a state from the store by its key.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique value key.</param>
        /// <returns>removed item</returns>
        public Task<T> DeleteAsync<T>(string correlationId, string key)
        {
            return null;
        }


        
    }
}
