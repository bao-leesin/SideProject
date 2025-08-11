using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IFunctionService
    {
        Task<FunctionDto> CreateFunctionAsync(CreateFunctionDto createDto);
        Task<FunctionDto[]> CreateFunctionsAsync(CreateFunctionDto[] createDtos);
    Task<FunctionDto> UpdateFunctionAsync(int id, UpdateFunctionDto updateDto);
        Task<FunctionDto[]> UpdateFunctionsAsync(UpdateFunctionDto[] updateDtos);
    Task DeleteFunctionAsync(int id);
    Task<FunctionDto> GetFunctionByIdAsync(int id);
        Task<PagedResult<FunctionDto>> SearchFunctionsAsync(GetFunctionRequest request);
    }
}