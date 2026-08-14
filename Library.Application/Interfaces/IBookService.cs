using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<PaginatedAllBooksDto> ListAllBooksDto(string? searchBy, string? searchByCategory, int page, int pageSize);
    }
}