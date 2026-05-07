using ECommerce.Infrastructure.Persistance.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistance.EFCore;

public class EcomDBContext(DbContextOptions<EcomDBContext> options) : DbContext(options)
{
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(DependencyInjection.EFCoreAssemblyReference);
    }
}  