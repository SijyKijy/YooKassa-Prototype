using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Получатель платежа
    /// </summary>
    public class Recipient
    {
        /// <summary>
        ///     Идентификатор магазина в Ю.Кассе
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; init; }

        /// <summary>
        ///     Идентификатор субаккаунта
        /// </summary>
        [JsonPropertyName("gateway_id")]
        public string GatewayId { get; init; }
    }
}