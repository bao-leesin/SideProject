using Microsoft.Extensions.DependencyInjection;


namespace Service.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
