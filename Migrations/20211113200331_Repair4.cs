using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class Repair4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Chats");
        }
    }
}
