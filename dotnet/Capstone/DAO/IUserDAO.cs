using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, int familyId, string role);
        User RegisterUserAndFamily(string username, string password, string familyName);
        int GetUserFamilyId(int userId);
    }
}
