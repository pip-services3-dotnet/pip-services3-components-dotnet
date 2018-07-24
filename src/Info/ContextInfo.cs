using System;
using Newtonsoft.Json;
using PipServices.Commons.Config;
using PipServices.Commons.Data;

namespace PipServices.Components.Info
{
    public sealed class ContextInfo : IReconfigurable
    {
        private string _name = "unknown";
        private StringValueMap _properties = new StringValueMap();

        public ContextInfo()
            : this(null, null)
        { }

        public ContextInfo(string name = null, string description = null)
        {
            _name = name ?? "unknown";
            Description = description;
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value ?? "unknown"; }
        }

        [JsonProperty("description")]
        public string Description { get; set; } = null;

        [JsonProperty("context_id")]
        public string ContextId { get; set; } = Environment.MachineName; // IdGenerator.NextLong();

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; } = DateTime.UtcNow;

        [JsonProperty("uptime")]
        public long Uptime
        {
            get
            {
                return DateTime.UtcNow.Ticks - StartTime.Ticks;
            }
        }

        [JsonProperty("properties")]
        public StringValueMap Properties
        {
            get { return _properties; }
            set { _properties = value ?? new StringValueMap(); }
        }

        public void Configure(ConfigParams config)
        {
            Name = config.GetAsStringWithDefault("name", Name);
            Name = config.GetAsStringWithDefault("info.name", Name);

            Description = config.GetAsStringWithDefault("description", Description);
            Description = config.GetAsStringWithDefault("info.description", Description);

            Properties = config.GetSection("properties");
        }

        public static ContextInfo FromConfig(ConfigParams config)
        {
            var result = new ContextInfo();
            result.Configure(config);
            return result;
        }
    }
}
