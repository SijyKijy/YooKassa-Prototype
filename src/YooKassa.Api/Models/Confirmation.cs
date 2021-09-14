using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Cпособ подтверждения платежа
    /// </summary>
    public class Confirmation
    {
        /// <summary>
        ///     Код сценария подтверждения
        /// </summary>
        public string Type { get; init; }

        /// <summary>
        ///     URL, на который вернется пользователь после подтверждения или отмены платежа на веб-странице
        /// </summary>
        [JsonPropertyName("return_url")]
        public string ReturnUrl { get; init; }

        /// <summary>
        ///     Диплинк на мобильное приложение, в котором пользователь подтверждает платеж
        /// </summary>
        [JsonPropertyName("confirmation_url")]
        public string ConfirmationUrl { get; init; }

        /// <summary>
        ///     Запрос на проведение платежа с аутентификацией по 3-D Secure
        /// </summary>
        /// <remarks>
        ///     Будет работать, если оплату банковской картой вы по умолчанию принимаете без подтверждения платежа пользователем.
        ///     <br/>
        ///     В остальных случаях аутентификацией по 3-D Secure будет управлять ЮKassa.
        ///     <br/>
        ///     Если хотите принимать платежи без дополнительного подтверждения пользователем, напишите вашему менеджеру ЮKassa.
        /// </remarks>
        public bool? Enforce { get; init; }

        /// <summary>
        ///     Язык интерфейса, писем и смс, которые будет видеть или получать пользователь
        /// </summary>
        /// <remarks>
        ///     Формат соответствует ISO/IEC 15897
        /// </remarks>
        public string Locale { get; init; } // TODO: В enum https://yookassa.ru/developers/api#create_payment_confirmation_embedded_locale

        /// <summary>
        ///     Токен для инициализации платежного <see href="https://yookassa.ru/developers/payment-forms/widget/basics">виджета ЮKassa</see>
        /// </summary>
        [JsonPropertyName("confirmation_token")]
        public string ConfirmationToken { get; init; }

        /// <summary>
        ///     Данные для генерации QR-кода
        /// </summary>
        [JsonPropertyName("confirmation_data")]
        public string ConfirmationData { get; init; }
    }
}