using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Data;
using vc_webapi.Helpers;
using vc_webapi.Model;
using vc_webapi.Model.API;
using vc_webapi.Model.Users;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public CoursesController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses([FromQuery] int limitCourses = int.MaxValue, [FromQuery] bool includeSessions = false, [FromQuery] bool includeSessionRecordings = false, [FromQuery] bool includeSessionParticipants = false)
        {
            var query = db.Courses
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionParticipants, q2 => q2.ThenInclude(e => e.Participants))
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionRecordings, q2 => q2.ThenInclude(e => e.Recordings))));

            return await query.Take(limitCourses).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecificCourse([FromRoute] long id, [FromQuery] bool includeSessions = false, [FromQuery] bool includeSessionRecordings = false, [FromQuery] bool includeSessionParticipants = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await db.Courses
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionParticipants, q2 => q2.ThenInclude(e => e.Participants))
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionRecordings, q2 => q2.ThenInclude(e => e.Recordings))))
                .SingleOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await this.User(db) is Admin)
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();

                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("{courseId}/AddSession")]
        public async Task<IActionResult> AddSession([FromRoute] long courseId, [FromBody] AddSessionModel session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await this.User(db) is Admin)
            {
                var course = await db.Courses.FindAsync(courseId);
                if (course == null)
                {
                    return NotFound();
                }
                var users = await db.Users.Where(user => session.ParticipantUserIds.Contains(user.Id)).ToListAsync();
                course.Sessions = new List<Session>
                {
                    new Session
                    {
                        Date = session.Date,
                        Participants = users,
                        Recordings = session.Recordings
                    }
                };
                await db.SaveChangesAsync();
                return Ok();
            }
            return Unauthorized();
        }

    }
}