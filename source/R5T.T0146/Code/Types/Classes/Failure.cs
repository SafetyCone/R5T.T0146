using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <inheritdoc cref="IFailure"/>
    [UtilityTypeMarker]
    public class Failure : Reason, IFailure
    {
        public List<IFailure> Causes { get; } = new List<IFailure>();

        IReadOnlyList<IFailure> IFailure.Causes => this.Causes;
    }
}
