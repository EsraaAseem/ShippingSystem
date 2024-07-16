using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class shipmentup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QrCodeUrl",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ClientId",
                table: "Shipments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Clients_ClientId",
                table: "Shipments",
                column: "ClientId",
                principalSchema: "Account",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Clients_ClientId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ClientId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "QrCodeUrl",
                table: "Shipments");
        }
    }
}
