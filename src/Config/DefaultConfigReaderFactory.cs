using PipServices.Components.Build;
using PipServices.Commons.Config;
using PipServices.Commons.Refer;

namespace PipServices.Components.Config
{
    /// <summary>
    /// Creates IConfigReader components by their descriptors.
    /// </summary>
    /// See <see cref="Factory"/>, <see cref="MemoryConfigReader"/>, <see cref="JsonConfigReader"/>, <see cref="YamlConfigReader"/>
    public class DefaultConfigReaderFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "config-reader", "default", "1.0");
        public static readonly Descriptor MemoryConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "memory", "*", "1.0");
        public static readonly Descriptor JsonConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "json", "*", "1.0");
        public static readonly Descriptor YamlConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "yaml", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultConfigReaderFactory()
        {
            RegisterAsType(MemoryConfigReaderDescriptor, typeof(MemoryConfigReader));
            RegisterAsType(JsonConfigReaderDescriptor, typeof(JsonConfigReader));
            RegisterAsType(YamlConfigReaderDescriptor, typeof(YamlConfigReader));
	    }
    }
}
