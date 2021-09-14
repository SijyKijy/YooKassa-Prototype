using System.Collections.Generic;

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
        ///     Автоматический прием поступившего платежа
        /// </summary>
        public bool? Capture { get; init; }

        /// <summary>
        ///     Данные, необходимые для инициации выбранного сценария подтверждения платежа пользователем
        /// </summary>
        public Confirmation Confirmation { get; init; }

        /// <summary>
        ///     Дополнительные данные, которые можно передать вместе с запросом и получить в ответе от ЮKassa для реализации внутренней логики
        /// </summary>
        public Dictionary<string, string> Metadata { get; init; }

        /// <summary>
        ///     Чек для проведения платежа по ФЗ-54
        /// </summary>
        public Receipt Receipt { get; init; }

        public Recipient Recipient { get; init; }

        public string PaymentToken { get; init; }

        public string PaymentMethodId { get; init; }

        public PaymentMethod PaymentMethodData { get; init; }

        public bool? SavePaymentMethod { get; init; }

        public string ClientIp { get; init; }

        //public Airline Airline { get; init; }
    }
}
