
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<Result<ProductDto>> GetProduct(Guid id, CancellationToken ct = default);
        Task<Result<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken ct = default);
        Task<Result<ProductDto>> CreateProduct(CreateProductDto request, CancellationToken ct = default);
        Task<Result<ProductDto>> UpdateProduct(UpdateProductDto request, CancellationToken ct = default);
        Task<Result> DeleteProduct(Guid id, CancellationToken ct = default);
    }
}
