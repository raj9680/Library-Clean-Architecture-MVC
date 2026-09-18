
using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
        Task<List<CategoryDto>> ListAllCategoryAsync(string searchByName);
        Task<int> EditCategoryAsync(CategoryDto cat);
        Task<CategoryDto> GetCategoryByIdAsync(Guid Id);
        Task<int> AddCategoryAsync(CategoryDto category);
        Task<int> DeleteCategoryAsync(Guid Id);
    }
}
