using System;
using System.Collections.Generic;

namespace Service.DTOs
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public string? Preview { get; set; }
        public ProductType Type { get; set; }
        public int Duration { get; set; }
        public int? PartnerId { get; set; }
        public PartnerDto? Partner { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ProductCategoryDto>? Categories { get; set; }
        public List<ProductTagDto>? Tags { get; set; }
    }
    public class ProductCategoryDto
    {
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
    public class ProductTagDto : BaseDto
    {
        public string? Tag { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
    public enum ProductType { Type1, Type2 }
} 