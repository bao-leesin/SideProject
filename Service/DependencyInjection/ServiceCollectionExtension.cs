using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;


namespace Service.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IMediaService, MediaService>(); 
            return services;
        }
    }
}
