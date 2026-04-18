using REPL.Base.Core.Domain.Primitives.Models;

namespace E_commerce.Core.Domain.Entities;

public class Order : FullAuditedAggregateRoot<Guid>
{
    #region Fields and Properties

    public string? OrderStatus { get; set; }
    public string? PaymentStatus { get; set; }
    public decimal? TotalAmount { get; set; }
    public Guid? UserId { get; set; }
    
    #endregion

    #region Constructors

    

    #endregion

    #region Actions and Behaviors

    

    #endregion
}