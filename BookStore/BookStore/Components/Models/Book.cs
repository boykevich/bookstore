namespace BookStore.Components.Models
{
    public record Book(string BookName, List<Author> Authors, DateTime DateOfPublishment, string Genre, string Language);
}
