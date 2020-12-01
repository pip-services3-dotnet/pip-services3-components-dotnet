using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Log
{
    /// <summary>
    /// Creates ILogger components by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-commons-dotnet/class_pip_services3_1_1_commons_1_1_config_1_1_config_params.html">Factory</a>, 
    /// <see cref="NullLogger"/>, <see cref="ConsoleLogger"/>, <see cref="CompositeLogger"/>
    public class DefaultLoggerFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "logger", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "logger", "default", "1.0");
        public static readonly Descriptor NullLoggerDescriptor = new Descriptor("pip-services", "logger", "null", "*", "1.0");
        public static readonly Descriptor NullLogger3Descriptor = new Descriptor("pip-services3", "logger", "null", "*", "1.0");
        public static readonly Descriptor NullLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "null", "*", "1.0");
        public static readonly Descriptor NullLogger3Descriptor2 = new Descriptor("pip-services3-commons", "logger", "null", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor = new Descriptor("pip-services", "logger", "console", "*", "1.0");
        public static readonly Descriptor ConsoleLogger3Descriptor = new Descriptor("pip-services3", "logger", "console", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "console", "*", "1.0");
        public static readonly Descriptor ConsoleLogger3Descriptor2 = new Descriptor("pip-services3-commons", "logger", "console", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor = new Descriptor("pip-services", "logger", "composite", "*", "1.0");
        public static readonly Descriptor CompositeLogger3Descriptor = new Descriptor("pip-services3", "logger", "composite", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "composite", "*", "1.0");
        public static readonly Descriptor CompositeLogger3Descriptor2 = new Descriptor("pip-services3-commons", "logger", "composite", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor = new Descriptor("pip-services", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor DiagnosticsLogger3Descriptor = new Descriptor("pip-services3", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor DiagnosticsLogger3Descriptor2 = new Descriptor("pip-services3-commons", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor = new Descriptor("pip-services", "logger", "event", "*", "1.0");
        public static readonly Descriptor EventLogger3Descriptor = new Descriptor("pip-services3", "logger", "event", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor2 = new Descriptor("pip-services-commons", "logger", "event", "*", "1.0");
        public static readonly Descriptor EventLogger3Descriptor2 = new Descriptor("pip-services3-commons", "logger", "event", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultLoggerFactory()
        {
            RegisterAsType(NullLoggerDescriptor, typeof(NullLogger));
            RegisterAsType(NullLogger3Descriptor, typeof(NullLogger));
            RegisterAsType(NullLoggerDescriptor2, typeof(NullLogger));
            RegisterAsType(NullLogger3Descriptor2, typeof(NullLogger));
            RegisterAsType(ConsoleLoggerDescriptor, typeof(ConsoleLogger));
            RegisterAsType(ConsoleLogger3Descriptor, typeof(ConsoleLogger));
            RegisterAsType(ConsoleLoggerDescriptor2, typeof(ConsoleLogger));
            RegisterAsType(ConsoleLogger3Descriptor2, typeof(ConsoleLogger));
            RegisterAsType(CompositeLoggerDescriptor, typeof(CompositeLogger));
            RegisterAsType(CompositeLogger3Descriptor, typeof(CompositeLogger));
            RegisterAsType(CompositeLoggerDescriptor2, typeof(CompositeLogger));
            RegisterAsType(CompositeLogger3Descriptor2, typeof(CompositeLogger));
            RegisterAsType(DiagnosticsLoggerDescriptor, typeof(DiagnosticsLogger));
            RegisterAsType(DiagnosticsLogger3Descriptor, typeof(DiagnosticsLogger));
            RegisterAsType(DiagnosticsLoggerDescriptor2, typeof(DiagnosticsLogger));
            RegisterAsType(DiagnosticsLogger3Descriptor2, typeof(DiagnosticsLogger));
            RegisterAsType(EventLoggerDescriptor, typeof(EventLogger));
            RegisterAsType(EventLogger3Descriptor, typeof(EventLogger));
            RegisterAsType(EventLoggerDescriptor2, typeof(EventLogger));
            RegisterAsType(EventLogger3Descriptor2, typeof(EventLogger));
        }

    }
}