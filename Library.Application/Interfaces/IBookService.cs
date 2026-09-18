using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<PaginatedAllBooksDto> ListAllBooksAsync(string? searchBy, string? searchByCategory, int page, int pageSize);
        Task<AddBookDto> AddBookAsync(AddBookDto addBookDto);
        Task<EditBookDto> GetBookByIdAsync(Guid id);
        Task<int> EditBookAsync(EditBookDto editBook);
        Task<int> DeleteBookAsync(Guid Id);
        Task<List<BooksDropdownDto>> GetAllBooks();
        Task<AllBookTransactionDto> IssueBookAsync(AllBookTransactionDto bookTransactionDto);
        Task<List<MemberDropdownDto>> GetTransactingMembersAsync();
        Task<List<AllBookTransactionDto>> GetTransactingBooksAsync(Guid? memberId);
        Task<int> UpdateTransactionAsyc(AllBookTransactionDto transactionDto);
    }
}