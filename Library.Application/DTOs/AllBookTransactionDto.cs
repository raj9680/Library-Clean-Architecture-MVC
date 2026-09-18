using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class AllBookTransactionDto
    {
        public Guid? TransactionId { get; set; }
        [Required]
        public Guid? TMemberId { get; set; }
        
        public string? BookTitle { get; set; }
        [Required]
        public Guid? BookId { get; set; }
        public string? Member { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? CalculatedFine { get; set; }

    }
}
