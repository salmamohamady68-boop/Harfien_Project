using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    ResetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetCodeExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetSession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetSessionExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Craftsmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Craftsmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Craftsmen_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionPlanDetails_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CraftsmanId = table.Column<int>(type: "int", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Craftsmen_CraftsmanId",
                        column: x => x.CraftsmanId,
                        principalTable: "Craftsmen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CraftsmanId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Craftsmen_CraftsmanId",
                        column: x => x.CraftsmanId,
                        principalTable: "Craftsmen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvidenceAttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminResolutionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CraftsmanId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                values: new object[] { "ADMIN_ID", 0, "Cairo", null, "00348f4d-b4ef-48eb-afa3-0452c0d9e748", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Admin@gmail.com", true, "Admin", null, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENPLFwt5ruzWosD/s1/gYOXYfPz076o07tzlhY05/Efj18NKKyHTBP/zSs6NB6l1gQ==", null, null, "1234567890", true, null, null, null, "6e271328-bb5f-4c8f-a1c3-dfa7d2509048", false, "Admin@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القاهرة" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الجيزة" },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الإسكندرية" },
                    { 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الدقهلية" },
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشرقية" },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القليوبية" },
                    { 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنوفية" },
                    { 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البحيرة" },
                    { 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الغربية" },
                    { 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الشيخ" },
                    { 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمياط" },
                    { 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الإسماعيلية" },
                    { 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السويس" },
                    { 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بورسعيد" },
                    { 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شمال سيناء" },
                    { 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "جنوب سيناء" },
                    { 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البحر الأحمر" },
                    { 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الوادي الجديد" },
                    { 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مطروح" },
                    { 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بني سويف" },
                    { 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفيوم" },
                    { 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنيا" },
                    { 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسيوط" },
                    { 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سوهاج" },
                    { 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قنا" },
                    { 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الأقصر" },
                    { 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسوان" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المعادي" },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "حلوان" },
                    { 3, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الزمالك" },
                    { 4, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مصر الجديدة" },
                    { 5, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "النزهة" },
                    { 6, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مدينة نصر" },
                    { 7, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "التجمع الخامس" },
                    { 8, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشروق" },
                    { 9, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "العمرانية" },
                    { 10, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الهرم" },
                    { 11, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الدقي" },
                    { 12, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشيخ زايد" },
                    { 13, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "6 أكتوبر" },
                    { 14, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سيدي جابر" },
                    { 15, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محرم بك" },
                    { 16, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "برج العرب" },
                    { 17, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحضرة" },
                    { 18, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الإبراهيمية" },
                    { 19, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنصورة" },
                    { 20, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شربين" },
                    { 21, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أجا" },
                    { 22, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السنبلاوين" },
                    { 23, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "تمي الأمديد" },
                    { 24, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الزقازيق" },
                    { 25, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بلبيس" },
                    { 26, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر صقر" },
                    { 27, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحسينية" },
                    { 28, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "10 رمضان" },
                    { 29, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بنها" },
                    { 30, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الخصوص" },
                    { 31, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شبرا الخيمة" },
                    { 32, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القناطر الخيرية" },
                    { 33, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طوخ" },
                    { 34, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شبين الكوم" },
                    { 35, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قويسنا" },
                    { 36, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أشمون" },
                    { 37, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السادات" },
                    { 38, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الباجور" },
                    { 39, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمنهور" },
                    { 40, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رشيد" },
                    { 41, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إيتاي البارود" },
                    { 42, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الدوار" },
                    { 43, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الرحمانية" },
                    { 44, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طنطا" },
                    { 45, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمنود" },
                    { 46, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "زفتى" },
                    { 47, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المحلة الكبرى" },
                    { 48, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الزيات" },
                    { 49, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بيلا" },
                    { 50, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحامول" },
                    { 51, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دسوق" },
                    { 52, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سيدي سالم" },
                    { 53, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فوه" },
                    { 54, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمياط الجديدة" },
                    { 55, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فارسكور" },
                    { 56, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رأس البر" },
                    { 57, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر سعد" },
                    { 58, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "عزبة البرج" },
                    { 59, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القنطرة شرق" },
                    { 60, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القنطرة غرب" },
                    { 61, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فايد" },
                    { 62, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القصاصين" },
                    { 63, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "التل الكبير" },
                    { 64, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الجناين" },
                    { 65, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "عتاقة" },
                    { 66, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الأربعين" },
                    { 67, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "حي فيصل" },
                    { 68, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شرق بورسعيد" },
                    { 69, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "غرب بورسعيد" },
                    { 70, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بورفؤاد" },
                    { 71, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الضواحي" },
                    { 72, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "العريش" },
                    { 73, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رفح" },
                    { 74, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشيخ زويد" },
                    { 75, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بئر العبد" },
                    { 76, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نخل" },
                    { 77, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شرم الشيخ" },
                    { 78, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دهب" },
                    { 79, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نويبع" },
                    { 80, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طابا" },
                    { 81, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سانت كاترين" },
                    { 82, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الغردقة" },
                    { 83, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سفاجا" },
                    { 84, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القصير" },
                    { 85, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مرسى علم" },
                    { 86, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رأس غارب" },
                    { 87, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الخارجة" },
                    { 88, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الداخلة" },
                    { 89, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "باريس" },
                    { 90, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفرافرة" },
                    { 91, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مرسى مطروح" },
                    { 92, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السلوم" },
                    { 93, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الضبعة" },
                    { 94, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "النجيلة" },
                    { 95, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ناصر" },
                    { 96, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفشن" },
                    { 97, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمسطا" },
                    { 98, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إهناسيا" },
                    { 99, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ببا" },
                    { 100, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "يوسف الصديق" },
                    { 101, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إطسا" },
                    { 102, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سنورس" },
                    { 103, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طامية" },
                    { 104, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبشواي" },
                    { 105, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمالوط" },
                    { 106, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ملوي" },
                    { 107, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بني مزار" },
                    { 108, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبو قرقاص" },
                    { 109, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مغاغة" },
                    { 110, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ديروط" },
                    { 111, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "صدفا" },
                    { 112, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفتح" },
                    { 113, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبنوب" },
                    { 114, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "منفلوط" },
                    { 115, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أخميم" },
                    { 116, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "جرجا" },
                    { 117, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البلينا" },
                    { 118, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المراغة" },
                    { 119, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دار السلام" },
                    { 120, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نجع حمادي" },
                    { 121, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قفط" },
                    { 122, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دندرة" },
                    { 123, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبو تشت" },
                    { 124, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قنا الجديدة" },
                    { 125, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القرنة" },
                    { 126, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مدينة الأقصر" },
                    { 127, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الزينية" },
                    { 128, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البياضية" },
                    { 129, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دراو" },
                    { 130, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كوم أمبو" },
                    { 131, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إدفو" },
                    { 132, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نصر النوبة" },
                    { 133, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسوان الجديدة" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ADMIN_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AreaId",
                table: "AspNetUsers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ApplicationUserId",
                table: "ChatMessages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ReceiverId",
                table: "ChatMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId_ReceiverId",
                table: "ChatMessages",
                columns: new[] { "SenderId", "ReceiverId" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrderId",
                table: "Complaints",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CraftsmanAvailabilities_CraftsmanId",
                table: "CraftsmanAvailabilities",
                column: "CraftsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Craftsmen_UserId",
                table: "Craftsmen",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CraftsmanId",
                table: "Orders",
                column: "CraftsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CraftsmanId",
                table: "Services",
                column: "CraftsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanDetails_ClientId",
                table: "SubscriptionPlanDetails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPlanDetails_SubscriptionPlanId",
                table: "SubscriptionPlanDetails",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                table: "Wallet",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_OrderId",
                table: "WalletTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletId",
                table: "WalletTransactions",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "CraftsmanAvailabilities");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SubscriptionPlanDetails");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Craftsmen");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
