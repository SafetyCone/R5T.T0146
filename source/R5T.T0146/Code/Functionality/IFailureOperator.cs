using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.T0146
{
	[FunctionalityMarker]
	public partial interface IFailureOperator : IFunctionalityMarker
	{
		public Failure CausedBy(Failure failure, IFailure cause)
        {
			failure.Causes.Add(cause);

			return failure;
        }

		public Failure CausedBy(Failure failure, params IFailure[] causes)
		{
			failure.Causes.AddRange(causes);

			return failure;
		}

		public Failure CausedBy(Failure failure, IEnumerable<IFailure> causes)
		{
			failure.Causes.AddRange(causes);

			return failure;
		}

		public Failure Get_ChildFailuresFailure()
		{
			var output = Instances.ReasonOperator.Failure("Failure due to child result failures.");
			return output;
		}
	}
}