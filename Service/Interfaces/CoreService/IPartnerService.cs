using Service.DTOs;
using Service.DTOs.Common;
using Service.Services.CoreService;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IPartnerService
    {
        Task<PartnerDto> CreatePartnerAsync(CreatePartnerDto createDto);
    Task<PartnerDto> UpdatePartnerAsync(int id, UpdatePartnerDto updateDto);
    Task DeletePartnerAsync(int id);
    Task<PartnerDto> GetPartnerByIdAsync(int id);
        Task<PagedResult<PartnerDto>> GetPartnersAsync(GetPartnerRequest request);

        event EventHandler<PartnerEventArgs> PartnerCreated;
    }
}