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
        [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePaymentByTokenAsync([Required] CreatePaymentData data,
            string idempotenceKey, CancellationToken ct)
        {
            NewPaymentByTokenData newPaymentData = new()
            {
                Amount = new() { Value = data.Price },
                PaymentToken = data.PaymentToken,
                Confirmation = new() { Type = "redirect", ReturnUrl = "https://yookassaapi-test.azurewebsites.net/confirm" },
                Description = data.Description ?? "Test fast token payment",
                Metadata = new() { Id = 1, Name = "User name" }
            };

            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(newPaymentData, idempotenceKey, ct);

            return result.Error is null
                ? Json(new PaymentResponse() { Url = result.Result?.Confirmation?.ConfirmationUrl ?? "" })
                : BadRequest(result.Error);
        }

        /// <summary>
        ///     Создать платёж на базе одноразового токена оплаты
        /// </summary>
        /// <remarks>
        ///     Для тестов!
        /// </remarks>
        /// <param name="data">Исходные данные для создания платежа</param>
        /// <param name="idempotenceKey">Ключ идемпотентности</param>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [Route("detail")]
        public async Task<IActionResult> CreatePaymentByTokenAsync(NewPaymentByTokenData data, string idempotenceKey, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(data, idempotenceKey, ct);

            return result.Error is null
                ? Json(new PaymentResponse() { Url = result.Result?.Confirmation?.ConfirmationUrl ?? "" })
                : BadRequest(result.Error);
        }
    }
}
