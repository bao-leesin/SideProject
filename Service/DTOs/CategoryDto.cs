using System.Collections.Generic;

namespace Service.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public CategoryDto? Parent { get; set; }
        public List<CategoryDto>? Children { get; set; }
        public List<CategoryTagDto>? Tags { get; set; }
    }
    public class CategoryTagDto : BaseDto
    {
        public string? Tag { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
} 