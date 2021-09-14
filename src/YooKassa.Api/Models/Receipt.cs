using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Чек
    /// </summary>
    public class Receipt
    {
        /// <inheritdoc cref="Models.Customer"/>
        /// <remarks>
        ///     Необходимо указать как минимум контактные данные: электронную почту или номер телефона
        /// </remarks>
        public Customer Customer { get; init; }

        /// <summary>
        ///     Список товаров в заказе
        /// </summary>
        /// <remarks>
        ///     Не более 100 товаров
        /// </remarks>
        public List<ReceiptItem> Items { get; init; }

        /// <summary>
        ///     Система налогообложения магазина
        /// </summary>
        /// <remarks>
        ///     Параметр необходим, только если у вас несколько систем налогообложения, в остальных случаях не передается
        /// </remarks>
        public TaxSystemCode? TaxSystemCode { get; init; }
    }
}