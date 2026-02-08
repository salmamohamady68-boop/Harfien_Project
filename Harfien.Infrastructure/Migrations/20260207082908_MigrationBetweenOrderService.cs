using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationBetweenOrderService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5143ea-3aa6-4a2f-bfb1-38753258acd6", new DateTime(2026, 2, 7, 8, 29, 3, 164, DateTimeKind.Utc).AddTicks(4705), "AQAAAAIAAYagAAAAEMujV9cOMHBNlfJEJOP9o6Kpqkwii02dRzwm2fOigOcz8+v76b/uKD+piV7EloUHmQ==", "b1bfa19f-84f9-4650-ba36-9143c3995513" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 8, 29, 3, 532, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3cc7692-89c8-4615-8e03-0e92301664a2", new DateTime(2026, 2, 7, 4, 0, 20, 575, DateTimeKind.Utc).AddTicks(6586), "AQAAAAIAAYagAAAAEHWyHP8+eTf0gvV8p3c7l+WxOnunacxQQRHifz38ikmjQQ8feVzDaNPpsyK8H9QNtg==", "96b33725-45fb-40b1-a274-473b47cf8328" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 7, 4, 0, 20, 862, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
