using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class AllMembersDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public string? MemberImage { get; set; }
        public List<AllBookTransactionDto> BookTransactions { get; set; } = new();
    }

    public static class AllMembersDtoExtension
    {
        public static Member ToMember(this AllMembersDto member)
        {
            return new Member
            {
                Id = Guid.NewGuid(),
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Status = member.Status,
                Address = member.Address
            };
        }
    }
}
