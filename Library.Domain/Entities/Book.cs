
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Book
    {
        [Key]
        public Guid? Id { get; set; }

        [StringLength(40)]
        public string? Title { get; set; }
        public string? ISBN { get; set; }


        // FK - 1
        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; } 


        // FK 2
        public Guid? AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }


        [StringLength(40)]
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? TotalCopies { get; set; }
        public int? AvailableCopies { get; set; }
        public int? ShelfNumber { get; set; }

        [StringLength(120)]
        public string? Description { get; set; }


        // FK - 3
        public Guid? ImageId { get; set; }
        [ForeignKey(nameof(ImageId))]
        public Image? Image { get; set; }


        // Navigation Property
        public ICollection<BookTransaction> BookTransactions { get; set; } = new List<BookTransaction>();
    }
}
