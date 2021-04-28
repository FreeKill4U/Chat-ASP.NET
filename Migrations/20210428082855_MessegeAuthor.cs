using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class MessegeAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messeges_Chats_ChatId",
                table: "Messeges");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Messeges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Messeges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Messeges_Chats_ChatId",
                table: "Messeges",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messeges_Chats_ChatId",
                table: "Messeges");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Messeges");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Messeges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messeges_Chats_ChatId",
                table: "Messeges",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
