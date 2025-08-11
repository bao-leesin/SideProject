using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createDto);
    Task<OrderDto> UpdateOrderProductsAsync(int id, UpdateOrderProductsDto updateDto);
    Task<OrderDto> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto updateDto);
        Task<OrderDto[]> UpdateMultipleOrderStatusAsync(UpdateMultipleOrderStatusDto updateDto);
        Task<PagedResult<OrderDto>> SearchOrdersAsync(GetOrderRequest request);
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task DeleteOrderAsync(int id);
    }
}