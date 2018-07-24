using PipServices.Components.Build;
using PipServices.Commons.Config;
using PipServices.Commons.Refer;

namespace PipServices.Components.Config
{
    public class DefaultConfigReaderFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "config-reader", "default", "1.0");
        public static readonly Descriptor MemoryConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "memory", "*", "1.0");
        public static readonly Descriptor JsonConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "json", "*", "1.0");
        public static readonly Descriptor YamlConfigReaderDescriptor = new Descriptor("pip-services", "config-reader", "yaml", "*", "1.0");

        public DefaultConfigReaderFactory()
        {
            RegisterAsType(MemoryConfigReaderDescriptor, typeof(MemoryConfigReader));
            RegisterAsType(JsonConfigReaderDescriptor, typeof(JsonConfigReader));
            RegisterAsType(YamlConfigReaderDescriptor, typeof(YamlConfigReader));
	    }
    }
}
