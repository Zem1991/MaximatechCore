using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "PRODUCT");

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "PRODUCT",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "PRODUCT");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "PRODUCT",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
