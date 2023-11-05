using System;

using Newtonsoft.Json;

using R5T.T0142;


namespace R5T.T0146
{
    [UtilityTypeMarker]
    public class ExceptionJsonConverter : JsonConverter<Exception>
    {
        public override Exception ReadJson(JsonReader reader, Type objectType, Exception existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Exception value, JsonSerializer serializer)
        {
            var exceptionTypeName = value.GetType().FullName;
            var message = $"{exceptionTypeName}: {value.Message}";

            writer.WriteValue(message);
        }

        public override bool CanRead => false;
    }
}
