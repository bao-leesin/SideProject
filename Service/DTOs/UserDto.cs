using System;
using System.Collections.Generic;
using Service.DTOs.Common;

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

    // --- Request DTOs ---
    public class UserCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? TaxCode { get; set; }
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public int? GroupId { get; set; }
    }
    public class AuthenticationUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? DeviceId { get; set; }
    }
    public class UserRegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? TaxCode { get; set; }
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    public class UserUpdatePasswordDto
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    public class UserUpdateDeviceIdDto
    {
        public string DeviceId { get; set; } = string.Empty;
    }
    public class UserUpdateStatusDto
    {
        public Status Status { get; set; }
    }
    public class UserUpdateGroupIdDto
    {
        public int? GroupId { get; set; }
    }
    public class UserUpdateContactDto
    {
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? TaxCode { get; set; }
    }
    public class UserUpdateRoleDto
    {
        public UserRole Role { get; set; }
    }

    public class GetUsersRequest : PagingRequest
    {
        public string? SearchTerm { get; set; }
        public Status? Status { get; set; }
        public UserRole? Role { get; set; }
        public int? GroupId { get; set; }
    }
} 