using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146.Serialization
{
    [DataTypeMarker]
    public sealed class Result
    {
        [JsonProperty(PropertyName = "SUCCESS", Order = 10)]
        public bool Success { get; set; }

        [JsonProperty(Order = 100)]
        public string Title { get; set; }

        [JsonProperty(Order = 150)]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty(Order = 200)]
        public Failure[] Failures { get; set; }

        [JsonProperty(Order = 300)]
        public Success[] Successes { get; set; }

        [JsonProperty(Order = 400)]
        public Result[] Children { get; set; }


        // JSON.NET specific.
        public bool ShouldSerializeChildren()
        {
            var output = this.Children?.Any() ?? false;
            return output;
        }

        // JSON.NET specific.
        public bool ShouldSerializeMetadata()
        {
            var output = this.Metadata?.Any() ?? false;
            return output;
        }
    }
}
