using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Common;

public class Function : EntityBase
{
    public string? Name { get; set; }
    public Status Status { get; set; }
    public string? Route { get; set; }
    public FunctionType Type { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public Function? Parent { get; set; }
    public ICollection<Function>? Children { get; set; }
    public int Order { get; set; }
    public string? Icon { get; set; }
}

public enum FunctionType { Type1, Type2 } 