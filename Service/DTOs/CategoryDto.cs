using System.Collections.Generic;
using Service.DTOs.Common;

namespace Service.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public CategoryDto? Parent { get; set; }
        public List<CategoryDto>? Children { get; set; }
        public List<CategoryTagDto>? Tags { get; set; }
        public Status Status { get; set; }
    }
    public class CategoryTagDto : BaseDto
    {
        public string? Tag { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
    // --- Request DTOs ---
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
    public class DeleteMultiCategoriesDto
    {
        public List<int> Ids { get; set; } = new List<int>();
    }

    public class GetCategoryRequest : PagingRequest
    {
        public string? SearchTerm { get; set; }
        public int? ParentId { get; set; }
    }
} 