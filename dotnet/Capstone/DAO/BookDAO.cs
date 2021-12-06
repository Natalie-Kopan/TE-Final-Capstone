using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BookDAO : IBookDAO
    {
        private const string AddBooksSql = "INSERT INTO books (isbn, title, author) VALUES (@isbn, @title, @author)";

        private readonly string connectionString;

        public BookDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Book AddBook(Book bookToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(AddBooksSql, conn))
                {
                  
                    command.Parameters.AddWithValue("@isbn", bookToAdd.ISBN);
                    command.Parameters.AddWithValue("@title", bookToAdd.Title);
                    command.Parameters.AddWithValue("@author", bookToAdd.Author);

                    command.ExecuteNonQuery();
                }
            }

            return bookToAdd;
        }

    }
}
