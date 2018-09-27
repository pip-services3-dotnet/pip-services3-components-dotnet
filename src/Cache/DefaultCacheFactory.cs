using PipServices.Components.Build;
using PipServices.Commons.Refer;

namespace PipServices.Components.Cache
{
    /// <summary>
    /// Creates ICache components by their descriptors.
    /// </summary>
    /// See <see cref="Factory"/>, <see cref="ICache"/>, <see cref="MemoryCache"/>, <see cref="NullCache"/>
    public class DefaultCacheFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services", "factory", "cache", "default", "1.0");
        public static Descriptor NullCacheDescriptor = new Descriptor("pip-services", "cache", "null", "*", "1.0");
        public static Descriptor NullCacheDescriptor2 = new Descriptor("pip-services-commons", "cache", "null", "*", "1.0");
        public static Descriptor MemoryCacheDescriptor = new Descriptor("pip-services", "cache", "memory", "*", "1.0");
        public static Descriptor MemoryCacheDescriptor2 = new Descriptor("pip-services-commons", "cache", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultCacheFactory()
        {
            RegisterAsType(MemoryCacheDescriptor, typeof(MemoryCache));
            RegisterAsType(MemoryCacheDescriptor2, typeof(MemoryCache));
            RegisterAsType(NullCacheDescriptor, typeof(NullCache));
            RegisterAsType(NullCacheDescriptor2, typeof(NullCache));
	    }
    }
}
