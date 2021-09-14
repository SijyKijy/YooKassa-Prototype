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
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true,
            };
        }

        public static JsonSerializerOptions JsonSerializerOptions { get; }
    }
}
