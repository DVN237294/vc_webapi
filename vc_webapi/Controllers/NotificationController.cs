using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Model;
using vc_webapi.Data;
using vc_webapi.Helpers;
using Microsoft.AspNetCore.Authorization;
using vc_webapi.Model.Users;
using vc_webapi.Model.API;
using Microsoft.EntityFrameworkCore.Query;

namespace vc_webapi.Model.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public NotificationController(Vc_webapiContext context)
        {
            db = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(long userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await this.User(db);

            if (user != null)
            {
                var notificationsFromUser = db.Notifications.Where(u => user.Id == userId);
                return await notificationsFromUser.ToListAsync();
            }
            return BadRequest();
        }


    }
}
