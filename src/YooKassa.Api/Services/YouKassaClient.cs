using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

        public async Task<Payments> GetPaymentsAsync(CancellationToken ct = default)
        {
            HttpRequestMessage request = CreateRequest("payments", HttpMethod.Get);

            using HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
            var s = await response.Content.ReadFromJsonAsync<Payments>(CustomJsonOptions.JsonSerializerOptions, ct);

            return s;
        }

        private static HttpRequestMessage CreateRequest(string method, HttpMethod httpMethod)
        {
            return new HttpRequestMessage(httpMethod, method);
        }
    }
}
