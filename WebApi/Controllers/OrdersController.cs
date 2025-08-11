using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces.CoreService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createDto)
        {
            var result = await _orderService.CreateOrderAsync(createDto);
            return Ok(result);
        }

        [HttpPatch("{id}/products")]
    public async Task<IActionResult> UpdateOrderProducts(int id, [FromBody] UpdateOrderProductsDto updateDto)
        {
            var result = await _orderService.UpdateOrderProductsAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto updateDto)
        {
            var result = await _orderService.UpdateOrderStatusAsync(id, updateDto);
            return Ok(result);
        }

        [HttpPatch("bulk-status")]
        public async Task<IActionResult> UpdateMultipleOrderStatus([FromBody] UpdateMultipleOrderStatusDto updateDto)
        {
            var result = await _orderService.UpdateMultipleOrderStatusAsync(updateDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrders([FromQuery] GetOrderRequest request)
        {
            var result = await _orderService.SearchOrdersAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
} 