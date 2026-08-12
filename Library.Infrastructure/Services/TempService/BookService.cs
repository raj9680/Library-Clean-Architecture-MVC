using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Services.TempService
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;
        public BookService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AllBooksDto>> ListAllBooksDto()
        {
            var allBooks = _dbContext.Books.Include(x => x.Category).Include(x => x.Author).Include(x => x.Image).Include(x => x.BookTransactions).ThenInclude(m => m.Member).ToList();
            List<AllBooksDto> allBooksDto = new List<AllBooksDto>();

            foreach (var item in allBooks)
            {
                AllBooksDto BookDto = new AllBooksDto()
                {
                    BookId = item.Id,
                    Publisher = item.Publisher,
                    PublishDate = item.PublishDate ?? DateTime.Now,
                    ShelfNumber = item.ShelfNumber,
                    TotalCopies = item.TotalCopies,
                    BookURL = item.Image?.Url?.ToString(),
                    BookTitle = item.Title,
                    ISBN = item.ISBN,
                    Description = item.Description,
                    Category = item.Category?.Name?.ToString(),
                    Author = item.Author?.Name?.ToString(),
                    AvailableCopies = Convert.ToInt32(item.TotalCopies),
                    AllBooksTransactionsDto = item.BookTransactions?.Select(transaction => new AllBookTransactionDto
                    {
                        TransactionId = transaction.Id,
                        TMemberId = transaction.MemberId,
                        Member = transaction?.Member?.Name?.ToString(),
                        IssueDate = transaction.IssueDate,
                        DueDate = transaction.DueDate,
                        ReturnDate = transaction.ReturnDate,
                        CalculatedFine = transaction.CalculatedFine
                    }).ToList()
                };

                allBooksDto.Add(BookDto);
            }
            return allBooksDto;
        }
    }
}
