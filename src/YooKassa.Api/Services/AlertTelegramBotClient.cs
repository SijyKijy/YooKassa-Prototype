using System.Net.Http;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using YooKassa.Api.Options;

namespace YooKassa.Api.Services
{
    public class AlertTelegramBotClient : TelegramBotClient
    {
        public AlertTelegramBotClient(IOptions<TelegramBotOptions> options, HttpClient httpClient)
            : base(options.Value.Token, httpClient) { }
    }
}