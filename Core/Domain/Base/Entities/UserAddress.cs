using System.Reflection.Metadata.Ecma335;
using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class UserAddress : Entity<Guid>
{
    #region Fields and Properties

    public string? UserId { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public bool IsDefault { get; set; }
    
    #endregion
}