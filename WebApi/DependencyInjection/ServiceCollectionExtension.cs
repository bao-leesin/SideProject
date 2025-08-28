using Microsoft.Extensions.Configuration;
using WebAPI.HealthChecks;

namespace WebAPI.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomHealthChecks(
                          this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<ApplicationHealthCheck>("Application Health Check", tags: new[] { "application" });
            builder.AddSqlServer(
               connectionString: configuration.GetConnectionString("DefaultConnection"),
               healthQuery: "SELECT 1", // Lightweight query  
               failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
               tags: new[] { "database", "sqlserver" });
            return services;
        }
    }
}
