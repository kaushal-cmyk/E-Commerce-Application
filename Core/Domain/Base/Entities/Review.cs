using System.Reflection.Metadata.Ecma335;
using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class Review : AuditedAggregateRoot<Guid>
{
    #region Fields and Properties

    public int? Rating { get; set; }
    public string? Comment { get; set; }
    public bool? IsApproved { get; set; }
    public Guid? UserId { get; set; }
    public Guid ProductId { get; set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}