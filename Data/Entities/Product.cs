using System;
using System.Collections.Generic;
using Data.Common;

public class Product : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public string? Preview { get; set; }
    public ProductType Type { get; set; }
    public int Duration { get; set; }
    public int? PartnerId { get; set; }
    public Partner? Partner { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<ProductCategory>? Categories { get; set; }
    public ICollection<ProductTag>? Tags { get; set; }
}

public class ProductCategory
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

public class ProductTag : EntityBase
{
    public string? Tag { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

public enum ProductType { Type1, Type2 } 