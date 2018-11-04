using PipServices3.Commons.Config;

namespace PipServices3.Components.Config
{
    /// <summary>
    /// Interface for configuration readers that retrieve configuration from various sources
    /// and make it available for other components.
    /// 
    /// Some IConfigReader implementations may support configuration parameterization.
    /// The parameterization allows to use configuration as a template and inject there dynamic values.
    /// The values may come from application command like arguments or environment variables.
    /// </summary>
    public interface IConfigReader
    {
        /// <summary>
        /// Reads configuration and parameterize it with given values.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="parameters">values to parameters the configuration or null to skip parameterization.</param>
        /// <returns>ConfigParams configuration.</returns>
        ConfigParams ReadConfig(string correlationId, ConfigParams parameters);
    }
}
