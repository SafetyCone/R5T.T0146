using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0146
{
	[FunctionalityMarker]
	public partial interface IResultOperator : IFunctionalityMarker
	{
        /// <summary>
        /// If a result has child failures, add a failure reason.
        /// </summary>
        public void AddChildFailuresFailure_IfChildFailures(Result result)
        {
            var hasChildFailures = this.Has_ChildFailures(result);

            if (hasChildFailures)
            {
                var childFailuresFailure = Instances.FailureOperator.Get_ChildFailuresFailure();

                result.WithReason(childFailuresFailure);
            }
        }

        public Result AddChild(Result result, Result childResult)
        {
            result.Children.Add(childResult);

            return result;
        }

        /// <summary>
        /// Adds a child result only if the child result is a failure.
        /// </summary>
        public Result AddChild_IfFailure(Result result, Result childResult)
        {
            if(childResult.IsFailure())
            {
                this.AddChild(result, childResult);
            }

            return result;
        }

        public TResult AddChildren<TResult>(TResult result, params Result[] childResults)
            where TResult : Result
        {
            this.AddChildren(
                result,
                childResults.AsEnumerable());

            return result;
        }

        public Result AddChildren(Result result, IEnumerable<Result> childResults)
        {
            result.Children.AddRange(childResults);

            return result;
        }

        public TResult AddFailure<TResult>(TResult result, string failureMessage)
            where TResult : Result
        {
            result.Failures.Add(
                Instances.ReasonOperator.Failure(failureMessage));

            return result;
        }

        public Result AddFailure(Result result, Exception cause)
        {
            result.Failures.Add(
                Instances.ReasonOperator.Failure(cause));

            return result;
        }

        public Result AddFailure(Result result, string failureMessage, IEnumerable<IFailure> failures)
        {
            result.Failures.Add(
                Instances.ReasonOperator.Failure(failureMessage, failures));

            return result;
        }

        public TResult AddFailure<TResult>(TResult result, string failureMessage, Exception cause)
            where TResult : Result
        {
            result.Failures.Add(
                Instances.ReasonOperator.Failure(failureMessage, cause));

            return result;
        }

        public TResult AddMetadata<TResult>(TResult result, string key, object value)
            where TResult : Result
        {
            result.Metadata.Add(key, value);

            return result;
        }

        public TResult AddMetadata<TResult>(TResult result, IDictionary<string, object> metadata)
            where TResult : Result
        {
            result.Metadata.AddRange(metadata);

            return result;
        }

        public TResult AddOutcome<TResult>(TResult result,
            bool success,
            string successReason,
            string failureReason)
            where TResult : Result
        {
            if (success)
            {
                result.WithSuccess(successReason);
            }
            else
            {
                result.WithFailure(failureReason);
            }

            return result;
        }

        public TResult AddReasons<TResult>(TResult result, params IReason[] reasons)
            where TResult : Result
        {
            var output = this.AddReasons(result, reasons.AsEnumerable());
            return output;
        }

        public TResult AddReasons<TResult>(TResult result, IEnumerable<IReason> reasons)
            where TResult : Result
        {
            var failures = reasons.OfType<IFailure>();

            result.Failures.AddRange(failures);

            var successes = reasons.OfType<ISuccess>();

            result.Successes.AddRange(successes);

            return result;
        }

        public TResult AddSuccess<TResult>(TResult result, string successMessage)
            where TResult : Result
        {
            result.Successes.Add(
                Instances.ReasonOperator.Success(successMessage));

            return result;
        }

        public TResult AddTitle<TResult>(TResult result, string title)
            where TResult : Result
        {
            result.Title = title;

            return result;
        }

        public TResult AddValue<TResult, TValue>(TResult result, TValue value)
            where TResult : Result<TValue>
        {
            result.Value = value;

            return result;
        }

        public Result Failure(string failureMessage)
        {
            var output = this.Result().WithFailure(failureMessage);
            return output;
        }

        public Result Failure(Exception cause)
        {
            var output = this.Result().WithFailure(cause);
            return output;
        }

        public Result Failure(string failureMessage, Exception cause)
        {
            var output = this.Result().WithFailure(failureMessage, cause);
            return output;
        }

        public Result<TValue> Failure<TValue>(TValue value, string failureMessage)
        {
            var output = this.Result<TValue>(value)
                .WithFailure(failureMessage)
                ;
            return output;
        }

        public Result<TValue> Failure<TValue>(string failureMessage, Exception cause)
        {
            var output = this.Result<TValue>().WithFailure(failureMessage, cause);
            return output;
        }

        /// <summary>
        /// Are any of a result's children failures?
        /// </summary>
        public bool Has_ChildFailures(IResult result)
        {
            var output = result.Children
                .Where(child => this.IsFailure(child))
                .Any();
                ;

            return output;
        }

        /// <summary>
        /// Are any of a result's children, or children of children, failures recursively?
        /// </summary>
        public bool Has_ChildFailures_Recursive(IResult result)
        {
            var output = result.Children
                .Where(child => this.IsFailure(child))
                .Any();
            ;

            return output;
        }

        /// <summary>
        /// If there are any failure reasons, the result is a failure.
        /// </summary>
        public bool IsFailure(IResult result)
        {
            var isFailure = result.Failures.Any();
            return isFailure;
        }

        /// <summary>
        /// If there are any failure reasons, the result is a failure.
        /// Otherwise, the result is a success.
        /// </summary>
        public bool IsSuccess(IResult result)
        {
            var isFailure = this.IsFailure(result);

            var isSuccess = !isFailure;
            return isSuccess;
        }

        public Result<TValue> New<TValue>()
        {
            var result = this.Result<TValue>();
            return result;
        }

        public Result<TValue> New<TValue>(TValue value)
        {
            var result = this.New<TValue>()
                .WithValue(value)
                ;

            return result;
        }

        public Result New()
        {
            var result = this.Result();
            return result;
        }

        public IEnumerable<IReason> Reasons(Result result)
        {
            var output = result.Failures
                .Cast<IReason>()
                .Concat(result.Successes)
                ;

            return output;
        }

        public void FillResultFromResult(Result destination, Result source)
        {
            destination.Title = source.Title;
            destination.Metadata.AddRange(source.Metadata);
            destination.Failures.AddRange(source.Failures);
            destination.Successes.AddRange(source.Successes);
            destination.Children.AddRange(source.Children);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Filter_RemoveSuccesses{TResult}(TResult)"/>
        /// </summary>
        public void Filter_KeepFailuresOnly<TResult>(TResult result)
            where TResult : Result
        {
            this.Filter_RemoveSuccesses(result);
        }

        /// <summary>
        /// This is useful when trying to find failures.
        /// </summary>
        public void Filter_RemoveSuccesses<TResult>(TResult result)
            where TResult : Result
        {
            // Remove all success reaons.
            result.Successes.Clear();

            // Keep only failure children.
            var failureChildren = result.Children
                .Where(child => child.IsFailure())
                .Now();

            result.Children.Clear();

            result.Children.AddRange(failureChildren);

            // Recurse.
            foreach (var child in result.Children)
            {
                this.Filter_RemoveSuccesses(child);
            }
        }

        public Result<T> Result<T>(Result result, T value)
        {
            var output = this.Result<T>(value);

            this.FillResultFromResult(output, result);

            return output;
        }

        public Result Result()
        {
            var output = new Result();
            return output;
        }

        public Result Result(string title)
        {
            var output = this.Result()
                .WithTitle(title)
                ;

            return output;
        }

        public Result<TValue> Result<TValue>()
        {
            var output = new Result<TValue>();
            return output;
        }

        public Result<TValue> Result<TValue>(TValue value)
        {
            var output = new Result<TValue>()
                .WithValue(value)
                ;

            return output;
        }

        public Result Success()
        {
            // Success is just the default result.
            var output = this.Result();
            return output;
        }

        public Result<TValue> Success<TValue>(TValue value)
        {
            var output = new Result<TValue>
            {
                Value = value,
            };

            return output;
        }

        public Result SuccessWithMessage(string successMessage)
        {
            var output = this.Result()
                .WithSuccess(successMessage)
                ;

            return output;
        }

        public Result<TValue> SuccessWithMessage<TValue>(TValue value, string successMessage)
        {
            var output = this.Success(value)
                .WithSuccess(successMessage)
                ;

            return output;
        }

        public IReason ToReason(
            IResult result,
            string successReason,
            string failureReason)
        {
            var reason = result.IsSuccess()
                ? Instances.ReasonOperator.Success(successReason) as IReason
                : Instances.ReasonOperator.Failure(failureReason, result.Failures) as IReason
                ;

            return reason;
        }

        public string ToString(IResult result)
        {
            var representation = $"{result.IsSuccess()}: success?";
            return representation;
        }
    }
}