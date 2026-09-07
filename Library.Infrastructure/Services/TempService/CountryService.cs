using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Services.TempService
{
    public class CountryService : ICountryService
    {
        private readonly LibraryDbContext _dbContext;
        public CountryService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CountryDto>> GetAllCountryAsync()
        {
            return await _dbContext.Countries
                .AsNoTracking()
                .Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }



    }
}
