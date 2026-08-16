
using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
    }
}
