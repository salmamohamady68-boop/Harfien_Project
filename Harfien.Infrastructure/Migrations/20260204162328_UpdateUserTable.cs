using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetCodeExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "ResetCode", "ResetCodeExpiry", "SecurityStamp" },
                values: new object[] { "4bb33714-4802-4af3-a7f7-0b241483be62", new DateTime(2026, 2, 4, 16, 23, 23, 459, DateTimeKind.Utc).AddTicks(431), "AQAAAAIAAYagAAAAENYc1cAmu+9OMpg/Pil9jtSNJzlizBoHCJEt/viF6x0757P5DZDAi6JkdcA/mOswWA==", null, null, "1a444286-5dae-41f2-b616-9f025daacb39" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetCodeExpiry",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c06c7e77-11d7-4c81-bf31-cffe21639031", new DateTime(2026, 2, 3, 13, 35, 4, 896, DateTimeKind.Utc).AddTicks(8054), "AQAAAAIAAYagAAAAEO4thzCYn3NMM3A/VD+yNDZ9E0cIDuhvYUlTv9OPTXSjTSNWR8/loBspc+F327b5QA==", "0a838cd3-f1a6-450d-b644-d872efec6513" });
        }
    }
}
