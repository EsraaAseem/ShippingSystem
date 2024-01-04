using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class shipmentup4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shippings_ShippingId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShippingId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "Shipments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShippingId",
                table: "Shipments",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shippings_ShippingId",
                table: "Shipments",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "ShippingId");
        }
    }
}
