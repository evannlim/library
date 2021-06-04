namespace Library.App
{
    public class Book
    {
        public string Title { get; set; }
        public int NumberOfPages { get; set; }

        public Book(string title, int numberOfPages)
        {
            Title = title;
            NumberOfPages = numberOfPages;
        }
    }
}
