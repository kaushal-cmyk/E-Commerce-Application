namespace E_commerce.Core.Domain.Entities;

public class Product
{
    #region Fields and Properties 
    
    public string? Title { get; private set; }
    public string? Slug { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? LongDescription { get; private set; }
    public string? BrandId { get; set; }
    public bool? IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; private set; }
    #endregion

    #region Constructors

    #endregion

    #region Actions and Behaviours
    
    

    #endregion
    
}