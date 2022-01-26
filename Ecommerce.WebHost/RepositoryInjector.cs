using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Repositories;

namespace Ecommerce.WebHost
{
    public static class RepositoryInjector
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IDapperContext, DapperContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}