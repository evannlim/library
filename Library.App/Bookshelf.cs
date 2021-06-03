using System;
using System.Collections.Generic;

namespace Library.App
{
    class Bookshelf
    {
        List<Book> shelf1 = new List<Book>();
        List<Book> shelf2 = new List<Book>();
        List<Book> shelf3 = new List<Book>();

        //Represents how many pages one shelf can fit.
        int NumberPages;

        /*
         * Constructor for the bookshelf. Sets the number of pages a shelf can hold.
         */
        public Bookshelf(int NumberPages = 1000)
        {
            this.NumberPages = NumberPages;
        }

        /*
         * Displays the entire bookshelf in the console.
         */
        public void ShowBookshelf()
        {
            for (int i = 1; i <= 3; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Shelf 1:");
                        if (shelf1.Count != 0)
                        {
                            for (int j = 0; j < shelf1.Count; j++)
                                Console.WriteLine(shelf1[j].Title);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Shelf 2:");
                        if (shelf2.Count != 0)
                        {
                            for (int j = 0; j < shelf2.Count; j++)
                                Console.WriteLine(shelf2[j].Title);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Shelf 3:");
                        if (shelf3.Count != 0)
                        {
                            for (int j = 0; j < shelf3.Count; j++)
                                Console.WriteLine(shelf3[j].Title);
                        }
                        break;
                }
                Console.WriteLine();
            }
        }

        /*
         * Adds a book to a shelf. If the shelf is full, then it doesn't add the book.
         */
        public void AddBook(Book book, int shelfNumber)
        {
            if (NumberOfPagesInShelf(shelfNumber) + book.NumberOfPages <= NumberPages)
            {
                switch (shelfNumber)
                {
                    case 1:
                        shelf1.Add(book);
                        break;
                    case 2:
                        shelf2.Add(book);
                        break;
                    case 3:
                        shelf3.Add(book);
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"\"{book.Title}\" successfully added to shelf {shelfNumber}.");
            }
            else
                Console.WriteLine($"\"{book.Title}\" cannot fit in shelf.");
        }

        /*
         * Removes all instances of books with the given title.
         */
        public void RemoveBook(string title)
        {
            bool removed = false;
            for (int i = shelf1.Count - 1; i >= 0; i--)
                if (shelf1[i].Title.Equals(title))
                {
                    shelf1.RemoveAt(i);
                    removed = true;
                }
            for (int i = shelf2.Count - 1; i >= 0; i--)
                if (shelf2[i].Title.Equals(title))
                {
                    shelf2.RemoveAt(i);
                    removed = true;
                }
            for (int i = shelf2.Count - 1; i >= 0; i--)
                if (shelf2[i].Title.Equals(title))
                {
                    shelf2.RemoveAt(i);
                    removed = true;
                }
            if (removed)
                Console.WriteLine($"All instances of \"{title}\" successfully removed.");
            else
                Console.WriteLine($"No book with the title \"{title}\" found.");
        }

        /*
         * Sorts a shelf alphabetically.
         */
        public void SortShelf(int shelfNumber)
        {
            switch (shelfNumber)
            {
                case 1:
                    shelf1.Sort(CompareBook);
                    break;
                case 2:
                    shelf2.Sort(CompareBook);
                    break;
                case 3:
                    shelf3.Sort(CompareBook);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Shelf " + shelfNumber + " sorted.");
        }

        /*
         * Sorts every book across all the shelves. Writes the number of books that cannot fit in the bookshelf due to space limitation.
         */
        public void SortAll()
        {
            List<Book> allBooks = new List<Book>();
            for (int i = shelf1.Count - 1; i >= 0; i--)
                allBooks.Add(shelf1[i]);
            for (int i = shelf2.Count - 1; i >= 0; i--)
                allBooks.Add(shelf2[i]);
            for (int i = shelf3.Count - 1; i >= 0; i--)
                allBooks.Add(shelf3[i]);
            shelf1.Clear();
            shelf2.Clear();
            shelf3.Clear();
            allBooks.Sort(CompareBook);

            int shelf = 1;
            int lostBooks = 0;
            if (allBooks.Count > 0)
            {
                for (int i = 0; i < allBooks.Count; i++)
                {
                    if (shelf == 4)
                    {
                        lostBooks++;
                    }
                    else if (NumberOfPagesInShelf(shelf) + allBooks[i].NumberOfPages > NumberPages)
                    {
                        shelf++;
                    }
                    if (shelf <= 3)
                    {
                        switch (shelf)
                        {
                            case 1:
                                shelf1.Add(allBooks[i]);
                                break;
                            case 2:
                                shelf2.Add(allBooks[i]);
                                break;
                            case 3:
                                shelf3.Add(allBooks[i]);
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Bookshelf completely sorted. " + lostBooks + " lost books");
        }

        /*
         * Counts the number of pages in a shelf based on the books. If a wrong shelf number is given, returns -1.
         * 
         * @return number of pages that the shelf is currently holding
         */
        private int NumberOfPagesInShelf(int shelfNumber)
        {
            int pages = 0;
            switch (shelfNumber)
            {
                case 1:
                    for (int i = shelf1.Count - 1; i >= 0; i--)
                        pages += shelf1[i].NumberOfPages;
                    break;
                case 2:
                    for (int i = shelf2.Count - 1; i >= 0; i--)
                        pages += shelf2[i].NumberOfPages;
                    break;
                case 3:
                    for (int i = shelf3.Count - 1; i >= 0; i--)
                        pages += shelf3[i].NumberOfPages;
                    break;
                default:
                    return -1;
            }
            return pages;
        }

        /*
         * Compares books based on title. Used to sort the lists.
         */
        private int CompareBook(Book book1, Book book2) => book1.Title.CompareTo(book2.Title);
    }
}
