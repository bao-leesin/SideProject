using Data.Repositories;
using Data.Repositories.Entities;
using Data.Repositories.Interface;
using Data.Repositories.Interface.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Data.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            return services;
        }
    }
}
