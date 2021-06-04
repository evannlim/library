using System;
using System.Threading.Tasks;
using Xunit;
using Library.App;
using System.Collections.Generic;

namespace Library.App.Tests.Unit.Bookshelfs
{
    public partial class BookshelfTests
    {
        [Fact]
        public void ShouldAddBook()
        {
            //given
            Book randomBook = CreateRandomBook();
            Bookshelf testBookshelf = new Bookshelf();
            int randomShelf = new Random().Next(1, 4);
            List<Book> updatedShelf = new List<Book>();
            updatedShelf.Add(randomBook);

            //when
            testBookshelf.AddBook(randomBook, randomShelf);

            //then
            List<Book> testShelf;
            switch(randomShelf)
            {
                case 1:
                    testShelf = testBookshelf.GetShelf1();
                    break;
                case 2:
                    testShelf = testBookshelf.GetShelf2();
                    break;
                case 3:
                    testShelf = testBookshelf.GetShelf3();
                    break;
                default:
                    testShelf = new List<Book>();
                    break;
            }
            Assert.Equal(updatedShelf, testShelf);
        }
    }
}
