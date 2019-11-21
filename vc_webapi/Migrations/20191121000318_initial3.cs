using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebuntisCourseId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.UniqueConstraint("AK_Courses_WebuntisCourseId", x => x.WebuntisCourseId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebuntisId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    isTeacher = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoProperties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    VirtualFilePath = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    MimeType = table.Column<string>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    ContainerExt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledSessions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebuntisId = table.Column<long>(nullable: false),
                    WebuntisCourseId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    WebuntisTeacherIds = table.Column<long[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledSessions", x => x.Id);
                    table.UniqueConstraint("AK_ScheduledSessions_WebuntisId", x => x.WebuntisId);
                    table.ForeignKey(
                        name: "FK_ScheduledSessions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledSessions_Courses_WebuntisCourseId",
                        column: x => x.WebuntisCourseId,
                        principalTable: "Courses",
                        principalColumn: "WebuntisCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: true),
                    CourseId = table.Column<long>(nullable: true),
                    EnrollmentDateUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: false),
                    SessionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertiesId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ThumbnailURL = table.Column<string>(nullable: true),
                    RecordTimeUtc = table.Column<DateTime>(nullable: false),
                    StreamUrl = table.Column<string>(nullable: true),
                    SessionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_VideoProperties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "VideoProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    VideoId = table.Column<long>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CommentTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "WebuntisCourseId" },
                values: new object[,]
                {
                    { -1L, "SDJ1", -1L },
                    { -2L, "AJP1", -2L }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "WebuntisId" },
                values: new object[,]
                {
                    { -1L, "F.301a UV", 1319L },
                    { -2L, "F.301b UV", 1320L },
                    { -3L, "F.302a UV", 1321L },
                    { -4L, "F.302b UV", 1322L },
                    { -5L, "F.304 UV", 1323L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FullName", "UserName", "isTeacher" },
                values: new object[] { -1L, "Student", "some@mail.com", "BPR Test Student", "teststudent", false });

            migrationBuilder.InsertData(
                table: "VideoProperties",
                columns: new[] { "Id", "ContainerExt", "Duration", "FileSize", "Height", "MimeType", "VirtualFilePath", "Width" },
                values: new object[] { -1L, "mp4", 10000L, 788493L, 176, "video/mp4", "testvideo.mp4", 320 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDateUtc", "UserId" },
                values: new object[,]
                {
                    { -1L, -1L, new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc), -1L },
                    { -2L, -2L, new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc), -1L }
                });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "CourseId", "Date" },
                values: new object[,]
                {
                    { -1L, -1L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { -2L, -1L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { -3L, -2L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { -4L, -2L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "Id", "SessionId", "UserId" },
                values: new object[,]
                {
                    { -1L, -1L, -1L },
                    { -4L, -4L, -1L },
                    { -2L, -2L, -1L },
                    { -3L, -3L, -1L }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Name", "PropertiesId", "RecordTimeUtc", "SessionId", "StreamUrl", "ThumbnailURL" },
                values: new object[,]
                {
                    { -14L, "AJP Lesson 2 part 2", -1L, new DateTime(2019, 12, 1, 2, 33, 40, 606, DateTimeKind.Utc), -4L, "/api/Videostream/-14", "/assets/video.jpeg" },
                    { -13L, "AJP Lesson 2", -1L, new DateTime(2019, 12, 1, 1, 48, 40, 606, DateTimeKind.Utc), -4L, "/api/Videostream/-13", "/assets/video.jpeg" },
                    { -12L, "AJP Lesson 1 part 4", -1L, new DateTime(2019, 11, 24, 4, 13, 40, 606, DateTimeKind.Utc), -3L, "/api/Videostream/-12", "/assets/video.jpeg" },
                    { -11L, "AJP Lesson 1 part 3", -1L, new DateTime(2019, 11, 24, 3, 18, 40, 606, DateTimeKind.Utc), -3L, "/api/Videostream/-11", "/assets/video.jpeg" },
                    { -10L, "AJP Lesson 1 part 2", -1L, new DateTime(2019, 11, 24, 2, 33, 40, 606, DateTimeKind.Utc), -3L, "/api/Videostream/-10", "/assets/video.jpeg" },
                    { -9L, "AJP Lesson 1", -1L, new DateTime(2019, 11, 24, 1, 48, 40, 606, DateTimeKind.Utc), -3L, "/api/Videostream/-9", "/assets/video.jpeg" },
                    { -8L, "SDJ Lesson 2 part 4", -1L, new DateTime(2019, 11, 30, 4, 13, 40, 606, DateTimeKind.Utc), -2L, "/api/Videostream/-8", "/assets/video.jpeg" },
                    { -7L, "SDJ Lesson 2 part 3", -1L, new DateTime(2019, 11, 30, 3, 18, 40, 606, DateTimeKind.Utc), -2L, "/api/Videostream/-7", "/assets/video.jpeg" },
                    { -6L, "SDJ Lesson 2 part 2", -1L, new DateTime(2019, 11, 30, 2, 33, 40, 606, DateTimeKind.Utc), -2L, "/api/Videostream/-6", "/assets/video.jpeg" },
                    { -5L, "SDJ Lesson 2", -1L, new DateTime(2019, 11, 30, 1, 48, 40, 606, DateTimeKind.Utc), -2L, "/api/Videostream/-5", "/assets/video.jpeg" },
                    { -4L, "SDJ Lesson 1 part 4", -1L, new DateTime(2019, 11, 23, 4, 13, 40, 606, DateTimeKind.Utc), -1L, "/api/Videostream/-4", "/assets/video.jpeg" },
                    { -3L, "SDJ Lesson 1 part 3", -1L, new DateTime(2019, 11, 23, 3, 18, 40, 606, DateTimeKind.Utc), -1L, "/api/Videostream/-3", "/assets/video.jpeg" },
                    { -2L, "SDJ Lesson 1 part 2", -1L, new DateTime(2019, 11, 23, 2, 33, 40, 606, DateTimeKind.Utc), -1L, "/api/Videostream/-2", "/assets/video.jpeg" },
                    { -1L, "SDJ Lesson 1", -1L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc), -1L, "/api/Videostream/-1", "/assets/video.jpeg" },
                    { -15L, "AJP Lesson 2 part 3", -1L, new DateTime(2019, 12, 1, 3, 18, 40, 606, DateTimeKind.Utc), -4L, "/api/Videostream/-15", "/assets/video.jpeg" },
                    { -16L, "AJP Lesson 2 part 4", -1L, new DateTime(2019, 12, 1, 4, 13, 40, 606, DateTimeKind.Utc), -4L, "/api/Videostream/-16", "/assets/video.jpeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId",
                table: "Comments",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_SessionId",
                table: "Participant",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_UserId",
                table: "Participant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Name",
                table: "Rooms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSessions_RoomId",
                table: "ScheduledSessions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSessions_WebuntisCourseId",
                table: "ScheduledSessions",
                column: "WebuntisCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_CourseId",
                table: "Session",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PropertiesId",
                table: "Videos",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_SessionId",
                table: "Videos",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "ScheduledSessions");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "VideoProperties");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
