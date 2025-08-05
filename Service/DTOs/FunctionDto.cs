using System.Collections.Generic;

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
    }
    public enum FunctionType { Type1, Type2 }
    public enum Status { Active, Inactive }
} 