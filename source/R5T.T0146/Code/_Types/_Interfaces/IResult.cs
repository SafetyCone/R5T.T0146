using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <summary>
    /// A result is a collection of failure reasons, success reasons, and child results, any of which might be empty.
    /// Results form a hierarchy since a result can contain child results.
    /// </summary>
    [DataTypeMarker]
    public interface IResult
    {
        string Title { get; }
        public IReadOnlyDictionary<string, object> Metadata { get; }

        IEnumerable<IFailure> Failures { get; }
        IEnumerable<ISuccess> Successes { get; }

        IEnumerable<IResult> Children { get; }
    }


    /// <summary>
    /// A result returning a value.
    /// <inheritdoc cref="IResult" path="/summary"/>
    /// </summary>
    public interface IResult<out TValue> : IResult
    {
        /// <summary>
        /// Allows determining whether a result actually has a value, or whether the value is just the default value for the value type.
        /// </summary>
        bool HasValue { get; }
        TValue Value { get; }
    }
}
