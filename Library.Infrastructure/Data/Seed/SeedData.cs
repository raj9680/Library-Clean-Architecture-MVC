using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(LibraryDbContext dbContext)
        {
            await SeedCountriesAsync(dbContext);
            await SeedAuthorsAsync(dbContext);

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedCountriesAsync(LibraryDbContext dbContext)
        {
            if (await dbContext.Countries.AnyAsync())
                return;

            var countries = await JsonSeeder.ReadAsync<Country>("Countries");
            await dbContext.Countries.AddRangeAsync(countries);
            // await dbContext.SaveChangesAsync();
        }

        private static async Task SeedAuthorsAsync(LibraryDbContext dbContext)
        {
            // skip if data exists already
            if (await dbContext.Authors.AnyAsync()) 
                return;

            var authors = await JsonSeeder.ReadAsync<Author>("Authors");
            await dbContext.Authors.AddRangeAsync(authors);
            // await dbContext.SaveChangesAsync();
        }
    }
}
