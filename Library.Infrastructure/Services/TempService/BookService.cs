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

        
        public async Task<PaginatedAllBooksDto> ListAllBooksAsync(string? searchBy, string? searchByCategory, int page, int pageSize)
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
                query = query.Where(x => x.Category.Id.ToString() == searchByCategory);
            }

            // For Pagination

            // 1 - Count after filtering
            int totalRecords = query.Count();

            // 2 - Calculate total pages
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // 3 - Get only the requested pages
            query = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

            // 4 - Execute Query - var books = query.ToList(); - twice

            // This is just only mapping to DTOs
            var books = await query
                .Select(x => new AllBooksDto
                {
                    BookId = x.Id,
                    Publisher = x.Publisher,
                    PublishDate = x.PublishDate ?? DateTime.Now,
                    ShelfNumber = x.ShelfNumber,
                    TotalCopies = x.TotalCopies,
                    BookURL = x.Image != null ? x.Image.Url : null,
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

            return new PaginatedAllBooksDto
            {
                Items = books,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public async Task<AddBookDto> AddBookAsync(AddBookDto addBookDto)
        {
            await using(var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // T1 - insert image
                    Image img = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = $"/img/{addBookDto.ImageFileName}"
                    };

                    _dbContext.Images.Add(img);
                    await _dbContext.SaveChangesAsync();

                    // T2 - save book
                    Book book = addBookDto.ToBook();

                    book.ImageId = img.Id;
                    _dbContext.Books.Add(book);

                    var updatedRecords = await _dbContext.SaveChangesAsync();

                    if (updatedRecords == 0)
                    {
                        throw new InvalidOperationException("Book was not inserted.");
                    }

                    await transaction.CommitAsync();

                    return new AddBookDto
                    {
                        Id = book.Id
                    };
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
