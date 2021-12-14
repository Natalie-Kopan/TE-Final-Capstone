using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IActivityDAO
    {
        ActivityLog AddActivity(ActivityLog activity, int userId, string isbn);
        List<ActivityLog> ViewActivityLogByBook(int userId, string isbn);
        List<ActivityLog> ViewActivityLogByUser(int userId);
    }
}
