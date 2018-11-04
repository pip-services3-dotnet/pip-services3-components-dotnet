using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Log
{
    /// <summary>
    /// Creates ILogger components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <see cref="NullLogger"/>, <see cref="ConsoleLogger"/>, <see cref="CompositeLogger"/>
    public class DefaultLoggerFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services3", "factory", "logger", "default", "1.0");
        public static readonly Descriptor NullLoggerDescriptor = new Descriptor("pip-services3", "logger", "null", "*", "1.0");
        public static readonly Descriptor NullLoggerDescriptor2 = new Descriptor("pip-services3-commons", "logger", "null", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor = new Descriptor("pip-services3", "logger", "console", "*", "1.0");
        public static readonly Descriptor ConsoleLoggerDescriptor2 = new Descriptor("pip-services3-commons", "logger", "console", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor = new Descriptor("pip-services3", "logger", "composite", "*", "1.0");
        public static readonly Descriptor CompositeLoggerDescriptor2 = new Descriptor("pip-services3-commons", "logger", "composite", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor = new Descriptor("pip-services3", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor DiagnosticsLoggerDescriptor2 = new Descriptor("pip-services3-commons", "logger", "diagnostics", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor = new Descriptor("pip-services3", "logger", "event", "*", "1.0");
        public static readonly Descriptor EventLoggerDescriptor2 = new Descriptor("pip-services3-commons", "logger", "event", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
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