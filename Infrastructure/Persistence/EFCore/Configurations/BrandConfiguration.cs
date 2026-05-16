
using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistance.EFCore.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(b => b.LogoUrl)
                   .HasMaxLength(1024);

            builder.Property(b => b.IsActive)
                   .HasDefaultValue(true);

            builder.Property(b => b.IsDeleted)
                   .HasDefaultValue(false);

            builder.OwnsOne(b => b.Created, a =>
            {
                a.Property(x => x.By).HasColumnName("CreatedBy").HasMaxLength(256);
                a.Property(x => x.On).HasColumnName("CreatedOn");
            });

            builder.OwnsOne(b => b.Updated, a =>
            {
                a.Property(x => x.By).HasColumnName("UpdatedBy").HasMaxLength(256);
                a.Property(x => x.On).HasColumnName("UpdatedOn");
            });
        }
    }
}
