
namespace ECommerce.Core.Domain.Common
{
    public abstract class FullAuditedAggregateRoot<TKey> : AuditedEntity<TKey> where TKey : notnull
    {
        public bool IsDeleted { get; set; }
    }
}
