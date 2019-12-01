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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Notification>>> GetMyNotifications([FromQuery] bool includeDismissed = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = await this.User(db);

            if (user != null)
            {
                var notificationsFromUser = db.Notifications.Where(n => n.UserId == user.Id).Where(n => includeDismissed ? true : !n.Dismissed)
                    .Include(n => n.RouterLinkParameters);
                return await notificationsFromUser.ToListAsync();
            }
            return new List<Notification>();
        }

        [HttpPut("dismiss/{notificationId}")]
        [ProducesResponseType(typeof(Notification), 200)]
        public async Task<IActionResult> DismissNotification([FromRoute] long notificationId)
        {
            User user = await this.User(db);

            if (user != null)
            {
                var notification = await db.Notifications.Where(n => n.UserId == user.Id && n.Id == notificationId).FirstOrDefaultAsync();
                if(notification != null)
                {
                    notification.Dismissed = true;
                    await db.SaveChangesAsync();
                    return Ok(notification);
                }
            }

            return Forbid();
        }
    }
}
