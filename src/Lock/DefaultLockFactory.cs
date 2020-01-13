using System;

using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Lock
{
    /// <summary>
    /// Creates ILock components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <see cref="ILock"/>, <see cref="MemoryLock"/>, <see cref="NullLock"/>
    public class DefaultLockFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "lock", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "lock", "default", "1.0");
        public static readonly Descriptor NullLockDescriptor = new Descriptor("pip-services", "lock", "null", "*", "1.0");
        public static readonly Descriptor NullLock3Descriptor = new Descriptor("pip-services3", "lock", "null", "*", "1.0");
        public static readonly Descriptor MemoryLockDescriptor = new Descriptor("pip-services", "lock", "memory", "*", "1.0");
        public static readonly Descriptor MemoryLock3Descriptor = new Descriptor("pip-services3", "lock", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultLockFactory()
        {
            RegisterAsType(NullLockDescriptor, typeof(NullLock));
            RegisterAsType(NullLock3Descriptor, typeof(NullLock));
            RegisterAsType(MemoryLockDescriptor, typeof(MemoryLock));
            RegisterAsType(MemoryLock3Descriptor, typeof(MemoryLock));
        }
    }
}
