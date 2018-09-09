using Microsoft.EntityFrameworkCore.Migrations;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class EventTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "Events",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Events");
        }
    }
}
