using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class RangesExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Singers",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rehearsals",
                type: "varchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "News",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "News",
                type: "varchar(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Links",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Choirmasters",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "varchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Singers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rehearsals",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "News",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "News",
                type: "varchar(1500)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Links",
                type: "varchar(255)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Choirmasters",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "varchar(1000)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndOfRegistration", "EventType", "From", "ImageUrl", "IsDeleted", "Name", "Organizer", "Place", "StartOfRegistration", "To" },
                values: new object[] { 1, "Nějaký popis události", new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concert", new DateTime(2018, 9, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Soustředění xyz", null, "Konvikt", new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rehearsals",
                columns: new[] { "Id", "Date", "Description", "IsDeleted" },
                values: new object[] { 1, new DateTime(2018, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "První zkouška semestru", false });

            migrationBuilder.InsertData(
                table: "Singers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "ImageUrl", "IsActive", "IsDeleted", "NumberOfIDCard", "PassportNumber", "PhoneNumber", "Surname", "VoiceGroup" },
                values: new object[] { 1, "Adresa ondry trlifaje", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ondra.trli@centrum.cz", "Ondřej", null, true, false, "123456", "654321", "+420123456789", "Trlifaj", "B2" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Author", "Current", "Description", "Duration", "IsDeleted", "Name", "SheetType", "SheetsAvailable" },
                values: new object[] { 1, "Green day", true, null, new TimeSpan(0, 0, 0, 0, 0), false, "21 Guns", "Unified", 1 });
        }
    }
}
