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
            return db.Videos.OrderByDescending(v => v.RecordTimeUtc).Take(limit);
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        [AllowAnonymous]
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
    }
}