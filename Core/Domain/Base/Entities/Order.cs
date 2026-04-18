using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class Order : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties

    public string? OrderStatus { get; private set; }
    public string? PaymentStatus { get; private set; }
    public decimal? TotalAmount { get;private set; }
    public Guid? UserId { get;private set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviors

    

    #endregion
}