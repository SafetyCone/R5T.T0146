using System;

using Newtonsoft.Json;


namespace R5T.T0146.Serialization
{
    public sealed class ExceptionFailure : Failure
    {
        [JsonProperty(Order = 150)]
        public Exception Exception { get; set; }
    }
}
