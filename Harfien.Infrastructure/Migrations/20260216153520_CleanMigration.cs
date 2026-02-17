using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CleanMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06a78b48-cb6b-4ed7-836f-bf7d7d9bd6b5", "AQAAAAIAAYagAAAAEH2pzDRlRnL9gi5jTmAQpgWW2hgEGqOc8wUc0UBtVgW8fYdZVC8YA+hntdzkUk0qfA==", "df87c994-fd37-45dc-8503-83edecce0356" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "169c78ea-252f-4f9b-ab72-452a570214f2", "AQAAAAIAAYagAAAAEOm4kSQAwMLXzhzi70EoKf8WJUh9Bl1M9u4u3B0oEUHXIDR+RGyVNsKH/4rx9enfSA==", "1a843e63-1923-487d-b898-bb66154ab73d" });
        }
    }
}
