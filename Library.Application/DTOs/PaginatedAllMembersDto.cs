namespace Library.Application.DTOs
{
    public class PaginatedAllMembersDto
    {
        public List<AllMembersDto>? Items { get; set; } = new List<AllMembersDto>();
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
