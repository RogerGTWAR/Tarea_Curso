using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_Api.Migrations
{
    /// <inheritdoc />
    public partial class ini10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre_Empresa",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Empresas");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Empresa",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
