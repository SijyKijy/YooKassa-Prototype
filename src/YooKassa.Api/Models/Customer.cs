namespace YooKassa.Api.Models
{
    /// <summary>
    ///     Информация о пользователе
    /// </summary>
    public class Customer
    {
        /// <summary>
        ///     Для юрлица - название организации, для ИП и физического лица - ФИО
        /// </summary>
        /// <remarks>
        ///     Если у физлица отсутствует ИНН, в этом же параметре передаются паспортные данные. Не более 256 символов.
        ///     <br/>
        ///     Онлайн-кассы, которые поддерживают этот параметр: Orange Data, АТОЛ Онлайн
        /// </remarks>
        public string FullName { get; init; }

        /// <summary>
        ///     ИНН пользователя (10 или 12 цифр)
        /// </summary>
        /// <remarks>
        ///     Если у физического лица отсутствует ИНН, необходимо передать паспортные данные в параметре <see cref="FullName"/>.
        ///     <br/>
        ///     Онлайн-кассы, которые поддерживают этот параметр: Orange Data, АТОЛ Онлайн
        /// </remarks>
        public string Inn { get; init; }

        /// <summary>
        ///     Электронная почта пользователя для отправки чека
        /// </summary>
        /// <remarks>
        ///     Обязательный параметр, если не передан <see cref="Phone"/>
        /// </remarks>
        public string Email { get; init; }

        /// <summary>
        ///     Телефон пользователя для отправки чека
        /// </summary>
        /// <remarks>
        ///     Указывается в формате ITU-T E.164, например 79000000000
        ///     <br/>
        ///     Обязательный параметр, если не передан <see cref="Email"/>
        /// </remarks>
        public string Phone { get; init; }
    }
}