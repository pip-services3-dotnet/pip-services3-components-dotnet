using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Cache
{
    /// <summary>
    /// Creates ICache components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <see cref="ICache"/>, <see cref="MemoryCache"/>, <see cref="NullCache"/>
    public class DefaultCacheFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services", "factory", "cache", "default", "1.0");
        public static Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "cache", "default", "1.0");
        public static Descriptor NullCacheDescriptor = new Descriptor("pip-services", "cache", "null", "*", "1.0");
        public static Descriptor NullCache3Descriptor = new Descriptor("pip-services3", "cache", "null", "*", "1.0");
        public static Descriptor NullCacheDescriptor2 = new Descriptor("pip-services-commons", "cache", "null", "*", "1.0");
        public static Descriptor NullCache3Descriptor2 = new Descriptor("pip-services3-commons", "cache", "null", "*", "1.0");
        public static Descriptor MemoryCacheDescriptor = new Descriptor("pip-services", "cache", "memory", "*", "1.0");
        public static Descriptor MemoryCache3Descriptor = new Descriptor("pip-services3", "cache", "memory", "*", "1.0");
        public static Descriptor MemoryCacheDescriptor2 = new Descriptor("pip-services-commons", "cache", "memory", "*", "1.0");
        public static Descriptor MemoryCache3Descriptor2 = new Descriptor("pip-services3-commons", "cache", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultCacheFactory()
        {
            RegisterAsType(MemoryCacheDescriptor, typeof(MemoryCache));
            RegisterAsType(MemoryCache3Descriptor, typeof(MemoryCache));
            RegisterAsType(MemoryCacheDescriptor2, typeof(MemoryCache));
            RegisterAsType(MemoryCache3Descriptor2, typeof(MemoryCache));
            RegisterAsType(NullCacheDescriptor, typeof(NullCache));
            RegisterAsType(NullCache3Descriptor, typeof(NullCache));
            RegisterAsType(NullCacheDescriptor2, typeof(NullCache));
            RegisterAsType(NullCache3Descriptor2, typeof(NullCache));
	    }
    }
}
