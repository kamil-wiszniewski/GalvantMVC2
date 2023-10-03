using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalvantMVC2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crane",
                columns: table => new
                {
                    CraneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiftingCapacity = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    RaisingHeight = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    WorkloadGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    UDTExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectricalExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResursDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crane", x => x.CraneId);
                    table.ForeignKey(
                        name: "FK_Crane_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoist",
                columns: table => new
                {
                    HoistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiftingCapacity = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    RaisingHeight = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    WorkloadGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    UDTExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectricalExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResursDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoist", x => x.HoistId);
                    table.ForeignKey(
                        name: "FK_Hoist_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tank",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PermissiblePressure = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    UDTExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectricalExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResursDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tank", x => x.TankId);
                    table.ForeignKey(
                        name: "FK_Tank_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crane_EquipmentId",
                table: "Crane",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoist_EquipmentId",
                table: "Hoist",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tank_EquipmentId",
                table: "Tank",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crane");

            migrationBuilder.DropTable(
                name: "Hoist");

            migrationBuilder.DropTable(
                name: "Tank");
        }
    }
}
