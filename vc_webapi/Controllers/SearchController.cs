using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Data;
using vc_webapi.Model.API;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public SearchController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SearchResult), 200)]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] int limit = 0)
        {
            limit = limit <= 0 ? int.MaxValue : limit;
            query = query.ToLower();

            return Ok(new SearchResult
            {
                Videos = await db.Videos.
                Where(v => v.Name.ToLower().Contains(query)).
                Take(limit).
                OrderByDescending(v => v.RecordTimeUtc).
                ToListAsync(),

                Users = await db.Users.
                Where(u => u.FullName.ToLower().Contains(query) || u.Email.Contains(query)).
                Take(limit).
                ToListAsync(),

                Courses = await db.Courses.
                Where(c => c.Name.ToLower().Contains(query)).
                Take(limit).
                ToListAsync()
            });
        }

    }
}