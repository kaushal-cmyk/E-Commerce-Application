namespace ECommerce.Core.Application.DTOs.UserAddress;

public sealed record UserAddressDto(
    Guid Id,
    string FullName,
    string PhoneNumber,
    string Street,
    string City,
    string? State,
    string Country,
    string PostalCode,
    bool IsDefault
);

public sealed record CreateUserAddressDto(
    string UserId,
    string FullName,
    string PhoneNumber,
    string Street,
    string City,
    string? State,
    string Country,
    string PostalCode
);

public sealed record UpdateUserAddressDto(
    string FullName,
    string PhoneNumber,
    string Street,
    string City,
    string? State,
    string Country,
    string PostalCode
);