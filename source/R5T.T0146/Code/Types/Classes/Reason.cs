using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <inheritdoc cref="IReason"/>
    [UtilityTypeMarker]
    public abstract class Reason : IReason
    {
        public string Message { get; set; }
        public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();

        string IReason.Message => this.Message;
        IReadOnlyDictionary<string, object> IReason.Metadata => this.Metadata;
    }
}
