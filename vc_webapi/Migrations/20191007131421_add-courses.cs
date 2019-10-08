using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class addcourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Video",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordTimeUTC",
                table: "Video",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Video",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_CourseId",
                table: "Video",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Course_CourseId",
                table: "Video",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Course_CourseId",
                table: "Video");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Video_CourseId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "RecordTimeUTC",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Video");
        }
    }
}
