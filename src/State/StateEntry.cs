using System;
using System.Collections.Generic;
using System.Text;

namespace PipServices3.Components.State
{
    public class StateEntry
    {
        private string _key;
        private dynamic _value;
        private long _lastUpdateTime;

        /// <summary>
        /// Creates a new instance of the state entry and assigns its values.
        /// </summary>
        /// <param name="key">a unique key to locate the value.</param>
        /// <param name="value">a value to be stored.</param>
        public StateEntry(string key, dynamic value)
        {
            _key = key;
            _value = value;
            _lastUpdateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Gets the sstate value.
        /// </summary>
        /// <returns>the value object.</returns>
        public string GetKey()
        {
            return _key;
        }

        /// <summary>
        /// Gets the last update time.
        /// </summary>
        /// <returns>the timestamp when the value ware stored.</returns>
        public dynamic GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Gets the last update time.
        /// </summary>
        /// <returns>the timestamp when the value ware stored.</returns>
        public long GetLastUpdateTime()
        {
            return _lastUpdateTime;
        }

        /// <summary>
        /// Sets a new state value.
        /// </summary>
        /// <param name="value">a new cached value.</param>
        public void SetValue(dynamic value)
        {
            this._value = value;
            this._lastUpdateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}
