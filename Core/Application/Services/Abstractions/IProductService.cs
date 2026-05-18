
using ECommerce.Core.Application.Dtos;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto?> GetProduct(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> CreateAsync(CreateProductDto request);
        Task<ProductDto> UpdateAsync(UpdateProductDto request);
        Task DeleteAsync(Guid id);

    }
}
