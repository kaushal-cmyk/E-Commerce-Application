
using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistance.EFCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(512);

            builder.Property(p => p.LongDescription)
                .HasMaxLength(4000);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(p => p.Slug).IsUnique();
            builder.HasIndex(p => p.BrandId);

            builder.HasOne<Brand>()
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(p => p.Created, a =>
            {
                a.Property(x => x.By).HasColumnName("CreatedBy").HasMaxLength(256);
                a.Property(x => x.On).HasColumnName("CreatedOn");
            });

            builder.OwnsOne(p => p.Updated, a =>
            {
                a.Property(x => x.By).HasColumnName("UpdatedBy").HasMaxLength(256);
                a.Property(x => x.On).HasColumnName("UpdatedOn");
            });

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
