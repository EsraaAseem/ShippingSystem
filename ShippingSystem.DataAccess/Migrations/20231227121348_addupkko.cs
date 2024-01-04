using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addupkko : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentStatusId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentStatusId",
                table: "Shipments",
                column: "ShipmentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_shipmentStatuses_ShipmentStatusId",
                table: "Shipments",
                column: "ShipmentStatusId",
                principalTable: "shipmentStatuses",
                principalColumn: "ShipmentStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_shipmentStatuses_ShipmentStatusId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShipmentStatusId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipmentStatusId",
                table: "Shipments");
        }
    }
}
