using System;
using System.Collections.Generic;

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
    public enum OrderStatus { Pending, Completed, Cancelled }
} 