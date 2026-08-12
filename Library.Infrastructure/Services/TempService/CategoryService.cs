using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Services.TempService
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext _dbContext;
        public CategoryService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookCategoryDto>> GetAllCategoryAsync()
        {
            //
            //List<Category> allCategory = await _dbContext.Categories.ToListAsync();

            //List<BookCategoryDto> result = new List<BookCategoryDto>();

            //foreach (var category in allCategory)
            //{
            //    var cat = new BookCategoryDto
            //    {
            //        Id = category.Id,
            //        Name = category.Name,
            //    };
            //    result.Add(cat);
            //}

            // OR
            List<BookCategoryDto> result = await _dbContext.Categories.Select(category => category.ToCategory()).ToListAsync();

            return result;
        }
    }
}
