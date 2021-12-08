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
        private readonly string connectionString;

        public BookDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private const string AddBooksSql = "INSERT INTO books (isbn, title, author) VALUES (@isbn, @title, @author)";
        private const string AddUserBookSql = "INSERT INTO user_books(isbn, user_id) VALUES(@isbn, @user_id)";
        private const string getUserBooks = "SELECT b.isbn, b.title, b.author FROM books b " +
            "INNER JOIN user_books ub ON ub.isbn = b.isbn " +
            "WHERE ub.user_id = @user_id";
        private const string getBookByIsbn = "SELECT b.isbn, b.title, b.author FROM books b " +
            "WHERE b.isbn = @isbn";


        public Book AddBook(Book bookToAdd, int user_id)
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

                using (SqlCommand command = new SqlCommand(AddUserBookSql, conn))
                {

                    command.Parameters.AddWithValue("@isbn", bookToAdd.ISBN);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }
            }
            return bookToAdd;
        }

        public List<Book> GetBooks(int userId)
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(getUserBooks, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.ISBN = (int)Convert.ToInt64(reader["isbn"]);
                            book.Author = Convert.ToString(reader["author"]);
                            book.Title = Convert.ToString(reader["title"]);
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
    }
}
