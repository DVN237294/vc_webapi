using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class addvideoproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PropertiesId",
                table: "Videos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StreamUrl",
                table: "Videos",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 100L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 8, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 101L,
                column: "EnrollmentDateUtc",
                value: new DateTime(2019, 8, 8, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Date",
                value: new DateTime(2019, 11, 6, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 101L,
                column: "Date",
                value: new DateTime(2019, 11, 6, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 102L,
                column: "Date",
                value: new DateTime(2019, 11, 6, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 103L,
                column: "Date",
                value: new DateTime(2019, 11, 6, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.InsertData(
                table: "VideoProperties",
                columns: new[] { "Id", "ContainerExt", "Duration", "FileSize", "Height", "MimeType", "VirtualFilePath", "Width" },
                values: new object[] { 100L, "mp4", 10000L, 788493L, 176, "video/mp4", "testvideo.mp4", 320 });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 6, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(2974), "/api/Videostream/100" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 6, 17, 36, 18, 750, DateTimeKind.Utc).AddTicks(4722), "/api/Videostream/101" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 6, 18, 21, 18, 750, DateTimeKind.Utc).AddTicks(4795), "/api/Videostream/102" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 6, 19, 16, 18, 750, DateTimeKind.Utc).AddTicks(4798), "/api/Videostream/103" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 13, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(4799), "/api/Videostream/104" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 13, 17, 36, 18, 750, DateTimeKind.Utc).AddTicks(4815), "/api/Videostream/105" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 13, 18, 21, 18, 750, DateTimeKind.Utc).AddTicks(4817), "/api/Videostream/106" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 13, 19, 16, 18, 750, DateTimeKind.Utc).AddTicks(4819), "/api/Videostream/107" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 7, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(6353), "/api/Videostream/108" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 7, 17, 36, 18, 750, DateTimeKind.Utc).AddTicks(6360), "/api/Videostream/109" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 7, 18, 21, 18, 750, DateTimeKind.Utc).AddTicks(6362), "/api/Videostream/110" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 7, 19, 16, 18, 750, DateTimeKind.Utc).AddTicks(6363), "/api/Videostream/111" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 14, 16, 51, 18, 750, DateTimeKind.Utc).AddTicks(6365), "/api/Videostream/112" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 14, 17, 36, 18, 750, DateTimeKind.Utc).AddTicks(6366), "/api/Videostream/113" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 14, 18, 21, 18, 750, DateTimeKind.Utc).AddTicks(6368), "/api/Videostream/114" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                columns: new[] { "PropertiesId", "RecordTimeUtc", "StreamUrl" },
                values: new object[] { 100L, new DateTime(2019, 11, 14, 19, 16, 18, 750, DateTimeKind.Utc).AddTicks(6369), "/api/Videostream/115" });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PropertiesId",
                table: "Videos",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoProperties_PropertiesId",
                table: "Videos",
                column: "PropertiesId",
                principalTable: "VideoProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoProperties_PropertiesId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "VideoProperties");

            migrationBuilder.DropIndex(
                name: "IX_Videos_PropertiesId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "PropertiesId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "StreamUrl",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Videos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "Duration",
                table: "Videos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Videos",
                type: "text",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 100L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 24, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(5127), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 101L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 24, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(6065), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 102L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 24, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(6133), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 103L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 24, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(6134), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 104L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 31, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(6136), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 105L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 31, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(6147), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 106L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 31, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(6148), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 107L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 31, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(6149), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 108L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 25, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7788), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 109L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 25, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(7792), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 110L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 25, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(7793), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 10, 25, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(7794), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 112L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 11, 1, 14, 31, 2, 254, DateTimeKind.Utc).AddTicks(7795), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 113L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 11, 1, 15, 16, 2, 254, DateTimeKind.Utc).AddTicks(7796), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 114L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 11, 1, 16, 1, 2, 254, DateTimeKind.Utc).AddTicks(7797), "/assets/testvideo.mp4" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 115L,
                columns: new[] { "Duration", "RecordTimeUtc", "URL" },
                values: new object[] { 10L, new DateTime(2019, 11, 1, 16, 56, 2, 254, DateTimeKind.Utc).AddTicks(7798), "/assets/testvideo.mp4" });
        }
    }
}
