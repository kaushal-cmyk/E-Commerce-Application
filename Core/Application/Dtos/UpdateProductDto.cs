
namespace ECommerce.Core.Application.Dtos
{
    public class UpdateProductDto
    {
        public string Title { get; init; }
        public string? ShortDescription { get; init; }
        public string? LongDescription { get; init; }
        public decimal Price { get; init; }
    }
}
