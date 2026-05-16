using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistance.EFCore;

public class EcomDBContext(DbContextOptions<EcomDBContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }

    //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    //{
    //    // public DbSet<Product> Products { get; set; }

    //    base.ConfigureConventions(configurationBuilder);

    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(DependencyInjection.EFCoreAssemblyReference);
    }
}