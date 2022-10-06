using System;

using R5T.T0142;


namespace R5T.T0146
{
    [UtilityTypeMarker]
    public interface IExceptionFailure : IFailure
    {
        Exception Exception { get; }
    }
}
