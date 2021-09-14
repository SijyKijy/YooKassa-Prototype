using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    public enum CardSourceType
    {
        Unknown,
        ApplePay,
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
        public string ExpiryYear { get; init; }

        /// <summary>
        ///     Срок действия, месяц
        /// </summary>
        /// <remarks>
        ///     MM
        /// </remarks>
        public string ExpiryMonth { get; init; }

        /// <summary>
        ///     Тип банковской карты
        /// </summary>
        public string CardType { get; init; }

        /// <summary>
        ///     Код страны, в которой выпущена карта
        /// </summary>
        /// <remarks>
        ///      Передается в формате ISO-3166 alpha-2. Пример: RU
        /// </remarks>
        public string IssuerCountry { get; init; }

        /// <summary>
        ///     Наименование банка, выпустившего карту.
        /// </summary>
        public string IssuerName { get; init; }

        /// <summary>
        ///     Источник данных банковской карты
        /// </summary>
        public CardSourceType Source { get; init; }
    }
}