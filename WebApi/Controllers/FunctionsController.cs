using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces.CoreService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionsController : ControllerBase
    {
        private readonly IFunctionService _functionService;

        public FunctionsController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFunction([FromBody] CreateFunctionDto createDto)
        {
            var result = await _functionService.CreateFunctionAsync(createDto);
            return Ok(result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateFunctions([FromBody] CreateFunctionDto[] createDtos)
        {
            var result = await _functionService.CreateFunctionsAsync(createDtos);
            return Ok(result);
        }

        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFunction(int id, [FromBody] UpdateFunctionDto updateDto)
        {
            var result = await _functionService.UpdateFunctionAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdateFunctions([FromBody] UpdateFunctionDto[] updateDtos)
        {
            var result = await _functionService.UpdateFunctionsAsync(updateDtos);
            return Ok(result);
        }

        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFunction(int id)
        {
            await _functionService.DeleteFunctionAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetFunctionById(int id)
        {
            var result = await _functionService.GetFunctionByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchFunctions([FromQuery] GetFunctionRequest request)
        {
            var result = await _functionService.SearchFunctionsAsync(request);
            return Ok(result);
        }
    }
} 