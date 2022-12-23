using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class AutenticacionUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidelizado_InformacionAdicional_InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.DropIndex(
                name: "IX_Fidelizado_InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.DropColumn(
                name: "InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.AddColumn<int>(
                name: "FidelizadoId",
                table: "InformacionAdicional",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_FidelizadoId",
                table: "InformacionAdicional",
                column: "FidelizadoId",
                unique: true,
                filter: "[FidelizadoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionAdicional_Fidelizado_FidelizadoId",
                table: "InformacionAdicional",
                column: "FidelizadoId",
                principalTable: "Fidelizado",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionAdicional_Fidelizado_FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.DropIndex(
                name: "IX_InformacionAdicional_FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.DropColumn(
                name: "FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.AddColumn<int>(
                name: "InformacionAdicionalId",
                table: "Fidelizado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_InformacionAdicionalId",
                table: "Fidelizado",
                column: "InformacionAdicionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fidelizado_InformacionAdicional_InformacionAdicionalId",
                table: "Fidelizado",
                column: "InformacionAdicionalId",
                principalTable: "InformacionAdicional",
                principalColumn: "Id");
        }
    }
}
