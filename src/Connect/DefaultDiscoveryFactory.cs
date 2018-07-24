using PipServices.Components.Build;
using PipServices.Commons.Refer;

namespace PipServices.Components.Connect
{
    public class DefaultDiscoveryFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "discovery", "default", "1.0");
        public static readonly Descriptor MemoryDiscoveryDescriptor = new Descriptor("pip-services", "discovery", "memory", "*", "1.0");
        public static readonly Descriptor MemoryDiscoveryDescriptor2 = new Descriptor("pip-services-commons", "discovery", "memory", "*", "1.0");

        public DefaultDiscoveryFactory()
        {
            RegisterAsType(MemoryDiscoveryDescriptor, typeof(MemoryDiscovery));
            RegisterAsType(MemoryDiscoveryDescriptor2, typeof(MemoryDiscovery));
	    }	
    }
}
