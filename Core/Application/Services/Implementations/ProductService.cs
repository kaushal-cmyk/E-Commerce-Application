
using AutoMapper;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.Errors;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Brand, Guid> _brandRepository;

        public ProductService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Product, Guid> productRepository,
            IRepository<Brand, Guid> brandRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        public async Task<Result<ProductDto>> GetProduct(Guid id, CancellationToken ct = default)
        {
            var product = await _productRepository.GetByIdAsync(id, ct);

            if (product == null)
            {
                return Result<ProductDto>.Failure(DomainErrors.Product.Errors.NotFound);
            }

            return Result<ProductDto>.Success(_mapper.Map<ProductDto>(product));
        }

        public async Task<Result<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken ct = default)
        {
            var products = await _productRepository.GetAllAsync(ct);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Result<IEnumerable<ProductDto>>.Success(productDtos);
        }

        public async Task<Result<ProductDto>> CreateProduct(CreateProductDto productDto, CancellationToken ct = default)
        {
            var brandExists = await _brandRepository.AnyAsync(b => b.Id == productDto.BrandId, ct);
            if (!brandExists)
            {
                return Result<ProductDto>.Failure(DomainErrors.Product.Errors.NotFound);
            }

            var product = Product.Create(
                title: productDto.Title,
                shortDescription: productDto.ShortDescription,
                longDescription: productDto.LongDescription,
                price: productDto.Price,
                brandId: productDto.BrandId);

            await _productRepository.AddAsync(product, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            var resultDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(resultDto);
        }

        public async Task<Result<ProductDto>> UpdateProduct(UpdateProductDto updateProductDto, CancellationToken ct = default)
        {
            var product = await _productRepository.GetByIdAsync(updateProductDto.Id, ct);

            if (product == null)
                return Result<ProductDto>.Failure(DomainErrors.Product.Errors.NotFound);

            product.UpdateDetails(
                updateProductDto.Title,
                updateProductDto.ShortDescription,
                updateProductDto.LongDescription
            );

            product.ChangePrice(updateProductDto.Price);

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(ct);

            var resultDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(resultDto);
        }

        public async Task<Result> DeleteProduct(Guid id, CancellationToken ct = default)
        {
            var product = await _productRepository.GetByIdAsync(id, ct);

            if (product == null)
                return Result.Failure(DomainErrors.Product.Errors.NotFound);

            await _productRepository.RemoveAsync(id, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return Result.Success();
        }

    }
}
