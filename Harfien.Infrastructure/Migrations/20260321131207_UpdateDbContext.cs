using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPlanDetails_SubscriptionPlan_SubscriptionPlanId",
                table: "SubscriptionPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_Orders_OrderId",
                table: "WalletTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_Wallet_WalletId",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPlan",
                table: "SubscriptionPlan");

            migrationBuilder.RenameTable(
                name: "WalletTransaction",
                newName: "WalletTransactions");

            migrationBuilder.RenameTable(
                name: "SubscriptionPlan",
                newName: "SubscriptionPlans");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransaction_WalletId",
                table: "WalletTransactions",
                newName: "IX_WalletTransactions_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransaction_OrderId",
                table: "WalletTransactions",
                newName: "IX_WalletTransactions_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPlans",
                table: "SubscriptionPlans",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Craftsman", "CRAFTSMAN" },
                    { "3", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AreaId", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "Gender", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetSession", "PasswordResetSessionExpiry", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "ResetCode", "ResetCodeExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName", "Zone" },
                values: new object[] { "ADMIN_ID", 0, "Cairo", null, "a657a756-9d48-4dd9-811b-996d594506bc", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Admin@gmail.com", true, "Admin", null, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEArzG7XgJVt3gKpzk/wD6KOWJtTdT4AbcClJmPfkec2cIfJfKGZsHaWZGZp08dNbIQ==", null, null, "1234567890", true, null, null, null, "0e567d07-491f-41b8-8774-ac335401708f", false, "Admin@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ADMIN_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPlanDetails_SubscriptionPlans_SubscriptionPlanId",
                table: "SubscriptionPlanDetails",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Orders_OrderId",
                table: "WalletTransactions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Wallet_WalletId",
                table: "WalletTransactions",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPlanDetails_SubscriptionPlans_SubscriptionPlanId",
                table: "SubscriptionPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Orders_OrderId",
                table: "WalletTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Wallet_WalletId",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPlans",
                table: "SubscriptionPlans");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ADMIN_ID" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID");

            migrationBuilder.RenameTable(
                name: "WalletTransactions",
                newName: "WalletTransaction");

            migrationBuilder.RenameTable(
                name: "SubscriptionPlans",
                newName: "SubscriptionPlan");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransactions_WalletId",
                table: "WalletTransaction",
                newName: "IX_WalletTransaction_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransactions_OrderId",
                table: "WalletTransaction",
                newName: "IX_WalletTransaction_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPlan",
                table: "SubscriptionPlan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPlanDetails_SubscriptionPlan_SubscriptionPlanId",
                table: "SubscriptionPlanDetails",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_Orders_OrderId",
                table: "WalletTransaction",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_Wallet_WalletId",
                table: "WalletTransaction",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
