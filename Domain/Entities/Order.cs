using System;
using System.Collections.Generic;
using Domain.Common;

public class Order : EntityBase
{
    public int? UserId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderProduct>? Products { get; set; }
}

public class OrderProduct
{
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

public enum OrderStatus { Pending, Completed, Cancelled } 