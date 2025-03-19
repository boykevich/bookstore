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
                new Author { Id = 3, FirstName = "Taras", LastName = "Shevchenko" },
                new Author { Id = 4, FirstName = "Isaac", LastName = "Asimov" },
                new Author { Id = 5, FirstName = "Dale", LastName = "Carnegie" },
                new Author { Id = 6, FirstName = "George", LastName = "Orwell" },
                new Author { Id = 7, FirstName = "Aldous", LastName = "Huxley" },
                new Author { Id = 8, FirstName = "Charles", LastName = "Duhigg" },
                new Author { Id = 9, FirstName = "J. R. R.", LastName = "Tolkien" },
                new Author { Id = 10, FirstName = "Frank", LastName = "Herbert" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    BookName = "Harry Potter and the Philosopher's Stone",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PotterPhilosopher'sStone.png",
                    SmallDescription = "A young boy discovers he is a wizard and embarks on an adventure at Hogwarts.",
                    Price = 00.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1997, 6, 26), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 2,
                    BookName = "Harry Potter and the Chamber of Secrets",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PotterChamberOfSecrets.png",
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
                    ImagePath = "/images/books/PotterPrisonerOfAzkaban.png",
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
                    ImagePath = "/images/books/PotterGobletOfFire.png",
                    SmallDescription = "Harry unexpectedly becomes a competitor in the dangerous Triwizard Tournament, a magical competition between three wizarding schools. As he faces deadly challenges, he also uncovers a sinister plot involving Lord Voldemort’s return to power.",
                    Price = 25.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2000, 7, 8), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 6,
                    BookName = "Harry Potter and the Order of the Phoenix",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PotterOrderofPhoenix.png",
                    SmallDescription = "Harry faces new challenges at Hogwarts and a growing threat from Lord Voldemort.",
                    Price = 27.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2003, 6, 21), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 7,
                    BookName = "Harry Potter and the Half-Blood Prince",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PotterHalf-BloodPrince.png",
                    SmallDescription = "Harry learns more about Voldemort’s past and prepares for the final battle.",
                    Price = 29.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2005, 7, 16), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 8,
                    BookName = "Harry Potter and the Deathly Hallows",
                    Genre = "Fantasy",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PotterDeathlyHallows.png",
                    SmallDescription = "Harry and his friends go on a quest to defeat Voldemort once and for all.",
                    Price = 31.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2007, 7, 21), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 9,
                    BookName = "1984",
                    Genre = "Dystopian",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/1984.png",
                    SmallDescription = "A chilling vision of a totalitarian future.",
                    Price = 18.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1949, 6, 8), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 10,
                    BookName = "Brave New World",
                    Genre = "Dystopian",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/BraveNewWorld.png",
                    SmallDescription = "A futuristic world with controlled society and loss of individuality.", 
                    Price = 17.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1932, 8, 18), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 11,
                    BookName = "The Power of Habit",
                    Genre = "Self-Improvement",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/PowerOfHabit.png",
                    SmallDescription = "Explores how habits work and how they can be changed.",
                    Price = 22.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(2012, 2, 28), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 12,
                    BookName = "The Hobbit",
                    Genre = "Adventure",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/TheHobbit.png",
                    SmallDescription = "A hobbit’s journey to reclaim a lost treasure.",
                    Price = 20.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1937, 9, 21), DateTimeKind.Utc)
                },
                new Book
                {
                    Id = 13,
                    BookName = "Dune",
                    Genre = "Science Fiction",
                    AvailableLanguage = "English",
                    ImagePath = "/images/books/Dune.png",
                    SmallDescription = "A sci-fi epic set on a desert planet.",
                    Price = 26.99m,
                    DateOfPublishment = DateTime.SpecifyKind(new DateTime(1965, 8, 1), DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = 1, BooksId = 1 },
                new { AuthorsId = 1, BooksId = 2 },
                new { AuthorsId = 1, BooksId = 3 },
                new { AuthorsId = 2, BooksId = 4 },
                new { AuthorsId = 1, BooksId = 5 },
                new { AuthorsId = 3, BooksId = 5 },
                new { AuthorsId = 1, BooksId = 6 },
                new { AuthorsId = 1, BooksId = 7 },
                new { AuthorsId = 1, BooksId = 8 },
                new { AuthorsId = 6, BooksId = 9 },
                new { AuthorsId = 7, BooksId = 10 },
                new { AuthorsId = 8, BooksId = 11 },
                new { AuthorsId = 9, BooksId = 12 },
                new { AuthorsId = 10, BooksId = 13 }
            );

            // Налаштування зв'язку PdfBook з BookId
            modelBuilder.Entity<PdfBook>()
                .HasIndex(pb => pb.BookId)
                .IsUnique(); // Кожна книжка має лише один PDF

            modelBuilder.Entity<PdfBook>().HasData(
                new PdfBook { Id = 1, BookId = 1, FilePath = "/pdf/PotterPhilosopher'sStone.pdf" },
                new PdfBook { Id = 2, BookId = 2, FilePath = "/pdf/PotterChamberOfSecrets.pdf" },
                new PdfBook { Id = 3, BookId = 3, FilePath = "/pdf/PotterPrisonerOfAzkaban.pdf" },
                new PdfBook { Id = 4, BookId = 4, FilePath = "/pdf/AtomicHabits.pdf" },
                new PdfBook { Id = 5, BookId = 5, FilePath = "/pdf/PotterGobletOfFire.pdf" },
                new PdfBook { Id = 6, BookId = 6, FilePath = "/pdf/PotterOrderOfPhoenix.pdf" },
                new PdfBook { Id = 7, BookId = 7, FilePath = "/pdf/PotterHalf-BloodPrince.pdf" },
                new PdfBook { Id = 8, BookId = 8, FilePath = "/pdf/PotterDeathlyHallows.pdf" },
                new PdfBook { Id = 9, BookId = 9, FilePath = "/pdf/1984.pdf" },
                new PdfBook { Id = 10, BookId = 10, FilePath = "/pdf/BraveNewWorld.pdf" },
                new PdfBook { Id = 11, BookId = 11, FilePath = "/pdf/ThePowerOfHabit.pdf" },
                new PdfBook { Id = 12, BookId = 12, FilePath = "/pdf/TheHobbit.pdf" },
                new PdfBook { Id = 13, BookId = 13, FilePath = "/pdf/herbert-duna.pdf" }
            );
        }
    }
}
