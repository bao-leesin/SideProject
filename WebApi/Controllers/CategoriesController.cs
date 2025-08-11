using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces.CoreService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createDto)
        {
            var result = await _categoryService.CreateCategoryAsync(createDto);
            return Ok(result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateCategories([FromBody] CreateCategoryDto[] createDtos)
        {
            var result = await _categoryService.CreateCategoriesAsync(createDtos);
            return Ok(result);
        }

        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdateCategories([FromBody] UpdateCategoryDto[] updateDtos)
        {
            var result = await _categoryService.UpdateCategoriesAsync(updateDtos);
            return Ok(result);
        }

        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpPost("bulk-delete")]
        public async Task<IActionResult> DeleteCategories([FromBody] DeleteMultiCategoriesDto deleteDto)
        {
            await _categoryService.DeleteCategoriesAsync(deleteDto);
            return NoContent();
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchCategories([FromQuery] GetCategoryRequest request)
        {
            var result = await _categoryService.SearchCategoriesAsync(request);
            return Ok(result);
        }
    }
} 