using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Updateinventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a0d68896-6e89-46a4-a9e7-2b0aa17edc97"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("76fc0760-be56-4c90-b09c-fde6436050f9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("254a86dd-3e41-45b8-bb91-f97ee3b17c70"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aac63b91-beb8-4de4-b050-f2888fdff282"));

            migrationBuilder.RenameColumn(
                name: "ImportPrice",
                table: "Inventories",
                newName: "TotalImportPrice");

            migrationBuilder.RenameColumn(
                name: "ExportPrice",
                table: "Inventories",
                newName: "TotalExportPrice");

            migrationBuilder.AlterColumn<Guid>(
                name: "JewelryId",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InventoryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JewelryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExportPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDetails_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDetails_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetails_InventoryId",
                table: "InventoryDetails",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetails_JewelryId",
                table: "InventoryDetails",
                column: "JewelryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories",
                column: "JewelryId",
                principalTable: "Jewelries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "InventoryDetails");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "TotalImportPrice",
                table: "Inventories",
                newName: "ImportPrice");

            migrationBuilder.RenameColumn(
                name: "TotalExportPrice",
                table: "Inventories",
                newName: "ExportPrice");

            migrationBuilder.AlterColumn<Guid>(
                name: "JewelryId",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "IsActive", "RoleName", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("254a86dd-3e41-45b8-bb91-f97ee3b17c70"), null, null, false, true, "Admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "IsActive", "RoleName", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("a0d68896-6e89-46a4-a9e7-2b0aa17edc97"), null, null, false, true, "User", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birthday", "Code", "Created", "CreatedBy", "Deleted", "Email", "FirstName", "FullName", "Gender", "IdentityCard", "IdentityCardAddress", "IdentityCardDate", "IsActive", "IsAdmin", "LastName", "Password", "Phone", "PurchaseRevenue", "RefreshToken", "RefreshTokenExpiryTime", "Status", "Updated", "UpdatedBy", "UserName" },
                values: new object[] { new Guid("aac63b91-beb8-4de4-b050-f2888fdff282"), "Binh Phuoc", null, "AD-01", new DateTimeOffset(new DateTime(2025, 1, 10, 13, 58, 16, 593, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), false, "admin@gmail.com", "Tri", "Tran Huu Tri", 1, "12345", "Binh Phuoc", new DateTimeOffset(new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), true, true, "Tran", "FF9A32AB4A6E687FF64C2A139A9D04BD3AD58F10", "0333444555", 0m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "IsActive", "RoleId", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("76fc0760-be56-4c90-b09c-fde6436050f9"), null, null, false, true, new Guid("254a86dd-3e41-45b8-bb91-f97ee3b17c70"), null, null, new Guid("aac63b91-beb8-4de4-b050-f2888fdff282") });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Jewelries_JewelryId",
                table: "Inventories",
                column: "JewelryId",
                principalTable: "Jewelries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
