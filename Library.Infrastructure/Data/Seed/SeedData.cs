using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(LibraryDbContext dbContext)
        {
            await SeedRolesAsync(dbContext);
            await SeedCategoriesAsync(dbContext);
            await SeedImagesAsync(dbContext);
            await SeedCountriesAsync(dbContext);
            await SeedAuthorsAsync(dbContext);
            await SeedMembersAsync(dbContext);
            await SeedBooksAsync(dbContext);
            await SeedTransactionsAsync(dbContext);

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

        private static async Task SeedRolesAsync(LibraryDbContext dbContext)
        {
            if(await dbContext.Roles.AnyAsync())
            {
                return;
            }

            var roles = await JsonSeeder.ReadAsync<Role>("Roles");
            await dbContext.Roles.AddRangeAsync(roles);
        }

        private static async Task SeedCategoriesAsync(LibraryDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync())
            {
                return;
            }

            var categories = await JsonSeeder.ReadAsync<Category>("Categories");
            await dbContext.Categories.AddRangeAsync(categories);
        }

        private static async Task SeedImagesAsync(LibraryDbContext dbContext)
        {
            if (await dbContext.Images.AnyAsync())
            {
                return;
            }

            var images = await JsonSeeder.ReadAsync<Image>("Images");
            await dbContext.Images.AddRangeAsync(images);
        }

        private static async Task SeedBooksAsync(LibraryDbContext dbContext)
        {
            if(await dbContext.Books.AnyAsync())
            {
                return;
            }

            var books = await JsonSeeder.ReadAsync<Book>("Books");
            await dbContext.Books.AddRangeAsync(books);
        }

        private static async Task SeedMembersAsync(LibraryDbContext dbContext)
        {
            if(await dbContext.Members.AnyAsync())
            {
                return;
            }

            var members = await JsonSeeder.ReadAsync<Member>("Members");
            await dbContext.Members.AddRangeAsync(members);
        }

        private static async Task SeedTransactionsAsync(LibraryDbContext dbContext)
        {
            if(await dbContext.BookTransactions.AnyAsync())
            {
                return;
            }

            var transaction = await JsonSeeder.ReadAsync<BookTransaction>("BookTransactions");
            await dbContext.AddRangeAsync(transaction);
        }
    }
}
