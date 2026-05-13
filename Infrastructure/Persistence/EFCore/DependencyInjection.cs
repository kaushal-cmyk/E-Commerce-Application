using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.Persistance.EFCore;

public static class DependencyInjection
{
    public static readonly Assembly EFCoreAssemblyReference = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EcomDBContext>(options =>
            options.UseSqlServer(connectionString));

        // services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}