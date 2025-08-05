using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createDto);
        Task<OrderDto> UpdateOrderProductsAsync(string id, UpdateOrderProductsDto updateDto);
        Task<OrderDto> UpdateOrderStatusAsync(string id, UpdateOrderStatusDto updateDto);
        Task<OrderDto[]> UpdateMultipleOrderStatusAsync(UpdateMultipleOrderStatusDto updateDto);
        Task<PagedResult<OrderDto>> SearchOrdersAsync(GetOrderRequest request);
        Task<OrderDto> GetOrderByIdAsync(string id);
        Task DeleteOrderAsync(string id);
    }
} 