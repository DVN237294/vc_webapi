using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses([FromQuery] int limitCourses = int.MaxValue, [FromQuery] bool includeSessions = false, [FromQuery] bool includeSessionRecordings = false, [FromQuery] bool includeSessionParticipants = false)
        {
            includeSessions = includeSessions || includeSessionRecordings || includeSessionParticipants;
            var query = db.Courses
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionParticipants, q2 => q2.ThenInclude(e => e.DbParticipants).ThenInclude(e => e.User))
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionRecordings, q2 => q2.ThenInclude(e => e.Recordings))));

            return await query.Take(limitCourses).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpecificCourse([FromRoute] long id, [FromQuery] bool includeSessions = false, [FromQuery] bool includeSessionRecordings = false, [FromQuery] bool includeSessionParticipants = false)
        {
            var course = await db.Courses
                .If(includeSessions, q => q.Include(e => e.Sessions)
                    .If(includeSessionParticipants, q2 => q2.ThenInclude(e => e.DbParticipants).ThenInclude(e => e.User))
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
        [Route("AddRange")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> AddRange([FromBody] ICollection<Course> courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await this.User(db) is Admin)
            {
                var entitiesExist = await db.Courses.Where(c => courses.Select(c2 => c2.WebuntisCourseId).Contains(c.WebuntisCourseId)).ToDictionaryAsync(c => c.WebuntisCourseId, c => c);
                var toAdd = courses.Where(c => !entitiesExist.TryGetValue(c.WebuntisCourseId, out Course _)).ToList();

                db.Courses.AddRange(toAdd);
                await db.SaveChangesAsync();

                int added = toAdd.Count();
                return Ok(added);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Course course)
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
            if(session == null || session.Recordings == null || session.Recordings.Count == 0)
            {
                return BadRequest();
            }

            var course = await db.Courses.Where(c => c.Id == courseId).Include(c => c.Sessions).SingleOrDefaultAsync();
            if (course == null)
            {
                return NotFound();
            }
            if (await this.User(db) is Admin)
            {
                List<User> users = new List<User>();
                if (session.ParticipantUserIds != null && session.ParticipantUserIds.Count > 0)
                    //Contains implementation of ICollection is not supported in EF, so cast to IEnumerable:
                    users = await db.Users.Where(user => (session.ParticipantUserIds as IEnumerable<long>).Contains(user.Id)).ToListAsync();

                db.Videos.AddRange(session.Recordings);
                course.Sessions.Add(new Session
                {
                    Date = session.Date,
                    Recordings = session.Recordings,
                    Participants = users
                });
                await db.SaveChangesAsync();
                return Ok();
            }
            return Unauthorized();
        }

    }
}