using Microsoft.EntityFrameworkCore.Migrations;

namespace vc_webapi.Migrations
{
    public partial class add_Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTeacher",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTeacher",
                table: "Users");
        }
    }
}
