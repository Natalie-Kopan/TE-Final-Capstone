using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBookDAO
    {
        Book AddBook(Book bookToAdd, int userId);
        List<Book> GetBooks(int userId);

    }
}
