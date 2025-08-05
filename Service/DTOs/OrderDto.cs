using System;
using System.Collections.Generic;
using Service.DTOs.Common;

namespace Service.DTOs
{
    public class OrderDto : BaseDto
    {
        public int? UserId { get; set; }
        public UserDto? User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProductDto>? Products { get; set; }
    }
    public class OrderProductDto
    {
        public int OrderId { get; set; }
        public OrderDto? Order { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
    public enum OrderStatus { Pending, Confirmed, Processing, Shipped, Delivered, Cancelled, Completed }

    // --- Request DTOs ---
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public List<OrderProductDto> Products { get; set; } = new List<OrderProductDto>();
        public string? Notes { get; set; }
    }
    public class UpdateOrderProductsDto
    {
        public List<OrderProductDto> Products { get; set; } = new List<OrderProductDto>();
    }
    public class UpdateOrderStatusDto
    {
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }
    }
    public class UpdateMultipleOrderStatusDto
    {
        public List<int> OrderIds { get; set; } = new List<int>();
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }
    }

    public class GetOrderRequest : PagingRequest
    {
        public string? SearchTerm { get; set; }
        public OrderStatus? Status { get; set; }
        public int? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
} 