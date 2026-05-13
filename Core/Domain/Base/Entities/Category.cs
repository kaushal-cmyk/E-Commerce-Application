using REPL.Base.Core.Domain.Primitives.Models;

namespace ECommerce.Core.Domain.Entities;

public class Category : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties
    
    public string? Name { get; private set; }
    public string? Slug { get; private set; }
    public Guid? ParentCategoryId { get; private set; }
    public bool? IsActive { get; private set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}