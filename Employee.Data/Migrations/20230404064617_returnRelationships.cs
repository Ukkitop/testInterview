using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRole.Data.Migrations
{
    /// <inheritdoc />
    public partial class returnRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Employees_EmployeeDataModelId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_EmployeeDataModelId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EmployeeDataModelId",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "EmployeeDataModelRoleDataModel",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDataModelRoleDataModel", x => new { x.EmployeesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EmployeeDataModelRoleDataModel_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDataModelRoleDataModel_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDataModelRoleDataModel_RolesId",
                table: "EmployeeDataModelRoleDataModel",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDataModelRoleDataModel");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeDataModelId",
                table: "Roles",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EmployeeDataModelId",
                table: "Roles",
                column: "EmployeeDataModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Employees_EmployeeDataModelId",
                table: "Roles",
                column: "EmployeeDataModelId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
