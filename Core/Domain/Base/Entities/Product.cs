namespace E_commerce.Core.Domain.Entities;

public class Product
{
    #region Fields and Properties 
    
    public string? Title { get; private set; }
    public string? Slug { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? LongDescription { get; private set; }
    public decimal BasePrice { get; private set; }
    public string? StockKeepingUnit { get; private set; }
    public decimal DiscountedPrice { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    #endregion

    #region Constructors

    #endregion

    #region Actions and Behaviours
    
    

    #endregion
    
}