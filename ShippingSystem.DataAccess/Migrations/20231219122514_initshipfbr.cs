using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initshipfbr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProductTotalPrice",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProductTotalWeight",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTotalPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductTotalWeight",
                table: "Product");
        }
    }
}
