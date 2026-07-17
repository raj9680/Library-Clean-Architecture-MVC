
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Country
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property - In FLuent API
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
