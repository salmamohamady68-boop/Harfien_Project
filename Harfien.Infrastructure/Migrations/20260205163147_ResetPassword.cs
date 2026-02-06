using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetSession",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetSessionExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PasswordResetSession", "PasswordResetSessionExpiry", "SecurityStamp" },
                values: new object[] { "e58f7f4e-4ae7-46a7-af52-5a12043e2eb3", new DateTime(2026, 2, 5, 16, 31, 44, 244, DateTimeKind.Utc).AddTicks(183), "AQAAAAIAAYagAAAAECwdd4LX3i0bHi2LFfmlijeqglR4Ad9E0iSVwkeRTpXqlAQ7W/2cHSIb9mjoDEvniQ==", null, null, "12abbfa9-657b-4652-acff-f64ff5e5a96a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetSession",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordResetSessionExpiry",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bb33714-4802-4af3-a7f7-0b241483be62", new DateTime(2026, 2, 4, 16, 23, 23, 459, DateTimeKind.Utc).AddTicks(431), "AQAAAAIAAYagAAAAENYc1cAmu+9OMpg/Pil9jtSNJzlizBoHCJEt/viF6x0757P5DZDAi6JkdcA/mOswWA==", "1a444286-5dae-41f2-b616-9f025daacb39" });
        }
    }
}
