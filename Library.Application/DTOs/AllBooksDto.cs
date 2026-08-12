
namespace Library.Application.DTOs
{
    public class AllBooksDto
    {
        public string? BookURL { get; set; }
        public Guid? BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? ISBN { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string? Description { get; set; }
        public int? ShelfNumber { get; set; }
        public List<AllBookTransactionDto> AllBooksTransactionsDto { get; set; } = new List<AllBookTransactionDto>();
    }
}
