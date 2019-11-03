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
    public class VideosController2
    {
        private readonly Vc_webapiContext db;

        public VideosController2(Vc_webapiContext context)
        {
            db = context;
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IEnumerable<Video> GetVideosFromName(string name)
        {
            if (name is null)
            {
                return db.Videos;
            }

            var videosFromName =
                db.Videos.Where(v => v.Name.ToLower().Contains((name))).OrderByDescending(v => v.RecordTimeUtc);

            return videosFromName.ToList();
        }
    }
}
