
namespace Library.Application.DTOs
{
    public class RecentlyAddedBookDto
    {
        public string? BookTitle { get; set; }
        public string? ISBN { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
