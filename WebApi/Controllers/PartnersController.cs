using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner([FromBody] CreatePartnerDto createDto)
        {
            var result = await _partnerService.CreatePartnerAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartner(string id, [FromBody] UpdatePartnerDto updateDto)
        {
            var result = await _partnerService.UpdatePartnerAsync(id, updateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(string id)
        {
            await _partnerService.DeletePartnerAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartnerById(string id)
        {
            var result = await _partnerService.GetPartnerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPartners([FromQuery] GetPartnerRequest request)
        {
            var result = await _partnerService.GetPartnersAsync(request);
            return Ok(result);
        }
    }
} 