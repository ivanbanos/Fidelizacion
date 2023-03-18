using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class AgregarCentroVentaAUsurio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CentroVentaId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CentroVentaId",
                table: "Usuario",
                column: "CentroVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_CentroVenta_CentroVentaId",
                table: "Usuario",
                column: "CentroVentaId",
                principalTable: "CentroVenta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_CentroVenta_CentroVentaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CentroVentaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CentroVentaId",
                table: "Usuario");
        }
    }
}
