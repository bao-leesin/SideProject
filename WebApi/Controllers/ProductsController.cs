using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            var result = await _productService.CreateProductAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductDto updateDto)
        {
            var result = await _productService.UpdateProductAsync(id, updateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPost("bulk-delete")]
        public async Task<IActionResult> DeleteProducts([FromBody] DeleteMultiProductsDto deleteDto)
        {
            await _productService.DeleteProductsAsync(deleteDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts([FromQuery] GetProductRequest request)
        {
            var result = await _productService.SearchProductsAsync(request);
            return Ok(result);
        }
    }
} 