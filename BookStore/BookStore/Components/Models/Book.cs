namespace BookStore.Components.Models
{
    public record Book(int Id, string BookName, List<Author> Authors, DateTime DateOfPublishment, string Genre, List<string> AvailableLanguages, string ImagePath, string SmallDescription, decimal Price);
}
