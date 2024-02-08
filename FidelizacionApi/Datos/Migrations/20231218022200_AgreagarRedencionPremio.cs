using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class AgreagarRedencionPremio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redencion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremioId = table.Column<int>(type: "int", nullable: false),
                    FidelizadoId = table.Column<int>(type: "int", nullable: false),
                    CentroVentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redencion_Fidelizado_FidelizadoId",
                        column: x => x.FidelizadoId,
                        principalTable: "Fidelizado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redencion_Premio_PremioId",
                        column: x => x.PremioId,
                        principalTable: "Premio",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("a8dee0a4-0b7e-4576-9ee0-5fd7cca61bbb"));

            migrationBuilder.CreateIndex(
                name: "IX_Redencion_FidelizadoId",
                table: "Redencion",
                column: "FidelizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Redencion_PremioId",
                table: "Redencion",
                column: "PremioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redencion");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("ea8b570f-586c-4841-a487-abc066a35034"));
        }
    }
}
