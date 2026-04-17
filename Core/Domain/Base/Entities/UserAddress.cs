using System.Reflection.Metadata.Ecma335;

namespace E_commerce.Core.Domain.Entities;

public class UserAddress
{
    #region Fields and Properties

    public Guid? Id { get; set; }
    public string? UserId { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }
    
    #endregion
}