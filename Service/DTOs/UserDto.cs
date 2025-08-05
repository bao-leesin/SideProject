using System;

namespace Service.DTOs
{
    public class UserDto : BaseDto
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
        public GroupDto? Group { get; set; }
        public UserRole Role { get; set; }
        public List<UserProductDto>? UserProducts { get; set; }
        public List<UserCategoryDto>? UserCategories { get; set; }
    }
    public class UserProductDto
    {
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
    public class UserCategoryDto
    {
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
    public enum UserRole { Admin, User, Guest }
    public enum Status { Active, Inactive }
} 