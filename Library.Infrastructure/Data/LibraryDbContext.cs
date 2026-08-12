using Library.Domain.Entities;
using Library.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    /// <summary>
    /// Responsibilities:
    /// DbSets
    /// Relationships
    /// Table names
    /// Fluent API
    /// Nothing else
    /// </summary>
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(
            DbContextOptions<LibraryDbContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurations
            CountryConfiguration.Configure(modelBuilder);
            AuthorConfiguration.Configure(modelBuilder);
            BookConfiguration.Configure(modelBuilder);
        }
    }
}
