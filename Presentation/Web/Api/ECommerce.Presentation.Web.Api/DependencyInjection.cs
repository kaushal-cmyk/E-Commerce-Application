using ECommerce.Core.Application.Mapping;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Application.Services.Implementations;

namespace ECommerce.Presentation.Web.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());

            return services;
        }
    }
}
