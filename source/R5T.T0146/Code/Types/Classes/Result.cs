using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <inheritdoc cref="IResult"/>
    [UtilityTypeMarker]
    public class Result : IResult
    {
        public string Title { get; set; }
        public Dictionary<string, object> Metadata { get; } = new();

        public List<IFailure> Failures { get; } = new();
        public List<ISuccess> Successes { get; } = new();
        public List<IResult> Children { get; } = new();


        IReadOnlyDictionary<string, object> IResult.Metadata => this.Metadata;
        IEnumerable<IFailure> IResult.Failures => this.Failures;
        IEnumerable<ISuccess> IResult.Successes => this.Successes;
        IEnumerable<IResult> IResult.Children => this.Children;
    }


    /// <inheritdoc cref="IResult{TValue}"/>
    /// <remarks>
    /// Note: not thread-safe.
    /// </remarks>
    [UtilityTypeMarker]
    public class Result<TValue> : Result, IResult<TValue>
    {
        private bool zHasValue;
        public bool HasValue => this.zHasValue;

        private TValue zValue;
        public TValue Value
        {
            get => this.zValue;
            set
            {
                // Note, not thread-safe since these two lines are not guaranteed to be atomic.
                this.zValue = value;
                
                this.zHasValue = true;
            }
        }
    }
}
