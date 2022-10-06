using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0146
{
	[FunctionalityMarker]
	public partial interface IReasonOperator : IFunctionalityMarker
	{
		public TReason AddMetadata<TReason>(TReason reason, string key, object value)
			where TReason : Reason
        {
			reason.Metadata.Add(key, value);

			return reason;
        }

		public TReason AddMetadata<TReason>(TReason reason, IDictionary<string, object> metadata)
			where TReason : Reason
		{
			reason.Metadata.AddRange(metadata);

			return reason;
		}

		public Failure Failure()
        {
			var output = new Failure();
			return output;
        }

		public Failure Failure(string failureMessage)
		{
			var output = this.Failure()
				.WithMessage(failureMessage)
				;

			return output;
		}

		public Failure Failure(
			string failureMessage,
			IFailure cause)
		{
			var output = this.Failure(failureMessage)
				.CausedBy(cause)
				;

			return output;
		}

		public Failure Failure(
			string failureMessage,
			params IFailure[] causes)
		{
			var output = this.Failure(failureMessage, causes.AsEnumerable());
			return output;
		}

		public Failure Failure(
			string failureMessage,
			IEnumerable<IFailure> causes)
		{
			var output = this.Failure(failureMessage)
				.CausedBy(causes)
				;

			return output;
		}

		public ExceptionFailure Failure(Exception cause)
        {
			var output = new ExceptionFailure()
			{
				Exception = cause,
			};

			return output;
        }

		public ExceptionFailure Failure(
			string failureMessage,
			Exception cause)
		{
			var output = this.Failure(cause)
				.WithMessage(failureMessage)
				;

			return output;
		}

		public TReason SetMessage<TReason>(TReason reason, string message)
			where TReason : Reason
		{
			reason.Message = message;

			return reason;
		}

		public Success Success()
        {
			var output = new Success();
			return output;
        }

		public Success Success(string successMessage)
        {
			var output = this.Success()
				.WithMessage(successMessage)
				;

			return output;
        }
	}
}