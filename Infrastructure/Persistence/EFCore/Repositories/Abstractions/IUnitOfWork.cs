#nullable enable

namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface IUnitOfWork : IDisposable
{
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();
}