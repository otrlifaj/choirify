using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trlifaj.Choirify.Data.Migrations
{
    public partial class AddedChoirmasterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Singers_SingerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SingerId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ChoirmasterId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Choirmasters",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NumberOfIDCard = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    PassportNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choirmasters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChoirmasterId",
                table: "AspNetUsers",
                column: "ChoirmasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Choirmasters_ChoirmasterId",
                table: "AspNetUsers",
                column: "ChoirmasterId",
                principalTable: "Choirmasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Singers_SingerId",
                table: "AspNetUsers",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Choirmasters_ChoirmasterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Singers_SingerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Choirmasters");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChoirmasterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChoirmasterId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SingerId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Singers_SingerId",
                table: "AspNetUsers",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
