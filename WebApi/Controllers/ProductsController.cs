using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Service.DTOs;
using Service.Interfaces;
using Service.Interfaces.CoreService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediaService _mediaService;

        public ProductsController(
            IProductService productService, IMediaService mediaService)
        {
            _productService = productService;
            _mediaService = mediaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            var result = await _productService.CreateProductAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateDto)
        {
            var result = await _productService.UpdateProductAsync(id, updateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
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
    public async Task<IActionResult> GetProductById(int id)
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

        [HttpPost("upload-media")]
        public async Task<IActionResult> UploadProductImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await _mediaService.UploadVideoAsync();
            return NoContent();
        }

      
    }
} 