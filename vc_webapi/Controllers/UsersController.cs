using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using vc_webapi.Data;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public UsersController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.SingleOrDefaultAsync(c => c.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Id);
        }
    }
}
