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
        public ActionResult ViewActivityByBook(string isbn)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            List<ActivityLog> logs = activityDAO.ViewActivityLogByBook(userId, isbn);
            
            return Ok(logs);
        }

        [HttpGet("{userId}/{isbn}")]
        [Authorize]
        public ActionResult ViewActivityByBookAndUserId(string isbn, int userId)
        {
            List<ActivityLog> logs = activityDAO.ViewActivityLogByBook(userId, isbn);

            return Ok(logs);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public ActionResult ViewActivityByUser(int userId)
        {
            List<ActivityLog> logs = activityDAO.ViewActivityLogByUser(userId);

            return Ok(logs);
        }
            
        [HttpPost("{isbn}")]
        [Authorize]
        public ActionResult AddActivityToBook(ActivityLog activity, string isbn)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            ActivityLog log = activityDAO.AddActivity(activity, userId, isbn);

            return Created("/activity/" + log.isbn, log);
        }

        [HttpPost("{userId}/{isbn}")]
        [Authorize]
        public ActionResult AddActivityToBookByUserId(ActivityLog activity, string isbn, int userId)
        {
            ActivityLog log = activityDAO.AddActivity(activity, userId, isbn);

            return Created("/activity/" + log.isbn, log);
        }
    }
}
