using PipServices3.Components.Build;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Config
{
    /// <summary>
    /// Creates IConfigReader components by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_cache_1_1_default_cache_factory.html">Factory</a>, 
    /// <see cref="MemoryConfigReader"/>, <see cref="JsonConfigReader"/>, <see cref="YamlConfigReader"/>
    public class DefaultConfigReaderFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-servicess", "factory", "config-reader", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "config-reader", "default", "1.0");
        public static readonly Descriptor MemoryConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "memory", "*", "1.0");
        public static readonly Descriptor MemoryConfigReader3Descriptor = new Descriptor("pip-services3", "config-reader", "memory", "*", "1.0");
        public static readonly Descriptor JsonConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "json", "*", "1.0");
        public static readonly Descriptor JsonConfigReader3Descriptor = new Descriptor("pip-services3", "config-reader", "json", "*", "1.0");
        public static readonly Descriptor YamlConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "yaml", "*", "1.0");
        public static readonly Descriptor YamlConfigReader3Descriptor = new Descriptor("pip-services3", "config-reader", "yaml", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultConfigReaderFactory()
        {
            RegisterAsType(MemoryConfigReaderDescriptor, typeof(MemoryConfigReader));
            RegisterAsType(MemoryConfigReader3Descriptor, typeof(MemoryConfigReader));
            RegisterAsType(JsonConfigReaderDescriptor, typeof(JsonConfigReader));
            RegisterAsType(JsonConfigReader3Descriptor, typeof(JsonConfigReader));
            RegisterAsType(YamlConfigReaderDescriptor, typeof(YamlConfigReader));
            RegisterAsType(YamlConfigReader3Descriptor, typeof(YamlConfigReader));
	    }
    }
}
