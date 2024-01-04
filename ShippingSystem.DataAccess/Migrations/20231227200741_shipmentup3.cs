using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class shipmentup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BackupId",
                table: "Shipments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_BackupId",
                table: "Shipments",
                column: "BackupId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShippingId",
                table: "Shipments",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_BackUps_BackupId",
                table: "Shipments",
                column: "BackupId",
                principalTable: "BackUps",
                principalColumn: "BackupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shippings_ShippingId",
                table: "Shipments",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "ShippingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_BackUps_BackupId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shippings_ShippingId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_BackupId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShippingId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "BackupId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "Shipments");
        }
    }
}
