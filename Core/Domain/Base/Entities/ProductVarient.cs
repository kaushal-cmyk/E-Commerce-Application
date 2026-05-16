using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities;

public class ProductVarient : BaseEntity<Guid>
{
    #region Fields and Properties

    public string? StockKeepingUnit { get; private set; }
    public decimal Price { get; private set; }
    public decimal DiscountedPrice { get; private set; }
    public int StockQuantity { get; private set; }
    public bool? IsActive { get; private set; }

    public Guid ProductId { get; private set; }
    #endregion

    #region Constructors

    #endregion

    #region Actions and Behaviours



    #endregion}
}