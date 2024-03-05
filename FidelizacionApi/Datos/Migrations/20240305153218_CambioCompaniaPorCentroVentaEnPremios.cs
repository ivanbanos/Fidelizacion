using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class CambioCompaniaPorCentroVentaEnPremios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premio_Compania_CompaniaId",
                table: "Premio");

            migrationBuilder.DropIndex(
                name: "IX_Premio_CompaniaId",
                table: "Premio");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "Premio");

            migrationBuilder.AddColumn<int>(
                name: "CentroVentaId",
                table: "Premio",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6b215857-7cac-41e9-8ffa-3f8a72c3e932"));

            migrationBuilder.CreateIndex(
                name: "IX_Premio_CentroVentaId",
                table: "Premio",
                column: "CentroVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premio_CentroVenta_CentroVentaId",
                table: "Premio",
                column: "CentroVentaId",
                principalTable: "CentroVenta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premio_CentroVenta_CentroVentaId",
                table: "Premio");

            migrationBuilder.DropIndex(
                name: "IX_Premio_CentroVentaId",
                table: "Premio");

            migrationBuilder.DropColumn(
                name: "CentroVentaId",
                table: "Premio");

            migrationBuilder.AddColumn<int>(
                name: "CompaniaId",
                table: "Premio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("a7ce468b-6628-428d-8b7e-023bae29183e"));

            migrationBuilder.CreateIndex(
                name: "IX_Premio_CompaniaId",
                table: "Premio",
                column: "CompaniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premio_Compania_CompaniaId",
                table: "Premio",
                column: "CompaniaId",
                principalTable: "Compania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
