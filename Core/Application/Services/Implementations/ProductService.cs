
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

        public ProductService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Product, Guid> productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Result<ProductDto>> GetProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return Result<ProductDto>.Failure(DomainErrors.Product.Errors.NotFound);
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(productDto);
        }

        public async Task<Result<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Result<IEnumerable<ProductDto>>.Success(productDtos);
        }

        public async Task<Result<ProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var brandExists = await _brandRepository.AnyAsync(b => b.Id == productDto.BrandId);
            if (!brandExists)
                return Result<ProductDto>.Failure(DomainErrors.Product.Errors.BrandNotFound);

            var product = Product.Create(
                title: productDto.Title,
                shortDescription: productDto.ShortDescription,
                longDescription: productDto.LongDescription,
                price: productDto.Price,
                brandId: productDto.BrandId);

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(resultDto);
        }

        public async Task<ProductDto> UpdateProduct(
            UpdateProductDto updateProductDto)
        {
            var product =
                await _productRepository
                    .GetByIdAsync(updateProductDto.Id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Entity not Found.");
            }

            product.UpdateDetails(
                updateProductDto.Title,
                updateProductDto.ShortDescription,
                updateProductDto.LongDescription
            );

            product.ChangePrice(updateProductDto.Price);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }


        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
