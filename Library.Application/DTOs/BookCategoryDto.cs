using Library.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Library.Application.DTOs
{
    public class BookCategoryDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }


    // Extension method to Map Category to CategoryDto
    public static class BookCategoryExtensions
    {
        public static BookCategoryDto ToCategory(this Category category)
        {
            return new BookCategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
