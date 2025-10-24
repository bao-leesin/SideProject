using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadRequest request)
        {
            var file = request.File;
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            return NoContent();
        }
    }
}