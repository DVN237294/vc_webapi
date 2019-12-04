using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using vc_webapi.Controllers;
using vc_webapi.Model;
using vc_webapi.Model.Enums;
using vc_webapi.Model.Users;

namespace vc_webapi.Data
{
    public class Vc_webapiContext : DbContext
    {
        public Vc_webapiContext (DbContextOptions<Vc_webapiContext> options)
            : base(options)
        { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<VideoProperties> VideoProperties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ScheduledSession> ScheduledSessions { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.UserName)
                .IsUnique();
            builder.Entity<Admin>();
            builder.Entity<Student>();

            builder.Entity<Participant>()
                .HasOne(x => x.Session)
                .WithMany(x => x.DbParticipants)
                .HasForeignKey(x => x.SessionId);

            builder.Entity<Participant>()
                .HasOne(x => x.User)
                .WithMany(x => x.DbParticipants)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Room>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<ScheduledSession>()
                .HasOne(x => x.Course)
                .WithMany(x => x.ScheduledSessions)
                .HasForeignKey(x => x.WebuntisCourseId)
                .HasPrincipalKey(x => x.WebuntisCourseId);

            builder.Entity<ScheduledSession>()
                .HasOne(x => x.Room)
                .WithMany(x => x.ScheduledSessions)
                .HasForeignKey(x => x.RoomId);

            builder.Entity<ScheduledSession>()
                .HasAlternateKey(x => x.WebuntisId);

            builder.Entity<RouterLinkParam>()
                .Property(e => e.Param)
                .HasConversion(
                    v => v.ToString(),
                    v => (LinkParam)Enum.Parse(typeof(LinkParam), v));

            builder.Entity<Notification>()
                .Property(e => e.RouterLink)
                .HasConversion(
                    v => v.ToString(),
                    v => (RouterLink)Enum.Parse(typeof(RouterLink), v));

            User testStudent = new Student
            {
                FullName = "BPR Test Student",
                UserName = "teststudent",
                Id = -1L,
                Email = "some@mail.com"
            };
            builder.Entity<Student>().HasData(testStudent);
            builder.Entity<VideoProperties>().HasData(new VideoProperties
            {
                Id = -1L,
                ContainerExt = "mp4",
                Duration = 10000L,
                FileSize = 788493L,
                Height = 176,
                Width = 320,
                MimeType = "video/mp4",
                VirtualFilePath = "testvideo.mp4"
            });

            var sdjSession1 = new object[]
            {
                 new
                 {
                     Id = -1L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L}",
                     Name = "SDJ Lesson 1",
                     Duration = 10L,
                     SessionId = -1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 1L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 1L}",
                     Name = "SDJ Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = -1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 2L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 2L}",
                     Name = "SDJ Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = -1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 3L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 3L}",
                     Name = "SDJ Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = -1L,
                     PropertiesId = -1L
                 }
             };
            var sdjSession2 = new object[]
            {
                 new
                 {
                     Id = -1L - 4L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 4L}",
                     Name = "SDJ Lesson 2",
                     Duration = 10L,
                     SessionId = -1L - 1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 5L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 5L}",
                     Name = "SDJ Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = -1L - 1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 6L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 6L}",
                     Name = "SDJ Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = -1L - 1L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 7L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 7L}",
                     Name = "SDJ Lesson 2 part 4",
                     Duration = 10L,
                     SessionId = -1L - 1L,
                     PropertiesId = -1L
                 }
            };
            var sdjSessions = new object[]
            {
                 new
                 {
                     Id = -1L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = -1L
                 },
                 new
                 {
                     Id = -1L - 1L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = -1L
                 }
            };
            Course sdj1 = new Course
            {
                Id = -1L,
                Name = "SDJ1",
                WebuntisCourseId = -1L
            };
            var ajpSession1 = new object[]
             {
                 new
                 {
                     Id = -1L - 8L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 8L}",
                     Name = "AJP Lesson 1",
                     Duration = 10L,
                     SessionId = -1L - 2L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 9L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 9L}",
                     Name = "AJP Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = -1L - 2L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 10L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 10L}",
                     Name = "AJP Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = -1L - 2L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 11L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 11L}",
                     Name = "AJP Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = -1L - 2L,
                     PropertiesId = -1L
                 }
             };
            var ajpSession2 = new object[]
            {
                 new
                 {
                     Id = -1L - 12L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 12L}",
                     Name = "AJP Lesson 2",
                     Duration = 10L,
                     SessionId = -1L - 3L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 13L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 13L}",
                     Name = "AJP Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = -1L - 3L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 14L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 14L}",
                     Name = "AJP Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = -1L - 3L,
                     PropertiesId = -1L
                 },
                 new
                 {
                     Id = -1L - 15L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}{-1L - 15L}",
                     Name = "AJP Lesson 2 part 4",
                     Duration = 10L,
                     SessionId = -1L - 3L,
                     PropertiesId = -1L
                 }
            };
            var ajpSessions = new object[]
            {
                 new
                 {
                     Id = -1L - 2L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = -1L - 1L
                 },
                 new
                 {
                     Id = -1L - 3L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = -1L - 1L
                 }
            };
            Course ajp1 = new Course
            {
                Id = -1L - 1L,
                Name = "AJP1",
                WebuntisCourseId = -1L - 1L
            };

            builder.Entity<Video>().HasData(sdjSession1.Concat(sdjSession2).Concat(ajpSession1).Concat(ajpSession2));
            builder.Entity<Session>().HasData(sdjSessions.Concat(ajpSessions));
            builder.Entity<Course>().HasData(sdj1, ajp1);
            builder.Entity<Enrollment>().HasData(
            new
            {
                Id = -1L,
                EnrollmentDateUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc).AddDays(-90),
                UserId = -1L,
                CourseId = -1L
            },
            new
            {
                Id = -1L - 1L,
                EnrollmentDateUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc).AddDays(-90),
                UserId = -1L,
                CourseId = -1L - 1L
            });

            builder.Entity<Participant>().HasData(
            new Participant
            {
                Id = -1L,
                SessionId = -1L,
                UserId = -1L
            },
            new Participant
            {
                Id = -1L - 1L,
                SessionId = -1L - 1L,
                UserId = -1L
            },
            new Participant
            {
                Id = -1L - 2L,
                SessionId = -1L - 2L,
                UserId = -1L
            },
            new Participant
            {
                Id = -1L - 3L,
                SessionId = -1L - 3L,
                UserId = -1L
            });

            builder.Entity<Room>().HasData(
            new Room
            {
                Id = -1L,
                WebuntisId = 1319,
                Name = "F.301a UV",
            },
            new Room
            {
                Id = -1L - 1L,
                WebuntisId = 1320,
                Name = "F.301b UV",
            },
            new Room
            {
                Id = -1L - 2L,
                WebuntisId = 1321,
                Name = "F.302a UV",
            },
            new Room
            {
                Id = -1L - 3L,
                WebuntisId = 1322,
                Name = "F.302b UV",
            },
            new Room
            {
                Id = -1L - 4L,
                WebuntisId = 1323,
                Name = "F.304 UV",
            });

            builder.Entity<Comment>().HasData(new
            {
                Id = -1L,
                UserId = -1L,
                VideoId = -1L,
                CommentTime = new DateTime(2019, 10, 5, 22, 3, 59),
                Message = "Comment to test notifications! @teststudent"
            });

            builder.Entity<RouterLinkParam>().HasData(
                new
                {
                    Id = -1L,
                    Param = LinkParam.VideoId,
                    Value = (-1L).ToString(),
                    NotificationId = -1L
                },
                new
                {
                    Id = -2L,
                    Param = LinkParam.CommentId,
                    Value = (-1L).ToString(),
                    NotificationId = -1L
                });

            builder.Entity<Notification>().HasData(
                new Notification
                {
                    Message = "You were mentioned in a comment by BPR Test Student, in video \"SDJ Lesson 1\"",
                    NotificationTimeUtc = new DateTime(2019, 10, 5, 22, 4, 02),
                    Id = -1L,
                    Dismissed = false,
                    UserId = -1L,
                    RouterLink = RouterLink.Comment
                });
        }
    }
}
