using System;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146.Serialization
{
    [DataTypeMarker]
    public sealed class Exception
    {
        [JsonProperty(Order = 1)]
        public string Type { get; set; }

        [JsonProperty(Order = 2)]
        public string Message { get; set; }
    }
}
