using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        public FamilyController(IUserDAO _userDAO)
        {
            userDAO = _userDAO;
        }
        [HttpPost()]
        public IActionResult AddFamilyMember(RegisterFamily familyMem)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            int familyId = userDAO.GetUserFamilyId(userId);

            User newMember = userDAO.AddUser(familyMem.Username, familyMem.Password, familyId, familyMem.Role);

            return Created("/", newMember);
        }
        [HttpGet()]
        public IActionResult GetFamilyMembers()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            int familyId = userDAO.GetUserFamilyId(userId);
            IEnumerable<ReturnUser> familyMembers = userDAO.GetUserFamilyMembers(familyId);
            return Ok(familyMembers);
        }
    }
}
