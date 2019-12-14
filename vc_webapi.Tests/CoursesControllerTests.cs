using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using vc_webapi.Controllers;
using vc_webapi.Data;
using vc_webapi.Model;
using vc_webapi.Model.API;
using vc_webapi.Model.Users;
using Xunit;

namespace vc_webapi.Tests
{
    public class CoursesControllerTests
    {
        private readonly TestFixture<Vc_webapiContext> fixture = new TestFixture<Vc_webapiContext>(m => new Vc_webapiContext(m));

        [Fact]
        public async Task GetAllCourses_GivenALimit_ReturnsCoursesAccordingToLimit() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2),
                assert: (result, _) => result.Value.Count().Should().Be(2));

        [Fact]
        public async Task GetAllCourses_NoLimitSet_ReturnsAllCourses()
        {
            await fixture.RunWithDatabaseAsync(
                arrange: db => db.Courses.Count(),
                act: async (db, count) => await new CoursesController(db).GetAllCourses(),
                assert: (result, count) => result.Value.ToArray().Should().HaveCount(count));
        }

        [Fact]
        public async Task GetAllCourses_IncludeSessionsNotSet_SessionsAreNull() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2),
                assert: (result, _) => result.Value.ToArray().Should().OnlyContain(c => c.Sessions == null));

        [Fact]
        public async Task GetAllCourses_IncludeSessionsSetAndIncludeParticipantsNotSet_ParticipantsAreNull() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessions: true),
                assert: (result, _) => result.Value.ToArray().SelectMany(c => c.Sessions).Should().OnlyContain(s => s.Participants == null));

        [Fact]
        public async Task GetAllCourses_IncludeSessionsSetAndIncludeRecordingsNotSet_RecordingsAreNull() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessions: true),
                assert: (result, _) => result.Value.ToArray().SelectMany(c => c.Sessions).Should().OnlyContain(s => s.Recordings == null));

        [Fact]
        public async Task GetAllCourses_IncludeSessionsSet_SessionsIncluded() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessions: true),
                assert: (result, _) => result.Value.ToArray().Should().OnlyContain(c => c.Sessions.Count > 0));

        [Fact]
        public async Task GetAllCourses_IncludeParticipantsSet_ParticipantsIncluded() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessionParticipants: true),
                assert: (result, _) => result.Value.ToArray().SelectMany(c => c.Sessions).Should().OnlyContain(s => s.Participants.Count() > 0));

        [Fact]
        public async Task GetAllCourses_IncludeRecordingsSet_RecordingsIncluded() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessionRecordings: true),
                assert: (result, _) => result.Value.ToArray().SelectMany(c => c.Sessions).Should().OnlyContain(s => s.Recordings.Count() > 0));

        [Fact]
        public async Task GetAllCourses_IncludeRecordingsSetAndIncludeParticipantsSet_RecordingsIncludedAndParticipantsIncluded() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (db, c) => await c.GetAllCourses(limitCourses: 2, includeSessionRecordings: true, includeSessionParticipants: true),
                assert: (result, _) => result.Value.ToArray().SelectMany(c => c.Sessions)
                    .Should()
                        .OnlyContain(s => s.Recordings.Count() > 0)
                        .And.OnlyContain(s => s.Participants.Count() > 0));


        [Fact]
        public async Task GetSpecificCourse_GivenCourseId_ReturnSpecificCouse()
        {
            var course = new Course()
            {
                Id = 12345L
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Add(course);
                    await db.SaveChangesAsync();
                    return new CoursesController(db);
                },
                act: async (_, c) => await c.GetSpecificCourse(12345L),
                assert: (result, _) =>
                {
                    result.Should().BeOfType<OkObjectResult>();
                    (result as OkObjectResult).Value.Should().Be(course);
                });
        }

        [Fact]
        public async Task GetSpecificCourse_GivenNonExistantId_ReturnNotFound() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => new CoursesController(db),
                act: async (_, c) => await c.GetSpecificCourse(12345L),
                assert: (result, _) => result.Should().BeOfType<NotFoundResult>());

        [Fact]
        public async Task AddRange_GivenValidCourseRange_DatabaseContainsRange()
        {
            var courses = new List<Course>()
            {
                new Course() { Id = 12345L, WebuntisCourseId = 12345L },
                new Course() { Id = 12346L, WebuntisCourseId = 12346L },
                new Course() { Id = 12347L, WebuntisCourseId = 12347L },
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Admin()
                    {
                        UserName = "testUser123"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser123");
                },
                act: async (_, c) => await c.AddRange(courses),
                assert: (result, _, db) =>
                {
                    result.Should().BeOfType<OkObjectResult>();
                    (result as OkObjectResult).Value.Should().BeOfType<int>();
                    ((int)(result as OkObjectResult).Value).Should().Be(courses.Count);
                    db.Courses.Should().Contain(courses);
                });
        }

        [Fact]
        public async Task AddRange_CallingUserIsNotAdmin_ReturnsNotAuthorized()
        {
            var courses = new List<Course>()
            {
                new Course() { Id = 12345L, WebuntisCourseId = 12345L },
                new Course() { Id = 12346L, WebuntisCourseId = 12346L },
                new Course() { Id = 12347L, WebuntisCourseId = 12347L },
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Student()
                    {
                        UserName = "testUser1234"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser1234");
                },
                act: async (_, c) => await c.AddRange(courses),
                assert: (result, _) => result.Should().BeOfType<UnauthorizedResult>());
        }

        [Fact]
        public async Task Add_CallingUserIsNotAdmin_ReturnsNotAuthorized()
        {
            var course =  new Course() { Id = 12345L, WebuntisCourseId = 12345L };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Student()
                    {
                        UserName = "testUser123456"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser123456");
                },
                act: async (_, c) => await c.Add(course),
                assert: (result, _) => result.Should().BeOfType<UnauthorizedResult>());
        }

        [Fact]
        public async Task Add_GivenValidCourse_DatabaseContainsCourse()
        {
            var course = new Course() { Id = 12345L, WebuntisCourseId = 12345L };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Admin()
                    {
                        UserName = "testUser12345"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser12345");
                },
                act: async (_, c) => await c.Add(course),
                assert: (result, _, db) =>
                {
                    result.Should().BeOfType<OkResult>();
                    db.Courses.Should().Contain(course);
                });
        }

        [Fact]
        public async Task AddSession_GivenInvalidCourseId_ReturnsNotFound() =>
            await fixture.RunWithDatabaseAsync(
                arrange: db => ControllerFactory(db, ""),
                act: async (_, c) => await c.AddSession(232545243, new AddSessionModel() { Recordings = new[] { new Video() } }),
                assert: (result, _) => result.Should().BeOfType<NotFoundResult>());

        [Fact]
        public async Task AddSession_GivenSessionWithVideoAndWithoutParticipants_CourseHasSessionWithVideo()
        {
            var model = new AddSessionModel()
            {
                Date = DateTime.UtcNow,
                Recordings = new []
                {
                    new Video()
                    {
                        Id = 12345678L,
                        Name = "testVideo",
                        RecordTimeUtc = DateTime.UtcNow,
                        Properties = new VideoProperties()
                        {
                            MimeType = "test",
                            Duration = 0,
                            ContainerExt = "test"
                        }
                    }
                }
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Admin()
                    {
                        UserName = "testUser12345"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser12345");
                },
                act: async (_, c) => await c.AddSession(-1, model),
                assert: (result, _, db) =>
                {
                    result.Should().BeOfType<OkResult>();
                    db.Courses.AsQueryable<Course>()
                              .Include(c => c.Sessions)
                              .ThenInclude(s => s.Recordings)
                              .Include(c => c.Sessions)
                              .ThenInclude(s => s.DbParticipants)
                              .Should()
                              .Contain(c => c.Sessions.Any(s => s.Recordings.Any(v => v.Id == 12345678L)));
                });
        }

        [Fact]
        public async Task AddSession_GivenSessionWithParticipants_CourseHasSessionParticpants()
        {
            var model = new AddSessionModel()
            {
                Date = DateTime.UtcNow,
                Recordings = new[]
                {
                    new Video()
                    {
                        Id = 12345678L,
                        Name = "testVideo",
                        RecordTimeUtc = DateTime.UtcNow,
                        Properties = new VideoProperties()
                        {
                            MimeType = "test",
                            Duration = 0,
                            ContainerExt = "test"
                        }
                    }
                },
                ParticipantUserIds = new []
                {
                    1234567L
                }
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Admin()
                    {
                        Id = 1234567L,
                        UserName = "testUser12345"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser12345");
                },
                act: async (_, c) => await c.AddSession(-1, model),
                assert: (result, _, db) =>
                {
                    result.Should().BeOfType<OkResult>();
                    var courses = db.Courses.AsQueryable<Course>()
                              .Include(c => c.Sessions)
                              .ThenInclude(s => s.Recordings)
                              .Include(c => c.Sessions)
                              .ThenInclude(s => s.DbParticipants)
                              .ThenInclude(p => p.User);
                    courses.Should().Contain(c => c.Sessions.Any(s => s.Recordings.Any(v => v.Id == 12345678L)));
                    courses.Should().Contain(c => c.Sessions.Any(s => s.Participants.Any(p => p.Id == 1234567L)));
                });
        }

        [Fact]
        public async Task AddSession_GivenSessionWithoutVideos_ReturnsBadRequest()
        {
            var model = new AddSessionModel()
            {
                Date = DateTime.UtcNow
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Admin()
                    {
                        UserName = "testUser12345"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser12345");
                },
                act: async (_, c) => await c.AddSession(-1, model),
                assert: (result, _, db) => result.Should().BeOfType<BadRequestResult>());
        }

        [Fact]
        public async Task AddSession_CallingUserIsNotAdmin_ReturnsNotAuthorized()
        {
            var model = new AddSessionModel()
            {
                Date = DateTime.UtcNow,
                Recordings = new[] { new Video() }
            };
            await fixture.RunWithDatabaseAsync(
                arrange: async db =>
                {
                    db.Users.Add(new Student()
                    {
                        UserName = "testUser12345"
                    });
                    await db.SaveChangesAsync();
                    return ControllerFactory(db, "testUser12345");
                },
                act: async (_, c) => await c.AddSession(-1, model),
                assert: (result, _) => result.Should().BeOfType<UnauthorizedResult>());
        }
        private CoursesController ControllerFactory(Vc_webapiContext db, string userName)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("UserName", userName),
            }, "mock"));
            return new CoursesController(db)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = user
                    }
                }
            };
        }
    }
}
