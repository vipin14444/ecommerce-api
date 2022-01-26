using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Services;

namespace Ecommerce.WebHost
{
    public static class ServiceInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}