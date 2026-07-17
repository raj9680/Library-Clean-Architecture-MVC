using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class BookTransaction
    {
        [Key]
        public Guid? Id { get; set; }


        // FK - 1
        public Guid? BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }


        // FK - 2
        public Guid? MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member? Member { get; set; }


        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // [Precision(10, 2)]
        public decimal? CalculatedFine { get; set; }
    }
}