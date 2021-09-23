namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Товаров в заказе
    /// </summary>
    public class ReceiptItem
    {
        /// <summary>
        ///     Название товара
        /// </summary>
        /// <remarks>
        ///     Не более 128 символов
        /// </remarks>
        public string Description { get; init; }

        /// <summary>
        ///     Количество товара
        /// </summary>
        /// <remarks>
        ///     Максимально возможное значение зависит от модели вашей онлайн-кассы
        /// </remarks>
        public decimal Quantity { get; init; }

        /// <summary>
        ///     Цена товара
        /// </summary>
        public Amount Amount { get; init; }

        /// <summary>
        ///     Ставка НДС
        /// </summary>
        public VatCode VatCode { get; init; }

        /// <summary>
        ///     Признак предмета расчета
        /// </summary>
        public string PaymentSubject { get; init; } // TODO: Сделать enum https://yookassa.ru/developers/54fz/parameters-values#payment-subject

        /// <summary>
        ///     Признак способа расчета
        /// </summary>
        public string PaymentMode { get; init; } // TODO: Сделать enum https://yookassa.ru/developers/54fz/parameters-values#payment-mode

        /// <summary>
        ///     Код товара - уникальный номер, который присваивается экземпляру товара при <see href="https://docs.cntd.ru/document/902192509">маркировке</see>
        /// </summary>
        /// <remarks>
        ///     Формат: число в шестнадцатеричном представлении с пробелами.
        ///     <br/>
        ///     Максимальная длина - 32 байта.
        ///     <br/>
        ///     Пример: 00 00 00 01 00 21 FA 41 00 23 05 41 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 12 00 AB 00.
        ///     <br/>
        ///     Обязательный параметр, если товар нужно <see href="https://docs.cntd.ru/document/557297080">маркировать</see>
        /// </remarks>
        public string ProductCode { get; init; }

        /// <summary>
        ///     Код страны происхождения товара по общероссийскому классификатору стран мира
        /// </summary>
        /// <remarks>
        ///     Пример: RU.
        ///     <br/>
        ///     Онлайн-кассы, которые поддерживают этот параметр: Orange Data, Кит Инвест.
        /// </remarks>
        public string CountryOfOriginCode { get; init; }

        /// <summary>
        ///     Номер таможенной декларации (от 1 до 32 символов).
        /// </summary>
        /// <remarks>
        ///     Онлайн-кассы, которые поддерживают этот параметр: Orange Data, Кит Инвест.
        /// </remarks>
        public string CustomsDeclarationNumber { get; init; }

        /// <summary>
        ///     Сумма акциза товара с учетом копеек
        /// </summary>
        /// <remarks>
        ///     Десятичное число с точностью до 2 символов после точки.
        ///     <br/>
        ///     Онлайн-кассы, которые поддерживают этот параметр: Orange Data, Кит Инвест.
        /// </remarks>
        public string Excise { get; init; }
    }
}