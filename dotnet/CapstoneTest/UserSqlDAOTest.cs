using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.DAO;
using Capstone.Models;

namespace CapstoneTest
{
    [TestClass]
    public class UserSqlDAOTest : SqlDaoTestBase
    {
        [TestMethod]
        public void GetUserTest()
        {
            UserSqlDAO access = new UserSqlDAO(ConnectionString);

            User user = access.GetUser("user");

            Assert.IsNotNull(user);

            Assert.AreEqual("user", user.Role);
        }

        [TestMethod]
        public void AddUserTest()
        {
            UserSqlDAO access = new UserSqlDAO(ConnectionString);

            User user = access.AddUser("anotheruser", "password", 1, "admin");

            Assert.IsNotNull(user);

            Assert.AreEqual("admin", user.Role);

            user = access.GetUser("anotheruser");

            Assert.IsNotNull(user);

            Assert.AreEqual("admin", user.Role);
        }

        [TestMethod]
        public void AddUserWithoutValidRoleThrowsExceptionTest()
        {
            Assert.ThrowsException<SqlException>(() =>
            {
                UserSqlDAO access = new UserSqlDAO(ConnectionString);

                User user = access.AddUser("anotheruser", "password", 1, "notarole");
            });
        }

        [TestMethod]
        public void AddUserAndAssignToFamilyTest()
        {
            UserSqlDAO access = new UserSqlDAO(ConnectionString);

            User user = access.RegisterUser("john", "password", "Doe", "user");

            Assert.AreEqual("john", user.Username);
        }
    }
}
