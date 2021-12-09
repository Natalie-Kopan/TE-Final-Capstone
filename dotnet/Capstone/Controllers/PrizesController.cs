using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrizesController: ControllerBase
    {
        private readonly IPrizesDAO prizesDAO;
        private readonly IUserDAO userDAO;

        public PrizesController(IPrizesDAO prizes, IUserDAO user)
        {
            this.prizesDAO = prizes;
            this.userDAO = user;
        }

        [HttpPost("{familyId}")]
        [Authorize]
        public ActionResult AddNewPrize(Prizes prizeToAdd)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            Prizes newPrize = new Prizes();
            try
            {
                newPrize = prizesDAO.AddPrize(prizeToAdd);
            }
            catch (SqlException)
            {
                return BadRequest(new { message = "The prize entered is invalid" });
            }

            return Created("/prize/" + prizeToAdd.familyId, prizeToAdd);
        }


        //Getting the FamilyID from Prizes
        [HttpGet]
        public ActionResult GetAllFamilyPrizes()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            int familyId = userDAO.GetUserFamilyId(userId);

            IEnumerable<Prizes> allFamilyPrizes = prizesDAO.GetPrizes(familyId);
            return Ok(allFamilyPrizes);
            
        }

    }
}
