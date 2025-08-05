using System.Collections.Generic;

namespace Service.DTOs
{
    public class GroupDto : BaseDto
    {
        public string? Name { get; set; }
        public Status Status { get; set; }
        public List<GroupFunctionDto>? Functions { get; set; }
    }
    public class GroupFunctionDto
    {
        public int GroupId { get; set; }
        public GroupDto? Group { get; set; }
        public int FunctionId { get; set; }
        public FunctionDto? Function { get; set; }
    }
    public enum Status { Active, Inactive }
} 