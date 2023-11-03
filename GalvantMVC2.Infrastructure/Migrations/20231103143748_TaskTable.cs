using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalvantMVC2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Equipment",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Tasks",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Tasks",
                type: "decimal(9,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TaskEmployee",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEmployee", x => new { x.TaskId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_TaskEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEmployee_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskFile",
                columns: table => new
                {
                    TaskFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFile", x => x.TaskFileId);
                    table.ForeignKey(
                        name: "FK_TaskFile_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EquipmentId",
                table: "Tasks",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEmployee_EmployeeId",
                table: "TaskEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFile_TaskId",
                table: "TaskFile",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Equipment_EquipmentId",
                table: "Tasks",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Equipment_EquipmentId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "TaskEmployee");

            migrationBuilder.DropTable(
                name: "TaskFile");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EquipmentId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "Equipment");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tasks",
                newName: "CreationDate");
        }
    }
}
