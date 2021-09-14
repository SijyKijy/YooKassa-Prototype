using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Исходные данные для создания платежа.
    /// </summary>
    public class Payment
    {
        public string Id {  get; init; }
        
        public string Status { get; init; }

        [JsonPropertyName("paid")]
        public bool IsPaid { get; init; }

        /// <summary>
        ///     Сумма платежа.
        ///     Иногда партнеры Яндекс.Кассы берут с пользователя дополнительную комиссию, которая не входит в эту сумму.
        /// </summary>
        public Amount Amount { get; init; }

        [JsonPropertyName("create_at")]
        public DateTime CreateAt { get; init; }

        public string Description { get; init; }

        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; init; }

        [JsonIgnore]
        public JsonProperty Metadata { get; init; }

        [JsonPropertyName("payment_method")]
        public PaymentMethod PaymentMethod { get; init; }

        /// <summary>
        ///     Получатель платежа.
        /// </summary>
        /// <remarks>
        ///     Нужен, если вы разделяете потоки платежей в рамках одного аккаунта или создаете платеж в адрес другого аккаунт
        /// </remarks>
        public Recipient Recipient { get; init; }

        /// <summary>
        ///     Возможность провести возврат по API
        /// </summary>
        public bool Refundable { get; init; }

        /// <summary>
        ///     Признак тестовой операции
        /// </summary>
        public bool Test { get; init; }

        /// <summary>
        ///     Сумма платежа, которую получит магазин
        /// </summary>
        [JsonPropertyName("income_amount")]
        public Amount IncomeAmount { get; init; }
    }
}
