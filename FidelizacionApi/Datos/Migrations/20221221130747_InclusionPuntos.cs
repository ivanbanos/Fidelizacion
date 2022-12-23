using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class InclusionPuntos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidelizado_TipoDocumento_TipoDocumentoId",
                table: "Fidelizado");

            migrationBuilder.DropIndex(
                name: "IX_Fidelizado_TipoDocumentoId",
                table: "Fidelizado");

            migrationBuilder.AlterColumn<int>(
                name: "CentroVentaId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Punto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorVenta = table.Column<float>(type: "real", nullable: false),
                    Factura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FidelizadoId = table.Column<int>(type: "int", nullable: false),
                    CentroVentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punto_CentroVenta_CentroVentaId",
                        column: x => x.CentroVentaId,
                        principalTable: "CentroVenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punto_Fidelizado_FidelizadoId",
                        column: x => x.FidelizadoId,
                        principalTable: "Fidelizado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Punto_CentroVentaId",
                table: "Punto",
                column: "CentroVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Punto_FidelizadoId",
                table: "Punto",
                column: "FidelizadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punto");

            migrationBuilder.AlterColumn<int>(
                name: "CentroVentaId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_TipoDocumentoId",
                table: "Fidelizado",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fidelizado_TipoDocumento_TipoDocumentoId",
                table: "Fidelizado",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
