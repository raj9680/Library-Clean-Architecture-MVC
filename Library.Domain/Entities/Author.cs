using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Author
    {
        [Key]
        public Guid? Id { get; set; }

        [StringLength(30)]
        public string? Name { get; set; }


        // Foreign Key - handling in Fluent API, only this
        public Guid? CountryId { get; set; }
        public Country? Country { get; set; } 


        [StringLength(120)]
        public string? Biography { get; set; }


        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
