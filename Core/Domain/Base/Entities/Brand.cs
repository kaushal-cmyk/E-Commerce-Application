using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class Brand : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties 

    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public string? LogoUrl { get; set; }

    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}