using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Member
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }


        // Foreign Key
        public Guid? ImageId { get; set; }
        [ForeignKey(nameof(ImageId))]
        public Image? Image { get; set; }


        // Foreign Key
        public Guid? RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }


        public string? Password { get; set; }


        // Navigation Property
        public ICollection<BookTransaction> BookTransactions { get; set; } = new List<BookTransaction>();
    }
}
