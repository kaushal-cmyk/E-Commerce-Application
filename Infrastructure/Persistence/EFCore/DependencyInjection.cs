using DefaultNamespace;
using DefaultNamespace.Abstractions;
using ECommerce.Infrastructure.Persistance.EFCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.Persistance.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructurePersistenceDependencies(
        this IServiceCollection services, string? connectionString)
    {
        services.AddBaseInfrastructurePersistenceDependencies();

        if (!string.IsNullOrWhiteSpace(connectionString))
            services.AddEcomDbContext(connectionString);

        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddEcomDbContext(
        this IServiceCollection services, string connectionString)
    {
        services.AddScoped<DbContext, EcomDBContext>()
            .AddScoped(sp => sp.GetRequiredService<IDbContextFactory<EcomDBContext>>().CreateDbContext())
            .AddScoped<IDbContextFactory<DbContext>, ApplicationDbContextFactory<DbContext, EcomDBContext>>()
            .AddDbContextFactory<EcomDBContext>((sp, options) =>
            {
                options.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString)
                    .AddInterceptors(sp.GetRequiredService<AuditInterceptor>());
            }, lifetime: ServiceLifetime.Scoped);

        return services;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}