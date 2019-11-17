using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vc_webapi.Migrations
{
    public partial class addTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTeacher",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 13, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 13, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Date",
                value: new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L,
                column: "Date",
                value: new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L,
                column: "Date",
                value: new DateTime(2019, 11, 11, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L,
                column: "Date",
                value: new DateTime(2019, 11, 11, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 21, 17, 55, 189, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 22, 2, 55, 189, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 22, 57, 55, 189, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 21, 17, 55, 189, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 22, 2, 55, 189, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 22, 57, 55, 189, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 12, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 12, 21, 17, 55, 190, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 12, 22, 2, 55, 190, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 12, 22, 57, 55, 190, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 19, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 19, 21, 17, 55, 190, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 19, 22, 2, 55, 190, DateTimeKind.Utc).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 19, 22, 57, 55, 190, DateTimeKind.Utc).AddTicks(128));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTeacher",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 12, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 12, 14, 34, 26, 264, DateTimeKind.Utc).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Date",
                value: new DateTime(2019, 11, 10, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L,
                column: "Date",
                value: new DateTime(2019, 11, 10, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L,
                column: "Date",
                value: new DateTime(2019, 11, 10, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L,
                column: "Date",
                value: new DateTime(2019, 11, 10, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 10, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 10, 15, 19, 26, 263, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 10, 16, 4, 26, 263, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 10, 16, 59, 26, 263, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 17, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 17, 15, 19, 26, 263, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 17, 16, 4, 26, 263, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 17, 16, 59, 26, 263, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 15, 19, 26, 263, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 16, 4, 26, 263, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 11, 16, 59, 26, 263, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 14, 34, 26, 263, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 15, 19, 26, 263, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 16, 4, 26, 263, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                column: "RecordTimeUtc",
                value: new DateTime(2019, 11, 18, 16, 59, 26, 263, DateTimeKind.Utc).AddTicks(7708));
        }
    }
}
