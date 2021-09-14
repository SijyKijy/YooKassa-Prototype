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
        public string AccountId { get; init; }

        /// <summary>
        ///     Идентификатор субаккаунта
        /// </summary>
        public string GatewayId { get; init; }
    }
}