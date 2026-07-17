using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Configurations
{
    public static class AuthorConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                // Table Name
                entity.ToTable("Authors");

                // Primary Key
                entity.HasKey(entity => entity.Id);

                // Relationship
                // This is the only relation we implemeneted in this app using FLuent API, rest all are in Entity
                entity.HasOne(x => x.Country)
                    .WithMany(x => x.Authors)
                    .HasForeignKey(x => x.CountryId);
            });
        }
    }
}
