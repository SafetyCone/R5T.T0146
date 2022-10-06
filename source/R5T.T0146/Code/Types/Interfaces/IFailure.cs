using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <summary>
    /// A failure is a reason a result failed.
    /// Failures can have a set of causes, which are themselves failures. This allows a hierarchy of causes to be constructed all the way down to the root cause.
    /// </summary>
    [UtilityTypeMarker]
    public interface IFailure : IReason
    {
        IReadOnlyList<IFailure> Causes { get; }
    }
}
