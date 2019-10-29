using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.UserName)
                .IsUnique();
            builder.Entity<Admin>();
            builder.Entity<Student>();

            builder.Entity<UserSession>()
                .HasOne(x => x.Session)
                .WithMany(x => x.UserSessions)
                .HasForeignKey(x => x.SessionId);

            builder.Entity<UserSession>()
                .HasOne(x => x.User)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.UserId);

            User testStudent = new Student
            {
                FullName = "BPR Test Student",
                UserName = "teststudent",
                Id = 100L,
                Email = "some@mail.com"
            };
            builder.Entity<Student>().HasData(testStudent);

            var sdjSession1 = new object[]
            {
                 new
                 {
                     Id = 100L,
                     RecordTimeUtc = DateTime.UtcNow,
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 1",
                     Duration = 10L,
                     SessionId = 100L
                 },
                 new
                 {
                     Id = 101L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = 100L
                 },
                 new
                 {
                     Id = 102L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = 100L
                 },
                 new
                 {
                     Id = 103L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = 100L
                 }
             };
            var sdjSession2 = new object[]
            {
                 new
                 {
                     Id = 104L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 2",
                     Duration = 10L,
                     SessionId = 101L
                 },
                 new
                 {
                     Id = 105L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = 101L
                 },
                 new
                 {
                     Id = 106L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = 101L
                 },
                 new
                 {
                     Id = 107L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "SDJ Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = 101L
                 }
            };
            var sdjSessions = new object[]
            {
                 new
                 {
                     Id = 100L,
                     Date = DateTime.UtcNow,
                     CourseId = 100L
                 },
                 new
                 {
                     Id = 101L,
                     Date = DateTime.UtcNow,
                     CourseId = 100L
                 }
            };
            Course sdj1 = new Course
            {
                Id = 100L,
                Name = "SDJ1"
            };
            var ajpSession1 = new object[]
             {
                 new
                 {
                     Id = 108L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(1),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 1",
                     Duration = 10L,
                     SessionId = 102L
                 },
                 new
                 {
                     Id = 109L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 1 part 2",
                     Duration = 10L,
                     SessionId = 102L
                 },
                 new
                 {
                     Id = 110L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 1 part 3",
                     Duration = 10L,
                     SessionId = 102L
                 },
                 new
                 {
                     Id = 111L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(1) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 1 part 4",
                     Duration = 10L,
                     SessionId = 102L
                 }
             };
            var ajpSession2 = new object[]
            {
                 new
                 {
                     Id = 112L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(8),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 2",
                     Duration = 10L,
                     SessionId = 103L
                 },
                 new
                 {
                     Id = 113L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(45),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 2 part 2",
                     Duration = 10L,
                     SessionId = 103L
                 },
                 new
                 {
                     Id = 114L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(90),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = 103L
                 },
                 new
                 {
                     Id = 115L,
                     RecordTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(8) + TimeSpan.FromMinutes(145),
                     ThumbnailURL = "/assets/video.jpeg",
                     URL = "/assets/testvideo.mp4",
                     Name = "AJP Lesson 2 part 3",
                     Duration = 10L,
                     SessionId = 103L
                 }
            };
            var ajpSessions = new object[]
            {
                 new
                 {
                     Id = 102L,
                     Date = DateTime.UtcNow,
                     CourseId = 101L
                 },
                 new
                 {
                     Id = 103L,
                     Date = DateTime.UtcNow,
                     CourseId = 101L
                 }
            };
            Course ajp1 = new Course
            {
                Id = 101L,
                Name = "AJP1"
            };

            builder.Entity<Video>().HasData(sdjSession1.Concat(sdjSession2).Concat(ajpSession1).Concat(ajpSession2));
            builder.Entity<Session>().HasData(sdjSessions.Concat(ajpSessions));
            builder.Entity<Course>().HasData(sdj1, ajp1);
            builder.Entity<Enrollment>().HasData(
            new
            {
                Id = 100L,
                EnrollmentDateUtc = DateTime.UtcNow.AddDays(-90),
                UserId = 100L,
                CourseId = 100L
            },
            new
            {
                Id = 101L,
                EnrollmentDateUtc = DateTime.UtcNow.AddDays(-90),
                UserId = 100L,
                CourseId = 101L
            });

            builder.Entity<UserSession>().HasData(
            new UserSession
            {
                Id = 100L,
                SessionId = 100L,
                UserId = 100L
            },
            new UserSession
            {
                Id = 101L,
                SessionId = 101L,
                UserId = 100L
            },
            new UserSession
            {
                Id = 102L,
                SessionId = 102L,
                UserId = 100L
            },
            new UserSession
            {
                Id = 103L,
                SessionId = 103L,
                UserId = 100L
            });
        }
    }
}
