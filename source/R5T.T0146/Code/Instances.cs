using System;


namespace R5T.T0146
{
    public static class Instances
    {
        public static IFailureOperator FailureOperator { get; } = T0146.FailureOperator.Instance;
        public static IResultSerializer ResultSerializer { get; } = T0146.ResultSerializer.Instance;
        public static IReasonOperator ReasonOperator { get; } = T0146.ReasonOperator.Instance;
        public static IResultOperator ResultOperator { get; } = T0146.ResultOperator.Instance;
    }
}