using Library.Domain.Entities;

namespace Library.Application.DTOs
{
    public class AllAuthorDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? CountryId { get; set; }
        public string? Biography { get; set; }
        public int TotalBooks { get; set; }
        public List<AllBooksDto> Books { get; set; } = new List<AllBooksDto>();
    }

    public static class AllAuthorDtoExtension
    {
        public static AllAuthorDto ToAuthor(this Author author)
        {
            return new AllAuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                CountryId = author.CountryId.ToString(),
                Biography = author.Biography,
                Books = new()
            };
        }
    }
}
