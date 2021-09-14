using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YooKassa.Api.Options;

namespace YooKassa.Api.Handlers
{
    public class YouKassaClientMessageHandler : DelegatingHandler
    {
        private readonly ILogger<YouKassaClientMessageHandler> _logger;
        private readonly YooKassaOptions _options;

        public YouKassaClientMessageHandler(ILogger<YouKassaClientMessageHandler> logger, IOptions<YooKassaOptions> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options?.Value;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Version = System.Net.HttpVersion.Version20;
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(_options.StoreId + ':' + _options.SecretKey)));

            return base.SendAsync(request, cancellationToken);
        }
    }
}
