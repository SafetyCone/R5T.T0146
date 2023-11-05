using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.T0146
{
    /// <inheritdoc cref="IResult"/>
    [DataTypeMarker]
    public class Result : IResult
    {
        public string Title { get; set; }
        public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();

        public List<IFailure> Failures { get; } = new List<IFailure>();
        public List<ISuccess> Successes { get; } = new List<ISuccess>();
        public List<Result> Children { get; } = new List<Result>();


        IReadOnlyDictionary<string, object> IResult.Metadata => this.Metadata;
        IEnumerable<IFailure> IResult.Failures => this.Failures;
        IEnumerable<ISuccess> IResult.Successes => this.Successes;
        IEnumerable<IResult> IResult.Children => this.Children;

        public override string ToString()
        {
            var isFailure = Instances.ResultOperator.IsFailure(this);

            var output = isFailure
                ? $"<FAIL> {this.Title}"
                : $"<Success> {this.Title}"
                ;

            return output;
        }
    }


    /// <inheritdoc cref="IResult{TValue}"/>
    /// <remarks>
    /// Note: not thread-safe.
    /// </remarks>
    [UtilityTypeMarker]
    public class Result<TValue> : Result, IResult<TValue>
    {
        #region Static

        public static implicit operator TValue(Result<TValue> result)
        {
            return result.Value;
        }

        #endregion


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

        public override string ToString()
        {
            var isFailure = Instances.ResultOperator.IsFailure(this);

            var output = isFailure
                ? $"<FAIL> {this.Value} | {this.Title}"
                : $"<Success> {this.Value} | {this.Title}"
                ;

            return output;
        }
    }
}
