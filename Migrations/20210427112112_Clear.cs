using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class Clear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
