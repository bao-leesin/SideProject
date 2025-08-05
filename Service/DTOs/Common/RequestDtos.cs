using System.Collections.Generic;

namespace Service.DTOs.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class PagingRequest
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; } = "asc";
    }
} 