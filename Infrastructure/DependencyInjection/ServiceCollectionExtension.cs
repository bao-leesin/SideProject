using Domain.Messaging;
using Domain.Storage;
using Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, RabbitMqPublisher>();
            services.AddSingleton<IStorageService, MinioStorageService>();
            return services;
        }
    }
}
