using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0146
{
	[FunctionalityMarker]
	public partial interface IResultSerializer : IFunctionalityMarker
	{
        #region Static

        private static Serialization.Result ToSerialization(IResult result)
        {
            var output = new Serialization.Result()
            {
                Success = result.IsSuccess(),
                Title = result.Title,
                Metadata = new Dictionary<string, object>(result.Metadata),
                Failures = result.Failures.Select(x => IResultSerializer.ToSerialization(x)).Now(),
                Successes = result.Successes.Select(x => IResultSerializer.ToSerialization(x)).Now(),
                Children = result.Children.Select(x => IResultSerializer.ToSerialization(x)).Now(),
            };

            return output;
        }

        private static Serialization.Success ToSerialization(ISuccess success)
        {
            var output = new Serialization.Success()
            {
                Message = success.Message,
                Metadata = new Dictionary<string, object>(success.Metadata),
            };

            return output;
        }

        private static Serialization.Failure ToSerialization(IFailure failure)
        {
            Serialization.Failure output;

            if(failure is IExceptionFailure exceptionFailure)
            {
                output = IResultSerializer.ToSerialization(exceptionFailure);
            }
            else
            {
                output = new Serialization.Failure();

                IResultSerializer.FillSerialization(output, failure);
            }

            return output;
        }

        private static Serialization.ExceptionFailure ToSerialization(IExceptionFailure exceptionFailure)
        {
            var exception = IResultSerializer.ToSerialization(exceptionFailure.Exception);

            var output = new Serialization.ExceptionFailure
            {
                Exception = exception,
            };

            IResultSerializer.FillSerialization(output, exceptionFailure);

            return output;
        }

        private static void FillSerialization(Serialization.Failure output, IFailure failure)
        {
            output.Message = failure.Message;
            output.Metadata = new Dictionary<string, object>(failure.Metadata);
            output.Causes = failure.Causes.Select(x => IResultSerializer.ToSerialization(x)).Now();
        }

        private static Serialization.Exception ToSerialization(Exception exception)
        {
            var output = new Serialization.Exception
            {
                Message = exception.Message,
                Type = F0000.Instances.TypeOperator.GetTypeNameOf(exception),
            };

            return output;
        }

        #endregion

        public void Serialize(string jsonFilePath, Result result, bool overwrite = true)
        {
            var output = IResultSerializer.ToSerialization(result);

            F0032.Instances.JsonOperator.SaveToFile(jsonFilePath, output, overwrite);
        }

        public void Serialize(string jsonFilePath, IEnumerable<Result> results, bool overwrite = true)
        {
            var output = results.Select(x => IResultSerializer.ToSerialization(x)).Now();

            F0032.Instances.JsonOperator.SaveToFile(jsonFilePath, output, overwrite);
        }
    }
}