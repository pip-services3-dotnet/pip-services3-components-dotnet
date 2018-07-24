
namespace PipServices.Commons.Config
{
    /// <summary>
    /// Memory Config Reader
    /// </summary>
    /// <seealso cref="PipServices.Commons.Config.IConfigReader" />
    /// <seealso cref="PipServices.Commons.Config.IReconfigurable" />
    public class MemoryConfigReader : IConfigReader, IReconfigurable
    {
        protected ConfigParams _config = new ConfigParams();

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryConfigReader"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public MemoryConfigReader(ConfigParams config = null)
        {
            _config = config ?? new ConfigParams();
        }

        /// <summary>
        /// Configures the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public virtual void Configure(ConfigParams config)
        {
            _config = config;
        }

        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual ConfigParams ReadConfig(string correlationId, ConfigParams parameters)
        {
            return new ConfigParams(_config);
        }
    }
}
