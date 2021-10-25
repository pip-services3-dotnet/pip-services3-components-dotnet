using PipServices3.Commons.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipServices3.Components.State
{
    /// <summary>
    /// State store that keeps states in the process memory.
    /// 
    /// Remember: This implementation is not suitable for synchronization of distributed processes.
    /// 
    /// ### Configuration parameters ###
    /// __options:__
    /// - timeout: default caching timeout in milliseconds(default: disabled)
    /// 
    /// See <see cref="ICache"/>
    /// 
    /// <example>
    /// <code>
    /// var store = new MemoryStateStore();
    /// 
    /// var value = await store.LoadAsync("123", "key1");
    /// ...
    /// await store.save("123", "key1", "ABC");
    /// </code>
    /// </example>
    /// </summary>
    public class MemoryStateStore : IStateStore, IReconfigurable
    {
        private Dictionary<string, StateEntry> _states = new Dictionary<string, StateEntry>();
        private long _timeout = 0;

        /// <summary>
        /// Configures component by passing configuration parameters.
        /// </summary>
        /// <param name="config">configuration parameters to be set.</param>
        public virtual void Configure(ConfigParams config)
        {
            _timeout = config.GetAsLongWithDefault("options.timeout", _timeout);
        }

        /// <summary>
        /// Clears component state.
        /// </summary>
        private void Cleanup()
        {
            if (this._timeout == 0) return;

            long cutOffTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - _timeout;

            // Cleanup obsolete entries
            foreach (var prop in this._states.Keys)
            {
                StateEntry entry = this._states[prop];
                // Remove obsolete entry
                if (entry.GetLastUpdateTime() < cutOffTime)
                {
                    _states.Remove(prop);
                }
            }
        }

        /// <summary>
        /// Loads state from the store using its key.
        /// If value is missing in the store it returns null.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <returns>the state value or null if value wasn't found.</returns>
        public async Task<T> LoadAsync<T>(string correlationId, string key)
        {
            if (key == null)
            {
                throw new Exception("Key cannot be null");
            }

            // Cleanup the stored states
            Cleanup();

            // Get entry from the store
            StateEntry entry = _states.ContainsKey(key) ? _states[key] : null;

            // Store has nothing
            if (entry == null)
            {
                return default(T);
            }

            return entry.GetValue();
        }

        /// <summary>
        /// Loads an array of states from the store using their keys.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="keys">unique state keys.</param>
        /// <returns>an array with state values and their corresponding keys.</returns>
        public async Task<List<StateValue<T>>> LoadBulkAsync<T>(string correlationId, List<string> keys)
        {
            // Cleanup the stored states
            this.Cleanup();

            var result = new List<StateValue<T>>();

            foreach (var key in keys)
            {
                var value = await LoadAsync<T>(correlationId, key);
                result.Add(new StateValue<T>() { Key = key, Value = value });
            }

            return result;
        }

        /// <summary>
        /// Saves state into the store.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique state key.</param>
        /// <param name="value">a state value.</param>
        /// <returns>The state that was stored in the store.</returns>
        public async Task<T> SaveAsync<T>(string correlationId, string key, T value)
        {
            if (key == null)
            {
                throw new Exception("Key cannot be null");
            }

            // Cleanup the stored states
            Cleanup();

            // Get the entry
            StateEntry entry = _states.ContainsKey(key) ? _states[key] : null;

            // Shortcut to remove entry from the cache
            if (value == null)
            {
                _states.Remove(key);
                return value;
            }

            // Update the entry
            if (entry != null)
            {
                entry.SetValue(value);
            }
            // Or create a new entry 
            else
            {
                entry = new StateEntry(key, value);
                this._states[key] = entry;
            }

            return value;
        }

        /// <summary>
        /// Deletes a state from the store by its key.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a unique value key.</param>
        /// <returns>removed item</returns>
        public async Task<T> DeleteAsync<T>(string correlationId, string key)
        {
            if (key == null)
            {
                throw new Exception("Key cannot be null");
            }

            // Cleanup the stored states
            Cleanup();

            // Get the entry
            var entry = _states.ContainsKey(key) ? _states[key] : null;

            // Remove entry from the cache
            if (entry != null)
            {
                _states.Remove(key);
                return entry.GetValue();
            }

            return default(T);
        }
    }
}
