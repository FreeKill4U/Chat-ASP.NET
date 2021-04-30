using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolaKomunikator.Migrations
{
    public partial class Rank1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Chats_ChatId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Users_UserId",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_UserId",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ranks");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ranks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Ranks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "AddUser",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Ranks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColorText",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GiveRank",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mention",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NewUser",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reaction",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoveUser",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendMessege",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendPhoto",
                table: "Ranks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RankId",
                table: "Users",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Chats_ChatId",
                table: "Ranks",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ranks_RankId",
                table: "Users",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Chats_ChatId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ranks_RankId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddUser",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "ColorText",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "GiveRank",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "Mention",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "NewUser",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "RemoveUser",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "SendMessege",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "SendPhoto",
                table: "Ranks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ranks",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_UserId",
                table: "Ranks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Chats_ChatId",
                table: "Ranks",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Users_UserId",
                table: "Ranks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
