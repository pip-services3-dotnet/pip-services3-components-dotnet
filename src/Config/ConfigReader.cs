using HandlebarsDotNet;

namespace PipServices.Commons.Config
{
    /// <summary>
    /// Config reader with parameters
    /// </summary>
    /// <seealso cref="PipServices.Commons.Config.IConfigurable" />
    public abstract class ConfigReader : IConfigurable, IConfigReader
    {
        private ConfigParams _parameters = new ConfigParams();

        /// <summary>
        /// Sets the components configuration.
        /// </summary>
        /// <param name="config">Configuration parameters.</param>
        public virtual void Configure(ConfigParams config)
        {
            var parameters = config.GetSection("parameters");
            if (parameters.Count > 0)
            {
                _parameters = parameters;
            }
        }

        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="parameters">The parameters.</param>
        public abstract ConfigParams ReadConfig(string correlationId, ConfigParams parameters);

        /// <summary>
        /// Parameterizes the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="parameters">The parameters.</param>
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
