using ECommerce.Core.Domain.POCOs;

namespace ECommerce.Core.Domain.Errors
{
    public static class RuntimeErrors
    {
        public static readonly Error NullEntity = new Error("Null", "Entity Cannot Be Null");
    }
}
