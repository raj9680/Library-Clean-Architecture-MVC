using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<AllBooksDto>> ListAllBooksDto();
    }
}