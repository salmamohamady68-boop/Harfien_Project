using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddResetColumnsToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4474bdb8-9591-4b90-a46f-86b828a09753", "AQAAAAIAAYagAAAAEDxlTb5/0unSSn9yGWgSsovDrl8WaprZEs62lTPFxhsWAq2t3e/3qT9IlXi15B8FhQ==", "d29a8cda-e482-4b2c-9592-f057b2804d6b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbe12a76-7b09-4b33-9772-ac1308e8932f", "AQAAAAIAAYagAAAAENth+esUJykMl/Qt3cruUXN5UHorCE06y4XV+G3+VEZffp0RLtp8MBqc1oMvXxsBXA==", "5bc7d50d-12da-4ae4-9746-b9078c6375f4" });
        }
    }
}
