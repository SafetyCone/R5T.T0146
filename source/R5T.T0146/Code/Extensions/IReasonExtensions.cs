using System;
using System.Collections.Generic;

using R5T.T0146;

using Instances = R5T.T0146.Instances;


namespace System
{
    public static class IReasonExtensions
    {
        public static TReason WithMessage<TReason>(this TReason reason, string message)
            where TReason : Reason
        {
            var output = Instances.ReasonOperator.SetMessage(reason, message);
            return output;
        }

        public static TReason WithMetadata<TReason>(this TReason reason, string key, object value)
            where TReason : Reason
        {
            var output = Instances.ReasonOperator.AddMetadata(reason, key, value);
            return output;
        }

        public static TReason WithMetadata<TReason>(this TReason reason, IDictionary<string, object> metadata)
            where TReason : Reason
        {
            var output = Instances.ReasonOperator.AddMetadata(reason, metadata);
            return output;
        }
    }
}
