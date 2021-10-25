using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
using System;
using System.Collections.Generic;
using System.Text;

namespace PipServices3.Components.State
{
    /// <summary>
    /// Creates <see cref="IStateStore"/> components by their descriptors.
    /// 
    /// See <see cref="Factory"/>, <see cref="IStateStore"/>, <see cref="MemoryStateStore"/>, <see cref="NullStateStore"/>
    /// </summary>
    public class DefaultStateStoreFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "state-store", "default", "1.0");
        public static readonly Descriptor NullStateStoreDescriptor = new Descriptor("pip-services", "state-store", "null", "*", "1.0");
        public static readonly Descriptor MemoryStateStoreDescriptor = new Descriptor("pip-services", "state-store", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultStateStoreFactory(): base()
        {
            this.RegisterAsType(DefaultStateStoreFactory.MemoryStateStoreDescriptor, typeof(MemoryStateStore));
            this.RegisterAsType(DefaultStateStoreFactory.NullStateStoreDescriptor, typeof(NullStateStore));
        }
    }
}
