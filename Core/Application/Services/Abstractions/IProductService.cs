
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<Result<ProductDto>> GetProduct(Guid id);
        Task<Result<IEnumerable<ProductDto>>> GetAllProducts();
        Task<Result<ProductDto>> CreateProduct(CreateProductDto request);
        Task<Result<ProductDto>> UpdateProduct(UpdateProductDto request);
        Task<Result> DeleteProduct(Guid id);
    }
}
