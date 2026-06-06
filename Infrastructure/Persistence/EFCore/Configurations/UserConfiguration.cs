
using ECommerce.Core.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsVerified)
                .HasDefaultValue(false);

            // audit fields — match your existing pattern
            builder.Property(x => x.CreatedBy).HasMaxLength(256);
            builder.Property(x => x.CreatedOn);
            builder.Property(x => x.UpdatedBy).HasMaxLength(256);
            builder.Property(x => x.UpdatedOn);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            // indexes
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.StoreId);

            // relationship
            builder.HasMany<RefreshToken>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
