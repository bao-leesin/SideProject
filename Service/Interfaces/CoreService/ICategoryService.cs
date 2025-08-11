using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto);
        Task<CategoryDto[]> CreateCategoriesAsync(CreateCategoryDto[] createDtos);
    Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto updateDto);
        Task<CategoryDto[]> UpdateCategoriesAsync(UpdateCategoryDto[] updateDtos);
    Task DeleteCategoryAsync(int id);
        Task DeleteCategoriesAsync(DeleteMultiCategoriesDto deleteDto);
    Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<PagedResult<CategoryDto>> SearchCategoriesAsync(GetCategoryRequest request);
    }
}