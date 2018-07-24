using PipServices.Components.Build;
using PipServices.Commons.Refer;

namespace PipServices.Components.Log
{
    public class DefaultLoggerFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "logger", "default", "1.0");
        public static readonly Descriptor NullLoggerDescriptor = new Descriptor("pip-services", "logger", "null", "*", "1.0");
        public static readonly Descriptor NullLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "null", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor = new Descriptor("pip-services", "logger", "console", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "console", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor = new Descriptor("pip-services", "logger", "composite", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "composite", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor = new Descriptor("pip-services", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor = new Descriptor("pip-services", "logger", "event", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "event", "*", "1.0");

        public DefaultLoggerFactory()
        {
            RegisterAsType(NullLoggerDescriptor, typeof(NullLogger));
            RegisterAsType(NullLoggerDescriptor2, typeof(NullLogger));
            RegisterAsType(ConsoleLoggerDescriptor, typeof(ConsoleLogger));
            RegisterAsType(ConsoleLoggerDescriptor2, typeof(ConsoleLogger));
            RegisterAsType(CompositeLoggerDescriptor, typeof(CompositeLogger));
            RegisterAsType(CompositeLoggerDescriptor2, typeof(CompositeLogger));
	    }

    }
}