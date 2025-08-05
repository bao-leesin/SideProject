using System.Collections.Generic;
using Service.DTOs.Common;

namespace Service.DTOs
{
    public class GroupDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Data.Common.Status Status { get; set; }
        public List<GroupFunctionDto>? Functions { get; set; }
    }
    public class GroupFunctionDto
    {
        public int GroupId { get; set; }
        public GroupDto? Group { get; set; }
        public int FunctionId { get; set; }
        public FunctionDto? Function { get; set; }
    }

    // --- Request DTOs ---
    public class CreateGroupDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Data.Common.Status Status { get; set; } = Data.Common.Status.Active;
    }
    public class UpdateGroupNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
    public class UpdateGroupFunctionsDto
    {
        public List<int> FunctionIds { get; set; } = new List<int>();
    }
    public class UpdateGroupStatusDto
    {
        public Data.Common.Status Status { get; set; }
    }

    public class GetGroupRequest : PagingRequest
    {
        public string? SearchTerm { get; set; }
        public Data.Common.Status? Status { get; set; }
    }
} 