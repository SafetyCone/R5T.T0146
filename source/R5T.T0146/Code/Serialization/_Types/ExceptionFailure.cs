using System;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146.Serialization
{
    [DataTypeMarker]
    public sealed class ExceptionFailure : Failure
    {
        [JsonProperty(Order = 150)]
        public Exception Exception { get; set; }
    }
}
