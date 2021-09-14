namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Сумма платежа
    /// </summary>
    public class Amount
    {
        /// <summary>
        ///     Сумма в выбранной валюте
        /// </summary>
        /// <remarks>
        ///     Выражается в виде строки и пишется через точку, например 10.00. Количество знаков после точки зависит от выбранной валюты.
        /// </remarks>
        public string Value { get; init; }

        /// <summary>
        ///     Код валюты в формате ISO-4217
        /// </summary>
        /// <remarks>
        ///      Должен соответствовать валюте субаккаунта (<see cref="Recipient.GatewayId"/>), если вы разделяете потоки платежей, и валюте аккаунта (<see cref="Options.YooKassaOptions.StoreId"/> в личном кабинете), если не разделяете.
        /// </remarks>
        public string Currency { get; init; } = "RUB";
    }
}