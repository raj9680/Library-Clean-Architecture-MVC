using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
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

        public async Task<List<AllBooksDto>> ListAllBooksDto( string? searchBy, string? searchByCategory)
        {
            IQueryable<Book> query = _dbContext.Books.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                searchBy = searchBy.Trim();

                query = query.Where(x =>
                x.Title.Contains(searchBy) ||
                x.ISBN.Contains(searchBy) ||
                x.Author.Name.Contains(searchBy));
            }

            if (!string.IsNullOrWhiteSpace(searchByCategory))
            {
                query = query.Where(x => x.Category.Name.Contains(searchByCategory));
            }

            // This is just only mapping to DTOs
            return await query
                .Select(x => new AllBooksDto
                {
                    BookId = x.Id,
                    Publisher = x.Publisher,
                    PublishDate = x.PublishDate ?? DateTime.Now,
                    ShelfNumber = x.ShelfNumber,
                    TotalCopies = x.TotalCopies,
                    BookURL = x.Image != null?x.Image.Url:null,
                    BookTitle = x.Title,
                    ISBN = x.ISBN,
                    Description = x.Description,
                    Category = x.Category.Name,
                    Author = x.Author.Name,
                    AvailableCopies = x.TotalCopies,

                    AllBooksTransactionsDto = x.BookTransactions
                .Select(transaction => new AllBookTransactionDto
                {
                    TransactionId = transaction.Id,
                    TMemberId = transaction.MemberId,
                    Member = transaction.Member.Name,
                    IssueDate = transaction.IssueDate,
                    DueDate = transaction.DueDate,
                    ReturnDate = transaction.ReturnDate,
                    CalculatedFine = transaction.CalculatedFine
                }).ToList()
             
            }).ToListAsync();
        }
    }
}
