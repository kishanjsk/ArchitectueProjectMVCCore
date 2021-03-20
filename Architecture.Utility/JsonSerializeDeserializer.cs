using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Architecture.Utility
{
    public static class JsonSerializeDeserializer
    {
        public static TEntity JSONStringToObject<TEntity>(string json)
        {
            return JsonConvert.DeserializeObject<TEntity>(json.ToSafeString());
        }

        public static string JsonString<TEntity>(TEntity obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T JSONStringToObject<T>(string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json.ToSafeString(), settings);
        }

        // NOT IN USE
        public static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

    }
}