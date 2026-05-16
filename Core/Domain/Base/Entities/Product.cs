using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities;

public class Product : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties 

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? LongDescription { get; private set; }
    public bool IsActive { get; private set; }
    public decimal Price { get; private set; }
    public Guid BrandId { get; private set; }

    #endregion

    #region Constructors

#nullable disable
    protected Product() { }
#nullable enable

    private Product(
        string title,
        string? shortDescription,
        string? longDescription,
        decimal price,
        Guid brandId)
    {
        //Id = Guid.NewGuid();
        Title = title;
        Slug = GenerateSlug(title);
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Price = price;
        BrandId = brandId;
        IsActive = true;
    }

    #endregion

    #region Actions and Behaviours

    public static Product Create(
        string title,
        string? shortDescription,
        string? longDescription,
        decimal price,
        Guid brandId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        return new Product(title, shortDescription, longDescription, price, brandId);
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void ChangePrice(decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        Price = price;
    }

    public void UpdateDetails(string title, string? shortDescription, string? longDescription)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        Title = title;
        Slug = GenerateSlug(title);
        ShortDescription = shortDescription;
        LongDescription = longDescription;
    }

    private static string GenerateSlug(string title)
    {
        return title.ToLower().Replace(" ", "-");
    }

    #endregion

}