using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces.CoreService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserCreateDto> _createValidator;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto createDto)
        {
            if (createDto is null)
            {
                return BadRequest("User creation data cannot be null.");
            }

            // Validate the DTO using FluentValidation

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _userService.CreateUserAsync(createDto);
            return Ok(result);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationUserDto authDto)
        {
            var result = await _userService.AuthenticateAsync(authDto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpPatch("{id}/password")]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] UserUpdatePasswordDto updateDto)
        {
            var result = await _userService.UpdatePasswordAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/device")]
        public async Task<IActionResult> UpdateDeviceId(int id, [FromBody] UserUpdateDeviceIdDto updateDto)
        {
            var result = await _userService.UpdateDeviceIdAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UserUpdateStatusDto updateDto)
        {
            var result = await _userService.UpdateStatusAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/group")]
        public async Task<IActionResult> UpdateGroupId(int id, [FromBody] UserUpdateGroupIdDto updateDto)
        {
            var result = await _userService.UpdateGroupIdAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/contact")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UserUpdateContactDto updateDto)
        {
            var result = await _userService.UpdateContactAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/role")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UserUpdateRoleDto updateDto)
        {
            var result = await _userService.UpdateRoleAsync(id, updateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var result = await _userService.GetUsersAsync(request);
            return Ok(result);
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _userService.GetCurrentUserAsync();
            return Ok(result);
        }
    }
} 