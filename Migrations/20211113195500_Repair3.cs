using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class Repair3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Icon",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IconColor",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IconColor",
                table: "Users");
        }
    }
}
