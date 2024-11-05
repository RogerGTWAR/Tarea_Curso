using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_Api.Migrations
{
    /// <inheritdoc />
    public partial class ini7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empresas");
        }
    }
}
