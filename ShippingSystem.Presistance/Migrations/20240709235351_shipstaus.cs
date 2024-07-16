using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class shipstaus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumDays",
                table:  "ShipmentTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ShipmentStatuses",
                columns: new[] { "Id", "ShipmentStatusDescription", "ShipmentStatusName" },
                values: new object[] { new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"), "Reciver reject the shipment", "Returned" });

            migrationBuilder.InsertData(
                table: "ShipmentTypes",
                columns: new[] { "Id", "ExtreShippingCost", "Name", "NumDays" },
                values: new object[,]
                {
                    { 1, 20.0, "Normal", 7 },
                    { 2, 30.0, "In4Days", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShipmentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"));

            migrationBuilder.DeleteData(
                table: "ShipmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShipmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "NumDays",
                table: "ShipmentTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
