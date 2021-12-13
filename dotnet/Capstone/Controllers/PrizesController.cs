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

        [HttpPost()]
        [Authorize]
        public ActionResult AddNewPrize(Prizes prizeToAdd)
        {

            if(prizeToAdd.startDate >= prizeToAdd.endDate)
            {
                return BadRequest();
            }
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            int familyId = userDAO.GetUserFamilyId(userId);
            prizeToAdd.familyId = familyId;
            Prizes newPrize = new Prizes();
            try
            {
                newPrize = prizesDAO.AddPrize(prizeToAdd);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { message = "The prize entered is invalid" });
            }

            return Created("/Prizes", prizeToAdd);
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
        [HttpDelete("{id:int}")]
        public ActionResult DeletePrize(int prizeIdToDelete)
        {
            int prizeId = prizesDAO.DeletePrize(prizeIdToDelete);
            return NoContent();
        }
        [HttpPut]
        public ActionResult EditPrize(Prizes prize)
        {

            Prizes editedPrize = prizesDAO.EditPrize(prize);
            return Ok();
        }
    }
}
