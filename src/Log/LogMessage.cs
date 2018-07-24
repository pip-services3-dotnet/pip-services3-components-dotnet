using System;
using System.Runtime.Serialization;
using PipServices.Commons.Errors;

namespace PipServices.Components.Log
{
    [DataContract]
    public class LogMessage
    {
        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "level")]
        public string Level { get; set; }

        [DataMember(Name = "correlation_id")]
        public string CorrelationId { get; set; }
  
        [DataMember(Name = "error")]
        public ErrorDescription Error { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
