using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<PaginatedAllBooksDto> ListAllBooksAsync(string? searchBy, string? searchByCategory, int page, int pageSize);
        Task<AddBookDto> AddBookAsync(AddBookDto addBookDto);
        Task<EditBookDto> EditBookAsync(Guid id);
    }
}