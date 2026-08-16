using Library.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Library.Application.DTOs
{
    public class CategoryDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }


    // Extension method to Map Category to CategoryDto
    public static class BookCategoryExtensions
    {
        public static CategoryDto ToCategory(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
