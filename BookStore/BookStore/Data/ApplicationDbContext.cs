using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Components.Models;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PdfBook> PdfBooks { get; set; }
        public DbSet<PurchasedBook> PurchasedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling" },
                new Author { Id = 2, FirstName = "James", LastName = "Clear" },
                new Author { Id = 3, FirstName = "Taras", LastName = "Shevchenko" }
            );

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
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1997, 6, 26), DateTimeKind.Utc)
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
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1998, 7, 2), DateTimeKind.Utc)
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
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1999, 7, 8), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 4,
                    BookName = "Atomic Habits",
                    Genre = "Self-Improvement",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/AtomicHabits.png",
                    SmallDescription = "A practical guide on how tiny changes can lead to remarkable results in life and productivity.",
                    Price = 25.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2018, 10, 16), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 5,
                    BookName = "Harry Potter and the Goblet of Fire",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/HarryPotter4.png",
                    SmallDescription = "Harry unexpectedly becomes a competitor in the dangerous Triwizard Tournament, a magical competition between three wizarding schools. As he faces deadly challenges, he also uncovers a sinister plot involving Lord Voldemort’s return to power.",
                    Price = 25.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2000, 7, 8), DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = 1, BooksId = 1 },
                new { AuthorsId = 1, BooksId = 2 },
                new { AuthorsId = 1, BooksId = 3 },
                new { AuthorsId = 2, BooksId = 4 },
                new { AuthorsId = 1, BooksId = 5 },
                new { AuthorsId = 3, BooksId = 5 }
            );

            // Налаштування зв'язку PdfBook з BookId
            modelBuilder.Entity<PdfBook>()
                .HasIndex(pb => pb.BookId)
                .IsUnique(); // Кожна книжка має лише один PDF

            modelBuilder.Entity<PdfBook>().HasData(
                new PdfBook { Id = 1, BookId = 1, FilePath = "/pdf/HarryPotter1.pdf" },
                new PdfBook { Id = 2, BookId = 2, FilePath = "/pdf/HarryPotter2.pdf" },
                new PdfBook { Id = 3, BookId = 3, FilePath = "/pdf/HarryPotter3.pdf" }

            );
        }
    }
}
