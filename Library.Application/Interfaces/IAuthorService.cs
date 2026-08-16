using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorAsync();
    }
}