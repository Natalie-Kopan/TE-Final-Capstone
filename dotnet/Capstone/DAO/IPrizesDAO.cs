using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPrizesDAO
    {
        Prizes AddPrize(Prizes prizeToAdd);
        List<Prizes> GetPrizes(int family_id);
        Prizes DeletePrize(Prizes prize);
        public Prizes EditPrize(Prizes prize);

    }
}
