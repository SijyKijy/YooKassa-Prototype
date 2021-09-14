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

        [HttpGet]
        public async Task<IActionResult> GetPaymentsAsync(CancellationToken ct)
        {
            ResponseData<Payments> result = await _apiClient.GetPaymentsAsync(ct);

            return result.Error is null
                ? Json(result.Result)
                : Json(result.Error);
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<IActionResult> GetPaymentAsync(string paymentId, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.GetPaymentAsync(paymentId, ct);

            return result.Error is null
                ? Json(result.Result)
                : Json(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentAsync(NewPaymentData data, string idempotenceKey, CancellationToken ct)
        {
            ResponseData<Payment> result = await _apiClient.CreatePaymentAsync(data, idempotenceKey, ct);

            return result.Error is null
                ? Json(result.Result)
                : Json(result.Error);
        }
    }
}
