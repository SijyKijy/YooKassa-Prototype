using System.ComponentModel.DataAnnotations;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Исходные данные для создания платежа на базе платёжного токена
    /// </summary>
    public class NewPaymentByTokenData
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
        ///     Одноразовый токен для проведения оплаты, сформированный с помощью <see href="https://yookassa.ru/developers/payments/sdk-tokens">веб или мобильного SDK</see>
        /// </summary>
        [Required]
        public string PaymentToken { get; init; }

        /// <summary>
        ///     Данные, необходимые для инициации выбранного сценария подтверждения платежа пользователем
        /// </summary>
        public Confirmation Confirmation { get; init; }

        /// <summary>
        ///     Дополнительные данные, которые можно передать вместе с запросом и получить в ответе от ЮKassa для реализации внутренней логики
        /// </summary>
        public UserInfo Metadata { get; init; }
    }
}
