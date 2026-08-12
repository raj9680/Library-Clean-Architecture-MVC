namespace Library.Application.DTOs
{
    public class DashboardDto
    {
        public int TotalBooks { get; set; }
        public int TotalMembers { get; set; }
        public int AvailableBooks { get; set; }
        public int IssuedBooks { get; set; }


        public List<RecentlyAddedBookDto>? RecentlyAddedBooks { get; set; } = new();
        public List<RecentlyIssuedBookDto>? RecentlyIssuedBooks { get; set; } = new();
    }
}