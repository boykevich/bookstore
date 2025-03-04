namespace BookStore.Components.Models
{
    public record Author (string FirstName, string LastName)
    {
        public string FullName()
        {
            return FirstName + LastName;
        }
    }
}
