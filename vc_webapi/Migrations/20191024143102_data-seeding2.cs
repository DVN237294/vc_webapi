using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vc_webapi.Migrations
{
    public partial class dataseeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 7, 26, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 7, 26, 14, 31, 2, 255, DateTimeKind.Utc).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.InsertData(
                table: "UserSession",
                columns: new[] { "Id", "SessionId", "UserId" },
                values: new object[,]
                {
                    { 100L, 100L, 100L },
                    { 101L, 101L, 100L },
                    { 102L, 102L, 100L },
                    { 103L, 103L, 100L }
                });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(7798));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSession",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "UserSession",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "UserSession",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "UserSession",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 7, 26, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 7, 26, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L,
                column: "Date",
                value: new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 24, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 31, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 10, 25, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 14, 12, 4, 951, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 14, 57, 4, 951, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 15, 42, 4, 951, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 1, 16, 37, 4, 951, DateTimeKind.Utc).AddTicks(4427));
        }
    }
}
