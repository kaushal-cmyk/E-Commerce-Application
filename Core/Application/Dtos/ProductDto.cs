
namespace ECommerce.Core.Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Slug { get; init; }
        public string? ShortDescription { get; init; }
        public string? LongDescription { get; init; }
        public decimal Price { get; init; }
        public bool IsActive { get; init; }
        public Guid BrandId { get; init; }
        public DateTimeOffset? CreatedOn { get; init; }
        public string? CreatedBy { get; init; }
    }
}
