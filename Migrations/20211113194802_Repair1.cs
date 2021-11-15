using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class Repair1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Icon",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Chats");
        }
    }
}
