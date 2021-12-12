using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ActivityLog
    {
        public int logId { get; set; }
        public int userId { get; set; }
        public int isbn { get; set; }
        public DateTime dateOfActivity { get; set; }
        public int minutesRead { get; set; }
        public string bookTitle { get; set; }
        public string bookAuthor { get; set; }
        public string bookFormat { get; set; }
        public string notes { get; set; }


    }
}
