using Library.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class AddBookDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage ="Book Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage ="ISBN is required")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage ="Category is required")]
        public Guid CategoryId { get; set; } = Guid.Empty;

        [Required(ErrorMessage ="Author is required")]
        public Guid AuthorId { get; set; } = new Guid();
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? TotalCopies { get; set; }
        public int? AvailableCopies { get; set; }
        public int? ShelfNumber { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageFileName { get; set; }
    }

    public static class AddBookDtoExtension
    {
        public static Book ToBook(this AddBookDto dto)
        {
            return new Book
            {
                Id = Guid.NewGuid(),

                Title = dto.Title,
                ISBN = dto.ISBN,

                AuthorId = dto.AuthorId,
                CategoryId = dto.CategoryId,

                TotalCopies = dto.TotalCopies,
                AvailableCopies = dto.TotalCopies,

                ShelfNumber = dto.ShelfNumber,
                Description = dto.Description,
                Publisher = dto.Publisher,
                PublishDate = dto.PublishDate

                //Image = dto.Image == null
                //? null
                //: new Image
                //{
                //    Url = dto.Image.
                //}
            };
        }
    }
}
