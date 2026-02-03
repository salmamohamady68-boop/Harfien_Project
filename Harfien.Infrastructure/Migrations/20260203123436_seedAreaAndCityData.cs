using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedAreaAndCityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8583), "Cairo" },
                    { 2, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8585), "Giza" },
                    { 3, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8586), "Alexanderia" },
                    { 4, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8587), "Aswan" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8812), "Maadi" },
                    { 2, 1, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8813), "Helwan" },
                    { 3, 1, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8814), "Ramses" },
                    { 4, 2, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8815), "El Omarania" },
                    { 5, 3, new DateTime(2026, 2, 3, 12, 34, 33, 909, DateTimeKind.Utc).AddTicks(8816), "Naga Elarab" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
