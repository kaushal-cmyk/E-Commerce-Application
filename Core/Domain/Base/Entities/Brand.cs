using REPL.Base.Core.Domain.Primitives.Models;

namespace ECommerce.Core.Domain.Entities;

public class Brand : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties 

    public string? Name { get; private set; }
    public bool? IsActive { get; private set; }
    public string? LogoUrl { get;private set; }

    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}