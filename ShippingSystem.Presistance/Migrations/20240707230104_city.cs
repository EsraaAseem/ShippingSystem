using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class city : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beackup_Clients_ClientId",
                table: "Beackup");

            migrationBuilder.DropForeignKey(
                name: "FK_Beackup_Representatives_RepresentativeId",
                table: "Beackup");

            migrationBuilder.DropForeignKey(
                name: "FK_Beackup_Vehicles_VehicleId",
                table: "Beackup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beackup",
                table: "Beackup");

            migrationBuilder.RenameTable(
                name: "Beackup",
                newName: "Beackups");

            migrationBuilder.RenameIndex(
                name: "IX_Beackup_VehicleId",
                table: "Beackups",
                newName: "IX_Beackups_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Beackup_RepresentativeId",
                table: "Beackups",
                newName: "IX_Beackups_RepresentativeId");

            migrationBuilder.RenameIndex(
                name: "IX_Beackup_ClientId",
                table: "Beackups",
                newName: "IX_Beackups_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beackups",
                table: "Beackups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateName = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcessShippingCost = table.Column<double>(type: "float", nullable: false),
                    ReturnShippingCost = table.Column<double>(type: "float", nullable: false),
                    BeackupDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourierShippingCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourierInvoiceDeliveryCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourierBeackupDeliveryCostPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourierShipmentMoveCost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Beackups_Clients_ClientId",
                table: "Beackups",
                column: "ClientId",
                principalSchema: "Account",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beackups_Representatives_RepresentativeId",
                table: "Beackups",
                column: "RepresentativeId",
                principalSchema: "Account",
                principalTable: "Representatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beackups_Vehicles_VehicleId",
                table: "Beackups",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beackups_Clients_ClientId",
                table: "Beackups");

            migrationBuilder.DropForeignKey(
                name: "FK_Beackups_Representatives_RepresentativeId",
                table: "Beackups");

            migrationBuilder.DropForeignKey(
                name: "FK_Beackups_Vehicles_VehicleId",
                table: "Beackups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beackups",
                table: "Beackups");

            migrationBuilder.RenameTable(
                name: "Beackups",
                newName: "Beackup");

            migrationBuilder.RenameIndex(
                name: "IX_Beackups_VehicleId",
                table: "Beackup",
                newName: "IX_Beackup_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Beackups_RepresentativeId",
                table: "Beackup",
                newName: "IX_Beackup_RepresentativeId");

            migrationBuilder.RenameIndex(
                name: "IX_Beackups_ClientId",
                table: "Beackup",
                newName: "IX_Beackup_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beackup",
                table: "Beackup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beackup_Clients_ClientId",
                table: "Beackup",
                column: "ClientId",
                principalSchema: "Account",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beackup_Representatives_RepresentativeId",
                table: "Beackup",
                column: "RepresentativeId",
                principalSchema: "Account",
                principalTable: "Representatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beackup_Vehicles_VehicleId",
                table: "Beackup",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
