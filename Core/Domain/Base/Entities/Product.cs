using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities;

public class Product : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties 

    public string? Title { get; private set; }
    public string? Slug { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? LongDescription { get; private set; }
    public bool? IsActive { get; private set; }
    public Guid BrandId { get; private set; }

    #endregion

    #region Constructors

    #endregion

    #region Actions and Behaviours



    #endregion

}