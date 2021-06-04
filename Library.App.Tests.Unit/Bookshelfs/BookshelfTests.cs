using System;
using System.Collections.Generic;
using System.Text;

namespace Library.App.Tests.Unit.Bookshelfs
{
    public partial class BookshelfTests
    {
        public string GenerateRandomString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            char letter;
            int length = random.Next(1, 11);

            for (int i = 0; i < length; i++)
            {
                int letterNumber = random.Next(1, 27);
                letter = Convert.ToChar(letterNumber + 65);
                stringBuilder.Append(letter);
            }

            return stringBuilder.ToString();
        }

        public int GenerateRandomNumber() => new Random().Next(25, 1001);

        public Book CreateRandomBook() => new Book(GenerateRandomString(), GenerateRandomNumber());
    }
}
