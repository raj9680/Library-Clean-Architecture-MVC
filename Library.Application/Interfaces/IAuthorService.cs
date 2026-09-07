using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorAsync();
        Task<PaginatedAllAuthorsDto> GetAllAuthorsAsync(int page, int pageSize, string? searchByName);
        Task<int> AddAuthorAsync(AuthorDto author);
        Task<int> UpdateAuthorAsync(AuthorDto author);
        Task<AuthorDto> GetAuthorByIdAsync(Guid Id);
        Task<int> DeleteAuthorAsync(Guid Id);
    }
}