using BookStore.Components.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<PurchasedBook> PurchasedBooks { get; set; } = new List<PurchasedBook>();
}