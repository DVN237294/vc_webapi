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
        public async Task<IActionResult> CreateComment(string message, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var video = await db.Videos.FindAsync(id);

            User user = await this.User(db);

            if (user != null)
            {
                if (video != null)
                {
                    db.Comments.Add(new Comment
                    {
                        User = user,
                        UserName = user.UserName,
                        CommentTime = DateTime.Now,
                        Message = message,
                        Video = video

                    });
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            return Unauthorized();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsFromAVideo([FromRoute] long id)
        {
            var video = await db.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            if (video != null)
            {
                var commentsFromVideo = db.Comments.Where(i => i.Video.Id == id);
                return await commentsFromVideo.ToListAsync();
            }
            return Unauthorized();

        }

        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {                
            return db.Comments;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await this.User(db) is Admin)
            {
                var comment = await db.Comments.FindAsync(id);
                if (comment == null)
                {
                    return NotFound();
                }

                db.Comments.Remove(comment);
                await db.SaveChangesAsync();

                return Ok(comment);
            }
            return Unauthorized();
        }

    }
}
    

       