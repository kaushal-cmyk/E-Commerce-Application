
namespace ECommerce.Core.Domain.ValueObjects
{
    public class ActionInfo
    {
        public string By { get; init; }
        public DateTimeOffset On { get; init; }

        public ActionInfo(string by, DateTimeOffset on)
        {
            By = by;
            On = on;
        }
    }
}
