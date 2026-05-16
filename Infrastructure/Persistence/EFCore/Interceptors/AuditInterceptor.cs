
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistance.EFCore.Interceptors
{
    public sealed class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public AuditInterceptor(ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService ?? throw new ArgumentNullException(nameof(loggedInUserService));
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is not null)
                AuditEntries(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (eventData.Context != null)
            {
                AuditEntries(eventData.Context);
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void AuditEntries(DbContext context)
        {
            var now = DateTimeOffset.UtcNow;
            var user = _loggedInUserService.GetCurrentUserIdentity() ?? "System";

            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    TrySetProperty(entry, "Created", now);
                    TrySetProperty(entry, "CreatedBy", user);
                }

                if (entry.State == EntityState.Modified)
                {
                    TrySetProperty(entry, "Updated", now);
                    TrySetProperty(entry, "UpdatedBy", user);
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    TrySetProperty(entry, "IsDeleted", true);
                    TrySetProperty(entry, "Updated", now);
                    TrySetProperty(entry, "UpdatedBy", user);
                }
            }
        }

        private static void TrySetProperty(EntityEntry entry, string propertyName, object? value)
        {
            var property = entry.Properties.FirstOrDefault(p => p.Metadata.Name == propertyName);

            if (property != null)
            {
                property.CurrentValue = value;
            }
        }
    }
}
