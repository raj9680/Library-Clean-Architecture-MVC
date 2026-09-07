namespace Library.Application.DTOs
{
    public class PaginatedAllAuthorsDto
    {
        public List<AllAuthorDto> Items { get; set; } = new List<AllAuthorDto>();
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
