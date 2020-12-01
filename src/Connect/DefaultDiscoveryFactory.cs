using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Connect
{
    /// <summary>
    /// Creates IDiscovery components by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-commons-dotnet/class_pip_services3_1_1_commons_1_1_config_1_1_config_params.html">Factory</a>, 
    /// <see cref="IDiscovery"/>, <see cref="MemoryDiscovery"/>
    public class DefaultDiscoveryFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "discovery", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "discovery", "default", "1.0");
        public static readonly Descriptor MemoryDiscoveryDescriptor = new Descriptor("pip-services", "discovery", "memory", "*", "1.0");
        public static readonly Descriptor MemoryDiscovery3Descriptor = new Descriptor("pip-services3", "discovery", "memory", "*", "1.0");
        public static readonly Descriptor MemoryDiscoveryDescriptor2 = new Descriptor("pip-services-commons", "discovery", "memory", "*", "1.0");
        public static readonly Descriptor MemoryDiscovery3Descriptor2 = new Descriptor("pip-services3-commons", "discovery", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultDiscoveryFactory()
        {
            RegisterAsType(MemoryDiscoveryDescriptor, typeof(MemoryDiscovery));
            RegisterAsType(MemoryDiscovery3Descriptor, typeof(MemoryDiscovery));
            RegisterAsType(MemoryDiscoveryDescriptor2, typeof(MemoryDiscovery));
            RegisterAsType(MemoryDiscovery3Descriptor2, typeof(MemoryDiscovery));
	    }	
    }
}
