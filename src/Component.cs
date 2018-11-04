using System;
using PipServices3.Commons.Config;
using PipServices3.Components.Count;
using PipServices3.Components.Log;
using PipServices3.Commons.Refer;

namespace PipServices3.Components
{
    /// <summary>
    /// Abstract component that supportes configurable dependencies, logging and performance counters.
    /// 
    /// ### Configuration parameters ###
    /// 
    /// dependencies:
    /// - [dependency name 1]: Dependency 1 locator (descriptor)
    /// - ...
    /// - [dependency name N]: Dependency N locator (descriptor)
    /// 
    /// ### References ###
    /// 
    /// - *:counters:*:*:1.0       (optional) <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/interface_pip_services_1_1_components_1_1_count_1_1_i_counters.html">ICounters</a> components to pass collected measurements
    /// - *:logger:*:*:1.0         (optional) <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/interface_pip_services_1_1_components_1_1_log_1_1_i_logger.html">ILogger</a> components to pass log messages 
    /// - ...                      References must match configured dependencies.
    /// </summary>
    public class Component: IConfigurable, IReferenceable
    {
        protected DependencyResolver _dependencyResolver = new DependencyResolver();
        protected CompositeLogger _logger = new CompositeLogger();
        protected CompositeCounters _counters = new CompositeCounters();

        /// <summary>
        /// Configures component by passing configuration parameters.
        /// </summary>
        /// <param name="config">configuration parameters to be set.</param>
        public void Configure(ConfigParams config)
        {
            _dependencyResolver.Configure(config);
            _logger.Configure(config);
        }

        /// <summary>
        /// Sets references to dependent components.
        /// </summary>
        /// <param name="references">references to locate the component dependencies.</param>
        public void SetReferences(IReferences references)
        {
            _dependencyResolver.SetReferences(references);
            _logger.SetReferences(references);
            _counters.SetReferences(references);
        }
    }
}
