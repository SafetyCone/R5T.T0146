using System;
using System.Collections.Generic;

using R5T.T0146;

using Instances = R5T.T0146.Instances;


namespace System
{
    public static class FailureExtensions
    {
        public static Failure CausedBy(this Failure failure, IFailure cause)
        {
            var output = Instances.FailureOperator.CausedBy(failure, cause);
            return output;
        }

        public static Failure CausedBy(this Failure failure, params IFailure[] causes)
        {
            var output = Instances.FailureOperator.CausedBy(failure, causes);
            return output;
        }

        public static Failure CausedBy(this Failure failure, IEnumerable<IFailure> causes)
        {
            var output = Instances.FailureOperator.CausedBy(failure, causes);
            return output;
        }
    }
}
