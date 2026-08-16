using Library.Domain.Entities;

namespace Library.Application.DTOs
{
    public class AuthorDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
