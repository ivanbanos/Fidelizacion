using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class FidelizadoEInformacionGeneral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Compania",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "CentroVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmpresaFidelizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tefelono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorcentajePuntos = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaFidelizado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fidelizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puntos = table.Column<float>(type: "real", nullable: false),
                    PorcentajePuntos = table.Column<float>(type: "real", nullable: false),
                    PuntosReservados = table.Column<float>(type: "real", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimoReclamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CentroVentaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fidelizado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fidelizado_CentroVenta_CentroVentaId",
                        column: x => x.CentroVentaId,
                        principalTable: "CentroVenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fidelizado_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fidelizado_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacionAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrato = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroHijos = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    ProfesionId = table.Column<int>(type: "int", nullable: true),
                    EmpresaFidelizadoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FidelizadoId = table.Column<int>(type: "int", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_EmpresaFidelizado_EmpresaFidelizadoId",
                        column: x => x.EmpresaFidelizadoId,
                        principalTable: "EmpresaFidelizado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_EstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_Fidelizado_FidelizadoId",
                        column: x => x.FidelizadoId,
                        principalTable: "Fidelizado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_Profesion_ProfesionId",
                        column: x => x.ProfesionId,
                        principalTable: "Profesion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformacionAdicional_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "EstadoCivil",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Solterio" },
                    { 2, "Casado" },
                    { 3, "Divorsiado" },
                    { 4, "Viudo" }
                });

            migrationBuilder.InsertData(
                table: "Profesion",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ingeniero" },
                    { 2, "Medico" },
                    { 3, "Estudiante" }
                });

            migrationBuilder.InsertData(
                table: "Sexo",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" },
                    { 3, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "TipoDocumento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cedula" },
                    { 2, "Cedula Extranjeria" },
                    { 3, "Pasaporte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compania_EstadoId",
                table: "Compania",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroVenta_EstadoId",
                table: "CentroVenta",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_CentroVentaId",
                table: "Fidelizado",
                column: "CentroVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_EstadoId",
                table: "Fidelizado",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_TipoDocumentoId",
                table: "Fidelizado",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_CiudadId",
                table: "InformacionAdicional",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_EmpresaFidelizadoId",
                table: "InformacionAdicional",
                column: "EmpresaFidelizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_EstadoCivilId",
                table: "InformacionAdicional",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_FidelizadoId",
                table: "InformacionAdicional",
                column: "FidelizadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_ProfesionId",
                table: "InformacionAdicional",
                column: "ProfesionId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_SexoId",
                table: "InformacionAdicional",
                column: "SexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroVenta_Estado_EstadoId",
                table: "CentroVenta",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compania_Estado_EstadoId",
                table: "Compania",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroVenta_Estado_EstadoId",
                table: "CentroVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Compania_Estado_EstadoId",
                table: "Compania");

            migrationBuilder.DropTable(
                name: "InformacionAdicional");

            migrationBuilder.DropTable(
                name: "EmpresaFidelizado");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Fidelizado");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropIndex(
                name: "IX_Compania_EstadoId",
                table: "Compania");

            migrationBuilder.DropIndex(
                name: "IX_CentroVenta_EstadoId",
                table: "CentroVenta");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Compania");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "CentroVenta");
        }
    }
}
