using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Models;
using Ecommerce.Services;

namespace Ecommerce.WebHost
{
    public static class MappingInjector
    {
        public static void InjectMappings(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new MapperConfiguration(x => x.AddProfile(new MappingProfile())).CreateMapper());
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}