using System.Collections.Generic;
using Service.DTOs.Common;

namespace Service.DTOs
{
    public class FunctionDto : BaseDto
    {
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public FunctionDto? Parent { get; set; }
        public List<FunctionDto>? Children { get; set; }
        public Status Status { get; set; }
        public string? Route { get; set; }
        public FunctionType Type { get; set; }
        public int Order { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
    }
    public enum FunctionType { Type1, Type2 }
    public enum Status { Active, Inactive }

    // --- Request DTOs ---
    public class CreateFunctionDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
    public class UpdateFunctionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Path { get; set; }
        public Status Status { get; set; }
    }
    public class DeleteFunctionDto
    {
        public int Id { get; set; }
    }

    public class GetFunctionRequest : PagingRequest
    {
        public string? SearchTerm { get; set; }
        public Status? Status { get; set; }
    }
} 