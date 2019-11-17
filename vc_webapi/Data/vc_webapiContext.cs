using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using vc_webapi.Controllers;
using vc_webapi.Model;
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
            
            User testStudent = new Student
            {
                FullName = "BPR Test Student",
                UserName = "teststudent",
                Id = long.MaxValue,
                Email = "some@mail.com"
            };
            builder.Entity<Student>().HasData(testStudent);
            builder.Entity<VideoProperties>().HasData(new VideoProperties
            {
                Id = long.MaxValue,
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
                     Id = long.MaxValue,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}100",
                     Name = "SDJ Lesson 1",
                     Duration = 10L,
                     SessionId = long.MaxValue,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 1L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}101",
                     Name = "SDJ Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = long.MaxValue,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 2L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}102",
                     Name = "SDJ Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = long.MaxValue,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 3L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}103",
                     Name = "SDJ Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = long.MaxValue,
                     PropertiesId = long.MaxValue
                 }
             };
            var sdjSession2 = new object[]
            {
                 new
                 {
                     Id = long.MaxValue - 4L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}104",
                     Name = "SDJ Lesson 2",
                     Duration = 10L,
                     SessionId = long.MaxValue - 1L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 5L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}105",
                     Name = "SDJ Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = long.MaxValue - 1L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 6L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}106",
                     Name = "SDJ Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = long.MaxValue - 1L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 7L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}107",
                     Name = "SDJ Lesson 2 part 4",
                     Duration = 10L,
                     SessionId = long.MaxValue - 1L,
                     PropertiesId = long.MaxValue
                 }
            };
            var sdjSessions = new object[]
            {
                 new
                 {
                     Id = long.MaxValue,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 1L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = long.MaxValue
                 }
            };
            Course sdj1 = new Course
            {
                Id = long.MaxValue,
                Name = "SDJ1",
                WebuntisCourseId = long.MaxValue
            };
            var ajpSession1 = new object[]
             {
                 new
                 {
                     Id = long.MaxValue - 8L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}108",
                     Name = "AJP Lesson 1",
                     Duration = 10L,
                     SessionId = long.MaxValue - 2L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 9L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}109",
                     Name = "AJP Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = long.MaxValue - 2L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 10L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}110",
                     Name = "AJP Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = long.MaxValue - 2L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 11L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}111",
                     Name = "AJP Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = long.MaxValue - 2L,
                     PropertiesId = long.MaxValue
                 }
             };
            var ajpSession2 = new object[]
            {
                 new
                 {
                     Id = long.MaxValue - 12L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}112",
                     Name = "AJP Lesson 2",
                     Duration = 10L,
                     SessionId = long.MaxValue - 3L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 13L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}113",
                     Name = "AJP Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = long.MaxValue - 3L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 14L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}114",
                     Name = "AJP Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = long.MaxValue - 3L,
                     PropertiesId = long.MaxValue
                 },
                 new
                 {
                     Id = long.MaxValue - 15L,
                     RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     StreamUrl = $"{VideostreamController.StreamBaseUrl}115",
                     Name = "AJP Lesson 2 part 4",
                     Duration = 10L,
                     SessionId = long.MaxValue - 3L,
                     PropertiesId = long.MaxValue
                 }
            };
            var ajpSessions = new object[]
            {
                 new
                 {
                     Id = long.MaxValue - 2L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = long.MaxValue - 1L
                 },
                 new
                 {
                     Id = long.MaxValue - 3L,
                     Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                     CourseId = long.MaxValue - 1L
                 }
            };
            Course ajp1 = new Course
            {
                Id = long.MaxValue - 1L,
                Name = "AJP1",
                WebuntisCourseId = long.MaxValue - 1L
            };

            builder.Entity<Video>().HasData(sdjSession1.Concat(sdjSession2).Concat(ajpSession1).Concat(ajpSession2));
            builder.Entity<Session>().HasData(sdjSessions.Concat(ajpSessions));
            builder.Entity<Course>().HasData(sdj1, ajp1);
            builder.Entity<Enrollment>().HasData(
            new
            {
                Id = long.MaxValue,
                EnrollmentDateUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc).AddDays(-90),
                UserId = long.MaxValue,
                CourseId = long.MaxValue
            },
            new
            {
                Id = long.MaxValue - 1L,
                EnrollmentDateUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc).AddDays(-90),
                UserId = long.MaxValue,
                CourseId = long.MaxValue - 1L
            });

            builder.Entity<Participant>().HasData(
            new Participant
            {
                Id = long.MaxValue,
                SessionId = long.MaxValue,
                UserId = long.MaxValue
            },
            new Participant
            {
                Id = long.MaxValue - 1L,
                SessionId = long.MaxValue - 1L,
                UserId = long.MaxValue
            },
            new Participant
            {
                Id = long.MaxValue - 2L,
                SessionId = long.MaxValue - 2L,
                UserId = long.MaxValue
            },
            new Participant
            {
                Id = long.MaxValue - 3L,
                SessionId = long.MaxValue - 3L,
                UserId = long.MaxValue
            });

            builder.Entity<Room>().HasData(
            new Room
            {
                Id = long.MaxValue,
                WebuntisId = 1319,
                Name = "F.301a UV",
            }, 
            new Room
            {
                Id = long.MaxValue - 1L,
                WebuntisId = 1320,
                Name = "F.301b UV",
            },
            new Room
            {
                Id = long.MaxValue - 2L,
                WebuntisId = 1321,
                Name = "F.302a UV",
            },
            new Room
            {
                Id = long.MaxValue - 3L,
                WebuntisId = 1322,
                Name = "F.302b UV",
            },
            new Room
            {
                Id = long.MaxValue - 4L,
                WebuntisId = 1323,
                Name = "F.304 UV",
            });
        }
    }
}
