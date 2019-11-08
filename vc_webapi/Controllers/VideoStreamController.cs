using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using vc_webapi.Attributes;
using vc_webapi.Data;
using vc_webapi.Helpers;
using vc_webapi.Model;
using vc_webapi.Model.API;
using vc_webapi.Model.Users;
using vc_webapi.Services;

namespace vc_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideostreamController : ControllerBase
    {
        public static string StreamBaseUrl { get; } = "/api/Videostream/";
        private readonly ILogger<VideostreamController> logger;
        private readonly VideoStoreService videoStore;
        private readonly Vc_webapiContext db;
        public VideostreamController(ILogger<VideostreamController> logger, VideoStoreService videoStore, Vc_webapiContext db)
        {
            this.logger = logger;
            this.videoStore = videoStore;
            this.db = db;
        }

        [ProducesResponseType(typeof(FileStreamResult), 200)]
        [Produces("application/octet-stream")]
        [HttpGet("{videoId}")]
        public async Task<IActionResult> GetVideo([FromRoute] long videoId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (videoId <= 0) return BadRequest(videoId);

            Video video = await db.Videos.Include(v => v.Properties).Where(p => p.Id == videoId).SingleOrDefaultAsync();
            if (video == null) return BadRequest(videoId);

            Stream fileStream = videoStore.GetVideo(video.Properties); //FileStreamResult will call IDispose for me
            return File(fileStream, video.Properties.MimeType, $"{video.Name}.{video.Properties.ContainerExt}", true);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(UlTokenModel), 200)]
        public async Task<IActionResult> PostVideoProperties([FromBody] Video video)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await this.User(db) is Admin)
            {
                string ulToken = videoStore.GetUploadToken(video);
                if (ulToken == null) return BadRequest();

                return Ok(new UlTokenModel { UlToken = ulToken });
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpPost("{ulToken}")]
        [Consumes("multipart/form-data")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(Video), 200)]
        [RequestEncodingContentType(MediaType = "multipart/form-data", ParameterNames = new[] { "file" }, ContentTypes = new[] { "application/octet-stream" })]
        public async Task<IActionResult> UploadVideo([FromRoute] string ulToken, [FromForm] IFormFileCollection file)
        {
            if ((file?.Count ?? 0) != 1) return BadRequest();

            IFormFile vid = file.SingleOrDefault();

            return await HandleVideoUpload(ulToken, vid.OpenReadStream(), vid.Length);
        }

        [Authorize]
        [HttpPost("{ulToken}/body")]
        [Consumes("application/octet-stream")]
        [BinaryPayload]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(Video), 200)]
        public async Task<IActionResult> UploadVideoBody([FromRoute] string ulToken)
        {
            Stream stream = Request.Body;
            long length = Request.ContentLength ?? 0;
            if (length <= 0) return BadRequest();

            return await HandleVideoUpload(ulToken, stream, length);
        }

        private async Task<IActionResult> HandleVideoUpload(string ulToken, Stream fileStream, long streamLength)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (videoStore.GetUploadModel(ulToken, out Video video))
                if (await this.User(db) is Admin)
                {
                    video.Properties = await videoStore.StoreVideoAsync(fileStream, video.Properties, streamLength, HttpContext.RequestAborted);
                    if (video.Properties != null)
                    {
                        db.Videos.Add(video);
                        await db.SaveChangesAsync(); //Save and get Id
                        video.StreamUrl += $"{StreamBaseUrl}{video.Id}";
                        await db.SaveChangesAsync(); //Update URL with Id
                        return Ok(video);
                    }
                }

            return BadRequest();
        }
    }
}