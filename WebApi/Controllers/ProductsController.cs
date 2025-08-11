using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public ProductsController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var result = await _mediaService.UploadFileAsync(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Upload failed: {ex.Message}");
            }
        }
    }
}