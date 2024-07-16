using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class initii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                schema: "Account",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "Account",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Account",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                schema: "Account",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "Account",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtreShippingCost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcessShippingCost = table.Column<double>(type: "float", nullable: false),
                    ReturnShippingCost = table.Column<double>(type: "float", nullable: false),
                    BeackupDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepShippingCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepInvoiceDeliveryCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepBeackupDeliveryCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepShipmentMoveCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Accounts_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Account",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_City_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_City_ShipmentType_ShippingTypeId",
                        column: x => x.ShippingTypeId,
                        principalTable: "ShipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ClientId",
                table: "City",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_City_GovernorateId",
                table: "City",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ShippingTypeId",
                table: "City",
                column: "ShippingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropTable(
                name: "ShipmentType");

            migrationBuilder.DropColumn(
                name: "Branch",
                schema: "Account",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "Account",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Account",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Governorate",
                schema: "Account",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "Account",
                table: "Accounts");
        }
    }
}
