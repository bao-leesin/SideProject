using System.Collections.Generic;
using Domain.Common;

public class User : EntityBase
{
    public string? Name { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Province { get; set; }
    public string? TaxCode { get; set; }
    public string? DeviceId { get; set; }
    public Status Status { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    public UserRole Role { get; set; }
    public ICollection<UserProduct>? UserProducts { get; set; }
    public ICollection<UserCategory>? UserCategories { get; set; }
}

public class UserProduct
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

public class UserCategory
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

public enum UserRole { Admin, User, Guest } 