using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class initial20 : Migration
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
                    { 9223372036854775807L, "SDJ1", 9223372036854775807L },
                    { 9223372036854775806L, "AJP1", 9223372036854775806L }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "WebuntisId" },
                values: new object[,]
                {
                    { 9223372036854775807L, "F.301a UV", 1319L },
                    { 9223372036854775806L, "F.301b UV", 1320L },
                    { 9223372036854775805L, "F.302a UV", 1321L },
                    { 9223372036854775804L, "F.302b UV", 1322L },
                    { 9223372036854775803L, "F.304 UV", 1323L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FullName", "UserName" },
                values: new object[] { 9223372036854775807L, "Student", "some@mail.com", "BPR Test Student", "teststudent" });

            migrationBuilder.InsertData(
                table: "VideoProperties",
                columns: new[] { "Id", "ContainerExt", "Duration", "FileSize", "Height", "MimeType", "VirtualFilePath", "Width" },
                values: new object[] { 9223372036854775807L, "mp4", 10000L, 788493L, 176, "video/mp4", "testvideo.mp4", 320 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDateUtc", "UserId" },
                values: new object[,]
                {
                    { 9223372036854775807L, 9223372036854775807L, new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775807L },
                    { 9223372036854775806L, 9223372036854775806L, new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775807L }
                });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "CourseId", "Date" },
                values: new object[,]
                {
                    { 9223372036854775807L, 9223372036854775807L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { 9223372036854775806L, 9223372036854775807L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { 9223372036854775805L, 9223372036854775806L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) },
                    { 9223372036854775804L, 9223372036854775806L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "Id", "SessionId", "UserId" },
                values: new object[,]
                {
                    { 9223372036854775807L, 9223372036854775807L, 9223372036854775807L },
                    { 9223372036854775804L, 9223372036854775804L, 9223372036854775807L },
                    { 9223372036854775806L, 9223372036854775806L, 9223372036854775807L },
                    { 9223372036854775805L, 9223372036854775805L, 9223372036854775807L }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Name", "PropertiesId", "RecordTimeUtc", "SessionId", "StreamUrl", "ThumbnailURL" },
                values: new object[,]
                {
                    { 9223372036854775794L, "AJP Lesson 2 part 2", 9223372036854775807L, new DateTime(2019, 12, 1, 2, 33, 40, 606, DateTimeKind.Utc), 9223372036854775804L, "/api/Videostream/113", "/assets/video.jpeg" },
                    { 9223372036854775795L, "AJP Lesson 2", 9223372036854775807L, new DateTime(2019, 12, 1, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775804L, "/api/Videostream/112", "/assets/video.jpeg" },
                    { 9223372036854775796L, "AJP Lesson 1 part 4", 9223372036854775807L, new DateTime(2019, 11, 24, 4, 13, 40, 606, DateTimeKind.Utc), 9223372036854775805L, "/api/Videostream/111", "/assets/video.jpeg" },
                    { 9223372036854775797L, "AJP Lesson 1 part 3", 9223372036854775807L, new DateTime(2019, 11, 24, 3, 18, 40, 606, DateTimeKind.Utc), 9223372036854775805L, "/api/Videostream/110", "/assets/video.jpeg" },
                    { 9223372036854775798L, "AJP Lesson 1 part 2", 9223372036854775807L, new DateTime(2019, 11, 24, 2, 33, 40, 606, DateTimeKind.Utc), 9223372036854775805L, "/api/Videostream/109", "/assets/video.jpeg" },
                    { 9223372036854775799L, "AJP Lesson 1", 9223372036854775807L, new DateTime(2019, 11, 24, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775805L, "/api/Videostream/108", "/assets/video.jpeg" },
                    { 9223372036854775800L, "SDJ Lesson 2 part 4", 9223372036854775807L, new DateTime(2019, 11, 30, 4, 13, 40, 606, DateTimeKind.Utc), 9223372036854775806L, "/api/Videostream/107", "/assets/video.jpeg" },
                    { 9223372036854775801L, "SDJ Lesson 2 part 3", 9223372036854775807L, new DateTime(2019, 11, 30, 3, 18, 40, 606, DateTimeKind.Utc), 9223372036854775806L, "/api/Videostream/106", "/assets/video.jpeg" },
                    { 9223372036854775802L, "SDJ Lesson 2 part 2", 9223372036854775807L, new DateTime(2019, 11, 30, 2, 33, 40, 606, DateTimeKind.Utc), 9223372036854775806L, "/api/Videostream/105", "/assets/video.jpeg" },
                    { 9223372036854775803L, "SDJ Lesson 2", 9223372036854775807L, new DateTime(2019, 11, 30, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775806L, "/api/Videostream/104", "/assets/video.jpeg" },
                    { 9223372036854775804L, "SDJ Lesson 1 part 4", 9223372036854775807L, new DateTime(2019, 11, 23, 4, 13, 40, 606, DateTimeKind.Utc), 9223372036854775807L, "/api/Videostream/103", "/assets/video.jpeg" },
                    { 9223372036854775805L, "SDJ Lesson 1 part 3", 9223372036854775807L, new DateTime(2019, 11, 23, 3, 18, 40, 606, DateTimeKind.Utc), 9223372036854775807L, "/api/Videostream/102", "/assets/video.jpeg" },
                    { 9223372036854775806L, "SDJ Lesson 1 part 2", 9223372036854775807L, new DateTime(2019, 11, 23, 2, 33, 40, 606, DateTimeKind.Utc), 9223372036854775807L, "/api/Videostream/101", "/assets/video.jpeg" },
                    { 9223372036854775807L, "SDJ Lesson 1", 9223372036854775807L, new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc), 9223372036854775807L, "/api/Videostream/100", "/assets/video.jpeg" },
                    { 9223372036854775793L, "AJP Lesson 2 part 3", 9223372036854775807L, new DateTime(2019, 12, 1, 3, 18, 40, 606, DateTimeKind.Utc), 9223372036854775804L, "/api/Videostream/114", "/assets/video.jpeg" },
                    { 9223372036854775792L, "AJP Lesson 2 part 4", 9223372036854775807L, new DateTime(2019, 12, 1, 4, 13, 40, 606, DateTimeKind.Utc), 9223372036854775804L, "/api/Videostream/115", "/assets/video.jpeg" }
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
