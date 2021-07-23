using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
using System;
using System.Collections.Generic;
using System.Text;

namespace PipServices3.Components.Test
{
    /// <summary>
    /// Creates test components by their descriptors.
    /// </summary>
    /// <see cref="Factory"/>, <see cref="Shutdown"/>
    public class DefaultTestFactory: Factory
    {
        private static readonly Descriptor ShutdownDescriptor = new Descriptor("pip-services", "shutdown", "*", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultTestFactory(): base()
        {
            RegisterAsType(DefaultTestFactory.ShutdownDescriptor, typeof(Shutdown));
        }
    }
}
