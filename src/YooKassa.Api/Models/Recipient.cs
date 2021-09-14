using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    public class Recipient
    {
        /// <summary>
        /// Идентификатор магазина в Яндекс.Кассе
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("gateway_id")]
        public string GatewayId { get; set; }
    }
}