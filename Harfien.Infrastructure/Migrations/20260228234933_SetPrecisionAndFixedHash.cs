using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetPrecisionAndFixedHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "10b1abfa-1929-462d-8a4f-4d5eeb22c9bc", "cab06db5-3cf8-48de-84f4-06c4b64dc228" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cff27653-9255-41ec-9a1b-e94e534dee9a", "21323b9f-3234-487d-8e3b-5aa597ae3b88" });
        }
    }
}
