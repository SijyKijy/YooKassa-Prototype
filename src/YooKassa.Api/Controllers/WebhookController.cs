using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using YooKassa.Api.Models;
using YooKassa.Api.Options;

namespace YooKassa.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class WebhookController : BaseController
    {
        private readonly ITelegramBotClient _telegramBot;

        public WebhookController(ITelegramBotClient telegramBot)
        {
            _telegramBot = telegramBot ?? throw new ArgumentNullException(nameof(telegramBot));
        }

        [HttpPost]
        public async Task<IActionResult> GetNotifications([FromServices] IOptions<TelegramBotOptions> options, Notification notification)
        {
            if (notification is null)
                return BadRequest();

            string chatId = options.Value.ChatId;
            string payload = notification.Payload?.ToString() ?? "";

            await (notification.EventType switch
            {
                "payment.succeeded" => _telegramBot.SendTextMessageAsync(chatId, $"Платеж успешно завершен\nPayload:```json {payload}```", ParseMode.Markdown),
                "payment.waiting_for_capture" => _telegramBot.SendTextMessageAsync(chatId, $"Платеж оплачен, деньги авторизованы и ожидают списания\nPayload:```json {payload}```", ParseMode.Markdown),
                "payment.canceled" => _telegramBot.SendTextMessageAsync(chatId, $"Платеж отменен\nPayload:```json {payload}```", ParseMode.Markdown),
                "refund.succeeded" => _telegramBot.SendTextMessageAsync(chatId, $"Возврат успешно завершен\nPayload:```json {payload}```", ParseMode.Markdown),
                _ => _telegramBot.SendTextMessageAsync(chatId, "Неизвестно")
            });

            return Ok();
        }
    }
}