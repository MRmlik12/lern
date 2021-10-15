using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lern.Infrastructure.Migrations
{
    public partial class AddGroupFixWithMembersSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Groups_SetCollection",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_Members",
                table: "Users");

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

            migrationBuilder.AddColumn<List<Guid>>(
                name: "MembersId",
                table: "Groups",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "SetCollectionId",
                table: "Groups",
                type: "uuid[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembersId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SetCollectionId",
                table: "Groups");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Members",
                table: "Users",
                column: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_SetCollection",
                table: "Sets",
                column: "SetCollection");

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
    }
}
