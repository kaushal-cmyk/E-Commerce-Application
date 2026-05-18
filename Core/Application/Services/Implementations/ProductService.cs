
using AutoMapper;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product, Guid> _productRespository;

        public ProductService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Product, Guid> productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRespository = productRepository;
        }

        public async Task<ProductDto?> GetProduct(Guid id)
        {
            var product = await _productRespository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRespository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

    }
}
