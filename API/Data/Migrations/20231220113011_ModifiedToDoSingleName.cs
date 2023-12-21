using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class ModifiedToDoSingleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoEvents_Users_UserId",
                table: "ToDoEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoEvents",
                table: "ToDoEvents");

            migrationBuilder.RenameTable(
                name: "ToDoEvents",
                newName: "ToDoSingleEvents");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoEvents_UserId",
                table: "ToDoSingleEvents",
                newName: "IX_ToDoSingleEvents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoSingleEvents",
                table: "ToDoSingleEvents",
                column: "ToDoEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoSingleEvents_Users_UserId",
                table: "ToDoSingleEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoSingleEvents_Users_UserId",
                table: "ToDoSingleEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoSingleEvents",
                table: "ToDoSingleEvents");

            migrationBuilder.RenameTable(
                name: "ToDoSingleEvents",
                newName: "ToDoEvents");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoSingleEvents_UserId",
                table: "ToDoEvents",
                newName: "IX_ToDoEvents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoEvents",
                table: "ToDoEvents",
                column: "ToDoEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoEvents_Users_UserId",
                table: "ToDoEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
