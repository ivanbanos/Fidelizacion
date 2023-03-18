using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class PrimerUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CentroVentaId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CentroVentaId", "Contrasena", "EstadoId", "Guid", "NombreUsuario", "PerfilId" },
                values: new object[] { 1, null, "$2a$11$VLwdQFPB4zzuVjRkDwm8a.AhZ8Yw6w.00YWRxwxGx5kuYQeLmRv6e", 1, new Guid("91eb3ebb-a37f-4efc-a331-95988af89eab"), "Arthur", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CentroVentaId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
