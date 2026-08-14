namespace Library.Application.DTOs
{
    public class PaginatedAllBooksDto
    {
        public List<AllBooksDto> Items { get; set; } = new List<AllBooksDto>();
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
