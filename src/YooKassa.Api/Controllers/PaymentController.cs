using System.ComponentModel.DataAnnotations;
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
        ///     Создать платёж на базе одноразового токена оплаты
        /// </summary>
        /// <param name="data">Исходные данные для создания платежа</param>
        /// <param name="idempotenceKey">Ключ идемпотентности</param>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePaymentByTokenAsync(NewPaymentByTokenData data, string idempotenceKey, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(data, idempotenceKey, ct);

            return result.Error is null
                ? Json(result.Result?.Confirmation?.ConfirmationUrl ?? "")
                : BadRequest(result.Error);
        }

        /// <summary>
        ///     Быстро cоздать платёж на базе одноразового токена оплаты.
        /// </summary>
        /// <remarks>
        ///     Может не сработать
        /// </remarks>
        /// <param name="paymentToken">Одноразовый токен для проведения оплаты</param>
        /// <param name="price">Сумма платежа</param>
        /// <param name="idempotenceKey">Ключ идемпотентности</param>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [Route("fast")]
        public async Task<IActionResult> CreatePaymentByTokenAsync(
            [Required] string paymentToken,
            [Required] decimal price,
            string idempotenceKey, CancellationToken ct)
        {
            NewPaymentByTokenData data = new()
            {
                Amount = new() { Value = price.ToString() },
                PaymentToken = paymentToken,
                Confirmation = new() { Type = "redirect", ReturnUrl = "https://yookassaapi-test.azurewebsites.net/confirm" },
                Description = "Test fast token payment",
                Metadata = new() { Id = 1, Name = "Super-Vlad" }
            };

            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(data, idempotenceKey, ct);

            return result.Error is null
                ? Json(result.Result?.Confirmation?.ConfirmationUrl ?? "")
                : BadRequest(result.Error);
        }
    }
}
