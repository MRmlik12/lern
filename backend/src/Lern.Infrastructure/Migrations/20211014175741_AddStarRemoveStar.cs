using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lern.Infrastructure.Migrations
{
    public partial class AddStarRemoveStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Stars",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Stars",
                table: "Users",
                column: "Stars");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sets_Stars",
                table: "Users",
                column: "Stars",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sets_Stars",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Stars",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Users");
        }
    }
}
