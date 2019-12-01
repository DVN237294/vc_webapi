using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vc_webapi.Migrations
{
    public partial class addnotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    NotificationTimeUtc = table.Column<DateTime>(nullable: false),
                    Dismissed = table.Column<bool>(nullable: false),
                    RouterLink = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouterLinkParam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Param = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    NotificationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouterLinkParam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouterLinkParam_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentTime", "Message", "UserId", "VideoId" },
                values: new object[] { -1L, new DateTime(2019, 10, 5, 22, 3, 59, 0, DateTimeKind.Unspecified), "Comment to test notifications! @teststudent", -1L, -1L });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Dismissed", "Message", "NotificationTimeUtc", "RouterLink", "UserId" },
                values: new object[] { -1L, false, "You were mentioned in a comment by BPR Test Student, in video \"SDJ Lesson 1\"", new DateTime(2019, 10, 5, 22, 4, 2, 0, DateTimeKind.Unspecified), "Comment", -1L });

            migrationBuilder.InsertData(
                table: "RouterLinkParam",
                columns: new[] { "Id", "NotificationId", "Param", "Value" },
                values: new object[,]
                {
                    { -1L, -1L, "VideoId", "-1" },
                    { -2L, -1L, "CommentId", "-1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RouterLinkParam_NotificationId",
                table: "RouterLinkParam",
                column: "NotificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouterLinkParam");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: -1L);
        }
    }
}
