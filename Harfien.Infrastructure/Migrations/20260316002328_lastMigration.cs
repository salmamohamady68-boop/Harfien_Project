using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Craftsmen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b97be9c-46c8-4cde-93c1-81ee8d46590c", "29d21b1a-a588-404d-bc72-b293db74e803" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Craftsmen");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42b16891-82be-4ad9-af88-a6d2a1ebcad5", "a974c4a5-3ecc-48d6-8b48-7a6147526d54" });
        }
    }
}
