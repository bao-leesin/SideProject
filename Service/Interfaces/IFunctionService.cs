using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFunctionService
    {
        Task<FunctionDto> CreateFunctionAsync(CreateFunctionDto createDto);
        Task<FunctionDto[]> CreateFunctionsAsync(CreateFunctionDto[] createDtos);
        Task<FunctionDto> UpdateFunctionAsync(string id, UpdateFunctionDto updateDto);
        Task<FunctionDto[]> UpdateFunctionsAsync(UpdateFunctionDto[] updateDtos);
        Task DeleteFunctionAsync(string id);
        Task<FunctionDto> GetFunctionByIdAsync(string id);
        Task<PagedResult<FunctionDto>> SearchFunctionsAsync(GetFunctionRequest request);
    }
} 