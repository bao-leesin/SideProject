using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDto createDto)
        {
            var result = await _groupService.CreateGroupAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(string id, [FromBody] UpdateGroupNameDto updateDto)
        {
            var result = await _groupService.UpdateGroupAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/functions")]
        public async Task<IActionResult> UpdateGroupFunctions(string id, [FromBody] UpdateGroupFunctionsDto updateDto)
        {
            var result = await _groupService.UpdateGroupFunctionsAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateGroupStatus(string id, [FromBody] UpdateGroupStatusDto updateDto)
        {
            var result = await _groupService.UpdateGroupStatusAsync(id, updateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(string id)
        {
            var result = await _groupService.GetGroupByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchGroups([FromQuery] GetGroupRequest request)
        {
            var result = await _groupService.SearchGroupsAsync(request);
            return Ok(result);
        }
    }
} 