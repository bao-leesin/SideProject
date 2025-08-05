using Service.DTOs;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
} 