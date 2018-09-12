using Microsoft.EntityFrameworkCore.Migrations;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class ModelCleaned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SheetType",
                table: "Songs",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "SheetType",
                value: "Unified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SheetType",
                table: "Songs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "SheetType",
                value: 0);
        }
    }
}
