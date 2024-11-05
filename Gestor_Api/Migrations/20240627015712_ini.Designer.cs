﻿// <auto-generated />
using System;
using Gestor_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestor_Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240627015712_ini")]
    partial class ini
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SharedModels.EmpleadoDatos", b =>
                {
                    b.Property<int>("Empleado_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Empleado_Id"));

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fin_Contrato")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("HorasExtras")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Inicio_Contrato")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroCedula")
                        .HasColumnType("int");

                    b.Property<int>("NumeroINSS")
                        .HasColumnType("int");

                    b.Property<int>("NumeroRuc")
                        .HasColumnType("int");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Registered")
                        .HasColumnType("bit");

                    b.Property<decimal>("SalarioMensual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Empleado_Id");

                    b.ToTable("EmpleadosDatos");
                });

            modelBuilder.Entity("SharedModels.Ingresos", b =>
                {
                    b.Property<int>("Ingresos_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ingresos_Id"));

                    b.Property<decimal?>("Adelanto_Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Antiguedad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Empleado_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fin_Periodo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio_Periodo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Inss")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ir")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Nocturnidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Otras_Deducciones")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OtrosIngresos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PagoHorasExtras")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RiesgoLaboral")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalarioBruto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalarioMensual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalarioNeto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Ingresos_Id");

                    b.ToTable("EmpleadosIngresos");
                });

            modelBuilder.Entity("SharedModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
