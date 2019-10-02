using System;
using PipServices3.Commons.Config;

namespace PipServices3.Components.Config
{
    public abstract class CachedConfigReader: IConfigReader, IReconfigurable
    {
        private long _lastRead = 0;
        private ConfigParams _config;

        public CachedConfigReader()
        {
            Timeout = 60000;
        }

        public long Timeout { get; set; }

        public virtual void Configure(ConfigParams config)
        {
            Timeout = config.GetAsLongWithDefault("timeout", Timeout);
        }

        protected abstract ConfigParams PerformReadConfig(string correlationId, ConfigParams parameters);

        public ConfigParams ReadConfig(string correlationId, ConfigParams parameters)
        {
            if (_config != null && DateTime.UtcNow.Ticks < _lastRead + TimeSpan.FromMilliseconds(Timeout).Ticks)
            {
                return _config;
            }

            _config = PerformReadConfig(correlationId, parameters);
            _lastRead = DateTime.UtcNow.Ticks;

            return _config;
        }

        public ConfigParams ReadConfigSection(string correlationId, ConfigParams parameters, string section)
        {
            var config = ReadConfig(correlationId, parameters);
            return config != null ? config.GetSection(section) : null;
        }
    }
}
