using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElevatorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    floorno = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true),
                    officefloor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftLogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: true),
                    start = table.Column<int>(type: "int", nullable: true),
                    end = table.Column<int>(type: "int", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_LiftLogs_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "elevatorLoggings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    floorno = table.Column<int>(type: "int", nullable: false),
                    elogId = table.Column<int>(type: "int", nullable: true),
                    logLiftId = table.Column<int>(type: "int", nullable: true),
                    liftlogid = table.Column<int>(type: "int", nullable: true),
                    ElevatorLogAccessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elevatorLoggings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_elevatorLoggings_ElevatorLogs_ElevatorLogAccessId",
                        column: x => x.ElevatorLogAccessId,
                        principalTable: "ElevatorLogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_elevatorLoggings_LiftLogs_liftlogid",
                        column: x => x.liftlogid,
                        principalTable: "LiftLogs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_elevatorLoggings_ElevatorLogAccessId",
                table: "elevatorLoggings",
                column: "ElevatorLogAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_elevatorLoggings_liftlogid",
                table: "elevatorLoggings",
                column: "liftlogid");

            migrationBuilder.CreateIndex(
                name: "IX_LiftLogs_employeeId",
                table: "LiftLogs",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "elevatorLoggings");

            migrationBuilder.DropTable(
                name: "ElevatorLogs");

            migrationBuilder.DropTable(
                name: "LiftLogs");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
