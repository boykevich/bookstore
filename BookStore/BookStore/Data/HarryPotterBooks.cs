using BookStore.Components.Models;

namespace BookStore.Data
{
    public class HarryPotterBooks
    {
        public List<Book> Books { get; } = new()
        {
            new Book(1, "Harry Potter and the Philosopher's Stone",
                new List<Author> { new Author("J.K.", "Rowling") },
                new DateTime(1997, 6, 26), "Fantasy",
                new List<string> { "English", "Ukrainian", "French" },
                "/images/books/HarryPotter1.png",
                "A young boy discovers he is a wizard and embarks on an adventure at Hogwarts.",
                19.99m),

            new Book(2, "Harry Potter and the Chamber of Secrets",
                new List<Author> { new Author("J.K.", "Rowling") },
                new DateTime(1998, 7, 2), "Fantasy",
                new List<string> { "English", "Spanish", "German" },
                "/images/books/HarryPotter2.png",
                "Harry returns to Hogwarts for his second year, where a mysterious chamber has been opened, releasing a deadly monster.",
                21.99m),

            new Book(3, "Harry Potter and the Prisoner of Azkaban",
                new List<Author> { new Author("J.K.", "Rowling") },
                new DateTime(1999, 7, 8), "Fantasy",
                new List<string> { "English", "French", "Italian" },
                "/images/books/HarryPotter3.png",
                "Harry faces new challenges as he learns about Sirius Black, a dangerous prisoner who has escaped from Azkaban.",
                23.99m)
        };
    }
}
