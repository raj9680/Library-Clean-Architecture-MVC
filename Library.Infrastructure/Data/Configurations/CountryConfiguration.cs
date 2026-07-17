using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Configurations
{
    public static class CountryConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                // Table Name
                entity.ToTable("Countries");

                // Primary Key
                entity.HasKey(x => x.Id);

                /* Properties Constraints
                
                    entity.Property(x => x.Name)
                          .HasMaxLength(40)
                          .IsRequired();

                */

                /* Relationships
                  
                1. One to Many:

                    entity.HasOne(x => x.Author)
                      .WithMany(x => x.Books)
                      .HasForeignKey(x => x.AuthorId);

                --> Using Entities
                
                public class Author
                {
                    public Guid Id { get; set; }
                    public ICollection<Book> Books { get; set; } = new();
                 }

                public class Book
                {
                    public Guid Id { get; set; }
                    public Guid AuthorId { get; set; }
                    public Author Author { get; set; } = null!;
                }

                Book has one Author.
                Author has many Books.
                AuthorId is the foreign key.

                ---

                2. One to One:

                    entity.HasOne(x => x.User)
                        .WithOne(x => x.Profile)
                        .HasForeignKey<Profile>(x => x.UserId);
                    

                -> Using Entities

                public class User
                {
                    public Guid Id { get; set; }
                    public Profile Profile { get; set; } = null!;
                 }

                public class Profile
                {
                    public Guid Id { get; set; }
                    public Guid UserId { get; set; }
                    public User User { get; set; } = null!;
                }

                Profile has one User.
                User has one Profile.
                UserId is the foreign key.

                ---

                3. Many to Many
                    
                    entity.HasMany(x => x.Courses)
                        .WithMany(x => x.Students);


                -> using Entities:

                public class Student
                {
                    public Guid Id { get; set; }

                    public ICollection<Course> Courses { get; set; } = new();
                 }

                public class Course
                {
                    public Guid Id { get; set; }
                    public ICollection<Student> Students { get; set; } = new();
                }

                Student has many Courses.
                Course has many Students.


                used in this app.
                    //entity.HasOne(x => x.Category)
                    //      .WithMany(x => x.Books)
                    //      .HasForeignKey(x => x.CategoryId);

                    //entity.HasOne(x => x.Cover)
                    //      .WithMany(x => x.Books)
                    //      .HasForeignKey(x => x.CoverId);
                */

            });
        }
    }
}