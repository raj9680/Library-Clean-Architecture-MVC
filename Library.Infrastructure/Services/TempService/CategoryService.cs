using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
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

        public async Task<int> AddCategoryAsync(CategoryDto category)
        {

            Category cat = new Category
            {
                Name = category.Name,
                Id = Guid.NewGuid()
            };

            _dbContext.Categories.Add(cat);
            int recordUpdated = await _dbContext.SaveChangesAsync();
            return recordUpdated;
        }

        public async Task<int> DeleteCategoryAsync(Guid Id)
        {
            int res = 0;
            var cat = _dbContext.Categories.FirstOrDefault(c => c.Id == Id);
            if(cat != null)
            {
                _dbContext.Categories.Remove(cat);
                try
                {
                    res = await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains(""))
                    {
                        res = 457;
                    }
                }
            }
            return res;
        }

        public async Task<int> EditCategoryAsync(CategoryDto cat)
        {
            var catt = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == cat.Id);

            if (cat == null)
            {
                throw new KeyNotFoundException("Book not exist");
            }

            // update entity
            catt.Name = cat.Name;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
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
            List<CategoryDto> result = await _dbContext.Categories.Select(category => category.ToCategory()).ToListAsync();

            return result;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid Id)
        {
            var cat = await _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefaultAsync();

            CategoryDto cDto = new CategoryDto
            {
                Id = cat.Id,
                Name = cat.Name,
            };

            return cDto;
        }

        public async Task<List<CategoryDto>> ListAllCategoryAsync(string searchByName)
        {
            IQueryable<Category> query = _dbContext.Categories.AsNoTracking();

            if(!string.IsNullOrWhiteSpace(searchByName))
            {
                searchByName = searchByName.Trim();
                query = query.Where(x => x.Name.Contains(searchByName));
            }

            List<CategoryDto> result = await query.Select(category => category.ToCategory()).ToListAsync();

            return result;
        }
    }
}
