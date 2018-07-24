using PipServices.Commons.Config;

namespace PipServices.Components.Config
{
    /// <summary>
    /// The interface of Config Reader
    /// </summary>
    public interface IConfigReader
    {
        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="parameters">The parameters.</param>
        ConfigParams ReadConfig(string correlationId, ConfigParams parameters);
    }
}
