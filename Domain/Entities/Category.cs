using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Category : EntityBase
{
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public Category? Parent { get; set; }
    public ICollection<Category>? Children { get; set; }
    public ICollection<CategoryTag>? Tags { get; set; }
}

public class CategoryTag : EntityBase
{
    public string? Tag { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
} 