using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Count
{
    /// <summary>
    /// Creates ICounters components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <see cref="NullCounters"/>, <see cref="LogCounters"/>, <see cref="CompositeCounters"/>
    public class DefaultCountersFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services3", "factory", "counters", "default", "1.0");
        public static readonly Descriptor NullCountersDescriptor = new Descriptor("pip-services3", "counters", "null", "*", "1.0");
        public static readonly Descriptor NullCountersDescriptor2 = new Descriptor("pip-services3-commons", "counters", "null", "*", "1.0");
        public static readonly Descriptor LogCountersDescriptor = new Descriptor("pip-services3", "counters", "log", "*", "1.0");
        public static readonly Descriptor LogCountersDescriptor2 = new Descriptor("pip-services3-commons", "counters", "log", "*", "1.0");
        public static readonly Descriptor CompositeCountersDescriptor = new Descriptor("pip-services3", "counters", "composite", "*", "1.0");
        public static readonly Descriptor CompositeCountersDescriptor2 = new Descriptor("pip-services3-commons", "counters", "composite", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultCountersFactory()
        {
            RegisterAsType(NullCountersDescriptor, typeof(NullCounters));
            RegisterAsType(NullCountersDescriptor2, typeof(NullCounters));
            RegisterAsType(LogCountersDescriptor, typeof(LogCounters));
            RegisterAsType(LogCountersDescriptor2, typeof(LogCounters));
            RegisterAsType(CompositeCountersDescriptor, typeof(CompositeCounters));
            RegisterAsType(CompositeCountersDescriptor2, typeof(CompositeCounters));
	    }
    }
}
