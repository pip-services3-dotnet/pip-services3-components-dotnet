using System;
using PipServices.Components.Build;
using PipServices.Commons.Refer;

namespace PipServices.Components.Info
{
    /// <summary>
    /// Creates information components by their descriptors.
    /// </summary>
    /// See <see cref="Factory"/>, <see cref="ContextInfo"/>
    public class DefaultInfoFactory : Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "info", "default", "1.0");
        public static Descriptor ContextInfoDescriptor = new Descriptor("pip-services", "context-info", "default", "*", "1.0");
        public static Descriptor ContainerInfoDescriptor = new Descriptor("pip-services", "container-info", "default", "*", "1.0");
        public static Descriptor ContainerInfoDescriptor2 = new Descriptor("pip-services-container", "container-info", "default", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultInfoFactory()
        {
            RegisterAsType(ContextInfoDescriptor, typeof(ContextInfo));
            RegisterAsType(ContainerInfoDescriptor, typeof(ContextInfo));
            RegisterAsType(ContainerInfoDescriptor2, typeof(ContextInfo));
        }
    }
}
