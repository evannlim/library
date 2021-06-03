using System;

namespace Library.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bookshelf bookshelf = new Bookshelf();
            Console.WriteLine("Hi there. Welcome to your bookshelf.");
            Console.WriteLine("Commands: show, add, remove, sort shelf, sort all, exit");
            Console.WriteLine("\n");

            while (true)
            {
                string command = Console.ReadLine();
                string title;
                int shelf;
                switch (command)
                {
                    case "show":
                        Console.WriteLine();
                        bookshelf.ShowBookshelf();
                        Console.WriteLine();
                        break;
                    case "add":
                        Console.WriteLine("\nType in the title of the book:");
                        title = Console.ReadLine();
                        Console.WriteLine("\nHow many pages is the book?");
                        int numPages = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nWhich shelf would you like to put it in? (1, 2, or 3)");
                        shelf = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        bookshelf.AddBook(new Book(title, numPages), shelf);
                        Console.WriteLine("\n");
                        break;
                    case "remove":
                        Console.WriteLine("\nType in the title of the book you would like to remove:");
                        title = Console.ReadLine();
                        Console.WriteLine();
                        bookshelf.RemoveBook(title);
                        Console.WriteLine("\n");
                        break;
                    case "sort shelf":
                        Console.WriteLine("\nWhich shelf would you like to sort? (1, 2, or 3)");
                        shelf = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        bookshelf.SortShelf(shelf);
                        Console.WriteLine("\n");
                        break;
                    case "sort all":
                        Console.WriteLine();
                        bookshelf.SortAll();
                        Console.WriteLine("\n");
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nThat is not a command.");
                        Console.WriteLine("Commands: show, add, remove, sort shelf, sort all, exit");
                        Console.WriteLine("\n");
                        break;
                }
            }
        }
    }
}
