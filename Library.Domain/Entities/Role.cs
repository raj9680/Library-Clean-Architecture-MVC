
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Role
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
