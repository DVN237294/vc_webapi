using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using vc_webapi.Data;
using vc_webapi.Model;
using vc_webapi.Model.API;

namespace vc_webapi.Services
{
    public class VideoStoreService
    {
        private readonly string VideoRoot;
        private static readonly ConcurrentDictionary<string, Video> VideoUploadTokens = new ConcurrentDictionary<string, Video>();
        private readonly TimeSpan UPLOAD_TIMEOUT = TimeSpan.FromMinutes(10);
        public VideoStoreService(IWebHostEnvironment env, IConfiguration configuration)
        {
            string storeRoot = configuration["VideoStoreRoot"];
            if (string.IsNullOrWhiteSpace(storeRoot))
                this.VideoRoot = Path.Combine(env.ContentRootPath, "vc_videostore");
            else
                this.VideoRoot = Environment.ExpandEnvironmentVariables(storeRoot);

            if (!Directory.Exists(VideoRoot))
                Directory.CreateDirectory(VideoRoot);
        }

        public async Task<VideoProperties> StoreVideoAsync(Stream sourceStream, VideoProperties properties, long expectedLength, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(properties.ContainerExt)) properties.ContainerExt = "unkwn";
            
            properties.VirtualFilePath = $"{Path.GetRandomFileName()}.{properties.ContainerExt}";
            string physicalFilePath = PhysicalFilePath(properties.VirtualFilePath);
            bool fileOk = true;
            try
            {
                if (!token.IsCancellationRequested)
                {
                    using FileStream f = new FileStream(physicalFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, true);
                    await sourceStream.CopyToAsync(f, token);
                }
            }
            finally
            {
                fileOk = !token.IsCancellationRequested;
                if (fileOk)
                {
                    properties.FileSize = new FileInfo(physicalFilePath).Length;
                    if (properties.FileSize < expectedLength)
                        fileOk = false;
                }
                if(!fileOk)
                    File.Delete(physicalFilePath);
            }
            if (!fileOk)
                return null;

            return properties;
        }
        public string GetUploadToken(Video videoModel)
        {
            string ulToken = Guid.NewGuid().ToString();
            if (VideoUploadTokens.TryAdd(ulToken, videoModel))
            {
                Task.Delay(UPLOAD_TIMEOUT).ContinueWith(t => VideoUploadTokens.TryRemove(ulToken, out Video _));
                return ulToken;
            }
            return null;
        }
        public bool GetUploadModel(string token, out Video videoModel) => VideoUploadTokens.TryGetValue(token, out videoModel);
        public Stream GetVideo(VideoProperties properties) => new FileStream(PhysicalFilePath(properties.VirtualFilePath), FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
        private string PhysicalFilePath(string virtualFilePath) => Path.Combine(this.VideoRoot, virtualFilePath);
    }
}
