using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGroupService
    {
        Task<GroupDto> CreateGroupAsync(CreateGroupDto createDto);
        Task<GroupDto> UpdateGroupAsync(string id, UpdateGroupNameDto updateDto);
        Task<GroupDto> UpdateGroupFunctionsAsync(string id, UpdateGroupFunctionsDto updateDto);
        Task<GroupDto> UpdateGroupStatusAsync(string id, UpdateGroupStatusDto updateDto);
        Task DeleteGroupAsync(string id);
        Task<GroupDto> GetGroupByIdAsync(string id);
        Task<PagedResult<GroupDto>> SearchGroupsAsync(GetGroupRequest request);
    }
} 