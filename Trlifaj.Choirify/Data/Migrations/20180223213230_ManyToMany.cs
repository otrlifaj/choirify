using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rehearsals_RehearsalId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Events_EventId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Songs_SongId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Events_EventId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_EventId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Link",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RehearsalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RehearsalId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Link",
                newName: "Links");

            migrationBuilder.RenameIndex(
                name: "IX_Link_SongId",
                table: "Links",
                newName: "IX_Links_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_EventId",
                table: "Links",
                newName: "IX_Links_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Attended = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    SingerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAttendances_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventAttendances_AspNetUsers_SingerId",
                        column: x => x.SingerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    SongId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSongs_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RehearsalAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Attended = table.Column<bool>(nullable: false),
                    RehearsalId = table.Column<int>(nullable: true),
                    SingerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehearsalAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RehearsalAttendances_Rehearsals_RehearsalId",
                        column: x => x.RehearsalId,
                        principalTable: "Rehearsals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RehearsalAttendances_AspNetUsers_SingerId",
                        column: x => x.SingerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RehearsalSongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RehearsalId = table.Column<int>(nullable: true),
                    SongId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehearsalSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RehearsalSongs_Rehearsals_RehearsalId",
                        column: x => x.RehearsalId,
                        principalTable: "Rehearsals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RehearsalSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_EventId",
                table: "EventAttendances",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_SingerId",
                table: "EventAttendances",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSongs_EventId",
                table: "EventSongs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSongs_SongId",
                table: "EventSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalAttendances_RehearsalId",
                table: "RehearsalAttendances",
                column: "RehearsalId");

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalAttendances_SingerId",
                table: "RehearsalAttendances",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalSongs_RehearsalId",
                table: "RehearsalSongs",
                column: "RehearsalId");

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalSongs_SongId",
                table: "RehearsalSongs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Events_EventId",
                table: "Links",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Songs_SongId",
                table: "Links",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Events_EventId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Songs_SongId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "EventAttendances");

            migrationBuilder.DropTable(
                name: "EventSongs");

            migrationBuilder.DropTable(
                name: "RehearsalAttendances");

            migrationBuilder.DropTable(
                name: "RehearsalSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "Link");

            migrationBuilder.RenameIndex(
                name: "IX_Links_SongId",
                table: "Link",
                newName: "IX_Link_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_EventId",
                table: "Link",
                newName: "IX_Link_EventId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RehearsalId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Link",
                table: "Link",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_EventId",
                table: "Songs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RehearsalId",
                table: "AspNetUsers",
                column: "RehearsalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rehearsals_RehearsalId",
                table: "AspNetUsers",
                column: "RehearsalId",
                principalTable: "Rehearsals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Events_EventId",
                table: "Link",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Songs_SongId",
                table: "Link",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Events_EventId",
                table: "Songs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
