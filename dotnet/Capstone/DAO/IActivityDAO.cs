using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IActivityDAO
    {
        ActivityLog AddActivity(ActivityLog activity, int userId, int isbn);
        ActivityLog ViewActivityLogByBook(int userId, int isbn);
    }
}
