using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class LinkEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Links",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Links",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 1000, nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    SongId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_EventId",
                table: "Link",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_SongId",
                table: "Link",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Links",
                table: "Songs",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Links",
                table: "Events",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
