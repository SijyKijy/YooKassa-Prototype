using System.Text.Json;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Исходные данные для создания платежа
    /// </summary>
    public class NewPaymentData
    {
        /// <summary>
        ///     Сумма платежа
        /// </summary>
        /// <remarks>
        ///     Иногда партнеры ЮKassa берут с пользователя дополнительную комиссию, которая не входит в эту сумму
        /// </remarks>
        public Amount Amount { get; init; }

        /// <summary>
        ///     Описание транзакции, которое вы увидите в личном кабинете Яндекс.Кассы, а пользователь — при оплате
        /// </summary>
        /// <remarks>
        ///     Пример: "Оплата заказа №72 для user@yandex.ru"
        /// </remarks>
        public string Description { get; init; }

        /// <summary>
        ///     Чек для проведения платежа по ФЗ-54
        /// </summary>
        public Receipt Receipt { get; init; }

        /// <inheritdoc cref="Models.Recipient"/>
        /// <remarks>
        ///     Нужен, если вы разделяете потоки платежей в рамках одного аккаунта или создаете платеж в адрес другого аккаунта
        /// </remarks>
        public Recipient Recipient { get; init; }

        /// <summary>
        ///     Одноразовый токен для проведения оплаты, сформированный с помощью <see href="https://yookassa.ru/developers/payments/sdk-tokens">веб или мобильного SDK</see>
        /// </summary>
        public string PaymentToken { get; init; }

        /// <summary>
        ///     Идентификатор <see href="https://yookassa.ru/developers/payments/recurring-payments">сохраненного способа оплаты</see>
        /// </summary>
        public string PaymentMethodId { get; init; }

        /// <summary>
        ///     Данные для оплаты конкретным способом оплаты
        /// </summary>
        /// <remarks>
        ///     Вы можете не передавать этот объект в запросе. В этом случае пользователь будет выбирать способ оплаты на стороне ЮKassa.
        /// </remarks>
        public PaymentMethod PaymentMethodData { get; init; }

        /// <summary>
        ///     Данные, необходимые для инициации выбранного сценария подтверждения платежа пользователем
        /// </summary>
        public Confirmation Confirmation { get; init; }

        /// <summary>
        ///     Сохранение платежных данных
        /// </summary>
        /// <remarks>
        ///     C их помощью можно проводить повторные безакцептные списания.
        ///     <br/>
        ///     Значение true инициирует создание многоразового <see cref="PaymentMethod"/>.
        /// </remarks>
        [JsonPropertyName("save_payment_method")]
        public bool? IsSavePaymentMethod { get; init; }

        /// <summary>
        ///     <see href="https://yookassa.ru/developers/payments/payment-process#capture-true">Автоматический прием</see> поступившего платежа
        /// </summary>
        public bool? Capture { get; init; }

        /// <summary>
        ///     IPv4 или IPv6-адрес пользователя
        /// </summary>
        /// <remarks>
        ///     Если не указан, используется IP-адрес TCP-подключения
        /// </remarks>
        public string ClientIp { get; init; }

        /// <summary>
        ///     Дополнительные данные, которые можно передать вместе с запросом и получить в ответе от ЮKassa для реализации внутренней логики
        /// </summary>
        [JsonIgnore]
        public JsonElement? Metadata { get; init; }

        /*
         * TODO: Add airline https://yookassa.ru/developers/api#create_payment_airline
         * TODO: Add transfers https://yookassa.ru/developers/api#create_payment_transfers
         * TODO: Add deals https://yookassa.ru/developers/api#create_payment_deal
         */

        /// <summary>
        ///     Идентификатор покупателя в вашей системе
        /// </summary>
        /// <remarks>
        ///     Например электронная почта или номер телефона
        ///     <br/>
        ///     Не более 200 символов
        ///     <br/>
        ///     Присутствует, если вы хотите запомнить банковскую карту и отобразить ее при повторном платеже в <see href="https://yookassa.ru/developers/payment-forms/widget/basics">виджете ЮKassa</see>
        /// </remarks>
        public string MerchantCustomerId { get; init; }
    }
}
