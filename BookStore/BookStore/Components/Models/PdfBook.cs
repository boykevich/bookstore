using System.ComponentModel.DataAnnotations;

namespace BookStore.Components.Models
{
    public class PdfBook
    {
        [Key]
        public int Id { get; set; } // Унікальний ідентифікатор запису

        [Required]
        public int BookId { get; set; } // Ідентифікатор книжки, до якої належить PDF

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; } = string.Empty; // Шлях до файлу PDF
    }

}
