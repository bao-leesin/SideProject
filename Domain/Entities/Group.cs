using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

public class Group : EntityBase
{
    public string? Name { get; set; }
    public Status Status { get; set; }
    public ICollection<GroupFunction>? Functions { get; set; }
}

public class GroupFunction
{
    public int GroupId { get; set; }
    public Group? Group { get; set; }
    public int FunctionId { get; set; }
    public Function? Function { get; set; }
} 