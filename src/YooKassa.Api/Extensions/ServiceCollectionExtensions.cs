using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YooKassa.Api.Handlers;
using YooKassa.Api.Options;
using YooKassa.Api.Services;

namespace YooKassa.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services, IConfigurationSection section) => services
            .Configure<YooKassaOptions>(section.GetSection("Options"))
            .AddTransient<YouKassaClientMessageHandler>()
            .AddHttpClient<YouKassaClient>((_, c) =>  c.BaseAddress = new(section.GetValue<string>("Url"), UriKind.Absolute))
            .AddHttpMessageHandler<YouKassaClientMessageHandler>()
            .Services;
    }
}
