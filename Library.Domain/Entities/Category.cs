
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }


        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
