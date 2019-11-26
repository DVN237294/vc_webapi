using Microsoft.EntityFrameworkCore.Migrations;

namespace vc_webapi.Migrations
{
    public partial class commentupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "text",
                nullable: true);
        }
    }
}
