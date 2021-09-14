using System.Text.Encodings.Web;
using System.Text.Json;

namespace YooKassa.Api.Options
{
    public static class CustomJsonOptions
    {
        static CustomJsonOptions()
        {
            JsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                IgnoreNullValues = true,
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
            };
        }

        public static JsonSerializerOptions JsonSerializerOptions { get; }
    }
}
