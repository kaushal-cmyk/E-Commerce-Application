
using ECommerce.Core.Application.Dtos;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> CreateAsync(CreateProductDto request);
        Task<ProductDto> UpdateAsync(UpdateProductDto request);
        Task DeleteAsync(Guid id);

    }
}
