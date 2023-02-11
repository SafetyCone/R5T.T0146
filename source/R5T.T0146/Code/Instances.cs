using System;


namespace R5T.T0146
{
    public static class Instances
    {
        public static IFailureOperator FailureOperator => T0146.FailureOperator.Instance;
        public static IResultSerializer ResultSerializer => T0146.ResultSerializer.Instance;
        public static IReasonOperator ReasonOperator => T0146.ReasonOperator.Instance;
        public static IResultOperator ResultOperator => T0146.ResultOperator.Instance;
    }
}