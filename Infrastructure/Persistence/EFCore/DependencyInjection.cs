using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Options;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Application.Services.Implementations;
using ECommerce.Infrastructure.Persistence.EFCore.Authentication;
using ECommerce.Infrastructure.Persistence.EFCore.Interceptors;
using ECommerce.Infrastructure.Persistence.EFCore.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.EFCore;

public static class DependencyInjection
{
    public static readonly Assembly EFCoreAssemblyReference = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string? connectionString,
         IConfiguration configuration)
    {
        services.AddScoped<AuditInterceptor>();
        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            services.AddDbContext<EcomDBContext>((sp, options) => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<AuditInterceptor>()));

            services.AddScoped<DbContext>(sp =>
                sp.GetRequiredService<EcomDBContext>());
        }


        // services.AddScoped<IProductRepository, ProductRepository>();
        services.AddRepositories();
        services.AddAuthenticationServices(configuration);
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));
        services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandRepository<,>));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    private static IServiceCollection AddAuthenticationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(
            configuration.GetSection("JwtSettings"));

        services.AddScoped<IHasher, Hasher>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ILoggedInUserService, LoggedInUserService>();

        services.AddHttpContextAccessor();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),

                    ValidateIssuer = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["JwtSettings:Audience"],

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
}