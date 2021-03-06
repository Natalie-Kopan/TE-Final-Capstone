using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ActivityDAO : IActivityDAO 
    {
        private readonly string connectionString;

        public ActivityDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private const string AddActivityLogSql = "INSERT INTO reading_log (user_id, book_format, minutes_read, isbn, notes) " +
            "VALUES(@user_id, @book_format, @minutes_read, @isbn, @notes)";
        private const string ViewActivityLogByBookSql = "SELECT b.title, b.author, rl.log_id, rl.minutes_read, rl.date_of_activity, " +
            "rl.isbn, rl.book_format, rl.notes FROM reading_log rl INNER JOIN books b ON rl.isbn = b.isbn " +
            "WHERE rl.user_id = @user_id AND rl.isbn = @isbn";
        private const string ViewActivityLogByUserSql = "SELECT b.title, b.author, rl.log_id, rl.minutes_read, rl.date_of_activity, " +
            "rl.isbn, rl.book_format, rl.notes FROM reading_log rl INNER JOIN books b ON rl.isbn = b.isbn " +
            "WHERE rl.user_id = @user_id";

        public ActivityLog AddActivity(ActivityLog activity, int userId, string isbn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(AddActivityLogSql, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@book_format", activity.bookFormat);
                    command.Parameters.AddWithValue("@minutes_read", activity.minutesRead);
                    command.Parameters.AddWithValue("@notes", activity.notes);
                    command.Parameters.AddWithValue("@isbn", isbn);

                    command.ExecuteNonQuery();
                }
            }
            return activity;
        }

        public List<ActivityLog> ViewActivityLogByBook(int userId, string isbn)
        {
            List<ActivityLog> logs = new List<ActivityLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(ViewActivityLogByBookSql, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@isbn", isbn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ActivityLog log = new ActivityLog();
                            log.bookTitle = Convert.ToString(reader["title"]);
                            log.bookAuthor = Convert.ToString(reader["author"]);
                            log.logId = Convert.ToInt32(reader["log_id"]);
                            log.minutesRead = Convert.ToInt32(reader["minutes_read"]);
                            log.isbn = Convert.ToString(reader["isbn"]);
                            log.bookFormat = Convert.ToString(reader["book_format"]);
                            log.notes = Convert.ToString(reader["notes"]);
                            log.dateOfActivity = Convert.ToDateTime(reader["date_of_activity"]);
                            log.userId = userId;
                            logs.Add(log);
                        }
                    }
                }
            }
            return logs;
        }

        public List<ActivityLog> ViewActivityLogByUser(int userId)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(ViewActivityLogByUserSql, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ActivityLog log = new ActivityLog();
                            log.bookTitle = Convert.ToString(reader["title"]);
                            log.bookAuthor = Convert.ToString(reader["author"]);
                            log.logId = Convert.ToInt32(reader["log_id"]);
                            log.minutesRead = Convert.ToInt32(reader["minutes_read"]);
                            log.isbn = Convert.ToString(reader["isbn"]);
                            log.bookFormat = Convert.ToString(reader["book_format"]);
                            log.notes = Convert.ToString(reader["notes"]);
                            log.dateOfActivity = Convert.ToDateTime(reader["date_of_activity"]);
                            log.userId = userId;
                            logs.Add(log);
                        }
                    }
                }
            }
            return logs;
        }
    }
}
