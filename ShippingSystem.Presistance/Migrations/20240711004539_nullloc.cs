using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class nullloc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "ShipmentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"));
            */
            migrationBuilder.AlterColumn<string>(
                name: "LocationTo",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocationFrom",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentLocation",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentStatusDescription",
                table: "ShipmentStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationTo",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationFrom",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentLocation",
                table: "Shippings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentStatusDescription",
                table: "ShipmentStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

           /* migrationBuilder.InsertData(
                table: "ShipmentStatuses",
                columns: new[] { "Id", "ShipmentStatusDescription", "ShipmentStatusName" },
                values: new object[] { new Guid("1704f7d4-2929-41a1-92ce-d1129b151ca0"),
                    "Reciver reject the shipment", "Returned" });*/
        }
    }
}
