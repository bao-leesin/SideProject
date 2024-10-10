using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;


namespace Service.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
