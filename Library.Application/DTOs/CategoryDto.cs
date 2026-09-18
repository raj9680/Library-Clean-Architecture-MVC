using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class CategoryDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage ="Name cannot be emptied")]
        public string? Name { get; set; }
    }


    // Extension method to Map Category to CategoryDto
    public static class CategoryExtensions
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
