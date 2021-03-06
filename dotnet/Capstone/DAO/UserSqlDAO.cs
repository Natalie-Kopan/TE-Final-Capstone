using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        private string sqlAddFamily = "INSERT INTO family (family_name) VALUES (@family_name); SELECT @@IDENTITY";
        private string sqlGetUser = "SELECT user_id, username, password_hash, salt, user_role FROM users WHERE username = @username";
        private string sqlAddUser = "INSERT INTO users (username, password_hash, salt, family_id, user_role) VALUES " +
            "(@username, @password_hash, @salt, @family_id, @user_role)";
        private string sqlGetFamilyId = "SELECT family_id FROM users WHERE user_id = @user_id";
        private string sqlGetFamilyMembers = "SELECT user_id, username, user_role FROM users WHERE family_id = @family_id";

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnUser = GetUserFromReader(reader);
                }
            }

            return returnUser;
        }

        /// <summary>
        ///  RegisterUser Calls this method to create a user and add it to the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="family_id"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public User AddUser(string username, string password, int family_id, string role)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                cmd.Parameters.AddWithValue("@salt", hash.Salt);
                cmd.Parameters.AddWithValue("@family_id", family_id);
                cmd.Parameters.AddWithValue("@user_role", role);
                cmd.ExecuteNonQuery();
            }

            return GetUser(username);
        }

        /// <summary>
        /// This method creates a family and then adds the user (using the AddUser method) with the family ID
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="familyName"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public User RegisterUserAndFamily(string username, string password, string familyName)
        {
            int familyId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddFamily, conn);
                cmd.Parameters.AddWithValue("@family_name", familyName);
                familyId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return AddUser(username, password, familyId, "parent");
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }

        public int GetUserFamilyId(int userId)
        {
            int familyId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetFamilyId, conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                familyId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return familyId;
        }
        public List<ReturnUser> GetUserFamilyMembers(int familyId)
        {
            List<ReturnUser> familyMembers = new List<ReturnUser>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlGetFamilyMembers, conn))
                {
                    command.Parameters.AddWithValue("@family_id", familyId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReturnUser familyMember = new ReturnUser();
                            familyMember.UserId = (int)Convert.ToInt32(reader["user_id"]);
                            familyMember.Username = Convert.ToString(reader["username"]);
                            familyMember.Role = Convert.ToString(reader["user_role"]);
                            familyMembers.Add(familyMember);
                        }
                    }
                }
            }
            return familyMembers;
        }
    }
}
