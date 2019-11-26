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

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public CommentsController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(string message, long videoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await this.User(db);
            if (user != null)
            {
                var video = await db.Videos.FindAsync(videoId);
                if (video != null)
                {
                    db.Comments.Add(new Comment
                    {
                        User = user,
                        CommentTime = DateTime.UtcNow,
                        Message = message,
                        Video = video

                    });
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet("{videoId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsFromAVideo([FromRoute] long videoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await this.User(db);
            var video = await db.Videos.FindAsync(videoId);

            if (video == null)
            {
                return NotFound();
            }

            var comments = await db.Comments.Where(i => i.Video.Id == videoId)
                .Include(c => c.User)
                .ToListAsync();

            if (user != null)
            {
                foreach (var comment in comments)
                {
                    comment.Deletable = comment.User.Id == user.Id || user is Admin;
                }
            }

            return comments;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await this.User(db);
            var comment = await db.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.User.Id != user.Id && !(user is Admin))
            {
                return Forbid();
            }

            db.Comments.Remove(comment);
            await db.SaveChangesAsync();

            return Ok(comment);
        }

    }
}
    

       