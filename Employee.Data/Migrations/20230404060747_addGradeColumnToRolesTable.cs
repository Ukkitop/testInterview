using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRole.Data.Migrations
{
    /// <inheritdoc />
    public partial class addGradeColumnToRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Roles");
        }
    }
}
