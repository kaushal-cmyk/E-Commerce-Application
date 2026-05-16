using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities;

public class Brand : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties 

    public string? Name { get; private set; }
    public bool? IsActive { get; private set; }
    public string? LogoUrl { get; private set; }

    #endregion

    #region Constructors

#nullable disable

    protected Brand() { }
#nullable enable

    private Brand(string name, string? logoUrl)
    {
        Name = name;
        LogoUrl = logoUrl;
        IsActive = true;
    }

    #endregion

    #region Actions and Behaviorss

    public static Brand Create(string name, string? logoUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return new Brand(name, logoUrl);
    }

    #endregion
}