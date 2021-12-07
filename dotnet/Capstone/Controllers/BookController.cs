﻿using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            Book addBook = bookDAO.AddBook(bookToAdd, userId);
            return Created("/book/" + addBook.ISBN, addBook);
        }

        
    }
}
