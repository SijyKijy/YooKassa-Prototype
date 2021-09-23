using System.Text.Json;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Http-уведомление
    /// </summary>
    public class Notification
    {
        public string Type { get; init; }

        [JsonPropertyName("event")]
        public string EventType { get; init; }

        [JsonPropertyName("object")]
        public JsonElement? Payload { get; init; }
    }
}