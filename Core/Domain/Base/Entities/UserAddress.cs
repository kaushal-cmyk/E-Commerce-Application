using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities;

public class UserAddress : BaseEntity<Guid>
{
    #region Fields and Properties

    public string UserId { get; private set; }
    public string FullName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string? State { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }
    public bool IsDefault { get; private set; }

    #endregion

    #region Constructors

#nullable disable
    protected UserAddress() { }
#nullable enable

    private UserAddress(
        string userId,
        string fullName,
        string phoneNumber,
        string street,
        string city,
        string? state,
        string country,
        string postalCode)
    {
        UserId = userId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        IsDefault = false;
    }

    #endregion

    #region Actions and Behaviours

    public static UserAddress Create(
        string userId,
        string fullName,
        string phoneNumber,
        string street,
        string city,
        string? state,
        string country,
        string postalCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userId);
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);
        ArgumentException.ThrowIfNullOrWhiteSpace(postalCode);

        return new UserAddress(userId, fullName, phoneNumber, street, city, state, country, postalCode);
    }

    public void SetAsDefault() => IsDefault = true;

    public void UnsetDefault() => IsDefault = false;

    public void UpdateDetails(
        string fullName,
        string phoneNumber,
        string street,
        string city,
        string? state,
        string country,
        string postalCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);
        ArgumentException.ThrowIfNullOrWhiteSpace(postalCode);

        FullName = fullName;
        PhoneNumber = phoneNumber;
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
    }

    #endregion
}