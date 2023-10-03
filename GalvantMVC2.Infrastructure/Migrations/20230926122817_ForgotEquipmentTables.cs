using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalvantMVC2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForgotEquipmentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crane_Equipment_EquipmentId",
                table: "Crane");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoist_Equipment_EquipmentId",
                table: "Hoist");

            migrationBuilder.DropForeignKey(
                name: "FK_Tank_Equipment_EquipmentId",
                table: "Tank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tank",
                table: "Tank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoist",
                table: "Hoist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crane",
                table: "Crane");

            migrationBuilder.RenameTable(
                name: "Tank",
                newName: "Tanks");

            migrationBuilder.RenameTable(
                name: "Hoist",
                newName: "Hoists");

            migrationBuilder.RenameTable(
                name: "Crane",
                newName: "Cranes");

            migrationBuilder.RenameIndex(
                name: "IX_Tank_EquipmentId",
                table: "Tanks",
                newName: "IX_Tanks_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Hoist_EquipmentId",
                table: "Hoists",
                newName: "IX_Hoists_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Crane_EquipmentId",
                table: "Cranes",
                newName: "IX_Cranes_EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tanks",
                table: "Tanks",
                column: "TankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoists",
                table: "Hoists",
                column: "HoistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cranes",
                table: "Cranes",
                column: "CraneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cranes_Equipment_EquipmentId",
                table: "Cranes",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoists_Equipment_EquipmentId",
                table: "Hoists",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Equipment_EquipmentId",
                table: "Tanks",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cranes_Equipment_EquipmentId",
                table: "Cranes");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoists_Equipment_EquipmentId",
                table: "Hoists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Equipment_EquipmentId",
                table: "Tanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tanks",
                table: "Tanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoists",
                table: "Hoists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cranes",
                table: "Cranes");

            migrationBuilder.RenameTable(
                name: "Tanks",
                newName: "Tank");

            migrationBuilder.RenameTable(
                name: "Hoists",
                newName: "Hoist");

            migrationBuilder.RenameTable(
                name: "Cranes",
                newName: "Crane");

            migrationBuilder.RenameIndex(
                name: "IX_Tanks_EquipmentId",
                table: "Tank",
                newName: "IX_Tank_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Hoists_EquipmentId",
                table: "Hoist",
                newName: "IX_Hoist_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cranes_EquipmentId",
                table: "Crane",
                newName: "IX_Crane_EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tank",
                table: "Tank",
                column: "TankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoist",
                table: "Hoist",
                column: "HoistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crane",
                table: "Crane",
                column: "CraneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crane_Equipment_EquipmentId",
                table: "Crane",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoist_Equipment_EquipmentId",
                table: "Hoist",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tank_Equipment_EquipmentId",
                table: "Tank",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
