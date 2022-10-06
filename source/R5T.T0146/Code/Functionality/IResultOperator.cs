using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0146
{
	[FunctionalityMarker]
	public partial interface IResultOperator : IFunctionalityMarker
	{
        public Result AddChild(Result result, IResult childResult)
        {
            result.Children.Add(childResult);

            return result;
        }

        public TResult AddChildren<TResult>(TResult result, params IResult[] childResults)
            where TResult : Result
        {
            result.Children.AddRange(childResults);

            return result;
        }

        public Result AddChildren(Result result, IEnumerable<IResult> childResults)
        {
            result.Children.AddRange(childResults);

            return result;
        }

        public Result AddFailure(Result result, string failureMessage)
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

        public Result<TValue> Failure<TValue>(string failureMessage, Exception cause)
        {
            var output = this.Result<TValue>().WithFailure(failureMessage, cause);
            return output;
        }

        public bool IsFailure(IResult result)
        {
            var isFailure = result.Failures.Any();
            return isFailure;
        }

        public bool IsSuccess(IResult result)
        {
            var isFailure = this.IsFailure(result);

            var isSuccess = !isFailure;
            return isSuccess;
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
    }
}