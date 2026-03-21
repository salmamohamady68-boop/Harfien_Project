using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAndRelationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "918806bf-7a6e-4422-853f-dd8e32295e4e", "AQAAAAIAAYagAAAAEAo5rbAWJ5Uty6VL0GBWzMe0Mj/w2LreCcO8yFLN1BE1zEzzQfAUlekAHpPtctshiQ==", "61937ce6-e0de-4189-86c3-9060ef2ee941" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a657a756-9d48-4dd9-811b-996d594506bc", "AQAAAAIAAYagAAAAEArzG7XgJVt3gKpzk/wD6KOWJtTdT4AbcClJmPfkec2cIfJfKGZsHaWZGZp08dNbIQ==", "0e567d07-491f-41b8-8774-ac335401708f" });
        }
    }
}
