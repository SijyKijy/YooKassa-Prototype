using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    public enum PaymentMethodType
    {
        Unknown,

        /// <summary>
        ///     Альфа-клик
        /// </summary>
        [JsonPropertyName("alfabank")]
        Alfabank,

        /// <summary>
        ///     Баланс телефона
        /// </summary>
        [JsonPropertyName("mobile_balance")]
        MobileBalance,

        /// <summary>
        ///     Банковская карта
        /// </summary>
        [JsonPropertyName("bank_card")]
        BankCard,
    }

    /// <summary>
    ///     Способ оплаты
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        ///     Код способа оплаты
        /// </summary>
        public string Type { get; init; }

        /// <summary>
        ///     Идентификатор способа оплаты
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        ///     С помощью сохраненного способа оплаты можно проводить
        /// </summary>
        [JsonPropertyName("saved")]
        public bool IsSaved { get; init; }

        /// <summary>
        ///     Название способа оплаты
        /// </summary>
        public string Title { get; init; }

        /// <inheritdoc cref="Models.Card"/>
        public Card Card { get; init; }
    }
}