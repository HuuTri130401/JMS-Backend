using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateinventoryv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_JewelryId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "JewelryId",
                table: "Inventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JewelryId",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_JewelryId",
                table: "Inventories",
                column: "JewelryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories",
                column: "JewelryId",
                principalTable: "Jewelries",
                principalColumn: "Id");
        }
    }
}
