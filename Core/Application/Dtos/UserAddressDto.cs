namespace ECommerce.Core.Application.DTOs.UserAddress;

public record UserAddressDto(
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

public record CreateUserAddressDto(
    string UserId,
    string FullName,
    string PhoneNumber,
    string Street,
    string City,
    string? State,
    string Country,
    string PostalCode
);

public record UpdateUserAddressDto(
    string FullName,
    string PhoneNumber,
    string Street,
    string City,
    string? State,
    string Country,
    string PostalCode
);