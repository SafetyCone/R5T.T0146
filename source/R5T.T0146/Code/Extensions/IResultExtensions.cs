using System;
using System.Collections.Generic;

using R5T.T0146;

using Instances = R5T.T0146.Instances;


namespace System
{
    public static class IResultExtensions
    {
        public static bool IsFailure(this IResult result)
        {
            var output = Instances.ResultOperator.IsFailure(result);
            return output;
        }

        public static bool IsSuccess(this IResult result)
        {
            var output = Instances.ResultOperator.IsSuccess(result);
            return output;
        }

        public static IEnumerable<IReason> Reasons(this Result result)
        {
            var output = Instances.ResultOperator.Reasons(result);
            return output;
        }

        public static IReason ToReason(this IResult result,
            string successReason,
            string failureReason)
        {
            var reason = Instances.ResultOperator.ToReason(
                result,
                successReason,
                failureReason);

            return reason;
        }

        public static Result WithChild(this Result result, Result childResult)
        {
            var output = Instances.ResultOperator.AddChild(result, childResult);
            return output;
        }

        public static Result WithChild_IfFailure(this Result result, Result childResult)
        {
            var output = Instances.ResultOperator.AddChild_IfFailure(result, childResult);
            return output;
        }

        public static TResult WithChildren<TResult>(this TResult result, params Result[] childResults)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddChildren(result, childResults);
            return output;
        }

        public static Result WithChildren(this Result result, IEnumerable<Result> childResults)
        {
            var output = Instances.ResultOperator.AddChildren(result, childResults);
            return output;
        }

        public static TResult WithFailure<TResult>(this TResult result, string failureMessage)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddFailure(result, failureMessage);
            return output;
        }

        public static Result WithFailure(this Result result, Exception cause)
        {
            var output = Instances.ResultOperator.AddFailure(result, cause);
            return output;
        }

        public static Result WithFailure(this Result result, string failureMessage, IEnumerable<IFailure> failures)
        {
            var output = Instances.ResultOperator.AddFailure(result, failureMessage, failures);
            return output;
        }

        public static TResult WithFailure<TResult>(this TResult result, string failureMessage, Exception cause)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddFailure(result, failureMessage, cause);
            return output;
        }

        public static TResult WithMetadata<TResult>(this TResult reason, string key, object value)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddMetadata(reason, key, value);
            return output;
        }

        public static TResult WithOutcome<TResult>(this TResult result,
            bool success,
            string successReason,
            string failureReason)
            where TResult : Result
        {
            result = Instances.ResultOperator.AddOutcome(
                result,
                success,
                successReason,
                failureReason);

            return result;
        }

        public static TResult WithMetadata<TResult>(this TResult reason, IDictionary<string, object> metadata)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddMetadata(reason, metadata);
            return output;
        }

        public static TResult WithReason<TResult>(this TResult result, IReason reason)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddReasons(result, reason);
            return output;
        }

        public static TResult WithReasons<TResult>(this TResult result, params IReason[] reasons)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddReasons(result, reasons);
            return output;
        }

        public static Result WithReasons(this Result result, IEnumerable<IReason> reasons)
        {
            var output = Instances.ResultOperator.AddReasons(result, reasons);
            return output;
        }

        public static TResult WithSuccess<TResult>(this TResult result, string successMessage)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddSuccess(result, successMessage);
            return output;
        }

        public static TResult WithTitle<TResult>(this TResult result, string title)
            where TResult : Result
        {
            var output = Instances.ResultOperator.AddTitle(result, title);
            return output;
        }

        public static TResult WithValue<TResult, TValue>(this TResult result, TValue value)
            where TResult : Result<TValue>
        {
            var output = Instances.ResultOperator.AddValue(result, value);
            return output;
        }
    }
}
