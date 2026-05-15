using System.Reflection;
using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;
using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Implementations;
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

        services.AddScoped<DbContext>(sp =>
            sp.GetRequiredService<EcomDBContext>());


        // services.AddScoped<IProductRepository, ProductRepository>();
        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }


}