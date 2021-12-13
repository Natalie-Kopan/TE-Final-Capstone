using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Prizes
    {
        public int prizeId { get; set; }
        public int familyId { get; set; }
        public string description { get; set; }
        public string prizeTitle { get; set; }
        public string userGroup { get; set; }
        public int milestone { get; set; }
        public int maxPrize { get; set;}
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
