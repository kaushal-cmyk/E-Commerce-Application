
using ECommerce.Core.Application.Dtos;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto?> GetProduct(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> CreateProduct(CreateProductDto request);
        Task<ProductDto> UpdateProduct(UpdateProductDto request);
        Task DeleteProduct(Guid id);
    }
}
