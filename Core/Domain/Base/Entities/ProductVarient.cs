namespace E_commerce.Core.Domain.Entities;

public class ProductVarient
{
    #region Fields and Properties

    public string? StockKeepingUnit { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int StockQuantity { get; set; }
    public bool? IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    #endregion

    #region Constructors

    #endregion

    #region Actions and Behaviours



    #endregion}
}