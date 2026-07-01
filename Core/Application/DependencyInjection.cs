
using ECommerce.Core.Application.Mapping;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());

            return services;
        }
    }
}
