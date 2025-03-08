using Microsoft.EntityFrameworkCore;
using BookStore.Components.Models;

namespace BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    BookName = "Harry Potter and the Philosopher's Stone",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/HarryPotter1.png",
                    SmallDescription = "A young boy discovers he is a wizard and embarks on an adventure at Hogwarts.",
                    Price = 19.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1997, 6, 26), DateTimeKind.Utc) // ✅ Convert to UTC
                },
                new Book
                {
                    Id = 2,
                    BookName = "Harry Potter and the Chamber of Secrets",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/HarryPotter2.png",
                    SmallDescription = "Harry returns to Hogwarts for his second year, where a mysterious chamber has been opened, releasing a deadly monster.",
                    Price = 21.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1998, 7, 2), DateTimeKind.Utc) // ✅ Convert to UTC
                },
                new Book
                {
                    Id = 3,
                    BookName = "Harry Potter and the Prisoner of Azkaban",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/HarryPotter3.png",
                    SmallDescription = "Harry faces new challenges as he learns about Sirius Black, a dangerous prisoner who has escaped from Azkaban.",
                    Price = 23.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1999, 7, 8), DateTimeKind.Utc) // ✅ Convert to UTC
                }
            );
            
            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = 1, BooksId = 1 },
                new { AuthorsId = 1, BooksId = 2 },
                new { AuthorsId = 1, BooksId = 3 }
            );
        }
    }
}