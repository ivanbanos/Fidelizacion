using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoVencimiento",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Tiempo" });

            migrationBuilder.InsertData(
                table: "TipoVencimiento",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Conexion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoVencimiento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoVencimiento",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
