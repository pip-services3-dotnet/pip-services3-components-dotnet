using System;
using System.IO;

using PipServices.Commons.Errors;
using PipServices.Commons.Config;
using PipServices.Commons.Convert;

namespace PipServices.Components.Config
{
    /// <summary>
    /// Json Config Reader
    /// </summary>
    /// <seealso cref="PipServices.Commons.Config.FileConfigReader" />
    public class JsonConfigReader : FileConfigReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonConfigReader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public JsonConfigReader(string path = null)
            : base(path)
        { }

        private object ReadObject(string correlationId, ConfigParams parameters)
        {
            if (Path == null)
            {
                throw new ConfigException(correlationId, "NO_PATH", "Missing config file path");
            }

            try
            {
                using (var reader = new StreamReader(File.OpenRead(Path)))
                {
                    var json = reader.ReadToEnd();
                    json = Parameterize(json, parameters);
                    return JsonConverter.ToNullableMap(json);
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
            return new JsonConfigReader(path).ReadObject(correlationId, parameters);
        }

        /// <summary>
        /// Reads the configuration.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="path">The path.</param>
        /// <param name="parameters">The parameters.</param>
        public static ConfigParams ReadConfig(string correlationId, string path, ConfigParams parameters)
        {
            return new JsonConfigReader(path).ReadConfig(correlationId, parameters);
        }
    }
}
