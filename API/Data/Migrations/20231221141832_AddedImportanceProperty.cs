using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddedImportanceProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SingleEventImportance",
                table: "ToDoSingleEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RangedEventImportance",
                table: "ToDoRangedEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SingleEventImportance",
                table: "ToDoSingleEvents");

            migrationBuilder.DropColumn(
                name: "RangedEventImportance",
                table: "ToDoRangedEvents");
        }
    }
}
