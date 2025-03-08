using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Components.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new List<Author>();

        [Column(TypeName = "timestamp with time zone")] // ✅ Ensures PostgreSQL stores it correctly
        public DateTime DateOfPublishment 
        { 
            get => _dateOfPublishment;
            set => _dateOfPublishment = DateTime.SpecifyKind(value, DateTimeKind.Utc); // ✅ Ensure UTC conversion
        }
        private DateTime _dateOfPublishment = DateTime.UtcNow; // ✅ Default to UTC

        public string Genre { get; set; } = string.Empty;
        public string AvailableLanguage { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string SmallDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}