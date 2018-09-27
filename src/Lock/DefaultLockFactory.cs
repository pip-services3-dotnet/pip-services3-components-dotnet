using System;

using PipServices.Components.Build;
using PipServices.Commons.Refer;

namespace PipServices.Components.Lock
{
    /// <summary>
    /// Creates ILock components by their descriptors.
    /// </summary>
    /// See <see cref="Factory"/>, <see cref="ILock"/>, <see cref="MemoryLock"/>, <see cref="NullLock"/>
    public class DefaultLockFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "lock", "default", "1.0");
        public static readonly Descriptor NullLockDescriptor = new Descriptor("pip-services", "lock", "null", "*", "1.0");
        public static readonly Descriptor MemoryLockDescriptor = new Descriptor("pip-services", "lock", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultLockFactory()
        {
            RegisterAsType(NullLockDescriptor, typeof(NullLock));
            RegisterAsType(MemoryLockDescriptor, typeof(MemoryLock));
        }
    }
}
