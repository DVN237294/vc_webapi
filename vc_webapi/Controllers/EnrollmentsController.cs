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
    public class EnrollmentsController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public EnrollmentsController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("MyEnrollments")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetMyEnrollments([FromQuery] int limitEnrollments, [FromQuery] bool includeSessions, [FromQuery] bool includeSessionParticipants, [FromQuery] bool includeSessionRecordings)
        {
            User user = await this.User(db);
            if (user != null)
            {
                var query = db.Enrollments.Where(enrol => enrol.User.UserName == user.UserName)
                    .Include(enrollment => enrollment.Course)
                        .If(includeSessions, q2 => q2.ThenInclude(course => course.Sessions));

                if(query is IIncludableQueryable<Enrollment, IList<Session>> subQuery)
                    query = subQuery.If(includeSessionParticipants, q22 => q22.ThenInclude(a => a.Participants))
                        .Include(enrollment => enrollment.Course)
                            .ThenInclude(course => course.Sessions)
                                .If(includeSessionRecordings, q3 => q3.ThenInclude(session => session.Recordings));

                return await query.Take(limitEnrollments).ToListAsync();
            }
            return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> EnrollUser([FromBody] EnrollUserModel enrollUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await this.User(db) is Admin)
            {
                if (db.Enrollments
                    .Where(enroll => enroll.User.Id == enrollUserModel.UserId && enroll.Course.Id == enrollUserModel.CourseId)
                    .Any())
                    return Ok(); //User already enrolled in that course

                var user = await db.Users.FindAsync(enrollUserModel.UserId);
                if (user != null)
                {
                    var course = await db.Courses.FindAsync(enrollUserModel.CourseId);
                    if (course != null)
                    {
                        db.Enrollments.Add(new Enrollment
                        {
                            Course = course,
                            User = user,
                            EnrollmentDateUtc = DateTime.UtcNow
                        });
                        await db.SaveChangesAsync();
                        return Ok();
                    }
                }
                return BadRequest();
            }
            return Unauthorized();
        }
    }

}