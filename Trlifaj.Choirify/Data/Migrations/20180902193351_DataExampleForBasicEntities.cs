using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class DataExampleForBasicEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rehearsals",
                columns: new[] { "Id", "Date", "Description", "IsDeleted" },
                values: new object[] { 1, new DateTime(2018, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "První zkouška semestru", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rehearsals",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
