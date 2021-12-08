using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityDAO activityDAO;

        public ActivityController(IActivityDAO log)
        {
            this.activityDAO = log;
        }

        [HttpGet("{isbn}")]
        [Authorize]
        public ActionResult ViewActivityByBook(int isbn)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            ActivityLog log = activityDAO.ViewActivityLogByBook(userId, isbn);
            
            return Ok(log);
        }

        [HttpPost("{isbn}")]
        [Authorize]
        public ActionResult AddActivityToBook(ActivityLog activity, int isbn)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            ActivityLog log = activityDAO.AddActivity(activity, userId, isbn);

            return Created("/activity/" + log.isbn, log);
        }
    }
}
