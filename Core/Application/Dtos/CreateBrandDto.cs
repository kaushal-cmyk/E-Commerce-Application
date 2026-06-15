
namespace ECommerce.Core.Application.Dtos
{
    public sealed record CreateBrandDto
    {
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
    }
}
