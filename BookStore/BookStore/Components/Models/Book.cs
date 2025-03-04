namespace BookStore.Components.Models
{
    public  record Book
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 10)
                {
                    _name = value;
                }
            }
        }
    }
}
