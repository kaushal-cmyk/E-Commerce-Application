using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class Category : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties
    
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public bool? IsActive { get; set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}