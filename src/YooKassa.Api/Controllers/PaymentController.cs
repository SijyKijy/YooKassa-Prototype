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
            Payments payments = await _apiClient.GetPaymentsAsync(ct);
            return Json(payments);
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<IActionResult> GetPaymentAsync(string paymentId, CancellationToken ct)
        {
            Payment payments = await _apiClient.GetPaymentAsync(paymentId, ct);
            return Json(payments);
        }
    }
}
