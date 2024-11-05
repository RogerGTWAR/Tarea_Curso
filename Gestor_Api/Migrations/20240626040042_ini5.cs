using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_Api.Migrations
{
    /// <inheritdoc />
    public partial class ini5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpleadosDatos",
                columns: table => new
                {
                    Empleado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCedula = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    SalarioMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasExtras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroINSS = table.Column<int>(type: "int", nullable: false),
                    NumeroRuc = table.Column<int>(type: "int", nullable: false),
                    Inicio_Contrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin_Contrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Registered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosDatos", x => x.Empleado_Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadosIngresos",
                columns: table => new
                {
                    Ingresos_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empleado_Id = table.Column<int>(type: "int", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Antiguedad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagoHorasExtras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiesgoLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Nocturnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalarioBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inss = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Otras_Deducciones = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Adelanto_Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalarioNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inicio_Periodo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin_Periodo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosIngresos", x => x.Ingresos_Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Empresa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruc = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Empresa_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosDatos");

            migrationBuilder.DropTable(
                name: "EmpleadosIngresos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
