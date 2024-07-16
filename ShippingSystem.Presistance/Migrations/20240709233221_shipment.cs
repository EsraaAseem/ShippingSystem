using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class shipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ShippingCost",
                table: "Cities",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "InvoiceDeliveryCost",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GovernorateName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CourierShippingCostPercent",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CourierShipmentMoveCost",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CourierInvoiceDeliveryCostPercent",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CourierBeackupDeliveryCostPercent",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BeackupDeliveryCost",
                table: "Cities",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ShipmentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    NumDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtreShippingCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTypes", x => x.Id);
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
                    LocationFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_BackupId",
                table: "Shipments",
                column: "BackupId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CityId",
                table: "Shipments",
                column: "CityId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "ShipmentStatuses");

            migrationBuilder.DropTable(
                name: "ShipmentTypes");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.AlterColumn<string>(
                name: "ShippingCost",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDeliveryCost",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GovernorateName",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourierShippingCostPercent",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourierShipmentMoveCost",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourierInvoiceDeliveryCostPercent",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourierBeackupDeliveryCostPercent",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BeackupDeliveryCost",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
