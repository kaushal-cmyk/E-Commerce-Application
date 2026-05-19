using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            var product = await _productService.CreateProduct(request);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto request)
        {
            //var dto = request with { Id = id };
            await _productService.UpdateProduct(request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
