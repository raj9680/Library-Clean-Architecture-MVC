
namespace Library.Application.DTOs
{
    public class RecentlyIssuedBookDto
    {
        public string? BookTitle { get; set; }
        public string? Member { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
    }
}
