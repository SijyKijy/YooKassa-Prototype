using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Объект платежа
    /// </summary>
    public class Payment
    {
        /// <summary>
        ///     Идентификатор платежа в ЮKassa.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        ///     Статус платежа
        /// </summary>
        public string Status { get; init; } // TODO: Перевести на enum https://yookassa.ru/developers/api#payment_object_status

        /// <summary>
        ///     Сумма платежа
        /// </summary>
        /// <remarks>
        ///     Иногда партнеры ЮKassa берут с пользователя дополнительную комиссию, которая не входит в эту сумму.
        /// </remarks>
        public Amount Amount { get; init; }

        /// <summary>
        ///     Сумма платежа, которую получит магазин
        /// </summary>
        public Amount IncomeAmount { get; init; }

        /// <summary>
        ///     Описание транзакции, которое вы увидите в личном кабинете ЮKassa, а пользователь - при оплате
        /// </summary>
        /// <remarks>
        ///     Не более 128 символов
        /// </remarks>
        public string Description { get; init; }

        /// <inheritdoc cref="Models.Recipient"/>
        /// <remarks>
        ///     Нужен, если вы разделяете потоки платежей в рамках одного аккаунта или создаете платеж в адрес другого аккаунт
        /// </remarks>
        public Recipient Recipient { get; init; }

        /// <summary>
        ///     Способ оплаты , который был использован для этого платежа
        /// </summary>
        public PaymentMethod PaymentMethod { get; init; }

        /// <summary>
        ///     Время подтверждения платежа
        /// </summary>
        /// <remarks>
        ///     Указывается по UTC и передается в формате ISO 8601
        /// </remarks>
        public DateTime? CapturedAt { get; init; }

        /// <summary>
        ///     Время создания заказа
        /// </summary>
        /// <remarks>
        ///     Указывается по UTC и передается в формате ISO 8601
        /// </remarks>
        public DateTime? CreateAt { get; init; }

        /// <summary>
        ///     Время, до которого вы можете бесплатно отменить или подтвердить платеж
        /// </summary>
        /// <remarks>
        ///     В указанное время платеж в статусе waiting_for_capture будет автоматически отменен.
        ///     <br/>
        ///     Указывается по UTC и передается в формате ISO 8601
        /// </remarks>
        public DateTime? ExpiresAt { get; init; }

        /// <summary>
        ///     Выбранный способ подтверждения платежа
        /// </summary>
        /// <remarks>
        ///     Присутствует, когда платеж ожидает подтверждения от пользователя
        /// </remarks>
        public Confirmation Confirmation { get; init; }

        /// <summary>
        ///     Признак тестовой операции
        /// </summary>
        [JsonPropertyName("test")]
        public bool IsTest { get; init; }

        /// <summary>
        ///     Сумма, которая вернулась пользователю
        /// </summary>
        /// <remarks>
        ///     Присутствует, если у этого платежа есть успешные возвраты
        /// </remarks>
        public Amount RefundedAmount { get; init; }

        /// <summary>
        ///     Признак оплаты заказа
        /// </summary>
        [JsonPropertyName("paid")]
        public bool IsPaid { get; init; }

        /// <summary>
        ///     Возможность провести возврат по API
        /// </summary>
        [JsonPropertyName("refundable")]
        public bool IsRefundable { get; init; }

        /// <summary>
        ///     Статус доставки данных для чека в онлайн-кассу
        /// </summary>
        public string ReceiptRegistration { get; init; } // TODO: Сделать enum https://yookassa.ru/developers/api#payment_object_receipt_registration

        /// <summary>
        ///     Любые дополнительные данные, которые нужны вам для работы (например, номер заказа)
        /// </summary>
        /// <remarks>
        ///     Ограничения: максимум 16 ключей, имя ключа не больше 32 символов, значение ключа не больше 512 символов, тип данных - строка в формате UTF-8
        /// </remarks>
        public JsonElement? Metadata { get; init; }

        /// <summary>
        ///     Комментарий к статусу canceled: кто отменил платеж и по какой причине.
        /// </summary>
        /// <remarks>
        ///     Подробнее про <see href="https://yookassa.ru/developers/payments/declined-payments">неуспешные платежи</see>
        /// </remarks>
        public JsonElement? CancellationDetails { get; set; }

        /*
         * TODO: authorization_details https://yookassa.ru/developers/api#payment_object_authorization_details
         * TODO: transfers https://yookassa.ru/developers/api#payment_object_transfers
         * TODO: deal https://yookassa.ru/developers/api#payment_object_deal
         * TODO: merchant_customer_id https://yookassa.ru/developers/api#payment_object_merchant_customer_id
         */
    }
}
