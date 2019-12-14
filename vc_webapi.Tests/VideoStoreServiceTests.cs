using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vc_webapi.Services;
using Xunit;

namespace vc_webapi.Tests
{
    public class VideoStoreServiceTests
    {

        [Fact]
        public void GetUploadToken_GivenAVideo_ReturnsValidGUID()
        {
            //arrange
            var service = VideoStoreServiceFactory();

            //act 
            var video = new Model.Video()
            {
                Name = "test"
            };
            var token = service.GetUploadToken(video);

            //assert
            Guid.TryParse(token, out _).Should().BeTrue();
        }

        [Fact]
        public void GetUploadModel_GivenValidToken_ReturnsCorrectVideoModel()
        {
            //arrange
            var service = VideoStoreServiceFactory();

            //act 
            var video = new Model.Video()
            {
                Name = "test"
            };
            var token = service.GetUploadToken(video);
            var result = service.GetUploadModel(token, out Model.Video videoModel);

            //assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteVideoAsync_GivenExistingVideo_VideoShouldBeDeleted()
        {
            //arrange
            var service = VideoStoreServiceFactory();
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties()
            {
                VirtualFilePath = "DeleteVideoAsync_GivenExistingVideo_VideoShouldBeDeleted"
            };
            var videoFile = Path.Combine(service.VideoRoot, videoProps.VirtualFilePath);
            using var cancel = new CancellationTokenSource();
            using (FileStream file = new FileStream(videoFile, FileMode.CreateNew))
                await video.CopyToAsync(file);

            //act 
            var result = await service.DeleteVideoAsync(videoProps);

            //assert
            result.Should().BeTrue();
            File.Exists(videoFile).Should().BeFalse();
        }

        [Fact]
        public async Task StoreVideoAsync_GivenMockedVideo_MockedVideoIsStored()
        {
            //arrange
            var service = VideoStoreServiceFactory();
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties();
            using var cancel = new CancellationTokenSource();

            //act 
            await service.StoreVideoAsync(video, videoProps, 1024, cancel.Token);

            //assert
            File.Exists(Path.Combine(service.VideoRoot, videoProps.VirtualFilePath)).Should().BeTrue();

            //clean 
            await service.DeleteVideoAsync(videoProps);
        }

        [Fact]
        public async Task StoreVideoAsync_GivenMockedVideo_MockedVideoIdentical()
        {
            //arrange
            var service = VideoStoreServiceFactory();
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties();
            using var cancel = new CancellationTokenSource();

            //act 
            videoProps = await service.StoreVideoAsync(video, videoProps, 1024, cancel.Token);
            var storedVideo = service.GetVideo(videoProps);

            //assert
            var storedVideoInMem = new MemoryStream();
            await storedVideo.CopyToAsync(storedVideoInMem);
            storedVideoInMem.ToArray().Should().BeEquivalentTo(video.ToArray());

            //clean 
            await storedVideo.DisposeAsync();
            await service.DeleteVideoAsync(videoProps);
        }

        [Fact]
        public async Task StoreVideoAsync_StoreVideoCancelled_MockedVideoNotStored()
        {
            //arrange
            var service = VideoStoreServiceFactory();
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties();
            using var cancel = new CancellationTokenSource();

            //act 
            cancel.Cancel();
            await service.StoreVideoAsync(video, videoProps, 1024, cancel.Token);

            //assert
            File.Exists(Path.Combine(service.VideoRoot, videoProps.VirtualFilePath)).Should().BeFalse();
        }

        [Fact]
        public async Task StoreVideoAsync_ExpectedLengthIsWrong_MockedVideoNotStored()
        {
            //arrange
            var service = VideoStoreServiceFactory();
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties();
            using var cancel = new CancellationTokenSource();

            //act 
            await service.StoreVideoAsync(video, videoProps, 1025, cancel.Token);

            //assert
            File.Exists(Path.Combine(service.VideoRoot, videoProps.VirtualFilePath)).Should().BeFalse();
        }

        [Fact]
        public async Task StoreVideoAsync_GivenEnvVideoRootAndMockedVideo_MockedVideoIsStored()
        {
            //arrange
            var webhost = new Mock<IWebHostEnvironment>();
            var config = new Mock<IConfiguration>();
            config.Setup(_ => _["VideoStoreRoot"]).Returns<IConfiguration, string>(null);
            webhost.Setup(_ => _.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            var service = new VideoStoreService(webhost.Object, config.Object);
            var video = MockVideoFactory(1024);
            var videoProps = new Model.VideoProperties();
            using var cancel = new CancellationTokenSource();

            //act 
            await service.StoreVideoAsync(video, videoProps, 1024, cancel.Token);

            //assert
            File.Exists(Path.Combine(service.VideoRoot, videoProps.VirtualFilePath)).Should().BeTrue();

            //clean 
            await service.DeleteVideoAsync(videoProps);
        }

        private VideoStoreService VideoStoreServiceFactory()
        {
            var webhost = new Mock<IWebHostEnvironment>();
            var config = new Mock<IConfiguration>();
            config.Setup(_ => _["VideoStoreRoot"]).Returns(Directory.GetCurrentDirectory());
            return new VideoStoreService(webhost.Object, config.Object);
        }
        private MemoryStream MockVideoFactory(int size)
        {
            var random = new Random();
            var bytes = new byte[size];
            random.NextBytes(bytes);
            return new MemoryStream(bytes);
        }
    }
}
