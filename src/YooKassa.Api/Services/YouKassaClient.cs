using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using YooKassa.Api.Models;
using YooKassa.Api.Options;

namespace YooKassa.Api.Services
{
    public class YouKassaClient
    {
        private readonly ILogger<YouKassaClient> _logger;
        private readonly HttpClient _client;

        public YouKassaClient(ILogger<YouKassaClient> logger, HttpClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ResponseData<Payments>> GetPaymentsAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Получение списка платежей");

            using HttpRequestMessage request = CreateRequest("payments", HttpMethod.Get);
            using HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            return response.IsSuccessStatusCode
                ? new() { Result = await response.Content.ReadFromJsonAsync<Payments>(CustomJsonOptions.JsonSerializerOptions, ct) }
                : new() { Error = await response.Content.ReadFromJsonAsync<Error>(CustomJsonOptions.JsonSerializerOptions, ct) };
        }

        public async Task<ResponseData<Payment>> GetPaymentAsync(string paymentId, CancellationToken ct = default)
        {
            _logger.LogInformation("Получение платежа {paymentId}", paymentId);

            using HttpRequestMessage request = CreateRequest($"payments/{paymentId}", HttpMethod.Get);
            using HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            return response.IsSuccessStatusCode
                ? new() { Result = await response.Content.ReadFromJsonAsync<Payment>(CustomJsonOptions.JsonSerializerOptions, ct) }
                : new() { Error = await response.Content.ReadFromJsonAsync<Error>(CustomJsonOptions.JsonSerializerOptions, ct) };
        }

        public async Task<ResponseData<Payment>> CreatePaymentAsync(NewPaymentData data, string idempotenceKey = null, CancellationToken ct = default)
        {
            _logger.LogInformation("Создание платежа {idempotenceKey}", idempotenceKey);

            using HttpRequestMessage request = CreateRequest("payments", HttpMethod.Post);

            request.Headers.Add("Idempotence-Key", idempotenceKey ?? Guid.NewGuid().ToString());
            request.Content = JsonContent.Create(data, options: CustomJsonOptions.JsonSerializerOptions);

            using HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            return response.IsSuccessStatusCode
                ? new() { Result = await response.Content.ReadFromJsonAsync<Payment>(CustomJsonOptions.JsonSerializerOptions, ct) }
                : new() { Error = await response.Content.ReadFromJsonAsync<Error>(CustomJsonOptions.JsonSerializerOptions, ct) };
        }

        private static HttpRequestMessage CreateRequest(string method, HttpMethod httpMethod) => new(httpMethod, method);
    }
}
