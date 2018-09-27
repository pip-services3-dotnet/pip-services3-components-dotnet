using HandlebarsDotNet;
using PipServices.Commons.Config;

namespace PipServices.Components.Config
{
    /// <summary>
    /// Abstract config reader that supports configuration parameterization.
    /// 
    /// ### Configuration parameters ###
    /// 
    /// parameters:            this entire section is used as template parameters
    /// </summary>
    /// See <see cref="IConfigReader"/>
    public abstract class ConfigReader : IConfigurable, IConfigReader
    {
        private ConfigParams _parameters = new ConfigParams();

        /// <summary>
        /// Configures component by passing configuration parameters.
        /// </summary>
        /// <param name="config">Configuration parameters to be set.</param>
        public virtual void Configure(ConfigParams config)
        {
            var parameters = config.GetSection("parameters");
            if (parameters.Count > 0)
            {
                _parameters = parameters;
            }
        }

        /// <summary>
        /// Reads configuration and parameterize it with given values.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="parameters">values to parameters the configuration or null to skip parameterization.</param>
        /// <returns>ConfigParams configuration.</returns>
        public abstract ConfigParams ReadConfig(string correlationId, ConfigParams parameters);

        /// <summary>
        /// Parameterized configuration template given as string with dynamic parameters.
        /// The method uses Handlebars template engine.
        /// </summary>
        /// <param name="config">a string with configuration template to be parameterized</param>
        /// <param name="parameters">dynamic parameters to inject into the template</param>
        /// <returns>a parameterized configuration string.</returns>
        protected string Parameterize(string config, ConfigParams parameters)
        {
            if (parameters == null)
            {
                return config;
            }

            var template = Handlebars.Compile(config);

            return template(parameters);
        }
    }
}
