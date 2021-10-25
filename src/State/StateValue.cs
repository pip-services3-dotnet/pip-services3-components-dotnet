

namespace PipServices3.Components.State
{
    /// <summary>
    /// A data object that holds a retrieved state value with its key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StateValue<T>
    {
        /// <summary>
        /// A unique state key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// A stored state value;
        /// </summary>
        public T Value { get; set; }
    }
}
