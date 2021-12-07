using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookDAO bookDAO;

        public BookController(IBookDAO book)
        {
            this.bookDAO = book;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddNewBook(Book bookToAdd)
        {
          int userId = int.Parse(this.User.FindFirst("sub").Value);
          Book addBook = new Book();

            try
            {
                addBook = bookDAO.AddBook(bookToAdd, userId);
            }
            catch (SqlException)
            {
                return BadRequest(new { message = "This book either already exists or is invalid" });
            }
            
            return Created("/book/" + addBook.ISBN, addBook);
        }

        /// <summary>
        /// get all book
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult GetAllUserBooks()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            IEnumerable<Book> allBooks = bookDAO.GetBooks(userId);
            return Ok(allBooks);
        }
    }
}
