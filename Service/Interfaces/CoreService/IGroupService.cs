using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IGroupService
    {
        Task<GroupDto> CreateGroupAsync(CreateGroupDto createDto);
    Task<GroupDto> UpdateGroupAsync(int id, UpdateGroupNameDto updateDto);
    Task<GroupDto> UpdateGroupFunctionsAsync(int id, UpdateGroupFunctionsDto updateDto);
    Task<GroupDto> UpdateGroupStatusAsync(int id, UpdateGroupStatusDto updateDto);
    Task DeleteGroupAsync(int id);
    Task<GroupDto> GetGroupByIdAsync(int id);
        Task<PagedResult<GroupDto>> SearchGroupsAsync(GetGroupRequest request);
    }
}