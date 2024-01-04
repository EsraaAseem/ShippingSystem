using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class shipmentup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWight",
                table: "Shipments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalWight",
                table: "Shipments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
