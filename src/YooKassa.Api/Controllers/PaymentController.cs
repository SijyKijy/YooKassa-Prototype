using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YooKassa.Api.Models;
using YooKassa.Api.Services;

namespace YooKassa.Api.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly YouKassaClient _apiClient;

        public PaymentController(YouKassaClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        ///     Получить список платежей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Payments), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPaymentsAsync(CancellationToken ct)
        {
            ResponseData<Payments> result = await _apiClient.GetPaymentsAsync(ct);

            return result.Error is null
                ? Json(result.Result)
                : BadRequest(result.Error);
        }

        /// <summary>
        ///     Получить платёж
        /// </summary>
        /// <param name="paymentId">Уникальный идентификатор платежа</param>
        [HttpGet]
        [Route("{paymentId}")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPaymentAsync(string paymentId, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.GetPaymentAsync(paymentId, ct);

            return result.Error is null
                ? Json(result.Result)
                : BadRequest(result.Error);
        }

        /// <summary>
        ///     Создать платёж
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "amount": {
        ///             "value": "100.00",
        ///             "currency": "RUB"
        ///         },
        ///         "confirmation": {
        ///             "type": "redirect",
        ///             "returnUrl": "https://www.google.com/"
        ///         },
        ///         "description": "Заказ №1",
        ///         "receipt": {
        ///             "customer": {
        ///                 "email": "testmail@mail.com",
        ///                 "phone": "+71234567890"
        ///             },
        ///             "items": [
        ///                 {
        ///                     "description": "TestItem1",
        ///                     "quantity": "1",
        ///                     "amount": {
        ///                         "value": "2.00",
        ///                         "currency": "RUB"
        ///                     },
        ///                     "vat_code": 1
        ///                 }
        ///             ]
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="data">Исходные данные для создания платежа</param>
        /// <param name="idempotenceKey">Ключ идемпотентности</param>
        [HttpPost]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePaymentAsync(NewPaymentData data, string idempotenceKey, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(data, idempotenceKey, ct);

            return result.Error is null
                ? Json(result.Result)
                : BadRequest(result.Error);
        }
    }
}
