using Microsoft.Extensions.DependencyInjection;

namespace Data.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
