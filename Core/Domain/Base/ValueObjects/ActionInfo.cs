
namespace ECommerce.Core.Domain.ValueObjects
{
    public record ActionInfo
    {
        public string By { get; init; }
        public DateTimeOffset On { get; init; }

        public ActionInfo(string by, DateTimeOffset on)
        {
            By = by;
            On = on;
        }
        public static readonly ActionInfo Empty = new ActionInfo(string.Empty, DateTimeOffset.MinValue);
    }
}
