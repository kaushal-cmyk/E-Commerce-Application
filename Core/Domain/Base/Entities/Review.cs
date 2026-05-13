using System.Reflection.Metadata.Ecma335;
using REPL.Base.Core.Domain.Primitives.Models;

namespace ECommerce.Core.Domain.Entities;

public class Review : AuditedAggregateRoot<Guid>
{
    #region Fields and Properties

    public int? Rating { get; private set; }
    public string? Comment { get; private set; }
    public bool? IsApproved { get; private set; }
    public Guid? UserId { get; private set; }
    public Guid ProductId { get; private set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviorss

    

    #endregion
}