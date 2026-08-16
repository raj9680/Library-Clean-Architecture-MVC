using Library.Application.DTOs;
using Library.Application.Interfaces;
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
    }
}
