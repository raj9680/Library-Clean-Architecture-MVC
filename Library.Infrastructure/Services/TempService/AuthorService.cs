using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Services.TempService
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AuthorDto>> GetAllAuthorAsync()
        {
            return await _dbContext.Authors
                .Select(x => new AuthorDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<PaginatedAllAuthorsDto> GetAllAuthorsAsync(int page, int pageSize, string? searchByName)
        {
            IQueryable<Author> query = _dbContext.Authors
                .AsNoTracking()
                //.Where(a => a.Books.Any())
                .OrderByDescending(a => a.Books.Count());

            if (!string.IsNullOrWhiteSpace(searchByName))
            {
                searchByName = searchByName.Trim();

                query = query.Where(x =>
                x.Name.Contains(searchByName));
            }

            // For Pagination 
            int totalRecords = query.Count();

            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            query = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);


            var authors = await query
                //.Where(a => a.Books.Any())
                .Select(x => new AllAuthorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId.ToString(),
                    Country = x.Country.Name,
                    Biography = x.Biography,
                    TotalBooks = x.Books.Count(z => z.AuthorId == x.Id),
                    Books = x.Books.Select(b => new AllBooksDto
                    {
                         BookId = b.Id,
                         BookTitle = b.Title,
                         CategoryId = b.CategoryId,
                         Publisher = b.Publisher,
                         PublishDate = b.PublishDate,
                         AllBooksTransactionsDto = b.BookTransactions.Select(t => new AllBookTransactionDto
                         {
                            IssueDate = t.IssueDate,
                            ReturnDate = t.ReturnDate,
                            DueDate = t.DueDate,
                         }).ToList()
                    }).ToList()
                }).ToListAsync();


            return new PaginatedAllAuthorsDto
            {
                Items = authors,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public async Task<int> AddAuthorAsync(AuthorDto author)
        {
            author.Id = Guid.NewGuid();
            var authorEntity = author.ToAuthorr();

            await _dbContext.Authors.AddAsync(authorEntity);

            var resultCount = await _dbContext.SaveChangesAsync();

            if (resultCount > 0)
            {
                var authorId = authorEntity.Id;
            }

            return resultCount;
        }

        public async Task<int> UpdateAuthorAsync(AuthorDto author)
        {
            Author? authorr = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);

            if (authorr == null)
            {
                throw new KeyNotFoundException("Author not exist");
            }

            // Update Entities
            authorr.Name = author.Name;
            authorr.Biography = author.Biography;
            authorr.CountryId = author.CountryId;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await _dbContext.Authors
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new AuthorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Biography = x.Biography,
                    CountryId = x.CountryId

                }).FirstOrDefaultAsync();

            if (author == null)
            {
                throw new KeyNotFoundException("Author not found.");
            }

            return author;
        }

        public async Task<int> DeleteAuthorAsync(Guid authorId)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

            if (author == null)
                return 0;

            int result = 0;
            var res = _dbContext.Authors.Remove(author);
            try
            {
                result = await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("FK_Books_Authors_AuthorId"))
                {
                    result = 457;
                }
            }
            return result;
        }
    }
}
