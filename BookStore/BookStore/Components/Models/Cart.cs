using System.Collections.Generic;

namespace BookStore.Components.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; // Зв’язок з ApplicationUser (звичайно, його ID — рядок)
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
