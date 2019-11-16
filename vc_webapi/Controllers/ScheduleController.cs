using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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
    public class ScheduleController : ControllerBase
    {
        private readonly Vc_webapiContext db;

        public ScheduleController(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("ForRoom/{roomName}")]
        [ProducesResponseType(typeof(RoomRecordingSchedule), 200)]
        public async Task<IActionResult> GetRoomSchedule([FromRoute] string roomName, [FromQuery] DateTime startUtc = default, [FromQuery] DateTime endUtc = default)
        {
            //defaults to a 7 day timespan:
            if (startUtc == default && endUtc == default)
            {
                var now = DateTime.UtcNow;
                int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7; //+7 to make it positive in the Sunday case.
                startUtc = now.AddDays(-1 * diff).Date;
                endUtc = startUtc.AddDays(7);
            }
            else if (endUtc == default)
                endUtc = startUtc.AddDays(7);
            else if (startUtc == default)
                startUtc = endUtc.AddDays(-7);
            
            var room = await db.Rooms.Where(r => r.Name == roomName).SingleOrDefaultAsync();
            if (room == null) return NotFound(roomName);

            var sessions = await db.ScheduledSessions.
                Include(s => s.Course).
                Where(s => s.StartTime > startUtc && s.EndTime < endUtc && s.Room.Name == roomName).
                OrderBy(s => s.StartTime).
                ToListAsync();

            return Ok(new RoomRecordingSchedule
            {
                ValidFrom = startUtc,
                ValidTo = endUtc,
                ScheduledSessions = sessions
            });
        }

        [HttpGet]
        [Route("GetRooms")]
        [ProducesResponseType(typeof(ICollection<Room>), 200)]
        public async Task<IActionResult> GetRooms([FromQuery] int limit = 0)
        {
            if (!(await this.User(db) is Admin)) return BadRequest();

            return Ok(db.Rooms.Take(limit > 0 ? limit : int.MaxValue));
        }

        [HttpPost]
        [Route("AddRoom")]
        [ProducesResponseType(typeof(Room), 200)]
        public async Task<IActionResult> AddRoom([FromBody] Room room)
        {
            if (!(await this.User(db) is Admin)) return BadRequest();

            var existingRoom = await db.Rooms.FirstOrDefaultAsync(r => r.WebuntisId == room.WebuntisId);

            if (existingRoom != null) return Conflict(existingRoom);
            
            db.Rooms.Add(room);
            await db.SaveChangesAsync();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoomSchedules([FromBody] ICollection<ScheduledSession> sessions)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!(await this.User(db) is Admin)) return BadRequest();

            var entitiesExist = await db.ScheduledSessions.Where(c => sessions.Select(c2 => c2.WebuntisId).Contains(c.WebuntisId)).ToDictionaryAsync(c => c.WebuntisId, c => c);
            var toAdd = sessions.Where(c => !entitiesExist.TryGetValue(c.WebuntisId, out var _)).ToList();

            db.ScheduledSessions.AddRange(toAdd);
            await db.SaveChangesAsync();

            int added = toAdd.Count();
            return Ok(added);
        }
    }
}