using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    public enum CardSourceType
    {
        Unknown,
        [JsonPropertyName("apple_pay")]
        ApplePay,
        [JsonPropertyName("google_pay")]
        GooglePay
    }

    /// <summary>
    ///     Данные банковской карты
    /// </summary>
    public class Card
    {
        /// <summary>
        ///     Первые 6 цифр номера карты (BIN)
        /// </summary>
        public string First6 { get; init; }

        /// <summary>
        ///     Последние 4 цифры номера карты
        /// </summary>
        public string Last4 { get; init; }

        /// <summary>
        ///     Срок действия, год
        /// </summary>
        /// <remarks>
        ///     YYYY
        /// </remarks>
        [JsonPropertyName("expiry_year")]
        public string ExpiryYear { get; init; }

        /// <summary>
        ///     Срок действия, месяц
        /// </summary>
        /// <remarks>
        ///     MM
        /// </remarks>
        [JsonPropertyName("expiry_month")]
        public string ExpiryMonth { get; init; }

        /// <summary>
        ///     Тип банковской карты
        /// </summary>
        [JsonPropertyName("card_type")]
        public string CardType { get; init; }

        /// <summary>
        ///     Код страны, в которой выпущена карта
        /// </summary>
        /// <remarks>
        ///      Передается в формате ISO-3166 alpha-2. Пример: RU
        /// </remarks>
        [JsonPropertyName("issuer_country")]
        public string IssuerCountry { get; init; }

        /// <summary>
        ///     Наименование банка, выпустившего карту.
        /// </summary>
        [JsonPropertyName("issuer_name")]
        public string IssuerName { get; init; }

        /// <summary>
        ///     Источник данных банковской карты
        /// </summary>
        public CardSourceType Source { get; init; }
    }
}