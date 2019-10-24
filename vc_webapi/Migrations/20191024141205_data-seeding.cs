using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vc_webapi.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100L, "SDJ1" },
                    { 101L, "AJP1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FullName", "UserName" },
                values: new object[] { 100L, "Student", "some@mail.com", "BPR Test Student", "teststudent" });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDateUtc", "UserId" },
                values: new object[,]
                {
                    { 100L, 100L, new DateTime(2019, 7, 26, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(5934), 100L },
                    { 101L, 101L, new DateTime(2019, 7, 26, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(6595), 100L }
                });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "CourseId", "Date" },
                values: new object[,]
                {
                    { 100L, 100L, new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(2787) },
                    { 101L, 100L, new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(3354) },
                    { 102L, 101L, new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4428) },
                    { 103L, 101L, new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4430) }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Duration", "Name", "RecordTimeUtc", "SessionId", "ThumbnailURL", "URL" },
                values: new object[,]
                {
                    { 100L, 10L, "SDJ Lesson 1", new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(1657), 100L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 101L, 10L, "SDJ Lesson 1 part 2", new DateTime(2019, 10, 24, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(2673), 100L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 102L, 10L, "SDJ Lesson 1 part 3", new DateTime(2019, 10, 24, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(2741), 100L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 103L, 10L, "SDJ Lesson 1 part 4", new DateTime(2019, 10, 24, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(2743), 100L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 104L, 10L, "SDJ Lesson 2", new DateTime(2019, 10, 31, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(2744), 101L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 105L, 10L, "SDJ Lesson 2 part 2", new DateTime(2019, 10, 31, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(2755), 101L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 106L, 10L, "SDJ Lesson 2 part 3", new DateTime(2019, 10, 31, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(2756), 101L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 107L, 10L, "SDJ Lesson 2 part 3", new DateTime(2019, 10, 31, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(2757), 101L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 108L, 10L, "AJP Lesson 1", new DateTime(2019, 10, 25, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4416), 102L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 109L, 10L, "AJP Lesson 1 part 2", new DateTime(2019, 10, 25, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(4421), 102L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 110L, 10L, "AJP Lesson 1 part 3", new DateTime(2019, 10, 25, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(4423), 102L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 111L, 10L, "AJP Lesson 1 part 4", new DateTime(2019, 10, 25, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(4424), 102L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 112L, 10L, "AJP Lesson 2", new DateTime(2019, 11, 1, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4425), 103L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 113L, 10L, "AJP Lesson 2 part 2", new DateTime(2019, 11, 1, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(4425), 103L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 114L, 10L, "AJP Lesson 2 part 3", new DateTime(2019, 11, 1, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(4426), 103L, "/assets/video.jpeg", "/assets/testvideo.mp4" },
                    { 115L, 10L, "AJP Lesson 2 part 3", new DateTime(2019, 11, 1, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(4427), 103L, "/assets/video.jpeg", "/assets/testvideo.mp4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 101L);
        }
    }
}
