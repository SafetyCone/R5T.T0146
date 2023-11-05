using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <summary>
    /// A reason is a cause of a result being either a success or failure.
    /// A reason contains a message and a read-only dictionary of metadata.
    /// </summary>
    [DataTypeMarker]
    public interface IReason
    {
        string Message { get; }
        IReadOnlyDictionary<string, object> Metadata { get; }
    }
}
