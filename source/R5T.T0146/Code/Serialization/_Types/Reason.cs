using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146.Serialization
{
    [DataTypeMarker]
    public abstract class Reason
    {
        [JsonProperty(Order = 100)]
        public string Message { get; set; }

        [JsonProperty(Order = 200)]
        public Dictionary<string, object> Metadata { get; set; }


        // JSON.NET specific.
        public bool ShouldSerializeMetadata()
        {
            var output = this.Metadata?.Any() ?? false;
            return output;
        }
    }
}
