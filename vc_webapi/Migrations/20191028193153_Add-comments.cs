using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class Addcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Videos_VideoId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_VideoId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "VideoId1",
                table: "Comments");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VideoId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId",
                table: "Comments",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_VideoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "VideoId1",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId1",
                table: "Comments",
                column: "VideoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Videos_VideoId1",
                table: "Comments",
                column: "VideoId1",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
