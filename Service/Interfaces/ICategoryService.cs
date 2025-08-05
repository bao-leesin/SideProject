using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto);
        Task<CategoryDto[]> CreateCategoriesAsync(CreateCategoryDto[] createDtos);
        Task<CategoryDto> UpdateCategoryAsync(string id, UpdateCategoryDto updateDto);
        Task<CategoryDto[]> UpdateCategoriesAsync(UpdateCategoryDto[] updateDtos);
        Task DeleteCategoryAsync(string id);
        Task DeleteCategoriesAsync(DeleteMultiCategoriesDto deleteDto);
        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<PagedResult<CategoryDto>> SearchCategoriesAsync(GetCategoryRequest request);
    }
} 