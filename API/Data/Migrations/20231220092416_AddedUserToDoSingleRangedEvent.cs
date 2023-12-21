using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddedUserToDoSingleRangedEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDoEventName",
                table: "ToDoEvents",
                newName: "ToDoSingleEventName");

            migrationBuilder.RenameColumn(
                name: "ToDoEventDescription",
                table: "ToDoEvents",
                newName: "ToDoSingleEventDescription");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "ToDoEvents",
                newName: "SingleEventDate");

            migrationBuilder.CreateTable(
                name: "ToDoRangedEvents",
                columns: table => new
                {
                    ToDoRangedEventId = table.Column<string>(type: "TEXT", nullable: false),
                    ToDoRangedEventName = table.Column<string>(type: "TEXT", nullable: true),
                    ToDoRangedEventDescription = table.Column<string>(type: "TEXT", nullable: true),
                    RangedEventStartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RangedEventEndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoRangedEvents", x => x.ToDoRangedEventId);
                    table.ForeignKey(
                        name: "FK_ToDoRangedEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRangedEvents_UserId",
                table: "ToDoRangedEvents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoRangedEvents");

            migrationBuilder.RenameColumn(
                name: "ToDoSingleEventName",
                table: "ToDoEvents",
                newName: "ToDoEventName");

            migrationBuilder.RenameColumn(
                name: "ToDoSingleEventDescription",
                table: "ToDoEvents",
                newName: "ToDoEventDescription");

            migrationBuilder.RenameColumn(
                name: "SingleEventDate",
                table: "ToDoEvents",
                newName: "EventDate");
        }
    }
}
