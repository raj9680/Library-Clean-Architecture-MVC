using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class AuthorDto
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage ="Author name required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Country name required.")]
        public Guid? CountryId { get; set; }

        [Required(ErrorMessage ="Author biography is required.")]
        public string? Biography { get; set; }
    }

    public static class AuthorDtoExtensions
    {
        public static Author ToAuthorr(this AuthorDto author)
        {
            return new Author
            {
                Id = author.Id,
                Name = author.Name,
                CountryId = author.CountryId,
                Biography = author.Biography
            };
        }
    }
}
