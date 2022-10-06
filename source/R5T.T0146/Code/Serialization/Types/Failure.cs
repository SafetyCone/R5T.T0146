﻿using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;


namespace R5T.T0146.Serialization
{
    // Do not register as a utility type.
    public class Failure : Reason
    {
        [JsonProperty(Order = 300)]
        public Failure[] Causes { get; set; }


        // JSON.NET specific.
        public bool ShouldSerializeCauses()
        {
            var output = this.Causes?.Any() ?? false;
            return output;
        }
    }
}
