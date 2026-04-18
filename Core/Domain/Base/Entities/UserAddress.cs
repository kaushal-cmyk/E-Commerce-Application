using System.Reflection.Metadata.Ecma335;
using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class UserAddress : Entity<Guid>
{
    #region Fields and Properties

    public string? UserId { get; private set; }
    public string? FullName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? Country { get; private set; }
    public string? PostalCode { get; private set; }
    public bool IsDefault { get; private set; }
    
    #endregion
}