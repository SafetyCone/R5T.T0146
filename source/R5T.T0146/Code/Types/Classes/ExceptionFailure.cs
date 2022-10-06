using System;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146
{
    [UtilityTypeMarker]
    public class ExceptionFailure : Failure, IExceptionFailure
    {
        [JsonConverter(typeof(ExceptionJsonConverter))]
        public Exception Exception { get; set; }
    }
}
