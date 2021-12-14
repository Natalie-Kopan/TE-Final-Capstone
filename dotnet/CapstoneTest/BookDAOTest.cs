using Capstone.DAO;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTest
{
    [TestClass]
    public class BookDAOTest: SqlDaoTestBase
    {
        [TestMethod]
        public void AddBookTest()
        {
            //Arrange
            BookDAO input = new BookDAO(ConnectionString);
            Book book = new Book();
            book.Author = "test";
            book.Title = "test";
            book.ISBN = "100000";

            //Act
            Book addedBook = input.AddBook(book, 1);

            //Assert
            Assert.IsNotNull(addedBook);

        }
    }
}
