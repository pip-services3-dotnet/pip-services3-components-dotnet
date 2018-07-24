using System;
using System.IO;

using PipServices.Commons.Errors;

using YamlDotNet.Serialization;

namespace PipServices.Commons.Config
{
    /// <summary>
    /// Yaml Config Reader
    /// </summary>
    /// <seealso cref="PipServices.Commons.Config.FileConfigReader" />
    public class YamlConfigReader: FileConfigReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YamlConfigReader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public YamlConfigReader(string path = null)
            : base(path)
        { }

        private object ReadObject(string correlationId, ConfigParams parameters)
        {
            if (Path == null)
                throw new ConfigException(correlationId, "NO_PATH", "Missing config file path");

            try
            {
                using (var reader = new StreamReader(File.OpenRead(Path)))
                {
                    var yaml = reader.ReadToEnd();
                    yaml = Parameterize(yaml, parameters);

                    var deserializer = new Deserializer();
                    return deserializer.Deserialize<dynamic>(yaml);
                }
            }
            catch (Exception ex)
            {
                throw new FileException(
                    correlationId,
                    "READ_FAILED",
                    "Failed reading configuration " + Path + ": " + ex
                )
                .WithDetails("path", Path)
                .WithCause(ex);
            }
        }

        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="parameters">The parameters.</param>
        public override ConfigParams ReadConfig(string correlationId, ConfigParams parameters)
        {
            var value = ReadObject(correlationId, parameters);
            return ConfigParams.FromValue(value);
        }

        /// <summary>
        /// Reads the object.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="path">The path.</param>
        /// <param name="parameters">The parameters.</param>
        public static object ReadObject(string correlationId, string path, ConfigParams parameters)
        {
            return new YamlConfigReader(path).ReadObject(correlationId, parameters);
        }

        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="path">The path.</param>
        /// <param name="parameters">The parameters.</param>
        public static ConfigParams ReadConfig(string correlationId, string path, ConfigParams parameters)
        {
            return new YamlConfigReader(path).ReadConfig(correlationId, parameters);
        }
    }
}
