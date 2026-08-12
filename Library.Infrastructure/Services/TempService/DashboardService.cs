using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Services.TempService
{
    public class DashboardService : IDashboardService
    {
        private readonly LibraryDbContext _dbContext;
        public DashboardService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DashboardDto> GetDashboardInfoAsync()
        {
            var totalBooks = await _dbContext.Books.CountAsync();
            var issuedBooks = await _dbContext.BookTransactions
                .CountAsync(x => x.ReturnDate == null);
            var totalMembers = await _dbContext.Members.CountAsync();

            // Recently Added Books
            var recentlyAddedBooks = await _dbContext.Books.OrderByDescending(x => x.PublishDate).Take(5).Select(x => new RecentlyAddedBookDto
            {
                BookTitle = x.Title,
                ISBN = x.ISBN,
                Category = x.Category.Name,
                Author = x.Author.Name,
                AddedOn = x.PublishDate
            }).ToListAsync();


            // Recently Issued Books
            var recenlyIssuedBooks = await _dbContext.BookTransactions.OrderByDescending(x => x.IssueDate).Take(5).Select(x => new RecentlyIssuedBookDto
            {
                BookTitle = x.Book.Title,
                Member = x.Member.Name,
                IssueDate = x.IssueDate,
                DueDate = x.DueDate,
                Status = "Active"
            }).ToListAsync();

            return new DashboardDto
            {
                TotalBooks = totalBooks,
                AvailableBooks = totalBooks - issuedBooks,
                TotalMembers = totalMembers,
                IssuedBooks = issuedBooks,
                RecentlyAddedBooks = recentlyAddedBooks,
                RecentlyIssuedBooks = recenlyIssuedBooks
            };
        }
    }
}