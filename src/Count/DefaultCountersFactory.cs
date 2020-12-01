using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Count
{
    /// <summary>
    /// Creates ICounters components by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-commons-dotnet/class_pip_services3_1_1_commons_1_1_config_1_1_config_params.html">Factory</a>, 
    /// <see cref="NullCounters"/>, <see cref="LogCounters"/>, <see cref="CompositeCounters"/>
    public class DefaultCountersFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "counters", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "counters", "default", "1.0");
        public static readonly Descriptor NullCountersDescriptor = new Descriptor("pip-services", "counters", "null", "*", "1.0");
        public static readonly Descriptor NullCounters3Descriptor = new Descriptor("pip-services3", "counters", "null", "*", "1.0");
        public static readonly Descriptor NullCountersDescriptor2 = new Descriptor("pip-services-commons", "counters", "null", "*", "1.0");
        public static readonly Descriptor NullCounters3Descriptor2 = new Descriptor("pip-services3-commons", "counters", "null", "*", "1.0");
        public static readonly Descriptor LogCountersDescriptor = new Descriptor("pip-services", "counters", "log", "*", "1.0");
        public static readonly Descriptor LogCounters3Descriptor = new Descriptor("pip-services3", "counters", "log", "*", "1.0");
        public static readonly Descriptor LogCountersDescriptor2 = new Descriptor("pip-services-commons", "counters", "log", "*", "1.0");
        public static readonly Descriptor LogCounters3Descriptor2 = new Descriptor("pip-services3-commons", "counters", "log", "*", "1.0");
        public static readonly Descriptor CompositeCountersDescriptor = new Descriptor("pip-services", "counters", "composite", "*", "1.0");
        public static readonly Descriptor CompositeCounters3Descriptor = new Descriptor("pip-services3", "counters", "composite", "*", "1.0");
        public static readonly Descriptor CompositeCountersDescriptor2 = new Descriptor("pip-services-commons", "counters", "composite", "*", "1.0");
        public static readonly Descriptor CompositeCounters3Descriptor2 = new Descriptor("pip-services3-commons", "counters", "composite", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultCountersFactory()
        {
            RegisterAsType(NullCountersDescriptor, typeof(NullCounters));
            RegisterAsType(NullCounters3Descriptor, typeof(NullCounters));
            RegisterAsType(NullCountersDescriptor2, typeof(NullCounters));
            RegisterAsType(NullCounters3Descriptor2, typeof(NullCounters));
            RegisterAsType(LogCountersDescriptor, typeof(LogCounters));
            RegisterAsType(LogCounters3Descriptor, typeof(LogCounters));
            RegisterAsType(LogCountersDescriptor2, typeof(LogCounters));
            RegisterAsType(LogCounters3Descriptor2, typeof(LogCounters));
            RegisterAsType(CompositeCountersDescriptor, typeof(CompositeCounters));
            RegisterAsType(CompositeCounters3Descriptor, typeof(CompositeCounters));
            RegisterAsType(CompositeCountersDescriptor2, typeof(CompositeCounters));
            RegisterAsType(CompositeCounters3Descriptor2, typeof(CompositeCounters));
	    }
    }
}
