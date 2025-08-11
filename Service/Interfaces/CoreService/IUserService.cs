using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto createDto);
        Task<UserDto> AuthenticateAsync(AuthenticationUserDto authDto);
        Task<UserDto> RegisterAsync(UserRegisterDto registerDto);
        Task<UserDto> UpdatePasswordAsync(int id, UserUpdatePasswordDto updateDto);
        Task<UserDto> UpdateDeviceIdAsync(int id, UserUpdateDeviceIdDto updateDto);
        Task<UserDto> UpdateStatusAsync(int id, UserUpdateStatusDto updateDto);
        Task<UserDto> UpdateGroupIdAsync(int id, UserUpdateGroupIdDto updateDto);
        Task<UserDto> UpdateContactAsync(int id, UserUpdateContactDto updateDto);
        Task<UserDto> UpdateRoleAsync(int id, UserUpdateRoleDto updateDto);
        Task DeleteUserAsync(int id);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<PagedResult<UserDto>> GetUsersAsync(GetUsersRequest request);
        Task<UserDto> GetCurrentUserAsync();
    }
}