using System;

namespace Library.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bookshelf bookshelf = new Bookshelf();
            Console.WriteLine("Welcome to your bookshelf.");
            Console.WriteLine("Commands: show, add, remove, sort shelf, sort all, exit");
            Console.WriteLine();

            while (true)
            {
                string command = Console.ReadLine();
                string title;
                int shelf;
                switch (command)
                {
                    case "show":
                        bookshelf.ShowBookshelf();
                        break;
                    case "add":
                        Console.WriteLine("Type in the title of the book:");
                        title = Console.ReadLine();
                        Console.WriteLine("\nHow many pages is the book?");
                        int numPages = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nWhich shelf would you like to put it in? (1, 2, or 3)");
                        shelf = int.Parse(Console.ReadLine());
                        bookshelf.AddBook(new Book(title, numPages), shelf);
                        Console.WriteLine();
                        break;
                    case "remove":
                        Console.WriteLine("Type in the title of the book you would like to remove:");
                        title = Console.ReadLine();
                        bookshelf.RemoveBook(title);
                        Console.WriteLine();
                        break;
                    case "sort shelf":
                        Console.WriteLine("Which shelf would you like to sort? (1, 2, or 3)");
                        shelf = int.Parse(Console.ReadLine());
                        bookshelf.SortShelf(shelf);
                        Console.WriteLine();
                        break;
                    case "sort all":
                        bookshelf.SortAll();
                        Console.WriteLine();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case default:
                        Console.WriteLine("That is not a command.");
                        Console.WriteLine("Commands: show, add, remove, sort shelf, sort all, exit");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
