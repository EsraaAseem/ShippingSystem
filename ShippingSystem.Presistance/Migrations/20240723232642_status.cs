using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShipmentStatuses",
                columns: new[] { "Id", "ShipmentStatusDescription", "ShipmentStatusName" },
                values: new object[] { new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"), "Reciver reject the shipment", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShipmentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"));
        }
    }
}
