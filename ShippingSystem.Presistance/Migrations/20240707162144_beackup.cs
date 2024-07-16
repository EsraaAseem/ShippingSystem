using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class beackup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beackup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepresentativeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beackup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beackup_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Account",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beackup_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalSchema: "Account",
                        principalTable: "Representatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beackup_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beackup_ClientId",
                table: "Beackup",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Beackup_RepresentativeId",
                table: "Beackup",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beackup_VehicleId",
                table: "Beackup",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beackup");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
