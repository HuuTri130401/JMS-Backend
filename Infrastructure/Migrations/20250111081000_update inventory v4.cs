using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateinventoryv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("aac63b91-beb8-4de4-b050-f2888fdff282"), "Binh Phuoc", null, "AD-01", new DateTimeOffset(new DateTime(2025, 1, 11, 15, 10, 0, 23, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), false, "admin@gmail.com", "Tri", "Tran Huu Tri", 1, "12345", "Binh Phuoc", new DateTimeOffset(new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), true, true, "Tran", "FF9A32AB4A6E687FF64C2A139A9D04BD3AD58F10", "0333444555", 0m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "IsActive", "RoleId", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("76fc0760-be56-4c90-b09c-fde6436050f9"), null, null, false, true, new Guid("254a86dd-3e41-45b8-bb91-f97ee3b17c70"), null, null, new Guid("aac63b91-beb8-4de4-b050-f2888fdff282") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
