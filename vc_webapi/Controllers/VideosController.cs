using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Model;
using vc_webapi.Data;
using vc_webapi.Helpers;
using vc_webapi.Model.Users;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideosController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public VideosController(Vc_webapiContext context)
        {
            db = context;
        }

        // GET: api/Videos?limit=5
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Video> GetVideo([FromQuery] int limit)
        {
            if (limit <= 0)
                return db.Videos;
            return db.Videos.Take(limit);
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var video = await db.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo([FromRoute] long id, [FromBody] Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.Id)
            {
                return BadRequest();
            }

            if (await this.User(db) is Admin)
            {
                db.Entry(video).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
        }

        // POST: api/Videos
        [HttpPost]
        public async Task<IActionResult> PostVideo([FromBody] Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await this.User(db) is Admin)
            {
                db.Videos.Add(video);
                await db.SaveChangesAsync();

                return CreatedAtAction("GetVideo", new { id = video.Id }, video);
            }
            return Unauthorized();
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await this.User(db) is Admin)
            {
                var video = await db.Videos.FindAsync(id);
                if (video == null)
                {
                    return NotFound();
                }

                db.Videos.Remove(video);
                await db.SaveChangesAsync();

                return Ok(video);
            }
            return Unauthorized();
        }

        

        private bool VideoExists(long id)
        {
            return db.Videos.Any(e => e.Id == id);
        }
    }
}