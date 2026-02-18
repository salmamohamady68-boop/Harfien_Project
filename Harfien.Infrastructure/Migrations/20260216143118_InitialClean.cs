using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_AspNetUsers_ReceiverId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_AspNetUsers_SenderId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Chat_ChatId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_AspNetUsers_UserId",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_Wallet_WalletId",
                table: "WalletTransaction");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId1",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_UserId",
                table: "Wallets",
                newName: "IX_Wallets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_SenderId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ReceiverId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ChatId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CraftsmanAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CraftsmanId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftsmanAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CraftsmanAvailabilities_Craftsmen_CraftsmanId",
                        column: x => x.CraftsmanId,
                        principalTable: "Craftsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Craftsman");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "169c78ea-252f-4f9b-ab72-452a570214f2", "AQAAAAIAAYagAAAAEOm4kSQAwMLXzhzi70EoKf8WJUh9Bl1M9u4u3B0oEUHXIDR+RGyVNsKH/4rx9enfSA==", "1a843e63-1923-487d-b898-bb66154ab73d", "Admin@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_CraftsmanAvailabilities_CraftsmanId",
                table: "CraftsmanAvailabilities",
                column: "CraftsmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ReceiverId",
                table: "ChatMessages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderId",
                table: "ChatMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Chat_ChatId",
                table: "ChatMessages",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_Wallets_WalletId",
                table: "WalletTransaction",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ReceiverId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Chat_ChatId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_Wallets_WalletId",
                table: "WalletTransaction");

            migrationBuilder.DropTable(
                name: "CraftsmanAvailabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_UserId",
                table: "Wallet",
                newName: "IX_Wallet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notification",
                newName: "IX_Notification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ReceiverId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ChatId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Carftsman");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4474bdb8-9591-4b90-a46f-86b828a09753", "AQAAAAIAAYagAAAAEDxlTb5/0unSSn9yGWgSsovDrl8WaprZEs62lTPFxhsWAq2t3e/3qT9IlXi15B8FhQ==", "d29a8cda-e482-4b2c-9592-f057b2804d6b", "Admin@gamil.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId1",
                table: "Orders",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_AspNetUsers_ReceiverId",
                table: "ChatMessage",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_AspNetUsers_SenderId",
                table: "ChatMessage",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Chat_ChatId",
                table: "ChatMessage",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId1",
                table: "Orders",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_AspNetUsers_UserId",
                table: "Wallet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
