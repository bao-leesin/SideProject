using Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class DIConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<RabbitMqConsumerService>();
        }
    }
}
