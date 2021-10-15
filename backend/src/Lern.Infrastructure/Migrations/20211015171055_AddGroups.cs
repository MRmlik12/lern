using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lern.Infrastructure.Migrations
{
    public partial class AddGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Members",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SetCollection",
                table: "Sets",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Admin = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Users_Admin",
                        column: x => x.Admin,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Members",
                table: "Users",
                column: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_SetCollection",
                table: "Sets",
                column: "SetCollection");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Admin",
                table: "Groups",
                column: "Admin");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Groups_SetCollection",
                table: "Sets",
                column: "SetCollection",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_Members",
                table: "Users",
                column: "Members",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Groups_SetCollection",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_Members",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Users_Members",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sets_SetCollection",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Members",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SetCollection",
                table: "Sets");
        }
    }
}
