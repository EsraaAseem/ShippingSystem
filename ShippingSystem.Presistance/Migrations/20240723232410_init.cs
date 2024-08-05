using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCost = table.Column<double>(type: "float", nullable: false),
                    ExcessShippingCost = table.Column<double>(type: "float", nullable: false),
                    ReturnShippingCost = table.Column<double>(type: "float", nullable: false),
                    BeackupDeliveryCost = table.Column<double>(type: "float", nullable: false),
                    InvoiceDeliveryCost = table.Column<double>(type: "float", nullable: false),
                    CourierShippingCostPercent = table.Column<double>(type: "float", nullable: false),
                    CourierInvoiceDeliveryCostPercent = table.Column<double>(type: "float", nullable: false),
                    CourierBeackupDeliveryCostPercent = table.Column<double>(type: "float", nullable: false),
                    CourierShipmentMoveCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentStatusName = table.Column<int>(type: "int", nullable: false),
                    ShipmentStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumDays = table.Column<int>(type: "int", nullable: false),
                    ExtreShippingCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Accounts_Id",
                        column: x => x.Id,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_Id",
                        column: x => x.Id,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "Account",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.AppUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representatives_Accounts_Id",
                        column: x => x.Id,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Account",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Account",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Account",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Account",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Account",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceDeliveryCost = table.Column<double>(type: "float", nullable: false),
                    ItemsCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Account",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beackups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepresentativeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beackups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beackups_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Account",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beackups_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalSchema: "Account",
                        principalTable: "Representatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beackups_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepresentativeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShipped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalSchema: "Account",
                        principalTable: "Representatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shippings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciverEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    ShippingPrice = table.Column<double>(type: "float", nullable: false),
                    ProductsPrice = table.Column<double>(type: "float", nullable: false),
                    NetCost = table.Column<double>(type: "float", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId1",
                        column: x => x.InvoiceId1,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reciver_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reciver_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reciver_StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reciver_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reciver_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    MovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProccedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipmentStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    GeneralStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalRealPrice = table.Column<double>(type: "float", nullable: false),
                    QrCodeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Beackups_BackupId",
                        column: x => x.BackupId,
                        principalTable: "Beackups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Account",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_ShipmentStatuses_ShipmentStatusId",
                        column: x => x.ShipmentStatusId,
                        principalTable: "ShipmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_ShipmentTypes_ShipmentTypeId",
                        column: x => x.ShipmentTypeId,
                        principalTable: "ShipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Shippings_ShippingId1",
                        column: x => x.ShippingId1,
                        principalTable: "Shippings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    RecivedAmount = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.ShipmentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Product_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "Id", "ExtreShippingCost", "Name", "NumDays" },
                values: new object[,]
                {
                    { 1, 20.0, "Normal", 7 },
                    { 2, 30.0, "In4Days", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Account",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                schema: "Account",
                table: "Accounts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Account",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beackups_ClientId",
                table: "Beackups",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Beackups_RepresentativeId",
                table: "Beackups",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beackups_VehicleId",
                table: "Beackups",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId1",
                table: "InvoiceItems",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Account",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Account",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_BackupId",
                table: "Shipments",
                column: "BackupId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CityId",
                table: "Shipments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ClientId",
                table: "Shipments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentStatusId",
                table: "Shipments",
                column: "ShipmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentTypeId",
                table: "Shipments",
                column: "ShipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShippingId",
                table: "Shipments",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShippingId1",
                table: "Shipments",
                column: "ShippingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_RepresentativeId",
                table: "Shippings",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_VehicleId",
                table: "Shippings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Account",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Account",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Account",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRequest");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Beackups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ShipmentStatuses");

            migrationBuilder.DropTable(
                name: "ShipmentTypes");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Representatives",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Account");
        }
    }
}
