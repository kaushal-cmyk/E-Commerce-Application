
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<Result<ProductDto>> GetProduct(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> CreateProduct(CreateProductDto request);
        Task<ProductDto> UpdateProduct(UpdateProductDto request);
        Task DeleteProduct(Guid id);
    }
}
