
namespace ECommerce.Core.Domain.Common
{
    public abstract class FullAuditedAggregateRoot
    {
        public bool IsDeleted { get; set; }
    }
}
