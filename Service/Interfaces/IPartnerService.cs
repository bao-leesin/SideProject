using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPartnerService
    {
        Task<PartnerDto> CreatePartnerAsync(CreatePartnerDto createDto);
        Task<PartnerDto> UpdatePartnerAsync(string id, UpdatePartnerDto updateDto);
        Task DeletePartnerAsync(string id);
        Task<PartnerDto> GetPartnerByIdAsync(string id);
        Task<PagedResult<PartnerDto>> GetPartnersAsync(GetPartnerRequest request);
    }
} 